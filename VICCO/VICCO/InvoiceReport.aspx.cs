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

#endregion

namespace VICCO
{
    public partial class InvoiceReport : System.Web.UI.Page
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
                objUser.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                if (txtSearchPO.Text != "")
                {
                    objUser.Po_No = txtSearchPO.Text;
                }

                if (auto_select1.SelectedItem.Value != "")
                {
                    objUser.Customer_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
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

        public void BindClient()
        {
            Distributor_Management objClient = new Distributor_Management();
            objClient.SpOperation = "SELECT_FOR_INVOICE";
            objClient.Stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
            DataTable dtClient = new DataTable();
            dtClient = objClient.SaveDistributor();

            auto_select1.DataSource = dtClient;
            auto_select1.DataValueField = "DISTRIBUTOR_ID";
            auto_select1.DataTextField = "DISTRIBUTOR_NAME";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Select Client", "0"));
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
                BindClient();
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
    }
}