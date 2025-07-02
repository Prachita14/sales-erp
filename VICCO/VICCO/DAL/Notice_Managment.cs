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
    public class Notice_Management
    {
        #region"Veriable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public int Notice_id { get; set; }
        public string Notice_text { get; set; }
        public string Plain_text { get; set; }
        public string Is_Stockist { get; set; }
        public string Is_Sales { get; set; }
        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {

            if (Notice_id > 0)
                Command.Parameters.Add(new SqlParameter("@NOTICE_ID", SqlDbType.Int)).Value = Notice_id;
            else
                Command.Parameters.Add(new SqlParameter("@NOTICE_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Notice_text != string.Empty && Notice_text != null)
                Command.Parameters.Add(new SqlParameter("@NOTICE_TEXT", SqlDbType.VarChar)).Value = Notice_text;
            else
                Command.Parameters.Add(new SqlParameter("@NOTICE_TEXT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Plain_text != string.Empty && Plain_text != null)
                Command.Parameters.Add(new SqlParameter("@PLAIN_TEXT", SqlDbType.VarChar)).Value = Plain_text;
            else
                Command.Parameters.Add(new SqlParameter("@PLAIN_TEXT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Is_Stockist != string.Empty && Is_Stockist != null)
                Command.Parameters.Add(new SqlParameter("@IS_STOCKIST", SqlDbType.VarChar)).Value = Is_Stockist;
            else
                Command.Parameters.Add(new SqlParameter("@IS_STOCKIST", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Is_Sales != string.Empty && Is_Sales != null)
                Command.Parameters.Add(new SqlParameter("@IS_SALES", SqlDbType.VarChar)).Value = Is_Sales;
            else
                Command.Parameters.Add(new SqlParameter("@IS_SALES", SqlDbType.VarChar)).Value = DBNull.Value;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveNotice()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("NOTICE_MANAGEMENT", con);
                AddwithParameter(cmd);
                DataTable dtReport = new DataTable();
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