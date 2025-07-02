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
    public partial class DistributorReportDetails : System.Web.UI.Page
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
            auto_select1.DataTextField = "NAME";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Stockist Name", "0"));
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
            auto_select2.DataTextField = "NAME";
            auto_select2.DataBind();
            auto_select2.Items.Insert(0, new ListItem("Distributor Name", "0"));
        }

        public void GetDistributor()
        {
            try
            {
                Distributor_Management objDistributor = new Distributor_Management();
                objDistributor.code = txtDistributorCode.Text;
                if (auto_select1.SelectedIndex != -1)
                {
                    objDistributor.Stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }
                if (auto_select2.SelectedIndex != -1)
                {
                    objDistributor.Distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }
                objDistributor.SpOperation = "SELECT";
                DataTable dtDistributor = new DataTable();
                dtDistributor = objDistributor.SaveDistributor();

                Session["DataSource"] = dtDistributor;

                grdReport.DataSource = dtDistributor;
                grdReport.DataBind();

                grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdReport.UseAccessibleHeader = true;

                if (dtDistributor.Rows.Count == 0)
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
                BindStockistName();
                BindDistributorName();
                GetDistributor();
            }
        }

        protected void btnSearch_Distributor(object sender, EventArgs e)
        {
            GetDistributor();
        }

        protected void auto_select1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistributorName();
        }
    }
}