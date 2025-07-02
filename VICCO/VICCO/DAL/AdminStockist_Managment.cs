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
    public class AdminStockist_Managment
    {
        #region"Variable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public int roll_id { get; set; }
        public string Email { get; set; }
        public int STOCKIST_ID { get; set; }
        public int EMPLOYEE_ID { get; set; }
        public string MATERIAL_GROUP { get; set; }
        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (roll_id > 0)
                Command.Parameters.Add(new SqlParameter("@ROLL_ID", SqlDbType.Int)).Value = roll_id;
            else
                Command.Parameters.Add(new SqlParameter("@ROLL_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Email != string.Empty && Email != null)
                Command.Parameters.Add(new SqlParameter("@EMAIL", SqlDbType.VarChar)).Value = Email;
            else
                Command.Parameters.Add(new SqlParameter("@EMAIL", SqlDbType.VarChar)).Value = DBNull.Value;

            if (STOCKIST_ID > 0)
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = STOCKIST_ID;
            else
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (EMPLOYEE_ID > 0)
                Command.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", SqlDbType.Int)).Value = EMPLOYEE_ID;
            else
                Command.Parameters.Add(new SqlParameter("@EMPLOYEE_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (MATERIAL_GROUP != string.Empty && MATERIAL_GROUP != null)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_GROUP", SqlDbType.VarChar)).Value = MATERIAL_GROUP;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_GROUP", SqlDbType.VarChar)).Value = DBNull.Value;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable GetDetails()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("ADMIN_STOCKIST_MANAGEMENT", con);
                AddwithParameter(cmd);
                cmd.CommandTimeout = 0;
                DataTable DataGetDetails = new DataTable();                
                cmd.CommandType = CommandType.StoredProcedure;                
                sda = new SqlDataAdapter(cmd);
                con.Open();
                sda.Fill(DataGetDetails);               
                return DataGetDetails;
            }
        }
        #endregion
    }
}