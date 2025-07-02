﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using StarCity.DAL.LOGIN_DETAILS;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;

#endregion

namespace RCandJJ
{
    public partial class Index : System.Web.UI.Page
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
                LoginManagement objUser = new LoginManagement();
                objUser.Email_Id = txtEmail.Text;
                objUser.Password = txtPass.Text;
                objUser.Sp_Operation = "LOGIN_USER";
                DataTable dtUser = new DataTable();
                dtUser = objUser.SaveUser();


                if (Convert.ToString(dtUser.Rows[0]["ERRORMESSAGE"]) == "")
                {
                    HttpCookie UserIDCookie = new HttpCookie("UserID");
                    UserIDCookie.Value = Convert.ToString(dtUser.Rows[0]["USER_ID"]);
                    UserIDCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(UserIDCookie);

                    HttpCookie UserNameCookie = new HttpCookie("UserName");
                    UserNameCookie.Value = Convert.ToString(dtUser.Rows[0]["USER_NAME"]);
                    UserNameCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(UserNameCookie);                   

                    HttpCookie RollIDCookie = new HttpCookie("RollID");
                    RollIDCookie.Value = Convert.ToString(dtUser.Rows[0]["Roll_Id"]);
                    RollIDCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(RollIDCookie);

                    HttpCookie EmailCookie = new HttpCookie("Email");
                    EmailCookie.Value = txtEmail.Text;
                    EmailCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(EmailCookie);

                    HttpCookie StockistCookie = new HttpCookie("Stockist");
                    StockistCookie.Value = Convert.ToString(dtUser.Rows[0]["STOCKIST_ID"]);
                    StockistCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(StockistCookie);

                    if (Convert.ToString(dtUser.Rows[0]["Roll_Id"]) != "2")
                    {
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        Response.Redirect("StockistDashboard.aspx");
                    }
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