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

namespace VICCO
{
    public partial class PurchaseOrder : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        public void GetPurchaseOrder()
        {
            try
            {
                Distributor_PO_Management objPo = new Distributor_PO_Management();
                objPo.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);

                if (txtSearchPO.Text != "")
                {
                    objPo.Po_No = txtSearchPO.Text;
                }

                if (auto_select1.SelectedItem.Value != "")
                {
                    objPo.Distributor_Id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }

                if (txtFromDate.Text != "")
                {
                    objPo.Date = Convert.ToDateTime(txtFromDate.Text);
                }

                if (txttoDate.Text != "")
                {
                    objPo.to_date = Convert.ToDateTime(txttoDate.Text);
                }

                objPo.Sp_Operation = "GET_PURCHASE_ORDER_BY_PO";
                DataTable dtDistributor = new DataTable();
                dtDistributor = objPo.SaveUser();

                grdReport.DataSource = dtDistributor;
                grdReport.DataBind();

                if (dtDistributor.Rows.Count > 0)
                {
                    grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReport.UseAccessibleHeader = true;
                }

                if (dtDistributor.Rows.Count == 0)
                {
                    errorMsg.Visible = true;
                }
                else
                {
                    errorMsg.Visible = false;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack)
            {
                BindClient();
                GetPurchaseOrder();
                txtFromDate.Text = Convert.ToDateTime("1 " + System.DateTime.Now.ToString("MMM yyyy")).ToString("yyyy-MM-dd");
                txttoDate.Text= System.DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdReport.DataKeys[selRowIndex].Value.ToString();
            Response.Redirect("PurchaseOrderDetails.aspx?id=" + id);
        }

        protected void grdReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblInvoiceNo = (e.Row.FindControl("lblinvoiceno") as Label);
                Label Label44 = (e.Row.FindControl("Label44") as Label);
                HyperLink lnkInvoiceCreate = (e.Row.FindControl("lnkInvoice") as HyperLink);

                //if (lblInvoiceNo.Text != "")
                //{
                //    lblInvoiceNo.Visible = true;
                //    e.Row.Cells[5].Visible = true;
                //}
                //else
                //{
                //    e.Row.Cells[5].Visible = false;
                //}

                if (Label44.Text == "CLOSED")
                {
                    lnkInvoiceCreate.Visible = false;
                }

                //}

            }
        }

        protected void txtSearchPOClick(object sender, EventArgs e)
        {
            GetPurchaseOrder();
            auto_select1.ClearSelection();
        }
    }
}