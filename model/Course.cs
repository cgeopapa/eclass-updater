using System;
using System.IO;

namespace eclass_updater.model
{
    class Course
    {
        private bool update;
        private string name;
        private Uri url;
        private string path;

        public Course(string name, Uri url)
        {
            this.update = true;
            this.name = name;
            this.url = url;
            this.path = Directory.GetCurrentDirectory();
        }
    }
}
