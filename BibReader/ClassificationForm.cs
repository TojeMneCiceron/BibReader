using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BibReader.Saver;
using Sparc.TagCloud;
using BibReader.Finder;
using Collection = BibReader.Finder.Collection.Collection;

namespace BibReader
{
    public partial class ClassificationForm : Form
    {
        List<string> BlackList = new List<string>();
        TagCloudSetting TagCloudSetting = new TagCloudSetting();
        Finder.Finder finder = new Finder.Finder();

        public string Info
        {
            get => tbInfo.Text;
            set => tbInfo.Text = value;
        }

        public ClassificationForm()
        {
            InitializeComponent();
        }

        private IEnumerable<TagCloudTag> GetCloudTags()
        {
            TagCloudSetting.MaxCloudSize = (int)nudWordsCount.Value + BlackList.Count;
            return
                new TagCloudAnalyzer(TagCloudSetting)
                .ComputeTagCloud(
                    Info.Split(new string[] { "\r\n" }, StringSplitOptions.None)
                );
        }

        private void ClusterizationForm_Load(object sender, EventArgs e)
        {
            nudWordsCount.Value = 10;
            LoadWordAndFreqs(GetCloudTags());
            Draw();
        }


        private void LoadWordAndFreqs(IEnumerable<TagCloudTag> cloudTags)
        {
            lvFreqs.Items.Clear();
            foreach (var tag in cloudTags)
            {
                if (!BlackList.Contains(tag.Text))
                    lvFreqs.Items.Add(
                        new ListViewItem(
                            new string[] {
                                tag.Text,
                                tag.Count.ToString()
                            }
                        )
                    );
            }
            lvFreqs.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            lvFreqs.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btDeleteItems_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lvFreqs.SelectedItems)
            {
                BlackList.Add(item.SubItems[0].Text);
                lvFreqs.Items.Remove(item);
            }
            LoadWordAndFreqs(GetCloudTags());
        }

        private void tbRedraw_Click(object sender, EventArgs e) => Draw();

        private void Draw()
        {
            var wordCloud = 
                checkBoxImageIsBlack.Checked
                ? new WordCloud.WordCloud(pictBox.Width, pictBox.Height, false, Color.Black)
                : new WordCloud.WordCloud(pictBox.Width, pictBox.Height);

            pictBox.Image = 
                checkBoxFreq.Checked
                ? wordCloud.Draw(
                    lvFreqs.Items.Cast<ListViewItem>().Select(item => item.SubItems[0].Text + "(" + item.SubItems[1].Text + ")").ToList(),
                    lvFreqs.Items.Cast<ListViewItem>().Select(item => Convert.ToInt32(item.SubItems[1].Text)).ToList()
                )
                : wordCloud.Draw(
                    lvFreqs.Items.Cast<ListViewItem>().Select(item => item.SubItems[0].Text).ToList(),
                    lvFreqs.Items.Cast<ListViewItem>().Select(item => Convert.ToInt32(item.SubItems[1].Text)).ToList()
                );
        }

        private void btSaveImage_Click(object sender, EventArgs e) => ImageSaver.Save(pictBox.Image);

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) => LoadWordAndFreqs(GetCloudTags());

        private void btPrevFindedLibItem_Click(object sender, EventArgs e)
        {
            var currIndex = finder.GetIndex(
                Collection.MakeListOfIndexes(tbFind.Text, lvFreqs, 0),
                Functions.Prev
            );
            Collection.SelectItem(lvFreqs, currIndex);
        }

        private void btNextFindedLibItem_Click(object sender, EventArgs e)
        {
            var currIndex = finder.GetIndex(
                Collection.MakeListOfIndexes(tbFind.Text, lvFreqs, 0),
                Functions.Next
            );
            Collection.SelectItem(lvFreqs, currIndex);
        }

        private void tbSaveFreqsInExcel_Click(object sender, EventArgs e) => ExcelSaver.Save(new List<ListView>() { lvFreqs });

        private void tbTest_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
