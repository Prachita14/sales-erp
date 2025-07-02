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
using System.IO;
using System.Drawing;

#endregion

namespace VICCO
{
    public partial class DisplayReport : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());
        DataTable dt;
        #endregion

        #region "Public Function"

        public void BindEmployeeWithCode()
        {
            try
            {
                Employee_master_management objAutho = new Employee_master_management();
                objAutho.DESIGNATION_ID = 4;
                objAutho.SpOperation = "SELECT";
                DataTable dtAutho = new DataTable();
                dtAutho = objAutho.SaveEmployee();

                auto_select1.DataSource = dtAutho;
                auto_select1.DataValueField = "EMP_ID";
                auto_select1.DataTextField = "EMPLOYEE_DESCREPTION";
                auto_select1.DataBind();
                auto_select1.Items.Insert(0, new ListItem("Select Employee", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindDisplayReport()
        {
            No_of_display objdisplayreport = new No_of_display();

            objdisplayreport.SO_ID = Convert.ToInt32(auto_select1.SelectedItem.Value);

            if (txtFrom_Date.Text != "")
            {
                objdisplayreport.From_Date = Convert.ToDateTime(txtFrom_Date.Text);
            }
            if (txtTo_Date.Text != "")
            {
                objdisplayreport.To_Date = Convert.ToDateTime(txtTo_Date.Text);//Search by date
            }

            objdisplayreport.SpOperation = "SELECT";
            DataTable dt = new DataTable();
            dt = objdisplayreport.SaveDisplay();
            grddisplayreport.DataSource = dt;
            grddisplayreport.DataBind();

            if (dt.Rows.Count == 0)
            {
                errorMsg.Visible = true;
            }
            else
            {
                errorMsg.Visible = false;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFrom_Date.Text = Convert.ToDateTime("1 " + System.DateTime.Now.ToString("MMM yyyy")).ToString("yyyy-MM-dd");
                txtTo_Date.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                BindEmployeeWithCode();
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
            else if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 4)
            {
                this.Page.MasterPageFile = "~/Department.master";
            }
            else
            {
                this.Page.MasterPageFile = "~/Site1.master";
            }
        }

        protected void btnsearch(object sender, EventArgs e)
        {
            BindDisplayReport();

        }

        protected void grddisplayReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grddisplayreport.PageIndex = e.NewPageIndex;
            grddisplayreport.DataSource = Session["DataSource"];
            grddisplayreport.DataBind();
        }
    }
}