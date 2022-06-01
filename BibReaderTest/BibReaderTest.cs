using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibReader;
using BibReader.Publications;
using BibReader.Readers;
using BibReader.Readers.BibReaders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BibReaderTest
{
    [TestClass]
    class BibReaderTest
    {
        StreamReader[] r = { new StreamReader(@"C:\Users\ciceron\Desktop\21-11-2021\IEEE Document Title = teacher training+mooc (2).txt") };

        List<Source> defaultSources = new List<Source>();
        List<Source> customSources = new List<Source>();

        [TestMethod]
        public void ReadTest()
        {
            UniversalBibReader ubReader = new UniversalBibReader();

            List<LibItem> items = ubReader.Read(r, defaultSources, customSources);

            Assert.AreEqual(2, items.Count);
        }
        [TestMethod]
        public void UniqueTest()
        {

        }
        [TestMethod]
        public void RelevanceTest()
        {

        }
        [TestMethod]
        public void BibRefTest()
        {

        }
        [TestMethod]
        public void ClassificationTest()
        {

        }
        [TestMethod]
        public void StatisticTablesTest()
        {

        }
        [TestMethod]
        public void StatisticDiagramsTest()
        {

        }
    }
}
