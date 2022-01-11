using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BibReader.Publications;
using System.Windows.Forms;

namespace BibReader.Saver
{
    public class MyBibFormat
    {
        public static void Save(List<LibItem> libItems)
        {
            using (var saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "Файлы bib|*.bib";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFile.FileName;
                    using (var writer = new StreamWriter(filePath, false))
                    {
                        foreach (var item in libItems)
                        {
                            writer.WriteLine("@" + item.Type + "{");
                            writer.WriteLine("author={" + item.Authors + "},");
                            writer.WriteLine("abstract={" + item.Abstract + "},");
                            writer.WriteLine("affiliation={" + item.Affiliation + "},");
                            writer.WriteLine("doi={" + item.Doi + "},");
                            writer.WriteLine("journal={" + item.Journal + "},");
                            writer.WriteLine("keywords={" + item.Keywords + "},");
                            writer.WriteLine("number={" + item.Number + "},");
                            writer.WriteLine("pages={" + item.Pages + "},");
                            writer.WriteLine("publisher={" + item.Publisher + "},");
                            writer.WriteLine("source={" + item.Source + "},");
                            var title = item.OriginalTitle != string.Empty
                                ? "title={" + item.Title + " [" + item.OriginalTitle + "]},"
                                : "title={" + item.Title + "},";
                            writer.WriteLine(title);
                            writer.WriteLine("url={" + item.Url + "},");
                            writer.WriteLine("volume={" + item.Volume + "},");
                            writer.WriteLine("year={" + item.Year + "},");
                            writer.WriteLine("address={" + item.Address + "},");
                            writer.WriteLine("}");
                            writer.WriteLine();
                        }
                    }
                }
            }
            
        }
    }
}
