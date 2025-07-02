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
    public partial class MaterialReturnReport : System.Web.UI.Page
    {
        #region "Public Function"

        public void BindStockistName()
        {
            Supper_stockist_management objStockist = new Supper_stockist_management();
            objStockist.SpOperation = "SELECT";
            DataTable dtStockist = new DataTable();
            dtStockist = objStockist.SaveStockist();

            auto_select2.DataSource = dtStockist;
            auto_select2.DataValueField = "STOCKIST_ID";
            auto_select2.DataTextField = "NAME";
            auto_select2.DataBind();
            auto_select2.Items.Insert(0, new ListItem("Super Stockist Name", "0"));
        }

        public void GetMaterialReturn()
        {
            try
            {
                Material_Return_Management objReturn = new Material_Return_Management();

                if (ddlAprove.SelectedItem.Text == "New Request")
                {
                    objReturn.SpOperation = "SELECT_NEW_REQUEST";
                }
                else if (ddlAprove.SelectedItem.Text == "Rejected")
                {
                    objReturn.SpOperation = "SELECT_REJECTED";
                }
                else if (ddlAprove.SelectedItem.Text == "Approved")
                {
                    objReturn.SpOperation = "SELECT_APPROVE";
                }

                if (auto_select2.SelectedIndex != -1)
                {
                    objReturn.stockist_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }

                if (txtFromDate.Text != "")
                {
                    objReturn.Return_date = Convert.ToDateTime(txtFromDate.Text);
                }

                DataTable dtReturn = new DataTable();
                dtReturn = objReturn.SaveMaterialReturn();
                
                grdReport.DataSource = dtReturn;
                grdReport.DataBind();

                if (dtReturn.Rows.Count > 0)
                {

                    grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReport.UseAccessibleHeader = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            if (!IsPostBack)
            {
                
                txtFromDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                BindStockistName();
                GetMaterialReturn();
            }
        }

        protected void txtReturnMaterial_TextChanged(object sender, EventArgs e)
        {
            GetMaterialReturn();
        }

        protected void lnkApprove(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdReport.DataKeys[selRowIndex].Value.ToString();

            Material_Return_Management objReturn = new Material_Return_Management();
            objReturn.Return_id = Convert.ToInt32(id);
            objReturn.SpOperation = "APPROVE";
            objReturn.SaveMaterialReturn();
            GetMaterialReturn();
        }

        protected void lnkReject(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdReport.DataKeys[selRowIndex].Value.ToString();

            Material_Return_Management objReturn = new Material_Return_Management();
            objReturn.Return_id = Convert.ToInt32(id);
            objReturn.SpOperation = "REJECT";
            objReturn.SaveMaterialReturn();
            GetMaterialReturn();
        }

        protected void grdReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblapprove = (e.Row.FindControl("Lable6") as Label);
                LinkButton btnaprove = (e.Row.FindControl("lnkApprove") as LinkButton);
                LinkButton btnreject = (e.Row.FindControl("lnkRejcet") as LinkButton);

                if (ddlAprove.SelectedItem.Text != "New Request")
                {
                    btnaprove.Visible = false;
                    btnreject.Visible = false;
                    if (ddlAprove.SelectedItem.Text == "Approved")
                    {
                        lblapprove.ForeColor = System.Drawing.Color.Green;
                        btnreject.Visible = true;
                    }
                    else
                    {
                        lblapprove.ForeColor = System.Drawing.Color.Red;
                        btnaprove.Visible = true;
                    }
                }
                else
                {
                    lblapprove.Visible = false;
                }
            }
        }
    }
}