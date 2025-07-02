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
    public partial class PartyWiseSaleReportQuantity : System.Web.UI.Page
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
            Supper_stockist_management objStockist = new Supper_stockist_management();

            if (ddlRegion.SelectedItem.Text != "All Region")
            {
                objStockist.region = ddlRegion.SelectedItem.Text;
            }

            objStockist.SpOperation = "SELECT";
            DataTable dtStockist = new DataTable();
            dtStockist = objStockist.SaveStockist();

            auto_select2.DataSource = dtStockist;
            auto_select2.DataValueField = "STOCKIST_ID";
            auto_select2.DataTextField = "CODE_NAME";
            auto_select2.DataBind();
            auto_select2.Items.Insert(0, new ListItem("Super Stockist Name", "0"));
        }

        public void BindDistributorName()
        {
            Distributor_Management objDistributor = new Distributor_Management();

            if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 2)
            {
                stockist_ddl.Visible = false;
                objDistributor.Stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
            }
            else
            {
                if (auto_select2.SelectedIndex != -1)
                {
                    objDistributor.Stockist_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }
            }

            if (auto_select3.SelectedItem.Text != "District Name")
            {
                objDistributor.district = auto_select3.SelectedItem.Text;
            }

            objDistributor.SpOperation = "SELECT";
            DataTable dtDistributor = new DataTable();
            dtDistributor = objDistributor.SaveDistributor();

            //    //auto_select4.DataSource = dtDistributor;
            //    //auto_select4.DataValueField = "DISTRIBUTOR_ID";
            //    //auto_select4.DataTextField = "DISTRIBUTOR_NAME";
            //    //auto_select4.DataBind();
            //    //auto_select4.Items.Insert(0, new ListItem("Distributor Name", "0"));
            ListItem list = new ListItem();
            select2.Items.Clear();
            for (int i = 0; i < dtDistributor.Rows.Count; i++)
            {
                list = new ListItem(dtDistributor.Rows[i]["DISTRIBUTOR_NAME"].ToString(), dtDistributor.Rows[i]["DISTRIBUTOR_ID"].ToString());
                select2.Items.Add(list);
            }
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

                if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 2)
                {
                    objTown.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                }
                else
                {
                    if (auto_select2.SelectedIndex != -1)
                    {
                        objTown.stockist_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                    }

                    //if (ddlRegion.SelectedItem.Text != "All Region")
                    //{
                    //    objTown.Region = ddlRegion.SelectedItem.Text;
                    //}
                }



                //if (auto_select4.SelectedItem.Value != "0")
                //{
                //    objTown.Distributor_id = Convert.ToInt32(auto_select4.SelectedItem.Value);
                //}

                for (int i = 0; i <= select2.Items.Count - 1; i++)
                {
                    if (select2.Items[i].Selected)
                    {
                        objTown.Distributor_ids += select2.Items[i].Text + ",";
                    }
                }

                objTown.SpOperation = "GET_CITY";
                DataTable dtTown = new DataTable();
                dtTown = objTown.GetReport();

                auto_select5.DataSource = dtTown;
                auto_select5.DataTextField = "CITY";
                auto_select5.DataValueField = "CITY";
                auto_select5.DataBind();
                auto_select5.Items.Insert(0, new ListItem("Town Name", "0"));


                Report_management objSalesOfficer = new Report_management();

                if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 2)
                {
                    objSalesOfficer.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                }
                else
                {
                    if (auto_select2.SelectedIndex != -1)
                    {
                        objSalesOfficer.stockist_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                    }

                    if (ddlRegion.SelectedItem.Text != "All Region")
                    {
                        objSalesOfficer.Region = ddlRegion.SelectedItem.Text;
                    }
                }



                //if (auto_select4.SelectedItem.Value != "0")
                //{
                //    objSalesOfficer.Distributor_id = Convert.ToInt32(auto_select4.SelectedItem.Value);
                //}
                if (select2.SelectedIndex != -1)
                {
                    for (int i = 0; i <= select2.Items.Count - 1; i++)
                    {
                        if (select2.Items[i].Selected)
                        {
                            objSalesOfficer.Distributor_ids += select2.Items[i].Value + ",";
                        }
                    }
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
                throw ex;
            }
        }

        public void BindDistrict()
        {
            try
            {
                Report_management objDistrict = new Report_management();


                if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 2)
                {
                    objDistrict.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                }
                else
                {
                    if (auto_select2.SelectedIndex != -1)
                    {
                        objDistrict.stockist_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                    }

                    //if (ddlRegion.SelectedItem.Text != "All Region")
                    //{
                    //    objDistrict.Region = ddlRegion.SelectedItem.Text;
                    //}
                }


                if (select2.SelectedIndex != -1)
                {
                    for (int i = 0; i <= select2.Items.Count - 1; i++)
                    {
                        if (select2.Items[i].Selected)
                        {
                            objDistrict.Distributor_ids += select2.Items[i].Value + ",";
                        }
                    }
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

        public void GetSeconSaleReport()
        {
            try
            {
                Report_management objReport = new Report_management();

                if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 2)
                {
                    stockist_ddl.Visible = false;
                    objReport.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                }
                else
                {
                    if (auto_select2.SelectedIndex != -1)
                    {
                        objReport.stockist_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                    }
                    if (ddlRegion.SelectedItem.Text != "All Region")
                    {
                        objReport.Region = ddlRegion.SelectedItem.Text;
                    }
                }

                if (auto_select3.SelectedItem.Text != "District Name")
                {
                    objReport.District = auto_select3.SelectedItem.Text;
                }

                //if (auto_select4.SelectedIndex != -1)
                //{
                //    objReport.Distributor_id = Convert.ToInt32(auto_select4.SelectedItem.Value);
                //}
                if (select2.SelectedIndex != -1)
                {
                    for (int i = 0; i <= select2.Items.Count - 1; i++)
                    {
                        if (select2.Items[i].Selected)
                        {
                            objReport.Distributor_ids += select2.Items[i].Value + ",";
                        }
                    }
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
                Session["DataSource"] = dtReport;

                //Report Viewer-----------------------------------------
                ReportViewer1.AsyncRendering = false;
                ReportViewer1.SizeToReportContent = true;
                ReportViewer1.ZoomMode = ZoomMode.FullPage;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/PartyWiseValueQuantity.rdlc");
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
                    ReportViewer1.Visible = false;
                }
                else
                {
                    errorMsg.Visible = false;
                    ReportViewer1.Visible = true;
                }

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
                Report_management objReport = new Report_management();

                if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 2)
                {
                    stockist_ddl.Visible = false;
                    objReport.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                }
                else
                {
                    if (auto_select2.SelectedIndex != -1)
                    {
                        objReport.stockist_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                    }
                    if (ddlRegion.SelectedItem.Text != "All Region")
                    {
                        objReport.Region = ddlRegion.SelectedItem.Text;
                    }
                }

                if (auto_select3.SelectedItem.Text != "District Name")
                {
                    objReport.District = auto_select3.SelectedItem.Text;
                }

                //if (auto_select4.SelectedIndex != -1)
                //{
                //    objReport.Distributor_id = Convert.ToInt32(auto_select4.SelectedItem.Value);
                //}
                if(select2.SelectedIndex != -1)
                { 
                for (int i = 0; i <= select2.Items.Count - 1; i++)
                {
                    if (select2.Items[i].Selected)
                    {
                        objReport.Distributor_ids += select2.Items[i].Value + ",";
                    }
                }
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

                Session["DataSource"] = dtReport;

                //Report Viewer-----------------------------------------
                ReportViewer2.AsyncRendering = false;
                ReportViewer2.SizeToReportContent = true;
                ReportViewer2.ZoomMode = ZoomMode.FullPage;

                ReportViewer2.LocalReport.ReportPath = Server.MapPath("~/InactiveParty.rdlc");
                ReportViewer2.LocalReport.DataSources.Clear();
                ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dtReport);
                ReportViewer2.LocalReport.DataSources.Add(_rsource1);
                ReportViewer2.LocalReport.Refresh();

                //End Viewer------------------------------------------------------


                if (dtReport.Rows.Count == 0)
                {
                    errorMsg1.Visible = true;
                    ReportViewer2.Visible = false;
                }
                else
                {
                    errorMsg1.Visible = false;
                    ReportViewer2.Visible = true;
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
                txtFromDate.Text = Convert.ToDateTime("1 " + System.DateTime.Now.ToString("MMM yyyy")).ToString("yyyy-MM-dd");
                txttoDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 2)
                {
                    BindDistrict();
                    BindDropDown();
                    stockist_ddl.Visible = false;
                    region_ddl.Visible = false;
                }
                else
                {
                    BindRegion();
                    BindStockistName();
                    auto_select3.Items.Insert(0, new ListItem("District Name", "0"));
                }
                BindMaterialName();
                BindDistributorName();
                auto_select5.Items.Insert(0, new ListItem("Town Name", "0"));
                auto_select6.Items.Insert(0, new ListItem("Sales Officer", "0"));

                //auto_select2.Items.Insert(0, new ListItem("Super Stockist Name", "0"));
                //auto_select4.Items.Insert(0, new ListItem("Distributor Name", "0"));

                
               
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
            BindDistrict();
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
            BindDropDown();
            auto_select3.Items.Clear();
            auto_select3.Items.Insert(0, new ListItem("District Name", "0"));
            ScriptManager.RegisterStartupScript(
                        UpdatePanel1,
                        this.GetType(),
                        "MyAction",
                        "auto();",
                        true);
        }

        protected void ddlDistrict_Change(object sender, EventArgs e)
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
        protected void ddlDistributor_Change(object sender, EventArgs e)
        {
            BindDistrict();
            BindDropDown();
          
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