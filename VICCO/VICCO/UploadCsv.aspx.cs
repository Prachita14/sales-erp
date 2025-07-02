using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using VICCO.DAL;

namespace VICCO
{
    public partial class UploadCsv : System.Web.UI.Page
    {
        string sqlconn = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;

        public void UploadMaterial(string csvPath)
        {            
            FileUpload1.SaveAs(csvPath);

          
            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[12] { new DataColumn("MATERIAL_CODE", typeof(string)),
            new DataColumn("MATERIAL_NAME",typeof(string)),
            new DataColumn("MATERIAL_UOM_QTY",typeof(string)),
            new DataColumn("MATERIAL_UOM_UNIT",typeof(string)),
            new DataColumn("ALTERNATIVE_UOM_QTY",typeof(string)),
            new DataColumn("ALTERNATIVE_UOM_UNIT",typeof(string)),
            new DataColumn("GROSS_WEIGHT",typeof(string)),
            new DataColumn("NET_WEIGHT",typeof(string)),
            new DataColumn("SGST",typeof(string)),
            new DataColumn("CGST",typeof(string)),
            new DataColumn("HSN_CODE",typeof(string)),
            new DataColumn("MATERIAL_GROUP",typeof(string))
            });

            string csvData = File.ReadAllText(csvPath);

            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;

                    foreach (string cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }

            dt.Columns.Add("RATE", typeof(System.String));

            foreach (DataRow row in dt.Rows)
            {
                row["RATE"] = null;
            }

            dt.Columns.Add("CREATED_BY", typeof(System.String));

            foreach (DataRow row in dt.Rows)
            {
                row["CREATED_BY"] = 1;
            }

            dt.Columns.Add("CREATED_ON", typeof(System.String));

            foreach (DataRow row in dt.Rows)
            {
                row["CREATED_ON"] = System.DateTime.Now;
            }

            dt.Rows[0].Delete();
            dt.AcceptChanges();

            using (SqlConnection con = new SqlConnection(sqlconn))
            {
                using (SqlBulkCopy objbulk = new SqlBulkCopy(con))
                {
                    objbulk.DestinationTableName = "MATERIAL";
                    objbulk.ColumnMappings.Add("MATERIAL_CODE", "MATERIAL_CODE");
                    objbulk.ColumnMappings.Add("MATERIAL_NAME", "MATERIAL_NAME");
                    objbulk.ColumnMappings.Add("MATERIAL_UOM_QTY", "MATERIAL_UOM_QTY");
                    objbulk.ColumnMappings.Add("MATERIAL_UOM_UNIT", "MATERIAL_UOM_UNIT");
                    objbulk.ColumnMappings.Add("ALTERNATIVE_UOM_QTY", "ALTERNATIVE_UOM_QTY");
                    objbulk.ColumnMappings.Add("ALTERNATIVE_UOM_UNIT", "ALTERNATIVE_UOM_UNIT");
                    objbulk.ColumnMappings.Add("GROSS_WEIGHT", "GROSS_WEIGHT");
                    objbulk.ColumnMappings.Add("NET_WEIGHT", "NET_WEIGHT");
                    objbulk.ColumnMappings.Add("RATE", "RATE");
                    objbulk.ColumnMappings.Add("SGST", "SGST");
                    objbulk.ColumnMappings.Add("CGST", "CGST");
                    objbulk.ColumnMappings.Add("HSN_CODE", "HSN_CODE");
                    objbulk.ColumnMappings.Add("MATERIAL_GROUP", "MATERIAL_GROUP");
                    objbulk.ColumnMappings.Add("CREATED_BY", "CREATED_BY");
                    objbulk.ColumnMappings.Add("CREATED_ON", "CREATED_ON"); ;
                    con.Open();
                    objbulk.WriteToServer(dt);
                    con.Close();
                }
            }
        }

