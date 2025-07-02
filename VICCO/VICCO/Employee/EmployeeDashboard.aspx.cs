using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VICCO.DAL;
using System.Data;
using System.Web.Services;

namespace VICCO.Employee
{
    public partial class EmployeeDashboard : System.Web.UI.Page

    {
        public void GetNotice()
        {
            try
            {
                Notice_Management objNotice = new Notice_Management();
                objNotice.SpOperation = "SELECT_SALE_NOTICE";
              
                DataTable dt = new DataTable();

                dt = objNotice.SaveNotice();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 1; i <= dt.Rows.Count; i++)
                    {
                        pnlNotice.Controls.Add(new LiteralControl("<div class='col-md-12'>"));
                        pnlNotice.Controls.Add(new LiteralControl("<p>" + dt.Rows[i - 1]["NOTICE_TEXT"] + "</p>"));
                        pnlNotice.Controls.Add(new LiteralControl("</div>"));
                        pnlNotice.Controls.Add(new LiteralControl(" <div class='clearfix'></div><hr />"));
                    }
                }
                else
                {
                    pnlNotice.Controls.Add(new LiteralControl("<div class='col-md-12'>"));
                    pnlNotice.Controls.Add(new LiteralControl("<p>Notice Board</p>"));
                    pnlNotice.Controls.Add(new LiteralControl("</div>"));
                    pnlNotice.Controls.Add(new LiteralControl(" <div class='clearfix'></div>"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetmonthlyValue()
        {
            EmployeeDashboardData objDetails = new EmployeeDashboardData();
            objDetails.EMPLOYEE_ID = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
            objDetails.SpOperation = "GET_CURRENT_MONTH_VALUE";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();

            if (dt.Rows.Count > 0)
            {
                lblcurrentmonthvalue.Text = Convert.ToInt32(dt.Rows[0]["VALUE"]).ToString("N0");
            }
        }

        public void GetCimulativeValue()
        {
            EmployeeDashboardData objDetails = new EmployeeDashboardData();
            objDetails.EMPLOYEE_ID = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
            objDetails.SpOperation = "GET_CIMULATIVE_SALE_VALUE";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();
            
            if (dt.Rows.Count > 0)
            {
                lblcurrentCimulativevalue.Text = Convert.ToInt64(dt.Rows[0]["VALUE"]).ToString("N0");
            }
        }

        public void GetMonthlyQuantityValue()
        {
            EmployeeDashboardData objDetails = new EmployeeDashboardData();
            objDetails.EMPLOYEE_ID = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
            objDetails.SpOperation = "GET_CURRENTMONTH_QTY_BY_PRODUCT";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();
            
            if (dt.Rows.Count > 0)
            {
                lblcurrentmonthqtyvalue.Text = Convert.ToInt64(dt.Rows[0]["QTY"]).ToString("N0");
            }
        }

        public void GetMonthlyCumulativeValue()
        {
            EmployeeDashboardData objDetails = new EmployeeDashboardData();
            objDetails.EMPLOYEE_ID = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
            objDetails.SpOperation = "GET_CUMULATIVE_QTY_VALUE";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();

            if (dt.Rows.Count > 0)
            {
                lblcurrentcumulativeqtyvalue.Text = Convert.ToInt64(dt.Rows[0]["QTY"]).ToString("N0");
            }
        }

        [WebMethod]
        public static List<object> GetProductValueLinechart()
        {

            EmployeeDashboardData objDetails = new EmployeeDashboardData();

            if (HttpContext.Current.Request.Cookies["EMP_ID"] != null)
            {
                objDetails.EMPLOYEE_ID = Convert.ToInt32(HttpContext.Current.Request.Cookies["EMP_ID"].Value);
            }

            objDetails.SpOperation = "GET_STATE_PRODUCT_VALUE";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();

            List<object>
                iData = new List<object>();
            foreach (DataColumn dc in dt.Columns)
            {
                List<object>
                    x = new List<object>
                        ();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }

            if (dt.Columns.Count < 5)
            {
                for (int i = 5; i > dt.Columns.Count; i--)
                {
                    List<object>
                   x = new List<object>
                       ();
                    x.Add(0);
                    iData.Add(x);
                }
            }

            return iData;
        }

        [WebMethod]
        public static List<object> GetProductQtyLinechart()
        {
            EmployeeDashboardData objDetails = new EmployeeDashboardData();         

            if (HttpContext.Current.Request.Cookies["EMP_ID"] != null)
            {
                objDetails.EMPLOYEE_ID = Convert.ToInt32(HttpContext.Current.Request.Cookies["EMP_ID"].Value);
            }

            objDetails.SpOperation = "GET_STATE_PRODUCT_QTY";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();

            List<object>
                iData = new List<object>();
            foreach (DataColumn dc in dt.Columns)
            {
                List<object>
                    x = new List<object>
                        ();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }

            if (dt.Columns.Count < 5)
            {
                for (int i = 5; i > dt.Columns.Count; i--)
                {
                    List<object>
                   x = new List<object>
                       ();
                    x.Add(0);
                    iData.Add(x);
                }
            }

            return iData;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["EMP_ID"] == null)
            {
                Response.Redirect("~/Employee/EmployeeLogin.aspx");
            }

            lblLoginName.Text = (Request.Cookies["EMP_NAME"].Value);
            GetNotice();
            GetmonthlyValue();
            GetCimulativeValue();
            GetMonthlyQuantityValue();
            GetMonthlyCumulativeValue();
        } 
    }
}