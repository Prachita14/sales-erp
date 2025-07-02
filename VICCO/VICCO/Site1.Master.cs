using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace RCandJJ
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {                      
            
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            ClearChromCache();
            HttpCookie UserIDCookie = new HttpCookie("UserID");
            UserIDCookie.Expires = DateTime.Now.AddDays(-5);
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

            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));

            Session["UserID"] = null;

            Response.Redirect("~/Index.aspx");
        }

        public void ClearChromCache()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }
    }
}