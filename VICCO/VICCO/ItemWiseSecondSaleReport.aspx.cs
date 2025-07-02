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

#endregion

namespace VICCO
{
    public partial class ItemWiseSecondSaleReport : System.Web.UI.Page
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
            auto_select2.DataTextField = "NAME";
            auto_select2.DataBind();
            auto_select2.Items.Insert(0, new ListItem("Super Stockist Name", "0"));
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

                objReport.SpOperation = "ITEM_WISE_SECOND_SALE";
                DataTable dtReport = new DataTable();
                dtReport = objReport.GetReport();
                grdReport.DataSource = dtReport;
                grdReport.DataBind();

                Session["DataSource"] = dtReport;

                if (dtReport.Rows.Count == 0)
                {
                    errorMsg.Visible = true;
                }
                else
                {
                    errorMsg.Visible = false;
                    grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReport.UseAccessibleHeader = true;
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
                BindStockistName();


                if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 2)
                {
                    stockist_ddl.Visible = false;
                    region_ddl.Visible = false;
                }
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
        }

        #endregion
    }
}