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
    public partial class SelectionCriteriaStockiest : System.Web.UI.Page
    {
        #region "Variable

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
            objDistributor.SpOperation = "SELECT";
            DataTable dtDistributor = new DataTable();
            dtDistributor = objDistributor.SaveDistributor();

            auto_select1.DataSource = dtDistributor;
            auto_select1.DataValueField = "DISTRIBUTOR_ID";
            auto_select1.DataTextField = "DISTRIBUTOR_NAME";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Distributor Name", "0"));
        }
       
        public void SaveCriteria()
        {
            try
            {
                Selection_Criteria_management objCriteria = new Selection_Criteria_management();
                objCriteria.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                objCriteria.district = txtDistrict.Text;
                objCriteria.town = txtTown.Text;
                objCriteria.sales_officer = txtSales.Text;
                objCriteria.date_from_to = Convert.ToDateTime(txtdatefromto.Text);
                objCriteria.distributor_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                objCriteria.SpOperation = "INSERT_STOCKIST";
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
                objCriteria.SpOperation = "SELECT_STOCKIST";
                DataTable dtCriteria = new DataTable();
                dtCriteria = objCriteria.SaveCriteria();

                if (dtCriteria.Rows.Count > 0)
                {
                    txtDistrict.Text = Convert.ToString(dtCriteria.Rows[0]["DISTRICT"]);
                    txtSales.Text = Convert.ToString(dtCriteria.Rows[0]["SALES_OFFICER"]);
                    txtTown.Text = Convert.ToString(dtCriteria.Rows[0]["TOWN"]);
                    txtdatefromto.Text = Convert.ToDateTime(dtCriteria.Rows[0]["DATE_FROM_TO"]).ToString("dd MMM yyyy");
                    
                    auto_select1.SelectedItem.Text = Convert.ToString(dtCriteria.Rows[0]["DISTRIBUTOR"]);
                    auto_select1.SelectedItem.Value = Convert.ToString(dtCriteria.Rows[0]["DISTRIBUTOR_ID"]);
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
                objCriteria.district = txtDistrict.Text;
                objCriteria.town = txtTown.Text;
                objCriteria.distributor_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                objCriteria.sales_officer = txtSales.Text;
                objCriteria.date_from_to = Convert.ToDateTime(txtdatefromto.Text);
                objCriteria.SpOperation = "UPDATE_STOCKIST";
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