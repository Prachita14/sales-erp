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
    public partial class MaterialReport : System.Web.UI.Page
    {
        #region "Variable

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void BindMaterialName()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.SpOperation = "SELECT";
            DataTable dtMaterial = new DataTable();
            dtMaterial = objMaterial.SaveMaterial();

            auto_select1.DataSource = dtMaterial;
            auto_select1.DataValueField = "MATERIAL_ID";
            auto_select1.DataTextField = "MATERIAL_NAME";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Material Name", "0"));
        }

        public void GetMaterial()
        {
            try
            {
                Material_management objMaterial = new Material_management();
                objMaterial.Material_code = txtMaterialCode.Text;
                if (auto_select1.SelectedIndex != -1)
                {
                    objMaterial.Material_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
                }
                objMaterial.SpOperation = "SELECT";
                DataTable dtMaterial = new DataTable();
                dtMaterial = objMaterial.SaveMaterial();

                if (dtMaterial.Rows.Count > 0)
                {
                    Session["DataSource"] = dtMaterial;

                    grdReport.DataSource = dtMaterial;

                    if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 4)
                    {
                        grdReport.Columns[8].Visible = false;
                    }

                    grdReport.DataBind();
                    grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReport.UseAccessibleHeader = true;

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
                BindMaterialName();
                GetMaterial();
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
            GetMaterial();
        }
    }
}