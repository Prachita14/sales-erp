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
    public partial class Stockist : System.Web.UI.Page
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
                Region_Management objRegion = new Region_Management();
                DataTable dt = new DataTable();
                dt = objRegion.GetRegion();

                ddlRegion.DataSource = dt;
                ddlRegion.DataTextField = "REGION_NAME";
                ddlRegion.DataValueField = "REGION_NAME";
                ddlRegion.DataBind();
                ddlRegion.Items.Insert(0, new ListItem("Select Region", "0"));

                ListItem list = new ListItem();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list = new ListItem(dt.Rows[i]["REGION_NAME"].ToString().ToUpper(), dt.Rows[i]["REGION_ID"].ToString());
                    select2.Items.Add(list);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CreatePassword(int length)
        {

            StringBuilder res = new StringBuilder("");
            try
            {
                string m = "1234567890"; //txtPanNo.Text;
                string valid = m;
                Random rnd = new Random();
                while (0 < length--)
                {
                    res.Append(valid[rnd.Next(valid.Length)]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //                Response.Redirect("~/ErrorPage.aspx");
            }
            return res.ToString();
        }

        public bool CheckStockistCode()
        {
            Supper_stockist_management objStockist = new Supper_stockist_management();
            objStockist.code = txtStockistCode.Text;
            objStockist.SpOperation = "SELECT";
            DataTable dtStockist = new DataTable();
            dtStockist = objStockist.SaveStockist();

            if (dtStockist.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SaveStockist()
        {
            Supper_stockist_management objStockist = new Supper_stockist_management();
            objStockist.code = txtStockistCode.Text;
            objStockist.name = txtStockistName.Text;
            objStockist.address = txtAddress.Text;
            objStockist.district = txtDistrict.Text;
            objStockist.Pin_code = txtPincode.Text;
            objStockist.STOCKIST_REGION = ddlRegion.SelectedItem.Text;
            objStockist.Phone_number = txtPhoneNo.Text;
            objStockist.Mobile_number = txtMobileNo.Text;
            objStockist.email = txtEmail.Text;
            objStockist.password = txtPassword.Text;
            objStockist.country = txtCountry.Text;
            objStockist.City = txtCity.Text;
            objStockist.contact_person = txtContactPerson.Text;
            objStockist.pan = txtPan.Text;
            objStockist.lst = txtLst.Text;
            objStockist.cst = txtGstIn.Text;
            objStockist.tpt = txtTPT.Text;
            objStockist.SpOperation = "INSERT";

            DataTable dt = new DataTable();
            dt = objStockist.SaveStockist();

            for (int i = 0; i <= select2.Items.Count - 1; i++)
            {
                if (select2.Items[i].Selected)
                {
                    objStockist = new Supper_stockist_management();
                    objStockist.Stockist_id = Convert.ToInt32(dt.Rows[0]["STOCKIST_ID"]);
                    objStockist.region = select2.Items[i].Text;
                    objStockist.SpOperation = "INSERT_STATE";
                    objStockist.SaveStockist();
                }
            }
        }

        public void UpdateStockist()
        {
            try
            {
                Supper_stockist_management objStockist = new Supper_stockist_management();
                objStockist.Stockist_id = Convert.ToInt32(Request.QueryString["sid"]);
                objStockist.code = txtStockistCode.Text;
                objStockist.name = txtStockistName.Text;
                objStockist.address = txtAddress.Text;
                objStockist.district = txtDistrict.Text;
                objStockist.Pin_code = txtPincode.Text;
                objStockist.STOCKIST_REGION = ddlRegion.SelectedItem.Text;
                objStockist.Phone_number = txtPhoneNo.Text;
                objStockist.Mobile_number = txtMobileNo.Text;
                objStockist.email = txtEmail.Text;
                objStockist.country = txtCountry.Text;
                objStockist.City = txtCity.Text;
                objStockist.contact_person = txtContactPerson.Text;
                objStockist.pan = txtPan.Text;
                objStockist.lst = txtLst.Text;
                objStockist.cst = txtGstIn.Text;
                objStockist.tpt = txtTPT.Text;
                objStockist.password = txtPassword.Text;

                if (chkDeactivate.Checked == true)
                {
                    objStockist.Is_Active = true;
                }
                else
                {
                    objStockist.Is_Active = false;
                }

                objStockist.SpOperation = "UPDATE";
                objStockist.SaveStockist();

                for (int i = 0; i <= select2.Items.Count - 1; i++)
                {
                    if (select2.Items[i].Selected)
                    {
                        objStockist = new Supper_stockist_management();
                        objStockist.Stockist_id = Convert.ToInt32(Request.QueryString["sid"]);
                        objStockist.region = select2.Items[i].Text;
                        objStockist.SpOperation = "INSERT_STATE";
                        objStockist.SaveStockist();
                    }
                    else
                    {
                        objStockist = new Supper_stockist_management();
                        objStockist.Stockist_id = Convert.ToInt32(Request.QueryString["sid"]);
                        objStockist.region = select2.Items[i].Text;
                        objStockist.SpOperation = "DELETE_STATE";
                        objStockist.SaveStockist();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetStockist()
        {
            try
            {
                Supper_stockist_management objStockist = new Supper_stockist_management();
                objStockist.Stockist_id = Convert.ToInt32(Request.QueryString["sid"]);
                objStockist.SpOperation = "SELECT";
                DataTable dtStockist = new DataTable();
                dtStockist = objStockist.SaveStockist();

                if (dtStockist.Rows.Count > 0)
                {
                    txtStockistCode.Text = Convert.ToString(dtStockist.Rows[0]["CODE"]);
                    txtStockistName.Text = Convert.ToString(dtStockist.Rows[0]["NAME"]);
                    txtAddress.Text = Convert.ToString(dtStockist.Rows[0]["ADDRESS"]);
                    txtDistrict.Text = Convert.ToString(dtStockist.Rows[0]["DISTRICT"]);
                    txtPincode.Text = Convert.ToString(dtStockist.Rows[0]["PINCODE"]);
                    if(Convert.ToString(dtStockist.Rows[0]["STOCKIST_REGION"]) != "")
                    { 
                    ddlRegion.SelectedItem.Text = Convert.ToString(dtStockist.Rows[0]["STOCKIST_REGION"]);
                    ddlRegion.SelectedItem.Value = Convert.ToString(dtStockist.Rows[0]["STOCKIST_REGION"]);
                    }
                    txtPhoneNo.Text = Convert.ToString(dtStockist.Rows[0]["PHONE_NUMBER"]);
                    txtMobileNo.Text = Convert.ToString(dtStockist.Rows[0]["MOBILE_NUMBER"]);
                    txtEmail.Text = Convert.ToString(dtStockist.Rows[0]["EMAIL"]);
                    txtCountry.Text = Convert.ToString(dtStockist.Rows[0]["COUNTRY"]);
                    txtCity.Text = Convert.ToString(dtStockist.Rows[0]["CITY"]);
                    txtContactPerson.Text = Convert.ToString(dtStockist.Rows[0]["CONTACT_PERSON"]);
                    txtPan.Text = Convert.ToString(dtStockist.Rows[0]["PAN"]);
                    txtLst.Text = Convert.ToString(dtStockist.Rows[0]["LST"]);
                    txtGstIn.Text = Convert.ToString(dtStockist.Rows[0]["CST"]);
                    txtTPT.Text = Convert.ToString(dtStockist.Rows[0]["TPT"]);
                    txtPassword.Text = Convert.ToString(dtStockist.Rows[0]["PASSWORD"]);

                    if (Convert.ToString(dtStockist.Rows[0]["Is_Active"]) != "")
                    {
                        chkDeactivate.Checked = true;
                    }
                    objStockist = new Supper_stockist_management();
                    objStockist.Stockist_id = Convert.ToInt32(Request.QueryString["sid"]);
                    objStockist.SpOperation = "SELECT_STATE";
                    dtStockist = new DataTable();
                    dtStockist = objStockist.SaveStockist();

                    if (dtStockist.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtStockist.Rows.Count; i++)
                        {
                            select2.Items.FindByText(dtStockist.Rows[i]["REGION"].ToString().ToUpper()).Selected = true;
                        }
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
                BindRegion();
                if (Request.QueryString["sid"] != null)
                {
                    txtStockistCode.ReadOnly = true;
                    Deactivate.Visible = true;
                    GetStockist();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["sid"] != null)
            {
                UpdateStockist();
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>UpdateOk();</script>");
            }
            else
            {
                if (CheckStockistCode() == false)
                {
                    SaveStockist();
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
                }
                else
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningCode();</script>");
                }
            }

        }

        #endregion
    }
}