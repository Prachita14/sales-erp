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

namespace VICCO.Employee
{
    public partial class NoOfDisplay : System.Web.UI.Page
    {

        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());
        DataTable dt;
        #endregion

        #region "Public Function"

        public void BindGridViewStock()
        {
            Employee_master_management objClosingStock = new Employee_master_management();
            objClosingStock.EMP_ID = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
            objClosingStock.SpOperation = "GET_SO_BY_SR";
            DataTable dtStock = new DataTable();
            dtStock = objClosingStock.SaveEmployee();
            grdReport.DataSource = dtStock;
            grdReport.DataBind();

            if (dtStock.Rows.Count > 0)
            {
                grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdReport.UseAccessibleHeader = true;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridViewStock();
            }
        }

        protected void btnorder(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((Button)sender).Parent.Parent)).RowIndex;
            string id = grdReport.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdReport.Rows[selRowIndex];
            TextBox txtBrush = (row.FindControl("txtBrush") as TextBox);
            TextBox txtFrom_Date = (row.FindControl("txtFrom_Date") as TextBox);
            TextBox txtTo_Date = (row.FindControl("txtTo_Date") as TextBox);
            TextBox txtfacewash = (row.FindControl("txtfacewash") as TextBox);
            TextBox txtifb = (row.FindControl("txtifb") as TextBox);
            TextBox txtnryc = (row.FindControl("txtnryc") as TextBox);
            TextBox txtnrys = (row.FindControl("txtnrys") as TextBox);
            TextBox txtoib = (row.FindControl("txtoib") as TextBox);
            TextBox txtpaste = (row.FindControl("txtpaste") as TextBox);
            TextBox txtpaste25 = (row.FindControl("txtpaste25") as TextBox);
            TextBox txtpouchpowder = (row.FindControl("txtpouchpowder") as TextBox);
            TextBox txtpouchwso = (row.FindControl("txtpouchwso") as TextBox);
            TextBox txtpowder = (row.FindControl("txtpowder") as TextBox);
            TextBox txtsf = (row.FindControl("txtsf") as TextBox);
            TextBox txtshaving = (row.FindControl("txtshaving") as TextBox);
            TextBox txtvtccream = (row.FindControl("txtvtccream") as TextBox);
            TextBox txtwso = (row.FindControl("txtwso") as TextBox);
            TextBox txtCombine = (row.FindControl("txtCombine") as TextBox);
            
            //DropDownList ddlmonth = (row.FindControl("ddlmonth") as DropDownList);


            No_of_display objClosingStock = new No_of_display();
            objClosingStock.SO_ID = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
            objClosingStock.EMP_ID = Convert.ToInt32(id);
            objClosingStock.Brush = txtBrush.Text;
            objClosingStock.From_Date = Convert.ToDateTime(txtFrom_Date.Text);
            objClosingStock.To_Date = Convert.ToDateTime(txtTo_Date.Text);
            objClosingStock.Facewash = txtfacewash.Text;
            objClosingStock.IFB = txtifb.Text;
            objClosingStock.NRY_C = txtnryc.Text;
            objClosingStock.NRY_S = txtnrys.Text;
            objClosingStock.OIB = txtoib.Text;
            objClosingStock.Paste = txtpaste.Text;
            objClosingStock.Paste25 = txtpaste25.Text;
            objClosingStock.Pouch_Powder = txtpouchpowder.Text;
            objClosingStock.Pouch_WSO = txtpouchwso.Text;
            objClosingStock.Powder = txtpowder.Text;
            objClosingStock.SF = txtsf.Text;
            objClosingStock.Shaving = txtshaving.Text;
            objClosingStock.VTC_Cream = txtvtccream.Text;
            objClosingStock.WSO = txtwso.Text;
            objClosingStock.COMBINE = txtCombine.Text;
            //objClosingStock.Month = ddlmonth.SelectedItem.Text;
            objClosingStock.SpOperation = "INSERT";
            objClosingStock.SaveDisplay();

            Response.Redirect("NoOfDisplayReport.aspx");
        }

        protected void grddisplayReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdReport.PageIndex = e.NewPageIndex;
            grdReport.DataSource = Session["DataSource"];
            grdReport.DataBind();
        }
    }
}