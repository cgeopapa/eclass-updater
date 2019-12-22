using System;
using eclass_updater.model;
using System.Windows.Forms;
using eclass_updater.dao;

namespace eclass_updater
{
    public partial class SignIn : Form
    {
        private User user;

        public SignIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = new User(unameTextBox.Text, passTextBox.Text);

            if (Program.browser.SignIn(ref user))
            {
                Program.browser.GetCourses(user);
                JsonDAO.SaveUser(user);
                JsonDAO.SaveCourses(user);

                Hide();
                MainApp m = new MainApp(user);
                m.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Ωχ!", "Λάθος όνομα χρήστη ή κωδικός", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
