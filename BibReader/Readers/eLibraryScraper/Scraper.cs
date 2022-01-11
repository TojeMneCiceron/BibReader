using System.IO;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace BibReader.Readers.ELibraryScraper
{
    class Scraper
    {
        public void readFile(string htmlFile, string bibFile)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.Load(htmlFile);

            HtmlNode table = htmlDocument.GetElementbyId("restab");
            getBibFile(table, bibFile);
        }

        private bool isConference(string documentName)
        {
            return Regex.Match(
                documentName, 
                @"(?i)(\W|^)(В сборнике|коференция|коференции|семинар|симпозиум|conference|conferenceon|symposium)(\W|$)"
            ).Success;
        }
        private bool isBook(string documentName)
        {
            return Regex.Match(documentName, @"(?i)(\W|^)В книге:(\W|$)").Success;
        }

        public string getDocumentType(string documentName)
        {
            string doc_type = "";
            if (isConference(documentName))
                doc_type = "conference";

            if (isBook(documentName) || doc_type == "")
                doc_type = "book";

            return doc_type;
        }

        public string parseAuthors(string authors)
        {
            string strAuthors = "";
            string[] arrayAuthors = authors.Split(',');

            foreach(string a in arrayAuthors)
            {
                strAuthors += a + " and ";
            }

            return strAuthors.Remove(strAuthors.Length - 4, 4);
        }


        public void getBibFile(HtmlNode table, string bibFile)
        {
            StreamWriter bibfile = new StreamWriter(bibFile, false, System.Text.Encoding.Default);

            HtmlNodeCollection rows_table = table.SelectNodes(table.XPath + "//tr");

            int number = 0;


            foreach (HtmlNode tr in rows_table)
            {
                if (number > 0)
                {
                    HtmlNodeCollection cells = tr.SelectNodes(tr.XPath + "//td");
                    if (cells.Count > 0)
                    {
                        string document_type = "", itemType = "", value = "", year = "", authors = "";
                        string pages = "", number_journal = "", journal = "", url = "", title = "";

                        HtmlNodeCollection tagsA = cells[1].SelectNodes(cells[1].XPath + "//a");

                        HtmlNode a;
                        if (tagsA.Count > 0)
                        {
                            a = tagsA[0];
                            url = a.Attributes["href"].Value.Trim();
                            title = a.InnerText.Trim();
                        }

                        if (tagsA.Count > 1)
                        {
                            a = tagsA[1];
                            journal = a.InnerText.Trim();
                        }
                        
                        if (tagsA.Count > 2)
                        {
                            if (Regex.Match(tagsA[2].InnerText, @"[0-9]*").Success)
                            {
                                itemType = "article";
                                document_type = "journal";
                                number_journal = Regex.Match(tagsA[2].InnerText, @"[0-9]{1,}").Value;
                            }
                        }

                        HtmlNodeCollection fonts = cells[1].SelectNodes(cells[1].XPath + "//font");

                        string[] partMetadate;

                        if (fonts.Count > 1)
                            partMetadate = Regex.Split(cells[1].SelectNodes(cells[1].XPath + "//font")[1].InnerText, ". ");
                        else partMetadate = Regex.Split(cells[1].SelectNodes(cells[1].XPath + "//font")[0].InnerText, ". ");

                        if (document_type == "")
                            {
                                if (partMetadate.Length > 0)
                                    document_type = getDocumentType(partMetadate[0]);

                                itemType = document_type;
                            }

                            if (fonts.Count > 0)
                                if (fonts.Count < 2)
                                    authors = "";
                                else authors = fonts[0].InnerText.Trim();

                        foreach (string part in partMetadate)
                        {

                            if (Regex.Match(part, @"T. *").Value != "")
                            {
                                char[] trim = { 'T', '.' };
                                value = Regex.Match(part, @"T. *").Value.Trim(trim);
                                continue;
                            }

                            MatchCollection resultYear = Regex.Matches(part, @"(\d{4})");
                            if (resultYear.Count > 0)
                            {
                                year = resultYear[0].Value;
                                continue;
                            }

                            MatchCollection resultPage = Regex.Matches(part, @"\d{1,}-\d{1,}");
                            if (resultPage.Count > 0)
                            {
                                pages = resultPage[0].Value;
                                continue;
                            }
                            else
                            {
                                char[] trim = { 'C', '.' };
                                pages = Regex.Match(part, @"C. *").Value.Trim(trim);
                                continue;
                            }
                        }
                        string source = "eLibrary";
                        bibfile.Write("@" + itemType + "{\n");
                        bibfile.Write("author={" + parseAuthors(authors) + "},\n");
                        bibfile.Write("title={" + title + "},\n");
                        bibfile.Write("journal={" + journal + "},\n");
                        bibfile.Write("year={" + year + "},\n");
                        bibfile.Write("value={" + value + "},\n");
                        bibfile.Write("pages={" + pages + "},\n");
                        bibfile.Write("doi={},\n");
                        bibfile.Write("number={" + number_journal + "},\n");
                        bibfile.Write("note={},\n");
                        bibfile.Write("url={" + url + "},\n");
                        bibfile.Write("affiliation={},\n");
                        bibfile.Write("keywords={},\n");
                        bibfile.Write("publisher={},\n");
                        bibfile.Write("abbrev_source_title={},\n");
                        bibfile.Write("document_type={" + document_type + "},\n");
                        bibfile.Write("source={"+ source + "},\n");
                        bibfile.Write("}\n\n");
                        bibfile.WriteLine();
                    }
                }
                else number++;
            }
           bibfile.Close();
        }
    }
}
