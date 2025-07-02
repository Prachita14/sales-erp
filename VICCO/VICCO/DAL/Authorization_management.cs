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
    public class Authorization_management
    {
        #region"Veriable"

       // SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region "Properties"

        public int POSITION_ID { get; set; }
        public string POSITION { get; set; }
        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (POSITION_ID > 0)
                Command.Parameters.Add(new SqlParameter("@POSITION_ID", SqlDbType.Int)).Value = POSITION_ID;
            else
                Command.Parameters.Add(new SqlParameter("@POSITION_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (POSITION != string.Empty && POSITION != null)
                Command.Parameters.Add(new SqlParameter("@POSITION", SqlDbType.VarChar)).Value = POSITION;
            else
                Command.Parameters.Add(new SqlParameter("@POSITION", SqlDbType.VarChar)).Value = DBNull.Value;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = DBNull.Value;           
        }
        public DataTable SaveAuthorization()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("AUTHORIZATION_MANAGEMENT", con);
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