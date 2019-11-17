using System;
using System.Collections.Generic;
using System.Net.Http;
using HtmlAgilityPack;
using System.Linq;

namespace eclass_updater.model
{
    class Browser
    {
        private static readonly HttpClient client;

        private static readonly Uri url = new Uri(@"https://eclass.aueb.gr/");

        static Browser()
        {
            var handler = new HttpClientHandler() { UseCookies = true};
            client = new HttpClient(handler) { BaseAddress = url };

            handler.CookieContainer.SetCookies(url, "Cookie");
        }

        public bool SignIn(User user)
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
            doc.LoadHtml(client.GetAsync("https://eclass.aueb.gr/main/my_courses.php").Result.Content.ReadAsStringAsync().Result);

            foreach(var t in doc.DocumentNode.SelectNodes(@"/html/body/div[2]/div[1]/div[3]/div/div/div[4]/table/tbody/tr/td[1]/strong"))
            {
                string name = t.InnerText;

                Uri uri = new Uri(t.ChildNodes[0].GetAttributeValue("href", "100"));
                string id = uri.Segments.Last();
                Uri courseUrl = new Uri(string.Format("https://eclass.aueb.gr/modules/document/index.php?course={0}&download=/", id));

                courses.Add(new Course(true, name, courseUrl, System.IO.Directory.GetCurrentDirectory()));
            }
            user.courses = courses.ToArray();
        }
    }
}
