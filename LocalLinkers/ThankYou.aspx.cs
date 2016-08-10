using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    
    public partial class ThankYou : System.Web.UI.Page
    {
        public static string TransactionId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["TransactionId"]!=null)
                {
                    TransactionId = Request.QueryString["TransactionId"].ToString();
                }
            }
        }
    }
}