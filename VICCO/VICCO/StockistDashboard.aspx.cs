using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VICCO.DAL;
using System.Data;

namespace VICCO
{
    public partial class StockistDashboard : System.Web.UI.Page
    {
        public void GetNotice()
        {
            try
            {
                Notice_Management objNotice = new Notice_Management();
                objNotice.SpOperation = "SELECT_STOCKIST_NOTICE";

                DataTable dt = new DataTable();

                dt = objNotice.SaveNotice();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 1; i <= dt.Rows.Count; i++)
                    {
                        pnlNotice.Controls.Add(new LiteralControl("<div class='col-md-12'>"));
                        pnlNotice.Controls.Add(new LiteralControl("<p>" + dt.Rows[i - 1]["NOTICE_TEXT"] + "</p>"));
                        pnlNotice.Controls.Add(new LiteralControl("</div>"));
                        pnlNotice.Controls.Add(new LiteralControl(" <div class='clearfix'></div><hr />"));
                    }
                }
                else
                {
                    pnlNotice.Controls.Add(new LiteralControl("<div class='col-md-12'>"));
                    pnlNotice.Controls.Add(new LiteralControl("<p>Notice Board</p>"));
                    pnlNotice.Controls.Add(new LiteralControl("</div>"));
                    pnlNotice.Controls.Add(new LiteralControl(" <div class='clearfix'></div>"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetmonthlyValue()
        {
            AdminStockist_Managment objDetails = new AdminStockist_Managment();
            objDetails.STOCKIST_ID = Convert.ToInt32(Request.Cookies["Stockist"].Value);
            objDetails.SpOperation = "GET_CURRENT_MONTH_VALUE";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();

            if (dt.Rows.Count > 0)
            {
                lblcurrentmonthvalue.Text = Convert.ToInt32(dt.Rows[0]["VALUE"]).ToString("N0");
            }
        }

        public void GetCimulativeValue()
        {
            AdminStockist_Managment objDetails = new AdminStockist_Managment();
            objDetails.STOCKIST_ID = Convert.ToInt32(Request.Cookies["Stockist"].Value);
            objDetails.SpOperation = "GET_CIMULATIVE_SALE_VALUE";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();

            if (dt.Rows.Count > 0)
            {
                lblcurrentCimulativevalue.Text = Convert.ToInt32(dt.Rows[0]["VALUE"]).ToString("N0");
            }
        }

        public void GetMonthlyQuantityValue()
        {
            AdminStockist_Managment objDetails = new AdminStockist_Managment();
            objDetails.STOCKIST_ID = Convert.ToInt32(Request.Cookies["Stockist"].Value);
            objDetails.SpOperation = "GET_CURRENTMONTH_QTY_BY_PRODUCT";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();

            if (dt.Rows.Count > 0)
            {
                lblcurrentmonthqtyvalue.Text = Convert.ToInt32(dt.Rows[0]["QTY"]).ToString("N0");
            }
        }

        public void GetMonthlyCumulativeValue()
        {
            AdminStockist_Managment objDetails = new AdminStockist_Managment();
            objDetails.STOCKIST_ID = Convert.ToInt32(Request.Cookies["Stockist"].Value);
            objDetails.SpOperation = "GET_CUMULATIVE_QTY_VALUE";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();
            if (dt.Rows.Count > 0)
            {
                lblcurrentcumulativeqtyvalue.Text = Convert.ToInt32(dt.Rows[0]["QTY"]).ToString("N0");
            }
        }

        public void MaterialName()
        {
            Material_management objClient = new Material_management();
            //objClient.Material_id = Convert.ToInt32(Request.Cookies["USER_ID"]);
            objClient.SpOperation = "SELECT_ONLY_GROUP";
            DataTable dtClient = new DataTable();
            dtClient = objClient.SaveMaterial();

            ddlMaterialGroup.DataSource = dtClient;
            ddlMaterialGroup.DataTextField = "MATERIAL_GROUP";
            ddlMaterialGroup.DataBind();
            ddlMaterialGroup.Items.Insert(0, new ListItem("Material Name", "0"));

            ddlMaterial.DataSource = dtClient;
            ddlMaterial.DataTextField = "MATERIAL_GROUP";
            ddlMaterial.DataBind();
            ddlMaterial.Items.Insert(0, new ListItem("Material Name", "0"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null || Request.Cookies["Stockist"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                lblLoginName.Text = Convert.ToString(Request.Cookies["UserName"].Value);
            }

            if (!IsPostBack)
            {
                MaterialName();
                GetNotice();
                GetmonthlyValue();
                GetCimulativeValue();
                GetMonthlyQuantityValue();
                GetMonthlyCumulativeValue();
            }
        }
    }
}