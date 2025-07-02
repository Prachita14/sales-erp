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
    public class Admin_Dispatch_Material_Management
    {
        #region"Veriable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public int id { get; set; }
        public int stockist_id { get; set; }
        public DateTime date { get; set; }
        public DateTime to_date { get; set; }
        public string invoice_no { get; set; }
        public string status { get; set; }
        public int received_qty { get; set; }
        public string uom { get; set; }
        public string Remark { get; set; }
        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (id > 0)
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
            else
                Command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = DBNull.Value;

            if (stockist_id > 0)
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = stockist_id;
            else
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (date !=null && date!=DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@DATE", SqlDbType.Date)).Value = date;
            else
                Command.Parameters.Add(new SqlParameter("@DATE", SqlDbType.Date)).Value = DBNull.Value;

            if (to_date != null && to_date != DateTime.MinValue)
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.Date)).Value = to_date;
            else
                Command.Parameters.Add(new SqlParameter("@TO_DATE", SqlDbType.Date)).Value = DBNull.Value;

            if (invoice_no != string.Empty && invoice_no != null)
                Command.Parameters.Add(new SqlParameter("@INVOICE_NO", SqlDbType.VarChar)).Value = invoice_no;
            else
                Command.Parameters.Add(new SqlParameter("@INVOICE_NO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (status != string.Empty && status != null)
                Command.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.VarChar)).Value = status;
            else
                Command.Parameters.Add(new SqlParameter("@STATUS", SqlDbType.VarChar)).Value = DBNull.Value;

            if (received_qty >0)
                Command.Parameters.Add(new SqlParameter("@RECEIVED_QUANTITY", SqlDbType.VarChar)).Value = received_qty;
            else
                Command.Parameters.Add(new SqlParameter("@RECEIVED_QUANTITY", SqlDbType.VarChar)).Value = DBNull.Value;

            if (uom != string.Empty && uom != null)
                Command.Parameters.Add(new SqlParameter("@UOM", SqlDbType.VarChar)).Value = uom;
            else
                Command.Parameters.Add(new SqlParameter("@UOM", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Remark != string.Empty && Remark != null)
                Command.Parameters.Add(new SqlParameter("@REMARK", SqlDbType.VarChar)).Value = Remark;
            else
                Command.Parameters.Add(new SqlParameter("@REMARK", SqlDbType.VarChar)).Value = DBNull.Value;            

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveAdminDispatchMaterial()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("ADMIN_DISPATCH_MATERIAL_MANAGEMENT", con);
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