using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
#region "Additional Namespaces"

using VICCO.DAL;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;
using System.Drawing;
using Microsoft.Reporting.WebForms;

#endregion
namespace VICCO
{
    public partial class UploadedTargetExcel : System.Web.UI.Page
    {
        #region "Variable"

       
        SqlConnection scon = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionStr"].ToString());

        #endregion
        public void Get()
        {
           
            ReportViewer1.SizeToReportContent = true;

           
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/UploadedTarget.rdlc");

            
            DataTable dt = new DataTable();
            dt = Session["DataSource"] as DataTable;
            string region = Session["region"].ToString();

            ReportViewer1.LocalReport.DataSources.Clear();

            DataTable dtpara = new DataTable();

            dtpara.Columns.Add("REGION", typeof(System.String));

            DataRow dtrow = dtpara.NewRow();
            dtrow["REGION"] = region;
            dtpara.Rows.Add(dtrow);

            ReportDataSource _rsource1 = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Add(_rsource1);

            ReportDataSource _rsource2 = new ReportDataSource("DataSet2", dtpara);
            ReportViewer1.LocalReport.DataSources.Add(_rsource2);

            ReportViewer1.LocalReport.Refresh();
            

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["DataSource"] != null)
            {
                if (!IsPostBack)
                {
                    Get();
                }

                Warning[] warnings;
                string[] streamIds;
                string contentType;
                string encoding;
                string extension;

                //Export the RDLC Report to Byte Array.
                byte[] bytes = ReportViewer1.LocalReport.Render("Excel", null, out contentType, out encoding, out extension, out streamIds, out warnings);

                //Download the RDLC Report in Word, Excel, PDF and Image formats.
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=TargetReport." + extension);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
        }
    }
}