using DataAccess.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers.Ladybird
{
    public partial class LadyBird : System.Web.UI.Page
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
                    liAbout.Visible = false;
                    section3.Visible = false;
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
                    liContact.Visible = false;
                    section7.Visible = false;
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
                    section6.Visible = false;
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
                    section2.Visible = false;
                    liServices.Visible = false;
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
                 //   liHome.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}