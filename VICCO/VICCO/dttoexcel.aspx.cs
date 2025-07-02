using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VICCO.DAL;
using System.Data;
using ClosedXML.Excel;
using System.IO;

namespace VICCO
{
    public partial class dttoexcel : System.Web.UI.Page
    {
        public void Getreportdata()
        {
            try
            {
                TempReport objReport = new TempReport();

                DataTable dtReport = new DataTable();
                dtReport = objReport.GetReport();

                
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dtReport, "Sale");

                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=SqlExport.xlsx");
                        using (MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            wb.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
                    }
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Getreportdata();
        }
    }
}