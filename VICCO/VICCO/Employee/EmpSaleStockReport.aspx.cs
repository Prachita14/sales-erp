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
    public partial class EmpSaleStockReport : System.Web.UI.Page
    {
        #region "Public Function"

        public void BindMaterialName()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.SpOperation = "SELECT";
            DataTable dtMaterial = new DataTable();
            dtMaterial = objMaterial.SaveMaterial();

            //chkMaterial.DataSource = dtMaterial;
            //chkMaterial.DataTextField = "MATERIAL_DESCREPTION";
            //chkMaterial.DataValueField = "MATERIAL_ID";
            //chkMaterial.DataBind();

            auto_select1.DataSource = dtMaterial;
            auto_select1.DataValueField = "MATERIAL_ID";
            auto_select1.DataTextField = "MATERIAL_DESCREPTION";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Material Name", "0"));
        }

        public void BindStockistName()
        {
            Employee_Report_Managment objStockist = new Employee_Report_Managment();
            objStockist.Employee_id = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
            if (ddlRegion.SelectedItem.Text != "All Region")
            {
                objStockist.Region = ddlRegion.SelectedItem.Text;
            }

            objStockist.SpOperation = "GET_STOCKIST";
            DataTable dtStockist = new DataTable();
            dtStockist = objStockist.GetReport();

            auto_select2.DataSource = dtStockist;
            auto_select2.DataValueField = "STOCKIST_ID";
            auto_select2.DataTextField = "NAME";
            auto_select2.DataBind();
            auto_select2.Items.Insert(0, new ListItem("Super Stockist Name", "0"));
        }

        public void BindRegion()
        {
            try
            {
                Employee_Report_Managment objRegion = new Employee_Report_Managment();
                objRegion.Employee_id = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
                objRegion.SpOperation = "GET_REGION";
                ddlRegion.DataSource = objRegion.GetReport();
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

        public void GetSaleStockReport()
        {
            try
            {
                Employee_Report_Managment objReport = new Employee_Report_Managment();
                objReport.Employee_id = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);

                if (auto_select2.SelectedIndex != -1)
                {
                    objReport.stockist_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }

                if (auto_select1.SelectedIndex != -1)
                {
                    objReport.Material_ids = hdMaterialId.Value;
                }

                if (ddlRegion.SelectedItem.Text != "All Region")
                {
                    objReport.Region = ddlRegion.SelectedItem.Text;
                }

                if (txtFromDate.Text != "")
                {
                    objReport.from_date = Convert.ToDateTime(txtFromDate.Text);
                }

                if (txttoDate.Text != "")
                {
                    objReport.To_date = Convert.ToDateTime(txttoDate.Text);
                }

                objReport.SpOperation = "SALE_STOCK_REPORT";
                DataTable dtReport = new DataTable();
                dtReport = objReport.GetReport();
                //grdSaleStockReport.DataSource = dtReport;
                //grdSaleStockReport.DataBind();

                Session["DataSource"] = dtReport;

                //Report Viewer-----------------------------------------
                ReportViewer1.AsyncRendering = false;
                ReportViewer1.SizeToReportContent = true;
                ReportViewer1.ZoomMode = ZoomMode.FullPage;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/StockAndSale.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                DataTable dtpara = new DataTable();

                dtpara.Columns.Add("FROM_DATE", typeof(System.String));
                dtpara.Columns.Add("TO_DATE", typeof(System.String));

                DataRow dtrow = dtpara.NewRow();
                dtrow["FROM_DATE"] = objReport.from_date.ToString("dd MMM yyyy");
                dtrow["TO_DATE"] = objReport.To_date.ToString("dd MMM yyyy");
                dtpara.Rows.Add(dtrow);

                ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dtReport);
                ReportViewer1.LocalReport.DataSources.Add(_rsource1);

                ReportDataSource _rsource2 = new ReportDataSource("DataSet2", dtpara);
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
            if (Request.Cookies["EMP_ID"] == null)
            {
                Response.Redirect("~/Employee/EmployeeLogin.aspx");
            }
            if (!IsPostBack)
            {
                txtFromDate.Text = Convert.ToDateTime("1 " + System.DateTime.Now.ToString("MMM yyyy")).ToString("yyyy-MM-dd");
                txttoDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                BindRegion();
                BindMaterialName();
                BindStockistName();               
            }

            string region = ddlRegion.SelectedItem.Text;
        }

        protected void btnSearch_Report(object sender, EventArgs e)
        {
            string region = ddlRegion.SelectedItem.Text;
            GetSaleStockReport();
        }

        protected void ddlRegion_Change(object sender, EventArgs e)
        {
            BindStockistName();
        }

        #endregion
    }
}