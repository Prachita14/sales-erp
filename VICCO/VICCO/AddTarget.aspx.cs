using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using VICCO.DAL;

namespace VICCO
{
    public partial class AddTarget : System.Web.UI.Page
    {
        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        public void Getyear()
        {
            var currentYear = DateTime.Today.Year;

            for (int i = currentYear + 1; i >= 2017; i--)
            {
                auto_select1.Items.Add((i).ToString());
            }
        }

        public void AddtoActualTable(int Month, int year)
        {
            string mm = "";

            try
            {
                sda = new SqlDataAdapter("SELECT * FROM MATERIAL", con);
                dt = new DataTable();
                sda.Fill(dt);

                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //sda = new SqlDataAdapter("UPDATE TARGET SET STATUS=NULL WHERE MATERIAL_ID=" + dt.Rows[i]["MATERIAL_ID"] + " AND DISTRIBUTOR_ID IN (SELECT DISTRIBUTOR_ID FROM DISTRIBUTOR WHERE CODE IN(SELECT [DISTRIBUTOR_CODE] FROM TEMP_TARGET));", con);
                    //DataTable dtUpdateStatus = new DataTable();
                    //sda.Fill(dtUpdateStatus);
                    mm = dt.Rows[i]["MATERIAL_CODE"].ToString();
                    sda = new SqlDataAdapter("UPDATE TEMP_TARGET" + Convert.ToInt32(Request.Cookies["UserID"].Value) + " SET [" + dt.Rows[i]["MATERIAL_CODE"] + "]=0 WHERE [" + dt.Rows[i]["MATERIAL_CODE"] + "] IS NULL OR [" + dt.Rows[i]["MATERIAL_CODE"] + "]='';INSERT INTO TARGET (DISTRIBUTOR_ID,MATERIAL_ID,TARGET,MONTH,YEAR,CREATED_ON,STATUS) SELECT D.DISTRIBUTOR_ID," + dt.Rows[i]["MATERIAL_ID"] + ",CAST((SELECT SUM(ISNULL(CAST(ROUND(ISNULL([" + dt.Rows[i]["MATERIAL_CODE"] + "],0),0) AS decimal(18,0)),0)) FROM TEMP_TARGET" + Convert.ToInt32(Request.Cookies["UserID"].Value) + " WHERE [DISTRIBUTOR_CODE]=UDT.[DISTRIBUTOR_CODE]) AS INT)," + Month + "," + year + ",GETDATE(),'CURRENT TARGET' FROM TEMP_TARGET" + Convert.ToInt32(Request.Cookies["UserID"].Value) + " UDT JOIN DISTRIBUTOR D ON UDT.[DISTRIBUTOR_CODE]=D.CODE WHERE [" + dt.Rows[i]["MATERIAL_CODE"] + "] IS NOT NULL GROUP BY D.DISTRIBUTOR_ID,UDT.DISTRIBUTOR_CODE", con);
                    DataTable dtAddTarget = new DataTable();
                    sda.Fill(dtAddTarget);
                }
            }
            catch(Exception ex)
            {
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningMsgOk('" + ex.Message + "," + mm + "');</script>");
            }
        }

