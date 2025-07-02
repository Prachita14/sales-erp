using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Name spaces"

using VICCO.DAL;
using System.Data;
using System.IO;
using System.Drawing;
using Microsoft.Reporting.WebForms;

#endregion

namespace VICCO
{
    public partial class ProductStateWiseReportQtyNew : System.Web.UI.Page
    {
        #region "Public Function"
        public void BindMaterialName()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.SpOperation = "SELECT_ONLY_GROUP";
            DataTable dtMaterial = new DataTable();
            dtMaterial = objMaterial.SaveMaterial();

            auto_select1.DataSource = dtMaterial;
            auto_select1.DataValueField = "MATERIAL_GROUP";
            auto_select1.DataTextField = "MATERIAL_GROUP";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Material Name", "0"));
        }
        public void Getyear()
        {
            var currentYear = DateTime.Today.Year;

            for (int i = currentYear + 1; i >= 2017; i--)
            {
                auto_select6.Items.Add((i).ToString());
            }
        }
        public void ProductAndStateWiseReport()
        {
            try
            {
                Office_Report_Management objReport = new Office_Report_Management();


                objReport.from_date = Convert.ToDateTime("1 Apr " + auto_select6.SelectedItem.Text);
                objReport.To_date = Convert.ToDateTime("1 " + auto_select3.SelectedItem.Text + " " + auto_select6.SelectedItem.Text);

                objReport.MATERIAL_GROUP = auto_select1.SelectedItem.Text;

                objReport.SpOperation = "PRODUCT_STATE_WISE_SECONDARY_QUANTITY_REPORT_NEW";
                DataTable dtReport = new DataTable();
                dtReport = objReport.GetReport();

                Session["DataSource"] = dtReport;

                //Report Viewer-----------------------------------------
                ReportViewer1.AsyncRendering = false;
                ReportViewer1.SizeToReportContent = true;
                ReportViewer1.ZoomMode = ZoomMode.FullPage;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/ProductAndStateWiseReportNew.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();

                DataTable dt = new DataTable();
                dt.Columns.Add("Title");

                DataRow title = dt.NewRow();
                title["Title"] = "PRODUCT & STATE-WISE SECONDARY REPORT (QTY) " + auto_select1.SelectedItem.Text;
                dt.Rows.Add(title);

                //ReportParameter para1 = new ReportParameter("TITLE", "PRODUCT & STATE-WISE SECONDARY REPORT (VALUE) " + auto_select1.SelectedItem.Text);
                //ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { para1 });

                ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dtReport);
                ReportViewer1.LocalReport.DataSources.Add(_rsource1);

                ReportDataSource _rsource2 = new ReportDataSource("DataSet2", dt);
                ReportViewer1.LocalReport.DataSources.Add(_rsource2);

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
                BindMaterialName();
            }
        }

        protected void btnSearch_Report(object sender, EventArgs e)
        {
            ProductAndStateWiseReport();
        }


        #endregion
    }
}