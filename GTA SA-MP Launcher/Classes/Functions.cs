using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GTA_SA_MP_Launcher.Classes
{
    class Functions
    {
        public static void KonumGuncelle()
        {
            Globals.GTAKonum = Registry.CurrentUser.OpenSubKey(@"Software\\SAMP").GetValue("gta_sa_exe").ToString();
            Globals.OyunKonum = Globals.GTAKonum = Globals.GTAKonum.Substring(0, Globals.GTAKonum.LastIndexOf(@"\") + 1);
        }
    }
}
