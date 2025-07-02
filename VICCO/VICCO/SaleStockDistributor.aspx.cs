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
    public partial class SaleStockDistributor : System.Web.UI.Page
    {
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

        public void BindMaterialName()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.SpOperation = "SELECT";
            DataTable dtMaterial = new DataTable();
            dtMaterial = objMaterial.SaveMaterial();

            auto_select3.DataSource = dtMaterial;
            auto_select3.DataValueField = "MATERIAL_ID";
            auto_select3.DataTextField = "MATERIAL_DESCREPTION";
            auto_select3.DataBind();
            auto_select3.Items.Insert(0, new ListItem("Material Name", "0"));
        }

        public void BindDistributorName()
        {
            Distributor_Management objDistributor = new Distributor_Management();

            if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 2)
            {
                auto_select1.Visible = false;
                objDistributor.Stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
            }
            else
            {
                if (auto_select2.SelectedIndex != -1)
                {
                    objDistributor.Stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }
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

        public void GetSaleStockReport()
        {
            try
            {
                Report_management objReport = new Report_management();

                if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 2)
                {
                    auto_select1.Visible = false;
                    objReport.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                }
                else
                {
                    if (auto_select1.SelectedIndex != -1)
                    {
                        objReport.stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                    }
                }

                if (auto_select2.SelectedIndex != -1)
                {
                    objReport.Distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }

                if (auto_select3.SelectedIndex != -1)
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

                objReport.SpOperation = "DISTRIBUTOR_SALE_STOCK_REPORT";
                DataTable dtReport = new DataTable();
                dtReport = objReport.GetReport();
                
                Session["DataSource"] = dtReport;

                //Report Viewer-----------------------------------------
                ReportViewer1.AsyncRendering = false;
                ReportViewer1.SizeToReportContent = true;
                ReportViewer1.ZoomMode = ZoomMode.FullPage;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/StockAndSaleDistributosNew.rdlc");
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

                BindRegion();
                BindMaterialName();
                //BindDistributorName();

                if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 2)
                {
                    ddlRegion.Visible = false;
                }
            }

            string region = ddlRegion.SelectedItem.Text;
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
            string region = ddlRegion.SelectedItem.Text;
            GetSaleStockReport();
        }

        protected void ddlRegion_Change(object sender, EventArgs e)
        {
            BindStockistName();
        }

        protected void auto_select1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistributorName();
        }

        #endregion
    }
}