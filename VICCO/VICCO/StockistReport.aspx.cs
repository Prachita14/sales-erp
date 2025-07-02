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
    public partial class StockistReport : System.Web.UI.Page
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

                if (dtStockist.Rows.Count > 0)
                {
                    grdReport.DataSource = dtStockist;

                    if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 4)
                    {
                        grdReport.Columns[7].Visible=false;
                        grdReport.Columns[8].Visible = false; ;
                    }

                    grdReport.DataBind();

                    grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReport.UseAccessibleHeader = true;
                }

                    if (dtStockist.Rows.Count == 0)
                    {
                        grdReport.DataSource = null;
                        grdReport.DataBind();
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

        public void GetStockistByis(int stockist_id)
        {
            try
            {
                Supper_stockist_management objStockist = new Supper_stockist_management();
                objStockist.Stockist_id = stockist_id;                
                objStockist.SpOperation = "SELECT";
                DataTable dtStockist = new DataTable();
                dtStockist = objStockist.SaveStockist();

                if (dtStockist.Rows.Count > 0)
                {
                    lblCode.Text = Convert.ToString(dtStockist.Rows[0]["CODE"]);
                    lblName.Text = Convert.ToString(dtStockist.Rows[0]["NAME"]);
                    lblAddress.Text = Convert.ToString(dtStockist.Rows[0]["ADDRESS"]);
                    lblDistrict.Text = Convert.ToString(dtStockist.Rows[0]["DISTRICT"]);
                    lblPincode.Text = Convert.ToString(dtStockist.Rows[0]["PINCODE"]);
                    lblRegion.Text = Convert.ToString(dtStockist.Rows[0]["STOCKIST_REGION"]);                    
                    lblPhoneNo.Text = Convert.ToString(dtStockist.Rows[0]["PHONE_NUMBER"]);
                    lblMobileNo.Text = Convert.ToString(dtStockist.Rows[0]["MOBILE_NUMBER"]);
                    lblEmail.Text = Convert.ToString(dtStockist.Rows[0]["EMAIL"]);
                    lblCountry.Text = Convert.ToString(dtStockist.Rows[0]["COUNTRY"]);
                    lblCity.Text = Convert.ToString(dtStockist.Rows[0]["CITY"]);
                    lblContactPerson.Text = Convert.ToString(dtStockist.Rows[0]["CONTACT_PERSON"]);
                    lblPan.Text = Convert.ToString(dtStockist.Rows[0]["PAN"]);
                    lblLst.Text = Convert.ToString(dtStockist.Rows[0]["LST"]);
                    lblGSTIn.Text = Convert.ToString(dtStockist.Rows[0]["CST"]);
                    lblTpt.Text = Convert.ToString(dtStockist.Rows[0]["TPT"]);
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

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("Index.aspx");
            }

            if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 2)
            {
                this.Page.MasterPageFile = "~/Stockist.master";
            }
            else if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 3)
            {
                this.Page.MasterPageFile = "~/office.master";
            }
            else if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 4)
            {
                this.Page.MasterPageFile = "~/Department.master";
            }
            else
            {
                this.Page.MasterPageFile = "~/Site1.master";
            }
        }

        protected void btnSearch_Stockist(object sender, EventArgs e)
        {
            GetStockist();
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdReport.DataKeys[selRowIndex].Value.ToString();
            GetStockistByis(Convert.ToInt32(id));
            myModal.Style.Add("display", "block");

            grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdReport.UseAccessibleHeader = true;
        }
    }
}