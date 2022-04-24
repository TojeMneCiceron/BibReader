﻿using BibReader.Publications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibReader.Readers.BibReaders
{
    [Serializable]
    public class Source
    {
        public string Name { get; set; }
        public string Pattern { get; set; }
        public string FirstTag { get; set; }
        public bool HasDoubleBracketsOpening { get; set; }
        public bool HasDoubleBracketsClosing { get; set; }
        public bool TagCapital { get; set; }
        public bool TagValueSpaces { get; set; }
        public bool HasAsterisks { get; set; }

        public Source() { }

        public Source(string name, string pattern, string firstTag, bool hasDoubleBracketsOpening,
            bool hasDoubleBracketsClosing, bool tagCapital, bool tagValueSpaces, bool hasAsterisks)
        {
            Name = name;
            Pattern = pattern;
            FirstTag = firstTag;
            HasDoubleBracketsOpening = hasDoubleBracketsOpening;
            HasDoubleBracketsClosing = hasDoubleBracketsClosing;
            TagCapital = tagCapital;
            TagValueSpaces = tagValueSpaces;
            HasAsterisks = hasAsterisks;
        }

        public bool SourceAffiliation(LibItem item)
        {
            Regex regex = new Regex($"^{Pattern}$");
            //return false;

            //bool hasAsterisks;
            //if (item.Keywords.Contains("*"))
            //bool hasAsterisks = Regex.Matches(item.Keywords, @"\*").Count > Regex.Matches(item.Keywords, @"\{\*\}").Count;

            bool res = regex.IsMatch(item.BibTexId)
                && item.BibTexString.Contains("{{") == HasDoubleBracketsOpening
                && item.BibTexString.Contains("}}") == HasDoubleBracketsClosing
                && item.BibTexString.Contains("\nTitle") == TagCapital
                && item.BibTexString.Contains("itle = ") == TagValueSpaces
                //&& hasAsterisks == HasAsterisks 
                && item.BibTexFirstTag.ToLower() == FirstTag.ToLower();

            //int a = 0;
            //if (Name == "ACM DL" && !res)
            //    a += 1;

            return res;
        }

        public string Features()
        {
            string res = "";

            if (HasDoubleBracketsOpening)
                res += "{{; ";
            if (HasDoubleBracketsClosing)
                res += "}}; ";
            if (TagCapital)
                res += "Заглавные буквы; ";
            if (TagValueSpaces)
                res += "Пробелы; ";
            if (HasAsterisks)
                res += "*; ";

            return res;
        }
    }
}
