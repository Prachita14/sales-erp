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
    public partial class ViewEmployeeProfile : System.Web.UI.Page
    {
        public void GetEmployeeDetails()
        {
            try
            {
                Employee_master_management objempprofile = new Employee_master_management();
                objempprofile.EMP_ID = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
                objempprofile.SpOperation = "SELECT";
                DataTable dtUser = new DataTable();
                dtUser = objempprofile.SaveEmployee();

                if (dtUser.Rows.Count > 0)
                {
                    lblEmpName.Text = Convert.ToString(dtUser.Rows[0]["EMP_NAME"]);
                    lblEmail.Text = Convert.ToString(dtUser.Rows[0]["EMP_EMAIL"]);
                    lblcode.Text = Convert.ToString(dtUser.Rows[0]["EMP_CODE"]);
                    lbldate.Text = Convert.ToDateTime(dtUser.Rows[0]["JOINING_DATE"]).ToString("dd MMM yyyy");
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetEmployeeDetails();
        }
    }
}