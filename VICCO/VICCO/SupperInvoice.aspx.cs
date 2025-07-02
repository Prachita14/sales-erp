using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using VICCO.DAL.PURCHASE_ORDER;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using VICCO.DAL;
using VICCO.DAL.PURCHASE_ORDER_PRODUCT;

#endregion

namespace VICCO
{
    public partial class SupperInvoice : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function

        public void GetPoReport()
        {
            try
            {
                Purches_Order_Management objUser = new Purches_Order_Management();
                //objUser.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);

                if (txtSearchPO.Text != "")
                {
                    objUser.Po_No = txtSearchPO.Text;
                }

                if (auto_select1.SelectedItem.Value != "")
                {
                    objUser.stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }

                if (txtFromDate.Text != "")
                {
                    objUser.Date = Convert.ToDateTime(txtFromDate.Text);
                }

                if (txttoDate.Text != "")
                {
                    objUser.to_date = Convert.ToDateTime(txttoDate.Text);
                }

                objUser.Sp_Operation = "GET_PURCHASE_ORDER_BY_PO";
                DataTable dtUser = new DataTable();
                dtUser = objUser.SaveUser();

                grdReport.DataSource = dtUser;
                grdReport.DataBind();

                if (dtUser.Rows.Count == 0)
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningOk();</script>");
                }

                else
                {
                    grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReport.UseAccessibleHeader = true;

                    Session["DataSource"] = dtUser;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindStockistName()
        {
            Supper_stockist_management objStockist = new Supper_stockist_management();
            objStockist.SpOperation = "SELECT";
            DataTable dtStockist = new DataTable();
            dtStockist = objStockist.SaveStockist();

            auto_select1.DataSource = dtStockist;
            auto_select1.DataValueField = "STOCKIST_ID";
            auto_select1.DataTextField = "NAME";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Super Stockist Name", "0"));
        }

        public void DeletePurchaseOrderIfNotSave()
        {
            try
            {
                Purches_Order_Management objDeletePurchase = new Purches_Order_Management();
                objDeletePurchase.Sp_Operation = "DELETE_PURCHASE_ORDER_IF_NOT_SAVE";
                objDeletePurchase.SaveUser();
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
                txtFromDate.Text = Convert.ToDateTime("1 " + System.DateTime.Now.ToString("MMM yyyy")).ToString("yyyy-MM-dd");
                txttoDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                DeletePurchaseOrderIfNotSave();
                //BindClient();
                BindStockistName();
            }


        }

        protected void grdPOReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdReport.PageIndex = e.NewPageIndex;
            grdReport.DataSource = Session["DataSource"];
            grdReport.DataBind();
        }

        protected void txtSearchPO_TextChanged(object sender, EventArgs e)
        {
            GetPoReport();
            auto_select1.ClearSelection();
        }

        protected void ClientName_SelectedIndexchange(object sender, EventArgs e)
        {
            txtSearchPO.Text = "";
            GetPoReport();
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string PoNo = grdReport.DataKeys[selRowIndex].Value.ToString();

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "newpage", "customOpen('POFormPrint.aspx?po_no=" + PoNo + "');", true);
        }

        protected void grdInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblType = (e.Row.FindControl("lblType") as Label);
                Panel gstlink = (e.Row.FindControl("gstlink") as Panel);
                Panel igstlink = (e.Row.FindControl("igstlink") as Panel);

                if (lblType.Text == "igst")
                {
                    igstlink.Visible = true;
                    gstlink.Visible = false;
                }
                else
                {
                    igstlink.Visible = false;
                    gstlink.Visible = true;
                }
            }
        }

        public void btndeleteconfirm(object sender, EventArgs e)
        {
            try
            {
                int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
                string id = grdReport.DataKeys[selRowIndex].Value.ToString();


                //Purches_Order_Management objDistributor = new Purches_Order_Management();
                //objDistributor.Sp_Operation = "DELETE_PURCHASE_ORDER";
                //objDistributor.Purchaseorder_Id = Convert.ToInt32(id);
                //objDistributor.User_Id = Convert.ToInt32(Request.Cookies["UserID"].Value);

                //DataTable dtUser = new DataTable();
                //dtUser = objDistributor.SaveUser();

                Session["PO_DELETE_ID"] = id;

                grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdReport.UseAccessibleHeader = true;

                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>Confirm();</script>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void btndelete(object sender, EventArgs e)
        {
            try
            {
                if (Session["PO_DELETE_ID"] != null)
                {
                    Purches_Order_Management objDistributor = new Purches_Order_Management();
                    objDistributor.Sp_Operation = "DELETE_PURCHASE_ORDER";
                    objDistributor.Purchaseorder_Id = Convert.ToInt32(Session["PO_DELETE_ID"]);
                    objDistributor.User_Id = Convert.ToInt32(Request.Cookies["UserID"].Value);

                    DataTable dtUser = new DataTable();
                    dtUser = objDistributor.SaveUser();

                    grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReport.UseAccessibleHeader = true;

                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}