        public string UploadStockist(string csvPath)
        {

            Supper_stockist_management objstockist = new Supper_stockist_management();
            objstockist.SpOperation = "TRUNCATE_TEMP";
            objstockist.SaveStockist();

            FileUpload1.SaveAs(csvPath);

            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[17] { new DataColumn("STOCKIST_CODE", typeof(string)),
            new DataColumn("STOCKIST_NAME",typeof(string)),
            new DataColumn("ADDRESS",typeof(string)),
            new DataColumn("DISTRICT",typeof(string)),
            new DataColumn("PINCODE",typeof(string)),
            new DataColumn("REGION",typeof(string)),
            new DataColumn("PHONE_NUMBER",typeof(string)),
            new DataColumn("MOBILE_NUMBER",typeof(string)),
            new DataColumn("COUNTRY",typeof(string)),
            new DataColumn("CITY",typeof(string)),
            new DataColumn("CONTACT_PERSON",typeof(string)),
            new DataColumn("EMAIL",typeof(string)),
            new DataColumn("PASSWORD",typeof(string)),
            new DataColumn("PAN",typeof(string)),
            new DataColumn("LST",typeof(string)),
            new DataColumn("GSTIN",typeof(string)),
            new DataColumn("TPT",typeof(string))
            });

            string csvData = File.ReadAllText(csvPath);

            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;

                    foreach (string cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }

            dt.Columns.Add("ROLL_ID", typeof(System.Int32));

            foreach (DataRow row in dt.Rows)
            {
                row["ROLL_ID"] = 1;
            }

            dt.Rows[0].Delete();
            dt.AcceptChanges();

            using (SqlConnection con = new SqlConnection(sqlconn))
            {
                using (SqlBulkCopy objbulk = new SqlBulkCopy(con))
                {
                    objbulk.DestinationTableName = "TEMP_SUPPER_STOCKIST";
                    objbulk.ColumnMappings.Add("STOCKIST_CODE", "code");
                    objbulk.ColumnMappings.Add("STOCKIST_NAME", "name");
                    objbulk.ColumnMappings.Add("ADDRESS", "address");
                    objbulk.ColumnMappings.Add("DISTRICT", "district");
                    objbulk.ColumnMappings.Add("PINCODE", "pincode");
                    objbulk.ColumnMappings.Add("REGION", "STOCKIST_REGION");
                    objbulk.ColumnMappings.Add("PHONE_NUMBER", "phone_number");
                    objbulk.ColumnMappings.Add("MOBILE_NUMBER", "mobile_number");
                    objbulk.ColumnMappings.Add("EMAIL", "email");
                    objbulk.ColumnMappings.Add("PASSWORD", "password");
                    objbulk.ColumnMappings.Add("COUNTRY", "country");
                    objbulk.ColumnMappings.Add("CITY", "city");
                    objbulk.ColumnMappings.Add("CONTACT_PERSON", "contact_person");
                    objbulk.ColumnMappings.Add("PAN", "pan");
                    objbulk.ColumnMappings.Add("LST", "lst");
                    objbulk.ColumnMappings.Add("GSTIN", "cst");
                    objbulk.ColumnMappings.Add("TPT", "tpt");
                    con.Open();
                    objbulk.WriteToServer(dt);
                    con.Close();
                }
            }

            objstockist = new Supper_stockist_management();
            objstockist.SpOperation = "INSERT_FROM_CSV";
            dt = new DataTable();
            dt = objstockist.SaveStockist();

            string Msg = "";

            if (dt.Rows.Count > 0)
            {
                Msg = Convert.ToString(dt.Rows[0]["MESSAGE"]);
            }
            else
            {
                using (SqlConnection con = new SqlConnection(sqlconn))
                {
                    using (SqlBulkCopy objbulk = new SqlBulkCopy(con))
                    {
                        objbulk.DestinationTableName = "LOGIN";
                        objbulk.ColumnMappings.Add("NAME", "USER_NAME");
                        objbulk.ColumnMappings.Add("EMAIL", "EMAIL_ID");
                        objbulk.ColumnMappings.Add("MOBILE_NUMBER", "MOBILE_NUMBER");
                        objbulk.ColumnMappings.Add("PASSWORD", "PASSWORD");
                        objbulk.ColumnMappings.Add("ROLL_ID", "ROLL_ID");
                        con.Open();
                        objbulk.WriteToServer(dt);
                        con.Close();
                    }
                }
            }

