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

#endregion

namespace VICCO
{
    public partial class SelectionCritariaAdmin : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void BindStockistName()
        {
            Supper_stockist_management objStockist = new Supper_stockist_management();
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

        public void SaveCriteria()
        {
            try
            {
                Selection_Criteria_management objCriteria = new Selection_Criteria_management();
                objCriteria.state = ddlRegion.SelectedItem.Text;
                objCriteria.stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                objCriteria.district = txtDistrict.Text;
                objCriteria.town = txtTown.Text;
                objCriteria.distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                objCriteria.sales_officer = txtSales.Text;
                objCriteria.date_from_to = Convert.ToDateTime(txtdatefromto.Text);
                objCriteria.SpOperation = "INSERT_ADMIN";
                objCriteria.SaveCriteria();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetCriteriaByid()
        {
            try
            {
                Selection_Criteria_management objCriteria = new Selection_Criteria_management();
                objCriteria.Criteria_id = Convert.ToInt32(Request.QueryString["cid"]);
                objCriteria.SpOperation = "SELECT_ADMIN";
                DataTable dtCriteria = new DataTable();
                dtCriteria=objCriteria.SaveCriteria();

                if (dtCriteria.Rows.Count > 0)
                {
                    ddlRegion.SelectedItem.Text =Convert.ToString(dtCriteria.Rows[0]["STATE"]);
                    txtDistrict.Text = Convert.ToString(dtCriteria.Rows[0]["DISTRICT"]);
                    txtSales.Text = Convert.ToString(dtCriteria.Rows[0]["SALES_OFFICER"]);
                    txtTown.Text = Convert.ToString(dtCriteria.Rows[0]["TOWN"]);
                    txtdatefromto.Text = Convert.ToDateTime(dtCriteria.Rows[0]["DATE_FROM_TO"]).ToString("dd MMM yyyy");

                    auto_select1.SelectedItem.Text = Convert.ToString(dtCriteria.Rows[0]["STOCKIST"]);
                    auto_select1.SelectedItem.Value = Convert.ToString(dtCriteria.Rows[0]["STOCKIST_ID"]);

                    auto_select2.SelectedItem.Text = Convert.ToString(dtCriteria.Rows[0]["DISTRIBUTOR"]);
                    auto_select2.SelectedItem.Value = Convert.ToString(dtCriteria.Rows[0]["DISTRIBUTOR_ID"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCriteria()
        {
            try
            {
                Selection_Criteria_management objCriteria = new Selection_Criteria_management();
                objCriteria.Criteria_id = Convert.ToInt32(Request.QueryString["cid"]);
                objCriteria.state = ddlRegion.SelectedItem.Text;
                objCriteria.stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                objCriteria.district = txtDistrict.Text;
                objCriteria.town = txtTown.Text;
                objCriteria.distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                objCriteria.sales_officer = txtSales.Text;
                objCriteria.date_from_to = Convert.ToDateTime(txtdatefromto.Text);
                objCriteria.SpOperation = "UPDATE_ADMIN";
                objCriteria.SaveCriteria();
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
                BindRegion();
                BindStockistName();
                BindDistributorName();

                if (Request.QueryString["cid"] != null)
                {
                    GetCriteriaByid();
                }
            }

        }

        protected void auto_select1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistributorName();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["cid"] != null)
            {
                UpdateCriteria();
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>UpdateOk();</script>");
            }
            else
            {
                SaveCriteria();
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
            }
        }
    }
}