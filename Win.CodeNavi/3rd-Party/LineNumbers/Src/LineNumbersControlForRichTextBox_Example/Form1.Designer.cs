namespace LineNumbersControlForRichTextBox_Example
{
	partial class Form1
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
			if(disposing && (components != null))
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
            this.lineNumbersForRichText1 = new LineNumbersControlForRichTextBox.LineNumbersForRichText();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lineNumbersForRichText1
            // 
            this.lineNumbersForRichText1.AutoSizing = true;
            this.lineNumbersForRichText1.BackgroundGradientAlphaColor = System.Drawing.Color.Transparent;
            this.lineNumbersForRichText1.BackgroundGradientBetaColor = System.Drawing.Color.LightSteelBlue;
            this.lineNumbersForRichText1.BackgroundGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lineNumbersForRichText1.BorderLinesColor = System.Drawing.Color.SlateGray;
            this.lineNumbersForRichText1.BorderLinesStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineNumbersForRichText1.BorderLinesThickness = 1F;
            this.lineNumbersForRichText1.DockSide = LineNumbersControlForRichTextBox.LineNumbersForRichText.LineNumberDockSide.Left;
            this.lineNumbersForRichText1.GridLinesColor = System.Drawing.Color.SlateGray;
            this.lineNumbersForRichText1.GridLinesStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.lineNumbersForRichText1.GridLinesThickness = 1F;
            this.lineNumbersForRichText1.LineNumbersAlignment = System.Drawing.ContentAlignment.TopRight;
            this.lineNumbersForRichText1.LineNumbersAntiAlias = true;
            this.lineNumbersForRichText1.LineNumbersAsHexadecimal = false;
            this.lineNumbersForRichText1.LineNumbersClippedByItemRectangle = true;
            this.lineNumbersForRichText1.LineNumbersLeadingZeroes = true;
            this.lineNumbersForRichText1.LineNumbersOffset = new System.Drawing.Size(0, 0);
            this.lineNumbersForRichText1.Location = new System.Drawing.Point(40, 28);
            this.lineNumbersForRichText1.Margin = new System.Windows.Forms.Padding(0);
            this.lineNumbersForRichText1.MarginLinesColor = System.Drawing.Color.SlateGray;
            this.lineNumbersForRichText1.MarginLinesSide = LineNumbersControlForRichTextBox.LineNumbersForRichText.LineNumberDockSide.Right;
            this.lineNumbersForRichText1.MarginLinesStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lineNumbersForRichText1.MarginLinesThickness = 1F;
            this.lineNumbersForRichText1.Name = "lineNumbersForRichText1";
            this.lineNumbersForRichText1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lineNumbersForRichText1.ParentRichTextBox = this.richTextBox1;
            this.lineNumbersForRichText1.SeeThroughMode = false;
            this.lineNumbersForRichText1.ShowBackgroundGradient = true;
            this.lineNumbersForRichText1.ShowBorderLines = true;
            this.lineNumbersForRichText1.ShowGridLines = true;
            this.lineNumbersForRichText1.ShowLineNumbers = true;
            this.lineNumbersForRichText1.ShowMarginLines = true;
            this.lineNumbersForRichText1.Size = new System.Drawing.Size(20, 210);
            this.lineNumbersForRichText1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(61, 28);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(458, 210);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 273);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lineNumbersForRichText1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

		}

		#endregion

		private LineNumbersControlForRichTextBox.LineNumbersForRichText lineNumbersForRichText1;
        private System.Windows.Forms.RichTextBox richTextBox1;
	}
}

