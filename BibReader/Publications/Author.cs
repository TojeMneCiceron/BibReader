using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReader.Publications
{
    class Author
    {
        string LastName;
        string FirstName;

        public Author(string author)
        {
            if (author.Contains(","))
            {
                var a = author.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                LastName = a[0];
                FirstName = a[1];
            }
            else
            {
                var a = author.Split(new char[] { ' ' }, 1);
                FirstName = a[0];
                LastName = a[1];
            }

            ToInitials();
        }

        private void ToInitials()
        {

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
