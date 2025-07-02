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
    public partial class SaleReportQuantity : System.Web.UI.Page
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

        public void BindDistributorName()
        {
            Employee_Report_Managment objDistributor = new Employee_Report_Managment();
            objDistributor.Employee_id = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
            if (auto_select1.SelectedIndex != -1)
            {
                objDistributor.stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
            }

            if (auto_select3.SelectedItem.Text != "District Name")
            {
                objDistributor.District = auto_select3.SelectedItem.Text;
            }

            objDistributor.SpOperation = "GET_DISTRIBUTOR";
            DataTable dtDistributor = new DataTable();
            dtDistributor = objDistributor.GetReport();

            auto_select4.DataSource = dtDistributor;
            auto_select4.DataValueField = "DISTRIBUTOR_ID";
            auto_select4.DataTextField = "NAME";
            auto_select4.DataBind();
            auto_select4.Items.Insert(0, new ListItem("Distributor Name", "0"));
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

        public void BindDropDown()
        {
            try
            {

                Employee_Report_Managment objTown = new Employee_Report_Managment();
                objTown.Employee_id = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
                if (auto_select1.SelectedIndex != -1)
                {
                    objTown.stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }

                if (auto_select2.SelectedItem.Value != "0")
                {
                    objTown.Distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }

                if (ddlRegion.SelectedItem.Text != "All Region")
                {
                    objTown.Region = ddlRegion.SelectedItem.Text;
                }

                objTown.SpOperation = "GET_CITY";
                DataTable dtTown = new DataTable();
                dtTown = objTown.GetReport();

                auto_select5.DataSource = dtTown;
                auto_select5.DataTextField = "CITY";
                auto_select5.DataValueField = "CITY";
                auto_select5.DataBind();
                auto_select5.Items.Insert(0, new ListItem("Town Name", "0"));


                Employee_Report_Managment objSalesOfficer = new Employee_Report_Managment();
                objSalesOfficer.Employee_id = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
                if (auto_select1.SelectedIndex != -1)
                {
                    objSalesOfficer.stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }

                if (auto_select2.SelectedItem.Value != "0")
                {
                    objSalesOfficer.Distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }

                if (ddlRegion.SelectedItem.Text != "All Region")
                {
                    objSalesOfficer.Region = ddlRegion.SelectedItem.Text;
                }

                objSalesOfficer.SpOperation = "GET_OFFICER";
                DataTable dtOfficer = new DataTable();
                dtOfficer = objSalesOfficer.GetReport();

                auto_select6.DataSource = dtOfficer;
                auto_select6.DataTextField = "GST_NO";
                auto_select6.DataValueField = "GST_NO";
                auto_select6.DataBind();
                auto_select6.Items.Insert(0, new ListItem("Sales Officer", "0"));

            }
            catch (Exception ex)
            {
            }
        }

        public void BindDistrict()
        {
            try
            {
                Employee_Report_Managment objDistrict = new Employee_Report_Managment();
                objDistrict.Employee_id = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
                if (auto_select1.SelectedIndex != -1)
                {
                    objDistrict.stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }

                if (ddlRegion.SelectedItem.Text != "All Region")
                {
                    objDistrict.Region = ddlRegion.SelectedItem.Text;
                }

                objDistrict.SpOperation = "GET_DISTRICT";
                DataTable dtCriteria = new DataTable();
                dtCriteria = objDistrict.GetReport();

                auto_select3.DataSource = dtCriteria;
                auto_select3.DataTextField = "DISTRICT";
                auto_select3.DataValueField = "DISTRICT";
                auto_select3.DataBind();
                auto_select3.Items.Insert(0, new ListItem("District Name", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetInactivePartyReport()
        {
            try
            {
                Employee_Report_Managment objReport = new Employee_Report_Managment();

                if (auto_select2.SelectedIndex != -1)
                {
                    objReport.stockist_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }

                if (auto_select3.SelectedItem.Text != "District Name")
                {
                    objReport.District = auto_select3.SelectedItem.Text;
                }

                if (auto_select4.SelectedIndex != -1)
                {
                    objReport.Distributor_id = Convert.ToInt32(auto_select4.SelectedItem.Value);
                }

                if (auto_select5.SelectedItem.Text != "Town Name")
                {
                    objReport.City = auto_select5.SelectedItem.Text;
                }

                if (auto_select6.SelectedItem.Text != "Sales Officer")
                {
                    objReport.Sales_officer = auto_select6.SelectedItem.Text;
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

                objReport.SpOperation = "INACTIVE_DISTRIBUTOR";
                DataTable dtReport = new DataTable();
                dtReport = objReport.GetReport();
                //grdSecondSaleReport.DataSource = dtReport;
                //grdSecondSaleReport.DataBind();

                Session["DataSource"] = dtReport;

                //Report Viewer-----------------------------------------
                ReportViewer2.AsyncRendering = false;
                ReportViewer2.SizeToReportContent = true;
                ReportViewer2.ZoomMode = ZoomMode.FullPage;

                ReportViewer2.LocalReport.ReportPath = Server.MapPath("~/InactiveParty.rdlc");
                ReportViewer2.LocalReport.DataSources.Clear();
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
                ReportViewer2.LocalReport.Refresh();

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

        public void GetSeconSaleReport()
        {
            try
            {
                Employee_Report_Managment objReport = new Employee_Report_Managment();
                objReport.Employee_id = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);

                if (auto_select2.SelectedIndex != -1)
                {
                    objReport.stockist_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }

                if (auto_select3.SelectedItem.Text != "District Name")
                {
                    objReport.District = auto_select3.SelectedItem.Text;
                }

                if (auto_select4.SelectedIndex != -1)
                {
                    objReport.Distributor_id = Convert.ToInt32(auto_select4.SelectedItem.Value);
                }

                if (auto_select5.SelectedItem.Text != "Town Name")
                {
                    objReport.City = auto_select5.SelectedItem.Text;
                }

                if (auto_select6.SelectedItem.Text != "Sales Officer")
                {
                    objReport.Sales_officer = auto_select6.SelectedItem.Text;
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

                objReport.SpOperation = "PARTY_WISE_SALE_REPORT_QUANTITY";
                DataTable dtReport = new DataTable();
                dtReport = objReport.GetReport();
                //grdSecondSaleReport.DataSource = dtReport;
                //grdSecondSaleReport.DataBind();

                Session["DataSource"] = dtReport;

                //Report Viewer-----------------------------------------
                ReportViewer1.AsyncRendering = false;
                ReportViewer1.SizeToReportContent = true;
                ReportViewer1.ZoomMode = ZoomMode.FullPage;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/PartyWiseValueQuantity.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
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
                BindDistrict();
                BindDistributorName();
                BindDropDown();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnSearch_Report(object sender, EventArgs e)
        {
            GetSeconSaleReport();
            GetInactivePartyReport();
            ScriptManager.RegisterStartupScript(
                        UpdatePanel1,
                        this.GetType(),
                        "MyAction",
                        "auto();",
                        true);
        }

        protected void auto_select2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropDown();
            BindDistributorName();
            ScriptManager.RegisterStartupScript(
                        UpdatePanel1,
                        this.GetType(),
                        "MyAction",
                        "auto();",
                        true);
        }

        protected void ddlRegion_Change(object sender, EventArgs e)
        {
            BindStockistName();
            ScriptManager.RegisterStartupScript(
                        UpdatePanel1,
                        this.GetType(),
                        "MyAction",
                        "auto();",
                        true);
        }

        protected void ddlDistrict_Change(object sender, EventArgs e)
        {
            BindDistributorName();
            ScriptManager.RegisterStartupScript(
                        UpdatePanel1,
                        this.GetType(),
                        "MyAction",
                        "auto();",
                        true);
        }

        #endregion
    }
}