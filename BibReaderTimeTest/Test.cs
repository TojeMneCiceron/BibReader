using BibReader.BibReference.TypesOfSourse;
using BibReader.Corpuses;
using BibReader.Publications;
using BibReader.Readers;
using BibReader.Readers.BibReaders;
using BibReader.Readers.ELibraryScraper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Sparc.TagCloud;
using BibReader.Finder;
using System.Drawing;
using WordCloud;
using BibReader.Statistic;
using System.Windows.Forms.DataVisualization.Charting;

namespace BibReaderTimeTest
{
    class Test
    {
        string file;

        XmlSerializer xs = new XmlSerializer(typeof(List<Source>));
        StreamReader[] r = new StreamReader[1];

        List<Source> defaultSources = new List<Source>();
        List<Source> customSources = new List<Source>();

        public List<LibItem> libItems = new List<LibItem>();

        RichTextBox rtbBib = new RichTextBox();

        private void InitSources()
        {
            using (FileStream fs = new FileStream(@"C:\Users\ciceron\Desktop\BibReader\BibReader\bin\Debug\defaultSources.xml", FileMode.Open))
            {
                defaultSources = (List<Source>)xs.Deserialize(fs);
            }

            using (FileStream fs = new FileStream(@"C:\Users\ciceron\Desktop\BibReader\BibReader\bin\Debug\sources.xml", FileMode.Open))
            {
                customSources = (List<Source>)xs.Deserialize(fs);
            }
        }

        public Test(string file)
        {
            InitSources();
            this.file = file;
        }

        
        public void ReadBibTexTest()
        {
            r[0] = new StreamReader(file);
            UniversalBibReader ubReader = new UniversalBibReader();

            libItems = ubReader.Read(r, defaultSources, customSources);
        }

        public void ReadCsvTest()
        {
            var cv = new CsvConverter();
            cv.convertFile(file, @"ConverterFileCsv.bib");
            var reader = new StreamReader(@"ConverterFileCsv.bib");
            r[0] = reader;

            ReadBibTexTest();
        }

        public void ReadHtmlTest()
        {
            var scraper = new Scraper();
            scraper.readFile(file, @"ConverterFileHtml.bib");
            var reader = new StreamReader(@"ConverterFileHtml.bib");
            r[0] = reader;

            ReadBibTexTest();
        }

        public void UniqueTest()
        {
            var unique = new Unique(libItems);
            var uniqueItems = unique.GetUnique();
        }
        
        public void RelevanceTest()
        {
            var relevance = new Relevance(libItems);
            var relevanceItems = relevance.GetRelevance();
        }
        
        public void BibRefIEEETest()
        {
            rtbBib.Text = string.Empty;
            foreach (LibItem item in libItems)
            {
                switch (item.Type)
                {
                    case "conference":
                        var conference = new Conference(item);
                        conference.MakeIEEE(rtbBib);
                        break;

                    case "book":
                        var book = new Book(item);
                        book.MakeIEEE(rtbBib);
                        break;

                    case "journal":
                        var journal = new Journal(item);
                        journal.MakeIEEE(rtbBib);
                        break;
                }
            }
        }

        public void BibRefAPATest()
        {
            rtbBib.Text = string.Empty;
            foreach (LibItem item in libItems)
            {
                switch (item.Type)
                {
                    case "conference":
                        var conference = new Conference(item);
                        conference.MakeAPA(rtbBib);
                        break;

                    case "book":
                        var book = new Book(item);
                        book.MakeAPA(rtbBib);
                        break;

                    case "journal":
                        var journal = new Journal(item);
                        journal.MakeAPA(rtbBib);
                        break;
                }
            }
        }

        public void BibRefGOSTTest()
        {
            rtbBib.Text = string.Empty;
            foreach (LibItem item in libItems)
            {
                switch (item.Type)
                {
                    case "conference":
                        var conference = new Conference(item);
                        conference.MakeGOST(rtbBib);
                        break;

                    case "book":
                        var book = new Book(item);
                        book.MakeGOST(rtbBib);
                        break;

                    case "journal":
                        var journal = new Journal(item);
                        journal.MakeGOST(rtbBib);
                        break;
                }
            }
        }

        public void BibRefHarvardTest()
        {
            rtbBib.Text = string.Empty;
            foreach (LibItem item in libItems)
            {
                switch (item.Type)
                {
                    case "conference":
                        var conference = new Conference(item);
                        conference.MakeHarvard(rtbBib);
                        break;

                    case "book":
                        var book = new Book(item);
                        book.MakeHarvard(rtbBib);
                        break;

                    case "journal":
                        var journal = new Journal(item);
                        journal.MakeHarvard(rtbBib);
                        break;
                }
            }
        }

        NumericUpDown nudWordsCount = new NumericUpDown();
        List<string> BlackList = new List<string>();
        TagCloudSetting TagCloudSetting = new TagCloudSetting();
        Finder finder = new Finder();

        string Info = "";

