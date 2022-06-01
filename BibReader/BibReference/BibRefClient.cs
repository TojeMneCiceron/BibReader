using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Windows.Forms;
using Json.Net;
using Newtonsoft.Json.Linq;
using BibReader.Publications;

namespace BibReader.BibReference
{
    class BibRefClient
    {
        //static string url = $"http://{BibRefClientConfig.Default.stylesLink}:{BibRefClientConfig.Default.citationsLink}";

        public static List<string> GetStyles()
        {
            //List<string> styles = new List<string>();
            string url = BibRefClientConfig.Default.stylesLink;

            var request = WebRequest.Create(url);
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
            //MessageBox.Show(a.Count.ToString());


            return styles;
        }

        public static List<string> GetCitations(List<LibItem> items, string style)
        {
            string url = BibRefClientConfig.Default.citationsLink;

            var request = WebRequest.Create(url + style);
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
                //MessageBox.Show(o.ToString());

                citations = o.ToString().Split('\n').ToList();

                //foreach (var s in citations)
                //    MessageBox.Show(s);
            }
            catch (Exception e)
            {
                citations = null;
            }
            //MessageBox.Show(a.Count.ToString());


            return citations;
        }
    }
}
