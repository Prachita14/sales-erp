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

#endregion

namespace VICCO
{
    public partial class EmployeeMasterReport : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void BindDesignation()
        {
            try
            {
                Authorization_management objAutho = new Authorization_management();
                objAutho.SpOperation = "SELECT";
                DataTable dtAutho = new DataTable();
                dtAutho = objAutho.SaveAuthorization();

                auto_select2.DataSource = dtAutho;
                auto_select2.DataTextField = "POSITION";
                auto_select2.DataValueField = "POSITION_ID";
                auto_select2.DataBind();
                auto_select2.Items.Insert(0, new ListItem("Designation Name", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetEmployee()
        {
            try
            {
                Employee_master_management objMaterial = new Employee_master_management();

                if (auto_select2.SelectedItem.Value != "0")
                {
                    objMaterial.DESIGNATION_ID = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }

                if (auto_select1.SelectedItem.Value != "0")
                {
                    objMaterial.EMP_ID = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }

                objMaterial.SpOperation = "SELECT";
                DataTable dtMaterial = new DataTable();
                dtMaterial = objMaterial.SaveEmployee();

                if (dtMaterial.Rows.Count > 0)
                {
                    Session["DataSource"] = dtMaterial;

                    grdReport.DataSource = dtMaterial;
                    
                    if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 4)
                    {
                        grdReport.Columns[9].Visible = false;
                    }

                    grdReport.DataBind();

                    grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReport.UseAccessibleHeader = true;

                    if (dtMaterial.Rows.Count == 0)
                    {
                        errorMsg.Visible = true;
                        grdReport.Visible = false;
                    }
                    else
                    {
                        errorMsg.Visible = false;
                        grdReport.Visible = true;
                    }
                }
                else {
                    errorMsg.Visible = true;
                    grdReport.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindEmployeeWithCode()
        {
            try
            {
                Employee_master_management objAutho = new Employee_master_management();
                objAutho.SpOperation = "SELECT";
                DataTable dtAutho = new DataTable();
                dtAutho = objAutho.SaveEmployee();

                auto_select1.DataSource = dtAutho;
                auto_select1.DataTextField = "EMPLOYEE_DESCREPTION";
                auto_select1.DataValueField = "EMP_ID";
                auto_select1.DataBind();
                auto_select1.Items.Insert(0, new ListItem("Employee Name", "0"));
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
                BindDesignation();
                BindEmployeeWithCode();
                GetEmployee();
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

        protected void btnSearch_material(object sender, EventArgs e)
        {
            GetEmployee();
        }

        public void btndeleteclick(object sender, EventArgs e)
        {
            try
            {
                int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
                string id = grdReport.DataKeys[selRowIndex].Value.ToString();
                Employee_master_management objMaterial = new Employee_master_management();
                objMaterial.SpOperation = "DELETE";
                objMaterial.EMP_ID = Convert.ToInt32(id);
                DataTable dtUser = new DataTable();
                dtUser = objMaterial.SaveEmployee();

                GetEmployee();
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}