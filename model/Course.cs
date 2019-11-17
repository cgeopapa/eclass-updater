using System;

namespace eclass_updater.model
{
    class Course
    {
        private bool update;
        private string name;
        private Uri url;
        private string path;

        public Course(bool update, string name, Uri url, string path)
        {
            this.update = update;
            this.name = name;
            this.url = url;
            this.path = path;
        }
    }
}
