using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VICCO
{
    public partial class office : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            HttpCookie UserIDCookie = new HttpCookie("UserID");
            UserIDCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(UserIDCookie);

            HttpCookie UserNameCookie = new HttpCookie("UserName");
            UserNameCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(UserNameCookie);

            HttpCookie RollIDCookie = new HttpCookie("RollID");
            RollIDCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(RollIDCookie);

            HttpCookie EmailCookie = new HttpCookie("Email");
            EmailCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(EmailCookie);

            HttpCookie StockistCookie = new HttpCookie("Stockist");
            StockistCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(StockistCookie);

            Session["UserID"] = null;

            Response.Redirect("~/Index.aspx");
        }
    }
}