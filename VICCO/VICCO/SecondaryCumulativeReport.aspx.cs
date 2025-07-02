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
    public partial class SecondaryCumulativeReport : System.Web.UI.Page
    {        
       #region "Public Function"     
 
        public void BindMaterialName()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.SpOperation = "SELECT_ONLY_GROUP";
            DataTable dtMaterial = new DataTable();
            dtMaterial = objMaterial.SaveMaterial();

            auto_select4.DataSource = dtMaterial;
            auto_select4.DataValueField = "MATERIAL_GROUP";
            auto_select4.DataTextField = "MATERIAL_GROUP";
            auto_select4.DataBind();
            auto_select4.Items.Insert(0, new ListItem("Material Name", "0"));
        }

        public void BindRegion()
        {
            try
            {
                Region_Management objRegion = new Region_Management();
                auto_select1.DataSource = objRegion.GetRegion();
                auto_select1.DataTextField = "REGION_NAME";
                auto_select1.DataValueField = "REGION_ID";
                auto_select1.DataBind();
                auto_select1.Items.Insert(0, new ListItem("All India", "0"));
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

        public void GetCumulativeReport()
        {
            try
            {
                Office_Report_Management objReport = new Office_Report_Management();

                if (auto_select1.SelectedItem.Text != "All India")
                {
                    objReport.REGION = auto_select1.SelectedItem.Text;
                }

                if (auto_select3.SelectedItem.Text != "Select Month")
                {
                    objReport.MONTH = auto_select3.SelectedItem.Value;
                }
                else
                {
                    objReport.MONTH = "12";
                }

                if (auto_select4.SelectedItem.Text != "Material Name")
                {
                    objReport.MATERIAL_GROUP = auto_select4.SelectedItem.Text;
                }
                objReport.To_date = Convert.ToDateTime("31 Mar" + auto_select6.SelectedItem.Text);
                objReport.from_date = Convert.ToDateTime("1 Apr" + auto_select6.SelectedItem.Text);


                objReport.SpOperation = "SECONDARY_CUMULATIVE_REPORT";
                DataTable dtReport = new DataTable();
                dtReport = objReport.GetReport();
               

                //Report Viewer-----------------------------------------
                ReportViewer1.AsyncRendering = false;
                ReportViewer1.SizeToReportContent = true;
                ReportViewer1.ZoomMode = ZoomMode.FullPage;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/SecondaryCumulativeReport.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportParameter para1 = new ReportParameter("FROM_DATE1", objReport.from_date.AddYears(-2).ToString("yy"));
                ReportParameter para2 = new ReportParameter("TO_DATE1", objReport.from_date.AddYears(-1).ToString("yy"));
                ReportParameter para3 = new ReportParameter("FROM_DATE2", objReport.from_date.AddYears(-1).ToString("yy"));
                ReportParameter para4 = new ReportParameter("TO_DATE2", objReport.from_date.ToString("yy"));
                ReportParameter para5 = new ReportParameter("FROM_DATE3", objReport.from_date.ToString("yy"));
                ReportParameter para6 = new ReportParameter("TO_DATE3", objReport.from_date.AddYears(1).ToString("yy"));
                ReportParameter para7 = new ReportParameter("REGION", auto_select1.SelectedItem.Text);

                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { para1, para2, para3, para4, para5, para6, para7 });

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
                BindMaterialName();
                Getyear();
                BindRegion();
            }

        }

        protected void btnSearch_Report(object sender, EventArgs e)
        {
            GetCumulativeReport();
        }

        #endregion

        }
}