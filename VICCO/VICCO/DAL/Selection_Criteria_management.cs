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
    public class Selection_Criteria_management
    {
        #region "Variable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public int Criteria_id { get; set; }
        public string state { get; set; }
        public int stockist_id { get; set; }
        public string district { get; set; }
        public string town { get; set; }
        public int distributor_id { get; set; }
        public string sales_officer { get; set; }
        public DateTime date_from_to { get; set; }
        public DateTime To_Date { get; set; }
        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Criteria_id > 0)
                Command.Parameters.Add(new SqlParameter("@CRITERIA_ID", SqlDbType.Int)).Value = Criteria_id;
            else
                Command.Parameters.Add(new SqlParameter("@CRITERIA_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (state != string.Empty && state != null)
                Command.Parameters.Add(new SqlParameter("@STATE", SqlDbType.VarChar)).Value = state;
            else
                Command.Parameters.Add(new SqlParameter("@STATE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (stockist_id > 0)
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = stockist_id;
            else
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (district != string.Empty && district != null)
                Command.Parameters.Add(new SqlParameter("@DISTRICT", SqlDbType.VarChar)).Value = district;
            else
                Command.Parameters.Add(new SqlParameter("@DISTRICT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (town != string.Empty && town != null)
                Command.Parameters.Add(new SqlParameter("@TOWN", SqlDbType.VarChar)).Value = town;
            else
                Command.Parameters.Add(new SqlParameter("@TOWN", SqlDbType.VarChar)).Value = DBNull.Value;

            if (distributor_id > 0)
                Command.Parameters.Add(new SqlParameter("@DISTRIBUTOR_ID", SqlDbType.Int)).Value = distributor_id;
            else
                Command.Parameters.Add(new SqlParameter("@DISTRIBUTOR_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (sales_officer != string.Empty && sales_officer != null)
                Command.Parameters.Add(new SqlParameter("@SALES_OFFICER", SqlDbType.VarChar)).Value = sales_officer;
            else
                Command.Parameters.Add(new SqlParameter("@SALES_OFFICER", SqlDbType.VarChar)).Value = DBNull.Value;

            if (date_from_to != DateTime.MinValue && date_from_to != null)
                Command.Parameters.Add(new SqlParameter("@DATE_FROM_TO", SqlDbType.DateTime)).Value = date_from_to;
            else
                Command.Parameters.Add(new SqlParameter("@DATE_FROM_TO", SqlDbType.DateTime)).Value = DBNull.Value;

            if (To_Date != DateTime.MinValue && To_Date != null)
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.DateTime)).Value = To_Date;
            else
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.DateTime)).Value = DBNull.Value;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveCriteria()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("SELECTION_CRITERIA_MANAGEMENT", con);
                AddwithParameter(cmd);
                DataTable DataCriteria = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                con.Open();
                sda.Fill(DataCriteria);
                return DataCriteria;
            }

        }
        #endregion
    }
}