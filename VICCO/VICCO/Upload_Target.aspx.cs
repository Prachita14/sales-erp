using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using VICCO.DAL;

namespace VICCO
{
    public partial class Upload_Target : System.Web.UI.Page
    {
        #region"Variable"

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion      

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUploadTarget(object sender, EventArgs e)
        {
            try
            {
                sda = new SqlDataAdapter("SELECT * FROM MATERIAL", con);
                dt = new DataTable();
                sda.Fill(dt);

                //WHERE MATERIAL_CODE IN('[DOM01200-20OFF]','[DOM01200-10OFF]','[DOM01150-10OFF]','[DOM01150-15OFF]','[DOM01100-10OFF]','[DOM01100-05OFF]','[DOM01050-05OFF]','[DOM01025R]','DOM21100R','DOM02400R','DOM02200R','DOM02100R','DOM02050R','DOM02025R','DOM02020R','DOM03070R','DOM03050R','DOM03030R','DOM03015R','DOM24070R','DOM24030R','DOM24015R','DOM04070R','DOM04030R','DOM04015R','DOM44070R','DOM44030R','DOM44015R','DOM23060R','DOM23030R','DOM23015R','DOM23007R','DOM05300R','DOM05200R','DOM05100R','DOM05050R','DOM05007R','DOM07030R','DOM07015R','DOM07045R','DOM27030R','DOM27015R')

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sda = new SqlDataAdapter("UPDATE TARGET SET STATUS=NULL WHERE MATERIAL_ID=" + dt.Rows[i]["MATERIAL_ID"] + " AND DISTRIBUTOR_ID IN (SELECT DISTRIBUTOR_ID FROM DISTRIBUTOR WHERE CODE IN(SELECT [DISTRIBUTOR_CODE] FROM TEMP_TARGET));", con);
                    DataTable dtUpdateStatus = new DataTable();
                    sda.Fill(dtUpdateStatus);

                    sda = new SqlDataAdapter("INSERT INTO TARGET (DISTRIBUTOR_ID,MATERIAL_ID,TARGET,FROM_DATE,TO_DATE,CREATED_ON,STATUS) SELECT D.DISTRIBUTOR_ID," + dt.Rows[i]["MATERIAL_ID"] + ",CAST((SELECT SUM(ISNULL(CAST(ROUND([" + dt.Rows[i]["MATERIAL_CODE"] + "],0) AS decimal(18,0)),0)) FROM TEMP_TARGET WHERE [DISTRIBUTOR_CODE]=UDT.[DISTRIBUTOR_CODE]) AS INT),UDT.[From_Date],UDT.[TO_DATE],GETDATE(),'CURRENT TARGET' FROM TEMP_TARGET UDT JOIN DISTRIBUTOR D ON UDT.[DISTRIBUTOR_CODE]=D.CODE WHERE [" + dt.Rows[i]["MATERIAL_CODE"] + "] IS NOT NULL GROUP BY D.DISTRIBUTOR_ID,UDT.FROM_DATE,UDT.TO_DATE,UDT.DISTRIBUTOR_CODE", con);
                    DataTable dtAddTarget = new DataTable();
                    sda.Fill(dtAddTarget);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}