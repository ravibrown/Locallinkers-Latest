using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers.Template.Paramour
{
    public partial class Paramour : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    BindTemplate();
                    BindTemplateAboutus();
                    BindTemplateContact();
                    BindTemplateGallery();
                    BindTemplateServices();
                    BindTemplateSlider();
                }
            }
        }
        public void BindTemplate()
        {
            try
            {
                ClsTemplate obj = new ClsTemplate();
                obj.Id = Convert.ToInt64(Request.QueryString["id"]);
                obj.IsDeleted = false;
                rptTemplate.DataSource = obj.GetAll();
                rptTemplate.DataBind();
                rptTemplate2.DataSource = obj.GetAll();
                rptTemplate2.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
        public void BindTemplateAboutus()
        {
            try
            {
                ClsTemplateAboutUs obj = new ClsTemplateAboutUs();
                obj.IsDeleted = false;
                obj.TemplateId = Convert.ToInt64(Request.QueryString["id"]);

                var data = obj.GetAll();
                if (data.Count > 0)
                {
                    rptAboutUs.DataSource = data;
                    rptAboutUs.DataBind();
                    
                }
                else
                {
                    liAboutUs.Visible = false;
                    liAboutUsMobile.Visible = false;
                    about.Visible = false;
                }

            }
            catch (Exception ex)
            {

            }
        }

        public void BindTemplateContact()
        {
            try
            {
                ClsTemplateContact obj = new ClsTemplateContact();
                obj.IsDeleted = false;
                obj.TemplateId = Convert.ToInt64(Request.QueryString["id"]);
                List<ClsTemplateContact> lst = obj.GetAll();
                if (lst != null && lst.Count > 0)
                {

                    rptContact.DataSource = lst;
                    rptContact.DataBind();
                    hdnLatitude.Value = Convert.ToString(lst[0].Latitude);
                    hdnLongitude.Value = Convert.ToString(lst[0].Longitude);

                    rptSocialLink.DataSource = lst;
                    rptSocialLink.DataBind();
                }
                else
                {
                    contact.Visible = false;
                    liContact.Visible = false;
                    liContactMobile.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void BindTemplateGallery()
        {
            try
            {
                ClsTemplatePortfolio obj = new ClsTemplatePortfolio();
                obj.IsDeleted = false;
                obj.TemplateId = Convert.ToInt64(Request.QueryString["id"]);
                var data = obj.GetAll();
                if (data.Count > 0)
                {
                    rptGallery.DataSource = data;
                    rptGallery.DataBind();
                }
                else
                {
                    work.Visible = false;
                    liPortFolio.Visible = false;
                    liPortfolioMobile.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void BindTemplateServices()
        {

            ClsTemplateServices obj = new ClsTemplateServices();
            obj.IsDeleted = false;
            obj.TemplateId = Convert.ToInt64(Request.QueryString["id"]);

            var data = obj.GetAll();
            if (data.Count > 0)
            {
                rptServices.Visible = true;
                services.Visible = true;
                rptServices.DataSource = data;
                rptServices.DataBind();
            }
            else
            { rptServices.Visible = false;
                services.Visible = false;
                liServices.Visible = false;
                liServicesMobile.Visible = false; }
        }

        public void BindTemplateSlider()
        {
            try
            {
                ClsTemplateSlider obj = new ClsTemplateSlider();
                obj.IsDeleted = false;
                obj.TemplateId = Convert.ToInt64(Request.QueryString["id"]);
                List<ClsTemplateSlider> lst = obj.GetAll();
                if (lst != null && lst.Count > 0)
                {
                    rptSlider.DataSource = lst;
                    rptSlider.DataBind();
                    rptSliderIndicators.DataSource = lst;
                    rptSliderIndicators.DataBind();
                }
                else
                {
                  //  home.Visible = false;
                    //liHome.Visible = false;
                    //liHomeMobile.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}