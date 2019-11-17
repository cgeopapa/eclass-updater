using eclass_updater.model;
using System.Windows.Forms;

namespace eclass_updater
{
    public partial class CourseForm : UserControl
    {
        private Course course;

        public CourseForm(Course course)
        {
            InitializeComponent();

            this.course = course;
            update.Checked = this.course.update;
            name.Text = this.course.Name;
            path.Text = this.course.path;
        }

        private void update_CheckedChanged(object sender, System.EventArgs e)
        {
            course.update = ((CheckBox)sender).Checked;
        }

        private void browseBut_Click(object sender, System.EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    course.path = fbd.SelectedPath;
                    path.Text = course.path;
                }
            }
        }
    }
}
