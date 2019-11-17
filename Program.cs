using eclass_updater.dao;
using eclass_updater.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eclass_updater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            User user = JsonDAO.Load();
            if(user == null)
            {
                Application.Run(new SignIn());
            }
            else
            {
                Application.Run(new MainApp(user));
            }
        }
    }
}
