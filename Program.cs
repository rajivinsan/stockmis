using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Net;
using System.IO;

namespace GST
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
            Application.Run(new Module());
        }
    }
    class connection
    {
        public String connectionstring;
        public connection()
        {
            //connectionstring = "Provider=Microsoft.jet.Oledb.4.0; Data Source=dbson.mdb;persist security Info=false;jet OLEDB:Database Password=dbson";
            connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\db.mdb;persist security Info=false;jet OLEDB:Database Password=dbson";
        }

        private string SendSMS(String msg, String mob)
        {

            String html;
            string req = "http://www.smslane.com/vendorsms/pushsms.aspx?user=dealsmanoj&password=1986123&msisdn=" + mob + "&sid=WEBSMS&msg=" + msg + "&fl=0";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(req);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream data = response.GetResponseStream();
            using (StreamReader sr = new StreamReader(data))
            {
                html = sr.ReadToEnd();
            }
            response.Close();
            return html;
                        
        }
    }
}
