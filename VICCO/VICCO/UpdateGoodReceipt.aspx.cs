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
    public partial class UpdateGoodReceipt : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                GetDispatchedData();
            }
        }

        protected void Content_TextChange(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdDistributor.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdDistributor.Rows[selRowIndex];

            TextBox txtRecQty = (row.FindControl("txtReceivedQuantity") as TextBox);
            TextBox txtUOM = (row.FindControl("txtUom") as TextBox);
            TextBox txtRemark = (row.FindControl("txtRemark") as TextBox);
            Label lblShipped_qty = (row.FindControl("Label4") as Label);

            if (txtRecQty.Text == "")
            {
                txtRecQty.Text = "0";
            }

            Admin_Dispatch_Material_Management objDispatch = new Admin_Dispatch_Material_Management();
            objDispatch.id =Convert.ToInt32(id);
            objDispatch.received_qty = Convert.ToInt32(txtRecQty.Text);
            objDispatch.uom = txtUOM.Text;
            objDispatch.Remark = txtRemark.Text;

            if (lblShipped_qty.Text == txtRecQty.Text)
            {
                objDispatch.status = "Closed";
            }
            else if (txtRecQty.Text=="0")
            {
                objDispatch.status = "Stock In Transit";
            }
            else
            {
                objDispatch.status = "Short Received";
            }

            objDispatch.SpOperation = "UPDATE_DISPATCH_MATERIAL";
            objDispatch.SaveAdminDispatchMaterial();
            GetDispatchedData();
        }
    }
}