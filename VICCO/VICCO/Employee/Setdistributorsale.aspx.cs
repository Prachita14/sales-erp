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
    public partial class Setdistributorsale : System.Web.UI.Page
    {
        #region "Public Function"

        public void BindDistributorName()
        {
            Employee_Report_Managment objDistributor = new Employee_Report_Managment();
            objDistributor.Employee_id = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);

            objDistributor.SpOperation = "GET_DISTRIBUTOR";
            DataTable dtDistributor = new DataTable();
            dtDistributor = objDistributor.GetReport();

            auto_select2.DataSource = dtDistributor;
            auto_select2.DataValueField = "DISTRIBUTOR_ID";
            auto_select2.DataTextField = "DISTRIBUTOR_NAME";
            auto_select2.DataBind();
            auto_select2.Items.Insert(0, new ListItem("Distributor Name", "0"));
        }

        public void Getyear()
        {
            var currentYear = DateTime.Today.Year;
            for (int i = 2; i >= 0; i--)
            {
                auto_select4.Items.Add((currentYear - i).ToString());
            }
        }

        public void GetMaterial()
        {
            try
            {
                DistributtorSale objSale = new DistributtorSale();
                objSale.DISTRIBUTOR_ID = Convert.ToInt32(auto_select2.SelectedItem.Value);

                DateTime date = Convert.ToDateTime("1 " + auto_select3.SelectedItem.Text + " " + auto_select4.SelectedItem.Text);
                objSale.FROM_DATE = Convert.ToDateTime("1 " + auto_select3.SelectedItem.Text + " " + auto_select4.SelectedItem.Text);
                objSale.TO_DATE = (new DateTime(date.Year, date.Month, 1).AddMonths(1)).AddDays(-1);

                objSale.SP_OPERATION = "SELECT";
                DataTable drReport = new DataTable();
                drReport = objSale.Savesales();

                grdMaterial.DataSource = drReport;
                grdMaterial.DataBind();

                if (drReport.Rows.Count > 0)
                {
                    btnSave.Visible = true;
                }
                else
                {
                    btnSave.Visible = false;
                }


                Rowcount.Value = drReport.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveSale(string Material_id, string Sale)
        {

            try
            {
                DistributtorSale objSale = new DistributtorSale();
                objSale.MATERIAL_ID = Convert.ToInt32(Material_id);
                objSale.DISTRIBUTOR_ID = Convert.ToInt32(auto_select2.SelectedItem.Value);

                DateTime date = Convert.ToDateTime("1 " + auto_select3.SelectedItem.Text + " " + auto_select4.SelectedItem.Text);
                objSale.FROM_DATE = Convert.ToDateTime("1 " + auto_select3.SelectedItem.Text + " " + auto_select4.SelectedItem.Text);
                objSale.TO_DATE = (new DateTime(date.Year, date.Month, 1).AddMonths(1)).AddDays(-1);

                objSale.SALE = Convert.ToInt32(Sale);
                objSale.CREATED_BY = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);
                objSale.CREATED_ON = System.DateTime.Now;

                objSale.SP_OPERATION = "INSERT";
                DataTable drReport = new DataTable();
                drReport = objSale.Savesales();
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
                BindDistributorName();
                Getyear();
            }
            errorMsg.Visible = false;
        }

        protected void grdMaterial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                TextBox txtSale = (e.Row.FindControl("txtSale") as TextBox);

                if (txtSale.Text != "0")
                {
                    txtSale.ReadOnly = true;
                }
            }
        }

        protected void auto_select1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistributorName();
        }

        protected void btnGetMaterial(object sender, EventArgs e)
        {
            GetMaterial();
        }

        protected void btnSaveClick(object sender, EventArgs e)
        {
            int Row_count = Convert.ToInt32(Rowcount.Value);
            for (int i = 0; i < Row_count; i++)
            {
                string id = grdMaterial.DataKeys[i].Value.ToString();
                GridViewRow row = grdMaterial.Rows[i];

                Label lblMaterialid = (row.FindControl("lblMaterialId") as Label);
                TextBox txtSale = (row.FindControl("txtSale") as TextBox);

                //if (txtSale.Text == "0")
                //{
                //    txtSale.CssClass = "form-control error";
                //}
                //else
                //{
                txtSale.CssClass = "form-control";
                SaveSale(lblMaterialid.Text, txtSale.Text);
                //}

            }
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SaveOk();</script>");
        }
    }
}