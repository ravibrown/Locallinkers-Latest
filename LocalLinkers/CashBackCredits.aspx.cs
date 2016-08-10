using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class CashBackCredits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ClsCommon.GetSession())
                {
                    BindCashBackCredits();
                }
                else
                {
                    Response.Redirect("/Login");
                }
            }
        }
        public void BindCashBackCredits()
        {
            try
            {
                ClsUserPoints points = new ClsUserPoints();
                points.UserId = ClsCommon.UserId;
                points.IsDeleted = false;
                List<ClsUserPoints> list_points = points.GetAll();
                if (list_points != null && list_points.Count > 0)
                {
                    rptCashBackCredits.DataSource = list_points;
                    rptCashBackCredits.DataBind();
                    divCash.Visible = true;
                    divNoRecords.Visible = false;
                }
                else
                {
                    divCash.Visible = false;
                    divNoRecords.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}