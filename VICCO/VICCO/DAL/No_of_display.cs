using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region "Additional Namespace"

using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using VICCO.DAL;
using System.IO;
using System.Drawing;
using System.Configuration;

#endregion

namespace VICCO.DAL
{
    public class No_of_display
    {

        #region"Variable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;
        public DataTable DataSource;

        #endregion

        #region "Properties"

        public int EMP_ID { get; set; }
        public int SO_ID { get; set; }
        public DateTime From_Date { get; set; }
        public DateTime To_Date { get; set; }
        public string Brush { get; set; }
        public string Facewash { get; set; }
        public string IFB { get; set; }
        public string NRY_C { get; set; }
        public string NRY_S { get; set; }
        public string OIB { get; set; }
        public string Paste { get; set; }
        public string Paste25 { get; set; }
        public string Pouch_Powder { get; set; }
        public string Pouch_WSO { get; set; }
        public string Powder { get; set; }
        public string SF { get; set; }
        public string Shaving { get; set; }
        public string VTC_Cream { get; set; }
        public string WSO { get; set; }
        public string COMBINE { get; set; }
        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (EMP_ID > 0)
                Command.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int)).Value = EMP_ID;
            else
                Command.Parameters.Add(new SqlParameter("@EMP_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (SO_ID > 0)
                Command.Parameters.Add(new SqlParameter("@SO_ID", SqlDbType.Int)).Value = SO_ID;
            else
                Command.Parameters.Add(new SqlParameter("@SO_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (From_Date != DateTime.MinValue && From_Date != null)
                cmd.Parameters.Add(new SqlParameter("@From_Date", SqlDbType.Date)).Value = From_Date;
            else
                cmd.Parameters.Add(new SqlParameter("@From_Date", SqlDbType.Date)).Value = DBNull.Value;

            if (To_Date != DateTime.MinValue && To_Date != null)
                cmd.Parameters.Add(new SqlParameter("@To_Date", SqlDbType.Date)).Value = To_Date;
            else
                cmd.Parameters.Add(new SqlParameter("@To_Date", SqlDbType.Date)).Value = DBNull.Value;


            if (Brush != string.Empty && Brush != null)
                Command.Parameters.Add(new SqlParameter("@Brush", SqlDbType.Decimal)).Value = Brush;
            else
                Command.Parameters.Add(new SqlParameter("@Brush", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Facewash != string.Empty && Facewash != null)
                Command.Parameters.Add(new SqlParameter("@Facewash", SqlDbType.Decimal)).Value = Facewash;
            else
                Command.Parameters.Add(new SqlParameter("@Facewash", SqlDbType.Decimal)).Value = DBNull.Value;

            if (IFB != string.Empty && IFB != null)
                Command.Parameters.Add(new SqlParameter("@IFB", SqlDbType.Decimal)).Value = IFB;
            else
                Command.Parameters.Add(new SqlParameter("@IFB", SqlDbType.Decimal)).Value = DBNull.Value;

            if (NRY_C != string.Empty && NRY_C != null)
                Command.Parameters.Add(new SqlParameter("@NRY_C", SqlDbType.Decimal)).Value = NRY_C;
            else
                Command.Parameters.Add(new SqlParameter("@NRY_C", SqlDbType.Decimal)).Value = DBNull.Value;

            if (NRY_S != string.Empty && NRY_S != null)
                Command.Parameters.Add(new SqlParameter("@NRY_S", SqlDbType.Decimal)).Value = NRY_S;
            else
                Command.Parameters.Add(new SqlParameter("@NRY_S", SqlDbType.Decimal)).Value = DBNull.Value;

            if (OIB != string.Empty && OIB != null)
                Command.Parameters.Add(new SqlParameter("@OIB", SqlDbType.Decimal)).Value = OIB;
            else
                Command.Parameters.Add(new SqlParameter("@OIB", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Paste != string.Empty && Paste != null)
                Command.Parameters.Add(new SqlParameter("@Paste", SqlDbType.Decimal)).Value = Paste;
            else
                Command.Parameters.Add(new SqlParameter("@Paste", SqlDbType.Decimal)).Value = DBNull.Value;
            if (Paste25 != string.Empty && Paste25 != null)
                Command.Parameters.Add(new SqlParameter("@Paste25", SqlDbType.Decimal)).Value = Paste25;
            else
                Command.Parameters.Add(new SqlParameter("@Paste25", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Pouch_Powder != string.Empty && Pouch_Powder != null)
                Command.Parameters.Add(new SqlParameter("@Pouch_Powder", SqlDbType.Decimal)).Value = Pouch_Powder;
            else
                Command.Parameters.Add(new SqlParameter("@Pouch_Powder", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Pouch_WSO != string.Empty && Pouch_WSO != null)
                Command.Parameters.Add(new SqlParameter("@Pouch_WSO", SqlDbType.Decimal)).Value = Pouch_WSO;
            else
                Command.Parameters.Add(new SqlParameter("@Pouch_WSO", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Powder != string.Empty && Powder != null)
                Command.Parameters.Add(new SqlParameter("@Powder", SqlDbType.Decimal)).Value = Powder;
            else
                Command.Parameters.Add(new SqlParameter("@Powder", SqlDbType.Decimal)).Value = DBNull.Value;

            if (SF != string.Empty && SF != null)
                Command.Parameters.Add(new SqlParameter("@SF", SqlDbType.Decimal)).Value = SF;
            else
                Command.Parameters.Add(new SqlParameter("@SF", SqlDbType.Decimal)).Value = DBNull.Value;

            if (Shaving != string.Empty && Shaving != null)
                Command.Parameters.Add(new SqlParameter("@Shaving", SqlDbType.Decimal)).Value = Shaving;
            else
                Command.Parameters.Add(new SqlParameter("@Shaving", SqlDbType.Decimal)).Value = DBNull.Value;

            if (VTC_Cream != string.Empty && VTC_Cream != null)
                Command.Parameters.Add(new SqlParameter("@VTC_Cream", SqlDbType.Decimal)).Value = VTC_Cream;
            else
                Command.Parameters.Add(new SqlParameter("@VTC_Cream", SqlDbType.Decimal)).Value = DBNull.Value;

            if (WSO != string.Empty && WSO != null)
                Command.Parameters.Add(new SqlParameter("@WSO", SqlDbType.Decimal)).Value = WSO;
            else
                Command.Parameters.Add(new SqlParameter("@WSO", SqlDbType.Decimal)).Value = DBNull.Value;

            if (COMBINE != string.Empty && COMBINE != null)
                Command.Parameters.Add(new SqlParameter("@COMBINE", SqlDbType.Decimal)).Value = COMBINE;
            else
                Command.Parameters.Add(new SqlParameter("@COMBINE", SqlDbType.Decimal)).Value = DBNull.Value;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SpOperation", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveDisplay()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("NO_OF_DISPLAY", con);
                AddwithParameter(cmd);
                DataTable dtUser = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                con.Open();
                sda.Fill(dtUser);
                return dtUser;
            }
        }

        #endregion

    }
}