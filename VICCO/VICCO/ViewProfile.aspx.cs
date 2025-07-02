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
    public partial class ViewProfile : System.Web.UI.Page
    {

        public void GetStockistDetails()
        {
            try
            {
                AdminStockist_Managment objDetails = new AdminStockist_Managment();
                objDetails.STOCKIST_ID = Convert.ToInt32(Request.Cookies["Stockist"].Value);
                objDetails.SpOperation = "GET_STOCKIST_DETAILS";
                DataTable dtDetails = new DataTable();
                dtDetails = objDetails.GetDetails();

                if (dtDetails.Rows.Count > 0)
                {
                    lblname.Text = Convert.ToString(dtDetails.Rows[0]["NAME"]);
                    lblAddress.Text = Convert.ToString(dtDetails.Rows[0]["ADDRESS"]);
                    lblEmail.Text = Convert.ToString(dtDetails.Rows[0]["EMAIL"]);
                    lblMobileNo.Text = Convert.ToString(dtDetails.Rows[0]["MOBILE_NUMBER"]);
                    lblPan.Text = Convert.ToString(dtDetails.Rows[0]["pan"]);
                    lblCity.Text = Convert.ToString(dtDetails.Rows[0]["City"]);
                    lblGst.Text = Convert.ToString(dtDetails.Rows[0]["CST"]);
                    lblLst.Text = Convert.ToString(dtDetails.Rows[0]["LST"]);
                    lblregion.Text = Convert.ToString(dtDetails.Rows[0]["STOCKIST_REGION"]);
                    lbltpt.Text = Convert.ToString(dtDetails.Rows[0]["tpt"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetStockistDetails();
        }

    }
}