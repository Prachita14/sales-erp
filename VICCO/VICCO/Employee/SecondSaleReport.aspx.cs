using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using VICCO.DAL;
using System.Data;
using System.IO;
using System.Drawing;

#endregion

namespace VICCO
{
    public partial class SecondSaleReport : System.Web.UI.Page
    {
        #region "Public Function"

        public void BindMaterialName()
        {
            Material_management objMaterial = new Material_management();
            objMaterial.SpOperation = "SELECT";
            DataTable dtMaterial = new DataTable();
            dtMaterial = objMaterial.SaveMaterial();

            auto_select1.DataSource = dtMaterial;
            auto_select1.DataValueField = "MATERIAL_ID";
            auto_select1.DataTextField = "MATERIAL_DESCREPTION";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Material Name", "0"));
        }

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

            auto_select2.DataSource = dtStockist;
            auto_select2.DataValueField = "STOCKIST_ID";
            auto_select2.DataTextField = "NAME";
            auto_select2.DataBind();
            auto_select2.Items.Insert(0, new ListItem("Super Stockist Name", "0"));
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

        public void GetSeconSaleReport()
        {
            try
            {
                Employee_Report_Managment objReport = new Employee_Report_Managment();
                objReport.Employee_id = Convert.ToInt32(Request.Cookies["EMP_ID"].Value);

                if (auto_select2.SelectedIndex != -1)
                {
                    objReport.stockist_id = Convert.ToInt32(auto_select2.SelectedItem.Value);
                }

                if (auto_select1.SelectedIndex != -1)
                {
                    objReport.Material_ids = hdMaterialId.Value;
                }

                if (ddlRegion.SelectedItem.Text != "All Region")
                {
                    objReport.Region = ddlRegion.SelectedItem.Text;
                }

                if (txtFromDate.Text != "")
                {
                    objReport.from_date = Convert.ToDateTime(txtFromDate.Text);
                }

                if (txttoDate.Text != "")
                {
                    objReport.To_date = Convert.ToDateTime(txttoDate.Text);
                }

                objReport.SpOperation = "ITEM_WISE_SECOND_SALE";
                DataTable dtReport = new DataTable();
                dtReport = objReport.GetReport();

                grdReport.DataSource = dtReport;
                grdReport.DataBind();

                if (dtReport.Rows.Count > 0)
                {
                    grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReport.UseAccessibleHeader = true;
                }

                Session["DataSource"] = dtReport;

                if (dtReport.Rows.Count == 0)
                {
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

        #endregion

        #region "Event"

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["EMP_ID"] == null)
            {
                Response.Redirect("~/Employee/EmployeeLogin.aspx");
            }

            if (!IsPostBack)
            {
                BindRegion();
                BindMaterialName();
                BindStockistName();

                txtFromDate.Text = Convert.ToDateTime("1 " + System.DateTime.Now.ToString("MMM yyyy")).ToString("yyyy-MM-dd");
                txttoDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
            }
        }       

        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ItemWiseSecondSaleReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages

                grdReport.AllowPaging = false;
                grdReport.DataSource = Session["DataSource"];
                grdReport.DataBind();

                grdReport.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grdReport.HeaderRow.Cells)
                {
                    cell.BackColor = grdReport.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdReport.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdReport.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdReport.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdReport.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void grdSecondSaleReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdReport.PageIndex = e.NewPageIndex;
            grdReport.DataSource = Session["DataSource"];
            grdReport.DataBind();
        }

        protected void btnSearch_Report(object sender, EventArgs e)
        {
            GetSeconSaleReport();
        }

        protected void ddlRegion_Change(object sender, EventArgs e)
        {
            BindStockistName();
        }

        #endregion
    }
}