using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReaderTimeTest
{
    enum type
    { bib, csv, html};
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter(@"C:\Users\ciceron\Desktop\BibReader\BibReaderTimeTest\output.txt");
            int testCount = 5;
            string[] files = {
                @"C:\Users\ciceron\Desktop\21-11-2021\IEEE Document Title = teacher training+mooc (2).txt",
                @"C:\Users\ciceron\Desktop\21-11-2021\111.bib",
            };

            writer.WriteLine($"file\t" +
                $"count\t" +
                $"read\t" +
                $"unique\t" +
                $"relev\t" +
                $"bibref\t" +
                $"class\t" +
                $"stattables\t" +
                $"statdiagrams\t");

            foreach (string file in files)
            {
                type t = file.Contains(".csv") ? type.csv : file.Contains(".htm") ? type.html : type.bib;

                double readTime = 0;
                double uniqueTime = 0;
                double relevanceTime = 0;
                double bibRefTime = 0;
                double classTime = 0;
                double statTablesTime = 0;
                double statDiagramsTime = 0;

                Test test = new Test(file);

                for (int i = 0; i < testCount; i++)
                {
                    Stopwatch sw = new Stopwatch();

                    switch (t)
                    {
                        case type.bib:
                            sw.Start();
                            test.ReadBibTexTest();
                            sw.Stop();
                            readTime += (double)sw.ElapsedMilliseconds / 1000;
                            break;
                        case type.csv:
                            sw.Start();
                            test.ReadCsvTest();
                            sw.Stop();
                            readTime += (double)sw.ElapsedMilliseconds / 1000;
                            break;
                        case type.html:
                            sw.Start();
                            test.ReadHtmlTest();
                            sw.Stop();
                            readTime += (double)sw.ElapsedMilliseconds / 1000;
                            break;
                    }

                    sw.Restart();
                    test.UniqueTest();
                    sw.Stop();
                    uniqueTime += (double)sw.ElapsedMilliseconds / 1000;

                    sw.Restart();
                    test.RelevanceTest();
                    sw.Stop();
                    relevanceTime += (double)sw.ElapsedMilliseconds / 1000;

                    sw.Restart();
                    test.BibRefIEEETest();
                    sw.Stop();
                    bibRefTime += (double)sw.ElapsedMilliseconds / 1000;

                    sw.Restart();
                    test.ClassificationTest();
                    sw.Stop();
                    classTime += (double)sw.ElapsedMilliseconds / 1000;

                    sw.Restart();
                    test.StatisticTablesTest();
                    sw.Stop();
                    statTablesTime += (double)sw.ElapsedMilliseconds / 1000;

                    sw.Restart();
                    test.StatisticDiagramsTest();
                    sw.Stop();
                    statDiagramsTime += (double)sw.ElapsedMilliseconds / 1000;
                }

                readTime /= testCount;
                uniqueTime /= testCount;
                relevanceTime /= testCount;
                bibRefTime /= testCount;
                classTime /= testCount;
                statTablesTime /= testCount;
                statDiagramsTime /= testCount;

                writer.WriteLine($"{file}\t" +
                    $"{test.libItems.Count}\t" +
                    $"{string.Format("{0:0.000}", readTime)}\t" +
                    $"{string.Format("{0:0.000}", uniqueTime)}\t" +
                    $"{string.Format("{0:0.000}", relevanceTime)}\t" +
                    $"{string.Format("{0:0.000}", bibRefTime)}\t" +
                    $"{string.Format("{0:0.000}", classTime)}\t" +
                    $"{string.Format("{0:0.000}", statTablesTime)}\t" +
                    $"{string.Format("{0:0.000}", statDiagramsTime)}");
            }
            writer.Close();
        }
    }
}
