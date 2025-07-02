using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VICCO
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string body = "Dear Distributor, <br><br>Please fnd the attached copy of your invoice.<br>This is auto generated email, please do not reply to this email. In case of any query please contact your Super Stockiest or Nagpur Office.<br><br>Thanks and Regards,<br>VICCO Laboratories,<br>Secondary Distributor Portal Team";

            MailMessage mail = new MailMessage();
            mail.To.Add("ajyaul96@gmail.com");
            mail.From = new MailAddress("infodesk@viccolabs.com");
            // mail.Attachments.Add(new Attachment(Server.MapPath("~/Invoices/" + purchaseorder_id + ".pdf")));
            mail.Subject = "Invoice created";
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("infodesk@viccolabs.com", "Sanket@123");
            smtp.Send(mail);
        }
    }
}