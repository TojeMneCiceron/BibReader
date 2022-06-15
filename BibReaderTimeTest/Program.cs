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
            int testCount = int.Parse(args[0]);
            Console.WriteLine($"{args[0]} iterations");
            string[] files = {
                //@"IEEE 100.txt",
                //@"IEEE 200.txt",
                //@"IEEE 300.txt",
                //@"IEEE 400.txt",
                //@"IEEE 500.txt",
                //@"IEEE 600.txt",
                //@"IEEE 700.txt",
                //@"IEEE 800.txt",
                @"IEEE 900.txt",
                @"IEEE 1000.txt",
            };

            Console.WriteLine($"file\t" +
                $"count\t" +
                //$"read\t" +
                //$"unique\t" +
                //$"relev\t" +
                $"bibrefI\t" +
                $"bibrefG\t" +
                $"bibrefA\t" +
                $"bibrefH\t"
                //$"classT\t" +
                //$"classA\t" +
                //$"stattables\t" +
                //$"statdiagramsY\t" +
                //$"statdiagramsS\t" +
                //$"statdiagramsT\t" +
                //$"statdiagramsJ\t" +
                //$"statdiagramsC\t" +
                //$"statdiagramsG\t" +
                //$"statdiagramsA\t"
                );
            writer.WriteLine($"file\t" +
                $"count\t" +
                //$"read\t" +
                //$"unique\t" +
                //$"relev\t" +
                $"bibrefI\t" +
                $"bibrefG\t" +
                $"bibrefA\t" +
                $"bibrefH\t"
                //$"classT\t" +
                //$"classA\t" +
                //$"stattables\t" +
                //$"statdiagramsY\t" +
                //$"statdiagramsS\t" +
                //$"statdiagramsT\t" +
                //$"statdiagramsJ\t" +
                //$"statdiagramsC\t" +
                //$"statdiagramsG\t" +
                //$"statdiagramsA\t"
                );

            foreach (string file in files)
            {
                type t = file.Contains(".csv") ? type.csv : file.Contains(".htm") ? type.html : type.bib;

                double readTime = 0;
                double uniqueTime = 0;
                double relevanceTime = 0;
                double bibRefTimeH = 0;
                double bibRefTimeI = 0;
                double bibRefTimeG = 0;
                double bibRefTimeA = 0;
                double classTimeT = 0;
                double classTimeA = 0;
                double statTablesTime = 0;
                double statDiagramsTimeY = 0;
                double statDiagramsTimeS = 0;
                double statDiagramsTimeT = 0;
                double statDiagramsTimeJ = 0;
                double statDiagramsTimeC = 0;
                double statDiagramsTimeG = 0;
                double statDiagramsTimeA = 0;

                int itemsCount = 0;

                for (int i = 0; i < testCount; i++)
                {
                    Console.WriteLine($"i = {i + 1}");
                    Test test = new Test(file);
                    Stopwatch sw = new Stopwatch();

                    switch (t)
                    {
                        case type.bib:
                            //sw.Start();
                            test.ReadBibTexTest();
                            //sw.Stop();
                            //readTime += (double)sw.ElapsedMilliseconds / 1000;
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

                    //Console.WriteLine("reading done");
                    itemsCount = test.libItems.Count;
                    //sw.Restart();
                    //test.UniqueTest();
                    //sw.Stop();
                    //uniqueTime += (double)sw.ElapsedMilliseconds / 1000;
                    //Console.WriteLine("unique done");
                    //sw.Restart();
                    //test.RelevanceTest();
                    //sw.Stop();
                    //relevanceTime += (double)sw.ElapsedMilliseconds / 1000;
                    //Console.WriteLine("relevance done");
                    sw.Restart();
                    test.BibRefIEEETest();
                    sw.Stop();
                    bibRefTimeI += (double)sw.ElapsedMilliseconds / 1000;
                    Console.WriteLine((double)sw.ElapsedMilliseconds / 1000);
                    sw.Restart();
                    test.BibRefGOSTTest();
                    sw.Stop();
                    bibRefTimeG += (double)sw.ElapsedMilliseconds / 1000;
                    Console.WriteLine((double)sw.ElapsedMilliseconds / 1000);
                    sw.Restart();
                    test.BibRefAPATest();
                    sw.Stop();
                    bibRefTimeA += (double)sw.ElapsedMilliseconds / 1000;
                    Console.WriteLine((double)sw.ElapsedMilliseconds / 1000);
                    sw.Restart();
                    test.BibRefHarvardTest();
                    sw.Stop();
                    bibRefTimeH += (double)sw.ElapsedMilliseconds / 1000;
                    Console.WriteLine((double)sw.ElapsedMilliseconds / 1000);

                    //Console.WriteLine("bibref done");

                    //sw.Restart();
                    //test.ClassificationTitleTest();
                    //sw.Stop();
                    //classTimeT += (double)sw.ElapsedMilliseconds / 1000;

                    //sw.Restart();
                    //test.ClassificationAbstractTest();
                    //sw.Stop();
                    //classTimeA += (double)sw.ElapsedMilliseconds / 1000;
                    //Console.WriteLine("class done");
                    //sw.Restart();
                    //test.StatisticTablesTest();
                    //sw.Stop();
                    //statTablesTime += (double)sw.ElapsedMilliseconds / 1000;
                    //Console.WriteLine("stat tables done");
                    //sw.Restart();
                    //test.StatisticDiagramsYearTest();
                    //sw.Stop();
                    //statDiagramsTimeY += (double)sw.ElapsedMilliseconds / 1000;

                    //sw.Restart();
                    //test.StatisticDiagramsSourceTest();
                    //sw.Stop();
                    //statDiagramsTimeS += (double)sw.ElapsedMilliseconds / 1000;

                    //sw.Restart();
                    //test.StatisticDiagramsTypeTest();
                    //sw.Stop();
                    //statDiagramsTimeT += (double)sw.ElapsedMilliseconds / 1000;

                    //sw.Restart();
                    //test.StatisticDiagramsJournalTest();
                    //sw.Stop();
                    //statDiagramsTimeJ += (double)sw.ElapsedMilliseconds / 1000;

                    //sw.Restart();
                    //test.StatisticDiagramsConfTest();
                    //sw.Stop();
                    //statDiagramsTimeC += (double)sw.ElapsedMilliseconds / 1000;

                    //sw.Restart();
                    //test.StatisticDiagramsGeographyTest();
                    //sw.Stop();
                    //statDiagramsTimeG += (double)sw.ElapsedMilliseconds / 1000;

                    //sw.Restart();
                    //test.StatisticDiagramsAuthorsTest();
                    //sw.Stop();
                    //statDiagramsTimeA += (double)sw.ElapsedMilliseconds / 1000;
                    //Console.WriteLine("stat diagrams done");
                }

                //readTime /= testCount;
                //uniqueTime /= testCount;
                //relevanceTime /= testCount;
                bibRefTimeI /= testCount;
                bibRefTimeG /= testCount;
                bibRefTimeA /= testCount;
                bibRefTimeH /= testCount;
                //classTimeT /= testCount;
                //classTimeA /= testCount;
                //statTablesTime /= testCount;
                //statDiagramsTimeY /= testCount;
                //statDiagramsTimeS /= testCount;
                //statDiagramsTimeT /= testCount;
                //statDiagramsTimeJ /= testCount;
                //statDiagramsTimeC /= testCount;
                //statDiagramsTimeG /= testCount;
                //statDiagramsTimeA /= testCount;

                Console.WriteLine($"{file}\t" +
                    $"{itemsCount}\t" +
                    //$"{string.Format("{0:0.000}", readTime)}\t" +
                    //$"{string.Format("{0:0.000}", uniqueTime)}\t" +
                    //$"{string.Format("{0:0.000}", relevanceTime)}\t" +
                    $"{string.Format("{0:0.000}", bibRefTimeI)}\t" +
                    $"{string.Format("{0:0.000}", bibRefTimeG)}\t" +
                    $"{string.Format("{0:0.000}", bibRefTimeA)}\t" +
                    $"{string.Format("{0:0.000}", bibRefTimeH)}\t"
                    //$"{string.Format("{0:0.000}", classTimeT)}\t" +
                    //$"{string.Format("{0:0.000}", classTimeA)}\t" +
                    //$"{string.Format("{0:0.000}", statTablesTime)}\t" +
                    //$"{string.Format("{0:0.000}", statDiagramsTimeY)}\t" +
                    //$"{string.Format("{0:0.000}", statDiagramsTimeS)}\t" +
                    //$"{string.Format("{0:0.000}", statDiagramsTimeT)}\t" +
                    //$"{string.Format("{0:0.000}", statDiagramsTimeJ)}\t" +
                    //$"{string.Format("{0:0.000}", statDiagramsTimeC)}\t" +
                    //$"{string.Format("{0:0.000}", statDiagramsTimeG)}\t" +
                    //$"{string.Format("{0:0.000}", statDiagramsTimeA)}"
                    );
                writer.WriteLine($"{file}\t" +
                    $"{itemsCount}\t" +
                    //$"{string.Format("{0:0.000}", readTime)}\t" +
                    //$"{string.Format("{0:0.000}", uniqueTime)}\t" +
                    //$"{string.Format("{0:0.000}", relevanceTime)}\t" +
                    $"{string.Format("{0:0.000}", bibRefTimeI)}\t" +
                    $"{string.Format("{0:0.000}", bibRefTimeG)}\t" +
                    $"{string.Format("{0:0.000}", bibRefTimeA)}\t" +
                    $"{string.Format("{0:0.000}", bibRefTimeH)}\t"
                    //$"{string.Format("{0:0.000}", classTimeT)}\t" +
                    //$"{string.Format("{0:0.000}", classTimeA)}\t" +
                    //$"{string.Format("{0:0.000}", statTablesTime)}\t" +
                    //$"{string.Format("{0:0.000}", statDiagramsTimeY)}\t" +
                    //$"{string.Format("{0:0.000}", statDiagramsTimeS)}\t" +
                    //$"{string.Format("{0:0.000}", statDiagramsTimeT)}\t" +
                    //$"{string.Format("{0:0.000}", statDiagramsTimeJ)}\t" +
                    //$"{string.Format("{0:0.000}", statDiagramsTimeC)}\t" +
                    //$"{string.Format("{0:0.000}", statDiagramsTimeG)}\t" +
                    //$"{string.Format("{0:0.000}", statDiagramsTimeA)}"
                    );

            }
            writer.Close();
        }
    }
}
