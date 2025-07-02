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
    public partial class HeadReport : System.Web.UI.Page
    {
        #region "Public Function"

        public void BindMaterialName()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.SpOperation = "SELECT";
            DataTable dtMaterial = new DataTable();
            dtMaterial = objMaterial.SaveMaterial();

            auto_select1.DataSource = dtMaterial;
            auto_select1.DataValueField = "MATERIAL_ID";
            auto_select1.DataTextField = "MATERIAL_DESCREPTION";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Material Name", "0"));
        }

        public void GetTargetReport()
        {
            try
            {
                Report_management objReport = new Report_management();

                if (txtFromDate.Text != "")
                {
                    objReport.from_date = Convert.ToDateTime(txtFromDate.Text);
                }

                if (txttoDate.Text != "")
                {
                    objReport.To_date = Convert.ToDateTime(txttoDate.Text);
                }

                if (auto_select1.SelectedIndex != -1)
                {
                    objReport.Material_ids = hdMaterialId.Value;
                }

                if (auto_select2.SelectedItem.Text != "All Region")
                {
                    objReport.Region = auto_select2.SelectedItem.Text;
                }

                objReport.SpOperation = "HEAD_REPORT";

                DataTable dtReport = new DataTable();
                dtReport = objReport.GetReport();

                Session["DataSource"] = dtReport;

                if (txtFromDate.Text != "")
                {
                    objReport.from_date = Convert.ToDateTime(txtFromDate.Text);
                }

                if (txttoDate.Text != "")
                {
                    objReport.To_date = Convert.ToDateTime(txttoDate.Text);
                }

                if (auto_select1.SelectedIndex != -1)
                {
                    objReport.Material_ids = hdMaterialId.Value;
                }

                objReport.SpOperation = "HEAD_REPORT";
                objReport.Region ="" ;

                DataTable dtReport1 = new DataTable();
                dtReport1 = objReport.GetReport();
                

             

                //Report Viewer-----------------------------------------
                ReportViewer1.AsyncRendering = false;
                ReportViewer1.SizeToReportContent = true;
                ReportViewer1.ZoomMode = ZoomMode.FullPage;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/HeadReport.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dtReport);
                ReportViewer1.LocalReport.DataSources.Add(_rsource1);

                ReportDataSource _rsource2 = new ReportDataSource("DataSet2", dtReport1);
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

        public void BindRegion()
        {
            try
            {
                Region_Management objRegion = new Region_Management();
                auto_select2.DataSource = objRegion.GetRegion();
                auto_select2.DataTextField = "REGION_NAME";
                auto_select2.DataValueField = "REGION_ID";
                auto_select2.DataBind();
                auto_select2.Items.Insert(0, new ListItem("All Region", "0"));
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
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack)
            {
                txtFromDate.Text = Convert.ToDateTime("1 " + System.DateTime.Now.ToString("MMM yyyy")).ToString("yyyy-MM-dd");
                txttoDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                BindRegion();
                BindMaterialName();
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