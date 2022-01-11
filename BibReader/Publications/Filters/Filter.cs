using BibReader.Publications;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReader
{
    class Filter
    {
        public static List<string> Years = new List<string>();
        public static List<string> Types = new List<string>();
        public static List<string> Journals = new List<string>();
        public static List<string> Conferences = new List<string>();
        public static List<string> Geography = new List<string>();
        public static List<string> Source = new List<string>();
        public static List<int> AuthorsCount = new List<int>();

        public static List<LibItem> FilterOut(List<LibItem> libItems)
        {
            List<LibItem> res = new List<LibItem>();

            foreach (LibItem item in libItems)
            {
                if (Years.Contains(item.Year)
                    && Types.Contains(item.Type)
                    && Source.Contains(item.Source)
                    && (item.Type == "journal" && Journals.Contains(item.Journal) ||
                    item.Type == "conference" && Conferences.Contains(item.Journal) ||
                    item.Type == "book")
                    //&& (Geography.Count == 0 || Geography.Contains(item.Affiliation, new GeographyComparer()))
                    && (Geography.Count == 0 || CheckGeography(item))
                    && AuthorsCount.Contains(item.AuthorsCount()))
                {
                    res.Add(item);
                }
                //else
                //{
                //    int a = 1;
                //}
            }

            return res;


            return libItems
                .Where(item => 
                    Years.Contains(item.Year) 
                    && Types.Contains(item.Type) 
                    && Source.Contains(item.Source) 
                    && (item.Type == "journal" && Journals.Contains(item.Journal) ||
                    item.Type == "conference" && Conferences.Contains(item.Journal) ||
                    item.Type == "book")
                    && (Geography.Count == 0 || CheckGeography(item))
                    && AuthorsCount.Contains(item.AuthorsCount())
                )
                .ToList();
        }

        public static void Clear()
        {
            Years = new List<string>();
            Types = new List<string>();
            Journals = new List<string>();
            Conferences = new List<string>();
            Geography = new List<string>();
            Source = new List<string>();
            AuthorsCount = new List<int>();
        }

        private static bool CheckGeography(LibItem libItem)
        {
            if (libItem.AffiliationIsEmpty)
                return Geography.Contains("");

            foreach (var x in Geography)
                foreach (var y in libItem.Geography)
                    if (x == y)
                        return true;
            return false;
        }


        private class GeographyComparer : IEqualityComparer<string>
        {
            private bool IsWoS;

            public bool Equals(string x, string y)
            {
                string affiliation = y;
                if (affiliation != string.Empty)
                {
                    IsWoS = affiliation.Last() == '.';
                    var affs = !IsWoS
                            ? affiliation.Split(';').ToList()
                            : affiliation
                                .Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                                .Where(text => text[text.Length - 2] != ' ')
                                .ToList();
                    foreach (var aff in affs)
                    {
                        var infoArray = aff.Split(',');
                        if (x == infoArray.Last().Trim() 
                            || x.Contains("USA") && infoArray.Last().Contains("USA")
                            || x.Contains("USA") && infoArray.Last().Trim() == "United States"
                            || x == "United States" && infoArray.Last().Contains("USA")
                            || x.Contains("Russia") && infoArray.Last().Contains("Russia")
                            || x.Contains("China") && infoArray.Last().Contains("China"))
                            return true;
                    }
                    return false;
                }
                return true;
            }

            public int GetHashCode(string obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
