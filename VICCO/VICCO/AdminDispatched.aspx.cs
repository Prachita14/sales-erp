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
    public partial class AdminDispatched : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void GetDispatchedData()
        {
            try
            {
                Admin_Dispatch_Material_Management objDispatch = new Admin_Dispatch_Material_Management();
                objDispatch.invoice_no = Request.QueryString["invno"];
                objDispatch.SpOperation = "SELECT_BY_ID";
                DataTable dtDispatch = new DataTable();
                dtDispatch = objDispatch.SaveAdminDispatchMaterial();

                grdDistributor.DataSource = dtDispatch;
                grdDistributor.DataBind();

                lblDispatchNo.Text = Convert.ToString(dtDispatch.Rows[0]["DISPATCH_NOTE_NO"]);
                lblInvoiceNo.Text = Convert.ToString(dtDispatch.Rows[0]["INVOICE_NO"]);
                lblLineItem.Text = Convert.ToString(dtDispatch.Rows[0]["TOTAL_LINE_ITEM"]);

                lblTotal.Text = Convert.ToString(dtDispatch.Rows[0]["GROSS_TOTAL"]);

                lblTotalShipped.Text = Convert.ToString(dtDispatch.Rows[0]["TOTAL_SHIPPED_QUANTITY"]);
                lblTotalReceived.Text = Convert.ToString(dtDispatch.Rows[0]["TOTAL_RECEIVED_QUANTITY"]);

                lblDate.Text = Convert.ToDateTime(dtDispatch.Rows[0]["GRN_DATE"]).ToString("dd MMM yyyy");
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

            GetDispatchedData();
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
    }
}