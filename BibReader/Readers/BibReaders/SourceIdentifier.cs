using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BibReader.Readers
{
    class SourceIdentifier
    {
        string sourceTag = "";

        string initString = "";
        string pages = "";
        string year = "";
        string author = "";
        bool doubleBracketsOpening = false;
        bool doubleBracketsClosing = false;

        Regex ACM = new Regex(@"[0-9]+.[0-9]+/");
        Regex IEEE = new Regex(@"{\b[0-9]{7}\b,");
        Regex Inspec = new Regex(@"{\b[0-9]{16}\b,");
        Regex ASTS = new Regex(@"{\b[0-9]{17}\b,");

        public SourceIdentifier() { }

        public string SourceTag { get => sourceTag; set => sourceTag = value; }
        public string InitString { get => initString; set => initString = value; }
        public bool DoubleBracketsOpening { get => doubleBracketsOpening; set => doubleBracketsOpening = value; }
        public bool DoubleBracketsClosing { get => doubleBracketsClosing; set => doubleBracketsClosing = value; }
        public string Pages { get => pages; set => pages = value; }
        public string Year { get => year; set => year = value; }

        private bool ScienceDirect()
        {
            pages = pages.Split('-')[0];
            return year != "" && initString.Contains(pages) && initString.Contains(year);
        }

        public string IdentifySource()
        {
            //scopus
            if (sourceTag != "")
                return sourceTag;

            if (initString.Contains("WOS:") || doubleBracketsOpening && doubleBracketsClosing)
                return "Web of Science";

            if (IEEE.IsMatch(initString) || !doubleBracketsOpening && doubleBracketsClosing)
                return "IEEE";

            if (ACM.IsMatch(initString))
                return "ACM DL";

            if (ASTS.IsMatch(initString))
                return "Applied Science & Technology Source";

            if (Inspec.IsMatch(initString))
                return "Inspec";

            if (ScienceDirect())
                return "Science Direct";

            return "";
        }
    }
}
