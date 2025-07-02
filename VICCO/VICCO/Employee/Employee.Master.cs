using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VICCO.DAL;
using System.Data;

namespace VICCO.Employee
{
    public partial class Employee : System.Web.UI.MasterPage
    {

        public void GetEmployeeDetails()
        {
            try
            {
                Employee_master_management objEmployee = new Employee_master_management();
                objEmployee.EMP_ID = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
                objEmployee.SpOperation = "SELECT";
                DataTable dtEmp = new DataTable();
                dtEmp = objEmployee.SaveEmployee();

                if (dtEmp.Rows.Count > 0)
                {
                    if (Convert.ToString(dtEmp.Rows[0]["POSITION"]) == "SO")
                    {
                        DistributorSale.Visible = true;
                        Target.Visible = true;
                    }
                    if (Convert.ToString(dtEmp.Rows[0]["POSITION"]) == "SR")
                    {
                        TargetReport.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEmployeeDetails();
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            HttpCookie UserIDCookie = new HttpCookie("EMP_ID");
            UserIDCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(UserIDCookie);

            HttpCookie stokistCookieCookie = new HttpCookie("Stockist");
            stokistCookieCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(stokistCookieCookie);

            Response.Redirect("~/Employee/EmployeeLogin.aspx");
        }
    }
}