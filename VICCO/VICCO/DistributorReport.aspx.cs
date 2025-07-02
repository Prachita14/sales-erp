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
    public partial class DistributorReport : System.Web.UI.Page
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
            auto_select1.Items.Insert(0, new ListItem("Stockist Name", "0"));
        }

        public void BindDistributorName()
        {
            Distributor_Management objDistributor = new Distributor_Management();
            if (auto_select1.SelectedIndex != -1)
            {
                objDistributor.Stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
            }
            objDistributor.SpOperation = "SELECT";
            DataTable dtDistributor = new DataTable();
            dtDistributor = objDistributor.SaveDistributor();

            auto_select2.DataSource = dtDistributor;
            auto_select2.DataValueField = "DISTRIBUTOR_ID";
            auto_select2.DataTextField = "NAME";
            auto_select2.DataBind();
            auto_select2.Items.Insert(0, new ListItem("Distributor Name", "0"));
        }

        public void GetDistributor()
        {
            try
            {
                Distributor_Management objDistributor = new Distributor_Management();
                objDistributor.code = txtDistributorCode.Text;
                if (auto_select1.SelectedIndex != -1)
                {
                    objDistributor.Stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }
                if (auto_select2.SelectedIndex != -1)
                {
                    objDistributor.Distributor_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }
                objDistributor.SpOperation = "SELECT";
                DataTable dtDistributor = new DataTable();
                dtDistributor = objDistributor.SaveDistributor();


                if (dtDistributor.Rows.Count > 0)
                {
                    grdReport.DataSource = dtDistributor;
                    if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 4)
                    {
                        grdReport.Columns[8].Visible = false;
                        grdReport.Columns[9].Visible = false;
                    }
                    grdReport.DataBind();

                    grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReport.UseAccessibleHeader = true;
                }

                if (dtDistributor.Rows.Count == 0)
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

        public void GetDistributorByid(int distributor_id)
        {
            try
            {
                Distributor_Management objDistributor = new Distributor_Management();
                objDistributor.Distributor_id = distributor_id;
                objDistributor.SpOperation = "SELECT";
                DataTable dtDistributor = new DataTable();
                dtDistributor = objDistributor.SaveDistributor();

                if (dtDistributor.Rows.Count > 0)
                {
                    lblCode.Text = Convert.ToString(dtDistributor.Rows[0]["CODE"]);
                    lblName.Text = Convert.ToString(dtDistributor.Rows[0]["NAME"]);
                    lblStockistName.Text = Convert.ToString(dtDistributor.Rows[0]["STOCKIST_NAME"]);
                    lblAddress.Text = Convert.ToString(dtDistributor.Rows[0]["ADDRESS"]);
                    lblDistrict.Text = Convert.ToString(dtDistributor.Rows[0]["DISTRICT"]);
                    lblCity.Text = Convert.ToString(dtDistributor.Rows[0]["CITY"]);
                    lblPincode.Text = Convert.ToString(dtDistributor.Rows[0]["PINCODE"]);
                    lblRegion.Text = Convert.ToString(dtDistributor.Rows[0]["REGION"]);
                    lblState.Text = Convert.ToString(dtDistributor.Rows[0]["STATE"]);
                    lblPhoneNo.Text = Convert.ToString(dtDistributor.Rows[0]["PHONE_NUMBER"]);
                    lblMobileNo.Text = Convert.ToString(dtDistributor.Rows[0]["MOBILE_NUMBER"]);
                    lblEmail.Text = Convert.ToString(dtDistributor.Rows[0]["EMAIL"]);
                    lblCountry.Text = Convert.ToString(dtDistributor.Rows[0]["COUNTRY"]);
                    lblContactPerson.Text = Convert.ToString(dtDistributor.Rows[0]["CONTACT_PERSON"]);
                    lblPan.Text = Convert.ToString(dtDistributor.Rows[0]["PAN"]);
                    lblLst.Text = Convert.ToString(dtDistributor.Rows[0]["LST"]);
                    lblGSTIn.Text = Convert.ToString(dtDistributor.Rows[0]["CST"]);
                    lblTpt.Text = Convert.ToString(dtDistributor.Rows[0]["TPT"]);
                    lbltype.Text = Convert.ToString(dtDistributor.Rows[0]["Is_Active"]);
                    

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
            if (!IsPostBack)
            {
                BindStockistName();
                BindDistributorName();
                //GetDistributor();
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

        protected void btnSearch_Distributor(object sender, EventArgs e)
        {
            GetDistributor();
        }

        protected void lnkView_Click(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdReport.DataKeys[selRowIndex].Value.ToString();
            GetDistributorByid(Convert.ToInt32(id));
            myModal.Style.Add("display", "block");
            grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
            grdReport.UseAccessibleHeader = true;
        }

        protected void auto_select1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistributorName();
        }
    }
}