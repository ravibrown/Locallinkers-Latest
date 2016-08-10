using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers.UserControl
{
    public partial class HeaderSlider : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindHomeSlider();
            }
        }

        public void BindHomeSlider()
        {
            ClsHomeSlider obj = new ClsHomeSlider();
            obj.IsDeleted = false;
            obj.IsApproved = (int)ClsHomeSlider.BooleanValues.Approved;
            obj.Take = 5;
            List<ClsHomeSlider> lst = obj.GetAll();
            if (lst != null && lst.Count > 0)
            {
                rptHomeSliderIndicators.DataSource = lst;
                rptHomeSliderIndicators.DataBind();
                rptHomeslider.DataSource = lst;
                rptHomeslider.DataBind();
            }
        }
    }
}