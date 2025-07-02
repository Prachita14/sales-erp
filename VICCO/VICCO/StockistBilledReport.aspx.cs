using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using VICCO.DAL;
using System.Data;
using System.IO;
using System.Drawing;
using Microsoft.Reporting.WebForms;

#endregion
namespace VICCO
{
    public partial class StockistBilledReport : System.Web.UI.Page
    {
        #region "public function"
       
        public void GetStockistBilledReport()
        {
            try
            {
                Report_management objReport = new Report_management();
              
                objReport.from_date = Convert.ToDateTime(txtFrom_Date.Text);
                objReport.To_date = Convert.ToDateTime(txtTo_Date.Text);
                objReport.SpOperation = "STOCKIST_BILLED_REPORT";
                DataTable dtReport = new DataTable();
                dtReport = objReport.GetReport();


                //Report Viewer-----------------------------------------
                ReportViewer1.AsyncRendering = false;
                ReportViewer1.SizeToReportContent = true;
                ReportViewer1.ZoomMode = ZoomMode.FullPage;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/StockistBilledReport.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();



                ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dtReport);
                ReportViewer1.LocalReport.DataSources.Add(_rsource1);
                ReportViewer1.LocalReport.Refresh();

                //End Viewer------------------------------------------------------

                if (dtReport.Rows.Count == 0)
                {
                    errorMsg.Visible = true;
                }
                else
                {
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
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            if (!IsPostBack)
            {
                txtFrom_Date.Text = Convert.ToDateTime("1 " + System.DateTime.Now.ToString("MMM yyyy")).ToString("yyyy-MM-dd");
                txtTo_Date.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetStockistBilledReport();
        }
    }
}