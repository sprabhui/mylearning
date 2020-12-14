
namespace MediaMerger
{
    partial class frmHome
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lstDir = new System.Windows.Forms.ListBox();
            this.btnLoadDir = new System.Windows.Forms.Button();
            this.proBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lstDir
            // 
            this.lstDir.FormattingEnabled = true;
            this.lstDir.ItemHeight = 20;
            this.lstDir.Location = new System.Drawing.Point(8, 67);
            this.lstDir.Name = "lstDir";
            this.lstDir.Size = new System.Drawing.Size(620, 304);
            this.lstDir.TabIndex = 0;
            // 
            // btnLoadDir
            // 
            this.btnLoadDir.Location = new System.Drawing.Point(8, 39);
            this.btnLoadDir.Name = "btnLoadDir";
            this.btnLoadDir.Size = new System.Drawing.Size(166, 29);
            this.btnLoadDir.TabIndex = 1;
            this.btnLoadDir.Text = "Load Directories";
            this.btnLoadDir.UseVisualStyleBackColor = true;
            this.btnLoadDir.Click += new System.EventHandler(this.btnLoadDir_Click);
            // 
            // proBar
            // 
            this.proBar.Location = new System.Drawing.Point(8, 378);
            this.proBar.Name = "proBar";
            this.proBar.Size = new System.Drawing.Size(620, 18);
            this.proBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.proBar.TabIndex = 2;
            this.proBar.UseWaitCursor = true;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 418);
            this.Controls.Add(this.proBar);
            this.Controls.Add(this.btnLoadDir);
            this.Controls.Add(this.lstDir);
            this.Name = "frmHome";
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox lstDir;
        private System.Windows.Forms.Button btnLoadDir;
        private System.Windows.Forms.ProgressBar proBar;
    }
}

