using System;
using System.Collections.Generic;
using System.IO;

namespace eclass_updater.model
{
    public class Course
    {
        public bool update;
        private string name;
        private Uri url;
        public string path;

        public Course(string name, Uri url)
        {
            this.update = true;
            this.name = name;
            this.url = url;
            this.path = Directory.GetCurrentDirectory();
        }

        public string Name { get => name; }
        public Uri Url { get => url; }
    }
}
