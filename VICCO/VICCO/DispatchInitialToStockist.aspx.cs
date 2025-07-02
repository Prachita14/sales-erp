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
    public partial class DispatchInitialToStockist : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

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

        public void GetDispatchMaterial()
        {
            try
            {
                Admin_Dispatch_Initial_Material objDispatch = new Admin_Dispatch_Initial_Material();
                objDispatch.invoice_no = txtInvoiceno.Text;

                if (auto_select1.SelectedIndex != -1)
                {
                    objDispatch.stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }

                if (txtFromDate.Text != "")
                {
                    objDispatch.date = Convert.ToDateTime(txtFromDate.Text);
                }
                if (txtToDate.Text != "")
                {
                    objDispatch.to_date = Convert.ToDateTime(txtToDate.Text);
                }
                if (ddlStatus.SelectedItem.Text != "All")
                {
                    objDispatch.status = ddlStatus.SelectedItem.Text;
                }

                objDispatch.SpOperation = "SELECT";
                DataTable dtDispatch = new DataTable();
                dtDispatch = objDispatch.SaveAdminDispatchMaterial();

                if (dtDispatch.Rows.Count > 0)
                {
                    Session["DataSource"] = dtDispatch;

                    grdReport.DataSource = dtDispatch;
                    grdReport.DataBind();

                    grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReport.UseAccessibleHeader = true;

                    if (dtDispatch.Rows.Count == 0)
                    {
                        errorMsg.Visible = true;
                    }
                    else
                    {
                        errorMsg.Visible = false;
                    }
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
                txtFromDate.Text = Convert.ToDateTime("1 " + System.DateTime.Now.ToString("MMM yyyy")).ToString("yyyy-MM-dd");
                txtToDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                BindStockistName();
                GetDispatchMaterial();
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 2)
            {
                this.Page.MasterPageFile = "~/Stockist.master";
            }
            else if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 3)
            {
                this.Page.MasterPageFile = "~/office.master";
            }
            else
            {
                this.Page.MasterPageFile = "~/Site1.master";
            }
        }

        protected void grdDispatchReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdReport.PageIndex = e.NewPageIndex;
            grdReport.DataSource = Session["DataSource"];
            grdReport.DataBind();
        }

        protected void btnSearch_Dispatch(object sender, EventArgs e)
        {
            GetDispatchMaterial();
        }     
    }
}