using eclass_updater.model;
using Newtonsoft.Json;
using System.IO;

namespace eclass_updater.dao
{
    class JsonDAO
    {
        private static readonly string path = Directory.GetCurrentDirectory() + "data.json";

        public static void Save(User user)
        {
            string json = JsonConvert.SerializeObject(user);
            File.WriteAllText(path, json);
        }

        public static User Load()
        {
            if (File.Exists(path))
            {
                User user = (User)JsonConvert.DeserializeObject(File.ReadAllText(path));
                return user;
            }
            return null;
        }
    }
}
