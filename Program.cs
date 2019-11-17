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
        public static Browser browser = new Browser();

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
                browser.SignIn(ref user);
                Application.Run(new MainApp(user));
            }
        }
    }
}
