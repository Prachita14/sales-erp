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
    public class Employee_Report_Managment
    {
        #region"Variable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public int Employee_id { get; set; }
        public String Region { get; set; }
        public int stockist_id { get; set; }
        public int Distributor_id { get; set; }
        public int Material_id { get; set; }
        public string Material_ids { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Sales_officer { get; set; }
        public DateTime from_date { get; set; }
        public DateTime To_date { get; set; }
        public int PageNo { get; set; }
        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Employee_id > 0)
                Command.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", SqlDbType.Int)).Value = Employee_id;
            else
                Command.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Region != String.Empty && Region != null)
                Command.Parameters.Add(new SqlParameter("@REGION", SqlDbType.VarChar)).Value = Region;
            else
                Command.Parameters.Add(new SqlParameter("@REGION", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Material_id > 0)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = Material_id;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Material_ids != string.Empty && Material_ids != null)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_IDS", SqlDbType.VarChar)).Value = Material_ids;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_IDS", SqlDbType.VarChar)).Value = DBNull.Value;

            if (stockist_id > 0)
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = stockist_id;
            else
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Distributor_id > 0)
                Command.Parameters.Add(new SqlParameter("@DISTRIBUTOR_ID", SqlDbType.Int)).Value = Distributor_id;
            else
                Command.Parameters.Add(new SqlParameter("@DISTRIBUTOR_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (District != string.Empty && District != null)
                Command.Parameters.Add(new SqlParameter("@DISTRICT", SqlDbType.VarChar)).Value = District;
            else
                Command.Parameters.Add(new SqlParameter("@DISTRICT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (City != string.Empty && City != null)
                Command.Parameters.Add(new SqlParameter("@CITY", SqlDbType.VarChar)).Value = City;
            else
                Command.Parameters.Add(new SqlParameter("@CITY", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Sales_officer != string.Empty && Sales_officer != null)
                Command.Parameters.Add(new SqlParameter("@SALES_OFFICER", SqlDbType.VarChar)).Value = Sales_officer;
            else
                Command.Parameters.Add(new SqlParameter("@SALES_OFFICER", SqlDbType.VarChar)).Value = DBNull.Value;

            if (from_date != null && from_date != DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@FROM_DATE", SqlDbType.DateTime)).Value = from_date;
            else
                Command.Parameters.Add(new SqlParameter("@FROM_DATE", SqlDbType.DateTime)).Value = DBNull.Value;

            if (To_date != null && To_date != DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.DateTime)).Value = To_date;
            else
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.DateTime)).Value = DBNull.Value;

            if (PageNo > 0)
                Command.Parameters.Add(new SqlParameter("@PAGE_NO", SqlDbType.Int)).Value = PageNo;
            else
                Command.Parameters.Add(new SqlParameter("@PAGE_NO", SqlDbType.Int)).Value = DBNull.Value;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable GetReport()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("EMPLOYEE_REPORT_MANAGEMENT", con);
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