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
    public class PriceList_Management
    {
        #region"Veriable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public int price_id { get; set; }
        public int Material_id { get; set; }
        public double rate { get; set; }
        public double scheme { get; set; }
        public double disscount { get; set; }
        public int stockist_id { get; set; }
        public double Mrp { get; set; }
        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (price_id > 0)
                Command.Parameters.Add(new SqlParameter("@PRICE_ID", SqlDbType.Int)).Value = price_id;
            else
                Command.Parameters.Add(new SqlParameter("@PRICE_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Material_id > 0)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = Material_id;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (stockist_id > 0)
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = stockist_id;
            else
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (rate > 0)
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.Decimal)).Value = rate;
            else
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.Decimal)).Value = DBNull.Value;

            if (scheme > 0)
                Command.Parameters.Add(new SqlParameter("@SCHEME", SqlDbType.Decimal)).Value = scheme;
            else
                Command.Parameters.Add(new SqlParameter("@SCHEME", SqlDbType.Decimal)).Value = DBNull.Value;

            if (disscount > 0)
                Command.Parameters.Add(new SqlParameter("@DISSCOUNT", SqlDbType.Decimal)).Value = disscount;
            else
                Command.Parameters.Add(new SqlParameter("@DISSCOUNT", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Mrp > 0)
                Command.Parameters.Add(new SqlParameter("@MRP", SqlDbType.Decimal)).Value = Mrp;
            else
                Command.Parameters.Add(new SqlParameter("@MRP", SqlDbType.Decimal)).Value = DBNull.Value;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SavePriceList()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("STOCKIST_PRICE_MANAGEMENT", con);
                AddwithParameter(cmd);
                DataTable DataPriceList = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                con.Open();
                sda.Fill(DataPriceList);
                return DataPriceList;
            }

        }
        #endregion
    }
}