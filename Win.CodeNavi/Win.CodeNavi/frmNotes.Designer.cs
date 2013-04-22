/*
Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Ollie Whitehouse, ollie dot whitehouse at nccgroup dot com

http://www.github.com/nccgroup/ncccodenavi

Released under AGPL see LICENSE for more information
*/

namespace Win.CodeNavi
{
    partial class frmNotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNotes));
            this.SuspendLayout();
            // 
            // frmNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(347, 526);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNotes";
            this.Text = "Notes";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmNotes_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}