        public string ReadDataFromExcel()
        {
            try
            {
                bool Column_avail = true;
                string Not_Match_column = "";
                string msg = "";

                Target_Managment objTarget = new Target_Managment();
                objTarget.USER_ID = Convert.ToInt32(Request.Cookies["UserID"].Value);
                objTarget.SP_OPERATION = "CREATE_TEMP_TABLE";
                objTarget.SaveTarget();

                //Save the uploaded Excel file.
                string filePath = Server.MapPath("~/Target/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(filePath);

                //Open the Excel file in Read Mode using OpenXml.
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, false))
                {
                    //Read the first Sheet from Excel file.
                    Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

                    //Get the Worksheet instance.
                    Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;

                    //Fetch all the rows present in the Worksheet.
                    IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();

                    //Create a new DataTable.
                    dt = new DataTable();

                    //Loop through the Worksheet rows.
                    int ii = 0;

                    foreach (Cell cell in rows.FirstOrDefault().Descendants<Cell>())
                    {
                        string value = GetValue(doc, cell);

                        if (ii > 0)
                        {
                            Material_management objMaterial = new Material_management();
                            objMaterial.Material_code = value;
                            objMaterial.SpOperation = "SELECT";
                            DataTable dtMaterial = new DataTable();
                            dtMaterial = objMaterial.SaveMaterial();

                            if (dtMaterial.Rows.Count == 0)
                            {
                                Column_avail = false;
                                Not_Match_column = value + ",";
                            }
                        }

                        ii++;
                        dt.Columns.Add(value);
                    }

                    if (Column_avail == true)
                    {
                        foreach (Row row in rows)
                        {
                            //Use the first row to add columns to DataTable.
                            if (row.RowIndex.Value != 1)
                            {
                                //Add rows to DataTable.
                                dt.Rows.Add();
                                int i = 0;
                                foreach (Cell cell in row.Descendants<Cell>())
                                {
                                    dt.Rows[dt.Rows.Count - 1][i] = GetValue(doc, cell);
                                    i++;
                                }
                            }
                        }

                        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
                        {
                            connection.Open();
                            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                            {
                                foreach (DataColumn c in dt.Columns)
                                    bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
                                bulkCopy.DestinationTableName = "TEMP_TARGET" + Convert.ToString(Request.Cookies["UserID"].Value);
                                bulkCopy.WriteToServer(dt);
                            }
                        }

                        objTarget = new Target_Managment();
                        objTarget.FROM_DATE = Convert.ToDateTime("1 JAN " + auto_select1.SelectedItem.Text);
                        objTarget.USER_ID = Convert.ToInt32(Request.Cookies["UserID"].Value);
                        objTarget.SP_OPERATION = "EXPORT_FROM_TEMP";
                        dt = new DataTable();
                        dt = objTarget.SaveTarget();

                        if (dt.Rows.Count > 0)
                        {
                            msg = Convert.ToString(dt.Rows[0]["MESSAGE"]);
                        }

                        //if (msg == "")
                        //{
                        //    msg = "REOCORD ADDEDD SUCCESSFULLY!";
                        //}
                    }
                    else
                    {
                        msg = Not_Match_column + " code not available in database.";
                    }
                }

                return msg;               
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private string GetValue(SpreadsheetDocument doc, Cell cell)
        {
            if (cell.CellValue != null)
            {
                string value = cell.CellValue.InnerText;

                if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                {
                    return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
                }

                return value;
            }
            else
            {
                return "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Getyear();
            }
        }

        protected void btnUploadTarget(object sender, EventArgs e)
        {
            try
            {
                string msg = ReadDataFromExcel();

                if (msg != "")
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>WarningMsgOk('" + msg + "');</script>");
                }
                else
                {
                    if (chkJan.Checked == true)
                    {
                        AddtoActualTable(1,Convert.ToInt32(auto_select1.SelectedItem.Text));
                    }

                    if (chkFeb.Checked == true)
                    {
                        AddtoActualTable(2, Convert.ToInt32(auto_select1.SelectedItem.Text));
                    }

                    if (chkMar.Checked == true)
                    {
                        AddtoActualTable(3, Convert.ToInt32(auto_select1.SelectedItem.Text));
                    }

                    if (chkApr.Checked == true)
                    {
                        AddtoActualTable(4, Convert.ToInt32(auto_select1.SelectedItem.Text));
                    }
                    if (chkMay.Checked == true)
                    {
                        AddtoActualTable(5, Convert.ToInt32(auto_select1.SelectedItem.Text));
                    }
                    if (chkJun.Checked == true)
                    {
                        AddtoActualTable(6, Convert.ToInt32(auto_select1.SelectedItem.Text));
                    }
                    if (chkJuly.Checked == true)
                    {
                        AddtoActualTable(7, Convert.ToInt32(auto_select1.SelectedItem.Text));
                    }
                    if (chkAug.Checked == true)
                    {
                        AddtoActualTable(8, Convert.ToInt32(auto_select1.SelectedItem.Text));
                    }
                    if (chkSep.Checked == true)
                    {
                        AddtoActualTable(9, Convert.ToInt32(auto_select1.SelectedItem.Text));
                    }
                    if (chkOct.Checked == true)
                    {
                        AddtoActualTable(10, Convert.ToInt32(auto_select1.SelectedItem.Text));
                    }
                    if (chkNov.Checked == true)
                    {
                        AddtoActualTable(11, Convert.ToInt32(auto_select1.SelectedItem.Text));
                    }
                    if (chkDec.Checked == true)
                    {
                        AddtoActualTable(12, Convert.ToInt32(auto_select1.SelectedItem.Text));
                    }

                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "xx", "<script>SuccessOk();</script>");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}