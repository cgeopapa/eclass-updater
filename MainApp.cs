using eclass_updater.dao;
using eclass_updater.model;
using System.Windows.Forms;
using System;

namespace eclass_updater
{
    public partial class MainApp : Form
    {
        private User user;
        private bool shouldSave = true;

        public MainApp(User user)
        {
            InitializeComponent();

            this.user = user;
            uname.Text = this.user.userName;

            foreach(Course c in this.user.courses)
            {
                var f = new CourseForm(c);
                tablePanel.Controls.Add(f);
                f.Dock = DockStyle.Top;
            }
        }

        private void logout_Click(object sender, System.EventArgs e)
        {
            JsonDAO.Delete();
            shouldSave = false;

            Hide();
            SignIn s = new SignIn();
            s.ShowDialog();
            Close();
        }

        private void MainApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (shouldSave)
            {
                JsonDAO.Save(user);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            foreach(Course c in user.courses)
            {
                if(c.update)
                {
                    Program.browser.DownloadZip(c.Url, c.path);
                }
            }
        }
    }
}
