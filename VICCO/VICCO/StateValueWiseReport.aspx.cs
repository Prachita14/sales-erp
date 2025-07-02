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
    public partial class StateValueWiseReport : System.Web.UI.Page
    {
        #region "Public Function"      

        public void Getyear()
        {
            var currentYear = DateTime.Today.Year;

            for (int i = currentYear + 1; i >= 2017; i--)
            {
                auto_select6.Items.Add((i).ToString());
            }
        }

        public void StateAndValueWiseReport()
        {
            try
            {
                Office_Report_Management objReport = new Office_Report_Management();

                objReport.from_date = Convert.ToDateTime("1 Apr" + auto_select6.SelectedItem.Text);

                if (auto_select3.SelectedItem.Text != "Select Month")
                {
                    DateTime date =(Convert.ToDateTime("1 " + auto_select3.SelectedItem.Text + " " + auto_select6.SelectedItem.Text).AddMonths(1)).AddDays(-1);
                    objReport.To_date = date;
                }
                else
                {
                    objReport.To_date = Convert.ToDateTime("31 Mar " + auto_select6.SelectedItem.Text);
                }                

                objReport.SpOperation = "STATE_VALUE_WISE_SECONDARY_REPORT";
                DataTable dtReport = new DataTable();
                dtReport = objReport.GetReport();
               

                //Report Viewer-----------------------------------------
                ReportViewer1.AsyncRendering = false;
                ReportViewer1.SizeToReportContent = true;
                ReportViewer1.ZoomMode = ZoomMode.FullPage;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/StateAndValueWiseReport.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportParameter para3 = new ReportParameter("FROM_DATE2", "");
                ReportParameter para5;
                if (dtReport.Rows.Count > 0)
                {
                    para5 = new ReportParameter("FROM_DATE3", Convert.ToString(dtReport.Rows[0]["YEAR_NAME"]));
                }
                else
                {
                    para5 = new ReportParameter("FROM_DATE3", "");
                }
                ReportParameter para6 = new ReportParameter("MONTH", objReport.To_date.ToString("MMM"));

                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { para3, para5, para6 });

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
                Getyear();
            }
        }

        protected void btnSearch_Report(object sender, EventArgs e)
        {
            StateAndValueWiseReport();
        }

        #endregion

    }
}