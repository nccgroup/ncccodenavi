using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LineNumbersControlForRichTextBox_Example
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			richTextBox1.Rtf =
				@"{\rtf1\fbidis\ansi\ansicpg1251\deff0\deflang1049{\fonttbl{\f0\fnil\fcharset0 Microsoft Sans Serif;}{\f1\fswiss\fprq2\fcharset204 Calibri;}{\f2\fnil\fcharset204 Microsoft Sans Serif;}}
{\colortbl ;\red0\green255\blue0;\red255\green0\blue0;}
\viewkind4\uc1\pard\ltrpar\lang1033\f0\fs17 asdasdasd ashdhasd\par
ashdhas ahsdasd\par
ajsdjasndk asjkdnkjasnd jaksdnkjasn\par
\par
\pard\ltrpar\sa200\sl276\slmult1\f1\fs36 Fddfhf\highlight1 dgh\i f\highlight0 d\i0 sg dfgfddf\fs22  \b dfg\cf2 dfg\cf0 df\b0  d gdfg d\par
Fdsfsdfsdf\par
Sfdfsdf sdfds sdfgsdf sfdfsdfsdf\par
\par
\fs36 Fddfhf\highlight1 dgh\i f\highlight0 d\i0 sg dfgfddf\fs22  \b dfg\cf2 dfg\cf0 df\b0  d gdfg d\par
Fdsfsdfsdf\par
Sfdfsdf sdfds sdfgsdf sfdfsdfsdf\par
\par
\pard\ltrpar\f0\fs17 sdfesf sdijfjhsdf sdhfbjsdbfj sdjfjsdf\lang1049\f2\par
}
";
		}
	}
}
