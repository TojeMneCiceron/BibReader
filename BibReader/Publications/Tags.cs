using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibReader.Publications
{
    public class Tags
    {
        public static Dictionary<string, string> TagRework;
        public static Dictionary<string, string> TagValues;
        public static string[] VisibleTags;

        public static void NewTags()
        {
            TagRework = new Dictionary<string, string>
            {
                {"author", "authors"},
                {" author", "authors"},
                {"Author", "authors"},
                {"title", "title"},
                {" title", "title"},
                {"Title", "title"},
                {"booktitle", "journal"},
                {" booktitle", "journal"},
                {"Booktitle", "journal"},
                {"journal", "journal"},
                {" journal", "journal"},
                {"Journal", "journal"},
                {"year", "year"},
                {" year", "year"},
                {"Year", "year"},
                {"volume", "volume"},
                {" volume", "volume"},
                {"Volume", "volume"},
                {"pages", "pages"},
                {" pages", "pages"},
                {"Pages", "pages"},
                {"number", "number"},
                {" number", "number"},
                {"Number", "number"},
                {"doi", "doi"},
                {"DOI", "doi"},
                {"url", "url"},
                {"affiliation", "affiliation"},
                {"Affiliation", "affiliation"},
                {"abstract", "abstract"},
                {"Abstract", "abstract"},
                {"keywords", "keywords"},
                {"Keywords", "keywords"},
                {"author_keywords", "keywords"},
                {"publisher", "publisher"},
                {" publisher", "publisher"},
                {"Publisher", "publisher"},
                {"source", "source"},
                {"address", "address"},
                {"Address", "address"},
                {"inproceedings", "conference"},
                {"INPROCEEDINGS", "conference"},
                {"article", "journal"},
                {"ARTICLE", "journal"},
                {"conference", "conference"},
                {"incollection", "book"},
                {"book", "book"},
                {"inbook", "book"},
                {"chapter", "book"},
                {"referenceworkentry", "conference"},
                {"protocol", "conference"},
                {"bookseries", "book"},
                {"articleno", "articleNumber"},
                {"art_number", "articleNumber"},

                {"referencework", "conference"}
            };

            TagValues = new Dictionary<string, string>
            {
                { "authors", ""},
                { "title", ""},
                { "booktitle", ""},
                { "journal", ""},
                { "year", ""},
                { "volume", ""},
                { "pages", ""},
                { "doi", ""},
                { "url", ""},
                { "affiliation", ""},
                { "abstract", ""},
                { "keywords", ""},
                { "publisher", ""},
                { "source", ""},
                { "number", ""},
                { "originalTitle", ""},
                { "type", "" },
                { "address", "" },
                { "articleNumber", "" }
            };

            VisibleTags = new[] { "Authors",
            "Title",
            "Abstract",
            "Journal",
            "Year",
            "Volume",
            "Publisher",
            "Number",
            "ArticleNumber",
            "Pages",
            "Doi",
            "Url",
            "Affiliation",
            "Keywords",
            "Source"};
        }
    }
}
