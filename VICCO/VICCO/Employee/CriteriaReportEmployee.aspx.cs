using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using VICCO.DAL;
using System.IO;
using System.Drawing;
using Microsoft.Reporting.WebForms;

#endregion

namespace VICCO
{
    public partial class CriteriaReportEmployee : System.Web.UI.Page
    {       

        #region "Public Function"

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

            auto_select1.DataSource = dtStockist;
            auto_select1.DataValueField = "STOCKIST_ID";
            auto_select1.DataTextField = "NAME";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Super Stockist Name", "0"));
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

            auto_select2.DataSource = dtDistributor;
            auto_select2.DataValueField = "DISTRIBUTOR_ID";
            auto_select2.DataTextField = "NAME";
            auto_select2.DataBind();
            auto_select2.Items.Insert(0, new ListItem("Distributor Name", "0"));
        }

        public void BindRegion()
        {
            try
            {
                Employee_Report_Managment objRegion = new Employee_Report_Managment();
                objRegion.Employee_id=Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
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

                auto_select4.DataSource = dtTown;
                auto_select4.DataTextField = "CITY";
                auto_select4.DataValueField = "CITY";
                auto_select4.DataBind();
                auto_select4.Items.Insert(0, new ListItem("Town Name", "0"));


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

                auto_select5.DataSource = dtOfficer;
                auto_select5.DataTextField = "GST_NO";
                auto_select5.DataValueField = "GST_NO";
                auto_select5.DataBind();
                auto_select5.Items.Insert(0, new ListItem("Sales Officer", "0"));

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

        public void GetCriteria()
        {
            try
            {
                Employee_Report_Managment objReport = new Employee_Report_Managment();
                objReport.Employee_id = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
                if (auto_select1.SelectedItem.Value != "0")
                {
                    objReport.stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }

                if (auto_select2.SelectedItem.Value != "0")
                {
                    objReport.Distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }

                if (auto_select3.SelectedItem.Value != "0")
                {
                    objReport.District = auto_select3.SelectedItem.Text;
                }

                if (auto_select4.SelectedItem.Value != "0")
                {
                    objReport.City = auto_select4.SelectedItem.Text;
                }

                if (auto_select5.SelectedItem.Value != "0")
                {
                    objReport.Sales_officer = auto_select5.SelectedItem.Text;
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

                objReport.SpOperation = "SALES_REGISTER_REPORT";
                DataTable drReport = new DataTable();
                drReport = objReport.GetReport();

                Session["DataSource"] = drReport;

                //Report Viewer-----------------------------------------
                ReportViewer1.AsyncRendering = false;
                ReportViewer1.SizeToReportContent = true;
                ReportViewer1.ZoomMode = ZoomMode.FullPage;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CriteriaAdmin.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                DataTable dtpara = new DataTable();

                dtpara.Columns.Add("FROM_DATE", typeof(System.String));
                dtpara.Columns.Add("TO_DATE", typeof(System.String));

                DataRow dtrow = dtpara.NewRow();
                dtrow["FROM_DATE"] = objReport.from_date.ToString("dd MMM yyyy");
                dtrow["TO_DATE"] = objReport.To_date.ToString("dd MMM yyyy");
                dtpara.Rows.Add(dtrow);

                ReportDataSource _rsource1 = new ReportDataSource("DataSet1", drReport);
                ReportViewer1.LocalReport.DataSources.Add(_rsource1);

                ReportDataSource _rsource2 = new ReportDataSource("DataSet2", dtpara);
                ReportViewer1.LocalReport.DataSources.Add(_rsource2);
                ReportViewer1.LocalReport.Refresh();

                //End Viewer------------------------------------------------------

                if (drReport.Rows.Count == 0)
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
            if (Request.Cookies["EMP_ID"] == null)
            {
                Response.Redirect("~/Employee/EmployeeLogin.aspx");
            }

            if (!IsPostBack)
            {
                txtFromDate.Text = Convert.ToDateTime("1 " + System.DateTime.Now.ToString("MMM yyyy")).ToString("yyyy-MM-dd");
                txttoDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                BindRegion();
                BindStockistName();
                BindDistrict();
                BindDistributorName();
                BindDropDown();
            }
        }

        protected void auto_select1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropDown();
            BindDistributorName();            
        }

        protected void btnSearch_Criteria(object sender, EventArgs e)
        {
            GetCriteria();
        }

        protected void ddlRegion_Change(object sender, EventArgs e)
        {
            BindStockistName();
            BindDropDown();
        }

        protected void ddlDistrict_Change(object sender, EventArgs e)
        {
            BindDistributorName();
        }
    }
}