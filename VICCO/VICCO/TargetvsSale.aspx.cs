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
    public partial class TargetvsSale : System.Web.UI.Page
    {
        #region "Public Function"
     
        public void GetTargetReport()
        {
            try
            {
                TargetVsSaleReport objReport = new TargetVsSaleReport();

                if (auto_select3.SelectedItem.Text != "")
                {
                    objReport.from_date = Convert.ToDateTime("1 " + auto_select3.SelectedItem.Text + " " + auto_select6.SelectedItem.Text);
                }

                if (ddlReportWise.SelectedItem.Text == "Distributor")
                {
                    objReport.SpOperation = "TARGET_REPORT_DISTRIBUTOR";
                }

                if (ddlReportWise.SelectedItem.Text == "Stockist")
                {
                    objReport.SpOperation = "TARGET_REPORT_STOCKIST";
                }

                if (ddlReportWise.SelectedItem.Text == "SO")
                {
                    objReport.SpOperation = "TARGET_REPORT_S0";
                }

                if (ddlReportWise.SelectedItem.Text == "SR")
                {
                    objReport.SpOperation = "TARGET_REPORT_SR";
                }

                if (ddlReportWise.SelectedItem.Text == "ASM")
                {
                    objReport.SpOperation = "TARGET_REPORT_ASM";
                }

                if (ddlReportWise.SelectedItem.Text == "State Head")
                {
                    objReport.SpOperation = "TARGET_REPORT_STATE_HEAD";
                }

                if (ddlReportWise.SelectedItem.Text == "National Head")
                {
                    objReport.SpOperation = "TARGET_REPORT_NATION_HEAD";
                }


                DataTable dtReport = new DataTable();
                dtReport = objReport.GetReport();

                Session["DataSource"] = dtReport;

                //Report Viewer-----------------------------------------
                ReportViewer1.AsyncRendering = false;
                ReportViewer1.SizeToReportContent = true;
                ReportViewer1.ZoomMode = ZoomMode.FullPage;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/TargetVsSale.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                DataTable dtpara = new DataTable();

                dtpara.Columns.Add("FROM_DATE",typeof(System.String));
                //dtpara.Columns.Add("TO_DATE", typeof(System.String));

                DataRow dtrow =  dtpara.NewRow();
                dtrow["FROM_DATE"] = objReport.from_date.ToString("MMM yyyy");
                dtpara.Rows.Add(dtrow);
                //dtpara.Rows[0]["TO_DATE"] = objReport.from_date.ToString("MMM yyyy");

                //ReportParameter[] reportParameter = new ReportParameter[2];
                //reportParameter[0] = new ReportParameter("From_Date", objReport.from_date.ToString("MMM yyyy"));
                //reportParameter[1] = new ReportParameter("To_Date", objReport.from_date.ToString());
                //ReportViewer1.LocalReport.SetParameters(reportParameter);

                ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dtReport);
                ReportViewer1.LocalReport.DataSources.Add(_rsource1);

                ReportDataSource _rsource2 = new ReportDataSource("DataSet2", dtpara);
                ReportViewer1.LocalReport.DataSources.Add(_rsource2);

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

        #region "Event"

        public void Getyear()
        {
            var currentYear = DateTime.Today.Year;

            for (int i = currentYear + 1; i >= 2017; i--)
            {
                auto_select6.Items.Add((i).ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack)
            {
                auto_select3.SelectedItem.Text = System.DateTime.Now.ToString("MMM");
                auto_select3.SelectedItem.Value = System.DateTime.Now.ToString("MM");

                auto_select6.SelectedItem.Text = System.DateTime.Now.ToString("yyyy");

                //txtFromDate.Text = Convert.ToDateTime("1 " + System.DateTime.Now.ToString("MMM yyyy")).ToString("yyyy-MM-dd");
                //txttoDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                Getyear();
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

        protected void btnSearch_Report(object sender, EventArgs e)
        {           
            GetTargetReport();
        }

        #endregion
    }
}