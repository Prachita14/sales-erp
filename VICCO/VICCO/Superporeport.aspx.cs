using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using VICCO.DAL;
using System.Data;

#endregion

namespace VICCO
{
    public partial class Superporeport : System.Web.UI.Page
    {
        #region "Public Function"
       
        public void GetStockAlertHistory()
        {
            try
            {
                Super_Auto_GenratePO objStock = new Super_Auto_GenratePO();

                if (txtFromDate.Text != "")
                {
                    objStock.DATE = Convert.ToDateTime(txtFromDate.Text);
                }

                if (txttoDate.Text != "")
                {
                    objStock.TO_DATE = Convert.ToDateTime(txttoDate.Text);                }

               
                    objStock.STOCKIST_ID = Convert.ToInt32(Request.Cookies["Stockist"].Value);

                objStock.SP_OPERATION = "GET_PO";
                DataTable dt = new DataTable();
                dt = objStock.Getstock();

                grdReportNoExport.DataSource = dt;
                grdReportNoExport.DataBind();

                if (dt.Rows.Count == 0)
                {
                    errorMsg.Visible = true;
                }
                else
                {
                    grdReportNoExport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReportNoExport.UseAccessibleHeader = true;
                    errorMsg.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = Convert.ToDateTime("1 " + System.DateTime.Now.ToString("MMM yyyy")).ToString("yyyy-MM-dd");
                txttoDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
             
                GetStockAlertHistory();
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 2)
            {
                this.Page.MasterPageFile = "~/Stockist.master";
            }
            else if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 3)
            {
                this.Page.MasterPageFile = "~/office.master";
            }
            else if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 4)
            {
                this.Page.MasterPageFile = "~/Department.master";
            }
            else
            {
                this.Page.MasterPageFile = "~/Site1.master";
            }
        }       

        protected void btnSearch_Stockist(object sender, EventArgs e)
        {
            GetStockAlertHistory();
        }
    }
}