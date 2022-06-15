using BibReader.Publications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BibReader.Statistic
{
    public class Stat
    {
        public static Dictionary<string, int> Sources            { get; private set; } = new Dictionary<string, int>();
        public static Dictionary<string, int> SourcesUnique      { get; private set; } = new Dictionary<string, int>();
        public static Dictionary<string, int> SourcesRelevance   { get; private set; } = new Dictionary<string, int>();
        public static Dictionary<string, int> Years              { get; private set; } = new Dictionary<string, int>();
        public static Dictionary<string, int> Types              { get; private set; } = new Dictionary<string, int>();
        public static Dictionary<string, int> Journal            { get; private set; } = new Dictionary<string, int>();
        public static Dictionary<string, int> Conference         { get; private set; } = new Dictionary<string, int>();
        public static Dictionary<string, int> Geography          { get; private set; } = new Dictionary<string, int>();
        //new
        public static Dictionary<int, int> AuthorsCount          { get; private set; } = new Dictionary<int, int>();
        public enum Corpus
        {
            First,
            Unique,
            Relevance
        }

        public static void CalculateStatistic(List<LibItem> libItems, Corpus corpus)
        {
            //if (corpus == Corpus.First)
            //{
            //    Sources = new Dictionary<string, int>();
            //    SourcesUnique = new Dictionary<string, int>();
            //    SourcesRelevance = new Dictionary<string, int>();
            //}
            switch (corpus)
            {
                case Corpus.First:
                    Sources = new Dictionary<string, int>();
                    SourcesUnique = new Dictionary<string, int>();
                    SourcesRelevance = new Dictionary<string, int>();
                    break;
                case Corpus.Unique:
                    SourcesUnique = new Dictionary<string, int>();
                    break;
                case Corpus.Relevance:
                    SourcesRelevance = new Dictionary<string, int>();
                    break;
            }

            Years = new Dictionary<string, int>();
            Types = new Dictionary<string, int>();
            Journal = new Dictionary<string, int>();
            Conference = new Dictionary<string, int>();
            Geography = new Dictionary<string, int>();
            AuthorsCount = new Dictionary<int, int>();

            foreach (var item in libItems)
            {
                SetYearStatistic(item);
                SetTypesStatistic(item);
                if (corpus == Corpus.First)
                    SetSourseStatictic(item);
                if (corpus == Corpus.Unique)
                    SetSourseUniqueStatictic(item);
                if (corpus == Corpus.Relevance)
                    SetSourseRelevanceStatictic(item);
                SetJournalStatistic(item);
                SetConferenceStatistic(item);
                SetGeographyStatistic(item);
                SetAuthorsCount(item);
            }
        }
        //new
        private static void SetAuthorsCount(LibItem libItem)
        {
            if (AuthorsCount.ContainsKey(libItem.AuthorsCount()))
                AuthorsCount[libItem.AuthorsCount()]++;
            else
                AuthorsCount.Add(libItem.AuthorsCount(), 1);
        }
        private static void SetGeographyStatistic(LibItem libItem)
        {
            if (libItem.Affiliation != string.Empty)
            {
                foreach (var country in libItem.Geography)
                {
                    if (Geography.ContainsKey(country))
                        Geography[country]++;
                    else
                        Geography.Add(country, 1);
                }

                //    List<string> affs = new List<string>();
                //    if(libItem.Source == "Web of Science")
                //    {
                //        affs = libItem.Affiliation
                //            .Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries)
                //            .Where(text => text[text.Length-2] != ' ')
                //            .ToList();
                //    }
                //    else
                //        affs = libItem.Affiliation.Split(';').ToList();

                //    Dictionary<string, int> curAffs = new Dictionary<string, int>();

                //    foreach (var aff in affs)
                //    {
                //        var infoArray = aff.Split(',');

                //        infoArray[infoArray.Length - 1] = infoArray.Last().Trim();

                //        if (infoArray.Last().Contains("USA") || infoArray.Last() == "United States")
                //            infoArray[infoArray.Length - 1] = "USA";

                //        if (infoArray.Last() == "Russian Federation")
                //            infoArray[infoArray.Length - 1] = "Russia";

                //        if (infoArray.Last().Contains("China"))
                //            infoArray[infoArray.Length - 1] = "China";

                //        infoArray[infoArray.Length - 1] = infoArray[infoArray.Length - 1].Replace(".", "");

                //        if (!curAffs.ContainsKey(infoArray.Last()))
                //            curAffs.Add(infoArray.Last(), 1);
                //    }

                //    foreach (var key in curAffs.Keys)
                //    {
                //        if (Geography.ContainsKey(key))
                //            Geography[key]++;
                //        else
                //            Geography.Add(key, 1);
                //    }
            }
            else
                if (Geography.ContainsKey(""))
                    Geography[""]++;
                else
                    Geography.Add("", 1);
        }

        private static void SetYearStatistic(LibItem libItem)
        {
            if (Years.ContainsKey(libItem.Year))
                Years[libItem.Year]++;
            else
                Years.Add(libItem.Year, 1);
        }

        private static void SetJournalStatistic(LibItem libItem)
        {
            if (libItem.Type == "journal")
            if (Journal.ContainsKey(libItem.Journal))
                Journal[libItem.Journal]++;
            else
                Journal.Add(libItem.Journal, 1);
        }

        private static void SetConferenceStatistic(LibItem libItem)
        {
            if (libItem.Type == "conference")
            {
                var title = libItem.Journal;
                if (Conference.ContainsKey(title))
                    Conference[title]++;
                else
                    Conference.Add(title, 1);
            }
        }

        private static void SetSourseStatictic(LibItem libItem)
        {
            if (Sources.ContainsKey(libItem.Source))
                Sources[libItem.Source]++;
            else
            {
                Sources.Add(libItem.Source, 1);
                SourcesUnique.Add(libItem.Source, 0);
                SourcesRelevance.Add(libItem.Source, 0);
            }
        }

        private static void SetSourseUniqueStatictic(LibItem libItem)
        {
            if (SourcesUnique.ContainsKey(libItem.Source))
                SourcesUnique[libItem.Source]++;
            else
                SourcesUnique.Add(libItem.Source, 1);
        }

        private static void SetSourseRelevanceStatictic(LibItem libItem)
        {
            if (SourcesRelevance.ContainsKey(libItem.Source))
                SourcesRelevance[libItem.Source]++;
            else
                SourcesRelevance.Add(libItem.Source, 1);
        }

        private static void SetTypesStatistic(LibItem libItem)
        {
            if (Types.ContainsKey(libItem.Type))
                Types[libItem.Type]++;
            else
                Types.Add(libItem.Type, 1);
        }

        //public static void DeleteGeography(List<string> geo)
        //{
        //    foreach(string key in geo)
        //    {
        //        Geography[key]--;
        //    }

        //    Geography = Geography.Where(x => x.Value > 0).ToDictionary(x => x.Key, x => x.Value);
        //}
    }
}
