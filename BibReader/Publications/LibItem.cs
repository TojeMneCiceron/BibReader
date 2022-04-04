using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace BibReader.Publications
{
    public class LibItem
    {
        public string Authors { get; set; }
        public string Doi {get; set; }
        public string Year {get; set; }
        public string Title { get; set; }
        public string Journal {get; set; }
        public string Volume {get; set; }
        public string Pages {get; set; }
        public string Url {get; set; }
        public string Affiliation {get; set; }
        public string Abstract {get; set; }
        public string Keywords {get; set; }
        public string Publisher {get; set; }
        public string Source {get; set; }
        public string Number {get; set; }
        public string OriginalTitle { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string ArticleNumber { get; set; }
        public int Priority { get => Type == "conference" ? 0: 1; }
        public List<string> Geography { get; set; } = new List<string>();
        public int Id { get; set; }

        public LibItem(LibItem item)
        {
            Authors = item.Authors;
            Doi = item.Doi;
            Year = item.Year;
            Title = item.Title;
            Journal = item.Journal;
            Volume = item.Volume;
            Pages = item.Pages;
            Url = item.Url;
            Affiliation = item.Affiliation;
            Abstract = item.Abstract;
            Keywords = item.Keywords;
            Publisher = item.Publisher;
            Source = item.Source;
            Number = item.Number;
            OriginalTitle = item.OriginalTitle;
            Type = item.Type;
            Address = item.Address;
            ArticleNumber = item.ArticleNumber;
            FormGeography();
        }
        public LibItem(string authors, string doi, string year, string booktitle, string title, string journalName, 
            string volume, string pages, string url, string affiliation, string @abstract, string keywords, string publisher, 
            string source, string number, string originalTitle, string type, string address, string articleNumber)
        {
            Authors = authors;
            Doi = doi;
            Year = year;
            Title = title;
            Journal = journalName;
            Volume = volume;
            Pages = pages;
            Url = url;
            Affiliation = affiliation;
            Abstract = @abstract;
            Keywords = keywords;
            Publisher = publisher;
            Source = source;
            Number = number;
            OriginalTitle = originalTitle;
            Type = type;
            Address = address;
            ArticleNumber = articleNumber;
            FormGeography();
        }

        public LibItem(Dictionary<string, string> dict)
        {
            Authors = dict["authors"];
            Doi = dict["doi"];
            Year = dict["year"];
            Title = dict["title"];
            Journal = dict["journal"];
            Volume = dict["volume"];
            Pages = dict["pages"];
            Url = dict["url"];
            Affiliation = dict["affiliation"];
            Abstract = dict["abstract"];
            Keywords = dict["keywords"];
            Publisher = dict["publisher"];
            Source = dict["source"];
            Number = dict["number"];
            OriginalTitle = dict["originalTitle"];
            Type = dict["type"];
            Address = dict["address"];
            ArticleNumber = dict["articleNumber"];
            FormGeography();
        }

        public bool AbstractIsEmpty => Abstract == string.Empty ? true : false;
        public bool KeywordsIsEmpty => Keywords == string.Empty ? true : false;
        public bool AffiliationIsEmpty => Affiliation == string.Empty ? true : false;

        public PropertyInfo GetPropertyByButton(string name)
        {
            return GetType().GetProperty(name.Substring(2));
        }

        public string GetPropertyValue(string name)
        {
            return (string)GetType().GetProperty(name).GetValue(this);
        }

        public int EmptyTagsCount()
        {
            int count = 0;
            foreach (string key in Tags.VisibleTags)
            {
                if (GetPropertyValue(key) == "")
                    count++;
            }

            return count;
        }

        public int PagesCount()
        {
            if (Pages.Contains("<<"))
                return 0;
            
            string[] s = Pages.Replace(" ", "").Split('-');

            if (s.Length == 1)
                return 1;

            if (s.Length > 1)
                return int.Parse(s[1]) - int.Parse(s[0]) + 1;

            return 0;
        }

        public void CopyTags(LibItem item)
        {
            Authors = item.Authors;
            Doi = item.Doi;
            Year = item.Year;
            Title = item.Title;
            Journal = item.Journal;
            Volume = item.Volume;
            Pages = item.Pages;
            Url = item.Url;
            Affiliation = item.Affiliation;
            Abstract = item.Abstract;
            Keywords = item.Keywords;
            Publisher = item.Publisher;
            Source = item.Source;
            Number = item.Number;
            OriginalTitle = item.OriginalTitle;
            Type = item.Type;
            Address = item.Address;
            ArticleNumber = item.ArticleNumber;
            Geography = new List<string>(item.Geography);
        }

        public int AuthorsCount()
        {
            if (Authors == "")
                return 0;

            return new Regex(" and ").Matches(Authors).Count + 1;
        }

        private void FormGeography()
        {
            if (Affiliation != string.Empty)
            {
                List<string> affs = new List<string>();
                if (Source == "Web of Science")
                {
                    affs = Affiliation
                        .Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                        .Where(text => text[text.Length - 2] != ' ')
                        .ToList();
                }
                else
                    affs = Affiliation.Split(';').ToList();

                Dictionary<string, int> curAffs = new Dictionary<string, int>();

                foreach (var aff in affs)
                {
                    var infoArray = aff.Split(',');

                    infoArray[infoArray.Length - 1] = infoArray.Last().Trim();

                    if (infoArray.Last().Contains("USA") || infoArray.Last() == "United States")
                        infoArray[infoArray.Length - 1] = "USA";

                    if (infoArray.Last() == "Russian Federation")
                        infoArray[infoArray.Length - 1] = "Russia";

                    if (infoArray.Last().Contains("China"))
                        infoArray[infoArray.Length - 1] = "China";

                    infoArray[infoArray.Length - 1] = infoArray[infoArray.Length - 1].Replace(".", "");

                    if (!curAffs.ContainsKey(infoArray.Last()))
                        curAffs.Add(infoArray.Last(), 1);
                }

                foreach (var key in curAffs.Keys)
                {
                    Geography.Add(key);
                }
            }
        }

        public string BibTexForSave()
        {
            //string res;

            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            writer.WriteLine("@" + Type + "{");
            writer.WriteLine("author={" + Authors + "},");
            writer.WriteLine("abstract={" + Abstract + "},");
            writer.WriteLine("affiliation={" + Affiliation + "},");
            writer.WriteLine("doi={" + Doi + "},");
            writer.WriteLine("journal={" + Journal + "},");
            writer.WriteLine("keywords={" + Keywords + "},");
            writer.WriteLine("number={" + Number + "},");
            writer.WriteLine("pages={" + Pages + "},");
            writer.WriteLine("publisher={" + Publisher + "},");
            writer.WriteLine("source={" + Source + "},");
            var title = OriginalTitle != string.Empty
                ? "title={" + Title + " [" + OriginalTitle + "]},"
                : "title={" + Title + "},";
            writer.WriteLine(title);
            writer.WriteLine("url={" + Url + "},");
            writer.WriteLine("volume={" + Volume + "},");
            writer.WriteLine("articleNumber={" + ArticleNumber + "},");
            writer.WriteLine("year={" + Year + "},");
            writer.WriteLine("address={" + Address + "},");
            writer.WriteLine("}");

            return sb.ToString();
        }
        public string BibTexForRef()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            writer.WriteLine("@article{" + Id + ",");
            if (Journal != "")
                writer.WriteLine("journal={" + Journal + "},");
            if (Number != "")
                writer.WriteLine("number=" + Number + ",");
            //writer.WriteLine("publisher={" + Publisher + "},");
            if (Title != "")
                writer.WriteLine("title={{" + Title + "}},");
            if (Volume != "")
                writer.WriteLine("volume=" + Volume + ",");
            if (Authors != "")
                writer.WriteLine("author={" + Authors + "},");
            //writer.WriteLine("articleNumber={" + ArticleNumber + "},");
            if (Pages != "")
                writer.WriteLine("pages={" + Pages.Replace("<", "").Replace(">", "").Replace(" ", "") + "},");
            if (Year != "")
                writer.WriteLine("year=" + Year + ",");
            writer.WriteLine("}");

            return sb.ToString();
        }
    }
}
