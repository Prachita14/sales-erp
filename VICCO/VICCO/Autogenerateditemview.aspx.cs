﻿using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VICCO.DAL;
using YOGESH_INVOICE.DAL;

namespace VICCO
{
    public partial class Autogenerateditemview : System.Web.UI.Page
    {
        public void Getpoitems()
        {
            try
            {
                Super_Auto_GenratePO objStock = new Super_Auto_GenratePO();
                objStock.IS_NOT_GENERATE = "TRUE";
                objStock.STOCKIST_ID = Convert.ToInt32(Request.QueryString["sid"]);
                objStock.SP_OPERATION = "GET_FOR_PO_PRODUCT";
                DataTable dt = new DataTable();
                dt = objStock.Getstock();

                grdReport.DataSource = objStock.Getstock();
                grdReport.DataBind();

                if (dt.Rows.Count == 0)
                {
                    errorMsg.Visible = true;
                }
                else
                {
                    lblSupperName.Text = Convert.ToString(dt.Rows[0]["STOCKIST_NAME"]);
                    lblMaterialCount.Text = "Total Material Count:" + dt.Rows.Count.ToString();
                    errorMsg.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveProduct(int id)
        {
            try
            {
                Super_Auto_GenratePO objStock = new Super_Auto_GenratePO();
                objStock.ID = id;
                objStock.IS_NOT_GENERATE = "FALSE";
                objStock.SP_OPERATION = "UPDATE";
                objStock.Getstock();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SendEmail(string email, string filename)
        {
            if (email != "")
            {
                string body = "Dear All, <br><br>Please find the attached copy of Auto generated Purchase Order.<br><br>Thanks and Regards,<br>VICCO Laboratories,<br>Secondary Distributor Portal Team";

                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("infodesk@viccolabs.com");
                mail.Attachments.Add(new Attachment(Server.MapPath("~/AutoGenratedPO/" + filename)));
                mail.Subject = "Purchase Order generated";
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
                Getpoitems();
            }
        }

        protected void RemoveProduct(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdReport.DataKeys[selRowIndex].Value.ToString();
            RemoveProduct(Convert.ToInt32(id));
            Getpoitems();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Super_Auto_GenratePO objStock = new Super_Auto_GenratePO();
            foreach (GridViewRow gvrow in grdReport.Rows)
            {
                string id = grdReport.DataKeys[gvrow.RowIndex].Value.ToString();
                objStock.ID = Convert.ToInt32(id);
                objStock.IS_NOT_GENERATE = "True";
                objStock.SP_OPERATION = "UPDATE";
                objStock.Getstock();
            }

            grdReport.DataSource = null;
            grdReport.DataBind();
            lblSuccess.Text = "PO Created Successfully and Sended to Mail...";

            objStock = new Super_Auto_GenratePO();
            objStock.STOCKIST_ID = Convert.ToInt32(Request.QueryString["sid"]);
            objStock.SP_OPERATION = "SEND_PO";
            DataTable dtpo = new DataTable();
            dtpo = objStock.Getstock();

            NoInWord obj = new NoInWord();
            string amountinworld = obj.NumWordsWrapper(Convert.ToInt32(dtpo.Rows[0]["GRAND_TOTAL"]));
            dtpo.Columns.Add("TOTAL_IN_WORD", typeof(System.String));
            dtpo.Rows[0]["TOTAL_IN_WORD"] = amountinworld + " Rupees";

            objStock = new Super_Auto_GenratePO();
            objStock.SPURCHASEORDER_ID = Convert.ToInt32(dtpo.Rows[0]["SPURCHASEORDER_ID"]);
            objStock.SP_OPERATION = "GET_PO_PRODUCT";
            DataTable dtProduct = new DataTable();
            dtProduct = objStock.Getstock();

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/AutoGenerateStockistPO.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dtpo);
            ReportViewer1.LocalReport.DataSources.Add(_rsource1);

            ReportDataSource _rsource2 = new ReportDataSource("DataSet2", dtProduct);
            ReportViewer1.LocalReport.DataSources.Add(_rsource2);

            ReportViewer1.LocalReport.Refresh();

            Warning[] warnings;
            string[] streamIds;
            string mimeType;
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

            //Response.Buffer = true;
            //Response.Clear();
            //Response.ContentType = mimeType;

            //Response.AppendHeader("Content-Disposition", "inline; filename=vocco_invoice.xlsx");

            string filename = Convert.ToInt32(Request.QueryString["sid"]) + "_" + System.DateTime.Now.ToString("ddMMyyyyhhmm.") + extension;

            using (var fs = new System.IO.FileStream(Server.MapPath("~/AutoGenratedPO/" + filename), System.IO.FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }

            SendEmail("orders@viccolabs.com ", filename);

            //manjusha@viccolabs.com

            objStock = new Super_Auto_GenratePO();
            objStock.STOCKIST_ID = Convert.ToInt32(Request.QueryString["sid"]);
            objStock.SP_OPERATION = "UPDATE_FOR_MAIL_SENDED";
            objStock.Getstock();

            Button1.Visible = false;

        }
    }
}