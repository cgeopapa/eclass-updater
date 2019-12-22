using eclass_updater.model;
using Newtonsoft.Json;
using System.IO;
using CredentialManagement;
using System.Configuration;
using System;

namespace eclass_updater.dao
{
    class JsonDAO
    {
        private static readonly string path = Directory.GetCurrentDirectory() + @"\data.json";

        public static void SaveUser(User user)
        {
            Credential credential = new Credential();
            credential.Username = user.userName;
            credential.Password = user.password;
            credential.Type = CredentialType.Generic;
            credential.PersistanceType = PersistanceType.LocalComputer;
            credential.Target = ConfigurationManager.AppSettings["password-name"];
            credential.Save();
        }

        public static void SaveCourses(User user)
        {
            string json = JsonConvert.SerializeObject(user.courses);
            File.WriteAllText(path, json);
        }

        public static User Load()
        {
            Credential credential = new Credential();
            credential.Target = ConfigurationManager.AppSettings["password-name"];
            credential.Load();

            if (credential.Username == null) return null;
            
            Course[] courses = JsonConvert.DeserializeObject<Course[]>(File.ReadAllText(path));
            User user = new User(credential.Username, credential.Password);
            user.courses = courses;
            return user;
        }

        public static void Delete()
        {
            using(Credential credential = new Credential())
            {
                credential.Target = ConfigurationManager.AppSettings["password-name"];
                credential.Delete();
            }
            File.Delete(path);
        }
    }
}
