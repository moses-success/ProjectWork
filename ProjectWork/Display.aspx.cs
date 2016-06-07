using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectWork
{
    public partial class Display : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var test = new SendMessage();

            string details = test.getAllDetail("ER 3311-11");

            Label1.Text=details;
            Console.Write("number");
        }
    }
}