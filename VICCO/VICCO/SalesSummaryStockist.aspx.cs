using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using VICCO.DAL;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace VICCO
{
    public partial class SalesSummaryStockist : System.Web.UI.Page
    {
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

        public void BindCIty()
        {
            Report_management objTown = new Report_management();

            if (auto_select2.SelectedItem.Value != "0")
            {
                objTown.Distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
            }
            objTown.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);

            objTown.SpOperation = "GET_CITY";
            DataTable dtTown = new DataTable();
            dtTown = objTown.GetReport();

            auto_select4.DataSource = dtTown;
            auto_select4.DataTextField = "CITY";
            auto_select4.DataValueField = "CITY";
            auto_select4.DataBind();
            auto_select4.Items.Insert(0, new ListItem("Town Name", "0"));
        }
        public void BindSalesofficer()
        {
            Report_management objSalesOfficer = new Report_management();

            if (auto_select2.SelectedItem.Value != "0")
            {
                objSalesOfficer.Distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
            }
            objSalesOfficer.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);


            objSalesOfficer.SpOperation = "GET_OFFICER";
            DataTable dtOfficer = new DataTable();
            dtOfficer = objSalesOfficer.GetReport();

            auto_select5.DataSource = dtOfficer;
            auto_select5.DataTextField = "GST_NO";
            auto_select5.DataValueField = "GST_NO";
            auto_select5.DataBind();
            auto_select5.Items.Insert(0, new ListItem("Sales Officer", "0"));
        }

        public void BindDropDown()
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
            }
        }

        public void GetReport()
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
            if(auto_select2.SelectedItem.Value != "0")
            {
                objReport.Distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
            }
            if (auto_select3.SelectedItem.Value != "0")
            {
                objReport.District = Convert.ToString(auto_select3.SelectedItem.Text);
            }
            if (auto_select4.SelectedItem.Value != "0")
            {
                objReport.City = Convert.ToString(auto_select4.SelectedItem.Text);
            }
            if (auto_select5.SelectedItem.Value != "0")
            {
                objReport.Sales_officer = auto_select5.SelectedItem.Text;
            }

            objReport.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);

            objReport.SpOperation = "SALES_SUMMERY";
            DataTable dtReport = new DataTable();
            dtReport = objReport.GetReport();

            //Report Viewer-----------------------------------------
            ReportViewer1.AsyncRendering = false;
            ReportViewer1.SizeToReportContent = true;
            ReportViewer1.ZoomMode = ZoomMode.FullPage;


            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/SaleSummaryStockist.rdlc");

            DataTable dtpara = new DataTable();

            dtpara.Columns.Add("FROM_DATE", typeof(System.String));
            dtpara.Columns.Add("TO_DATE", typeof(System.String));

            DataRow dtrow = dtpara.NewRow();
            dtrow["FROM_DATE"] = objReport.from_date.ToString("dd MMM yyyy");
            dtrow["TO_DATE"] = objReport.To_date.ToString("dd MMM yyyy");
            dtpara.Rows.Add(dtrow);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dtReport);
            ReportViewer1.LocalReport.DataSources.Add(_rsource1);

            ReportDataSource _rsource2 = new ReportDataSource("DataSet2", dtpara);
            ReportViewer1.LocalReport.DataSources.Add(_rsource2);

            ReportViewer1.LocalReport.Refresh();
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("index.aspx");
            }           

            if(!IsPostBack)
            {                
                BindDropDown();
                BindDistributorName();
                BindCIty();
                BindSalesofficer();

                txtFromDate.Text = Convert.ToDateTime("1 " + System.DateTime.Now.ToString("MMM yyyy")).ToString("yyyy-MM-dd");
                txttoDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        protected void SelectedIndexChange(object sender, EventArgs e)
        {
            GetReport();
        }

        protected void ddlDistrict_Change(object sender, EventArgs e)
        {
            BindDistributorName();
        }

        protected void auto_select2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCIty();
            BindSalesofficer();
        }
    }
}