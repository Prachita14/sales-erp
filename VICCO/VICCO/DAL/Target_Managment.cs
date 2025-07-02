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
    public class Target_Managment
    {
        #region"Variable"

       // SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property


        public int ID { get; set; }
        public int STOCKIST_ID { get; set; }
        public int DISTRIBUTOR_ID { get; set; }
        public int USER_ID { get; set; }
        public int MATERIAL_ID { get; set; }
        public int TARGET { get; set; }
        public DateTime FROM_DATE { get; set; }
        public DateTime TO_DATE { get; set; }
        public string MATERIAL_CODE { get; set; }
        public string MATERIAL_NAME { get; set; }
        public string REGION { get; set; }
        public string MONTHS { get; set; }
        public string Material_ids { get; set; }
        public string Material_Group { get; set; }
        public string SP_OPERATION { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (ID > 0)
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = ID;
            else
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = DBNull.Value;
            
            if (STOCKIST_ID > 0)
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = STOCKIST_ID;
            else
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (DISTRIBUTOR_ID > 0)
                Command.Parameters.Add(new SqlParameter("@DISTRIBUTOR_ID", SqlDbType.Int)).Value = DISTRIBUTOR_ID;
            else
                Command.Parameters.Add(new SqlParameter("@DISTRIBUTOR_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (USER_ID > 0)
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = USER_ID;
            else
                Command.Parameters.Add(new SqlParameter("@USER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (MATERIAL_ID > 0)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = MATERIAL_ID;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (TARGET > 0)
                Command.Parameters.Add(new SqlParameter("@TARGET", SqlDbType.Int)).Value = TARGET;
            else
                Command.Parameters.Add(new SqlParameter("@TARGET", SqlDbType.Int)).Value = DBNull.Value;

            if (FROM_DATE != null && FROM_DATE != DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@FROM_DATE", SqlDbType.Date)).Value = FROM_DATE;
            else
                Command.Parameters.Add(new SqlParameter("@FROM_DATE", SqlDbType.Date)).Value = DBNull.Value;

            if (TO_DATE != null && TO_DATE != DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.Date)).Value = TO_DATE;
            else
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.Date)).Value = DBNull.Value;

            if (MATERIAL_CODE != string.Empty && MATERIAL_CODE != null)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_CODE", SqlDbType.VarChar)).Value = MATERIAL_CODE;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_CODE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (MATERIAL_NAME != string.Empty && MATERIAL_NAME != null)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_NAME", SqlDbType.VarChar)).Value = MATERIAL_NAME;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_NAME", SqlDbType.VarChar)).Value = DBNull.Value;

            if (MONTHS != string.Empty && MONTHS != null)
                Command.Parameters.Add(new SqlParameter("@MONTHS", SqlDbType.VarChar)).Value = MONTHS;
            else
                Command.Parameters.Add(new SqlParameter("@MONTHS", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Material_ids != string.Empty && Material_ids != null)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_IDS", SqlDbType.VarChar)).Value = Material_ids;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_IDS", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Material_Group != string.Empty && Material_Group != null)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_GROUP", SqlDbType.VarChar)).Value = Material_Group;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_GROUP", SqlDbType.VarChar)).Value = DBNull.Value;

            if (REGION != string.Empty && REGION != null)
                Command.Parameters.Add(new SqlParameter("@REGION", SqlDbType.VarChar)).Value = REGION;
            else
                Command.Parameters.Add(new SqlParameter("@REGION", SqlDbType.VarChar)).Value = DBNull.Value;

            if (SP_OPERATION != string.Empty && SP_OPERATION != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SP_OPERATION;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveTarget()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("TARGET_MANAGEMENT", con);
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