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
    public class Material_management
    {
        #region"Veriable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public int Material_id { get; set; }
        public string Material_code { get; set; }
        public string Material_name { get; set; }
        public string SHORT_NAME { get; set; }
        public string GROUP_NAME { get; set; }
        public int UOM_qty { get; set; }
        public string UOM_unit { get; set; }
        public int alternative_UOM_qty { get; set; }
        public string alternative_UOM_unit { get; set; }
        public double Sgst { get; set; }
        public double Cgst { get; set; }
        public double Gross_weight { get; set; }
        public double Net_Weight { get; set; }
        public double Rate { get; set; }
        public double Mrp { get; set; }
        public string Hsn_code { get; set; }
        public int Created_by { get; set; }
        public string SpOperation { get; set; }
        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Material_id > 0)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = Material_id;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Material_code != String.Empty && Material_code != null)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_CODE", SqlDbType.VarChar)).Value = Material_code;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_CODE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Material_name != String.Empty && Material_name != null)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_NAME", SqlDbType.VarChar)).Value = Material_name;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_NAME", SqlDbType.VarChar)).Value = DBNull.Value;

            if (SHORT_NAME != String.Empty && SHORT_NAME != null)
                Command.Parameters.Add(new SqlParameter("@SHORT_NAME", SqlDbType.VarChar)).Value = SHORT_NAME;
            else
                Command.Parameters.Add(new SqlParameter("@SHORT_NAME", SqlDbType.VarChar)).Value = DBNull.Value;

            if (GROUP_NAME != String.Empty && GROUP_NAME != null)
                Command.Parameters.Add(new SqlParameter("@GROUP_NAME", SqlDbType.VarChar)).Value = GROUP_NAME;
            else
                Command.Parameters.Add(new SqlParameter("@GROUP_NAME", SqlDbType.VarChar)).Value = DBNull.Value;


            if (UOM_qty > 0)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_UOM_QTY", SqlDbType.Int)).Value = UOM_qty;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_UOM_QTY", SqlDbType.Int)).Value = DBNull.Value;

            if (UOM_unit != String.Empty && UOM_unit != null)
                Command.Parameters.Add(new SqlParameter("@MATERIAL_UOM_UNIT", SqlDbType.VarChar)).Value = UOM_unit;
            else
                Command.Parameters.Add(new SqlParameter("@MATERIAL_UOM_UNIT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (alternative_UOM_qty > 0)
                Command.Parameters.Add(new SqlParameter("@ALTERNATIVE_UOM_QTY", SqlDbType.Int)).Value = alternative_UOM_qty;
            else
                Command.Parameters.Add(new SqlParameter("@ALTERNATIVE_UOM_QTY", SqlDbType.Int)).Value = DBNull.Value;

            if (alternative_UOM_unit != String.Empty && alternative_UOM_unit != null)
                Command.Parameters.Add(new SqlParameter("@ALTERNATIVE_UOM_UNIT", SqlDbType.VarChar)).Value = alternative_UOM_unit;
            else
                Command.Parameters.Add(new SqlParameter("@ALTERNATIVE_UOM_UNIT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Sgst > 0)
                Command.Parameters.Add(new SqlParameter("@SGST", SqlDbType.Decimal)).Value = Sgst;
            else
                Command.Parameters.Add(new SqlParameter("@SGST", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Cgst > 0)
                Command.Parameters.Add(new SqlParameter("@CGST", SqlDbType.Decimal)).Value = Cgst;
            else
                Command.Parameters.Add(new SqlParameter("@CGST", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Gross_weight > 0)
                Command.Parameters.Add(new SqlParameter("@GROSS_WEIGHT", SqlDbType.Decimal)).Value = Gross_weight;
            else
                Command.Parameters.Add(new SqlParameter("@GROSS_WEIGHT", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Net_Weight > 0)
                Command.Parameters.Add(new SqlParameter("@NET_WEIGHT", SqlDbType.Decimal)).Value = Net_Weight;
            else
                Command.Parameters.Add(new SqlParameter("@NET_WEIGHT", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Rate > 0)
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.Decimal)).Value = Rate;
            else
                Command.Parameters.Add(new SqlParameter("@RATE", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Mrp > 0)
                Command.Parameters.Add(new SqlParameter("@MRP", SqlDbType.Decimal)).Value = Mrp;
            else
                Command.Parameters.Add(new SqlParameter("@MRP", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Hsn_code != String.Empty && Hsn_code != null)
                Command.Parameters.Add(new SqlParameter("@HSN_CODE", SqlDbType.VarChar)).Value = Hsn_code;
            else
                Command.Parameters.Add(new SqlParameter("@HSN_CODE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Created_by > 0)
                Command.Parameters.Add(new SqlParameter("@CREATED_BY", SqlDbType.Int)).Value = Created_by;
            else
                Command.Parameters.Add(new SqlParameter("@CREATED_BY", SqlDbType.Int)).Value = DBNull.Value;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveMaterial()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("MATERIAL_MANAGEMENT", con);
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