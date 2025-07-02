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
using System.Text;

#endregion

namespace VICCO
{
    public partial class Distributor : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void BindRegion()
        {
            try
            {
                Distributor_Management objRegion = new Distributor_Management();
                objRegion.Stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                objRegion.SpOperation = "SELECT_REGION_BY_STOCKIST";
                ddlRegion.DataSource = objRegion.SaveDistributor();
                ddlRegion.DataTextField = "REGION_NAME";
                ddlRegion.DataValueField = "REGION_ID";
                ddlRegion.DataBind();
                ddlRegion.Items.Insert(0, new ListItem("Select Region", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindState()
        {
            try
            {
                Distributor_Management objRegion = new Distributor_Management();
                objRegion.Stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                objRegion.SpOperation = "SELECT_STATE_BY_STOCKIST";
                ddlState.DataSource = objRegion.SaveDistributor();
                ddlState.DataTextField = "STATE";
                ddlState.DataValueField = "ID";
                ddlState.DataBind();
                ddlState.Items.Insert(0, new ListItem("Select State", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindStockistName()
        {
            Supper_stockist_management objStockist = new Supper_stockist_management();
            objStockist.SpOperation = "SELECT";
            DataTable dtStockist = new DataTable();
            dtStockist = objStockist.SaveStockist();

            auto_select1.DataSource = dtStockist;
            auto_select1.DataValueField = "STOCKIST_ID";
            auto_select1.DataTextField = "STOCKIST_NAME_CODE";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Super Stockist Name", "0"));
        }

        public string Createid()
        {           
            try
            {
                Distributor_Management objDistributor = new Distributor_Management();
                objDistributor.Stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                objDistributor.SpOperation = "GET_MAX_ID_BY_STOCKIEST";
                DataTable dtDistributor = new DataTable();
                dtDistributor = objDistributor.SaveDistributor();

                if (Convert.ToString(dtDistributor.Rows[0]["ID"])=="0")
                {
                    return auto_select1.SelectedItem.Text.Substring(0, auto_select1.SelectedItem.Text.IndexOf(" (")) + "001";
                }
                else
                {
                    return auto_select1.SelectedItem.Text.Substring(0, auto_select1.SelectedItem.Text.IndexOf(" ("))+Convert.ToString(Convert.ToInt32(dtDistributor.Rows[0]["ID"])+1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public bool CheckDistributorCode()
        {
            Distributor_Management objDistributor = new Distributor_Management();
            objDistributor.code = txtStockistCode.Text;
            objDistributor.SpOperation = "SELECT";
            DataTable dtDistributor = new DataTable();
            dtDistributor = objDistributor.SaveDistributor();

            if (dtDistributor.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SaveDistributor()
        {
            Distributor_Management objDistributor = new Distributor_Management();
            objDistributor.Stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
            objDistributor.code = txtStockistCode.Text;
            objDistributor.name = txtStockistName.Text;
            objDistributor.address = txtAddress.Text;
            objDistributor.district = txtDistrict.Text;
            objDistributor.Pin_code = txtPincode.Text;
            objDistributor.region = ddlRegion.SelectedItem.Text;
            objDistributor.state = ddlState.SelectedItem.Text;
            objDistributor.Phone_number = txtPhoneNo.Text;
            objDistributor.Mobile_number = txtMobileNo.Text;
            objDistributor.email = txtEmail.Text;
            objDistributor.country = txtCountry.Text;
            objDistributor.City = txtCity.Text;
            objDistributor.contact_person = txtContactPerson.Text;
            objDistributor.pan = txtPan.Text;
            objDistributor.lst = txtLst.Text;
            objDistributor.cst = txtGstIn.Text;
            objDistributor.tpt = txtTPT.Text;
          
            objDistributor.Distributor_Type=ddlDistributorType.SelectedItem.Text;
            
            objDistributor.SpOperation = "INSERT";
            objDistributor.SaveDistributor();
        }

        public void UpdateDistributor()
        {
            try
            {
                Distributor_Management objDistributor = new Distributor_Management();
                objDistributor.Stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                objDistributor.Distributor_id = Convert.ToInt32(Request.QueryString["did"]);
                objDistributor.code = txtStockistCode.Text;
                objDistributor.name = txtStockistName.Text;
                objDistributor.address = txtAddress.Text;
                objDistributor.district = txtDistrict.Text;
                objDistributor.Pin_code = txtPincode.Text;
                objDistributor.region = ddlRegion.SelectedItem.Text;
                objDistributor.state = ddlState.SelectedItem.Text;
                objDistributor.Phone_number = txtPhoneNo.Text;
                objDistributor.Mobile_number = txtMobileNo.Text;
                objDistributor.email = txtEmail.Text;
                objDistributor.country = txtCountry.Text;
                objDistributor.City = txtCity.Text;
                objDistributor.contact_person = txtContactPerson.Text;
                objDistributor.pan = txtPan.Text;
                objDistributor.lst = txtLst.Text;
                objDistributor.cst = txtGstIn.Text;
                objDistributor.tpt = txtTPT.Text;
              
                objDistributor.Distributor_Type = ddlDistributorType.SelectedItem.Text;                

                if (chkDeactivate.Checked == true)
                {
                    objDistributor.Is_Active = true;
                }
                else
                {
                    objDistributor.Is_Active = false;
                }

                objDistributor.SpOperation = "UPDATE";
                objDistributor.SaveDistributor();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetDistributor()
        {
            try
            {
                Distributor_Management objDistributor = new Distributor_Management();
                objDistributor.Distributor_id = Convert.ToInt32(Request.QueryString["did"]);
                objDistributor.SpOperation = "SELECT";
                DataTable dtDistributor = new DataTable();
                dtDistributor = objDistributor.SaveDistributor();

                if (dtDistributor.Rows.Count > 0)
                {
                    txtStockistCode.Text = Convert.ToString(dtDistributor.Rows[0]["CODE"]);
                    txtStockistName.Text = Convert.ToString(dtDistributor.Rows[0]["NAME"]);
                    txtAddress.Text = Convert.ToString(dtDistributor.Rows[0]["ADDRESS"]);
                    txtDistrict.Text = Convert.ToString(dtDistributor.Rows[0]["DISTRICT"]);
                    txtPincode.Text = Convert.ToString(dtDistributor.Rows[0]["PINCODE"]);

                    auto_select1.SelectedItem.Text = Convert.ToString(dtDistributor.Rows[0]["STOCKIST_NAME"]);
                    auto_select1.SelectedItem.Value = Convert.ToString(dtDistributor.Rows[0]["STOCKIST_ID"]);

                    BindRegion();
                    BindState();

                    if (Convert.ToString(dtDistributor.Rows[0]["REGION"]) != "")
                    {
                        ddlRegion.SelectedItem.Text = Convert.ToString(dtDistributor.Rows[0]["REGION"]);
                        ddlRegion.SelectedItem.Value = Convert.ToString(dtDistributor.Rows[0]["REGION"]);
                    }

                    if (Convert.ToString(dtDistributor.Rows[0]["STATE"]) != "")
                    {
                        ddlState.SelectedItem.Text = Convert.ToString(dtDistributor.Rows[0]["STATE"]);
                        ddlState.SelectedItem.Value = Convert.ToString(dtDistributor.Rows[0]["STATE"]);
                    }

                    txtPhoneNo.Text = Convert.ToString(dtDistributor.Rows[0]["PHONE_NUMBER"]);
                    txtMobileNo.Text = Convert.ToString(dtDistributor.Rows[0]["MOBILE_NUMBER"]);
                    txtEmail.Text = Convert.ToString(dtDistributor.Rows[0]["EMAIL"]);
                    txtCountry.Text = Convert.ToString(dtDistributor.Rows[0]["COUNTRY"]);
                    txtCity.Text = Convert.ToString(dtDistributor.Rows[0]["CITY"]);
                    txtContactPerson.Text = Convert.ToString(dtDistributor.Rows[0]["CONTACT_PERSON"]);
                    txtPan.Text = Convert.ToString(dtDistributor.Rows[0]["PAN"]);
                    txtLst.Text = Convert.ToString(dtDistributor.Rows[0]["LST"]);
                    txtGstIn.Text = Convert.ToString(dtDistributor.Rows[0]["CST"]);
                    txtTPT.Text = Convert.ToString(dtDistributor.Rows[0]["TPT"]);

                    ddlDistributorType.SelectedItem.Value = Convert.ToString(dtDistributor.Rows[0]["DISTRIBUTOR_TYPE"]);
                    ddlDistributorType.SelectedItem.Text = Convert.ToString(dtDistributor.Rows[0]["DISTRIBUTOR_TYPE"]);

                    if (Convert.ToString(dtDistributor.Rows[0]["Is_Active"]) == "True")
                    {
                        chkDeactivate.Checked = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region "Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            if (!IsPostBack)
            {
                //BindRegion();
                //BindState();
                BindStockistName();

                if (Request.QueryString["did"] != null)
                {
                    txtStockistCode.ReadOnly = true;
                    Deactivate.Visible = true;
                    GetDistributor();
                }
                else
                {
                    ddlDistributorType.SelectedItem.Value = "Retail Distributor";
                    ddlDistributorType.SelectedItem.Text = "Retail Distributor";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["did"] != null)
            {
                UpdateDistributor();
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>UpdateOk();</script>");
            }
            else
            {
                if (CheckDistributorCode() == false)
                {
                    SaveDistributor();
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
                }
                else
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningCode();</script>");
                }
            }

        }

        protected void ddlStockestTextChange(object sender, EventArgs e)
        {
            if (auto_select1.SelectedItem.Value != "0")
            {
                txtStockistCode.Text = Createid();
            }
            else
            {
                txtStockistCode.Text = "";
            }

            BindRegion();
            BindState();
        }

        #endregion
    }
}