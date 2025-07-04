﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


#region "Additional Namespaces"

using VICCO.DAL;
using System.Data;

#endregion

namespace VICCO
{
    public partial class Autogeneratedpohistory : System.Web.UI.Page
    {
        #region "Public Function"

        public void BindStockistName()
        {
            Supper_stockist_management objStockist = new Supper_stockist_management();
            objStockist.SpOperation = "SELECT";
            DataTable dtStockist = new DataTable();
            dtStockist = objStockist.SaveStockist();

            ddlSupper.DataSource = dtStockist;
            ddlSupper.DataValueField = "STOCKIST_ID";
            ddlSupper.DataTextField = "NAME";
            ddlSupper.DataBind();
            ddlSupper.Items.Insert(0, new ListItem("Super Stockist Name", "0"));
        }

        public void GetStockAlertHistory()
        {
            try
            {
                Super_Auto_GenratePO objStock = new Super_Auto_GenratePO();

                if (txtFromDate.Text != "")
                {
                    objStock.DATE = Convert.ToDateTime(txtFromDate.Text);
                }

                if(txttoDate.Text!="")
                {
                    objStock.TO_DATE = Convert.ToDateTime(txttoDate.Text);
                }

                if (ddlSupper.SelectedItem.Value != "0")
                {
                    objStock.STOCKIST_ID = Convert.ToInt32(ddlSupper.SelectedItem.Value);
                }

                objStock.SP_OPERATION = "GET_PO";
                DataTable dt = new DataTable();
                dt = objStock.Getstock();

                grdReportNoExport.DataSource = dt;
                grdReportNoExport.DataBind();

                if (dt.Rows.Count == 0)
                {
                    errorMsg.Visible = true;
                }
                else
                {
                    grdReportNoExport.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdReportNoExport.UseAccessibleHeader = true;
                    errorMsg.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetDeactiveStock()
        {
            try
            {
                Super_Auto_GenratePO objStock = new Super_Auto_GenratePO();
                objStock.IS_NOT_GENERATE = "FALSE";

                if (ddlSupper.SelectedItem.Value != "0")
                {
                    objStock.STOCKIST_ID = Convert.ToInt32(ddlSupper.SelectedItem.Value);
                }

                objStock.SP_OPERATION = "SELECT_ALL";
                DataTable dt = new DataTable();
                dt = objStock.Getstock();

                grdDeactiveProduct.DataSource = dt;
                grdDeactiveProduct.DataBind();

                if (dt.Rows.Count == 0)
                {
                    erroeMsgDeactive.Visible = true;
                    btnPo.Visible = false;
                }
                else
                {
                    erroeMsgDeactive.Visible = false;
                    btnPo.Visible = true;
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
                txtFromDate.Text = Convert.ToDateTime("1 " + System.DateTime.Now.ToString("MMM yyyy")).ToString("yyyy-MM-dd");
                txttoDate.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

                BindStockistName();
                GetStockAlertHistory();
                GetDeactiveStock();
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

        protected void btnClickUpdateActive(object sender, EventArgs e)
        {
            Super_Auto_GenratePO objStock = new Super_Auto_GenratePO();
            foreach (GridViewRow gvrow in grdDeactiveProduct.Rows)
            {
                var checkbox = gvrow.FindControl("CheckBox1") as CheckBox;
                string id = grdDeactiveProduct.DataKeys[gvrow.RowIndex].Value.ToString();

                objStock.ID = Convert.ToInt32(id);

                if (checkbox.Checked)
                {
                    objStock.IS_NOT_GENERATE = "True";
                }
                else
                {
                    objStock.IS_NOT_GENERATE = "False";
                }

                objStock.SP_OPERATION = "UPDATE";
                objStock.Getstock();
            }

            GetDeactiveStock();
            GetStockAlertHistory();
        }

        protected void btnSearch_Stockist(object sender, EventArgs e)
        {
            GetStockAlertHistory();
        }
    }
}