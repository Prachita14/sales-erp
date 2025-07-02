using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using VICCO.DAL;
using System.Data;
using VICCO.DAL.PURCHASE_ORDER;
using VICCO.DAL.PURCHASE_ORDER_PRODUCT;

#endregion

namespace VICCO
{
    public partial class MaterialReturn : System.Web.UI.Page
    {
        #region "Public Function"

        public void GetCurrentMaterialReturn()
        {
            try
            {
                Material_Return_Management objReturn = new Material_Return_Management();
                objReturn.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                objReturn.SpOperation = "SELECT_TO_INSERT";
                DataTable dtReturn = new DataTable();
                dtReturn = objReturn.SaveMaterialReturn();
                grdProduct.DataSource = dtReturn;
                grdProduct.DataBind();

                grdProduct.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdProduct.UseAccessibleHeader = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public void RemoveProduct(int return_id)
        {
            try
            {
                Material_Return_Management objReturn = new Material_Return_Management();
                objReturn.Return_id = return_id;
                objReturn.SpOperation = "DELETE";
                objReturn.SaveMaterialReturn();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        #endregion

        #region "Event"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            if (!IsPostBack)
            {
                GetCurrentMaterialReturn();
            }
        }

        protected void DropDownProductContent_TextChange(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((DropDownList)sender).Parent.Parent)).RowIndex;
            string id = grdProduct.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdProduct.Rows[selRowIndex];

            DropDownList Product_id = (row.FindControl("auto_selectProduct") as DropDownList);
            TextBox txtBatchNo = (row.FindControl("txtBatchNo") as TextBox);
            TextBox txtRate = (row.FindControl("txtRate") as TextBox);
            TextBox txtQuantity = (row.FindControl("txtQuantity") as TextBox);
            TextBox txtComment = (row.FindControl("txtComment") as TextBox);

            Material_Return_Management objReturn = new Material_Return_Management();
            objReturn.Return_id = Convert.ToInt32(id);
            objReturn.Batch_no = txtBatchNo.Text;
            objReturn.Comment = txtComment.Text;
            objReturn.invoice_no = txtInvoice.Text;
            objReturn.Material_id = Convert.ToInt32(Product_id.SelectedItem.Value);
            objReturn.quantity = txtQuantity.Text;
            objReturn.Rate = txtRate.Text;
            if (txtCalender.Text != "")
            {
                objReturn.Return_date = Convert.ToDateTime(txtCalender.Text);
            }
            objReturn.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
            objReturn.SpOperation = "INSERT";
            objReturn.SaveMaterialReturn();

            GetCurrentMaterialReturn();

            ScriptManager.RegisterStartupScript(
                        UpdatePanel1,
                        this.GetType(),
                        "MyAction",
                        "auto();",
                        true);

        }

        protected void ProductContent_TextChange(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
            string id = grdProduct.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdProduct.Rows[selRowIndex];

            DropDownList Product_id = (row.FindControl("auto_selectProduct") as DropDownList);
            TextBox txtBatchNo = (row.FindControl("txtBatchNo") as TextBox);
            TextBox txtRate = (row.FindControl("txtRate") as TextBox);
            TextBox txtQuantity = (row.FindControl("txtQuantity") as TextBox);
            TextBox txtComment = (row.FindControl("txtComment") as TextBox);

            if (txtRate.Text == "")
            {
                txtRate.Text = "0";
            }

            if (txtQuantity.Text == "")
            {
                txtQuantity.Text = "0";
            }

            Material_Return_Management objReturn = new Material_Return_Management();
            objReturn.Return_id =Convert.ToInt32(id);
            objReturn.Batch_no = txtBatchNo.Text;
            objReturn.Comment = txtComment.Text;
            objReturn.invoice_no = txtInvoice.Text;
            objReturn.Material_id = Convert.ToInt32(Product_id.SelectedItem.Value);
            objReturn.quantity = txtQuantity.Text;
            objReturn.Rate = txtRate.Text;
            if (txtCalender.Text != "")
            {
                objReturn.Return_date = Convert.ToDateTime(txtCalender.Text);
            }
            objReturn.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
            objReturn.SpOperation = "INSERT";
            objReturn.SaveMaterialReturn();

            GetCurrentMaterialReturn();
            
            ScriptManager.RegisterStartupScript(
                        UpdatePanel1,
                        this.GetType(),
                        "MyAction",
                        "auto();",
                        true);

        }

        protected void RemoveProduct(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdProduct.DataKeys[selRowIndex].Value.ToString();
            RemoveProduct(Convert.ToInt32(id));
            GetCurrentMaterialReturn();

            ScriptManager.RegisterStartupScript(
                       UpdatePanel1,
                       this.GetType(),
                       "MyAction",
                       "auto();",
                       true);
        }

        protected void grdProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                DropDownList ddlProduct = (e.Row.FindControl("auto_selectProduct") as DropDownList);                

                Label lblProductName = (e.Row.FindControl("lblProductName") as Label);
                Label lblProduct_id = (e.Row.FindControl("lblProduct_id") as Label);


                Material_management objMaterial = new Material_management();
                objMaterial.SpOperation = "SELECT";
                DataTable dtMaterial = new DataTable();
                dtMaterial = objMaterial.SaveMaterial();

                ddlProduct.DataSource = dtMaterial;
                ddlProduct.DataValueField = "MATERIAL_ID";
                ddlProduct.DataTextField = "MATERIAL_DESCREPTION";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("Select Product ", "0"));

                if (lblProduct_id.Text != "")
                {
                    ddlProduct.ClearSelection();
                    ddlProduct.Items.FindByValue(lblProduct_id.Text).Selected = true;
                }

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Material_Return_Management objReturn = new Material_Return_Management();
            objReturn.invoice_no = txtInvoice.Text;        
            if (txtCalender.Text != "")
            {
                objReturn.Return_date = Convert.ToDateTime(txtCalender.Text);
            }
            objReturn.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
            objReturn.SpOperation = "INSERT";
            objReturn.SaveMaterialReturn();

            Material_Return_Management objReturn1 = new Material_Return_Management();            
            objReturn1.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
            objReturn1.SpOperation = "SUBMIT";
            objReturn1.SaveMaterialReturn();

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
        }

        #endregion
    }
}