using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using VICCO.DAL;
using System.Data;
using VICCO.DAL.PURCHASE_ORDER;
using VICCO.DAL.PURCHASE_ORDER_PRODUCT;

#endregion

namespace VICCO
{
    public partial class AdminReturnReport : System.Web.UI.Page
    {
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

        public void GetMaterialReturn()
        {
            try
            {
                Material_Return_Management objReturn = new Material_Return_Management();
                if (auto_select1.SelectedIndex != -1)
                {
                    objReturn.stockist_id= Convert.ToInt32(auto_select1.SelectedItem.Value);
                }

                if (txtFromDate.Text != "")
                {
                    objReturn.Return_date = Convert.ToDateTime(txtFromDate.Text);
                }

                objReturn.SpOperation = "SELECT";
                DataTable dtReturn = new DataTable();
                dtReturn = objReturn.SaveMaterialReturn();
                grdProduct.DataSource = dtReturn;
                grdProduct.DataBind();
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
                GetMaterialReturn();
            }
        }

        protected void txtReturnMaterial_TextChanged(object sender, EventArgs e)
        {
            GetMaterialReturn();
        }
    }
}