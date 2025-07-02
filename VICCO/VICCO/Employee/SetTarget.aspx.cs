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
using System.IO;
using System.Drawing;
using Microsoft.Reporting.WebForms;

#endregion

namespace VICCO.Employee
{
    public partial class SetTarget : System.Web.UI.Page
    {
        #region "Public Function"

        public void BindStockistName()
        {
            Employee_Report_Managment objStockist = new Employee_Report_Managment();
            objStockist.Employee_id = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
            if (ddlRegion.SelectedItem.Text != "All Region")
            {
                objStockist.Region = ddlRegion.SelectedItem.Text;
            }

            objStockist.SpOperation = "GET_STOCKIST";
            DataTable dtStockist = new DataTable();
            dtStockist = objStockist.GetReport();

            auto_select1.DataSource = dtStockist;
            auto_select1.DataValueField = "STOCKIST_ID";
            auto_select1.DataTextField = "NAME";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Super Stockist Name", "0"));
        }

        public void BindDistributorName()
        {
            Employee_Report_Managment objDistributor = new Employee_Report_Managment();
            objDistributor.Employee_id = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
            if (auto_select1.SelectedIndex != -1)
            {
                objDistributor.stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
            }

            if (auto_select3.SelectedItem.Text != "District Name")
            {
                objDistributor.District = auto_select3.SelectedItem.Text;
            }

            if (ddlRegion.SelectedItem.Text != "All Region")
            {
                objDistributor.Region = ddlRegion.SelectedItem.Text;
            }

            objDistributor.SpOperation = "GET_DISTRIBUTOR";
            DataTable dtDistributor = new DataTable();
            dtDistributor = objDistributor.GetReport();

            auto_select2.DataSource = dtDistributor;
            auto_select2.DataValueField = "DISTRIBUTOR_ID";
            auto_select2.DataTextField = "DISTRIBUTOR_NAME";
            auto_select2.DataBind();
            auto_select2.Items.Insert(0, new ListItem("Distributor Name", "0"));
        }

