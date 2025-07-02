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
    public class Office_Report_Management
    {
        #region"Variable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public int Material_id { get; set; }
        public DateTime from_date { get; set; }
        public DateTime To_date { get; set; }
        public string MATERIAL_GROUP { get; set; }
        public string REGION { get; set; }
        public string MONTH { get; set; }
        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Material_id > 0)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = Material_id;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = DBNull.Value;
           
            if (from_date != null && from_date != DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@FROM_DATE", SqlDbType.DateTime)).Value = from_date;
            else
                Command.Parameters.Add(new SqlParameter("@FROM_DATE", SqlDbType.DateTime)).Value = DBNull.Value;

            if (To_date != null && To_date != DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.DateTime)).Value = To_date;
            else
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.DateTime)).Value = DBNull.Value;

            if (MATERIAL_GROUP != string.Empty && MATERIAL_GROUP != null)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_GROUP", SqlDbType.VarChar)).Value = MATERIAL_GROUP;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_GROUP", SqlDbType.VarChar)).Value = DBNull.Value;

            if (REGION != string.Empty && REGION != null)
                Command.Parameters.Add(new SqlParameter("@REGION", SqlDbType.VarChar)).Value = REGION;
            else
                Command.Parameters.Add(new SqlParameter("@REGION", SqlDbType.VarChar)).Value = DBNull.Value;

            if (MONTH != string.Empty && MONTH != null)
                Command.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.VarChar)).Value = MONTH;
            else
                Command.Parameters.Add(new SqlParameter("@MONTH", SqlDbType.VarChar)).Value = DBNull.Value;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable GetReport()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("OFFICE_REPORT", con);
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