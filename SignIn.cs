using System;
using eclass_updater.model;
using System.Windows.Forms;

namespace eclass_updater
{
    public partial class SignIn : Form
    {
        private Browser browser = new Browser();
        private User user;

        public SignIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = new User(unameTextBox.Text, passTextBox.Text);

            if (browser.SignIn(user))
            {
                browser.GetCourses(user);
            }
            else
            {
                MessageBox.Show("Ωχ!", "Λάθος όνομα χρήστη ή κωδικός", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
