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
    public partial class StockistReportDetails : System.Web.UI.Page
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
            auto_select1.Items.Insert(0, new ListItem("Super Stockist Name", "0"));
        }

        public void GetStockist()
        {
            try
            {
                Supper_stockist_management objStockist = new Supper_stockist_management();
                objStockist.code = txtStockistCode.Text;
                if (auto_select1.SelectedIndex != -1)
                {
                    objStockist.Stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }
                objStockist.SpOperation = "SELECT";
                DataTable dtStockist = new DataTable();
                dtStockist = objStockist.SaveStockist();


                Session["DataSource"] = dtStockist;

                grdReport.DataSource = dtStockist;
                grdReport.DataBind();

                grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                grdReport.UseAccessibleHeader = true;

                if (dtStockist.Rows.Count == 0)
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
            if (!IsPostBack)
            {
                BindStockistName();
                GetStockist();
            }
        }
        protected void btnSearch_Stockist(object sender, EventArgs e)
        {
            GetStockist();
        }

    }
}