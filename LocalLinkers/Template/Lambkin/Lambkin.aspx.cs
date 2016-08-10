using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers.Template.Lambkin
{
    public partial class Lambkin : System.Web.UI.Page
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
                var data = obj.GetAll();
                if (data.Count > 0)
                {
                    rptTemplate.DataSource = data;
                    rptTemplate.DataBind();
                }
                else
                {
                    liHome.Visible = false;
                    liHomeMobile.Visible = false;
                  //  header.Visible = false;
                }
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
                    about.Visible = false;
                    liAbout.Visible = false;
                    liAboutMobile.Visible = false;
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
                    hdnAddress.Value = lst[0].Address + ", " + lst[0].City + ", " + lst[0].State;
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
                    news.Visible = false;
                    liPortfolioMobile.Visible = false;
                    liPortfolio.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void BindTemplateServices()
        {
            try
            {
                ClsTemplateServices obj = new ClsTemplateServices();
                obj.IsDeleted = false;
                obj.TemplateId = Convert.ToInt64(Request.QueryString["id"]);
                var data = obj.GetAll();
                if (data.Count > 0)
                {
                    rptServices.DataSource = data;
                    rptServices.DataBind();
                }
                else
                {
                    services.Visible = false;
                    liServices.Visible = false;
                    liServicesMobile.Visible = false;
                }
                
            }
            catch (Exception ex)
            {

            }
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
                    rptSlider.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}