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

namespace Win.CodeNavi
{
    class IsTextTester
    {
        /// http://stackoverflow.com/questions/910873/how-can-i-determine-if-a-file-is-binary-or-text-in-c
        /// <summary>
        /// Detect if a file is text and detect the encoding.
        /// </summary>
        /// <param name="encoding">
        /// The detected encoding.
        /// </param>
        /// <param name="fileName">
        /// The file name.
        /// </param>
        /// <param name="windowSize">
        /// The number of characters to use for testing.
        /// </param>
        /// <returns>
        /// true if the file is text.
        /// </returns>
        public static bool IsText(out Encoding encoding, string fileName, int windowSize)
        {
            using (var fileStream = File.OpenRead(fileName))
            {
                var rawData = new byte[windowSize];
                var text = new char[windowSize];
                var isText = true;

                // Read raw bytes
                var rawLength = fileStream.Read(rawData, 0, rawData.Length);
                fileStream.Seek(0, SeekOrigin.Begin);

                // Detect encoding correctly (from Rick Strahl's blog)
                // http://www.west-wind.com/weblog/posts/2007/Nov/28/Detecting-Text-Encoding-for-StreamReader
                if (rawData[0] == 0xef && rawData[1] == 0xbb && rawData[2] == 0xbf)
                {
                    encoding = Encoding.UTF8;
                }
                else if (rawData[0] == 0xfe && rawData[1] == 0xff)
                {
                    encoding = Encoding.Unicode;
                }
                else if (rawData[0] == 0 && rawData[1] == 0 && rawData[2] == 0xfe && rawData[3] == 0xff)
                {
                    encoding = Encoding.UTF32;
                }
                else if (rawData[0] == 0x2b && rawData[1] == 0x2f && rawData[2] == 0x76)
                {
                    encoding = Encoding.UTF7;
                }
                else
                {
                    encoding = Encoding.Default;
                }

                // Read text and detect the encoding
                using (var streamReader = new StreamReader(fileStream))
                {
                    streamReader.Read(text, 0, text.Length);
                }

                using (var memoryStream = new MemoryStream())
                {
                    using (var streamWriter = new StreamWriter(memoryStream, encoding))
                    {
                        // Write the text to a buffer
                        streamWriter.Write(text);
                        streamWriter.Flush();

                        // Get the buffer from the memory stream for comparision
                        var memoryBuffer = memoryStream.GetBuffer();

                        // Compare only bytes read
                        for (var i = 0; i < rawLength && isText; i++)
                        {
                            isText = rawData[i] == memoryBuffer[i];
                        }
                    }
                }

                return isText;
            }
        }
    }
}
