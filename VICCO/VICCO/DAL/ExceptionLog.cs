using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace VICCO.DAL
{
    public class ExceptionLog
    {
        public static void WriteErrorLog(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                if (!Directory.Exists(@"C:\\VICCO_SP"))
                {
                    Directory.CreateDirectory(@"C:\\VICCO_SP");
                }

                sw = new StreamWriter(@"C:\\VICCO_SP\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ": " + ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim());
                sw.WriteLine(ex.GetType().FullName);
                sw.WriteLine("Message : " + ex.Message);
                sw.WriteLine("StackTrace : " + ex.StackTrace);
                sw.WriteLine("------------------------------------------------------------");
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex1)
            {
                throw ex1;
            }
        }
        public static void WriteMessageLog(string Message)
        {
            StreamWriter sw = null;
            try
            {
                if (!Directory.Exists("C:\\VICCO_WS"))
                {
                    Directory.CreateDirectory(@"C:\\VICCO_WS");
                }
                sw = new StreamWriter(@"C:\\VICCO_WS\\LogFile.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ": " + Message);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}