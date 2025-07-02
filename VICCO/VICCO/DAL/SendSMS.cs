using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace VICCO.DAL
{
    public class SendSMS
    {
        public Boolean SMSsent(string mobno, string msg)
        {
            string url;
            WebClient client;
            try
            {
                client = new WebClient();
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                url = "http://site.bulksmsnagpur.net/sendsms?uname=viccol&pwd=viccol&senderid=viccol&to=" + mobno + "&msg=" + msg + "&route=T";
                string baseurl = url;
                Stream data = client.OpenRead(baseurl);
                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();
                data.Close();
                reader.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}