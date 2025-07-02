using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using VICCO.DAL;

#endregion

namespace VICCO.Employee
{
    public partial class EmployeeLogin : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void Login()
        {
            try
            {
                Employee_master_management objEmp = new Employee_master_management();
                objEmp.EMP_EMAIL = txtEmail.Text;
                objEmp.EMP_PASSWORD = txtPass.Text;
                objEmp.SpOperation = "LOGIN";
                DataTable dtUser = new DataTable();
                dtUser = objEmp.SaveEmployee();


                if (Convert.ToString(dtUser.Rows[0]["ERRORMESSAGE"]) == "")
                {
                    HttpCookie UserIDCookie = new HttpCookie("EMP_ID");
                    UserIDCookie.Value = Convert.ToString(dtUser.Rows[0]["EMP_ID"]);
                    UserIDCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(UserIDCookie);

                    HttpCookie UserNameCookie = new HttpCookie("EMP_NAME");
                    UserNameCookie.Value = Convert.ToString(dtUser.Rows[0]["EMP_NAME"]);
                    UserNameCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(UserNameCookie);

                    HttpCookie EmailCookie = new HttpCookie("EMP_EMAIL");
                    EmailCookie.Value = txtEmail.Text;
                    EmailCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(EmailCookie);

                    Response.Redirect("EmployeeDashboard.aspx");
                }
                else
                {
                    lblError.Text = Convert.ToString(dtUser.Rows[0]["ERRORMESSAGE"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Event"

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        #endregion
    }
}