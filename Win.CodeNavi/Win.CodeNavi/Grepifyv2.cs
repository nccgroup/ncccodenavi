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
using System.Xml;
using System.IO;

namespace Win.CodeNavi
{

    /// <summary>
    /// Class for each check
    /// </summary>
    class Grepifyv2Check
    {
        public string strName = null;
        public string strDescription = null;
        public string strRegex = null;
        
        public Grepifyv2Check(){

        }
    }

    /// <summary>
    /// Class for each file
    /// </summary>
    class Grepifyv2File 
    {
        public string strExts = null;
        List<Grepifyv2Check> myChecks = new List<Grepifyv2Check>();

        // Constructor
        public Grepifyv2File(String strFile) 
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strFile);
            XmlNodeList xmlExts = xmlDoc.GetElementsByTagName("Extensions");
            if (xmlExts.Count == 1)
            {
                strExts = xmlExts[0].InnerText;
            }
            else
            {
                return;
            }
            

            XmlNodeList xmlChecks = xmlDoc.GetElementsByTagName("Check");

            foreach(XmlNode xmlNode in xmlChecks){
                Grepifyv2Check myCheck = new Grepifyv2Check();

                foreach (XmlNode xmlSubNode in xmlNode.ChildNodes)
                {

                    if(xmlSubNode.Name.Equals("Regex")){
                        myCheck.strRegex = xmlSubNode.InnerText;
                    }

                    if(xmlSubNode.Name.Equals("Friendly")){
                        myCheck.strName = xmlSubNode.InnerText;
                    }

                    if(xmlSubNode.Name.Equals("Description")){
                        myCheck.strDescription = xmlSubNode.InnerText;
                    }

                }

                // We need them all
                if (myCheck.strRegex != null && myCheck.strName != null && myCheck.strDescription != null)
                {
                    myChecks.Add(myCheck);
                }
            }
        }

    }

    /// <summary>
    /// The main class
    /// </summary>
    class Grepifyv2
    {
        public List<Grepifyv2File> myFiles = new List<Grepifyv2File>();

        // Constructor
        public Grepifyv2(String strDirectory)
        {
            Console.WriteLine("Grepify v2");

            foreach (String fileXML in Directory.GetFiles(strDirectory,"*.grepifyv2"))
            {
                try
                {
                    Grepifyv2File grepv2File = new Grepifyv2File(fileXML);
                    myFiles.Add(grepv2File);
                }
                catch (Exception)
                {

                }
            }
        }

    }
}
