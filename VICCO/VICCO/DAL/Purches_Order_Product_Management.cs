using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region "AddtionalNamespces"

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace VICCO.DAL.PURCHASE_ORDER_PRODUCT
{
    public class Purches_Order_Product_Management
    {
        #region"Veriable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region"Properties"

        public int Purchase_order_product_id { get; set; }

        private int PURCHASEORDER_ID;
        public int PurchaseOrder_Id
        {
            get { return PURCHASEORDER_ID; }
            set { PURCHASEORDER_ID = value; }
        }

        public int stockist_id { get; set; }
        public double scheme { get; set; }
        public double cgst { get; set; }
        public double sgst { get; set; }       
        

        public int Product_id { get; set; }

        public int Customer_id { get; set; }
        
        private double QTY;
        public double Qty
        {
            get { return QTY; }
            set { QTY = value; }
        }

        private string UNIT;
        public string Unit
        {
            get { return UNIT; }
            set { UNIT = value; }
        }

        private double RATE;
        public double Rate
        {
            get { return RATE; }
            set { RATE = value; }
        }       

        private double AMOUNT;
        public double Amount
        {
            get { return AMOUNT; }
            set { AMOUNT = value; }
        }

        private double Disscount;
        public double disscount
        {
            get { return Disscount; }
            set { Disscount = value; }
        }

        private string SpOperation;
        public string Sp_Operation
        {
            get { return SpOperation; }
            set { SpOperation = value; }
        }

        public string Remark { get; set; }
        public int ReceivedQty { get; set; }


        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Purchase_order_product_id > 0)
                Command.Parameters.Add(new SqlParameter("@PURCHASE_ORDER_PRODUCT_ID", SqlDbType.Int)).Value = Purchase_order_product_id;
            else
                Command.Parameters.Add(new SqlParameter("@PURCHASE_ORDER_PRODUCT_ID", SqlDbType.Int)).Value = DBNull.Value;       
          
            if (PurchaseOrder_Id > 0)
                Command.Parameters.Add(new SqlParameter("@PURCHASEORDER_ID", SqlDbType.Int)).Value = PurchaseOrder_Id;
            else
                Command.Parameters.Add(new SqlParameter("@PURCHASEORDER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (stockist_id > 0)
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = stockist_id;
            else
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Customer_id > 0)
                Command.Parameters.Add(new SqlParameter("@CUSTMOER_ID", SqlDbType.Int)).Value = Customer_id;
            else
                Command.Parameters.Add(new SqlParameter("@CUSTMOER_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Product_id >0)
                Command.Parameters.Add(new SqlParameter("@PRODUCT_ID", SqlDbType.Int)).Value = Product_id;
            else
                Command.Parameters.Add(new SqlParameter("@PRODUCT_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Qty > 0)
                Command.Parameters.Add(new SqlParameter("@QTY", SqlDbType.Decimal)).Value = Qty;
            else
                Command.Parameters.Add(new SqlParameter("@QTY", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Unit != String.Empty && Unit != null)
                Command.Parameters.Add(new SqlParameter("@UNIT", SqlDbType.VarChar)).Value = Unit;
            else
                Command.Parameters.Add(new SqlParameter("@UNIT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Rate > 0)
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.Decimal)).Value = Rate;
            else
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.Decimal)).Value = DBNull.Value;

            if (scheme > 0)
                Command.Parameters.Add(new SqlParameter("@SCHEME", SqlDbType.Decimal)).Value = scheme;
            else
                Command.Parameters.Add(new SqlParameter("@SCHEME", SqlDbType.Decimal)).Value = DBNull.Value;

            if ( Amount > 0)
                Command.Parameters.Add(new SqlParameter("@AMOUNT", SqlDbType.Decimal)).Value = Amount;
            else
                Command.Parameters.Add(new SqlParameter("@AMOUNT", SqlDbType.Decimal)).Value = DBNull.Value;

            if (disscount > 0)
                Command.Parameters.Add(new SqlParameter("@DISCOUNT", SqlDbType.Decimal)).Value = disscount;
            else
                Command.Parameters.Add(new SqlParameter("@DISCOUNT", SqlDbType.Decimal)).Value = DBNull.Value;

            if (cgst > 0)
                Command.Parameters.Add(new SqlParameter("@CGST", SqlDbType.Decimal)).Value = cgst;
            else
                Command.Parameters.Add(new SqlParameter("@CGST", SqlDbType.Decimal)).Value = DBNull.Value;

            if (sgst > 0)
                Command.Parameters.Add(new SqlParameter("@SGST", SqlDbType.Decimal)).Value = sgst;
            else
                Command.Parameters.Add(new SqlParameter("@SGST", SqlDbType.Decimal)).Value = DBNull.Value;

            if (ReceivedQty > 0)
                Command.Parameters.Add(new SqlParameter("@RECEIVED_QTY", SqlDbType.Int)).Value = ReceivedQty;
            else
                Command.Parameters.Add(new SqlParameter("@RECEIVED_QTY", SqlDbType.Int)).Value = DBNull.Value;

            if (Remark != string.Empty && Remark != null)
                Command.Parameters.Add(new SqlParameter("@REMARK", SqlDbType.VarChar)).Value = Remark;
            else
                Command.Parameters.Add(new SqlParameter("@REMARK", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Sp_Operation != string.Empty && Sp_Operation != null)
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = Sp_Operation;
            else
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = DBNull.Value;
        }
        public DataTable SaveUser()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("PURCHASE_ORDER_PRODUCT_MANAGEMENT", con);
                AddwithParameter(cmd);
                DataTable dtUser = new DataTable();
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                con.Open();
                sda.Fill(dtUser);
                return dtUser;
            }

        }
         #endregion
    }
}