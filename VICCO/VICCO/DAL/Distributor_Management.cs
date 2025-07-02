using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region "Additional Namespaces"

using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using VICCO.DAL;
using System.Configuration;

#endregion

namespace VICCO.DAL
{
    public class Distributor_Management
    {

        #region"Veriable"

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString);
        SqlDataAdapter sda;
        SqlCommand cmd;
        DataSet ds;
        DataTable dt;

        #endregion

        #region property

        public int Distributor_id { get; set; }
        public int Stockist_id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string district { get; set; }
        public string Pin_code { get; set; }
        public string region { get; set; }
        public string state { get; set; }
        public string Phone_number { get; set; }
        public string Mobile_number { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string country { get; set; }
        public string City { get; set; }
        public string contact_person { get; set; }
        public string pan { get; set; }
        public string lst { get; set; }
        public string cst { get; set; }
        public string tpt { get; set; }
        public string Distributor_Type { get; set; }
        public bool Is_Active { get; set; }
        public string PHOTO { get; set; }
        public string SpOperation { get; set; }

        #endregion

        #region "Function"

        public void AddwithParameter(SqlCommand Command)
        {
            if (Distributor_id > 0)
                Command.Parameters.Add(new SqlParameter("@DISTRIBUTOR_ID", SqlDbType.Int)).Value = Distributor_id;
            else
                Command.Parameters.Add(new SqlParameter("@DISTRIBUTOR_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (Stockist_id > 0)
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = Stockist_id;
            else
                Command.Parameters.Add(new SqlParameter("@STOCKIST_ID", SqlDbType.Int)).Value = DBNull.Value;

            if (code != String.Empty && code != null)
                Command.Parameters.Add(new SqlParameter("@CODE", SqlDbType.VarChar)).Value = code;
            else
                Command.Parameters.Add(new SqlParameter("@CODE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (name != String.Empty && name != null)
                Command.Parameters.Add(new SqlParameter("@NAME", SqlDbType.VarChar)).Value = name;
            else
                Command.Parameters.Add(new SqlParameter("@NAME", SqlDbType.VarChar)).Value = DBNull.Value;

            if (address != String.Empty && address != null)
                Command.Parameters.Add(new SqlParameter("@ADDRESS", SqlDbType.VarChar)).Value = address;
            else
                Command.Parameters.Add(new SqlParameter("@ADDRESS", SqlDbType.VarChar)).Value = DBNull.Value;

            if (district != String.Empty && district != null)
                Command.Parameters.Add(new SqlParameter("@DISTRICT", SqlDbType.VarChar)).Value = district;
            else
                Command.Parameters.Add(new SqlParameter("@DISTRICT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Pin_code != String.Empty && Pin_code != null)
                Command.Parameters.Add(new SqlParameter("@PINCODE", SqlDbType.VarChar)).Value = Pin_code;
            else
                Command.Parameters.Add(new SqlParameter("@PINCODE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (region != String.Empty && region != null)
                Command.Parameters.Add(new SqlParameter("@REGION", SqlDbType.VarChar)).Value = region;
            else
                Command.Parameters.Add(new SqlParameter("@REGION", SqlDbType.VarChar)).Value = DBNull.Value;

            if (state != String.Empty && state != null)
                Command.Parameters.Add(new SqlParameter("@STATE", SqlDbType.VarChar)).Value = state;
            else
                Command.Parameters.Add(new SqlParameter("@STATE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Phone_number != String.Empty && Phone_number != null)
                Command.Parameters.Add(new SqlParameter("@PHONE_NUMBER", SqlDbType.VarChar)).Value = Phone_number;
            else
                Command.Parameters.Add(new SqlParameter("@PHONE_NUMBER", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Mobile_number != String.Empty && Mobile_number != null)
                Command.Parameters.Add(new SqlParameter("@MOBILE_NUMBER", SqlDbType.VarChar)).Value = Mobile_number;
            else
                Command.Parameters.Add(new SqlParameter("@MOBILE_NUMBER", SqlDbType.VarChar)).Value = DBNull.Value;

            if (email != String.Empty && email != null)
                Command.Parameters.Add(new SqlParameter("@EMAIL", SqlDbType.VarChar)).Value = email;
            else
                Command.Parameters.Add(new SqlParameter("@EMAIL", SqlDbType.VarChar)).Value = DBNull.Value;

            if (password != String.Empty && password != null)
                Command.Parameters.Add(new SqlParameter("@PASSWORD", SqlDbType.VarChar)).Value = password;
            else
                Command.Parameters.Add(new SqlParameter("@PASSWORD", SqlDbType.VarChar)).Value = DBNull.Value;

            if (country != String.Empty && country != null)
                Command.Parameters.Add(new SqlParameter("@COUNTRY", SqlDbType.VarChar)).Value = country;
            else
                Command.Parameters.Add(new SqlParameter("@COUNTRY", SqlDbType.VarChar)).Value = DBNull.Value;

            if (City != String.Empty && City != null)
                Command.Parameters.Add(new SqlParameter("@CITY", SqlDbType.VarChar)).Value = City;
            else
                Command.Parameters.Add(new SqlParameter("@CITY", SqlDbType.VarChar)).Value = DBNull.Value;

            if (contact_person != String.Empty && contact_person != null)
                Command.Parameters.Add(new SqlParameter("@CONTACT_PERSON", SqlDbType.VarChar)).Value = contact_person;
            else
                Command.Parameters.Add(new SqlParameter("@CONTACT_PERSON", SqlDbType.VarChar)).Value = DBNull.Value;

            if (pan != String.Empty && pan != null)
                Command.Parameters.Add(new SqlParameter("@PAN", SqlDbType.VarChar)).Value = pan;
            else
                Command.Parameters.Add(new SqlParameter("@PAN", SqlDbType.VarChar)).Value = DBNull.Value;

            if (lst != String.Empty && lst != null)
                Command.Parameters.Add(new SqlParameter("@LST", SqlDbType.VarChar)).Value = lst;
            else
                Command.Parameters.Add(new SqlParameter("@LST", SqlDbType.VarChar)).Value = DBNull.Value;

            if (cst != String.Empty && cst != null)
                Command.Parameters.Add(new SqlParameter("@CST", SqlDbType.VarChar)).Value = cst;
            else
                Command.Parameters.Add(new SqlParameter("@CST", SqlDbType.VarChar)).Value = DBNull.Value;

            if (tpt != String.Empty && tpt != null)
                Command.Parameters.Add(new SqlParameter("@TPT", SqlDbType.VarChar)).Value = tpt;
            else
                Command.Parameters.Add(new SqlParameter("@TPT", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Distributor_Type != string.Empty && Distributor_Type != null)
                Command.Parameters.Add(new SqlParameter("@DISTRIBUTOR_TYPE", SqlDbType.VarChar)).Value = Distributor_Type;
            else
                Command.Parameters.Add(new SqlParameter("@DISTRIBUTOR_TYPE", SqlDbType.VarChar)).Value = DBNull.Value;

            if (Is_Active != false)
                Command.Parameters.Add(new SqlParameter("@Is_Active", SqlDbType.Bit)).Value = Is_Active;
            else
                Command.Parameters.Add(new SqlParameter("@Is_Active", SqlDbType.Bit)).Value = DBNull.Value;

            if (PHOTO != String.Empty && PHOTO != null)
                Command.Parameters.Add(new SqlParameter("@PHOTO", SqlDbType.VarChar)).Value = PHOTO;
            else
                Command.Parameters.Add(new SqlParameter("@PHOTO", SqlDbType.VarChar)).Value = DBNull.Value;

            if (SpOperation != string.Empty && SpOperation != null)
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = SpOperation;
            else
                Command.Parameters.Add(new SqlParameter("@SP_OPERATION", SqlDbType.VarChar)).Value = DBNull.Value;
        }

        public DataTable SaveDistributor()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString))
            {
                cmd = new SqlCommand("DISTRIBUTOR_MANAGEMENT", con);
                AddwithParameter(cmd);
                DataTable DataTableDistributor = new DataTable();
                cmd.CommandType = CommandType.StoredProcedure;
                sda = new SqlDataAdapter(cmd);
                con.Open();
                sda.Fill(DataTableDistributor);                
                return DataTableDistributor;
            }
        }

        #endregion
    }
}