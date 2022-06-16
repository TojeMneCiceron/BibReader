using BibReader.Publications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReader.BibReference
{
    //public enum Sourse
    //{
    //    Scopus,
    //    ScienceDirect,
    //    IEEE,
    //    WebOfScience,
    //    ACMDL
    //}

    class AuthorsParser
    {
        //public string Authors { get; set; }

        public static string[] ParseAuthors(string authors, string sourse)
        {
            var Authors = authors.Split(new string[] { " and " }, StringSplitOptions.RemoveEmptyEntries);
            
            switch(sourse)
            {
                case "Scopus":
                    Authors = Authors
                    .Select(
                        author => author = 
                        string.Join(
                            " ", 
                            author
                            .Split(' ')
                            .Select(
                                (part, i) => 
                                part = i != 0 
                                ? string.Join(". ", part.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries)) + "." 
                                //? part.Replace(".", ". ").Remove(part.Length - 2)
                                : part
                            )
                        )
                    )
                    .ToArray();
                    LastNameIsFirst(ref Authors);
                    break;

                case "Science Direct":
                    LastNameIsLast(ref Authors);
                    break;

                case "IEEE":
                    LastNameIsFirst(ref Authors);
                    break;

                case "Web of Science":
                    LastNameIsFirst(ref Authors);
                    break;

                case "ACM DL":
                    LastNameIsFirst(ref Authors);
                    break;

                case "Springer Link":
                    LastNameIsLast(ref Authors);
                    break;
            }

            return Authors;
        }

        private static void LastNameIsFirst(ref string[] Authors)
        {
            for (int i = 0; i < Authors.Length; i++)
                while (Authors[i].Contains(','))
                    Authors[i] = Authors[i].Remove(Authors[i].IndexOf(','), 1);
        }

        private static void LastNameIsLast(ref string[] Authors)
        {
            for (int i = 0; i < Authors.Length; i++)
            {
                while (Authors[i].Contains(','))
                    Authors[i] = Authors[i].Remove(Authors[i].IndexOf(','), 1);
                var indexOfStartLastName = Authors[i].LastIndexOf(' ');
                if (indexOfStartLastName > 0)
                {
                    var FirstName = Authors[i].Substring(0, indexOfStartLastName);
                    var LastName = Authors[i].Substring(indexOfStartLastName + 1);
                    Authors[i] = string.Join(" ", LastName, FirstName);
                }
            }
        }

        public static string MakeAuthorsForAPA(List<Author> authors)
        {
            if (authors.Count == 0)
                return "";

            if (authors.Count == 1)
                return authors[0].FirstNameLast();
            else if (authors.Count > 20)
            {
                //return authors.Where((x, i) => i < 20).Select(x => x.FirstNameLast() + ", ").Aggregate((x, y) => $"{x}{y}") + $"... {authors.Last().FirstNameLast()}";

                return authors.Select((x, i) => i < 20 ? $"{x.FirstNameLast()}, " : i == authors.Count - 1 ? $"... {x.FirstNameLast()}" : "").Aggregate((x, y) => $"{x}{y}");
            }   
            else
            {
                return authors.Select((x, i) => i < authors.Count - 1 ? $"{x.FirstNameLast()}, " : $"& {x.FirstNameLast()}").Aggregate((x, y) => $"{x}{y}");
            }
            //return 
            //    string.Join(
            //        "",
            //        authors
            //        .Select(
            //            author => string.Join(
            //                " ",
            //                author.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            //                .Select(
            //                    (part, index) => 
            //                    part = index == 0 
            //                    ? part + "," 
            //                    : part[0] + "."
            //                )
            //            )
            //        )
            //        .Select(
            //            (author, i) => 
            //            authors.Count() < 8
            //            ?
            //            author +=
            //                i != authors.Length - 1 && i != authors.Length - 2
            //                ? ", "
            //                : i != authors.Length - 1 ? ", & " : ""
            //            :
            //            author =
            //                i <= 6
            //                ? i < 6 
            //                ? author + ", " 
            //                : author + " ... "
            //                : i == authors.Length - 1 ? author : ""
            //        )
            //    );
        }

        public static string MakeAuthorsForHarvard(List<Author> authors)
        {
            if (authors.Count == 0)
                return "";

            if (authors.Count > 3)
            {
                return authors[0].FirstNameLast() + " et. al.";
            }
            else
            {
                switch (authors.Count)
                {
                    case 1:
                        return authors[0].FirstNameLast();

                    case 2:
                        return $"{authors[0].FirstNameLast()} and {authors[1].FirstNameLast()}";

                    case 3:
                        return $"{authors[0].FirstNameLast()}, {authors[1].FirstNameLast()} and {authors[2].FirstNameLast()}";

                    default:
                        return "";
                }
            }             
            //return 
            //    string.Join(
            //        "",
            //        authors
            //        .Select(author => 
            //            string.Join(
            //                " ",
            //                author.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            //                .Select(
            //                    (part, index) => 
            //                    part = index == 0 
            //                    ? part + "," 
            //                    : part[0] + "."
            //                )
            //            )
            //        )
            //        .Select(
            //            (author, i) => 
            //            author += i != authors.Length - 1 && i != authors.Length - 2
            //            ? ", "
            //            : i != authors.Length - 1 ? " and " : ""
            //        )
            //    );
        }

        public static string MakeAuthorsForIEEE(List<Author> authors)
        {
            if (authors.Count == 0)
                return "";

            if (authors.Count > 6)
            {
                return authors[0].FirstNameFirst() + " et al.";
            }
            else
            {
                switch (authors.Count)
                {
                    case 1:
                        return authors[0].FirstNameFirst();
                    case 2:
                        return $"{authors[0].FirstNameFirst()} and {authors[1].FirstNameFirst()}";
                    default:
                        return authors.Select((x, i) => i < authors.Count - 1 ? $"{x.FirstNameFirst()}," : $"and {x.FirstNameFirst()}").Aggregate((x, y) => $"{x} {y}");
                }
            }    
            
            //return 
            //    string.Join(
            //        "",
            //        authors
            //        .Select(
            //            author => 
            //            author.IndexOf(" ") != -1 
            //            ? string.Join(
            //                " ",
            //                author
            //                .Substring(author.IndexOf(" ") + 1)
            //                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            //                .Select(init => init[0] + ".")
            //            )
            //            + " " + author.Substring(0, author.IndexOf(" "))
            //            : author
            //        )   
            //        .Select(
            //            (author, i) => author +=
            //            i != authors.Length - 1 && i != authors.Length - 2
            //            ? ", "
            //            : i != authors.Length - 1 
            //                ? (i==0 ? " and " : ", and ") 
            //                : ""
            //        )
            //    );
        }

        public static string MakeAuthorsForGOST(List<Author> authors)
        {
            if (authors.Count == 0)
                return "";

            if (authors.Count > 3)
            {
                return $"{authors[0].FirstNameFirst()} [et. al.]";
            }
            else
            {
                return authors.Select(x => x.FirstNameLast()).Aggregate((x, y) => $"{x}, {y}");
            }

            //return
            //    authors.Length < 4
            //    ?
            //    string.Join(
            //        ", ",
            //        authors.Select(author =>
            //            string.Join(
            //                " ",
            //                author
            //                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            //                .Select((part, index) => part = index == 0 ? part : part[0] + ".")
            //            )
            //        )
            //    )
            //    :
            //    string.Join(
            //        "",
            //        authors
            //        .Select(
            //            author =>
            //            author.IndexOf(" ") != -1
            //            ? string.Join(
            //                " ",
            //                author
            //                .Substring(author.IndexOf(" ") + 1)
            //                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
            //                .Select(init => init[0] + ".")
            //            )
            //            + " " + author.Substring(0, author.IndexOf(" "))
            //            : author
            //        )
            //        .Select(
            //            (author, i) =>
            //            author =
            //                i < 1
            //                //i < 3
            //                ?
            //                    i == 0
            //                    //i == 2
            //                    ? author + " [et. al.]"
            //                    : author + ", "
            //                : string.Empty
            //        )
            //    );
        }
    }
}
