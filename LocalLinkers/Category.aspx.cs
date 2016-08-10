using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class Category : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindCategory();
            }
        }

        public void BindCategory()
        {
            try
            {
                ClsCategory obj = new ClsCategory();
                obj.IsDeleted = false;
                obj.IsApproved = (int)ClsCategory.BooleanValues.Approved;
                rptCategory.DataSource = obj.GetAllForAjaxWithBusiness();
                rptCategory.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }
}