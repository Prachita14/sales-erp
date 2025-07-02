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
    public partial class MappingReport : System.Web.UI.Page
    {
        #region "Public Function"
        //public void BindDesignation()
        //{
        //    try
        //    {
        //        Authorization_management objAutho = new Authorization_management();
        //        objAutho.SpOperation = "SELECT";
        //        DataTable dtAutho = new DataTable();
        //        dtAutho = objAutho.SaveAuthorization();

        //        auto_select0.DataSource = dtAutho;
        //        auto_select0.DataTextField = "POSITION";
        //        auto_select0.DataValueField = "POSITION_ID";
        //        auto_select0.DataBind();
        //        auto_select0.Items.Insert(0, new ListItem("Designation Name", "0"));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void BindEmployeeWithCode()
        //{
        //    try
        //    {
        //        Employee_master_management objAutho = new Employee_master_management();
        //        if (auto_select0.SelectedItem.Value != "0")
        //        {
        //            objAutho.DESIGNATION_ID = Convert.ToInt32(auto_select0.SelectedItem.Value);
        //        }
        //        objAutho.SpOperation = "SELECT";
        //        DataTable dtAutho = new DataTable();
        //        dtAutho = objAutho.SaveEmployee();

        //        chklstEmployee.DataSource = dtAutho;
        //        chklstEmployee.DataValueField = "EMP_ID";
        //        chklstEmployee.DataTextField = "EMPLOYEE_DESCREPTION";
        //        chklstEmployee.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
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
        public void GetTargetReport()
        {
            try
            {
                Report_management objReport = new Report_management();                

                if (ddlRegion.SelectedItem.Text != "All Region")
                {
                    objReport.Region = ddlRegion.SelectedItem.Text;
                }

                //foreach (ListItem lst in chklstEmployee.Items)
                //{
                //    if (lst.Selected == true)
                //    {
                //        objReport.Emp_ids += lst.Value + ",";
                //    }
                //}

                objReport.SpOperation = "GET_MAPPING_REPORT";
                DataTable dt = new DataTable();
                dt = objReport.GetReport();


                //Report Viewer-----------------------------------------
                ReportViewer1.AsyncRendering = false;
                ReportViewer1.SizeToReportContent = true;
                ReportViewer1.ZoomMode = ZoomMode.FullPage;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/MappingReport.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dt);
                ReportViewer1.LocalReport.DataSources.Add(_rsource1);
                ReportViewer1.LocalReport.Refresh();

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
                //BindDesignation();
                //BindEmployeeWithCode();
                BindRegion();
                GetTargetReport();
            }
        }

        //protected void auto_select0_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    BindEmployeeWithCode();
        //}
        protected void btnSearch_Report(object sender, EventArgs e)
        {
            GetTargetReport();
        }

        #endregion
    }
}