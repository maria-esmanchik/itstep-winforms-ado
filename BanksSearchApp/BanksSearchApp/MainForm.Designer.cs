namespace BanksSearchApp
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.MaxCourseValue = new System.Windows.Forms.RadioButton();
            this.MinCourseValue = new System.Windows.Forms.RadioButton();
            this.ShowAllCourses = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ShowAllCourses);
            this.splitContainer1.Panel1.Controls.Add(this.MinCourseValue);
            this.splitContainer1.Panel1.Controls.Add(this.MaxCourseValue);
            this.splitContainer1.Size = new System.Drawing.Size(1240, 721);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.TabIndex = 0;
            // 
            // MaxCourseValue
            // 
            this.MaxCourseValue.AutoSize = true;
            this.MaxCourseValue.Location = new System.Drawing.Point(13, 56);
            this.MaxCourseValue.Name = "MaxCourseValue";
            this.MaxCourseValue.Size = new System.Drawing.Size(139, 21);
            this.MaxCourseValue.TabIndex = 0;
            this.MaxCourseValue.Text = "Max course value";
            this.MaxCourseValue.UseVisualStyleBackColor = true;
            this.MaxCourseValue.CheckedChanged += new System.EventHandler(this.MaxCourseValue_CheckedChanged);
            // 
            // MinCourseValue
            // 
            this.MinCourseValue.AutoSize = true;
            this.MinCourseValue.Location = new System.Drawing.Point(13, 84);
            this.MinCourseValue.Name = "MinCourseValue";
            this.MinCourseValue.Size = new System.Drawing.Size(136, 21);
            this.MinCourseValue.TabIndex = 1;
            this.MinCourseValue.Text = "Min course value";
            this.MinCourseValue.UseVisualStyleBackColor = true;
            this.MinCourseValue.CheckedChanged += new System.EventHandler(this.MinCourseValue_CheckedChanged);
            // 
            // ShowAllCourses
            // 
            this.ShowAllCourses.AutoSize = true;
            this.ShowAllCourses.Location = new System.Drawing.Point(13, 112);
            this.ShowAllCourses.Name = "ShowAllCourses";
            this.ShowAllCourses.Size = new System.Drawing.Size(135, 21);
            this.ShowAllCourses.TabIndex = 2;
            this.ShowAllCourses.TabStop = true;
            this.ShowAllCourses.Text = "Show all courses";
            this.ShowAllCourses.UseVisualStyleBackColor = true;
            this.ShowAllCourses.CheckedChanged += new System.EventHandler(this.ShowAllCourses_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 721);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BanksSearch";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton MaxCourseValue;
        private System.Windows.Forms.RadioButton MinCourseValue;
        private System.Windows.Forms.RadioButton ShowAllCourses;
    }
}

