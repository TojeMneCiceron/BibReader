using BibReader.Publications;
using BibReader.Readers.BibReaders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BibReader.Readers
{
    public class UniversalBibReader
    {
        string defaultPagesNumber = "<<1-5>>";
        int abstractMaxLength = 999;

        //private string FindSource(string str, int titleTagPosition)
        //{
        //    switch (titleTagPosition)
        //    {
        //        case 1:
        //            return "Science Direct";
        //        case 2:
        //            if (str.Contains("title ="))
        //                return "ACM DL";
        //            //if (str.Contains("title="))
        //            //    return "Scopus";
        //            if (str.Contains("Title ="))
        //                return "Web of Science";
        //            break;
        //        case 3:
        //            if (str.Contains("Title ="))
        //                return "Web of Science";
        //            return "IEEE";
        //    }
        //    return "";

        //    //switch(str.Substring(0, "title".Length))
        //    //{
        //    //    case " titl":
        //    //        return "ACM DL";
        //    //    case "title":
        //    //        //if (i == 1 || i == 3)
        //    //        //    return "ACM DL";
        //    //        //else
        //    //            return (str[5] != ' ') ? "IEEE" : "Science Direct";
        //    //    case "Title":
        //    //        return "Web of Science";
        //    //}
        //    //return "";
        //}

        //private void SetSource(string key, string value, string tagString, int titleTagPosition)
        //{
        //    if (key == "title" || key == "Title" || key == "source")
        //    {
        //        if (Tags.TagValues["source"] == "")
        //            Tags.TagValues["source"] = FindSource(tagString, titleTagPosition);
        //        if (key == "source")
        //            Tags.TagValues["source"] = value;
        //    }
        //}

        private string PretreatTitle(string title)
        {
            string[] codesForRemove = new string[] {
                @"\&\#38;",
                "amp;#x2014;",
                "{''}"
            };

            foreach (var code in codesForRemove)
            {
                if (title.Contains(code))
                {
                    var index = title.IndexOf(code);
                    title = title.Remove(index, code.Length);
                    if (code == "{''}")
                        title = title.Insert(index, "”");
                }
            }
            return RemoveOriginalTitle(title);
        }

        private bool SetOriginalTitle(string title)
        {
            var template = @".*\[(.+)\].*";
            var regex = new Regex(template);

            Tags.TagValues["originalTitle"] = regex.Match(title).Groups[1].Value;
            return Tags.TagValues["originalTitle"] != "";
        }

        private string RemoveOriginalTitle(string title)
        {
            if (SetOriginalTitle(title))
                title = 
                    title
                    .Remove(
                        title.IndexOf(Tags.TagValues["originalTitle"]) - 1,
                        Tags.TagValues["originalTitle"].Length + 2
                    );
            return title;
        }

        private void FixScienceDirect(string str)
        {
            var template = @"(.+?)\s=\s""(.+?)""";
            var regex = new Regex(template);
           
            var key = regex.Match(str).Groups[1].Value;
            var value = regex.Match(str).Groups[2].Value;
            if (Tags.TagRework.ContainsKey(key) && Tags.TagValues.ContainsKey(Tags.TagRework[key]))
                Tags.TagValues[Tags.TagRework[key]] = value;
        }

        private void SetType(string str) =>
            Tags.TagValues["type"] =
                Tags.TagRework
                [
                    str
                    .Substring(
                        1,
                        str.IndexOf('{') - 1
                    )
                    .ToLower()
                ];

        private bool IsEndOfTag(string currstr) =>
            currstr.Length >= 3 &&
            (currstr.Substring(currstr.Length - 2, 2) == "}," ||
            currstr.Substring(currstr.Length - 3, 3) == "}, " ||
            currstr.Substring(currstr.Length - 2, 2) == "\",") ||
            currstr.Substring(currstr.Length - 3, 3) == "},}";

        private bool IsEndOfLibItem(string currstr) => 
            currstr.Length > 2 && currstr != "}" 
            && currstr.Substring(currstr.Length - 2, 2) != ",}";

        private bool IsEvenBracketCount(string str)
        {
            return str.Count(x => x == '{') == str.Count(x => x == '}');
        }

        private string ReformatAbstract(string abst)
        {
            if (abst.Length == abstractMaxLength)
                abst = "<<НЕПОЛНАЯ АННОТАЦИЯ!>> " + abst;

            if (abst.Contains("["))
                abst = abst.Substring(0, abst.IndexOf("["));

            return abst;
        }

        private string RemoveExtraSymbols(string str)
        {
            Regex r = new Regex(@"{\w}");
            Regex rs = new Regex(@"\s+");
            //remove extra spaces and \
            string res = rs.Replace(str, " ").Replace("{\"}", "\"").Replace(@"\", "").Replace("<i>", "").Replace("</i>", "").Replace("{[}", "[").Replace("]", "]");

            var matches = r.Matches(res);

            foreach (Match match in matches)
            {
                var sym = Regex.Match(match.Value, @"\w");
                res = res.Replace(match.Value, sym.Value);
            }

            return res;
        }

        private string FixWOSGeography(string aff, string authors)
        {
            string[] s = aff.Replace(". ", "$").Split('$');

            return s.Where(x => !x.Contains("(Corresponding Author)")).Aggregate((x, y) => $"{x}. {y}");
        }

        private LibItem IdentifySource(LibItem item, List<Source> defaultSources, List<Source> customSources)
        {
            foreach (Source source in defaultSources)
            {
                if (source.SourceAffiliation(item))
                {
                    item.Source = source.Name;
                    return item;
                }
            }
            foreach (Source source in customSources)
            {
                if (source.SourceAffiliation(item))
                {
                    item.Source = source.Name;
                    return item;
                }
            }
            item.Source = "Неизв. источник";
            item.UnknownSource = true;
            return item;
        }

        //private string GetBibTexID(string bibTexString)
        //{
        //    string firstLine = bibTexString.Split('\n').First();

        //    string res = firstLine.Substring(firstLine.IndexOf('{') + 1);
        //    res = res.Substring(0, res.LastIndexOf(','));

        //    return res;
        //}

        private bool Caps(string s)
        {
            int caps = s.Where(x => x >= 'A' && x <= 'Z').Count();
            return (double)caps / s.Length > 0.6;
        }

        private string FixJournal(string j)
        {
            Regex regex = new Regex(@"\([A-Za-z0-9 ]+\)");
            string abb = regex.Match(j).Value;
            string res = j.ToLower();
            if (abb != "")
                res = res.Replace(abb.ToLower(), abb);

            return res;
        }
        private List<LibItem> GetLibItems(StreamReader reader, List<Source> defaultSources, List<Source> customSources)
        {
            string extra = "";

            List<LibItem> Items = new List<LibItem>();
            var template = @"\s?(.+?)\s?=\s?(""|{{|{)(.+?)(""|}}|}),";
            var regex = new Regex(template);
            string tagString = "", newLine = "";
            Tags.NewTags();

            if (reader == null)
                return Items;
            newLine = reader.ReadLine();

            while (newLine == null || newLine == "" || newLine[0] != '@')
            {
                if (newLine == null)
                    return Items;
                newLine = reader.ReadLine();
            }
            SetType(newLine);
            SourceIdentifier sourceIdentifier = new SourceIdentifier();
            sourceIdentifier.InitString = newLine;
            //ugums

            //int titleTagPosition = 1;
            bool isPagesTagFound = false;
            bool isNumpagesTagFound = false;
            string numpages = "";

            //int finalTitleTagPosition = -1;
            bool isFirstTag = true;
            string firstTag = "";
            string fullBibTexString = newLine + "\r\n";

            while (!reader.EndOfStream)
            {
                newLine = reader.ReadLine();
                while (newLine == "" || IsEndOfLibItem(newLine))
                {
                    if (newLine != "")
                    {
                        if (newLine[0] != '@')
                            tagString += newLine;
                        else
                        {
                            SetType(newLine);

                            sourceIdentifier = new SourceIdentifier();
                            sourceIdentifier.InitString = newLine;
                            //titleTagPosition = 0;

                            isFirstTag = true;
                            firstTag = "";
                            fullBibTexString = "";

                            isPagesTagFound = false;
                            isNumpagesTagFound = false;
                            numpages = "";
                        }

                        //string nextLine = reader.ReadLine();

                        if (IsEndOfTag(newLine) || IsEvenBracketCount(tagString))
                        {
                            if (newLine[newLine.Length - 1] == '}')
                                tagString += ",";

                            tagString = RemoveExtraSymbols(tagString);

                            if (newLine.Contains("@"))
                                fullBibTexString += newLine + "\r\n";
                            else
                                fullBibTexString += tagString + "\r\n";

                            sourceIdentifier.DoubleBracketsOpening = tagString.Contains("{{");
                            sourceIdentifier.DoubleBracketsClosing = tagString.Contains("}}");

                            var key = regex.Match(tagString).Groups[1].Value;

                            if (isFirstTag && key != "")
                            {
                                firstTag = key;
                                isFirstTag = false;
                            }

                            var value = ClearValue(regex.Match(tagString).Groups[3].Value, key);

                            if (key == "numpages")
                            {
                                isNumpagesTagFound = true;
                                numpages = value;
                            }

                            if (Tags.TagRework.ContainsKey(key) && Tags.TagRework[key] == "title" && value[value.Length - 1] == '.')
                                value = value.Substring(0, value.Length - 1);

                            if (Tags.TagRework.ContainsKey(key) && Tags.TagRework[key] == "source")
                                sourceIdentifier.SourceTag = value;

                            if (Tags.TagRework.ContainsKey(key) && Tags.TagRework[key] == "year")
                                sourceIdentifier.Year = value;

                            if (Tags.TagRework.ContainsKey(key) && Tags.TagRework[key] == "pages")
                            {
                                isPagesTagFound = true;
                                sourceIdentifier.Pages = value;
                                //if (value.Length >= 5 && !value.Contains('-'))
                                if (value.Any(char.IsLetter))
                                    value = defaultPagesNumber;

                            }

                            if (Tags.TagRework.ContainsKey(key) && Tags.TagRework[key] == "abstract")
                                value = ReformatAbstract(value);

                            //if (Tags.TagRework.ContainsKey(key) && Tags.TagRework[key] == "affiliation")
                            //    value = FixGeography(value);

                            //SetSource(key, value, tagString, titleTagPosition);
                            if (Tags.TagRework.ContainsKey(key))
                                Tags.TagValues[Tags.TagRework[key]] = value;
                            tagString = "";
                            //titleTagPosition++;
                        }
                    }

                    //fixing issue with tag 'title' in IEEE
                    if (extra == "")
                        newLine = reader.ReadLine();
                    else
                    {
                        newLine = extra;
                        extra = "";
                    }

                    if (newLine == null)
                        break;

                    if (newLine.Contains("}, title={"))
                    {
                        newLine = newLine.Replace("}, title={", "},\ntitle={");

                        string[] temp = newLine.Split('\n');

                        newLine = temp[0];
                        extra = temp[1];
                    }

                    
                }
                if (tagString != string.Empty)
                    FixScienceDirect(tagString);
                if (newLine == null)
                    break;
                tagString = string.Empty;

                if (!isPagesTagFound)
                    if (isNumpagesTagFound)
                        Tags.TagValues["pages"] = "1-" + numpages;
                    else
                        Tags.TagValues["pages"] = defaultPagesNumber;

                //Tags.TagValues["source"] = sourceIdentifier.IdentifySource();
                //if (Tags.TagValues["source"] == "Web of Science")
                Tags.TagValues["affiliation"] = FixWOSGeography(Tags.TagValues["affiliation"], Tags.TagValues["authors"]);

                var newItem = new LibItem(Tags.TagValues);

                newItem.BibTexFirstTag = firstTag;
                //setting string + id
                newItem.SetBibTexString(fullBibTexString + "}");
                //newItem.BibTexId = GetBibTexID(newItem.BibTexString);

                if (Tags.TagValues["source"] == "")
                    newItem = IdentifySource(newItem, defaultSources, customSources);


                //deleting caps
                if (Caps(newItem.Abstract))
                    newItem.Abstract = newItem.Abstract.ToLower();
                if (Caps(newItem.Title))
                    newItem.Title = newItem.Title.ToLower();
                if (Caps(newItem.Journal))
                {
                    newItem.Journal = FixJournal(newItem.Journal);
                }

                Items.Add(newItem);
                Tags.NewTags();
            }
            reader.Close();
            return Items;
        }

        public static string ClearValue(string value, string key)
        {
            key.ToLower();
            if (value != "" && ( key == "author"
                                || key == " author"  
                                || key == "title" 
                                || key == " title" 
                                || key == "pages" 
                                || key == " pages" 
                                || key == "journal" 
                                || key == " journal"
                                || key == "booktitle"
                                || key == " booktitle")
                ) {
                string[] symbolsForReplace = new string[] {
               @"{", @"}", @"\&\#38;", "�" , "®",  @"’", @"“", @"”", @"–", @" ", @"—", @"--",  @"{''}", @"\""{a}", @"\""{o}", @"{\'e}",
                @"\`{o", @"\'{\i}", @"\""{O}", @"\'{u}", @"\'{o}", @"\""{u}", @"\~{n}", @"\^{o}", @"\&", @"\""", @"\'", @"\~", @"\^", @"\`"
            };

                string[] newSymbols = new string[] {
                "", "", "", "", "",
                @"'", @"""", @"""", @"-", @" ", @"-", @"-", @"""", @"a", @"o", @"e",
                @"o", @"i", @"o", @"u", @"o", @"u", @"n", @"o", " ", "", "", "", "", ""
            };

                for (int i = 0; i < symbolsForReplace.Length; i++)
                {
                    value = value.Replace(symbolsForReplace[i], newSymbols[i]);
                }
            }
            return value;
        }

        public List<LibItem> Read(StreamReader[] readers, List<Source> defaultSources, List<Source> customSources)
        {
            var Items = new List<LibItem>();
            if (readers != null)
                foreach (var reader in readers)
                    Items.AddRange(GetLibItems(reader, defaultSources, customSources));
            return Items;
        }
    }
}