        private IEnumerable<TagCloudTag> GetCloudTags()
        {
            TagCloudSetting.MaxCloudSize = (int)nudWordsCount.Value + BlackList.Count;
            return
                new TagCloudAnalyzer(TagCloudSetting)
                .ComputeTagCloud(
                    Info.Split(new string[] { "\r\n" }, StringSplitOptions.None)
                );
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
            //lvFreqs.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
            //lvFreqs.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        CheckBox checkBoxImageIsBlack = new CheckBox();
        PictureBox pictBox = new PictureBox();
        CheckBox checkBoxFreq = new CheckBox();
        ListView lvFreqs = new ListView();

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

        public void ClassificationTitleTest()
        {
            Info = string.Join("\r\n",
                libItems
                .Where(item => item.Title != string.Empty)
                .Select(item => item.Title)
                );

            nudWordsCount.Value = 10;
            LoadWordAndFreqs(GetCloudTags());
            Draw();
        }

        public void ClassificationAbstractTest()
        {
            Info = string.Join("\r\n",
                libItems
                .Where(item => item.Abstract != string.Empty)
                .Select(item => item.Abstract)
                );

            nudWordsCount.Value = 10;
            LoadWordAndFreqs(GetCloudTags());
            Draw();
        }

        ListView lvSourceStatistic = new ListView();
        ListView lvYearStatistic = new ListView();
        ListView lvTypeOfDoc = new ListView();
        ListView lvJournalStat = new ListView();
        ListView lvGeography = new ListView();
        ListView lvConferenceStat = new ListView();
        ListView lvAuthorsCountStatistic = new ListView();

        public void StatisticTablesTest()
        {
            Stat.Corpus corpus = Stat.Corpus.First;
            Stat.CalculateStatistic(libItems, corpus);

            FormStatistic.LoadSourseStatistic(lvSourceStatistic);
            FormStatistic.LoadYearStatistic(lvYearStatistic);
            FormStatistic.LoadTypeStatistic(lvTypeOfDoc);
            FormStatistic.LoadJournalStatistic(lvJournalStat);
            FormStatistic.LoadGeographyStatistic(lvGeography);
            FormStatistic.LoadConferenceStatistic(lvConferenceStat);
            FormStatistic.LoadAuthorsCountStatistic(lvAuthorsCountStatistic);
        }

        private int[] orderByKeyValue(Dictionary<string, int> statistic)
        {
            return statistic.OrderBy(i => i.Key).Select(item => item.Value).ToArray();
        }

        private string[] orderByKeyKey(Dictionary<string, int> statistic)
        {
            return statistic.OrderBy(i => i.Key).Select(item => item.Key).ToArray();
        }
        private int[] orderByKeyValue(Dictionary<int, int> statistic)
        {
            return statistic.OrderBy(i => i.Key).Select(item => item.Value).ToArray();
        }
        private string[] orderByKeyKey(Dictionary<int, int> statistic)
        {
            return statistic.OrderBy(i => i.Key).Select(item => item.Key.ToString()).ToArray();
        }

        private void OpenDiagram(Chart chart, string[] xValues, int[] yValues, ListView lv)
        {
            chart.Series.Clear();

            chart.BackColor = Color.White;

            chart.BorderlineDashStyle = ChartDashStyle.Solid;
            chart.BorderlineColor = Color.White;

            chart.Series.Add(new Series("ColumnSeries")
            {
                ChartType = SeriesChartType.Pyramid
            });

            chart.Series["ColumnSeries"].Points.DataBindXY(xValues, yValues);
            chart.Series["ColumnSeries"].IsValueShownAsLabel = true;
            chart.ChartAreas.Add(new ChartArea());
            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
        }

        public void StatisticDiagramsYearTest()
        {
            int[] yValues = orderByKeyValue(Stat.Years);
            string[] xValues = orderByKeyKey(Stat.Years);

            Chart chart = new Chart();
            ListView lvStatistic = lvYearStatistic;
            if (chart != null && lvStatistic != null)
            {
                OpenDiagram(chart, xValues, yValues, lvStatistic);
            }
        }

        public void StatisticDiagramsSourceTest()
        {
            int[] yValues = orderByKeyValue(Stat.Sources);
            string[] xValues = orderByKeyKey(Stat.Sources);

            Chart chart = new Chart();
            ListView lvStatistic = lvSourceStatistic;
            if (chart != null && lvStatistic != null)
            {
                OpenDiagram(chart, xValues, yValues, lvStatistic);
            }
        }

        public void StatisticDiagramsTypeTest()
        {
            int[] yValues = orderByKeyValue(Stat.Types);
            string[] xValues = orderByKeyKey(Stat.Types);

            Chart chart = new Chart();
            ListView lvStatistic = lvTypeOfDoc;
            if (chart != null && lvStatistic != null)
            {
                OpenDiagram(chart, xValues, yValues, lvStatistic);
            }
        }

        public void StatisticDiagramsJournalTest()
        {
            int[] yValues = orderByKeyValue(Stat.Journal);
            string[] xValues = orderByKeyKey(Stat.Journal);

            Chart chart = new Chart();
            ListView lvStatistic = lvJournalStat;
            if (chart != null && lvStatistic != null)
            {
                OpenDiagram(chart, xValues, yValues, lvStatistic);
            }
        }

        public void StatisticDiagramsGeographyTest()
        {
            int[] yValues = orderByKeyValue(Stat.Geography);
            string[] xValues = orderByKeyKey(Stat.Geography);

            Chart chart = new Chart();
            ListView lvStatistic = lvGeography;
            if (chart != null && lvStatistic != null)
            {
                OpenDiagram(chart, xValues, yValues, lvStatistic);
            }
        }

        public void StatisticDiagramsConfTest()
        {
            int[] yValues = orderByKeyValue(Stat.Conference);
            string[] xValues = orderByKeyKey(Stat.Conference);

            Chart chart = new Chart();
            ListView lvStatistic = lvConferenceStat;
            if (chart != null && lvStatistic != null)
            {
                OpenDiagram(chart, xValues, yValues, lvStatistic);
            }
        }

        public void StatisticDiagramsAuthorsTest()
        {
            int[] yValues = orderByKeyValue(Stat.AuthorsCount);
            string[] xValues = orderByKeyKey(Stat.AuthorsCount);

            Chart chart = new Chart();
            ListView lvStatistic = lvAuthorsCountStatistic;
            if (chart != null && lvStatistic != null)
            {
                OpenDiagram(chart, xValues, yValues, lvStatistic);
            }
        }
    }
}
