using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWork
{
    /// <summary>
    /// Summary description for SMSHandler1
    /// </summary>
    public class SMSHandler : IHttpHandler
    {


        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (!string.IsNullOrEmpty(context.Request.QueryString["fulltext"]))
            {
                string keyword = context.Request.QueryString["fulltext"].ToString().Substring(0, 4);

                string numberPlate = string.Empty;

                if (keyword.ToUpper() == "INFO")
                {
                    numberPlate = context.Request.QueryString["fulltext"].ToString().Split(null)[1];

                }


            string senderNumber = context.Request.QueryString["From"].ToString();



                SendMessage send = new SendMessage();
               
                var result = send.getAllDetail(numberPlate);
                var result =
                if(result!=null)
                {
                    send.sendmessage("Deplaves", result, senderNumber);
                } else
                {
                    send.sendmessage("Deplaves", , senderNumber);
                }               
            
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}