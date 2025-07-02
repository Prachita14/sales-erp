using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VICCO.DAL
{
    public class S_Purchase_Order_Management
    {
        #region"Veriable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        public int ID { get; set; }
        public int MATERIAL_ID { get; set; }
        public int SPURCHASEORDER_ID { get; set; }
        public int MIN_STOCK_CS { get; set; }
        public int STOCKIST_ID { get; set; }
        public int PO_QTY { get; set; }
        public string SP_OPERATION { get; set; }

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (ID > 0)
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = ID;
            else
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = DBNull.Value;

            if (MATERIAL_ID > 0)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = MATERIAL_ID;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (SPURCHASEORDER_ID > 0)
                Command.Parameters.Add(new SqlParameter("@SPURCHASEORDER_ID", SqlDbType.Int)).Value = SPURCHASEORDER_ID;
            else
                Command.Parameters.Add(new SqlParameter("@SPURCHASEORDER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (MIN_STOCK_CS > 0)
                Command.Parameters.Add(new SqlParameter("@MIN_STOCK_CS", SqlDbType.Int)).Value = MIN_STOCK_CS;
            else
                Command.Parameters.Add(new SqlParameter("@MIN_STOCK_CS", SqlDbType.Int)).Value = DBNull.Value;

            if (PO_QTY > 0)
                Command.Parameters.Add(new SqlParameter("@PO_QTY", SqlDbType.Int)).Value = PO_QTY;
            else
                Command.Parameters.Add(new SqlParameter("@PO_QTY", SqlDbType.Int)).Value = DBNull.Value;

            if (STOCKIST_ID > 0)
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = STOCKIST_ID;
            else
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (SP_OPERATION != string.Empty && SP_OPERATION != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SP_OPERATION;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable Savepo()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("S_PURCHASE_ORDER_MANAGEMENT", con);
                AddwithParameter(cmd);
                DataTable dtUser = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                sda = new SqlDataAdapter(cmd);
                con.Open();
                sda.Fill(dtUser);
                return dtUser;
            }

        }

        #endregion
    }
}