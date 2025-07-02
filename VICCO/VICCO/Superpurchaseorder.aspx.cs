using Microsoft.Reporting.WebForms;
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
    public partial class Superpurchaseorder : System.Web.UI.Page
    {
        public void Getmaterial()
        {
            S_Purchase_Order_Management objpo = new S_Purchase_Order_Management();
            objpo.STOCKIST_ID = Convert.ToInt32(Request.Cookies["Stockist"].Value);
            objpo.SP_OPERATION = "INSERT_FOR_PO";
            objpo.Savepo();

            objpo.SP_OPERATION = "GET_MATERIAL_FOR_PO";
            DataTable dtpo = new DataTable();
            dtpo = objpo.Savepo();

            grdPurchaseorder.DataSource = dtpo;
            grdPurchaseorder.DataBind();

            if (dtpo.Rows.Count > 0)
            {
                //errorMsg.Visible = false;
                //content.Visible = true;
                grdPurchaseorder.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdPurchaseorder.UseAccessibleHeader = true;
            }
            else
            {
                //errorMsg.Visible = true;
                //content.Visible = false;
            }
        }
        public void GetManualMaterial()
        {
            S_Purchase_Order_Management objpo = new S_Purchase_Order_Management();
            objpo.STOCKIST_ID = Convert.ToInt32(Request.Cookies["Stockist"].Value);            
            objpo.SP_OPERATION = "GET_MANUAL_MATERIAL";
            DataTable dtpo = new DataTable();
            dtpo = objpo.Savepo();

            grdManualProduct.DataSource = dtpo;
            grdManualProduct.DataBind();

            grdManualProduct.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdManualProduct.UseAccessibleHeader = true;
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
                SmtpClient smtp = new SmtpClient("mail.viccolabs.com", 25); //587
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("infodesk@viccolabs.com", "vicco@123");
                smtp.Send(mail);
            }
            
        }
        public void DeleteAutoMaterial()
        {
            S_Purchase_Order_Management objpo = new S_Purchase_Order_Management();
            objpo.STOCKIST_ID= Convert.ToInt32(Request.Cookies["Stockist"].Value);
            objpo.SP_OPERATION = "MANUALY_DELETE_ALL";
            objpo.Savepo();
        }
        public void InsertManualMaterial(int id,int material_id,int qty)
        {
            S_Purchase_Order_Management objpo = new S_Purchase_Order_Management();
            objpo.STOCKIST_ID = Convert.ToInt32(Request.Cookies["Stockist"].Value);
            objpo.ID = id;
            objpo.MATERIAL_ID = material_id;
            objpo.PO_QTY = qty;
            objpo.SP_OPERATION = "MANUALY_INSERT";
            objpo.Savepo();
        }
        public void RemoveManualMaterial(int id)
        {
            S_Purchase_Order_Management objpo = new S_Purchase_Order_Management();
            objpo.ID = id;
            objpo.SP_OPERATION = "MANUALY_DELETE";
            objpo.Savepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime serverTime = DateTime.Now;
                DateTime utcTime = serverTime.ToUniversalTime();
                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                string s = localTime.ToString("dd MMM yyy");
                txtCalender.Text = s;

                Getmaterial();
                DeleteAutoMaterial();
                GetManualMaterial();
            }
        }
        protected void grdManualProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                DropDownList ddlProduct = (e.Row.FindControl("auto_selectProduct") as DropDownList);              

                Label lblProductName = (e.Row.FindControl("lblProductName") as Label);
                Label lblProduct_id = (e.Row.FindControl("lblProduct_id") as Label);

                if (Session["Material_List"] == null)
                {
                    Material_management objMaterial = new Material_management();
                    objMaterial.SpOperation = "SELECT";
                    DataTable dtMaterial = new DataTable();
                    dtMaterial = objMaterial.SaveMaterial();
                    Session["Material_List"] = dtMaterial;
                }

                ddlProduct.DataSource = Session["Material_List"];
                ddlProduct.DataValueField = "MATERIAL_ID";
                ddlProduct.DataTextField = "MATERIAL_DESCREPTION";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("Select Product ", "0"));

                if (lblProduct_id.Text != "")
                {
                    ddlProduct.ClearSelection();
                    ddlProduct.Items.FindByValue(lblProduct_id.Text).Selected = true;
                    //txtAvalibaleQty.Text = GetAvailableStock(Convert.ToInt32(lblProduct_id.Text));
                }
            }
        }
        protected void ProductContent_TextChange(object sender, EventArgs e)
        {
            try
            {
                int selRowIndex = ((GridViewRow)(((DropDownList)sender).Parent.Parent)).RowIndex;
                string id = grdManualProduct.DataKeys[selRowIndex].Value.ToString();
                GridViewRow row = grdManualProduct.Rows[selRowIndex];

                DropDownList Product_id = (row.FindControl("auto_selectProduct") as DropDownList);
                TextBox txtqty = (row.FindControl("txtQty") as TextBox);

                if (txtqty.Text == "")
                {
                    txtqty.Text = "0";
                }
                
                int p_id = 0;

                if (Product_id.SelectedItem.Value != "0")
                {
                    p_id = Convert.ToInt32(Product_id.SelectedItem.Value);
                }

                int quantity = Convert.ToInt32(txtqty.Text);

                InsertManualMaterial(Convert.ToInt32(id), p_id, quantity);
                GetManualMaterial();
            }
            catch (Exception ex)
            {
                throw ex;
                //ExceptionLog.WriteErrorLog(ex);
            }
        }
        protected void Content_TextChange(object sender, EventArgs e)
        {
            try
            {
                int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
                string id = grdManualProduct.DataKeys[selRowIndex].Value.ToString();
                GridViewRow row = grdManualProduct.Rows[selRowIndex];

                DropDownList Product_id = (row.FindControl("auto_selectProduct") as DropDownList);
                TextBox txtqty = (row.FindControl("txtQty") as TextBox);

                if (txtqty.Text == "")
                {
                    txtqty.Text = "0";
                }

                int p_id = 0;

                if (Product_id.SelectedItem.Value != "0")
                {
                    p_id = Convert.ToInt32(Product_id.SelectedItem.Value);
                }

                int quantity = Convert.ToInt32(txtqty.Text);

                InsertManualMaterial(Convert.ToInt32(id), p_id, quantity);
                GetManualMaterial();
            }
            catch (Exception ex)
            {
                throw ex;
                //ExceptionLog.WriteErrorLog(ex);
            }
        }
        protected void RemoveProduct(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdManualProduct.DataKeys[selRowIndex].Value.ToString();
            RemoveManualMaterial(Convert.ToInt32(id));
            GetManualMaterial();        
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            S_Purchase_Order_Management objpo = new S_Purchase_Order_Management();
            objpo.STOCKIST_ID = Convert.ToInt32(Request.Cookies["Stockist"].Value);
            objpo.SP_OPERATION = "UPDATE_ALL";
            objpo.Savepo();
            
            objpo = new S_Purchase_Order_Management();
            objpo.STOCKIST_ID = Convert.ToInt32(Request.Cookies["Stockist"].Value);
            objpo.SP_OPERATION = "SEND_PO";
            DataTable dtpo = new DataTable();
            dtpo = objpo.Savepo();

            if (dtpo.Rows.Count > 0)
            {
                foreach (GridViewRow gvrow in grdPurchaseorder.Rows)
                {                   
                    Label lblProduct_id = (gvrow.FindControl("lblProduct_id") as Label);
                    TextBox txtQty = (gvrow.FindControl("txtQty") as TextBox);

                    objpo.MATERIAL_ID = Convert.ToInt32(lblProduct_id.Text);
                    objpo.PO_QTY = Convert.ToInt32(txtQty.Text);
                    objpo.STOCKIST_ID = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                    objpo.SPURCHASEORDER_ID = Convert.ToInt32(dtpo.Rows[0]["SPURCHASEORDER_ID"]);
                    objpo.SP_OPERATION = "INSERT_PO_QTY";
                    objpo.Savepo();
                }

                grdPurchaseorder.DataSource = null;
                grdPurchaseorder.DataBind();

                objpo = new S_Purchase_Order_Management();
                objpo.SPURCHASEORDER_ID = Convert.ToInt32(dtpo.Rows[0]["SPURCHASEORDER_ID"]);
                objpo.SP_OPERATION = "GET_PO";
                dtpo = new DataTable();
                dtpo = objpo.Savepo();

                NoInWord obj = new NoInWord();
                string amountinworld = obj.NumWordsWrapper(Convert.ToInt32(dtpo.Rows[0]["GRAND_TOTAL"]));
                dtpo.Columns.Add("TOTAL_IN_WORD", typeof(System.String));
                dtpo.Rows[0]["TOTAL_IN_WORD"] = amountinworld + " Rupees";

                objpo = new S_Purchase_Order_Management();
                objpo.SPURCHASEORDER_ID = Convert.ToInt32(dtpo.Rows[0]["SPURCHASEORDER_ID"]);
                objpo.SP_OPERATION = "GET_PO_PRODUCT";
                DataTable dtProduct = new DataTable();
                dtProduct = objpo.Savepo();

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

                string filename = Convert.ToInt32(Request.Cookies["Stockist"].Value) + "_" + System.DateTime.Now.ToString("ddMMyyyyhhmm.") + extension;

                using (var fs = new System.IO.FileStream(Server.MapPath("~/AutoGenratedPO/" + filename), System.IO.FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }

                //SendEmail(" manjusha@viccolabs.com", filename);

                //manjusha@viccolabs.com

                objpo = new S_Purchase_Order_Management();
                objpo.STOCKIST_ID = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                objpo.SP_OPERATION = "UPDATE_FOR_MAIL_SENDED";
                objpo.Savepo();


                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessMsg();</script>");
            }
        }
    }
}