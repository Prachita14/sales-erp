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
    public partial class PurchaseOrderDetails : System.Web.UI.Page
    {
        #region "Variable"

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion
        #region"public function"
        public void GetPurchaseOrderData()
        {
            try
            {
                Distributor_PO_Management objpo = new Distributor_PO_Management();
                objpo.Purchaseorder_Id = Convert.ToInt32(Request.QueryString["id"]);
                objpo.Sp_Operation = "GET_PURCHASE_ORDER_BY_PO";
                DataTable dt = new DataTable();
                dt = objpo.SaveUser();
                if (dt.Rows.Count > 0)
                {
                    lblDistributor.Text = dt.Rows[0]["DISTRIBUTOR_NAME"].ToString();
                    lblPoNo.Text = dt.Rows[0]["PO_NO"].ToString();
                    lblDate.Text = Convert.ToDateTime(dt.Rows[0]["DATE"]).ToString("dd MMM yyyy");
                    lblTotal.Text = dt.Rows[0]["NET_TOTAL"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }
        public void GetProductData()
        {
            try 
            {
                Distributor_PO_Product_Management objPro = new Distributor_PO_Product_Management();
                objPro.PurchaseOrder_Id = Convert.ToInt32(Request.QueryString["id"]);
                objPro.Sp_Operation = "GET_PRODUCT_REPORT_BY_PO";
                DataTable dt = new DataTable();
                dt = objPro.SaveUser();
                if (dt.Rows.Count > 0)
                {
                    grdDistributor.DataSource = dt;
                    grdDistributor.DataBind();

                    grdDistributor.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdDistributor.UseAccessibleHeader = true;
                
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
            GetPurchaseOrderData();
            GetProductData();
        }
    }
}