using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using VICCO.DAL.PURCHASE_ORDER;
using VICCO.DAL.PURCHASE_ORDER_PRODUCT;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Configuration;
using VICCO.DAL;

#endregion

namespace VICCO
{
    public partial class EditIgstInvoice : System.Web.UI.Page
    {
        #region "Variable"

        DataSet ds;
        SqlCommand scmd;
        SqlDataAdapter sda;
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion

        #region "Public Function"

        public void BindClient()
        {
            Distributor_Management objClient = new Distributor_Management();
            objClient.SpOperation = "SELECT_FOR_INVOICE";
            objClient.Stockist_id = Convert.ToInt32(Request.QueryString["sid"]);
            DataTable dtClient = new DataTable();
            dtClient = objClient.SaveDistributor();

            auto_select1.DataSource = dtClient;
            auto_select1.DataValueField = "DISTRIBUTOR_ID";
            auto_select1.DataTextField = "DISTRIBUTOR_NAME";
            auto_select1.DataBind();
            auto_select1.Items.Insert(0, new ListItem("Select Client", "0"));
        }

        public void GetClientProduct()
        {
            try
            {             
                Purches_Order_Product_Management objProduct = new Purches_Order_Product_Management();
                objProduct.Sp_Operation = "GET_PRODUCT_BY_PO_TEMP";
                objProduct.stockist_id = Convert.ToInt32(lblStockistid.Text);
                objProduct.PurchaseOrder_Id = Convert.ToInt32(lblPurchaseOederid.Text);

                DataTable dtProduct = new DataTable();
                dtProduct = objProduct.SaveUser();

                if (dtProduct.Rows.Count > 0)
                {
                    grdProduct.DataSource = dtProduct;
                    grdProduct.DataBind();

                    //Purches_Order_Product_Management objProductTotal = new Purches_Order_Product_Management();
                    //objProductTotal.Sp_Operation = "GET_PRODUCT_TOTAL_BY_CLIENT";
                    //objProductTotal.PurchaseOrder_Id = Convert.ToInt32(lblPurchaseOederid.Text);

                    //DataTable dtProductTotal = new DataTable();
                    //dtProductTotal = objProductTotal.SaveUser();

                    //if (dtProductTotal.Rows.Count > 0)
                    //{
                    //    txtGrandTotal.Text = Convert.ToString(dtProductTotal.Rows[0]["GRAND_TOTAL"]);
                    //}

                    grdProduct.HeaderRow.TableSection = TableRowSection.TableHeader;
                    grdProduct.UseAccessibleHeader = true;
                }
                if (dtProduct.Rows.Count == 1)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningStock();</script>");
                    }

                //    Button1.Enabled = false;
                //}
                //else
                //{
                //    Button1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckPono()
        {
            try
            {
                Purches_Order_Management objUser = new Purches_Order_Management();
                objUser.stockist_id = Convert.ToInt32(Request.QueryString["sid"]);
                objUser.Po_No = txtPoNo.Text;
                objUser.Purchaseorder_Id = Convert.ToInt32(lblPurchaseOederid.Text);
                objUser.Sp_Operation = "CHECK_PO_NO_EDIT";
                DataTable dtUser = new DataTable();
                dtUser = objUser.SaveUser();

                if (dtUser.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertToPurchaseOrder(string is_print)
        {

            Purches_Order_Management objUser = new Purches_Order_Management();
            objUser.User_Id = Convert.ToInt32(Request.Cookies["UserID"].Value);
            objUser.stockist_id = Convert.ToInt32(Request.QueryString["sid"]);
            objUser.gst_type = "igst";

            if (auto_select1.SelectedItem.Value != "")
            {
                objUser.Customer_id = Convert.ToInt32(auto_select1.SelectedItem.Value);
            }

            objUser.Purchaseorder_Id = Convert.ToInt32(lblPurchaseOederid.Text);
            objUser.Po_No = txtPoNo.Text;
           
            objUser.Date = Convert.ToDateTime(txtCalender.Text);
            objUser.Is_print = is_print;

            objUser.Delivery_Period = txtDelieveryPeriod.Text;
            objUser.Note = txtNote.Text;
            objUser.Payment_Terms = txtVehicle.Text;
            objUser.transport = txtNoOfCases.Text;
            objUser.Gst_no = ddlSalesOfficer.SelectedItem.Text;

            objUser.Sp_Operation = "INSERT_PURCHASE_ORDER_DETAIL";
            objUser.SaveUser();

            Purches_Order_Product_Management objProduct = new Purches_Order_Product_Management();
            objProduct.PurchaseOrder_Id = Convert.ToInt32(lblPurchaseOederid.Text);
            objProduct.Sp_Operation = "COPY_TEMP_PRODUCT_TOPO";
            objProduct.SaveUser();

        }

        public string InsertPurchaseOrderProduct(int id, int product_id, double qty, double rate, string hsn_code, double scheme, double disscount)
        {
            try
            {
                Purches_Order_Product_Management objPro1 = new Purches_Order_Product_Management();
                objPro1.Purchase_order_product_id = id;
                objPro1.stockist_id = Convert.ToInt32(Request.QueryString["sid"]);
                objPro1.Product_id = product_id;
                objPro1.Qty = qty;
                objPro1.Rate = rate;
                objPro1.Unit = hsn_code;
                objPro1.scheme = scheme;
                objPro1.disscount = disscount;
                objPro1.PurchaseOrder_Id = Convert.ToInt32(lblPurchaseOederid.Text);
                objPro1.Sp_Operation = "INSERT_PURCHASE_ORDER_PRODUCT";
                DataTable dtUser1 = new DataTable();
                dtUser1 = objPro1.SaveUser();
                txtGrandTotal.Text = Convert.ToString(dtUser1.Rows[0]["GRAND_TOTAL"]);
                return dtUser1.Rows[0]["MSG"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetPoDetailsByPo_no()
        {
            try
            {
                Purches_Order_Management objUser = new Purches_Order_Management();
                objUser.Purchaseorder_Id = Convert.ToInt32(Request.QueryString["invoiceno"]);
                objUser.Sp_Operation = "GET_PURCHASE_ORDER_BY_PO";
                DataTable dtUser = new DataTable();
                dtUser = objUser.SaveUser();

                lblPurchaseOederid.Text = Convert.ToString(Request.QueryString["invoiceno"]);

                int stockistId = Convert.ToInt32(dtUser.Rows[0]["STOCKIST_ID"]);
                lblStockistid.Text = Convert.ToString(stockistId);

                if (dtUser.Rows.Count > 0)
                {
                    txtCalender.Text = Convert.ToDateTime(dtUser.Rows[0]["DATE"]).ToString("yyyy-MM-dd");
                    txtNote.Text = Convert.ToString(dtUser.Rows[0]["NOTE"]);
                    txtPoNo.Text = Convert.ToString(dtUser.Rows[0]["PO_NO"]);
                    auto_select1.SelectedItem.Text = Convert.ToString(dtUser.Rows[0]["DISTRIBUTOR_NAME"]);
                    auto_select1.SelectedItem.Value = Convert.ToString(dtUser.Rows[0]["DISTRIBUTOR_ID"]);

                    if (Convert.ToString(dtUser.Rows[0]["GST_NO"]) != "")
                    {
                        ddlSalesOfficer.SelectedItem.Value = Convert.ToString(dtUser.Rows[0]["GST_NO"]);
                        ddlSalesOfficer.SelectedItem.Text = Convert.ToString(dtUser.Rows[0]["GST_NO"]);
                    }

                    txtVehicle.Text = Convert.ToString(dtUser.Rows[0]["PAYMENT_TERMS"]);
                    txtNoOfCases.Text = Convert.ToString(dtUser.Rows[0]["TRANSPORT"]);
                    txtDelieveryPeriod.Text = Convert.ToString(dtUser.Rows[0]["DELIVERY_PERIOD"]);
                    txtNote.Text = Convert.ToString(dtUser.Rows[0]["NOTE"]);

                    Purches_Order_Product_Management objProduct = new Purches_Order_Product_Management();
                    objProduct.PurchaseOrder_Id = Convert.ToInt32(lblPurchaseOederid.Text);
                    objProduct.Sp_Operation = "COPY_PRODUCT_TO_TEMPPO";
                    objProduct.SaveUser();

                }

                ManageInvoiceAndStock(stockistId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveProduct(int purchase_product_id)
        {
            try
            {
                Purches_Order_Product_Management objPro1 = new Purches_Order_Product_Management();
                objPro1.Purchase_order_product_id = purchase_product_id;
                objPro1.Sp_Operation = "DELETE_PURCHASE_PRODUCT";
                DataTable dtUser1 = new DataTable();
                dtUser1 = objPro1.SaveUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ManageInvoiceAndStock( int stockistId)
        {
            try
            {
                Purches_Order_Management objDeletePurchase = new Purches_Order_Management();
                objDeletePurchase.User_Id = Convert.ToInt32(Request.Cookies["UserID"].Value);
                objDeletePurchase.stockist_id = stockistId;
                objDeletePurchase.Sp_Operation = "MANAGE_INVOICE_AND_STOCK";
                objDeletePurchase.SaveUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public string GetAvailableStock(int product_id)
        //{
        //    try
        //    {
        //        Purches_Order_Product_Management objstock = new Purches_Order_Product_Management();
        //        objstock.stockist_id = Convert.ToInt32(Request.QueryString["sid"]);
        //        objstock.Product_id = product_id;
        //        objstock.Sp_Operation = "GET_AVAILABLE_STOCK";
        //        DataTable dtStock = new DataTable();
        //        dtStock = objstock.SaveUser();

        //        if (dtStock.Rows.Count > 0)
        //        {
        //            return Convert.ToString(dtStock.Rows[0]["TOTAL_AVALIABLE_MATERIAL"]);
        //        }
        //        else
        //        {
        //            return "0";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void GetSalesOfficer()
        {
            Supper_stockist_management objsm = new Supper_stockist_management();
            objsm.SpOperation = "GET_SO_SUPER_WISE";
            DataTable dt = new DataTable();
            dt = objsm.SaveStockist();

            if (dt.Rows.Count > 0)
            {
                ddlSalesOfficer.DataSource = dt;
                ddlSalesOfficer.DataValueField = "EMP_NAME";
                ddlSalesOfficer.DataTextField = "EMP_NAME";
                ddlSalesOfficer.DataBind();
                ddlSalesOfficer.Items.Insert(0, new ListItem("Select SO", "0"));
            }

        }

        #endregion

        #region "Event"

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("index.aspx");
            }

            if (!IsPostBack)
            {
                //ManageInvoiceAndStock();
                //GetSiteDetailsAndNo();
                BindClient();
                GetSalesOfficer();

                if (Request.QueryString["invoiceno"] != null)
                {
                    //txtPoNo.Text = Convert.ToString(Request.QueryString["po_no"]);
                    //auto_select1.SelectedItem.Value = Convert.ToString(Request.QueryString["cid"]);
                    //auto_select1.SelectedItem.Text = Convert.ToString(Request.QueryString["cname"]);
                    GetPoDetailsByPo_no();
                }

                GetClientProduct();
            }
        }

        protected void Product_SelectedIndexChange(object sender, EventArgs e)
        {
            //InsertToPurchaseOrder("");
            int selRowIndex = ((GridViewRow)(((DropDownList)sender).Parent.Parent)).RowIndex;
            string id = grdProduct.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdProduct.Rows[selRowIndex];

            DropDownList Product_id = (row.FindControl("auto_selectProduct") as DropDownList);
            TextBox txtqty = (row.FindControl("txtQty") as TextBox);
            TextBox txtRate = (row.FindControl("txtRate") as TextBox);
            TextBox txtScheme = (row.FindControl("txtScheme") as TextBox);
            TextBox txtDisscount = (row.FindControl("txtDiscount") as TextBox);
            TextBox txtAvalibaleQty = (row.FindControl("txtAvailableQty") as TextBox);
            TextBox txtHsnCode = (row.FindControl("txtHsnCode") as TextBox);

            if (txtqty.Text == "")
            {
                txtqty.Text = "0";
            }

            if (txtRate.Text == "")
            {
                txtRate.Text = "0";
            }

            if (txtScheme.Text == "")
            {
                txtScheme.Text = "0";
            }
            if (txtDisscount.Text == "")
            {
                txtDisscount.Text = "0";
            }

            int p_id = 0;
            if (Product_id.SelectedItem.Value != "0")
            {
                p_id = Convert.ToInt32(Product_id.SelectedItem.Value);
            }


            double quantity = Convert.ToDouble(txtqty.Text);
            double rate = Convert.ToDouble(txtRate.Text);
            double Scheme = Convert.ToDouble(txtScheme.Text);
            double Disscount = Convert.ToDouble(txtDisscount.Text);

            string msg = InsertPurchaseOrderProduct(Convert.ToInt32(id), p_id, quantity, rate, txtHsnCode.Text, Scheme, Disscount);
            GetClientProduct();
            txtqty.Focus();

            if (msg != "")
            {
                ScriptManager.RegisterStartupScript(UpdatePanel1, this.GetType(), "MyAction1", "StockWarning();", true);
            }

            ScriptManager.RegisterStartupScript(
                        UpdatePanel1,
                        this.GetType(),
                        "MyAction",
                        "auto();",
                        true);
        }

        protected void ProductContent_TextChange(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((TextBox)sender).Parent.Parent)).RowIndex;
            string id = grdProduct.DataKeys[selRowIndex].Value.ToString();
            GridViewRow row = grdProduct.Rows[selRowIndex];

            DropDownList Product_id = (row.FindControl("auto_selectProduct") as DropDownList);
            TextBox txtqty = (row.FindControl("txtQty") as TextBox);
            TextBox txtRate = (row.FindControl("txtRate") as TextBox);
            TextBox txtScheme = (row.FindControl("txtScheme") as TextBox);
            TextBox txtDisscount = (row.FindControl("txtDiscount") as TextBox);
            TextBox txtHsnCode = (row.FindControl("txtHsnCode") as TextBox);

            if (txtqty.Text == "")
            {
                txtqty.Text = "0";
            }

            if (txtRate.Text == "")
            {
                txtRate.Text = "0";
            }

            if (txtScheme.Text == "")
            {
                txtScheme.Text = "0";
            }
            if (txtDisscount.Text == "")
            {
                txtDisscount.Text = "0";
            }

            int p_id = 0;
            if (Product_id.SelectedItem.Value != "0")
            {
                p_id = Convert.ToInt32(Product_id.SelectedItem.Value);
            }

            double quantity = Convert.ToDouble(txtqty.Text);
            double rate = Convert.ToDouble(txtRate.Text);
            double Scheme = Convert.ToDouble(txtScheme.Text);
            double Disscount = Convert.ToDouble(txtDisscount.Text);

            InsertPurchaseOrderProduct(Convert.ToInt32(id), p_id, quantity, rate, txtHsnCode.Text, Scheme, Disscount);
            GetClientProduct();

            TextBox txt = sender as TextBox;
            if (txt.ID == "txtRate")
            {
                txtScheme.Focus();
            }
            if (txt.ID == "txtQty")
            {
                txtRate.Focus();
            }
            if (txt.ID == "txtScheme")
            {
                txtDisscount.Focus();
            }

            ScriptManager.RegisterStartupScript(
                        UpdatePanel1,
                        this.GetType(),
                        "MyAction",
                        "auto();",
                        true);

        }

        protected void RemoveProduct(object sender, EventArgs e)
        {
            int selRowIndex = ((GridViewRow)(((LinkButton)sender).Parent.Parent)).RowIndex;
            string id = grdProduct.DataKeys[selRowIndex].Value.ToString();
            RemoveProduct(Convert.ToInt32(id));
            GetClientProduct();

            ScriptManager.RegisterStartupScript(
                       UpdatePanel1,
                       this.GetType(),
                       "MyAction",
                       "auto();",
                       true);
        }

        protected void grdProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the DropDownList in the Row
                DropDownList ddlProduct = (e.Row.FindControl("auto_selectProduct") as DropDownList);
                DropDownList ddlGst = (e.Row.FindControl("ddlGstRate") as DropDownList);

                Label lblProductName = (e.Row.FindControl("lblProductName") as Label);
                Label lblProduct_id = (e.Row.FindControl("lblProduct_id") as Label);

                TextBox txtAvalibaleQty = (e.Row.FindControl("txtAvailableQty") as TextBox);

                if (Session["Material_List"] == null)
                {
                    Material_management objMaterial = new Material_management();
                    objMaterial.SpOperation = "SELECT";
                    DataTable dtMaterial = new DataTable();
                    dtMaterial = objMaterial.SaveMaterial();
                    Session["Material_List"] = dtMaterial;
                }

                ddlProduct.DataSource = Session["Material_List"];
                ddlProduct.DataValueField = "MATERIAL_ID";
                ddlProduct.DataTextField = "MATERIAL_DESCREPTION";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("Select Product ", "0"));

                if (lblProduct_id.Text != "")
                {
                    ddlProduct.ClearSelection();
                    ddlProduct.Items.FindByValue(lblProduct_id.Text).Selected = true;
                    //txtAvalibaleQty.Text = GetAvailableStock(Convert.ToInt32(lblProduct_id.Text));
                }
            }
        }

        protected void txtContent_Textchanged(object sender, EventArgs e)
        {
            InsertToPurchaseOrder("");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (CheckPono() != true)
            {
                InsertToPurchaseOrder("True");
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "newpage", "customOpen('POFormPrint.aspx?type=igst&invoiceno=" + lblPurchaseOederid.Text + "');", true);
            }
            else
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningOk();</script>");
            }
        }

        #endregion

    }
}