using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ImperialPlastics
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MDIFORM());
        }
    }
    class connection
    {
        public String connectionstring;
        public connection()
        {
            connectionstring = "Provider=Microsoft.jet.Oledb.4.0; Data Source=dbson.mdb;persist security Info=false;jet OLEDB:Database Password=dbson";
        }
    }
}
