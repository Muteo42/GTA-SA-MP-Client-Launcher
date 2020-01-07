using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTA_SA_MP_Launcher.Classes
{
    class Globals
    {
        public static string ServerIP = "127.0.0.1";
        public static string GTAKonum = Registry.CurrentUser.OpenSubKey(@"Software\\SAMP").GetValue("gta_sa_exe").ToString();
        public static string OyunKonum = GTAKonum = GTAKonum.Substring(0, GTAKonum.LastIndexOf(@"\") + 1);
    }
}
