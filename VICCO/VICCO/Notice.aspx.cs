using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VICCO.DAL;
using System.Data;
using System.Text.RegularExpressions;

namespace VICCO
{
    public partial class Notice : System.Web.UI.Page
    {
        #region Public Function

        public void SaveNotice()
        {
            try
            {
                Notice_Management objNotice = new Notice_Management();
                objNotice.Notice_text = Editor1.Content;
                objNotice.Plain_text = Regex.Replace(Editor1.Content, @"<(.|\n)*?>", string.Empty);

                if (chkStockist.Checked == true)
                {
                    objNotice.Is_Stockist = "Yes";
                }

                if (chkSales.Checked == true)
                {
                    objNotice.Is_Sales = "Yes";
                }

                objNotice.SpOperation = "INSERT";
                objNotice.SaveNotice();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetNoticeReport()
        {
            try
            {
                Notice_Management objNotice = new Notice_Management();

                objNotice.SpOperation = "SELECT";
                DataTable dt = new DataTable();
                dt = objNotice.SaveNotice();
                Session["DataSource"] = dt;
                grdNotice.DataSource = dt;
                grdNotice.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteNotice(int nid)
        {
            try
            {
                Notice_Management objNotice = new Notice_Management();
                objNotice.Notice_id = nid;
                objNotice.SpOperation = "DELETE";
                objNotice.SaveNotice();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateNotice(int nid)
        {
            try
            {
                Notice_Management objNotice = new Notice_Management();
                objNotice.Notice_id = nid;
                objNotice.Notice_text = Editor1.Content;
                objNotice.Plain_text = Regex.Replace(Editor1.Content, @"<(.|\n)*?>", string.Empty);

                if (chkStockist.Checked == true)
                {
                    objNotice.Is_Stockist = "Yes";
                }

                if (chkSales.Checked == true)
                {
                    objNotice.Is_Sales = "Yes";
                }
                objNotice.SpOperation = "UPDATE";
                objNotice.SaveNotice();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetNoticeReport();
                btnSubmit.Visible = true;
                btnUpdate.Visible = false;
            }
        }

        protected void grdNotice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdNotice.PageIndex = e.NewPageIndex;
            grdNotice.DataSource = Session["DataSource"];
            grdNotice.DataBind();
        }

        protected void btnSaveNotice(object sender, EventArgs e)
        {
            SaveNotice();
            GetNoticeReport();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
        }

        protected void btnDeleteConfirm(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdNotice.DataKeys[selRowIndex].Value.ToString();
            Session["Gridrow_id"] = id;
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>Confirm();</script>");
        }

        protected void btnDelete(object sender, EventArgs e)
        {
            DeleteNotice(Convert.ToInt32(Session["Gridrow_id"]));
            GetNoticeReport();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>DeleteOk();</script>");
        }

        protected bool SetVisibility(object desc, int maxLength)
        {
            var description = (string)desc;
            if (string.IsNullOrEmpty(description)) { return false; }
            return description.Length > maxLength;
        }

        protected void ReadMoreLinkButton_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdNotice.DataKeys[selRowIndex].Value.ToString();
            Session["id"] = id;
            GridViewRow row = button.NamingContainer as GridViewRow;
            Label descLabel = row.FindControl("Label2") as Label;
            button.Text = (button.Text == "Read More") ? "Hide" : "Read More";
            string temp = descLabel.Text;
            if (button.Text == "Hide")
            {
                Editor1.Content = descLabel.ToolTip;
            }
            else
            {
                Editor1.Content = string.Empty;
            }
            //descLabel.Text = descLabel.ToolTip;
            descLabel.ToolTip = temp;

            Notice_Management objNotice = new Notice_Management();
            objNotice.Notice_id = Convert.ToInt32(Session["id"]);
            objNotice.SpOperation = "SELECT_BY_ID";
            DataTable dt = new DataTable();
            dt = objNotice.SaveNotice();

            if (Convert.ToString(dt.Rows[0]["IS_STOCKIST"]) == "Yes")
            {
                chkStockist.Checked = true;
            }
            if (Convert.ToString(dt.Rows[0]["IS_SALES"]) == "Yes")
            {
                chkSales.Checked = true;
            }

            btnSubmit.Visible = false;
            btnUpdate.Visible = true;
        }

        protected string Limit(object desc, int maxLength)
        {
            var description = (string)desc;
            if (string.IsNullOrEmpty(description)) { return description; }
            return description.Length <= maxLength ?
            description : description.Substring(0, maxLength) + "...";
        }

        protected void btnUpdateNotice(object sender, EventArgs e)
        {
            UpdateNotice(Convert.ToInt32(Session["id"]));
            GetNoticeReport();
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>UpdateOk();</script>");
        }

        #endregion
    }
}
