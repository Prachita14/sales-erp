using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VICCO.DAL;
using System.Data;
using StarCity.DAL.LOGIN_DETAILS;

namespace VICCO
{
    public partial class ViewAdminProfile : System.Web.UI.Page
    {
        public void GetAdminDetails()
        {
            try
            {
                LoginManagement objDetails = new LoginManagement();
                objDetails.Sp_Operation = "GET_LOGIN_DETAILS";
                DataTable dtDetails = new DataTable();
                dtDetails = objDetails.SaveUser();

                if (dtDetails.Rows.Count > 0)
                {
                    lblname.Text = Convert.ToString(dtDetails.Rows[0]["USER_NAME"]);
                    lblEmail.Text = Convert.ToString(dtDetails.Rows[0]["EMAIL_ID"]);
                    lblmobnumber.Text = Convert.ToString(dtDetails.Rows[0]["MOBILE_NO"]);
                    lblpassword.Text = Convert.ToString(dtDetails.Rows[0]["PASSWORD"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAdminDetails();
        }
    }
}