            return Msg;

            
        }

        public string UploadDistributor(string csvPath)
        {
            Distributor_Management objDistributor = new Distributor_Management();
            objDistributor.SpOperation = "TRUNCATE_TEMP";
            objDistributor.SaveDistributor();

            FileUpload1.SaveAs(csvPath);

            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[21] { new DataColumn("DISTRIBUTOR_CODE", typeof(string)),
            new DataColumn("DISTRIBUTOR_NAME",typeof(string)),
            new DataColumn("STOCKIST_CODE",typeof(string)),
            new DataColumn("ADDRESS",typeof(string)),
            new DataColumn("DISTRICT",typeof(string)),
            new DataColumn("PINCODE",typeof(string)),
            new DataColumn("REGION",typeof(string)),
             new DataColumn("STATE",typeof(string)),
            new DataColumn("PHONE_NUMBER",typeof(string)),
            new DataColumn("MOBILE_NUMBER",typeof(string)),            
            new DataColumn("COUNTRY",typeof(string)),
            new DataColumn("CITY",typeof(string)),
            new DataColumn("CONTACT_PERSON",typeof(string)),
            new DataColumn("EMAIL",typeof(string)),
            new DataColumn("PAN",typeof(string)),
            new DataColumn("LST",typeof(string)),
            new DataColumn("GSTIN",typeof(string)),
            new DataColumn("TPT",typeof(string)),
            new DataColumn("DISTRIBUTOR_TYPE",typeof(string)),
            new DataColumn("IS_ACTIVE",typeof(string)),
            new DataColumn("DEACTIVE_DATE",typeof(string)),
            });


            string csvData = File.ReadAllText(csvPath);

            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;


                    foreach (string cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }

            dt.Rows[0].Delete();
            dt.AcceptChanges();

            using (SqlConnection con = new SqlConnection(sqlconn))
            {
                using (SqlBulkCopy objbulk = new SqlBulkCopy(con))
                {
                    objbulk.DestinationTableName = "TEMP_DISTRIBUTOR";
                    objbulk.ColumnMappings.Add("DISTRIBUTOR_CODE", "code");
                    objbulk.ColumnMappings.Add("DISTRIBUTOR_NAME", "name");
                    objbulk.ColumnMappings.Add("STOCKIST_CODE", "stockist_code");
                    objbulk.ColumnMappings.Add("ADDRESS", "address");
                    objbulk.ColumnMappings.Add("DISTRICT", "district");
                    objbulk.ColumnMappings.Add("PINCODE", "pincode");
                    objbulk.ColumnMappings.Add("REGION", "region");
                    objbulk.ColumnMappings.Add("REGION", "state");
                    objbulk.ColumnMappings.Add("PHONE_NUMBER", "phone_number");
                    objbulk.ColumnMappings.Add("MOBILE_NUMBER", "mobile_number");
                    objbulk.ColumnMappings.Add("EMAIL", "email");                    
                    objbulk.ColumnMappings.Add("COUNTRY", "country");
                    objbulk.ColumnMappings.Add("CITY", "city");
                    objbulk.ColumnMappings.Add("CONTACT_PERSON", "contact_person");
                    objbulk.ColumnMappings.Add("PAN", "pan");
                    objbulk.ColumnMappings.Add("LST", "lst");
                    objbulk.ColumnMappings.Add("GSTIN", "cst");
                    objbulk.ColumnMappings.Add("TPT", "tpt");
                    objbulk.ColumnMappings.Add("DISTRIBUTOR_TYPE", "DISTRIBUTOR_TYPE");
                    objbulk.ColumnMappings.Add("IS_ACTIVE", "Is_Active");
                    objbulk.ColumnMappings.Add("DEACTIVE_DATE", "DEACTIVE_DATE");
                    con.Open();
                    objbulk.WriteToServer(dt);
                    con.Close();
                }
            }

            objDistributor = new Distributor_Management();
            objDistributor.SpOperation = "INSERT_FROM_CSV";
            dt = new DataTable();
            dt=objDistributor.SaveDistributor();

            string Msg = "";

            if(dt.Rows.Count>0)
            {
                Msg = Convert.ToString(dt.Rows[0]["MESSAGE"]);
            }

            return Msg;
        }

        public string UploadAdminDispatchMaterial(string csvPath)
        {
            SqlDataAdapter sda = new SqlDataAdapter("TRUNCATE TABLE TEMP_ADMIN_DISPATCH_MATERIAL;", sqlconn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            FileUpload1.SaveAs(csvPath);

            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[17] {
                 new DataColumn("id",typeof(string)),
            new DataColumn("Super_Stockist_Code",typeof(string)),
            new DataColumn("Super_Stockist_Name", typeof(string)),            
            new DataColumn("Tax_Invoice_no",typeof(string)),
            new DataColumn("LineItem",typeof(string)),
            new DataColumn("Dispatch_Date",typeof(string)),
            new DataColumn("Dispatch_Note_no",typeof(string)),
            new DataColumn("Item_Code",typeof(string)),
            new DataColumn("Item_Description",typeof(string)),
            new DataColumn("Batch_Numbe",typeof(string)),
            new DataColumn("Shipped_Quantity",typeof(string)),
            new DataColumn("Billed_Quantity",typeof(string)),
            new DataColumn("Rate",typeof(string)),
            new DataColumn("Scheme",typeof(string)),
            new DataColumn("Add_Disc",typeof(string)),
            new DataColumn("Total",typeof(string)),
            new DataColumn("Created at",typeof(string))
            });
           
            string csvData = File.ReadAllText(csvPath);

            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;

                    foreach (string cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }

            dt.Rows[0].Delete();
            dt.AcceptChanges();

            using (SqlConnection con = new SqlConnection(sqlconn))
            {
                using (SqlBulkCopy objbulk = new SqlBulkCopy(con))
                {
                    objbulk.DestinationTableName = "TEMP_ADMIN_DISPATCH_MATERIAL";
                    objbulk.ColumnMappings.Add("Tax_Invoice_no", "invoice_no");
                    objbulk.ColumnMappings.Add("Super_Stockist_Code", "stockist_code");
                    objbulk.ColumnMappings.Add("LineItem", "line_item");
                    objbulk.ColumnMappings.Add("Dispatch_Date", "grn_date");
                    objbulk.ColumnMappings.Add("Dispatch_Note_no", "dispatch_note_no");
                    objbulk.ColumnMappings.Add("Item_Code", "item_code");
                    objbulk.ColumnMappings.Add("Batch_Numbe", "batch_number");
                    objbulk.ColumnMappings.Add("Shipped_Quantity", "shipped_quantity");
                    objbulk.ColumnMappings.Add("Billed_Quantity", "billed_quantity");
                    objbulk.ColumnMappings.Add("Rate", "rate");
                    objbulk.ColumnMappings.Add("Scheme", "scheme");
                    objbulk.ColumnMappings.Add("Add_Disc", "addi_discount");
                    objbulk.ColumnMappings.Add("Total", "total");
                    con.Open();
                    objbulk.WriteToServer(dt);
                    con.Close();
                }
            }

            Admin_Dispatch_Material_Management objDispatch = new Admin_Dispatch_Material_Management();
            objDispatch.SpOperation = "INSERT_CSV";
            DataTable dtMeaase = new DataTable();
            dtMeaase = objDispatch.SaveAdminDispatchMaterial();

            if (dtMeaase.Rows.Count > 0)
            {
                string msg = "";

                if (Convert.ToString(dtMeaase.Rows[0]["TYPE"]) == "STOCKIST")
                {
                    for (int i = 0; i < dtMeaase.Rows.Count; i++)
                    {
                        msg += Convert.ToString(dtMeaase.Rows[0]["MESSAGE"]) + ",";
                    }

                    msg += "...Stockist code not available.";
                }

                if (Convert.ToString(dtMeaase.Rows[0]["TYPE"]) == "MATERIAL")
                {
                    for (int i = 0; i < dtMeaase.Rows.Count; i++)
                    {
                        msg += Convert.ToString(dtMeaase.Rows[0]["MESSAGE"]) + ",";
                    }

                    msg += "...Material code not available.";
                }

                if (Convert.ToString(dtMeaase.Rows[0]["TYPE"]) == "INVOICE")
                {
                    for (int i = 0; i < dtMeaase.Rows.Count; i++)
                    {
                        msg += Convert.ToString(dtMeaase.Rows[0]["MESSAGE"])+",";
                    }

                    msg += "...Invoice no already Exists.";
                }

                return msg;
              
            }
            else
            {
                return "";
            }
        }

        public string UploadAdminDispatchInitialMaterial(string csvPath)
        {
            SqlDataAdapter sda = new SqlDataAdapter("TRUNCATE TABLE TEMP_ADMIN_DISPATCH_MATERIAL;", sqlconn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            FileUpload1.SaveAs(csvPath);

            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[17] {
                 new DataColumn("id",typeof(string)),
            new DataColumn("Super_Stockist_Code",typeof(string)),
            new DataColumn("Super_Stockist_Name", typeof(string)),            
            new DataColumn("Tax_Invoice_no",typeof(string)),
            new DataColumn("LineItem",typeof(string)),
            new DataColumn("Dispatch_Date",typeof(string)),
            new DataColumn("Dispatch_Note_no",typeof(string)),
            new DataColumn("Item_Code",typeof(string)),
            new DataColumn("Item_Description",typeof(string)),
            new DataColumn("Batch_Numbe",typeof(string)),
            new DataColumn("Shipped_Quantity",typeof(string)),
            new DataColumn("Billed_Quantity",typeof(string)),
            new DataColumn("Rate",typeof(string)),
            new DataColumn("Scheme",typeof(string)),
            new DataColumn("Add_Disc",typeof(string)),
            new DataColumn("Total",typeof(string)),
            new DataColumn("Created at",typeof(string))
            });


            string csvData = File.ReadAllText(csvPath);

            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    dt.Rows.Add();
                    int i = 0;

                    foreach (string cell in row.Split(','))
                    {
                        dt.Rows[dt.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }

            dt.Rows[0].Delete();
            dt.AcceptChanges();

            using (SqlConnection con = new SqlConnection(sqlconn))
            {
                using (SqlBulkCopy objbulk = new SqlBulkCopy(con))
                {
                    objbulk.DestinationTableName = "TEMP_ADMIN_DISPATCH_MATERIAL";
                    objbulk.ColumnMappings.Add("Tax_Invoice_no", "invoice_no");
                    objbulk.ColumnMappings.Add("Super_Stockist_Code", "stockist_code");
                    objbulk.ColumnMappings.Add("LineItem", "line_item");
                    objbulk.ColumnMappings.Add("Dispatch_Date", "grn_date");
                    objbulk.ColumnMappings.Add("Dispatch_Note_no", "dispatch_note_no");
                    objbulk.ColumnMappings.Add("Item_Code", "item_code");
                    objbulk.ColumnMappings.Add("Batch_Numbe", "batch_number");
                    objbulk.ColumnMappings.Add("Shipped_Quantity", "shipped_quantity");
                    objbulk.ColumnMappings.Add("Billed_Quantity", "billed_quantity");
                    objbulk.ColumnMappings.Add("Rate", "rate");
                    objbulk.ColumnMappings.Add("Scheme", "scheme");
                    objbulk.ColumnMappings.Add("Add_Disc", "addi_discount");
                    objbulk.ColumnMappings.Add("Total", "total");
                    con.Open();
                    objbulk.WriteToServer(dt);
                    con.Close();
                }
            }

            Admin_Dispatch_Initial_Material objDispatch = new Admin_Dispatch_Initial_Material();
            objDispatch.SpOperation = "INSERT_CSV";
            DataTable dtMeaase = new DataTable();
            dtMeaase = objDispatch.SaveAdminDispatchMaterial();

            if (dtMeaase.Rows.Count > 0)
            {
                string msg = "";

                if (Convert.ToString(dtMeaase.Rows[0]["TYPE"]) == "STOCKIST")
                {
                    for (int i = 0; i < dtMeaase.Rows.Count; i++)
                    {
                        msg += Convert.ToString(dtMeaase.Rows[0]["MESSAGE"]) + ",";
                    }

                    msg += "...Stockist code not available.";
                }

                if (Convert.ToString(dtMeaase.Rows[0]["TYPE"]) == "MATERIAL")
                {
                    for (int i = 0; i < dtMeaase.Rows.Count; i++)
                    {
                        msg += Convert.ToString(dtMeaase.Rows[0]["MESSAGE"]) + ",";
                    }

                    msg += "...Material code not available.";
                }

                if (Convert.ToString(dtMeaase.Rows[0]["TYPE"]) == "INVOICE")
                {
                    for (int i = 0; i < dtMeaase.Rows.Count; i++)
                    {
                        msg += Convert.ToString(dtMeaase.Rows[0]["MESSAGE"]) + ",";
                    }

                    msg += "...Invoice no already Exists.";
                }

                return msg;
                
            }
            else
            {
                return "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] == "material")
            {
                HyperLink1.NavigateUrl = "~/CSV/CSV Format/Material.csv";
                PanelDispatch.Visible = false;
                PanelInitial.Visible = false;
                PanelMaterial.Visible = true;
                PanelStokist.Visible = false;
                PanelDistributor.Visible = false;
            }

            if (Request.QueryString["type"] == "stockist")
            {
                HyperLink1.NavigateUrl = "~/CSV/CSV Format/Stockist.csv";
                PanelDispatch.Visible = false;
                PanelInitial.Visible = false;
                PanelMaterial.Visible = false;
                PanelStokist.Visible = true;
                PanelDistributor.Visible = false;
            }

            if (Request.QueryString["type"] == "distributor")
            {
                HyperLink1.NavigateUrl = "~/CSV/CSV Format/Distributor.csv";
                PanelDispatch.Visible = false;
                PanelInitial.Visible = false;
                PanelMaterial.Visible = false;
                PanelStokist.Visible = false;
                PanelDistributor.Visible = true;
            }

            if (Request.QueryString["type"] == "admindispatch")
            {
                HyperLink1.NavigateUrl = "~/CSV/CSV Format/AdminDispatch.csv";
                PanelDispatch.Visible = true;
                PanelInitial.Visible = false;
                PanelMaterial.Visible = false;
                PanelStokist.Visible = false;
                PanelDistributor.Visible = false;
            }

            if (Request.QueryString["type"] == "initial")
            {
                HyperLink1.NavigateUrl = "~/CSV/CSV Format/AdminDispatch.csv";
                PanelDispatch.Visible = false;
                PanelInitial.Visible = true;
                PanelMaterial.Visible = false;
                PanelStokist.Visible = false;
                PanelDistributor.Visible = false;
            }
        }

        protected void btnUploadCSV(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    string extension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
                    //check file extension
                    if ((extension.ToLower() == ".csv"))
                    {
                        Random rnd = new Random();

                        string csvPath = Server.MapPath("~/CSV/") + Path.GetFileName(rnd.Next(1, 9999) + FileUpload1.PostedFile.FileName);

                        string msg = "";

                        if (File.Exists(csvPath))
                        {
                            File.Delete(csvPath);
                        }

                        if (Request.QueryString["type"] == "material")
                        {
                            UploadMaterial(csvPath);
                        }

                        if (Request.QueryString["type"] == "stockist")
                        {
                            msg = UploadStockist(csvPath);
                        }

                        if (Request.QueryString["type"] == "distributor")
                        {
                            msg = UploadDistributor(csvPath);
                        }

                        if (Request.QueryString["type"] == "admindispatch")
                        {
                            msg = UploadAdminDispatchMaterial(csvPath);
                        }

                        if (Request.QueryString["type"] == "initial")
                        {
                            msg = UploadAdminDispatchInitialMaterial(csvPath);
                        }

                        if (msg == "")
                        {
                            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningMsgOk('" + msg + "');</script>");
                        }

                    }
                    else
                    {
                        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningMsgOk('File format not supported...');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}