        public void BindRegion()
        {
            try
            {
                Employee_Report_Managment objRegion = new Employee_Report_Managment();
                objRegion.Employee_id = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
                objRegion.SpOperation = "GET_REGION";
                ddlRegion.DataSource = objRegion.GetReport();
                ddlRegion.DataTextField = "REGION_NAME";
                ddlRegion.DataValueField = "REGION_ID";
                ddlRegion.DataBind();
                ddlRegion.Items.Insert(0, new ListItem("All Region", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        public void BindDistrict()
        {
            try
            {
                Employee_Report_Managment objDistrict = new Employee_Report_Managment();
                objDistrict.Employee_id = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);

                if (auto_select1.SelectedIndex != -1)
                {
                    objDistrict.stockist_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }

                if (ddlRegion.SelectedItem.Text != "All Region")
                {
                    objDistrict.Region = ddlRegion.SelectedItem.Text;
                }

                objDistrict.SpOperation = "GET_DISTRICT";
                DataTable dtCriteria = new DataTable();
                dtCriteria = objDistrict.GetReport();

                auto_select3.DataSource = dtCriteria;
                auto_select3.DataTextField = "DISTRICT";
                auto_select3.DataValueField = "DISTRICT";
                auto_select3.DataBind();
                auto_select3.Items.Insert(0, new ListItem("District Name", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindMaterialName()
        {
            Target_Managment objTarget = new Target_Managment();

            objTarget.DISTRIBUTOR_ID = Convert.ToInt32(auto_select2.SelectedItem.Value);

            if (auto_select8.SelectedItem.Value != "0")
            {
                objTarget.MATERIAL_ID = Convert.ToInt32(auto_select8.SelectedItem.Value);
            }

            objTarget.TO_DATE = System.DateTime.Now;

            objTarget.SP_OPERATION = "SELECT";
            DataTable dtMaterial = new DataTable();
            dtMaterial = objTarget.SaveTarget();


            if (dtMaterial.Rows.Count > 0)
            {
                Session["DataSource"] = dtMaterial;

                grdMaterial.DataSource = dtMaterial;
                grdMaterial.DataBind();

                if (dtMaterial.Rows.Count == 0)
                {
                    errorMsg.Visible = true;
                }
                else
                {
                    errorMsg.Visible = false;
                }
            }
        }

        public void GetMaterialByCodeAndName()
        {
            try
            {
                Target_Managment objTarget = new Target_Managment();

                objTarget.DISTRIBUTOR_ID = Convert.ToInt32(auto_select2.SelectedItem.Value);
                objTarget.MATERIAL_ID = Convert.ToInt32(auto_select8.SelectedItem.Value);


                objTarget.SP_OPERATION = "GET_MATERIAL";
                DataTable dtReport = new DataTable();
                dtReport = objTarget.SaveTarget();
                grdMaterial.DataSource = dtReport;
                grdMaterial.DataBind();

                Session["DataSource"] = dtReport;

                if (dtReport.Rows.Count == 0)
                {
                    errorMsg.Visible = true;
                    //btnExport.Visible = false;
                }
                else
                {
                    errorMsg.Visible = false;
                    //btnExport.Visible = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveTarget(int id, string Material_id, string Target, string FromDate, string ToDate)
        {

            try
            {
                Target_Managment objTarget = new Target_Managment();
                objTarget.ID = id;
                objTarget.MATERIAL_ID = Convert.ToInt32(Material_id);
                objTarget.DISTRIBUTOR_ID = Convert.ToInt32(auto_select2.SelectedItem.Value);
                if (FromDate != "")
                {
                    objTarget.FROM_DATE = Convert.ToDateTime(FromDate);
                }
                if (ToDate != "")
                {
                    objTarget.TO_DATE =  Convert.ToDateTime((Convert.ToDateTime(ToDate).ToString("dd MMM yyyy")));
                }


                objTarget.TARGET = Convert.ToInt32(Target);


                objTarget.SP_OPERATION = "INSERT";
                DataTable drReport = new DataTable();
                drReport = objTarget.SaveTarget();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void BindMaterialNameFor()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.SpOperation = "SELECT";
            DataTable dtMaterial = new DataTable();
            dtMaterial = objMaterial.SaveMaterial();

            auto_select8.DataSource = dtMaterial;
            auto_select8.DataValueField = "MATERIAL_ID";
            auto_select8.DataTextField = "MATERIAL_DESCREPTION";
            auto_select8.DataBind();
            auto_select8.Items.Insert(0, new ListItem("Select All", "0"));
        }

        public void DeleteTarget(int id)
        {

            try
            {
                Target_Managment objTarget = new Target_Managment();
                objTarget.ID = id;
                objTarget.SP_OPERATION = "DELETE";
                DataTable drReport = new DataTable();
                drReport = objTarget.SaveTarget();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["EMP_ID"] == null)
            {
                Response.Redirect("~/Employee/EmployeeLogin.aspx");
            }

            if (!IsPostBack)
            {
                BindRegion();
                BindStockistName();
                BindDistrict();
                BindDistributorName();
                BindMaterialNameFor();
                // BindMaterialName();
            }
            errorMsg.Visible = false;
        }

        protected void grdMaterial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                TextBox txtFromDate = (e.Row.FindControl("txtFromDate") as TextBox);
                TextBox txttoDate = (e.Row.FindControl("txttoDate") as TextBox);
                TextBox txtSetTarget = (e.Row.FindControl("txtSetTarget") as TextBox);
                Button btnSearch = (e.Row.FindControl("btnSearch") as Button);
                LinkButton lnkDelete = (e.Row.FindControl("lnkDelete") as LinkButton);

                //txtFromDate.Attributes["min"] = System.DateTime.Now.ToString("yyyy-MM-dd");
                //txttoDate.Attributes["min"] = System.DateTime.Now.ToString("yyyy-MM-dd");

                if (txtSetTarget.Text != "0")
                {
                    btnSearch.Visible = false;
                    lnkDelete.Visible = false;
                    txtSetTarget.ReadOnly = true;
                    txtFromDate.ReadOnly = true;
                    txttoDate.ReadOnly = true;
                }
                else
                {
                    btnSearch.Visible = true;
                    lnkDelete.Visible = false;
                }
                
            }
        }

        protected void auto_select1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            BindDistributorName();
        }

        protected void ddlRegion_Change(object sender, EventArgs e)
        {
            BindStockistName();
            BindDistributorName();
        }

        protected void ddlDistrict_Change(object sender, EventArgs e)
        {
            BindDistributorName();
        }

        protected void btnTarget_Click(object sender, EventArgs e)
        {
            pnlSearch.Visible = true;
            BindMaterialName();
        }

        protected void btnSearch_Report(object sender, EventArgs e)
        {
            BindMaterialName();
            auto_select8.ClearSelection();
        }

        //protected void grdMaterial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grdMaterial.PageIndex = e.NewPageIndex;
        //    grdMaterial.DataSource = Session["DataSource"];
        //    grdMaterial.DataBind();
        //}

        protected void btnSavetarget_Click(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((Button)sender).Parent.Parent)).RowIndex;
            string id = grdMaterial.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdMaterial.Rows[selRowIndex];

            Label lblMaterialid = (row.FindControl("lblMaterialId") as Label);
            TextBox txtSetTarget = (row.FindControl("txtSetTarget") as TextBox);
            TextBox txtFromDate = (row.FindControl("txtFromDate") as TextBox);
            TextBox txtToDate = (row.FindControl("txttoDate") as TextBox);

            if (txtSetTarget.Text == "0")
            {
                txtSetTarget.CssClass = "form-control error";
            }
            else
            {
                txtSetTarget.CssClass = "form-control";
            }

            if (txtFromDate.Text == "")
            {
                txtFromDate.CssClass = "form-control error";
            }
            else
            {
                txtFromDate.CssClass = "form-control";
            }

            if (txtToDate.Text == "")
            {
                txtToDate.CssClass = "form-control error";
            }
            else
            {
                txtToDate.CssClass = "form-control";
            }

            if (txtFromDate.Text != "" && txtToDate.Text!="")
            {
                SaveTarget(Convert.ToInt32(id), lblMaterialid.Text, txtSetTarget.Text, txtFromDate.Text, txtToDate.Text);
                BindMaterialName();
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SaveOk();</script>");
            }
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdMaterial.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdMaterial.Rows[selRowIndex];

            DeleteTarget(Convert.ToInt32(id));
            BindMaterialName();
        }

    }
}