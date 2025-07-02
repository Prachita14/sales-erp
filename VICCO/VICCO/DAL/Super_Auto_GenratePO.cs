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
    public class Super_Auto_GenratePO
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
        public int STOCKIST_ID { get; set; }
        public int SPURCHASEORDER_ID { get; set; }
        public DateTime DATE { get; set; }
        public DateTime TO_DATE { get; set; }
        public string IS_NOT_GENERATE { get; set; }
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

            if (SPURCHASEORDER_ID > 0)
                Command.Parameters.Add(new SqlParameter("@SPURCHASEORDER_ID", SqlDbType.Int)).Value = SPURCHASEORDER_ID;
            else
                Command.Parameters.Add(new SqlParameter("@SPURCHASEORDER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (DATE != DateTime.MinValue && DATE != null)
                Command.Parameters.Add(new SqlParameter("@DATE", SqlDbType.Date)).Value = DATE;
            else
                Command.Parameters.Add(new SqlParameter("@DATE", SqlDbType.Date)).Value = DBNull.Value;

            if (TO_DATE != DateTime.MinValue && TO_DATE != null)
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.Date)).Value = TO_DATE;
            else
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.Date)).Value = DBNull.Value;

            if (IS_NOT_GENERATE != string.Empty && IS_NOT_GENERATE != null)
                Command.Parameters.Add(new SqlParameter("@IS_NOT_GENERATE", SqlDbType.VarChar)).Value = IS_NOT_GENERATE;
            else
                Command.Parameters.Add(new SqlParameter("@IS_NOT_GENERATE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (SP_OPERATION != string.Empty && SP_OPERATION != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SP_OPERATION;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable Getstock()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("AUTO_GENERATE_SUPPER_PO", con);
                AddwithParameter(cmd);
                DataTable dtReport = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                con.Open();
                sda.Fill(dtReport);
                return dtReport;
            }

            #endregion
        }
    }
}