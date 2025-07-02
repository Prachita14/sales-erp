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
    public partial class CriteriaReportStockiest : System.Web.UI.Page
    {
        #region "Variable

        decimal total_qty = 0, total_basic = 0, total_scheme = 0, total_Discount = 0, total_igst = 0, total_amount = 0;

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void BindDistributorName()
        {
            Distributor_Management objDistributor = new Distributor_Management();

            objDistributor.Stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);

            if (auto_select3.SelectedItem.Text != "District Name")
            {
                objDistributor.district = auto_select3.SelectedItem.Text;
            }

            objDistributor.SpOperation = "SELECT";
            DataTable dtDistributor = new DataTable();
            dtDistributor = objDistributor.SaveDistributor();

            auto_select2.DataSource = dtDistributor;
            auto_select2.DataValueField = "DISTRIBUTOR_ID";
            auto_select2.DataTextField = "DISTRIBUTOR_NAME";
            auto_select2.DataBind();
            auto_select2.Items.Insert(0, new ListItem("Distributor Name", "0"));
        }

        public void BindDropDown()
        {
            try
            {
                Report_management objTown = new Report_management();

                objTown.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                if (auto_select2.SelectedItem.Value != "0")
                {
                    objTown.Distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }
                
                objTown.SpOperation = "GET_CITY";
                DataTable dtTown = new DataTable();
                dtTown = objTown.GetReport();

                auto_select4.DataSource = dtTown;
                auto_select4.DataTextField = "CITY";
                auto_select4.DataValueField = "CITY";
                auto_select4.DataBind();
                auto_select4.Items.Insert(0, new ListItem("Town Name", "0"));


                Report_management objSalesOfficer = new Report_management();
                objSalesOfficer.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                if (auto_select2.SelectedItem.Value != "0")
                {
                    objSalesOfficer.Distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
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
                throw ex;
            }
        }

        public void BindDistrict()
        {
            try
            {
                Report_management objDistrict = new Report_management();
                objDistrict.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
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
                Report_management objReport = new Report_management();

                objReport.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);

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

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CriteriaStockist.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource _rsource1 = new ReportDataSource("DataSet1", drReport);
                ReportViewer1.LocalReport.DataSources.Add(_rsource1);
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
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            if (!IsPostBack)
            {
                txtFromDate.Text = Convert.ToDateTime("1 " + System.DateTime.Now.ToString("MMM yyyy")).ToString("yyyy-MM-dd");
                txttoDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                BindDistrict();
                BindDistributorName();
                BindDropDown();
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
            else
            {
                this.Page.MasterPageFile = "~/Site1.master";
            }
        }

        protected void auto_select1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistributorName();
        }

        protected void ddlDistrict_Change(object sender, EventArgs e)
        {
            BindDistributorName();
        }

        protected void ddlDistributor_Change(object sender, EventArgs e)
        {
            BindDropDown();
        }

        protected void btnSearch_Criteria(object sender, EventArgs e)
        {
            GetCriteria();
        }
    }
}