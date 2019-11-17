namespace eclass_updater
{
    partial class CourseForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.update = new System.Windows.Forms.CheckBox();
            this.path = new System.Windows.Forms.Label();
            this.browseBut = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // update
            // 
            this.update.AutoSize = true;
            this.update.Location = new System.Drawing.Point(4, 9);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(15, 14);
            this.update.TabIndex = 0;
            this.update.UseVisualStyleBackColor = true;
            this.update.CheckedChanged += new System.EventHandler(this.update_CheckedChanged);
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Location = new System.Drawing.Point(451, 10);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(148, 13);
            this.path.TabIndex = 2;
            this.path.Text = "F:/Path/To/Download/Folder";
            // 
            // browseBut
            // 
            this.browseBut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseBut.Location = new System.Drawing.Point(721, 4);
            this.browseBut.Name = "browseBut";
            this.browseBut.Size = new System.Drawing.Size(28, 23);
            this.browseBut.TabIndex = 3;
            this.browseBut.Text = "...";
            this.browseBut.UseVisualStyleBackColor = true;
            this.browseBut.Click += new System.EventHandler(this.browseBut_Click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(25, 6);
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Size = new System.Drawing.Size(420, 20);
            this.name.TabIndex = 4;
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.name);
            this.Controls.Add(this.browseBut);
            this.Controls.Add(this.path);
            this.Controls.Add(this.update);
            this.MinimumSize = new System.Drawing.Size(425, 0);
            this.Name = "CourseForm";
            this.Size = new System.Drawing.Size(752, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox update;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.Button browseBut;
        private System.Windows.Forms.TextBox name;
    }
}
