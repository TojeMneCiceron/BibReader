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
        public List<Author> AuthorsList { get; set; } = new List<Author>();
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
        public string BibTexString { get; set; }
        public string BibTexId { get; set; }
        public string BibTexFirstTag { get; set; }
        public bool UnknownSource { get; set; } = false;
        public string JournalAbbreviation { get; set; }

        public void SetBibTexString(string bibTexString)
        {
            BibTexString = bibTexString;

            string firstLine = bibTexString.Split('\n').First();
            string res = firstLine.Substring(firstLine.IndexOf('{') + 1);
            if (res.Length > 1)
                BibTexId = res.Substring(0, res.LastIndexOf(','));
            else
                BibTexId = "";
        }

        public void SetJournal(string j)
        {
            Journal = j;
            JournalAbbreviation = MakeAbbreviations(j);
        }

        public LibItem(LibItem item)
        {
            Authors = item.Authors;
            AuthorsList = item.AuthorsList;
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
            JournalAbbreviation = item.JournalAbbreviation;
        }
        public LibItem(string authors, string doi, string year, string booktitle, string title, string journalName, 
            string volume, string pages, string url, string affiliation, string @abstract, string keywords, string publisher, 
            string source, string number, string originalTitle, string type, string address, string articleNumber, string journalAbb)
        {
            Authors = authors;
            FormAuthorsList();
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
            JournalAbbreviation = journalAbb;
        }

        public LibItem(Dictionary<string, string> dict)
        {
            Authors = dict["authors"];
            FormAuthorsList();
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
            JournalAbbreviation = MakeAbbreviations(dict["journal"]);
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
            {
                Regex r = new Regex(@"\d+");
                int count = int.Parse(r.Match(s[1]).Value) - int.Parse(r.Match(s[0]).Value) + 1;
                return count;
            }
            return 0;
        }

        public void CopyTags(LibItem item)
        {
            Authors = item.Authors;
            AuthorsList = item.AuthorsList;
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
            JournalAbbreviation = item.JournalAbbreviation;
        }

        public int AuthorsCount()
        {
            if (Authors == "")
                return 0;

            return AuthorsList.Count;
            //return new Regex(" and ").Matches(Authors).Count + 1;
        }

        public void FormAuthorsList()
        {
            AuthorsList.Clear();
            
            var authors = Authors.Split(new string[] { " and " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string author in authors)
                AuthorsList.Add(new Author(author));
        }

        public void FormGeography()
        {
            Geography.Clear();
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

                List<string> curAffs = new List<string>();

                foreach (var aff in affs)
                {
                    var infoArray = aff.Split(',');

                    infoArray[infoArray.Length - 1] = infoArray.Last().Trim();

                    if (infoArray.Last().Contains("USA") || infoArray.Last().Contains("United States"))
                        infoArray[infoArray.Length - 1] = "USA";

                    if (infoArray.Last() == "Russian Federation")
                        infoArray[infoArray.Length - 1] = "Russia";

                    if (infoArray.Last().Contains("China")
                        || infoArray.Last() == "Hong Kong"
                        || infoArray.Last() == "Macau")
                        infoArray[infoArray.Length - 1] = "China";

                    if (infoArray.Last() == "Great Britain"
                        || infoArray.Last() == "UK"
                        || infoArray.Last() == "Wales"
                        || infoArray.Last() == "Scotland"
                        || infoArray.Last() == "Northern Ireland")
                        infoArray[infoArray.Length - 1] = "United Kingdom";

                    if (int.TryParse(infoArray.Last(), out int a))
                        infoArray[infoArray.Length - 1] = infoArray[infoArray.Length - 2].Trim();

                    infoArray[infoArray.Length - 1] = infoArray[infoArray.Length - 1].Replace(".", "");

                    if (!curAffs.Contains(infoArray.Last()))
                        curAffs.Add(infoArray.Last());
                }

                foreach (var key in curAffs)
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

        Dictionary<string, string> Abbreviations = new Dictionary<string, string>
        {
            {"Acoustics","Acoust."},
            {"Administration","Admin."},
            {"Administrative","Administ."},
            {"American","Amer."},
            {"Analysis","Anal."},
            {"Annals","Ann."},
            {"Annual","Annu."},
            {"Apparatus","App."},
            {"Applications","Applicat."},
            {"Applied","Appl."},
            {"Association","Assoc."},
            {"Automatic","Automat."},
            {"Broadcasting","Broadcast."},
            {"Business","Bus."},
            {"Communications","Commun."},
            {"Computers","Comput."},
            {"Computer","Comput."},
            {"Colloquium","Colloq."},
            {"Conference","Conf."},
            {"Congress","Congr."},
            {"Convention","Conv."},
            {"Correspondence","Corresp."},
            {"Cybernetics","Cybern."},
            {"Department","Dept."},
            {"Development","Develop."},
            {"Digest","Dig."},
            {"Economics","Econ."},
            {"Economic","Econ."},
            {"Education","Educ."},
            {"Electrical","Elect."},
            {"Electronic","Electron."},
            {"Engineering","Eng."},
            {"Ergonomics","Ergonom." },
            {"Evolutionary","Evol."},
            {"Exposition","Expo."},
            {"Foundation","Found."},
            {"Geoscience","Geosci."},
            {"Graphics","Graph."},
            {"Industrial","Ind."},
            {"Industry","Ind."},
            {"Information","Inform."},
            {"Institute","Inst."},
            {"Intelligence","Intell."},
            {"International","Int."},
            {"Journal","J."},
            {"Letters","Lett."},
            {"Letter","Lett."},
            {"Machine","Mach."},
            {"Magazine","Mag."},
            {"Management","Manage."},
            {"Managing","Manag."},
            {"Mathematics","Math."},
            {"Mathematic","Math."},
            {"Mathematical","Math."},
            {"Mechanical","Mech."},
            {"National","Nat."},
            {"Newsletter","Newslett."},
            {"Nuclear","Nucl."},
            {"Occupation","Occupat."},
            {"Philosophical","Philosph."},
            {"Proceedings","Proc."},
            {"Processing","Process."},
            {"Production","Prod."},
            {"Productivity","Productiv."},
            {"Quarterly","Quart."},
            {"Record","Rec."},
            {"Reliability","Rel."},
            {"Report","Rep."},
            {"Royal","Roy."},
            {"Science","Sci."},
            {"Selected","Select."},
            {"Society","Soc."},
            {"Sociological","Sociol."},
            {"Statistics","Stat."},
            {"Studies","Stud."},
            {"Supplement","Suppl."},
            {"Symposium","Symp."},
            {"Systems","Syst."},
            {"Technical","Tech."},
            {"Telecommunication","Telecommun."},
            {"Transactions","Trans."},
            {"Vehicular","Veh."},
            {"Working","Work."},
        };

        private string MakeAbbreviations(string s)
        {
            if (s == "")
                return s;

            foreach (var key in Abbreviations.Keys)
            {
                s = s.Replace(key, Abbreviations[key]).Replace(key.ToLower(), Abbreviations[key]);
            }

            return s;
        }
    }
}
