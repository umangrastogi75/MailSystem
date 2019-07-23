using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DemoMailingSystem
{
    class Connections
    {
        #region Database Objects

        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        //static DataSet ds;

        #endregion

        #region Constructor

        public Connections()
        {
        }

        #endregion

        #region Common Functions

        public static bool Connect()
        {
            try
            {                
                con = new SqlConnection("data source=192.168.43.136; integrated security=true; initial catalog=DemoMailingSystem;");
                con.Open();
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message.ToString();
                return false;
            }
        }

        public static void Disconnect()
        {
            con.Close();
        }

        public static SqlConnection ReturnConnection()
        {
            return con;
        }

        public static SqlDataReader ReturnReader(string str)
        {
            try
            {
                cmd = new SqlCommand(str, con);
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Message = ex.Message.ToString();
                reader = null;
                return reader;
            }
        }

        public static int Execute(string str)
        {
            try
            {
                cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                Message = ex.Message.ToString();
                return 0;
            }
        }

        public static int ReturnValue(string str)
        {
            try
            {
                cmd = new SqlCommand(str, con);
                Result = cmd.ExecuteScalar().ToString();
                return 1;
            }
            catch (Exception ex)
            {
                Message = ex.Message.ToString();
                return 0;
            }
        }

        public static DataTable ReturnTable(string str)
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(str, con);
                da.Fill(ds);
                dt = ds.Tables[0];
                if (dt.Rows.Count != 0)
                {
                    return dt;
                }
                else
                {
                    dt = null;
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message.ToString();
                dt = null;
                return dt;
            }
        }

        public static DataTable ReturnTable(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables.Count != 0)
                {
                    dt = ds.Tables[0];
                    if (dt.Rows.Count != 0)
                    {
                        return dt;
                    }
                    else
                    {
                        dt = null;
                        return dt;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message.ToString();
                cmd.Parameters["@Stat"].Value = 0;
                cmd.Parameters["@Message"].Value = ex.Message.ToString();
                dt = null;
                return dt;
            }
        }

        #endregion

        #region Properties

        public static string Message
        {
            get;
            set;
        }

        public static string Result
        {
            get;
            set;
        }

        #endregion

        public static string ImagePath
        {
            get { return "http://localhost:3766/UserImages/Thumbs/"; }
        }

    }
}