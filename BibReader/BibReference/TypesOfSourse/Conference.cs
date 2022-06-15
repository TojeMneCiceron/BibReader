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
    public class Conference
    {
        string City;
        string ConferenceName;
        string ConferenceNameAbbreviated;
        string[] Authors;
        string Title;
        string Publisher;
        int Volume = 0;
        int Number = 0;
        string Pages;
        int Year;
        string Doi;
        string Source;

        Font f = new Font(SystemFonts.DefaultFont, FontStyle.Italic);
        const string PointSpace = ". ";
        const string Point = ".";
        const string Spase = " ";
        const string DoublePointSpace = ": ";
        const string DoublePoint = ":";
        const string Page = "p. ";
        const string PPage = "pp. ";
        const string CommaSpace = ", ";
        const string Comma = ",";
        const string Space = " ";
        const string DoubleSlash = " // ";
        const string IN = "In";
        const string In = "in ";
        const string Lparenthesis = "(";
        const string Rparenthesis = ")";
        const string Num = "no. ";
        const string Vol = "vol. ";
        const string EtAl = " et. al. ";
        const string Slash = "/";
        const string DOI = "doi:";

        public Conference(string[] authors, string title, string publisher, string pages, int year, string city, string conferenceName, int number, int volume, string doi, string source)
        {
            Authors = authors.ToArray();
            Title = title;
            Publisher = publisher;
            Pages = source == "Springer Link" ? "XXX-XXX" : pages;
            Year = year;
            City = city;
            Number = number;
            Volume = volume;
            ConferenceName = conferenceName;
            Doi = doi;
            Source = source;
        }

        public Conference(LibItem libItem)
        {
            Int32.TryParse(libItem.Year, out int year);
            Int32.TryParse(libItem.Number, out int number);
            Int32.TryParse(libItem.Volume, out int volume);
            Authors = AuthorsParser.ParseAuthors(libItem.Authors, libItem.Source);
            Title = libItem.Title;
            Publisher = libItem.Publisher;
            Pages = libItem.Source == "Springer Link" ? "XXX-XXX" : libItem.Pages;
            Year = year;
            City = libItem.Address;
            Number = number;
            Volume = volume;
            ConferenceName = libItem.Journal;
            ConferenceNameAbbreviated = libItem.JournalAbbreviation;
            Doi = libItem.Doi;
            Source = libItem.Source;
        }

        public void MakeGOST(RichTextBox rtb)
        {
            var result = string.Empty;
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
            result += ConferenceName + PointSpace;
            if (City != string.Empty)
                result += City + DoublePointSpace;
            result += Publisher + CommaSpace;
            result += Year + PointSpace;
            result += Int32.TryParse(Pages, out int a) ? Page : PPage;
            result += Pages + Point;
            rtb.Text += result + "\n\n";
        }

        public void MakeHarvard(RichTextBox rtb)
        {
            rtb.Select(rtb.TextLength, 0);
            rtb.SelectedText = AuthorsParser.MakeAuthorsForHarvard(Authors);
            rtb.SelectedText = Space;
            rtb.SelectedText = Lparenthesis + Year + Rparenthesis + Space;
            rtb.SelectedText = Title + PointSpace;
            rtb.SelectedText = IN + DoublePointSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = ConferenceName + PointSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            if (City != string.Empty)
                rtb.SelectedText = City + DoublePointSpace;
            rtb.SelectedText = Publisher + CommaSpace;
            rtb.SelectedText = Int32.TryParse(Pages, out int a) ? Page : PPage;
            rtb.SelectedText = Pages + Point + "\n\n";
        }

        public void MakeAPA(RichTextBox rtb)
        {
            if (Doi != string.Empty)
            {
                // like a journal
                rtb.Select(rtb.TextLength, 0);
                rtb.SelectedText = AuthorsParser.MakeAuthorsForAPA(Authors);
                rtb.SelectedText = Space;
                rtb.SelectedText = Lparenthesis + Year + Rparenthesis + PointSpace;
                rtb.SelectedText = Title + PointSpace;
                rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
                rtb.SelectedText = ConferenceName + CommaSpace;
                rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
                rtb.SelectedText =
                    (Volume != 0 && Number != 0)
                    ? Volume + Lparenthesis + Number + Rparenthesis + CommaSpace
                    : (Volume != 0 && Number == 0)
                        ? rtb.SelectedText = Volume + CommaSpace
                        : Number != 0 ? rtb.SelectedText = Number + CommaSpace : "";
                rtb.SelectedText = Pages + Point;
                rtb.SelectedText = Space + DOI + Space + Doi;
                rtb.SelectedText = "\n\n";
            }
            else
            {
                // like a book
                rtb.Select(rtb.TextLength, 0);
                rtb.SelectedText = AuthorsParser.MakeAuthorsForAPA(Authors);
                rtb.SelectedText = Space;
                rtb.SelectedText = Lparenthesis + Year + Rparenthesis + PointSpace;
                if (Title != string.Empty)
                    rtb.SelectedText = Title + PointSpace;
                rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
                rtb.SelectedText = ConferenceName + Space;
                rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
                rtb.SelectedText = Lparenthesis;
                if (Volume != 0)
                    rtb.SelectedText += Vol + Volume + CommaSpace;
                rtb.SelectedText = Int32.TryParse(Pages, out int a) ? Page : PPage;
                rtb.SelectedText = Pages + Rparenthesis + PointSpace;
                if (City != string.Empty)
                    rtb.SelectedText = City + DoublePoint;
                rtb.SelectedText = Publisher + Point;
                rtb.SelectedText = "\n\n";
            }
        }

        public void MakeIEEE(RichTextBox rtb)
        {
            rtb.Select(rtb.TextLength, 0);
            rtb.SelectedText = AuthorsParser.MakeAuthorsForIEEE(Authors) + CommaSpace;
            rtb.SelectedText = "“" + Title + ",”" + In;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = f;
            rtb.SelectedText = ConferenceNameAbbreviated + CommaSpace;
            rtb.Select(rtb.TextLength, 0); rtb.SelectionFont = SystemFonts.DefaultFont;
            //if (City != string.Empty)
            //    rtb.SelectedText = City + CommaSpace;
            rtb.SelectedText = Year + CommaSpace;
            if (Volume != 0)
                rtb.SelectedText = Vol + Volume + CommaSpace;
            if (Number != 0)
                rtb.SelectedText = Num + Number + CommaSpace;
            rtb.SelectedText = Int32.TryParse(Pages, out int a) ? Page : PPage;
            rtb.SelectedText = Pages + Point + "\n\n";
        }
    }
}
