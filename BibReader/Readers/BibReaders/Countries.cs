using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BibReader.Readers.BibReaders
{
    public class Countries
    {
        public static Dictionary<string, string> countries = new Dictionary<string, string>();

        public static void ReadCountries()
        {
            StreamReader sr = new StreamReader("countries.txt");
            string country;
            while ((country = sr.ReadLine()) != null)
            {
                if (country == "" || !country.Contains("|"))
                    continue;
                var c = country.Split('|');
                if (!countries.ContainsKey(c[0]))
                    countries.Add(c[0], c[1]);
            }

            sr.Close();
        }

        public static string GetOriginalName(string country)
        {
            return countries.ContainsKey(country) ? countries[country] : country;
        }
    }
}
