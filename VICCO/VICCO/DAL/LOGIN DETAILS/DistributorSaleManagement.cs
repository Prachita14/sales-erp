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
    public class DistributtorSale
    {
        #region"Veriable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property


        public int ID { get; set; }
        public int DISTRIBUTOR_ID { get; set; }
        public int MATERIAL_ID { get; set; }
        public int SALE { get; set; }
        public DateTime FROM_DATE { get; set; }
        public DateTime TO_DATE { get; set; }
        public int CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string SP_OPERATION { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (ID > 0)
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = ID;
            else
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = DBNull.Value;

            if (DISTRIBUTOR_ID > 0)
                Command.Parameters.Add(new SqlParameter("@DISTRIBUTOR_ID", SqlDbType.Int)).Value = DISTRIBUTOR_ID;
            else
                Command.Parameters.Add(new SqlParameter("@DISTRIBUTOR_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (MATERIAL_ID > 0)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = MATERIAL_ID;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (SALE > 0)
                Command.Parameters.Add(new SqlParameter("@SALE", SqlDbType.Int)).Value = SALE;
            else
                Command.Parameters.Add(new SqlParameter("@SALE", SqlDbType.Int)).Value = DBNull.Value;

            if (FROM_DATE != null && FROM_DATE != DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@FROM_DATE", SqlDbType.Date)).Value = FROM_DATE;
            else
                Command.Parameters.Add(new SqlParameter("@FROM_DATE", SqlDbType.Date)).Value = DBNull.Value;

            if (TO_DATE != null && TO_DATE != DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.Date)).Value = TO_DATE;
            else
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.Date)).Value = DBNull.Value;

            if (CREATED_BY>0)
                Command.Parameters.Add(new SqlParameter("@CREATED_BY", SqlDbType.Int)).Value = CREATED_BY;
            else
                Command.Parameters.Add(new SqlParameter("@CREATED_BY", SqlDbType.Int)).Value = DBNull.Value;

            if (CREATED_ON != null && CREATED_ON != DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@CREATED_ON", SqlDbType.Date)).Value = CREATED_ON;
            else
                Command.Parameters.Add(new SqlParameter("@CREATED_ON", SqlDbType.Date)).Value = DBNull.Value;

            if (SP_OPERATION != string.Empty && SP_OPERATION != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SP_OPERATION;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable Savesales()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("DISTRIBUTOR_SALE_MANAGMENT", con);
                AddwithParameter(cmd);
                DataTable DataTableTarget = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                con.Open();
                sda.Fill(DataTableTarget);

                return DataTableTarget;
            }

        }
        #endregion

    }
}