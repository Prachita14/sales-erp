using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces

using VICCO.DAL;
using System.Data;

#endregion

namespace VICCO
{
    public partial class Notice1 : System.Web.UI.Page
    {
        #region Public Function

        public void SaveNotice()
        {
            try
            {
                Notice_Management objNotice = new Notice_Management();
                objNotice.Notice_text = txtEditor.Text;
                //objNotice.Plain_text = Editor1.PlainText;

                if (chkStockist.Checked == true)
                {
                    objNotice.Is_Stockist = "Yes";
                }

                if (chkSales.Checked == true)
                {
                    objNotice.Is_Sales = "Yes";
                }

                objNotice.SpOperation = "INSERT";
                //objNotice.SaveNotice();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetNoticeReport()
        {
            try
            {
                Notice_Management objNotice = new Notice_Management();
                objNotice.SpOperation = "SELECT";
                DataTable dt = new DataTable();
                dt = objNotice.SaveNotice();

                grdNotice.DataSource = dt;
                grdNotice.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetNoticeReport();
            }
        }

        protected void grdNotice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdNotice.PageIndex = e.NewPageIndex;
            grdNotice.DataSource = Session["DataSource"];
            grdNotice.DataBind();
        }

        protected void btnSaveNotice(object sender, EventArgs e)
        {
            SaveNotice();
            GetNoticeReport();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
        }

        #endregion
    }
}