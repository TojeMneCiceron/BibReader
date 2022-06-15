using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using BibReader.Publications;

namespace BibReader.BibReference
{
    class BibRefClient
    {
        //формирование запроса для получения списка стилей
        public static List<string> GetStyles()
        {
            string url = BibRefClientConfig.Default.stylesLink;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            List<string> styles;
            try
            {
                var webResponse = request.GetResponse();
                var webStream = webResponse.GetResponseStream();

                var reader = new StreamReader(webStream);
                var data = reader.ReadToEnd();

                var o = (JArray)JObject.Parse(data)["styles"];
                styles = o.ToObject<IList<string>>().ToList();
            }
            catch (Exception e)
            {
                styles = null;
            }

            return styles;
        }

        //формирование запроса для получения библиографических описаний
        public static List<string> GetCitations(List<LibItem> items, string style)
        {
            string url = BibRefClientConfig.Default.citationsLink;

            var request = (HttpWebRequest)WebRequest.Create(url + style);
            request.Method = "POST";
            request.ContentType = "application/json";

            for (int i = 0; i < items.Count; i++)
            {
                items[i].Id = i + 1;
            }

            string body = items.Select(item => item.BibTexForRef()).Aggregate((x, y) => $"{x}{y}");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(body);
            }

            List<string> citations;
            try
            {
                var webResponse = request.GetResponse();
                var webStream = webResponse.GetResponseStream();

                var reader = new StreamReader(webStream);
                var data = reader.ReadToEnd();

                var o = JObject.Parse(data)["citations"];

                citations = o.ToString().Split('\n').ToList();
            }
            catch (Exception e)
            {
                citations = null;
            }

            return citations;
        }
    }
}
