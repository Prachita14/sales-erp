using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VICCO.DAL;
using System.Data;
namespace VICCO
{
    public partial class DistributorMaterialReturn : System.Web.UI.Page
    {
        public void GetMaterialReturn()
        {
            try
            {
                Distributor_Material_Return objReturn = new Distributor_Material_Return();

                if (ddlAprove.SelectedItem.Text == "New Request")
                {
                    objReturn.SpOperation = "SELECT_NEW_REQUEST";
                }
                else if (ddlAprove.SelectedItem.Text == "Reject")
                {
                    objReturn.Approve = "False";
                    objReturn.SpOperation = "SELECT";
                }
                else if (ddlAprove.SelectedItem.Text == "Approved")
                {
                    objReturn.Approve = "True";
                    objReturn.SpOperation = "SELECT";
                }

                if (txtInvoice.Text != "")
                {
                    objReturn.invoice_no = Convert.ToString(txtInvoice.Text);
                }

                if (txtFromDate.Text != "")
                {
                    objReturn.Return_date = Convert.ToDateTime(txtFromDate.Text);
                }
               
                DataTable dtReturn = new DataTable();
                dtReturn = objReturn.SaveMaterialReturn();
                grdReport.DataSource = dtReturn;
                grdReport.DataBind();

                if (dtReturn.Rows.Count > 0)
                {
                    grdReport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReport.UseAccessibleHeader = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFromDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");
                GetMaterialReturn();
            }
        }

        protected void txtReturnMaterial_TextChanged(object sender, EventArgs e)
        {
            GetMaterialReturn();
        }

        protected void lnkApprove(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdReport.DataKeys[selRowIndex].Value.ToString();

            Distributor_Material_Return objReturn = new Distributor_Material_Return();
            objReturn.Return_id = Convert.ToInt32(id);
            objReturn.SpOperation = "DISTRIBUTOR_APPROVE";
            objReturn.SaveMaterialReturn();
            GetMaterialReturn();
        }

        protected void lnkReject(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdReport.DataKeys[selRowIndex].Value.ToString();

            Distributor_Material_Return objReturn = new Distributor_Material_Return();
            objReturn.Return_id = Convert.ToInt32(id);
            objReturn.SpOperation = "DISTRIBUTOR_REJECT";
            objReturn.SaveMaterialReturn();
            GetMaterialReturn();
        }

        protected void grdReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkapprove = (e.Row.FindControl("lnkApprove") as LinkButton);
                LinkButton lnkreject = (e.Row.FindControl("lnkRejcet") as LinkButton);
                Label lblApprove = (e.Row.FindControl("lblApprove") as Label);

                if (ddlAprove.SelectedItem.Text == "Approved" || ddlAprove.SelectedItem.Text == "Reject")
                {
                    lnkapprove.Visible = false;
                    lnkreject.Visible = false;
                    lblApprove.Visible = true;

                }

            }
        }
    }
}