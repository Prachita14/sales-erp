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
    public partial class ProductValueWiseReport : System.Web.UI.Page
    {
        #region "Public Function"
        public void BindRegion()
        {
            try
            {
                Region_Management objRegion = new Region_Management();
                ddlRegion.DataSource = objRegion.GetRegion();
                ddlRegion.DataTextField = "REGION_NAME";
                ddlRegion.DataValueField = "REGION_ID";
                ddlRegion.DataBind();
                ddlRegion.Items.Insert(0, new ListItem("All Region", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Getyear()
        {
            var currentYear = DateTime.Today.Year;

            for (int i = currentYear + 1; i >= 2017; i--)
            {
                auto_select6.Items.Add((i).ToString());
            }
        }

        public void ProductAndValueWiseReport()
        {
            try
            {
                Office_Report_Management objReport = new Office_Report_Management();

                //objReport.from_date = Convert.ToDateTime("1 Apr" + auto_select6.SelectedItem.Text);
                //objReport.To_date = Convert.ToDateTime("31 Mar" + auto_select6.SelectedItem.Text);

                if (ddlRegion.SelectedItem.Text != "All Region")
                {
                    objReport.REGION = ddlRegion.SelectedItem.Text;
                }

                objReport.from_date = Convert.ToDateTime("1 Apr " + auto_select6.SelectedItem.Text);
                objReport.To_date = Convert.ToDateTime("1 " + auto_select3.SelectedItem.Text + " " + auto_select6.SelectedItem.Text);

                objReport.SpOperation = "PRODUCT_VALUE_WISE_SECONDARY_REPORT";
                DataTable dtReport = new DataTable();
                dtReport = objReport.GetReport();
                //grdSaleStockReport.DataSource = dtReport;
                //grdSaleStockReport.DataBind();

                Session["DataSource"] = dtReport;

                //Report Viewer-----------------------------------------
                ReportViewer1.AsyncRendering = false;
                ReportViewer1.SizeToReportContent = true;
                ReportViewer1.ZoomMode = ZoomMode.FullPage;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ProductAndValueWiseReport.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportParameter para1 = new ReportParameter("TITLE", "PRODUCT AND VALUE WISE SECONDARY REPORT" + "(" + ddlRegion.SelectedItem.Text + ")");
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { para1 });

                ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dtReport);
                ReportViewer1.LocalReport.DataSources.Add(_rsource1);
                ReportViewer1.LocalReport.Refresh();

                //End Viewer------------------------------------------------------

                if (dtReport.Rows.Count == 0)
                {
                    errorMsg.Visible = true;
                    //btnExport.Visible = false;
                }
                else
                {
                    errorMsg.Visible = false;
                    //btnExport.Visible = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Event"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            if (!IsPostBack)
            {
                BindRegion();
                Getyear();
            }
        }

        protected void btnSearch_Report(object sender, EventArgs e)
        {
            ProductAndValueWiseReport();
        }

        #endregion
    }
}