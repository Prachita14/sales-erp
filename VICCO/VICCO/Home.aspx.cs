using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region "Additional Namespaces"

using VICCO.DAL;
using System.Data;
using System.Web.Services;

#endregion

namespace RCandJJ
{
    public partial class Home : System.Web.UI.Page
    {
        #region "Public Function"

        public void GetStockDetails()
        {
            try
            {
                AdminStockist_Managment objDetails = new AdminStockist_Managment();

                if (Convert.ToInt32(HttpContext.Current.Request.Cookies["RollID"].Value) == 2)
                {
                    if (HttpContext.Current.Request.Cookies["Stockist"] != null)
                    {
                        objDetails.STOCKIST_ID = Convert.ToInt32(HttpContext.Current.Request.Cookies["Stockist"].Value);
                    }
                }

                if (HttpContext.Current.Request.Cookies["EMP_ID"] != null)
                {
                    objDetails.EMPLOYEE_ID = Convert.ToInt32(HttpContext.Current.Request.Cookies["EMP_ID"].Value);
                }

                objDetails.SpOperation = "STOCK_TOTAL";
                DataTable dtDetails = new DataTable();
                dtDetails = objDetails.GetDetails();

                if (dtDetails.Rows.Count > 0)
                {
                    lblDistributor.Text = Convert.ToString(dtDetails.Rows[0]["TOTAL_DISTRIBUTOR"]);
                    lblMaterial.Text = Convert.ToString(dtDetails.Rows[0]["TOTAL_MATERIAL"]);
                    lblStockist.Text = Convert.ToString(dtDetails.Rows[0]["TOTAL_STOCKIST"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetmonthlyValue()
        {
            AdminStockist_Managment objDetails = new AdminStockist_Managment();
            if (Convert.ToInt32(HttpContext.Current.Request.Cookies["RollID"].Value) == 2)
            {
                if (HttpContext.Current.Request.Cookies["Stockist"] != null)
                {
                    objDetails.STOCKIST_ID = Convert.ToInt32(HttpContext.Current.Request.Cookies["Stockist"].Value);
                }
            }
           
            objDetails.SpOperation = "GET_CURRENT_MONTH_VALUE";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();

            if (dt.Rows.Count > 0)
            {
                lblcurrentmonthvalue.Text = Convert.ToInt32(dt.Rows[0]["VALUE"]).ToString("N0");
            }
        }

        public void GetCimulativeValue()
        {
            AdminStockist_Managment objDetails = new AdminStockist_Managment();
            if (Convert.ToInt32(HttpContext.Current.Request.Cookies["RollID"].Value) == 2)
            {
                if (HttpContext.Current.Request.Cookies["Stockist"] != null)
                {
                    objDetails.STOCKIST_ID = Convert.ToInt32(HttpContext.Current.Request.Cookies["Stockist"].Value);
                }
            }
           
            objDetails.SpOperation = "GET_CIMULATIVE_SALE_VALUE";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();

            if (dt.Rows.Count > 0)
            {
                lblcurrentCimulativevalue.Text = Convert.ToInt64(dt.Rows[0]["VALUE"]).ToString("N0");
            }
        }

        public void GetMonthlyQuantityValue()
        {
            AdminStockist_Managment objDetails = new AdminStockist_Managment();

            if (Convert.ToInt32(HttpContext.Current.Request.Cookies["RollID"].Value) == 2)
            {
                if (HttpContext.Current.Request.Cookies["Stockist"] != null)
                {
                    objDetails.STOCKIST_ID = Convert.ToInt32(HttpContext.Current.Request.Cookies["Stockist"].Value);
                }
            }            

            objDetails.SpOperation = "GET_CURRENTMONTH_QTY_BY_PRODUCT";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();

            if (dt.Rows.Count > 0)
            {
                lblcurrentmonthqtyvalue.Text = Convert.ToInt64(dt.Rows[0]["QTY"]).ToString("N0");
            }
        }

        public void GetMonthlyCumulativeValue()
        {
            AdminStockist_Managment objDetails = new AdminStockist_Managment();

            if (Convert.ToInt32(HttpContext.Current.Request.Cookies["RollID"].Value) == 2)
            {
                if (HttpContext.Current.Request.Cookies["Stockist"] != null)
                {
                    objDetails.STOCKIST_ID = Convert.ToInt32(HttpContext.Current.Request.Cookies["Stockist"].Value);
                }
            }
           
            objDetails.SpOperation = "GET_CUMULATIVE_QTY_VALUE";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();
            if (dt.Rows.Count > 0)
            {
                lblcurrentcumulativeqtyvalue.Text = Convert.ToInt64(dt.Rows[0]["QTY"]).ToString("N0");
            }
        }

        //public void MaterialName()
        //{
        //    Material_management objClient = new Material_management();
        //    //objClient.Material_id = Convert.ToInt32(Request.Cookies["USER_ID"]);
        //    objClient.SpOperation = "SELECT_ONLY_GROUP";
        //    DataTable dtClient = new DataTable();
        //    dtClient = objClient.SaveMaterial();

        //    ddlMaterialGroup.DataSource = dtClient;
        //    ddlMaterialGroup.DataTextField = "MATERIAL_GROUP";
        //    ddlMaterialGroup.DataBind();
        //    ddlMaterialGroup.Items.Insert(0, new ListItem("Material Name", "0"));

        //    ddlMaterial.DataSource = dtClient;
        //    ddlMaterial.DataTextField = "MATERIAL_GROUP";
        //    ddlMaterial.DataBind();
        //    ddlMaterial.Items.Insert(0, new ListItem("Material Name", "0"));
        //}

        //[WebMethod]
        //public static List<object> GetProductValueLinechart(string group)
        //{

        //    AdminStockist_Managment objDetails = new AdminStockist_Managment();

        //    if (Convert.ToInt32(HttpContext.Current.Request.Cookies["RollID"].Value) != 1)
        //    {
        //        if (HttpContext.Current.Request.Cookies["Stockist"] != null)
        //        {
        //            objDetails.STOCKIST_ID = Convert.ToInt32(HttpContext.Current.Request.Cookies["Stockist"].Value);
        //        }
        //    }
        //    if (HttpContext.Current.Request.Cookies["EMP_ID"] != null)
        //    {
        //        objDetails.EMPLOYEE_ID = Convert.ToInt32(HttpContext.Current.Request.Cookies["EMP_ID"].Value);
        //    }

        //    if (group != "0")
        //    {
        //        objDetails.MATERIAL_GROUP = group;
        //    }
        //    objDetails.SpOperation = "GET_STATE_PRODUCT_VALUE";
        //    DataTable dt = new DataTable();
        //    dt = objDetails.GetDetails();

        //    List<object>
        //        iData = new List<object>();
        //    foreach (DataColumn dc in dt.Columns)
        //    {
        //        List<object>
        //            x = new List<object>
        //                ();
        //        x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
        //        iData.Add(x);
        //    }

        //    if (dt.Columns.Count < 5)
        //    {
        //        for (int i = 5; i > dt.Columns.Count; i--)
        //        {
        //            List<object>
        //           x = new List<object>
        //               ();
        //            x.Add(0);
        //            iData.Add(x);
        //        }
        //    }

        //    return iData;
        //}

        //[WebMethod]
        //public static List<object> GetProductQtyLinechart(string group)
        //{
        //    AdminStockist_Managment objDetails = new AdminStockist_Managment();
        //    if (Convert.ToInt32(HttpContext.Current.Request.Cookies["RollID"].Value) != 1)
        //    {

        //        if (HttpContext.Current.Request.Cookies["Stockist"] != null)
        //        {
        //            objDetails.STOCKIST_ID = Convert.ToInt32(HttpContext.Current.Request.Cookies["Stockist"].Value);
        //        }

        //    }
        //    if (HttpContext.Current.Request.Cookies["EMP_ID"] != null)
        //    {
        //        objDetails.EMPLOYEE_ID = Convert.ToInt32(HttpContext.Current.Request.Cookies["EMP_ID"].Value);
        //    }
        //    if (group != "0")
        //    {
        //        objDetails.MATERIAL_GROUP = group;
        //    }
        //    objDetails.SpOperation = "GET_STATE_PRODUCT_QTY";
        //    DataTable dt = new DataTable();
        //    dt = objDetails.GetDetails();

        //    List<object>
        //        iData = new List<object>();
        //    foreach (DataColumn dc in dt.Columns)
        //    {
        //        List<object>
        //            x = new List<object>
        //                ();
        //        x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
        //        iData.Add(x);
        //    }

        //    if (dt.Columns.Count < 5)
        //    {
        //        for (int i = 5; i > dt.Columns.Count; i--)
        //        {
        //            List<object>
        //           x = new List<object>
        //               ();
        //            x.Add(0);
        //            iData.Add(x);
        //        }
        //    }

        //    return iData;
        //}

        [WebMethod]
        public static List<object> GetProductValueLinechart()
        {

            AdminStockist_Managment objDetails = new AdminStockist_Managment();

            if (Convert.ToInt32(HttpContext.Current.Request.Cookies["RollID"].Value) == 2)
            {
                if (HttpContext.Current.Request.Cookies["Stockist"] != null)
                {
                    objDetails.STOCKIST_ID = Convert.ToInt32(HttpContext.Current.Request.Cookies["Stockist"].Value);
                }
            }

            objDetails.SpOperation = "GET_STATE_PRODUCT_VALUE";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();

            List<object>
                iData = new List<object>();
            foreach (DataColumn dc in dt.Columns)
            {
                List<object>
                    x = new List<object>
                        ();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }

            if (dt.Columns.Count < 5)
            {
                for (int i = 5; i > dt.Columns.Count; i--)
                {
                    List<object>
                   x = new List<object>
                       ();
                    x.Add(0);
                    iData.Add(x);
                }
            }

            return iData;
        }

        [WebMethod]
        public static List<object> GetProductQtyLinechart()
        {
            AdminStockist_Managment objDetails = new AdminStockist_Managment();

            if (Convert.ToInt32(HttpContext.Current.Request.Cookies["RollID"].Value) == 2)
            {
                if (HttpContext.Current.Request.Cookies["Stockist"] != null)
                {
                    objDetails.STOCKIST_ID = Convert.ToInt32(HttpContext.Current.Request.Cookies["Stockist"].Value);
                }
            }

            objDetails.SpOperation = "GET_STATE_PRODUCT_QTY";
            DataTable dt = new DataTable();
            dt = objDetails.GetDetails();

            List<object>
                iData = new List<object>();
            foreach (DataColumn dc in dt.Columns)
            {
                List<object>
                    x = new List<object>
                        ();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }

            if (dt.Columns.Count < 5)
            {
                for (int i = 5; i > dt.Columns.Count; i--)
                {
                    List<object>
                   x = new List<object>
                       ();
                    x.Add(0);
                    iData.Add(x);
                }
            }

            return iData;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserID"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                if (Convert.ToInt32(Request.Cookies["RollID"].Value) == 2)
                {
                    Response.Redirect("StockistDashboard.aspx");
                }

                lblLoginName.Text = Convert.ToString(Request.Cookies["UserName"].Value);
            }

            if (!IsPostBack)
            {
                GetStockDetails();
                GetmonthlyValue();
                GetCimulativeValue();
                GetMonthlyQuantityValue();
                GetMonthlyCumulativeValue();
                //MaterialName();
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
    }
}