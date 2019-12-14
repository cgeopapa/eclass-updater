using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.IO.Compression;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace eclass_updater.model
{
    class Browser
    {
        private static readonly HttpClient client;

        private static readonly Uri url = new Uri(ConfigurationManager.AppSettings["url"]);

        static Browser()
        {
            var handler = new HttpClientHandler() { UseCookies = true};
            client = new HttpClient(handler) { BaseAddress = url };

            handler.CookieContainer.SetCookies(url, "Cookie");
        }

        public bool SignIn(ref User user)
        {
            var values = new Dictionary<string, string>
            {
                { "uname", user.userName},
                { "pass", user.password},
                {"submit", "" }
            };
            var content = new FormUrlEncodedContent(values);
            var response = client.PostAsync(url, content).Result.Content.ReadAsStringAsync().Result;

            if (response.Contains("Λάθος"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void GetCourses(User user)
        {
            List<Course> courses = new List<Course>();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(client.GetAsync(ConfigurationManager.AppSettings["all-courses"]).Result.Content.ReadAsStringAsync().Result);

            foreach(var t in doc.DocumentNode.SelectNodes(ConfigurationManager.AppSettings["xpath"]))
            {
                string name = t.InnerText;

                Uri uri = new Uri(t.ChildNodes[0].GetAttributeValue("href", "100"));
                string id = uri.Segments.Last();
                Uri courseUrl = new Uri(string.Format(ConfigurationManager.AppSettings["download"], id));

                courses.Add(new Course(name, courseUrl));
            }
            user.courses = courses.ToArray();
        }

        public void DownloadZip(Uri url, string path)
        {
            var result = client.GetAsync(url).Result.Content.ReadAsStreamAsync().Result;
            using (var zip = new ZipArchive(result))
            {
                foreach (var file in zip.Entries)
                {
                    if (file.Name.Equals(""))
                    {
                        continue;
                    }
                    string p = Path.Combine(path, file.FullName);
                    if (File.Exists(p) && File.GetLastWriteTime(p) != file.LastWriteTime)
                    {
                        //Create new name
                        string newName = p.Insert(p.LastIndexOf('.'), "_modified");

                        //Rename
                        File.Move(p, newName);
                    }
                    //Safely extract
                    file.ExtractToFile(p, true);
                }
            }
        }
    }
}
