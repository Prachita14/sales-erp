using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region "Additional Namespace"

using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using VICCO.DAL;
using System.IO;
using System.Drawing;
using System.Configuration;

#endregion

namespace VICCO.DAL
{
    public class PO_Format_Management
    {

        #region"Variable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;
        public DataTable DataSource;

        #endregion

        #region "Properties"

        public int ID { get; set; }
        public string INITIAL_KEYWORD { get; set; }
        public int STOCKIST_ID { get; set; }
        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (ID > 0)
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = ID;
            else
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = DBNull.Value;

            if (INITIAL_KEYWORD != string.Empty && INITIAL_KEYWORD != null)
                Command.Parameters.Add(new SqlParameter("@INITIAL_KEYWORD", SqlDbType.VarChar)).Value = INITIAL_KEYWORD;
            else
                Command.Parameters.Add(new SqlParameter("@INITIAL_KEYWORD", SqlDbType.VarChar)).Value = DBNull.Value;

            if (STOCKIST_ID > 0)
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = STOCKIST_ID;
            else
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = DBNull.Value;          

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable Getpoformat()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("PO_FORMAT_MANAGMENT", con);
                AddwithParameter(cmd);
                DataTable dtUser = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                con.Open();
                sda.Fill(dtUser);
                return dtUser;
            }
        }

        #endregion
    }
}