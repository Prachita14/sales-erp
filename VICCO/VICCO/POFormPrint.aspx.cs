using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using VICCO.DAL.PURCHASE_ORDER;
using VICCO.DAL.PURCHASE_ORDER_PRODUCT;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using VICCO.DAL;
using YOGESH_INVOICE.DAL;
using Microsoft.Reporting.WebForms;
using System.Net.Mail;
using System.Net;

#endregion

namespace NewStarCity
{
    public partial class POFormPrint : System.Web.UI.Page
    {
        #region "Variable"

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        public void Get()
        {
            NoInWord obj = new NoInWord();

            ReportViewer1.SizeToReportContent = true;

            if (Convert.ToString(Request.QueryString["type"]) == "gst")
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Vicco.rdlc");
            }
            else
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ViccoIgst.rdlc");
            }

            Purches_Order_Management objPurchase = new Purches_Order_Management();
            objPurchase.Purchaseorder_Id = Convert.ToInt32(Request.QueryString["invoiceno"]);
            objPurchase.Sp_Operation = "GET_PURCHASE_ORDER_BY_PO";
            DataTable dt = new DataTable();
            dt = objPurchase.SaveUser();

            lblPurchaseorder_id.Text = Request.QueryString["invoiceno"];
            lbldistributor_id.Text = Convert.ToString(dt.Rows[0]["DISTRIBUTOR_ID"]);

            string amountinworld = obj.NumWordsWrapper(Convert.ToInt32(dt.Rows[0]["GRAND_TOTAL"]));

            dt.Columns.Add("TOTAL_IN_WORLD", typeof(System.String));

            dt.Rows[0]["TOTAL_IN_WORLD"] = amountinworld + " Rupees";


            Purches_Order_Product_Management objProduct = new Purches_Order_Product_Management();
            objProduct.PurchaseOrder_Id = Convert.ToInt32(Request.QueryString["invoiceno"]);
            objProduct.Sp_Operation = "GET_PRODUCT_REPORT_BY_PO";
            DataTable dt1 = new DataTable();
            dt1 = objProduct.SaveUser();

            int count = dt1.Rows.Count;

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(_rsource1);

            ReportDataSource _rsource = new ReportDataSource("DataSet2", dt1);
            ReportViewer1.LocalReport.DataSources.Add(_rsource);

            ReportViewer1.LocalReport.Refresh();

        }
        public void SendDistributorEmailSMS()
        {
            Distributor_Management objClient = new Distributor_Management();
            objClient.SpOperation = "SELECT_FOR_INVOICE";
            objClient.Distributor_id = Convert.ToInt32(lbldistributor_id.Text);
            DataTable dtClient = new DataTable();
            dtClient = objClient.SaveDistributor();

            if (dtClient.Rows.Count > 0)
            {
                if (Convert.ToString(dtClient.Rows[0]["EMAIL"]) != "")
                {
                    SendEmail(Convert.ToString(dtClient.Rows[0]["EMAIL"]), Convert.ToInt32(lblPurchaseorder_id.Text));
                }

                if (Convert.ToString(dtClient.Rows[0]["MOBILE_NUMBER"]) != "")
                {
                    string msg = "Dear Distributor, \n\nYour invoice has been generated at super stockiest point. please check your email for detailed invoice. \n\nThanks and Regards, \nVICCO Laboratories";

                    SendSMS objsms = new SendSMS();
                    objsms.SMSsent(Convert.ToString(dtClient.Rows[0]["MOBILE_NUMBER"]), msg);
                }
            }

        }
        public void SendEmail(string email, int purchaseorder_id)
        {
            if (email != "")
            {
                string body = "Dear Distributor, <br><br>Please fnd the attached copy of your invoice.<br>This is auto generated email, please do not reply to this email. In case of any query please contact your Super Stockiest or Nagpur Office.<br><br>Thanks and Regards,<br>VICCO Laboratories,<br>Secondary Distributor Portal Team";

                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("infodesk@viccolabs.com");
                mail.Attachments.Add(new Attachment(Server.MapPath("~/Invoices/" + purchaseorder_id + ".pdf")));
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Get();
            }

            Warning[] warnings;
            string[] streamIds;
            string mimeType = "application/pdf";
            string encoding = string.Empty;
            string extension = string.Empty;

            byte[] bytes = ReportViewer1.LocalReport.Render(
                "PDF",
                null,
                out mimeType,
                out encoding,
                out extension,
                out streamIds,
                out warnings);

            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;

            Response.AppendHeader("Content-Disposition", "inline; filename=vocco_invoice.pdf");

            using (var fs = new System.IO.FileStream(Server.MapPath("~/Invoices/" + Convert.ToInt32(Request.QueryString["invoiceno"]) + ".pdf"), System.IO.FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }


            if (Request.QueryString["email"] != null)
            {
                SendDistributorEmailSMS();
            }

            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.Flush();
            Response.End();


        }
    }
}