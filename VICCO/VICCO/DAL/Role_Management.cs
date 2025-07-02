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
    public class Role_Management
    {

        #region"Variable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public int id { get; set; }
        public int Role_id { get; set; }
        public int Region_id { get; set; }
        public int stockist_id { get; set; }
        public int Employee_id { get; set; }
        public int Distributor_id { get; set; }
        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
          
            if (id > 0)
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
            else
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Role_id > 0)
                Command.Parameters.Add(new SqlParameter("@ROLE_ID", SqlDbType.Int)).Value = Role_id;
            else
                Command.Parameters.Add(new SqlParameter("@ROLE_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (stockist_id > 0)
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = stockist_id;
            else
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Region_id > 0)
                Command.Parameters.Add(new SqlParameter("@REGION_ID", SqlDbType.Int)).Value = Region_id;
            else
                Command.Parameters.Add(new SqlParameter("@REGION_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Employee_id > 0)
                Command.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", SqlDbType.Int)).Value = Employee_id;
            else
                Command.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Distributor_id > 0)
                Command.Parameters.Add(new SqlParameter("@DISTRIBUTOR_ID", SqlDbType.Int)).Value = Distributor_id;
            else
                Command.Parameters.Add(new SqlParameter("@DISTRIBUTOR_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataSet SaveRole()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("ROLE_CONTROL_MANAGEMENT", con);
                AddwithParameter(cmd);
                DataSet dsReport = new DataSet();
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                con.Open();
                sda.Fill(dsReport);
                return dsReport;
            }
        }

        #endregion

    }
}