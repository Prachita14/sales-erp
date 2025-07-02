using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using VICCO.DAL;
using System.Data;

namespace VICCO
{
    public partial class Price_list : System.Web.UI.Page
    {

        #region "Public Function"

        public void GetPriceList()
        {
            try
            {
                PriceList_Management objPriceList = new PriceList_Management();
                objPriceList.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                objPriceList.SpOperation = "INSERT";
                objPriceList.SavePriceList();

                PriceList_Management objPriceList1 = new PriceList_Management();
                objPriceList1.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                objPriceList1.SpOperation = "SELECT";
                DataTable dtPriceList = new DataTable();
                dtPriceList=objPriceList1.SavePriceList();

                grdReport1.DataSource = dtPriceList;
                grdReport1.DataBind();

                grdReport1.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdReport1.UseAccessibleHeader = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Public Function"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            if (!IsPostBack)
            {
                GetPriceList();
            }
        }

        protected void Content_TextChange(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((Button)sender).Parent.Parent)).RowIndex;
            string id = grdReport1.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdReport1.Rows[selRowIndex];

            TextBox txtRate = (row.FindControl("txtRate") as TextBox);
            TextBox txtScheme = (row.FindControl("txtScheme") as TextBox);
            TextBox txtDisscount = (row.FindControl("txtDisscount") as TextBox);
            TextBox txtMrp = (row.FindControl("txtMrp") as TextBox);

            if (txtRate.Text == "")
            {
                txtRate.Text = "0";
            }

            if (txtScheme.Text == "")
            {
                txtScheme.Text = "0";
            }

            if (txtDisscount.Text == "")
            {
                txtDisscount.Text = "0";
            }

            if (txtMrp.Text == "")
            {
                txtMrp.Text = "0";
            }

            PriceList_Management objPriceList = new PriceList_Management();
            objPriceList.price_id = Convert.ToInt32(id);
            objPriceList.rate = Convert.ToDouble(txtRate.Text);
            objPriceList.scheme = Convert.ToDouble(txtScheme.Text);
            objPriceList.disscount = Convert.ToDouble(txtDisscount.Text);
            objPriceList.Mrp = Convert.ToDouble(txtMrp.Text);
            objPriceList.SpOperation = "UPDATE";
            objPriceList.SavePriceList();

            grdReport1.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdReport1.UseAccessibleHeader = true;

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
                       
        }

        #endregion
    }
}