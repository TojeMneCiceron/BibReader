using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BibReader.Readers.BibReaders;

namespace BibReader
{
    public partial class EditCountries : Form
    {
        public EditCountries(Dictionary<string, string> _countries)
        {
            InitializeComponent();

            foreach (string key in _countries.Keys)
            {
                ListViewItem lvi = new ListViewItem(new string[] { key, _countries[key] });
                lv.Items.Add(lvi);
            }

            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            btDelete.Enabled = false;
        }

        private string DeleteExtraSpaces(string str)
        {
            return Regex.Replace(DeleteBorderSpaces(str), "\\s+", " ");
        }

        private string DeleteBorderSpaces(string str)
        {
            return Regex.Replace(Regex.Replace(str, "^\\s+", ""), "\\s+$", "");
        }

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            btDelete.Enabled = lv.SelectedItems.Count > 0;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            lv.Items.RemoveAt(lv.SelectedIndices[0]);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            string otherName = DeleteExtraSpaces(tbOtherName.Text);
            string originalName = DeleteExtraSpaces(tbOriginalName.Text);

            if (otherName == "")
            {
                MessageBox.Show("Введите другой вариант названия страны", "Ошибка");
                return;
            }

            if (originalName == "")
            {
                MessageBox.Show("Введите оригинальное название страны", "Ошибка");
                return;
            }

            ListViewItem lvi = new ListViewItem(new string[] { otherName, originalName });
            lv.Items.Add(lvi);

            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            tbOriginalName.Text = "";
            tbOtherName.Text = "";
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> countries = new Dictionary<string, string>();

            StreamWriter sw = new StreamWriter("countries.txt");
            foreach (ListViewItem lvi in lv.Items)
            {
                if (!countries.ContainsKey(lvi.SubItems[0].Text))
                    countries.Add(lvi.SubItems[0].Text, lvi.SubItems[1].Text);
                sw.WriteLine($"{lvi.SubItems[0].Text}|{lvi.SubItems[1].Text}");
            }
            sw.Close();

            Countries.countries = countries;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
