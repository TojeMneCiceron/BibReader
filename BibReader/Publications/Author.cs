using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReader.Publications
{
    public class Author
    {
        string LastName;
        string FirstName;

        public Author(string author)
        {
            author = author.Trim();
            bool toInitials = true;

            if (!author.Contains(" "))
            {
                LastName = author;
                FirstName = "";
            }
            else if (author.Contains(","))
            {
                var a = author.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                LastName = a[0];
                FirstName = a[1];
            }
            else
            {
                var indexOfStartLastName = author.LastIndexOf(' ');
                string s1 = author.Substring(0, indexOfStartLastName);
                string s2 = author.Substring(indexOfStartLastName + 1);
                //elibrary
                if (s2.Contains("."))
                {
                    LastName = s1;
                    FirstName = s2;
                    toInitials = false;
                }
                else
                {
                    //var indexOfStartLastName = author.LastIndexOf(' ');
                    FirstName = s1;
                    LastName = s2;
                }
            }

            if (toInitials)
                ToInitials();
        }

        private void ToInitials()
        {
            if (FirstName == "")
                return;

            var initials = FirstName.Split(' ');
            for (int i = 0; i < initials.Length; i++)
            {
                if (!initials[i].Contains("."))
                {
                    if (initials[i].Contains('-'))
                    {
                        var inits = initials[i].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        inits[0] = inits[0].Substring(0, 1) + ".";
                        initials[i] = inits[0] + "-";

                        if (inits.Length > 1)
                        {
                            inits[1] = inits[1].Substring(0, 1) + ".";
                            initials[i] += inits[1];
                        }
                    }
                    else
                        initials[i] = initials[i].Substring(0, 1) + ".";
                }
                //initials[i] = initials[i].Replace("-", "");
            }

            FirstName = initials.Aggregate((x, y) => $"{x} {y}");
            int a = 0;
        }

        public string FirstNameFirst()
        {
            return $"{FirstName} {LastName}";
        }

        public string FirstNameLast()
        {
            return $"{LastName} {FirstName}";
        }
    }
}
