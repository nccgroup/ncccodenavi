/*
Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Ollie Whitehouse, ollie dot whitehouse at nccgroup dot com

http://www.github.com/nccgroup/ncccodenavi

Released under AGPL see LICENSE for more information
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Win.CodeNavi
{

    class CodeMarkUp
    {

        public StringCollection strExts = new StringCollection();
        public StringCollection strKeyWords = new StringCollection();
        public string strName = null;
        public string strCommentLine = null;
        public string strCommentStart = null;
        public string strCommentEnd = null;

        public CodeMarkUp(){

        }

    }

    public class SourceCodeMarkUp
    {
        private List<CodeMarkUp> codeMarkUps = new List<CodeMarkUp>();

        private const int WM_SETREDRAW      = 0x000B;
        private const int WM_PAINT          = 0x000F;
        public const int WM_NCPAINT        = 0x0085;
        private const int WM_USER           = 0x400;
        private const int EM_GETEVENTMASK   = (WM_USER + 59);
        private const int EM_SETEVENTMASK   = (WM_USER + 69);
 
        [DllImport("user32", CharSet = CharSet.Auto)]       
        public extern static IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
 
        public SourceCodeMarkUp(string AssemblyDirectory)
        {
            if (Directory.Exists(AssemblyDirectory + "\\Notepad++.Profiles"))
            {
                foreach (string strFile in Directory.GetFiles(AssemblyDirectory + "\\Notepad++.Profiles"))
                {
                    CodeMarkUp cmuTemp = null;

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(strFile);

                    XmlNodeList xmlLangs = xmlDoc.GetElementsByTagName("Languages");

                    foreach (XmlNode xmlLang in xmlLangs)
                    {
                        foreach (XmlNode xmlSubNode in xmlLang.ChildNodes)
                        {
                            if (xmlSubNode.Name.Equals("Language"))
                            {
                                cmuTemp = new CodeMarkUp();

                                foreach(XmlAttribute xmlAttrib in xmlSubNode.Attributes){

                                    // Name
                                    if(xmlAttrib.Name.Equals("name")) cmuTemp.strName = xmlAttrib.Value;

                                    // Extensions
                                    if(xmlAttrib.Name.Equals("ext")){
                                        string[] strExts = xmlAttrib.Value.Split(' ');
                                        foreach(string strExt in strExts){
                                            cmuTemp.strExts.Add(strExt);
                                        }
                                    }

                                    // Comments
                                    if (xmlAttrib.Name.Equals("commentLine")) cmuTemp.strCommentLine = xmlAttrib.Value;
                                    if (xmlAttrib.Name.Equals("commentStart")) cmuTemp.strCommentStart = xmlAttrib.Value;
                                    if (xmlAttrib.Name.Equals("commentEnd")) cmuTemp.strCommentEnd = xmlAttrib.Value;
                                }

                                // Now
                                foreach (XmlNode xmlSubSubNode in xmlSubNode.ChildNodes)
                                {

                                    if(xmlSubSubNode.Name.Equals("Keywords"))
                                    {
                                        string[] strKeyWords = xmlSubSubNode.InnerText.Split(' ');
                                        foreach (string strKeyWord in strKeyWords)
                                        {
                                            cmuTemp.strKeyWords.Add(strKeyWord);
                                            //Console.WriteLine(strKeyWord);
                                        }
                                    }
                                }

                                codeMarkUps.Add(cmuTemp);
                            }
                        }
                        
                    }
                }
            }
            else
            {
                
            }
        }

        public void HighlightWord(RichTextBox richText, string stString, LineNumbersControlForRichTextBox.LineNumbersForRichText lnRT)
        {
            Regex rex = new Regex(stString);
            MatchCollection mcCollection = rex.Matches(richText.Text);

            //
            // http://weblogs.asp.net/jdanforth/archive/2004/03/12/88458.aspx
            //
            IntPtr eventMask = IntPtr.Zero;
            IntPtr eventMaskLRT = IntPtr.Zero;

            int StartCursorPosition = richText.SelectionStart;
            int EndCursorPosition = richText.SelectionLength;

            try
            {
                // Stop redrawing:
                SendMessage(richText.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
                if (lnRT != null) SendMessage(lnRT.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
                // Stop sending of events:
                eventMask = SendMessage(richText.Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);
                if (lnRT != null) eventMaskLRT = SendMessage(lnRT.Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);

                foreach (Match mMatch in mcCollection)
                {
                    int startIndex = mMatch.Index;
                    int StopIndex = mMatch.Length;
                    richText.SelectionColor = Color.Red;
                    richText.SelectionBackColor = Color.Black;
                    richText.Select(startIndex, StopIndex);
                    richText.SelectionStart = StartCursorPosition;
                    richText.SelectionLength = 0;
                    richText.SelectionColor = Color.Black;
                    richText.SelectionBackColor = Color.White;
                }

            }
            finally
            {
                richText.SelectionStart = StartCursorPosition;
                richText.SelectionLength = EndCursorPosition;
                richText.ScrollToCaret();
                // turn on events
                SendMessage(richText.Handle, EM_SETEVENTMASK, 0, eventMask);
                if (lnRT != null) SendMessage(lnRT.Handle, EM_SETEVENTMASK, 0, eventMaskLRT);
                // turn on redrawing
                SendMessage(richText.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
                if (lnRT != null) SendMessage(lnRT.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
                SendMessage(richText.Handle, WM_NCPAINT, 0, IntPtr.Zero);
            }
        }

        public void MakeUpRichText(RichTextBox richText, string strExt, LineNumbersControlForRichTextBox.LineNumbersForRichText lnRT){


            foreach(CodeMarkUp cmuLookup in codeMarkUps){
            
                foreach (string strMExt in cmuLookup.strExts)
                {
                    if(strMExt.Equals(strExt)){
                        
                        richText.SelectionLength = 0;
                        richText.SelectionColor = Color.Black;

                        StringBuilder sbTemp = new StringBuilder();

                        sbTemp.Append("(");

                        bool bFirst = true;
                        foreach (string strKeyword in cmuLookup.strKeyWords)
                        {
                            if (bFirst)
                            {
                                sbTemp.Append(strKeyword+"\\s");
                                bFirst = false;
                            }
                            else sbTemp.Append("|" + strKeyword+"\\s");
                        }
                        sbTemp.Append(")");

                        Console.WriteLine(sbTemp.ToString());
                       
                        Regex rex = new Regex(sbTemp.ToString());
                        MatchCollection mcCollection = rex.Matches(richText.Text);

                        //
                        // http://weblogs.asp.net/jdanforth/archive/2004/03/12/88458.aspx
                        //
                        IntPtr eventMask = IntPtr.Zero;
                        IntPtr eventMaskLRT = IntPtr.Zero;
                        try
                        {
                            // Stop redrawing:
                            SendMessage(richText.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
                            if (lnRT != null) SendMessage(lnRT.Handle, WM_SETREDRAW, 0, IntPtr.Zero);
                            // Stop sending of events:
                            eventMask = SendMessage(richText.Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);
                            if (lnRT != null) eventMaskLRT = SendMessage(lnRT.Handle, EM_GETEVENTMASK, 0, IntPtr.Zero);

                            int StartCursorPosition = 0;

                            foreach (Match mMatch in mcCollection)
                            {
                                int startIndex = mMatch.Index;
                                int StopIndex = mMatch.Length;
                                richText.Select(startIndex, StopIndex);
                                richText.SelectionColor = Color.Blue;
                                richText.SelectionStart = StartCursorPosition;
                                richText.SelectionLength = 0;
                                richText.SelectionColor = Color.Black;
                            }

                        }
                        finally
                        {
                            // turn on events
                            SendMessage(richText.Handle, EM_SETEVENTMASK, 0, eventMask);
                            if (lnRT != null) SendMessage(lnRT.Handle, EM_SETEVENTMASK, 0, eventMaskLRT);
                            // turn on redrawing
                            SendMessage(richText.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
                            if (lnRT != null) SendMessage(lnRT.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
                            SendMessage(richText.Handle, WM_NCPAINT, 0, IntPtr.Zero);
                        }

                    }
                }
            }
        }
          
    }
}
