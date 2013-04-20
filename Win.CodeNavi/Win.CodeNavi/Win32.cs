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
using System.Runtime.InteropServices;

namespace Win.CodeNavi
{
    class Win32
    {
        // offset of window style value
        public const int GWL_STYLE = -16;

        // window style constants for scrollbars
        public const int WS_VSCROLL = 0x00200000;
        public const int WS_HSCROLL = 0x00100000;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    }
}
