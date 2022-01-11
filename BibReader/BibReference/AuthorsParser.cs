using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReader.BibReference
{
    public enum Sourse
    {
        Scopus,
        ScienceDirect,
        IEEE,
        WebOfScience,
        ACMDL
    }

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
                    LastNameIsLast(ref Authors);
                    break;

                case "Web of Science":
                    LastNameIsFirst(ref Authors);
                    break;

                case "ACM DL":
                    LastNameIsFirst(ref Authors);
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
                var FirstName = Authors[i].Substring(0, indexOfStartLastName);
                var LastName = Authors[i].Substring(indexOfStartLastName + 1);
                Authors[i] = string.Join(" ", LastName, FirstName);
            }
        }

        public static string MakeAuthorsForAPA(string[] authors)
        {
            return 
                string.Join(
                    "",
                    authors
                    .Select(
                        author => string.Join(
                            " ",
                            author.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(
                                (part, index) => 
                                part = index == 0 
                                ? part + "," 
                                : part[0] + "."
                            )
                        )
                    )
                    .Select(
                        (author, i) => 
                        authors.Count() < 8
                        ?
                        author +=
                            i != authors.Length - 1 && i != authors.Length - 2
                            ? ", "
                            : i != authors.Length - 1 ? " & " : ""
                        :
                        author =
                            i <= 6
                            ? i < 6 
                            ? author + ", " 
                            : author + " ... "
                            : i == authors.Length - 1 ? author : ""
                    )
                );
        }

        public static string MakeAuthorsForHarvard(string[] authors)
        {
            return 
                string.Join(
                    "",
                    authors
                    .Select(author => 
                        string.Join(
                            " ",
                            author.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(
                                (part, index) => 
                                part = index == 0 
                                ? part + "," 
                                : part[0] + "."
                            )
                        )
                    )
                    .Select(
                        (author, i) => 
                        author += i != authors.Length - 1 && i != authors.Length - 2
                        ? ", "
                        : i != authors.Length - 1 ? " and " : ""
                    )
                );
        }

        public static string MakeAuthorsForIEEE(string[] authors)
        {
            return 
                string.Join(
                    "",
                    authors
                    .Select(
                        author => 
                        author.IndexOf(" ") != -1 
                        ? string.Join(
                            " ",
                            author
                            .Substring(author.IndexOf(" ") + 1)
                            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(init => init[0] + ".")
                        )
                        + " " + author.Substring(0, author.IndexOf(" "))
                        : author
                    )   
                    .Select(
                        (author, i) => author +=
                        i != authors.Length - 1 && i != authors.Length - 2
                        ? ", "
                        : i != authors.Length - 1 
                            ? (i==0 ? " and " : ", and ") 
                            : ""
                    )
                );
        }

        public static string MakeAuthorsForGOST(string[] authors)
        {
            return
                authors.Length < 4
                ?
                string.Join(
                    ", ",
                    authors.Select(author =>
                        string.Join(
                            " ",
                            author
                            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select((part, index) => part = index == 0 ? part : part[0] + ".")
                        )
                    )
                )
                :
                string.Join(
                    "",
                    authors
                    .Select(
                        author =>
                        author.IndexOf(" ") != -1
                        ? string.Join(
                            " ",
                            author
                            .Substring(author.IndexOf(" ") + 1)
                            .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(init => init[0] + ".")
                        )
                        + " " + author.Substring(0, author.IndexOf(" "))
                        : author
                    )
                    .Select(
                        (author, i) =>
                        author =
                            i < 3
                            ?
                                i == 2
                                ? author + " et. al."
                                : author + ", "
                            : string.Empty
                    )
                );
        }
    }
}
