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
    public class DashboardManagement
    {
        #region"Variable"

       // SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        public int PAGE { get; set; }
        public string SP_OPERATION { get; set; }
        public DataTable dt1 { get; set; }
        public void AddwithParameter(SqlCommand Command)
        {
            if (PAGE > 0)
                Command.Parameters.Add(new SqlParameter("@PAGE", SqlDbType.Int)).Value = PAGE;
            else
                Command.Parameters.Add(new SqlParameter("@PAGE", SqlDbType.Int)).Value = 0;

            if (SP_OPERATION != string.Empty && SP_OPERATION != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SP_OPERATION;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }
        public DataTable Getdata()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("DASHBOARD_DATA", con);
                AddwithParameter(cmd);
                DataTable dtReport = new DataTable();               
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                con.Open();
                sda.Fill(dtReport);
                return dtReport;
            }
        }

    }
}