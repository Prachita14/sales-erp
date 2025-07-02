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
    public partial class StockistReturnReport : System.Web.UI.Page
    {
        #region "Public Function"

        public void GetMaterialReturn()
        {
            try
            {
                Material_Return_Management objReturn = new Material_Return_Management();
                objReturn.stockist_id = Convert.ToInt32(Request.Cookies["Stockist"].Value);

                if (txtFromDate.Text != "")
                {
                    objReturn.Return_date = Convert.ToDateTime(txtFromDate.Text);
                }

                objReturn.SpOperation = "SELECT";
                DataTable dtReturn = new DataTable();
                dtReturn = objReturn.SaveMaterialReturn();
                grdProduct.DataSource = dtReturn;
                grdProduct.DataBind();

                if (dtReturn.Rows.Count > 0)
                {
                    grdProduct.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdProduct.UseAccessibleHeader = true;
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
                txtFromDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                GetMaterialReturn();
            }
        }

        protected void txtReturnMaterial_TextChanged(object sender, EventArgs e)
        {
            GetMaterialReturn();
        }

    }
}