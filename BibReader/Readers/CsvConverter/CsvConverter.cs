using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BibReader.Readers
{
    class CsvConverter
    {
        public CsvConverter() { }

        private bool isAuthor(char letter1, char letter2)
        {
            return letter1 >= 'a' && letter1 <= 'z' && letter2 >= 'A' && letter2 <= 'Z';
        }

        public string parseAuthors(string authors)
        {
            string strAuthors = "";
            int i = 0;
            while (authors != "" && i < authors.Length - 1)
            {
                if (isAuthor(authors[i], authors[i + 1]))
                {
                    strAuthors += authors.Substring(0, i) + " and ";
                    authors = authors.Substring(i + 1);
                    i = -1;
                }
                i++;
            }
            strAuthors += authors;
            return strAuthors;
        }

        string[] RemoveExtraEmptyElements(string[] str)
        {
            List<string> res = new List<string>();

            res.Add(str[0]);

            for (int i = 1; i < str.Length - 1; i++)
            {
                //if (str[i] == "" && (str[i - 1] == "" || str[i + 1] == ""))
                //        continue;

                //if (str[i] == "" && (str[i - 1] != "," && str[i + 1] != "," || res[res.Count - 1] == ""))
                //    continue;

                //if (str[i] == "" && (str[i + 1] != "" || (str[i - 1] != "," && str[i + 1] != ",") || res[res.Count - 1] == ""))
                //    continue;

                if (str[i] == "" && !(str[i + 1] == "" && res[res.Count - 1] != "" || str[i - 1] == "," && str[i + 1] == ","))
                    continue;

                if (str[i] == "" && str[i + 1] != "" && str[i + 1] != "," && str[i - 1] != "" && str[i - 1] != ",")
                    continue;

                if (str[i].Length > 1 && str[i][str[i].Length - 1] == ',' && str[i + 1] != ",")
                {
                    res.Add(str[i].Substring(0, str[i].Length - 1));
                    res.Add(",");
                }
                else
                    res.Add(str[i]);
            }

            return res.ToArray();
        }

        public void convertFile(string csvFile, string bibFile)
        {
            StreamReader csvfile = new StreamReader(csvFile);
            StreamWriter bibfile = new StreamWriter(bibFile, false, System.Text.Encoding.Default);

            string line = csvfile.ReadLine();
            while ((line = csvfile.ReadLine()) != null)
            {
                string[] str;
                str = line.Split('"');
                str = RemoveExtraEmptyElements(str);

                BibItem elem = new BibItem (
                    _itemType: str[19],
                    _author: parseAuthors(str[13]),
                    _doi: str[11],
                    _journal: str[3],
                    _title: str[1],
                    _year: str[15],
                    _number: str[9],
                    _url: str[17],
                    _source: "Springer Link", 
                    _document_type: str[19],
                    _volume: str[7],
                    _pages: "<<1-5>>"
                    );
                bibfile.WriteLine(elem.bibItem);
                bibfile.WriteLine();
            }
            csvfile.Close();
            bibfile.Close();
        }
    }

    class BibItem
    {
        public string bibItem { get; private set; }
        public BibItem()
        {
            bibItem = "";
        }

        public BibItem(
            string _itemType, string _author, string _doi, string _journal, 
            string _title, string _year, string _url = "", string _abstr = "", 
            string _affiliation = "", string _keywords = "", string _number = "", 
            string _pages = "", string _publisher = "", string _source = "",
            string _volume = "", string _document_type = "", string _note = "",
            string _abbrev_source_title = ""
            )
        {
            bibItem = '@' + _itemType + "{" + '\n'
                       + "author={" + _author + "}," + '\n'
                       + "title={" + _title + "}," + '\n'
                       + "journal={" + _journal + "}," + '\n'
                       + "year={" + _year + "}," + '\n'
                       + "volume={" + _volume + "}," + '\n'
                       + "number={" + _number + "}," + '\n'
                       + "pages={" + _pages + "}," + '\n'
                       + "doi={" + _doi + "}," + '\n'
                       + "note={" + _note + "}" + '\n'
                       + "url={" + _url + "}," + '\n'
                       + "affiliation={" + _affiliation + "}," + '\n'
                       + "keywords={" + _keywords + "}," + '\n'
                       + "publisher={" + _publisher + "}," + '\n'
                       + "abbrev_source_title={" + _abbrev_source_title + "}," + '\n'
                       + "document_type={" + _document_type + "}," + '\n'
                       + "source={" + _source + "}," + '\n'
                       + '}';
        }
    }
}
