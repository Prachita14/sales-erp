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
using System.Text;

#endregion


namespace VICCO
{
    public partial class EmployeeMaster : System.Web.UI.Page
    {

        #region "Variables"

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Function"

        public void GetEmployee()
        {
            try
            {
                Employee_master_management objEmployee = new Employee_master_management();
                objEmployee.EMP_ID = Convert.ToInt32(Request.QueryString["Eid"]);
                objEmployee.SpOperation = "SELECT";
                DataTable dtMaterial = new DataTable();
                dtMaterial = objEmployee.SaveEmployee();

                if (dtMaterial.Rows.Count > 0)
                {
                    txtEmployeeCode.Text = Convert.ToString(dtMaterial.Rows[0]["EMP_CODE"]);
                    txtEmployeeName.Text = Convert.ToString(dtMaterial.Rows[0]["EMP_NAME"]);
                    txtPassword.Text = Convert.ToString(dtMaterial.Rows[0]["EMP_PASSWORD"]);
                    txtEmail.Text = Convert.ToString(dtMaterial.Rows[0]["EMP_EMAIL"]);

                    if (Convert.ToString(dtMaterial.Rows[0]["JOINING_DATE"]) != "")
                    {
                        txtJoindate.Text = Convert.ToDateTime(dtMaterial.Rows[0]["JOINING_DATE"]).ToString("yyyy-MM-dd");
                    }

                    if (Convert.ToString(dtMaterial.Rows[0]["DEACTIVE_DATE"]) != "")
                    {
                        txtDeactiveDate.Text = Convert.ToDateTime(dtMaterial.Rows[0]["DEACTIVE_DATE"]).ToString("yyyy-MM-dd");
                    }

                    auto_select1.SelectedItem.Text = Convert.ToString(dtMaterial.Rows[0]["POSITION"]);
                    auto_select1.SelectedItem.Value = Convert.ToString(dtMaterial.Rows[0]["POSITION_ID"]);

                    GetParents();

                    if (Convert.ToString(dtMaterial.Rows[0]["PARENT_NAME"]) != "")
                    {
                        auto_select2.SelectedItem.Text = Convert.ToString(dtMaterial.Rows[0]["PARENT_NAME"]);
                        auto_select2.SelectedItem.Value = Convert.ToString(dtMaterial.Rows[0]["PARENT_ID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CreateEmployeeCde()
        {

            sda = new SqlDataAdapter("SELECT MAX(CAST(REPLACE(EMP_CODE,'EM',0) AS INT)) AS EMP_CODE FROM EMPOLYEE_MASTER", scon);
            DataTable dtCl = new DataTable();
            sda.Fill(dtCl);

            if (dtCl.Rows.Count > 0)
            {
                if (Convert.ToString(dtCl.Rows[0]["EMP_CODE"]) != "")
                {
                    int id_count = Convert.ToInt32(dtCl.Rows[0]["EMP_CODE"]).ToString().Length;

                    string substring = "EM";

                    for (int i = id_count; i < 5; i++)
                    {
                        substring += "0";
                    }

                    string s = substring + Convert.ToString(Convert.ToInt32(dtCl.Rows[0]["EMP_CODE"]) + 1);
                    txtEmployeeCode.Text = s;
                    return s;
                }
                else
                {
                    txtEmployeeCode.Text = "EM00001";
                    return "EM00001";

                }
            }
            else
            {
                txtEmployeeCode.Text = "EM00001";
                return "EM00001";

            }

        }

        public void BindDesignation()
        {
            try
            {
                Authorization_management objAutho = new Authorization_management();
                objAutho.SpOperation = "SELECT";
                DataTable dtAutho = new DataTable();
                dtAutho = objAutho.SaveAuthorization();

                auto_select1.DataSource = dtAutho;
                auto_select1.DataTextField = "POSITION";
                auto_select1.DataValueField = "POSITION_ID";
                auto_select1.DataBind();
                auto_select1.Items.Insert(0, new ListItem("Designation Name", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetParents()
        {
            try
            {
                Employee_master_management objEmployee = new Employee_master_management();
                objEmployee.DESIGNATION_ID = Convert.ToInt32(auto_select1.SelectedItem.Value);
                objEmployee.SpOperation = "GET_PARENTS";
                DataTable dtMaterial = new DataTable();
                dtMaterial = objEmployee.SaveEmployee();

                auto_select2.DataSource = dtMaterial;
                auto_select2.DataTextField = "EMP_NAME";
                auto_select2.DataValueField = "EMP_ID";
                auto_select2.DataBind();
                auto_select2.Items.Insert(0, new ListItem("Parents Name", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void InsertEmployee()
        {

            try
            {
                Employee_master_management objEmp = new Employee_master_management();
                objEmp.Parent_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                objEmp.EMP_CODE = txtEmployeeCode.Text;
                objEmp.EMP_NAME = txtEmployeeName.Text;
                objEmp.DESIGNATION_ID = Convert.ToInt32(auto_select1.SelectedItem.Value);
                objEmp.EMP_EMAIL = txtEmail.Text;
                objEmp.EMP_PASSWORD = txtPassword.Text;

                if (txtJoindate.Text != "")
                {
                    objEmp.Joining_Date = Convert.ToDateTime(txtJoindate.Text);
                }

                objEmp.SpOperation = "Insert";
                DataTable dtEmp = new DataTable();
                dtEmp = objEmp.SaveEmployee();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void UpdateEmployee()
        {

            try
            {
                Employee_master_management objEmp = new Employee_master_management();
                objEmp.EMP_ID = Convert.ToInt32(Request.QueryString["Eid"]);
                objEmp.Parent_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                objEmp.EMP_CODE = txtEmployeeCode.Text;
                objEmp.EMP_NAME = txtEmployeeName.Text;
                objEmp.DESIGNATION_ID = Convert.ToInt32(auto_select1.SelectedItem.Value);
                objEmp.EMP_EMAIL = txtEmail.Text;
                objEmp.EMP_PASSWORD = txtPassword.Text;

                if (txtJoindate.Text != "")
                {
                    objEmp.Joining_Date = Convert.ToDateTime(txtJoindate.Text);
                }
                if (txtDeactiveDate.Text != "")
                {
                    objEmp.Deactive_date = Convert.ToDateTime(txtDeactiveDate.Text);
                }

                objEmp.SpOperation = "UPDATE";
                DataTable dtEmp = new DataTable();
                dtEmp = objEmp.SaveEmployee();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region "Events"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Eid"] == null)
            {
                CreateEmployeeCde();
            }

            if (!IsPostBack)
            {
                BindDesignation();

                if(Request.QueryString["Eid"] != null)
                {
                    GetEmployee();
                }
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["Eid"] != null)
            {
                UpdateEmployee();
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>UpdateOk();</script>");
            }
            else
            {
                InsertEmployee();
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
            }
        }

        protected void DesignationChange(object sender, EventArgs e)
        {
                GetParents();
        }

        #endregion

    }
}