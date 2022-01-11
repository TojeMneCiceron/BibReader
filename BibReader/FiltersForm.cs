using BibReader.ColumnSorting;
using BibReader.Statistic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader
{
    public partial class FiltersForm : Form
    {
        public List<string> Years { get; set; } = new List<string>();
        public List<string> Conference { get; set; } = new List<string>();
        public List<string> Types { get; set; } = new List<string>();
        public List<string> Sources { get; set; } = new List<string>();
        public List<string> Journals { get; set; } = new List<string>();
        public List<string> Geography { get; set; } = new List<string>();
        public List<int> AuthorsCount { get; set; } = new List<int>();
        public int LastOpenedTab;
        public FiltersForm(int lastOpenedTap)
        {
            InitializeComponent();
            InitListViews();
            InitListViewEvent();
            tabControlForStatistic.SelectTab(lastOpenedTap);
        }

        private void InitListViews()
        {
            foreach (TabPage tp in tabControlForStatistic.TabPages)
            {
                tp.Controls.OfType<ListView>().First().CheckBoxes = true;
                tp.Controls.OfType<ListView>().First().Columns.Add("Значения");
            }
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Filter.Source = lvSourceStat.CheckedItems.Cast<ListViewItem>().Select(item => item.SubItems[0].Text == "Неизвестный источник" ? "" : item.SubItems[0].Text).ToList();
            Filter.Conferences = lvConferenceStat.CheckedItems.Cast<ListViewItem>().Select(item => item.SubItems[0].Text == "Без названия" ? "" : item.SubItems[0].Text).ToList();
            Filter.Journals = lvJournalStat.CheckedItems.Cast<ListViewItem>().Select(item => item.SubItems[0].Text == "Без названия" ? "" : item.SubItems[0].Text).ToList();
            Filter.Types = lvTypeStat.CheckedItems.Cast<ListViewItem>().Select(item => item.SubItems[0].Text == "Неизвестный тип" ? "" : item.SubItems[0].Text).ToList();
            Filter.Years = lvYearStat.CheckedItems.Cast<ListViewItem>().Select(item => item.SubItems[0].Text == "Без года" ? "" : item.SubItems[0].Text).ToList();
            Filter.Geography = lvGeographyStat.CheckedItems.Cast<ListViewItem>().Select(item => item.SubItems[0].Text == "Без географии" ? "" : item.SubItems[0].Text).ToList();
            Filter.AuthorsCount = lvAuthorsCountStat.CheckedItems.Cast<ListViewItem>().Select(item => int.Parse(item.SubItems[0].Text)).ToList();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FiltersForm_Load(object sender, EventArgs e)
        {
            lvYearStat.Items.AddRange(Years.OrderBy(i => i).Select(item => new ListViewItem(item == "" ? "Без года" : item)).ToArray());
            lvConferenceStat.Items.AddRange(Conference.OrderBy(i => i).Select(item => new ListViewItem(item == "" ? "Без названия" : item)).ToArray());
            lvTypeStat.Items.AddRange(Types.OrderBy(i => i).Select(item => new ListViewItem(item == "" ? "Неизвестный тип" : item)).ToArray());
            lvSourceStat.Items.AddRange(Sources.OrderBy(i => i).Select(item => new ListViewItem(item == "" ? "Неизвестный источник" : item)).ToArray());
            lvGeographyStat.Items.AddRange(Geography.OrderBy(i => i).Select(item => new ListViewItem(item == "" ? "Без географии" : item)).ToArray());
            lvJournalStat.Items.AddRange(Journals.OrderBy(i => i).Select(item => new ListViewItem(item == "" ? "Без названия" : item)).ToArray());
            lvAuthorsCountStat.Items.AddRange(AuthorsCount.OrderBy(i => i).Select(item => new ListViewItem(item.ToString())).ToArray());

            foreach (TabPage tp in tabControlForStatistic.TabPages)
            {
                tp.Controls.OfType<ListView>().First().AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                tp.Controls.OfType<ListView>().First().Items.Cast<ListViewItem>().ToList().ForEach(
                    item =>
                    item.Checked = Contains(item.ListView.Name, item.SubItems[0].Text)
                );
            }
            
        }

        private void InitListViewEvent()
        {
            tabControlForStatistic.TabPages.Cast<TabPage>()
                .Select(tp => tp.Controls.OfType<ListView>().First())
                .ToList()
                .ForEach(
                    listView => 
                    listView.ColumnClick += new ColumnClickEventHandler(
                        (sender, e) => Sorting.SortingByColumn((ListView)sender, e.Column)
                    )
                );
        }

        private bool Contains(string name, string text)
        {
            switch(name)
            {
                case "lvConferenceStat":
                    return Filter.Conferences.Contains(text == "Без названия" ? "" : text);
                case "lvGeographyStat":
                    return Filter.Geography.Contains(text == "Без географии" ? "" : text);
                case "lvJournalStat":
                    return Filter.Journals.Contains(text == "Без названия" ? "" : text);
                case "lvSourceStat":
                    return Filter.Source.Contains(text == "Неизвестный источник" ? "" : text);
                case "lvTypeStat":
                    return Filter.Types.Contains(text == "Неизвестный тип" ? "" : text);
                case "lvYearStat":
                    return Filter.Years.Contains(text == "Без года" ? "" : text);
                case "lvAuthorsCountStat":
                    return Filter.AuthorsCount.Contains(int.Parse(text));
                default:
                    return false;
            }
        }

        private void btCheckAll_Click(object sender, EventArgs e)
        {
            var tp = tabControlForStatistic.SelectedTab;

            tp.Controls.OfType<ListView>().First().Items.Cast<ListViewItem>().ToList().ForEach(
                    item =>
                    item.Checked = true
                );
        }

        private void btUncheckAll_Click(object sender, EventArgs e)
        {
            var tp = tabControlForStatistic.SelectedTab;

            tp.Controls.OfType<ListView>().First().Items.Cast<ListViewItem>().ToList().ForEach(
                    item =>
                    item.Checked = false
                );
        }

        private void FiltersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LastOpenedTab = tabControlForStatistic.SelectedIndex;
        }
    }
}
