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
    public partial class GoodReceipt : System.Web.UI.Page
    {
        #region "Variable"

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void GetDispatchMaterial()
        {
            try
            {
                Admin_Dispatch_Material_Management objDispatch = new Admin_Dispatch_Material_Management();
                objDispatch.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                objDispatch.invoice_no = txtInvoiceno.Text;

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

                grdReport.DataSource = dtDispatch;
                grdReport.DataBind();


                if (dtDispatch.Rows.Count > 0)
                {
                    Session["DataSource"] = dtDispatch;
                   
                    grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReport.UseAccessibleHeader = true;
                }

                if (dtDispatch.Rows.Count == 0)
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
                GetDispatchMaterial();
            }
        }

        protected void btnSearch_Dispatch(object sender, EventArgs e)
        {
            GetDispatchMaterial();
        }

        protected void grdDispatch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblStatus = (e.Row.FindControl("Label6") as Label);                
                
               HyperLink btnupdate = (e.Row.FindControl("btnupdate") as HyperLink);
                
                if (lblStatus.Text == "Closed")
                {                    
                    btnupdate.Visible = false;
                }                
            }
        }     
    }
}