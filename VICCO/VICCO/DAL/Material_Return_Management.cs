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
    public class Material_Return_Management
    {
        #region"Veriable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public int Return_id { get; set; }
        public int Material_id { get; set; }
        public int stockist_id { get; set; }
        public string invoice_no { get; set; }
        public DateTime Return_date { get; set; }
        public string Batch_no { get; set; }
        public string Rate { get; set; }
        public string quantity { get; set; }
        public string total { get; set; }
        public string Comment { get; set; }
        public string Approve { get; set; }
        public string SpOperation { get; set; }
        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Return_id > 0)
                Command.Parameters.Add(new SqlParameter("@RETURN_ID", SqlDbType.Int)).Value = Return_id;
            else
                Command.Parameters.Add(new SqlParameter("@RETURN_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Material_id > 0)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = Material_id;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (stockist_id > 0)
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = stockist_id;
            else
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (invoice_no != String.Empty && invoice_no != null)
                Command.Parameters.Add(new SqlParameter("@INVOICE_NO", SqlDbType.VarChar)).Value = invoice_no;
            else
                Command.Parameters.Add(new SqlParameter("@INVOICE_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Return_date !=null&& Return_date!=DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@RETURN_DATE", SqlDbType.DateTime)).Value = Return_date;
            else
                Command.Parameters.Add(new SqlParameter("@RETURN_DATE", SqlDbType.DateTime)).Value = DBNull.Value;

            if (Batch_no != String.Empty && Batch_no != null)
                Command.Parameters.Add(new SqlParameter("@BATCH_NO", SqlDbType.VarChar)).Value = Batch_no;
            else
                Command.Parameters.Add(new SqlParameter("@BATCH_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Rate != String.Empty && Rate != null)
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.VarChar)).Value = Rate;
            else
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (quantity != String.Empty && quantity != null)
                Command.Parameters.Add(new SqlParameter("@QUANTITY", SqlDbType.VarChar)).Value = quantity;
            else
                Command.Parameters.Add(new SqlParameter("@QUANTITY", SqlDbType.VarChar)).Value = DBNull.Value;

            if (total != String.Empty && total != null)
                Command.Parameters.Add(new SqlParameter("@TOTAL", SqlDbType.VarChar)).Value = total;
            else
                Command.Parameters.Add(new SqlParameter("@TOTAL", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Comment != String.Empty && Comment != null)
                Command.Parameters.Add(new SqlParameter("@COMMENT", SqlDbType.VarChar)).Value = Comment;
            else
                Command.Parameters.Add(new SqlParameter("@COMMENT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Approve != String.Empty && Approve != null)
                Command.Parameters.Add(new SqlParameter("@APRROVE", SqlDbType.VarChar)).Value = Approve;
            else
                Command.Parameters.Add(new SqlParameter("@APRROVE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveMaterialReturn()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("MATERIAL_RETURN_MANAGEMENT", con);
                AddwithParameter(cmd);
                DataTable DataTableMaterial = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                con.Open();
                sda.Fill(DataTableMaterial);
                return DataTableMaterial;
            }

        }

        #endregion
    }
}