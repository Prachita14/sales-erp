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
    public partial class RoleControlaspx : System.Web.UI.Page
    {

        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Function"

        public void BindEmployeeWithCode()
        {
            try
            {
                Employee_master_management objAutho = new Employee_master_management();
                objAutho.SpOperation = "SELECT_FOR_DROPDOWN";
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

        public void GetRole()
        {
            try
            {
                Role_Management objRoleRegion = new Role_Management();
                objRoleRegion.Employee_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                objRoleRegion.SpOperation = "GET_ROLE";
                DataSet ds = new DataSet();
                ds = objRoleRegion.SaveRole();

                grdRoleRegion.DataSource = ds.Tables[0];
                grdRoleRegion.DataBind();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdRoleRegion.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdRoleRegion.UseAccessibleHeader = true;

                    foreach (GridViewRow row in grdRoleRegion.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("CheckBox1") as CheckBox);
                            HiddenField hidemp = (row.Cells[0].FindControl("HiddenField1") as HiddenField);

                            if (hidemp.Value != "")
                            {
                                chkRow.Checked = true;
                            }
                        }
                    }
                }

                grdRoleStockist.DataSource = ds.Tables[1];
                grdRoleStockist.DataBind();

                if (ds.Tables[1].Rows.Count > 0)
                {
                    grdRoleStockist.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdRoleStockist.UseAccessibleHeader = true;

                    foreach (GridViewRow row in grdRoleStockist.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("CheckBox1") as CheckBox);
                            HiddenField hidemp = (row.Cells[0].FindControl("HiddenField1") as HiddenField);

                            if (hidemp.Value != "")
                            {
                                chkRow.Checked = true;
                            }
                        }
                    }
                }

                grdRoleDistributor.DataSource = ds.Tables[2];
                grdRoleDistributor.DataBind();

                if (ds.Tables[2].Rows.Count > 0)
                {
                    grdRoleDistributor.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdRoleDistributor.UseAccessibleHeader = true;

                    foreach (GridViewRow row in grdRoleDistributor.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            CheckBox chkRow = (row.Cells[0].FindControl("CheckBox1") as CheckBox);
                            HiddenField hidemp = (row.Cells[0].FindControl("HiddenField1") as HiddenField);

                            if (hidemp.Value != "")
                            {
                                chkRow.Checked = true;
                            }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployeeWithCode();
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
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

        protected void ddlEmployee_SelectedIndexChange(object sender, EventArgs e)
        {
            GetRole();
        }

        protected void btnSaveRegion(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdRoleRegion.Rows)
            {
                string id = grdRoleRegion.DataKeys[row.DataItemIndex].Value.ToString();

                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("CheckBox1") as CheckBox);

                    Role_Management objRole = new Role_Management();

                    if (chkRow.Checked == true)
                    {
                        objRole.Region_id = Convert.ToInt32(id);
                        objRole.Employee_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                        objRole.SpOperation = "SAVE_REGION";
                        objRole.SaveRole();
                    }
                    else
                    {
                        objRole.Region_id = Convert.ToInt32(id);
                        objRole.Employee_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                        objRole.SpOperation = "DELETE_REGION";
                        objRole.SaveRole();
                    }
                }

            }
            GetRole();
        }

        protected void btnSaveStockist(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdRoleStockist.Rows)
            {
                string id = grdRoleStockist.DataKeys[row.DataItemIndex].Value.ToString();

                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("CheckBox1") as CheckBox);

                    Role_Management objRole = new Role_Management();

                    if (chkRow.Checked == true)
                    {
                        objRole.stockist_id = Convert.ToInt32(id);
                        objRole.Employee_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                        objRole.SpOperation = "SAVE_STOCKIST";
                        objRole.SaveRole();
                    }
                    else
                    {
                        objRole.stockist_id = Convert.ToInt32(id);
                        objRole.Employee_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                        objRole.SpOperation = "DELETE_STOCKIST";
                        objRole.SaveRole();
                    }
                }

            }
            GetRole();
        }

        protected void btnSaveDistributor(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdRoleDistributor.Rows)
            {
                string id = grdRoleDistributor.DataKeys[row.DataItemIndex].Value.ToString();

                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("CheckBox1") as CheckBox);

                    Role_Management objRole = new Role_Management();

                    if (chkRow.Checked == true)
                    {
                        objRole.Distributor_id = Convert.ToInt32(id);
                        objRole.Employee_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                        objRole.SpOperation = "SAVE_DISTRIBUTOR";
                        objRole.SaveRole();
                    }
                    else
                    {
                        objRole.Distributor_id = Convert.ToInt32(id);
                        objRole.Employee_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                        objRole.SpOperation = "DELETE_DISTRIBUTOR";
                        objRole.SaveRole();
                    }
                }

            }
            GetRole();
        }
    }
}