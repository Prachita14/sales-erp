using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VICCO.DAL;

namespace VICCO
{
    public partial class Setsuperminstock : System.Web.UI.Page
    {
        public void GetMaterials()
        {
            S_Purchase_Order_Management objpo = new S_Purchase_Order_Management();
            objpo.SP_OPERATION = "GET_MATERIAL_FOR_MINSTOCK";
            DataTable dt = new DataTable();
            dt = objpo.Savepo();

            grdReportNoExport.DataSource = dt;
            grdReportNoExport.DataBind();

            grdReportNoExport.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdReportNoExport.UseAccessibleHeader = true;
        }
        public void UpdateMinStock(int id, int min_stock)
        {
            S_Purchase_Order_Management objpo = new S_Purchase_Order_Management();
            objpo.ID = id;
            objpo.MIN_STOCK_CS = min_stock;
            objpo.SP_OPERATION = "UPDATE_MINSTOCK";
            objpo.Savepo();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetMaterials();
            }
        }
        protected void btn_Stockupdate(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in grdReportNoExport.Rows)
            {
                string id = grdReportNoExport.DataKeys[gvrow.RowIndex].Value.ToString();
                GridViewRow row = grdReportNoExport.Rows[gvrow.RowIndex];

                TextBox txtMinstock = (row.FindControl("txtMinstock") as TextBox);

                if (txtMinstock.Text == "")
                {
                    txtMinstock.Text = "0";
                }

                if (txtMinstock.Text != "0")
                {
                    UpdateMinStock(Convert.ToInt32(id), Convert.ToInt32(txtMinstock.Text));                    
                }               
            }
            GetMaterials();
        }
    }
}