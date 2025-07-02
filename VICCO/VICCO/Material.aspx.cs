using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using VICCO.DAL;

#endregion

namespace RCandJJ
{
    public partial class Material : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void SaveMaterial()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.Material_code = txtMaterialCode.Text;
            objMaterial.Material_name = txtMaterialName.Text;
            objMaterial.SHORT_NAME = txtshortname.Text;
            objMaterial.GROUP_NAME = txtgroupname.Text;
            objMaterial.UOM_qty = Convert.ToInt32(txtUOMQty.Text);
            objMaterial.UOM_unit = ddlUomUnit.SelectedItem.Text;
            objMaterial.alternative_UOM_qty = Convert.ToInt32(txtAlternativeUOMQty.Text);
            objMaterial.alternative_UOM_unit = txtAlternativeUomUnit.Text;
            objMaterial.Gross_weight = Convert.ToDouble(txtGrossWeight.Text);
            objMaterial.Net_Weight = Convert.ToDouble(txtNetWeight.Text);
            objMaterial.Sgst = Convert.ToDouble(txtSGST.Text);
            objMaterial.Cgst = Convert.ToDouble(txtCgst.Text);
            objMaterial.Hsn_code = txtHsnCode.Text;
            if (txtMrp.Text != "")
            {
                objMaterial.Mrp = Convert.ToDouble(txtMrp.Text);
            }
            objMaterial.Created_by = Convert.ToInt32(Request.Cookies["UserID"].Value);
            objMaterial.SpOperation = "INSERT";
            objMaterial.SaveMaterial();
        }

        public void UpdateMaterial()
        {
            try
            {
                Material_management objMaterial = new Material_management();
                objMaterial.Material_id = Convert.ToInt32(Request.QueryString["mid"]);
                objMaterial.Material_code = txtMaterialCode.Text;
                objMaterial.Material_name = txtMaterialName.Text;
                objMaterial.SHORT_NAME = txtshortname.Text;
                objMaterial.GROUP_NAME = txtgroupname.Text;
                objMaterial.UOM_qty = Convert.ToInt32(txtUOMQty.Text);
                objMaterial.UOM_unit = ddlUomUnit.SelectedItem.Text;
                objMaterial.alternative_UOM_qty = Convert.ToInt32(txtAlternativeUOMQty.Text);
                objMaterial.alternative_UOM_unit = txtAlternativeUomUnit.Text;
                objMaterial.Gross_weight = Convert.ToDouble(txtGrossWeight.Text);
                objMaterial.Net_Weight = Convert.ToDouble(txtNetWeight.Text);
                objMaterial.Sgst = Convert.ToDouble(txtSGST.Text);
                objMaterial.Cgst = Convert.ToDouble(txtCgst.Text);
                objMaterial.Hsn_code = txtHsnCode.Text;
                if (txtMrp.Text != "")
                {
                    objMaterial.Mrp = Convert.ToDouble(txtMrp.Text);
                }
                objMaterial.Created_by = Convert.ToInt32(Request.Cookies["UserID"].Value);
                objMaterial.SpOperation = "UPDATE";
                objMaterial.SaveMaterial();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckMaterialName()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.SpOperation = "GET_MATERIAL_NAME";
            objMaterial.Material_name = txtMaterialName.Text;
            DataTable dtMaterial = new DataTable();
            dtMaterial = objMaterial.SaveMaterial();

            if (dtMaterial.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckMaterialCode()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.SpOperation = "CHECK_MATERIAL_CODE";

            if (Request.QueryString["mid"] != null)
            {
                objMaterial.Material_id = Convert.ToInt32(Request.QueryString["mid"]);
            }

            objMaterial.Material_code = txtMaterialCode.Text;
            DataTable dtMaterial = new DataTable();
            dtMaterial = objMaterial.SaveMaterial();

            if (dtMaterial.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GetMaterial()
        {
            try
            {
                Material_management objMaterial = new Material_management();
                objMaterial.Material_id = Convert.ToInt32(Request.QueryString["mid"]);
                objMaterial.SpOperation = "SELECT";
                DataTable dtMaterial = new DataTable();
                dtMaterial = objMaterial.SaveMaterial();

                if (dtMaterial.Rows.Count > 0)
                {
                    txtMaterialCode.Text = Convert.ToString(dtMaterial.Rows[0]["MATERIAL_CODE"]);
                    txtMaterialName.Text = Convert.ToString(dtMaterial.Rows[0]["MATERIAL_NAME"]);
                    txtshortname.Text = Convert.ToString(dtMaterial.Rows[0]["SHORT_NAME"]);
                    txtgroupname.Text = Convert.ToString(dtMaterial.Rows[0]["MATERIAL_GROUP"]);
                    txtUOMQty.Text = Convert.ToString(dtMaterial.Rows[0]["MATERIAL_UOM_QTY"]);
                    ddlUomUnit.SelectedItem.Value = Convert.ToString(dtMaterial.Rows[0]["MATERIAL_UOM_UNIT"]);
                    ddlUomUnit.SelectedItem.Text = Convert.ToString(dtMaterial.Rows[0]["MATERIAL_UOM_UNIT"]);
                    txtAlternativeUOMQty.Text = Convert.ToString(dtMaterial.Rows[0]["ALTERNATIVE_UOM_QTY"]);
                    txtAlternativeUomUnit.Text = Convert.ToString(dtMaterial.Rows[0]["ALTERNATIVE_UOM_QTY"]);
                    txtGrossWeight.Text = Convert.ToString(dtMaterial.Rows[0]["GROSS_WEIGHT"]);
                    txtNetWeight.Text = Convert.ToString(dtMaterial.Rows[0]["NET_WEIGHT"]);
                    txtHsnCode.Text = Convert.ToString(dtMaterial.Rows[0]["HSN_CODE"]);
                    txtCgst.Text = Convert.ToString(dtMaterial.Rows[0]["CGST"]);
                    txtSGST.Text = Convert.ToString(dtMaterial.Rows[0]["SGST"]);
                    txtMrp.Text = Convert.ToString(dtMaterial.Rows[0]["MRP"]);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["mid"] != null)
                {
                    GetMaterial();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckMaterialCode() == false)
            {
                if (Request.QueryString["mid"] != null)
                {
                    UpdateMaterial();
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>UpdateOk();</script>");
                }
                else
                {
                    if (CheckMaterialName() == false)
                    {
                        SaveMaterial();
                        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningOk();</script>");
                    }
                }
            }
            else
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningCodeOk();</script>");
            }
        }

        #endregion

    }
}