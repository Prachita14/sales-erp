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

namespace VICCO.Employee
{
    public partial class NoOfDisplayReport : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());
        DataTable dt;
        #endregion

        #region "Public Function"

        public void BindDisplayReport()
        {
            No_of_display objdisplayreport = new No_of_display();
            objdisplayreport.SO_ID = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);

            if (txtFrom_Date.Text != "")
            {
                objdisplayreport.From_Date = Convert.ToDateTime(txtFrom_Date.Text);
            }
            if (txtTo_Date.Text != "")
            {
                objdisplayreport.To_Date = Convert.ToDateTime(txtTo_Date.Text);
                //Search by date
            }

            objdisplayreport.SpOperation = "SELECT";
            DataTable dt = new DataTable();
            dt = objdisplayreport.SaveDisplay();
            grdReport.DataSource = dt;
            grdReport.DataBind();


            if (dt.Rows.Count > 0)
            {
                grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdReport.UseAccessibleHeader = true;
            }

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
            }
        }

        protected void btnsearch(object sender, EventArgs e)
        {
            BindDisplayReport();
        }

    }
}