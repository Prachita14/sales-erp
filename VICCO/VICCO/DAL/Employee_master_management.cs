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
    public class Employee_master_management
    {
        #region"Variable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region "Properties"

        public int EMP_ID { get; set; }
        public int Parent_id { get; set; }
        public string EMP_CODE { get; set; }
        public string EMP_NAME { get; set; }
        public int DESIGNATION_ID { get; set; }
        public string EMP_EMAIL { get; set; }
        public string EMP_PASSWORD { get; set; }
        public DateTime Joining_Date { get; set; }
        public DateTime Deactive_date { get; set; }
        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (EMP_ID > 0)
                Command.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int)).Value = EMP_ID;
            else
                Command.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Parent_id > 0)
                Command.Parameters.Add(new SqlParameter("@PARENT_ID", SqlDbType.Int)).Value = Parent_id;
            else
                Command.Parameters.Add(new SqlParameter("@PARENT_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (EMP_CODE != string.Empty && EMP_CODE != null)
                Command.Parameters.Add(new SqlParameter("@EMP_CODE", SqlDbType.VarChar)).Value = EMP_CODE;
            else
                Command.Parameters.Add(new SqlParameter("@EMP_CODE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (EMP_NAME != string.Empty && EMP_NAME != null)
                Command.Parameters.Add(new SqlParameter("@EMP_NAME", SqlDbType.VarChar)).Value = EMP_NAME;
            else
                Command.Parameters.Add(new SqlParameter("@EMP_NAME", SqlDbType.VarChar)).Value = DBNull.Value;

            if (DESIGNATION_ID > 0)
                Command.Parameters.Add(new SqlParameter("@DESIGNATION_ID", SqlDbType.Int)).Value = DESIGNATION_ID;
            else
                Command.Parameters.Add(new SqlParameter("@DESIGNATION_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (EMP_EMAIL != string.Empty && EMP_EMAIL != null)
                Command.Parameters.Add(new SqlParameter("@EMP_EMAIL", SqlDbType.VarChar)).Value = EMP_EMAIL;
            else
                Command.Parameters.Add(new SqlParameter("@EMP_EMAIL", SqlDbType.VarChar)).Value = DBNull.Value;

            if (EMP_PASSWORD != string.Empty && EMP_PASSWORD != null)
                Command.Parameters.Add(new SqlParameter("@EMP_PASSWORD", SqlDbType.VarChar)).Value = EMP_PASSWORD;
            else
                Command.Parameters.Add(new SqlParameter("@EMP_PASSWORD", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Joining_Date != DateTime.MinValue && Joining_Date != null)
                Command.Parameters.Add(new SqlParameter("@JOINING_DATE", SqlDbType.Date)).Value = Joining_Date;
            else
                Command.Parameters.Add(new SqlParameter("@JOINING_DATE", SqlDbType.Date)).Value = DBNull.Value;

            if (Deactive_date != DateTime.MinValue && Deactive_date != null)
                Command.Parameters.Add(new SqlParameter("@DEACTIVE_DATE", SqlDbType.Date)).Value = Deactive_date;
            else
                Command.Parameters.Add(new SqlParameter("@DEACTIVE_DATE", SqlDbType.Date)).Value = DBNull.Value;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveEmployee()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("EMPLOYEE_MASTER_MANAGEMENT", con);
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