using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace DemoMailingSystem
{
    public class userData
    {
        public DataTable userLogin(string userid, string password)
        {
            try
            {
                if (Connections.Connect())
                {
                    SqlCommand cmd = new SqlCommand("userLogin", Connections.ReturnConnection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userid", userid);
                    cmd.Parameters.AddWithValue("@password", password);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Connections.Message = e.Message.ToString();
                return null;
            }
            finally
            {
                Connections.Disconnect();
            }
        }
    }
}