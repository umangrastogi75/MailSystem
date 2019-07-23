using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DemoMailingSystem
{
    public class Messaging
    {
        public int SendMessage()
        {
            try
            {
                if (Connections.Connect())
                {
                    //    SqlCommand cmd = new SqlCommand("messageDetailInsert", Connections.ReturnConnection());
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.AddWithValue("@userid", txtSendTo.Text);
                    //    cmd.Parameters.AddWithValue("@msgid", Guid.NewGuid().ToString());
                    //    cmd.Parameters.AddWithValue("@catagary", 1);
                    //    cmd.Parameters.AddWithValue("@subject", txtSubject.Text);
                    //    cmd.Parameters.AddWithValue("@msgbody", txtMessage.Text);

                    //    SqlParameter message = new SqlParameter("@Mesage", SqlDbType.VarChar);
                    //    message.Direction = ParameterDirection.Output;
                    //    cmd.Parameters.Add(message);

                    //    SqlParameter stat = new SqlParameter("@Stat", SqlDbType.Int);
                    //    stat.Direction = ParameterDirection.Output;
                    //    cmd.Parameters.Add(stat);

                    //    cmd.ExecuteNonQuery();

                    //    Connections.Message = message.Value.ToString();

                    return 0;//Convert.ToInt16(stat.Value);

                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Connections.Message = ex.Message.ToString();
                return 0;
            }
        }
    }
}