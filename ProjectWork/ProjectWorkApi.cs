using System;
using smsghapi_dotnet_v2.Smsgh;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;

namespace ProjectWork
{
    public class SendMessage
    {
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter da = new SqlDataAdapter();

        public SqlCommand Commander(string CommanderCommand)
        {
            conn.Close();
            cmd.Parameters.Clear();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = CommanderCommand;

            return cmd;
        }



        public void CloseConn()
        {

            conn.Close();
            cmd.Dispose();
            cmd.Parameters.Clear();
        }

        public string getAllDetail(string NumberPlate)
        {
            cmd = Commander("[dbo].[getnumberplates]");
            cmd.Parameters.AddWithValue("@NumberPlate", NumberPlate);


            da.SelectCommand = cmd;

            DataSet ds = new DataSet();

            da.Fill(ds);

            CloseConn();

            StringBuilder str = new StringBuilder();

          
                str.Append("Number Plate :");
                str.Append(ds.Tables[0].Rows[0]["NumberPlate"].ToString());
                str.AppendLine(Environment.NewLine);
                str.Append("OwnerName :");
                str.Append(ds.Tables[0].Rows[0]["OwnerName"].ToString());
                str.AppendLine(Environment.NewLine);
                str.Append("Chasis Number :");
                str.Append(ds.Tables[0].Rows[0]["ChassisNumber"].ToString());
                str.AppendLine(Environment.NewLine);
                str.Append("Model :");
                str.Append(ds.Tables[0].Rows[0]["Model"].ToString());
                str.AppendLine(Environment.NewLine);
                str.Append("Colors :");
                str.Append(ds.Tables[0].Rows[0]["Colors"].ToString());
                str.AppendLine(Environment.NewLine);
                str.Append("Cartype :");
                str.Append(ds.Tables[0].Rows[0]["Cartype"].ToString());
                str.AppendLine();
            

            return str.ToString();
        }



        public void sendmessage(string subject, string message, string recepientNumber)
        {
            const string clientId = "";
            const string clientSecret = "";
            try
            {
                var host = new ApiHost(new BasicAuth(clientId, clientSecret));

                var messageApi = new MessagingApi(host);
                MessageResponse msg = messageApi.SendQuickMessage(subject, recepientNumber, message, true);
                Console.WriteLine(msg.Status);
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(HttpRequestException))
                {
                    var ex = e as HttpRequestException;
                    if (ex != null && ex.HttpResponse != null)
                    {
                        //Console.WriteLine("Error Status Code " + ex.HttpResponse.Status);
                    }
                }
                throw;
            }
          //  Console.ReadKey();
        }
    }
}