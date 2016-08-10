using DataAccess.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalLinkers
{
    public partial class Business : System.Web.UI.Page
    {
        public int CategoryId = 0;
        public string CategoryName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string host = HttpContext.Current.Request.Url.AbsolutePath;
                string[] splitUrl = host.Split('/');
                if (splitUrl.Length > 3)
                {
                    CategoryId = Convert.ToInt32(splitUrl[2]);
                    CategoryName = splitUrl[3].ToString().Replace("-", " ");
                }
            }
        }


        protected string GetImagePath(int id)
        {
            string result = "";
            if (id > 0)
            {
                ClsBusinessImages img = new ClsBusinessImages();
                img.BusinessId = id;
                img.IsDeleted = false;
                img.GetRecord();
                if (img.DataRecieved)
                {
                    result = ClsCommon.BusinessImagesPath + img.Image;
                }
            }
            return result;
        }

        #region "WebMethod"
        [WebMethod]
        public static BusinessList BindBusiness(int take, int index, int categoryid,string SubCategoryIds,string Latitude,string Longitude,string Keyword)
        {
            List<ClsPropBusiness> list_Business = new List<ClsPropBusiness>();
            BusinessList lst_MainBusiness = new BusinessList();
            
            try
            {
                ClsBusiness obj = new ClsBusiness();
                obj.IsDeleted = false;
                if (HttpContext.Current.Session["SelectedCityId"] != null)
                {
                    obj.SelectedCity = Convert.ToInt64(HttpContext.Current.Session["SelectedCityId"]);
                }
                else
                {
                    obj.SelectedCity = ClsCommon.DefaultSelectedCity;
                }
                obj.CategoryId = categoryid;
                obj.Index = index;
                obj.Take = take;
                obj.OrderBy = "Distance";
                obj.SubCategoryIds = SubCategoryIds;
                if (!string.IsNullOrEmpty(Latitude) && !string.IsNullOrEmpty(Longitude))
                {
                    obj.Latitude = Latitude;
                    obj.Longitude = Longitude;
                }
                else
                {
                   var latlng= ClsCommon.GetLatLongByCityID(obj.SelectedCity);
                    obj.Latitude = latlng.Latitude;
                    obj.Longitude= latlng.Longitude;

                }
                obj.IsApproved = (int)ClsCategory.BooleanValues.Approved;
                obj.Keyword = Keyword;
                obj.Distance = 5;
                list_Business = obj.GetAllForAjax();
                if (index == 0 && SubCategoryIds=="")
                {
                    ClsSubCategory subcategory = new ClsSubCategory();
                    subcategory.CategoryId = categoryid;
                    subcategory.IsDeleted = false;
                    subcategory.IsApproved = (int)ClsSubCategory.BooleanValues.Approved;
                    obj.LstSubCategory = subcategory.GetAllForAjaxWithJoin();
                }
                lst_MainBusiness.LstBusiness = list_Business;
                lst_MainBusiness.LstSlider = list_Business.Where(a=>a.PremiumImage!="" && a.PremiumImage != null && a.Subscription==(int)ClsBusiness.BusinessSubscription.Premium).Take(3).ToList();
                lst_MainBusiness.LstSubCategory = obj.LstSubCategory;
            }
            catch (Exception ex)
            {

            }
            return lst_MainBusiness;
        }

        [WebMethod]
        public static string SendConfirmMessage(Int64 BusinessId,string date,string time,string usermessage)
        {

            string Result = string.Empty;
            try
            {
                if (ClsCommon.GetSession())
                {
                    ClsBusinessBooking obj = new ClsBusinessBooking();
                    obj.BusinessId = BusinessId;
                    obj.UserId = Convert.ToInt64(HttpContext.Current.Session["UserId"]);
                    List<ClsBusinessBooking> list_Business = obj.GetAll();
                    if (list_Business.Count == 0)
                    {
                        obj.Time = time;
                        DateTime ConvertedDate = DateTime.ParseExact(date, "dd/MM/yyyy", null);
                        obj.BookingDate = ConvertedDate;
                        obj.Message = usermessage;
                        obj.Add();
                        if (obj.Id > 0)
                        {
                            ClsBusiness business = new ClsBusiness();
                            ClsCategory category = new ClsCategory();
                            business.Id = BusinessId;
                            business.GetRecord();
                            //if (business.CategoryId != null && business.CategoryId > 0)
                            //{
                            //    category.Id = Convert.ToInt64(business.CategoryId);
                            //    category.GetRecord();
                            //}
                            string businessmessage = ClsCommon.BusinessBookingMessage;
                            businessmessage = businessmessage.Replace("##Date##", date);
                            businessmessage = businessmessage.Replace("##Time##", time);
                            businessmessage = businessmessage.Replace("##Message##", usermessage);
                            businessmessage = businessmessage.Replace("##NameAndPhoneNumber##", (!string.IsNullOrEmpty(ClsCommon.UserName) ? ClsCommon.UserName + "/" + ClsCommon.PhoneNumber : ClsCommon.PhoneNumber));

                            string businessUsermessage = ClsCommon.BusinessBookingUserMessage;
                            businessUsermessage = businessUsermessage.Replace("##Date##", date);
                            businessUsermessage = businessUsermessage.Replace("##Time##", time);
                            businessUsermessage = businessUsermessage.Replace("##BusinessName##", business.BusinessName);
                            if (!string.IsNullOrEmpty(business.PhoneNumber1))
                            {
                                ClsCommon.SendCodeThroughSms(business.PhoneNumber1, businessmessage);
                                ClsCommon.SendCodeThroughSms(ClsCommon.PhoneNumber, businessUsermessage);
                            }

                            if (!string.IsNullOrEmpty(business.Email))
                            {
                                string host = HttpContext.Current.Request.Url.Host;
                                //Send message to owner of business
                                EmailMessage message = new EmailMessage();
                                message.Message = "Hi ," + business.ContactPerson + "<br/>" + businessmessage + (!string.IsNullOrEmpty(ClsCommon.UserName) ? ClsCommon.UserName : ClsCommon.PhoneNumber + usermessage + " Date:" + date + " Time:" + time);
                                message.Subject = ClsCommon.BusinessBookingSubject;
                                message.To = business.Email;
                                bool ret = ClsCommon.SendEmail(message);
                            }

                            if (!string.IsNullOrEmpty(ClsCommon.UserEmail))
                            {
                                //Send message to user
                                EmailMessage message1 = new EmailMessage();
                                message1.Message = "Hi ," + (!string.IsNullOrEmpty(ClsCommon.UserName) ? ClsCommon.UserName : ClsCommon.PhoneNumber) + "<br/>" + businessUsermessage + (!string.IsNullOrEmpty(ClsCommon.UserName) ? ClsCommon.UserName : ClsCommon.PhoneNumber + usermessage + " Date:" + date + " Time:" + time);
                                message1.Subject = ClsCommon.BusinessBookingSubject;
                                message1.To = ClsCommon.UserEmail;
                                bool ret1 = ClsCommon.SendEmail(message1);
                            }
                            Result = "Booked Successfully";
                        }
                    }
                    else
                    {
                        Result = "Already booked";
                    }
                }
                else
                {
                    ClsBusiness business = new ClsBusiness();
                    ClsCategory category = new ClsCategory();
                    business.Id = BusinessId;
                    business.GetRecord();
                    if (business.CategoryId != null && business.CategoryId > 0)
                    {
                        category.Id = Convert.ToInt64(business.CategoryId);
                        category.GetRecord();
                        if (category.DataRecieved)
                        {
                            Result = "/Login?ReturnUrl=/Business/" + category.Id + "/" + category.Name;
                        }
                        else
                        {
                            Result = "/Login";
                        }
                    }
                    else
                    {
                        Result = "/Login";
                    }
                }
            }
            catch (Exception ex)
            {
                Result = "Error! Try Again Later..";
            }
            return Result;
        }
        #endregion
    }

    public class BusinessList
    {
        //LstSubCategory
        private List<ClsPropSubCategory> _LstSubCategory = null;
        public List<ClsPropSubCategory> LstSubCategory
        {
            get { return _LstSubCategory; }
            set { _LstSubCategory = value; }
        }

        //LstSlider
        private List<ClsPropBusiness> _LstSlider = null;
        public List<ClsPropBusiness> LstSlider
        {
            get { return _LstSlider; }
            set { _LstSlider = value; }
        }

        //LstBusiness
        private List<ClsPropBusiness> _LstBusiness = null;
        public List<ClsPropBusiness> LstBusiness
        {
            get { return _LstBusiness; }
            set { _LstBusiness = value; }
        }
    }
}