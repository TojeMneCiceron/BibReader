using BibReader.Publications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReader.Corpuses
{
    class Relevance
    {
        List<LibItem> RelevanceItems = new List<LibItem>(); 

        public Relevance(List<LibItem> libItems)
        {
            RelevanceItems = libItems.ToList();
        }

        public List<LibItem> GetRelevance()
        {
            var items = new List<LibItem>();

            foreach (var item in RelevanceItems)
            {
                var pages = item.Pages;
                var authors = item.Authors;

                if (IsRelevance(pages, authors))
                    items.Add(item);
            }
            return items;
        }

        private static bool IsRelevance(string pages, string authors) => IsRelevancePages(pages) && authors != "";

        private static bool IsRelevancePages(string pages)
        {
            if (pages == "" || pages == string.Empty)
                return false;

            var pagesClone = "";
            for (int j = 0; j < pages.Length; j++)
                if (!char.IsLetter(pages[j]))
                    pagesClone += pages[j];
            pages = pagesClone;

            string pageBegin = "", pageEnd = "";
            int i = 0;
            while (i < pages.Length && char.IsDigit(pages[i]))
            {
                pageBegin += pages[i]; i++;
            }
            while (i < pages.Length && !char.IsDigit(pages[i]))
                i++;
            while (i < pages.Length)
            { 
                pageEnd += pages[i]; 
                i++; 
            }

            Int32.TryParse(pageBegin, out int intPageBegin);
            Int32.TryParse(pageEnd, out int intPageEnd);

            return intPageEnd - intPageBegin > 3 ? true : false;
        }
    }
}
