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
    public partial class Uplodedtarget : System.Web.UI.Page
    {
        #region "Variable"

        decimal total_qty = 0, total_basic = 0, total_scheme = 0, total_Discount = 0, total_igst = 0, total_amount = 0;

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void Getyear()
        {
            var currentYear = DateTime.Today.Year;

            for (int i = currentYear + 1; i >= 2017; i--)
            {
                auto_select6.Items.Add((i).ToString());
            }
        }
        public void BindMaterialGroup()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.SpOperation = "SELECT_ONLY_GROUP";
            DataTable dtMaterial = new DataTable();
            dtMaterial = objMaterial.SaveMaterial();

            ddlMaterialGroup.DataSource = dtMaterial;
            ddlMaterialGroup.DataValueField = "MATERIAL_GROUP";
            ddlMaterialGroup.DataTextField = "MATERIAL_GROUP";
            ddlMaterialGroup.DataBind();
            ddlMaterialGroup.Items.Insert(0, new ListItem("Material Group", "0"));
        }
        public void BindMaterial()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.SpOperation = "SELECT";
            objMaterial.GROUP_NAME = ddlMaterialGroup.SelectedItem.Value;
            DataTable dtMaterial = new DataTable();
            dtMaterial = objMaterial.SaveMaterial();

            Ddlmaterial.DataSource = dtMaterial;
            Ddlmaterial.DataValueField = "MATERIAL_ID";
            Ddlmaterial.DataTextField = "MATERIAL_DESCREPTION";
            Ddlmaterial.DataBind();
            Ddlmaterial.Items.Insert(0, new ListItem("Material Name", "0"));
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

        public void Gettarget()
        {
            try
            {
                Target_Managment objReport = new Target_Managment();

                if (ddlMaterialGroup.SelectedItem.Value != "0")
                {
                    objReport.Material_Group = ddlMaterialGroup.SelectedItem.Value;
                }

                if (Ddlmaterial.SelectedIndex != -1)
                {
                    objReport.Material_ids = hdMaterialId.Value;
                }

                if (auto_select1.SelectedItem.Value != "0")
                {
                    objReport.STOCKIST_ID = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }

                if (auto_select2.SelectedItem.Value != "0")
                {
                    objReport.DISTRIBUTOR_ID = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }             

                if (ddlRegion.SelectedItem.Text != "All Region")
                {
                    objReport.REGION = ddlRegion.SelectedItem.Text;
                }

                if (auto_select3.SelectedItem.Text != "")
                {
                    objReport.FROM_DATE = Convert.ToDateTime("1 " + auto_select3.SelectedItem.Text + " " + auto_select6.SelectedItem.Text);
                }
                
                objReport.SP_OPERATION = "SELECT";
                DataTable drReport = new DataTable();
                drReport = objReport.SaveTarget();

                Session["DataSource"] = drReport;
                Session["region"] = ddlRegion.SelectedItem.Text;

                grdReport1.DataSource = drReport;
                grdReport1.DataBind();

                if (drReport.Rows.Count == 0)
                {
                    errorMsg.Visible = true;
                    deletebtn.Visible = false;
                }
                else
                {
                    grdReport1.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReport1.UseAccessibleHeader = true;
                    errorMsg.Visible = false;
                    deletebtn.Visible = true;
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
                Getyear();
                BindRegion();
                BindMaterialGroup();

                auto_select3.SelectedItem.Text = System.DateTime.Now.ToString("MMM");
                auto_select3.SelectedItem.Value = System.DateTime.Now.ToString("MM");

                auto_select6.SelectedItem.Text = System.DateTime.Now.ToString("yyyy");

                auto_select1.Items.Insert(0, new ListItem("Super Stockist", "0"));
                auto_select2.Items.Insert(0, new ListItem("Distributor Name", "0"));            
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

        protected void editclick(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdReport1.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdReport1.Rows[selRowIndex];

            TextBox txtTarget = (row.FindControl("txtTarget") as TextBox);
            Label lblTarget = (row.FindControl("lblTarget") as Label);

            txtTarget.Visible = true;
            lblTarget.Visible = false;

            grdReport1.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdReport1.UseAccessibleHeader = true;
        }

        protected void updateRecord(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
            string id = grdReport1.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdReport1.Rows[selRowIndex];

            TextBox txtTarget = (row.FindControl("txtTarget") as TextBox);
            Label lblTarget = (row.FindControl("lblTarget") as Label);

            txtTarget.Visible = false;
            lblTarget.Visible = true;

            if (txtTarget.Text == "")
            {
                txtTarget.Text = "0";
            }

            lblTarget.Text = txtTarget.Text;

            Target_Managment objReport = new Target_Managment();
            objReport.ID = Convert.ToInt32(id);
            objReport.TARGET = Convert.ToInt32(txtTarget.Text);
            objReport.SP_OPERATION = "UPDATE_TARGET";
            objReport.SaveTarget();

            grdReport1.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdReport1.UseAccessibleHeader = true;

        }

       

        protected void auto_select1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistributorName();
            ScriptManager.RegisterStartupScript(
                     UpdatePanel1,
                     this.GetType(),
                     "MyAction",
                     "auto();",
                     true);
        }
        protected void ddlGroup_Change(object sender, EventArgs e)
        {
            BindMaterial();
            ScriptManager.RegisterStartupScript(
                     UpdatePanel1,
                     this.GetType(),
                     "MyAction",
                     "auto();",
                     true);
        }
        protected void btnSearch_Criteria(object sender, EventArgs e)
        {
            Gettarget();
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

        protected void btndeletetarget(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in grdReport1.Rows)
            {
                CheckBox chk = (CheckBox)gvrow.FindControl("chkRow");

                if (chk != null & chk.Checked)
                {
                    int id = Convert.ToInt32(grdReport1.DataKeys[gvrow.RowIndex].Values[0]);

                    Target_Managment objReport = new Target_Managment();
                    objReport.ID = id;
                    objReport.SP_OPERATION = "DELETE";
                    objReport.SaveTarget();
                }
            }
            Gettarget();
        }  
    }
}