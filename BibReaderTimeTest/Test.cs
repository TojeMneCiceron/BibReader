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

        public void ClassificationTest()
        {

        }
        
        public void StatisticTablesTest()
        {

        }
        
        public void StatisticDiagramsTest()
        {

        }
    }
}
