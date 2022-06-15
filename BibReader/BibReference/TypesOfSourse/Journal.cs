using BibReader.Publications;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibReader.BibReference.TypesOfSourse
{
    public class Journal
    {
        string Title;
        string[] Authors;
        string JournalName;
        string JournalNameAbbreviated;
        string Pages;
        int Year;
        int Number;
        int Volume;
        string Link;
        string DOI;
        DateTime Date;
        string Source;

        Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
        const string Point = ".";
        const string Page = "p. ";
        const string PPage = "pp. ";
        const string CommaSpace = ", ";
        const string Space = " ";
        const string Access = "Accessed on: ";
        const string Num = "no. ";
        const string Vol = "vol. ";
        const string PointSpace = ". ";
        const string DoublePointSpace = ": ";
        const string DoubleSlash = "//";
        const string URL = "URL: ";
        const string Lparenthesis = "(";
        const string Rparenthesis = ")";
        const string Avaliable = "Avaliable at: ";
        const string DateRus = "дата обращения";
        const string Lpar = "[";
        const string Rpar = "]";
        const string Retrieved = "Retrieved ";
        const string From = "from ";
        const string EtAl = " et. al. ";
        const string Slash = "/";

        public Journal(string[] authors, string title, string journalName, string pages, int year, int number, int vol, string link, DateTime date, string source, string doi)
        {
            Authors = authors.ToArray();
            Title = title;
            JournalName = journalName;
            Year = year;
            Pages = source == "Springer Link" ? "XXX-XXX" : pages;
            Number = number;
            Volume = vol;
            Link = link;
            Date = date;
            Source = source;
            DOI = doi;
        }

        public Journal(LibItem libItem)
        {
            Int32.TryParse(libItem.Volume, out int volume);
            Int32.TryParse(libItem.Number, out int number);
            Int32.TryParse(libItem.Year, out int year);

            Authors = AuthorsParser.ParseAuthors(libItem.Authors, libItem.Source);
            Title = libItem.Title;
            JournalName = libItem.Journal;
            JournalNameAbbreviated = libItem.JournalAbbreviation;
            Year = year;
            Pages = libItem.Source == "Springer Link" ? "XXX-XXX" : libItem.Pages;
            Number = number;
            Volume = volume;
            Link = string.Empty;
            Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            DOI = libItem.Doi;
        }

        public void MakeGOST(RichTextBox rtb)
        {
            string result = string.Empty;
            if (Authors.Length < 4)
            {
                result += AuthorsParser.MakeAuthorsForGOST(Authors);
                result += Space;
                result += Title;
            }
            else
            {
                result += Title;
                result += Space + Slash + Space;
                result += AuthorsParser.MakeAuthorsForGOST(Authors);
            }
            result += Space + DoubleSlash + Space;
            result += JournalName + PointSpace;
            result += Year + PointSpace;
            if (Volume != 0)
                result += Vol + Volume + CommaSpace;
            if (Number != 0)
                result += Num + Number + PointSpace;
            result += PPage + Pages + Point;
            if (Link != string.Empty)
                result += Space + URL + Link + Space + Lparenthesis + Avaliable + Date.ToString("dd.MM.yyyy") + Rparenthesis + Point;
            rtb.Text += result + "\n\n";
        }

        public void MakeHarvard(RichTextBox rtb)
        {
            rtb.Select(rtb.TextLength, 0);
            rtb.SelectedText = AuthorsParser.MakeAuthorsForHarvard(Authors);
            rtb.SelectedText = Space;
            rtb.SelectedText = Lparenthesis + Year + Rparenthesis + Space;
            rtb.SelectedText = Title + PointSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = JournalName + CommaSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            rtb.SelectedText = 
                (Volume != 0 && Number != 0)
                ? Volume + Lparenthesis + Number + Rparenthesis + CommaSpace
                : (Volume != 0 && Number == 0)
                    ? rtb.SelectedText = Volume + CommaSpace
                    : Number != 0 ? rtb.SelectedText = Number + CommaSpace : "";
            rtb.SelectedText = Int32.TryParse(Pages, out int a) ? Page : PPage;
            rtb.SelectedText = Pages + Point;
            if (Link != "")
                rtb.SelectedText = Space + Avaliable + Link + Space + Lpar + DateRus + Date.ToString("dd MMM yyyy") + Rpar + Point;
            rtb.SelectedText = "\n\n";
        }

        public void MakeAPA(RichTextBox rtb)
        {
            rtb.Select(rtb.TextLength, 0);
            rtb.SelectedText = AuthorsParser.MakeAuthorsForAPA(Authors);
            rtb.SelectedText = Space;
            rtb.SelectedText = Lparenthesis + Year + Rparenthesis + PointSpace;
            rtb.SelectedText = Title + PointSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = JournalName + CommaSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            rtb.SelectedText =
                (Volume != 0 && Number != 0)
                ? Volume + Lparenthesis + Number + Rparenthesis + CommaSpace
                : (Volume != 0 && Number == 0)
                    ? rtb.SelectedText = Volume + CommaSpace
                    : Number != 0 ? rtb.SelectedText = Number + CommaSpace : "";
            rtb.SelectedText = Pages + Point;
            //if (Link != "")
            //    rtb.SelectedText = Space + Retrieved + Date.ToString("dd MMMM yyyy") + CommaSpace + From + Link;

            if (DOI != "")
                rtb.SelectedText = Space + DOI;
            rtb.SelectedText = "\n\n";
        }

        public void MakeIEEE(RichTextBox rtb)
        {
            rtb.Select(rtb.TextLength, 0);
            rtb.SelectedText = AuthorsParser.MakeAuthorsForIEEE(Authors) + CommaSpace;
            //rtb.SelectedText = Lparenthesis + Year + Rparenthesis + PointSpace;
            rtb.SelectedText = "“" + Title + ",”" + Space;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = JournalNameAbbreviated + CommaSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            if (Volume != 0)
                rtb.SelectedText = Vol + Volume + CommaSpace;
            if (Number != 0)
                rtb.SelectedText = Num + Number + CommaSpace;
            rtb.SelectedText = Int32.TryParse(Pages, out int a) ? Page : PPage;
            rtb.SelectedText = Pages + CommaSpace + Year + Point;
            //if (Link != "")
            //    rtb.SelectedText = Space + Avaliable + Link + Point + Space + Access + Date.ToString("MMM. dd, yyyy.");
            rtb.SelectedText = "\n\n";
        }
    }
}
