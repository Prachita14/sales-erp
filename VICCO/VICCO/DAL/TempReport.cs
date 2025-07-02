using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


#region "AddtionalNamespces"

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace VICCO.DAL
{
    public class TempReport
    {
        #region "Variable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {          
            //if (SpOperation != string.Empty && SpOperation != null)
            //    Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            //else
            //    Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable GetReport()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("TEMP_REPORT", con);
                AddwithParameter(cmd);
                DataTable dtReport = new DataTable();
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                con.Open();
                sda.Fill(dtReport);
                return dtReport;
            }

        }

        #endregion
    }
}