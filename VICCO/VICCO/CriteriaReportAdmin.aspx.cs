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
    public partial class CriteriaReportAdmin : System.Web.UI.Page
    {
        #region "Variable"

        decimal total_qty = 0, total_basic = 0, total_scheme = 0, total_Discount = 0, total_igst = 0, total_amount = 0;

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void BindStockistName()
        {
            Supper_stockist_management objStockist = new Supper_stockist_management();

            if (ddlRegion.SelectedItem.Text != "All Region")
            {
                objStockist.region = ddlRegion.SelectedItem.Text;
            }

            objStockist.SpOperation = "SELECT";
            DataTable dtStockist = new DataTable();
            dtStockist = objStockist.SaveStockist();

            auto_select1.DataSource = dtStockist;
            auto_select1.DataValueField = "STOCKIST_ID";
            auto_select1.DataTextField = "CODE_NAME";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Super Stockist Name", "0"));
        }

        public void BindDistributorName()
        {
            Distributor_Management objDistributor = new Distributor_Management();

            if (auto_select1.SelectedIndex != -1)
            {
                objDistributor.Stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
            }

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
            //ListItem list = new ListItem();
            //for (int i = 0; i < dtDistributor.Rows.Count; i++)
            //{
            //    list = new ListItem(dtDistributor.Rows[i]["DISTRIBUTOR_NAME"].ToString(), dtDistributor.Rows[i]["DISTRIBUTOR_ID"].ToString());
            //    select2.Items.Add(list);
            //}

        }

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

        public void BindDropDown()
        {
            try
            {
                Report_management objTown = new Report_management();
                if (auto_select1.SelectedIndex != -1)
                {
                    objTown.stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }

                if (auto_select2.SelectedItem.Value != "0")
                {
                    objTown.Distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }
                //for (int i = 0; i <= select2.Items.Count - 1; i++)
                //{
                //    if (select2.Items[i].Selected)
                //    {
                //        objTown.Distributor_ids += select2.Items[i].Text + ",";
                //    }
                //}

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


                Report_management objSalesOfficer = new Report_management();
                if (auto_select1.SelectedIndex != -1)
                {
                    objSalesOfficer.stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }

                if (auto_select2.SelectedItem.Value != "0")
                {
                    objSalesOfficer.Distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }
                //for (int i = 0; i <= select2.Items.Count - 1; i++)
                //{
                //    if (select2.Items[i].Selected)
                //    {
                //        objSalesOfficer.Distributor_ids += select2.Items[i].Value + ",";
                //    }
                //}

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
                Report_management objDistrict = new Report_management();

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
                Report_management objReport = new Report_management();

                if (auto_select1.SelectedItem.Value != "0")
                {
                    objReport.stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }

                if (auto_select2.SelectedItem.Value != "0")
                {
                    objReport.Distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }
                //for (int i = 0; i <= select2.Items.Count - 1; i++)
                //{
                //    if (select2.Items[i].Selected)
                //    {
                //        objReport.Distributor_ids += select2.Items[i].Value + ",";
                //    }
                //}

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

                BindRegion();
                //auto_select1.Items.Insert(0, new ListItem("Super Stockist", "0"));
                auto_select2.Items.Insert(0, new ListItem("Distributor Name", "0"));
                auto_select4.Items.Insert(0, new ListItem("Town Name", "0"));
                auto_select5.Items.Insert(0, new ListItem("Sales Officer", "0"));
                auto_select3.Items.Insert(0, new ListItem("District Name", "0"));
                BindStockistName();
                // BindDistrict();
                // BindDistributorName();
                // BindDropDown();
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
            BindDistrict();
            BindDropDown();
        }

        protected void ddlDistrict_Change(object sender, EventArgs e)
        {
            BindDistributorName();
        }
    }
}