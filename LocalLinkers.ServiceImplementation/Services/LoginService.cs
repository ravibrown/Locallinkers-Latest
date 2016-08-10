using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using LocalLinkers.ServiceContract;
using LocalLinkers.DataContract;
using DataAccess.Classes;
using System.Web;
using DataAccess;
using System.IO;
using System.Drawing;

namespace LocalLinkers.ServiceImplementation
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class LoginService : ILoginService
    {
        public ResultDataContract AddUser(SignUpDataContract data)
        {
            ResultDataContract memresult = new ResultDataContract();

            try
            {
                if (data != null)
                {
                    ClsLogin obj = new ClsLogin();
                    obj.PhoneNumber = data.PhoneNumber;
                    obj.RoleId = (int)ClsLogin.Role.User;
                    obj.IsDeleted = false;
                    obj.GetRecord();
                    if (!obj.DataRecieved)
                    {
                        ClsLogin objemail = new ClsLogin();
                        if (data.Email != "")
                        {
                            objemail.Email = data.Email;
                            objemail.RoleId = (int)ClsLogin.Role.User;
                            objemail.IsDeleted = false;
                            objemail.GetRecord();
                        }
                        if (!objemail.DataRecieved)
                        {
                            obj.Email = data.Email;
                            obj.Password = data.Password;
                            obj.DeviceCode = data.DeviceCode;
                            obj.IMEI = data.IMEI;
                            obj.PlatForm = data.Platform;
                            if (obj.PhoneNumber == ClsCommon.IphonePhoneNumber)
                            {
                                obj.VerificationCode = "12345";
                            }
                            else
                            {
                                obj.VerificationCode = ClsCommon.NewVerificationCode().Substring(0, 6);
                            }
                            obj.UniqueId = ClsCommon.CreateUniqueId();
                            obj.Add();

                            string messagesignup = ClsCommon.SignUpMessage;
                            messagesignup = messagesignup.ToString().Replace("##OTP##", obj.VerificationCode);
                            ClsCommon.SendCodeThroughSms(obj.PhoneNumber, messagesignup);

                            if (obj.Email != "")
                            {
                                string host = HttpContext.Current.Request.Url.Host;
                                var callBackUrl = host + "/SignUp?code=" + obj.VerificationCode;
                                EmailMessage message = new EmailMessage();
                                message.Message = "Hi ," + obj.Email.Split('@')[0].ToString().ToUpperInvariant() + "<br/>" + messagesignup + "<a href=\"" + callBackUrl + "\">" + callBackUrl.ToString() + "</a>";
                                message.Subject = ClsCommon.EmailRegisterSubject;
                                message.To = obj.Email;
                                bool ret = ClsCommon.SendEmail(message);
                                if (ret == true)
                                {
                                    memresult.UserId = obj.Id;
                                    memresult.Result = "1";
                                    memresult.Result_Details = "Add Succesfully";
                                }
                                else
                                {
                                    memresult.UserId = obj.Id;
                                    memresult.Result = "3";
                                    memresult.Result_Details = "Add member but verification code not sent";
                                }

                            }
                            else
                            {
                                memresult.UserId = obj.Id;
                                memresult.Result = "1";
                                memresult.Result_Details = "Add Succesfully";
                            }
                        }
                        else
                        {
                            memresult.UserId = obj.Id;
                            memresult.Result = "4";
                            memresult.Result_Details = "Email Already Exist";
                        }
                    }
                    else
                    {

                        memresult.UserId = obj.Id;
                        memresult.Result = "2";
                        memresult.Result_Details = "Phone Number Already Exist";

                    }
                }

            }
            catch (Exception a1)
            {
                memresult.UserId = 0;
                memresult.Result = "0";
                memresult.Result_Details = "Error:" + a1.Message;
            }
            return memresult;
        }
        public LoginResultDataContract Login(LoginDataContract data)
        {
            LoginResultDataContract result = new LoginResultDataContract();
            try
            {
                if (data != null)
                {
                    ClsLogin obj = new ClsLogin();
                    string password = data.Password;
                    obj.PhoneNumber = data.PhoneNumber;
                    //obj.RoleId = 0;
                    obj.IsDeleted = false;
                    obj.IsAunthenticate();
                    if (obj.DataRecieved)
                    {
                        ClsUserPoints pts = new ClsUserPoints();
                        pts.UserId = obj.Id;
                        pts.IsDeleted = false;
                        Int64 ReedemPoints = pts.SumPoints();
                        if (obj.Password == password)
                        {


                            if (!obj.IsApprovedByAdmin)
                            {
                                result.UserId = obj.Id;
                                result.RoleId = obj.RoleId;
                                result.Email = obj.Email;
                                result.ReedemPoints = ReedemPoints;
                                result.Phone = obj.PhoneNumber;
                                result.Image = obj.Image;
                                result.UserName = obj.UserName;
                                result.Address = obj.Address1;
                                result.City = obj.City;
                                result.Result = "3";
                                result.Result_Details = "Confirm Your Email First";
                            }
                            else
                            {
                                result.UserId = obj.Id;
                                result.RoleId = obj.RoleId;
                                result.Email = obj.Email;
                                result.Phone = obj.PhoneNumber;
                                result.ReedemPoints = ReedemPoints;
                                result.Image = obj.Image;
                                result.UserName = obj.UserName;
                                result.Address = obj.Address1;
                                result.City = obj.City;
                                result.Result = "1";
                                result.Result_Details = "Login Successfully";
                            }
                            SetEmptyForNullValues(result);
                        }
                        else
                        {
                            result.UserId = obj.Id;
                            result.RoleId = obj.RoleId;
                            result.Email = obj.Email;
                            result.Phone = obj.PhoneNumber;
                            result.ReedemPoints = ReedemPoints;
                            result.Image = obj.Image;
                            result.UserName = obj.UserName;
                            result.Address = obj.Address1;
                            result.City = obj.City;
                            result.Result = "2";
                            result.Result_Details = "Password Did Not Matched";
                        }
                    }
                    else
                    {
                        result.UserId = 0;
                        result.RoleId = 0;
                        result.ReedemPoints = 0;
                        result.Email = "";
                        result.Phone = "";
                        result.Image = "";
                        result.UserName = "";
                        result.Address = "";
                        result.City = "";
                        result.Result = "4";
                        result.Result_Details = "User Doesn't Exist";
                    }
                }

            }
            catch (Exception a1)
            {
                result.UserId = 0;
                result.RoleId = 0;
                result.Email = "";
                result.Phone = "";
                result.Image = "";
                result.UserName = "";
                result.Address = "";
                result.City = "";
                result.Result = "0";
                result.Result_Details = "Error:" + a1.Message;
            }
            return result;
        }
        private void SetEmptyForNullValues(LoginResultDataContract result)
        {

            if (result.Email == null)
            {
                result.Email = "";
            }
            if (result.Phone == null)
            {
                result.Phone = "";
            }
            if (result.ReedemPoints == null)
            {
                result.ReedemPoints = 0;
            }
            if (result.Image == null)
            {
                result.Image = "";
            }
            if (result.UserName == null)
            {
                result.UserName = "";
            }
            if (result.Address == null)
            {
                result.Address = "";
            }
            if (result.City == null)
            {
                result.City = "";
            }
        }
        public LoginResultDataContract CheckVerificationCode(VerificationDataContract data)
        {
            LoginResultDataContract memresult = new LoginResultDataContract();
            try
            {
                if (data != null)
                {
                    ClsLogin obj = new ClsLogin();
                    obj.Id = data.UserId;
                    obj.IsDeleted = false;
                    obj.GetRecord();
                    if (obj.DataRecieved)
                    {
                        if (obj.IsApprovedByAdmin == true)
                        {
                            memresult.UserId = obj.Id;
                            memresult.Email = obj.Email;
                            memresult.Phone = obj.PhoneNumber;
                            memresult.Result = "3";
                            memresult.Result_Details = "Already Verified";
                        }
                        else
                        {
                            if (data.VerificationCode == obj.VerificationCode)
                            {
                                obj.IsApprovedByAdmin = true;
                                obj.Edit();
                                ClsUserPoints points = new ClsUserPoints();
                                points.UserId = obj.Id;
                                points.Points = 10;
                                points.IsApprovedByAdmin = true;
                                points.Add();
                                string messageverified = ClsCommon.VerifiedMessage;
                                ClsCommon.SendCodeThroughSms(obj.PhoneNumber, messageverified);
                                if (obj.Email != "")
                                {
                                    string host = HttpContext.Current.Request.Url.Host;
                                    EmailMessage message = new EmailMessage();
                                    message.Message = "Hi ," + obj.Email.Split('@')[0].ToString().ToUpperInvariant() + "<br/>" + messageverified;
                                    message.Subject = ClsCommon.EmailRegisterSubject;
                                    message.To = obj.Email;
                                    bool ret = ClsCommon.SendEmail(message);
                                }
                                memresult.UserId = obj.Id;
                                memresult.Email = obj.Email;
                                memresult.Phone = obj.PhoneNumber;
                                memresult.Result = "1";
                                memresult.Result_Details = "Succesfully Verified";
                            }
                            else
                            {
                                memresult.UserId = obj.Id;
                                memresult.Email = obj.Email;
                                memresult.Phone = obj.PhoneNumber;
                                memresult.Result = "2";
                                memresult.Result_Details = "Code Doesn't Match";
                            }

                        }
                        SetEmptyForNullValues(memresult);
                    }
                    else
                    {
                        memresult.UserId = 0;
                        memresult.Email = "";
                        memresult.Phone = "";
                        memresult.Result = "4";
                        memresult.Result_Details = "User Doesn't Exist";
                    }
                }
            }
            catch (Exception a1)
            {
                memresult.UserId = 0;
                memresult.Result = "0";
                memresult.Email = "";
                memresult.Phone = "";
                memresult.Result_Details = "Error:" + a1.Message;
            }
            return memresult;
        }
        public VerificationResultDataContract ResendVerificationCode(VerificationByPhoneNumberDataContract data)
        {
            VerificationResultDataContract memresult = new VerificationResultDataContract();
            try
            {
                if (data != null)
                {
                    ClsLogin obj = new ClsLogin();
                    obj.PhoneNumber = data.PhoneNumber;
                    obj.IsDeleted = false;
                    obj.GetRecord();
                    if (obj.DataRecieved)
                    {
                        if (obj.IsApprovedByAdmin == true)
                        {
                            memresult.VerifcationCode = "";
                            memresult.UserId = obj.Id;
                            memresult.Result = "3";
                            memresult.Result_Details = "Already Verified";
                        }
                        else
                        {
                            //obj.VerificationCode = ClsCommon.NewVerificationCode().Substring(0, 6);
                            if (obj.PhoneNumber == ClsCommon.IphonePhoneNumber)
                            {
                                obj.VerificationCode = "12345";
                            }
                            else
                            {
                                obj.VerificationCode = ClsCommon.NewVerificationCode().Substring(0, 6);
                            }
                            obj.Edit();
                            if (obj.DataRecieved && obj.Id > 0)
                            {
                                ClsCommon.SendCodeThroughSms(obj.PhoneNumber, obj.VerificationCode + ClsCommon.ResendOTPMessage);
                                if (obj.Email != "")
                                {
                                    string host = HttpContext.Current.Request.Url.Host;
                                    var callBackUrl = host + "/SignUp?code=" + obj.VerificationCode;
                                    //SendGridMessage message = new SendGridMessage();
                                    //message.AddTo(obj.Email);
                                    //message.From = new MailAddress(obj.Email, ClsCommon.SiteName);
                                    //message.Subject = ClsCommon.EmailRegisterSubject;
                                    //message.Html = "Hi ," + obj.Email.Split('@')[0].ToString().ToUpperInvariant() + "<br/>" + ClsCommon.EmailRegisterBodyMessage + "<a href=\"" + callBackUrl + "\">" + callBackUrl.ToString() + "</a>";

                                    //bool ret = ClsCommon.SendGrid(message);
                                    EmailMessage message = new EmailMessage();
                                    message.Message = "Hi ," + obj.Email.Split('@')[0].ToString().ToUpperInvariant() + "<br/>" + ClsCommon.EmailRegisterBodyMessage + "<a href=\"" + callBackUrl + "\">" + callBackUrl.ToString() + "</a>";
                                    message.Subject = ClsCommon.EmailRegisterSubject;
                                    message.To = obj.Email;
                                    bool ret = ClsCommon.SendEmail(message);
                                    if (ret == true)
                                    {
                                        memresult.VerifcationCode = obj.VerificationCode;
                                        memresult.UserId = obj.Id;
                                        memresult.Result = "1";
                                        memresult.Result_Details = "Code Send Succesfully";
                                    }
                                    else
                                    {
                                        memresult.VerifcationCode = "";
                                        memresult.UserId = obj.Id;
                                        memresult.Result = "2";
                                        memresult.Result_Details = "Code Not Send";
                                    }
                                }
                                else
                                {
                                    memresult.VerifcationCode = obj.VerificationCode;
                                    memresult.UserId = obj.Id;
                                    memresult.Result = "1";
                                    memresult.Result_Details = "Code Send Succesfully";
                                }
                            }
                        }
                    }
                    else
                    {
                        memresult.VerifcationCode = "";
                        memresult.UserId = 0;
                        memresult.Result = "4";
                        memresult.Result_Details = "User Doesn't Exist";
                    }
                }
            }
            catch (Exception a1)
            {
                memresult.VerifcationCode = "";
                memresult.UserId = 0;
                memresult.Result = "0";
                memresult.Result_Details = "Error:" + a1.Message;
            }
            return memresult;
        }
        public VerificationResultDataContract ForgetPassword(ForgetInputDataContract data)
        {
            VerificationResultDataContract memresult = new VerificationResultDataContract();
            try
            {
                if (data != null)
                {
                    ClsLogin obj = new ClsLogin();
                    obj.PhoneNumber = data.PhoneNumber;
                    obj.IsDeleted = false;
                    obj.GetRecord();
                    if (obj.DataRecieved)
                    {
                        //if (obj.IsApprovedByAdmin == true)
                        //{
                        obj.VerificationCode = ClsCommon.NewVerificationCode().Substring(0, 6);
                        obj.Edit();
                        ClsCommon.SendCodeThroughSms(obj.PhoneNumber, obj.VerificationCode + ClsCommon.ForgetPasswordMessage);
                        memresult.VerifcationCode = obj.VerificationCode;
                        memresult.UserId = obj.Id;
                        memresult.Result = "1";
                        memresult.Result_Details = "Succesfully Code Sent";
                        if (obj.Email != "")
                        {
                            string host = HttpContext.Current.Request.Url.Host;
                            var callBackUrl = host + "/ResetPassword?id=" + obj.UniqueId;
                            //SendGridMessage message = new SendGridMessage();
                            //message.AddTo(obj.Email);
                            //message.From = new MailAddress(obj.Email, ClsCommon.SiteName);
                            //message.Subject = ClsCommon.EmailRegisterSubject;
                            //message.Html = "Hi ," + obj.Email.Split('@')[0].ToString().ToUpperInvariant() + "<br/>" + ClsCommon.EmailRegisterBodyMessage + "<a href=\"" + callBackUrl + "\">" + callBackUrl.ToString() + "</a>";

                            //bool ret = ClsCommon.SendGrid(message);
                            EmailMessage message = new EmailMessage();
                            message.Message = "Hi ," + obj.Email.Split('@')[0].ToString().ToUpperInvariant() + "<br/>" + ClsCommon.ResetPasswordBodyMessage + "<a href=\"" + callBackUrl + "\">" + callBackUrl.ToString() + "</a>";
                            message.Subject = ClsCommon.EmailResetPassword;
                            message.To = obj.Email;
                            bool ret = ClsCommon.SendEmail(message);
                        }
                        //}
                        //else
                        //{
                        //    memresult.VerifcationCode = "";
                        //    memresult.UserId = obj.Id;
                        //    memresult.Result = "2";
                        //    memresult.Result_Details = "User Not Verified";
                        //}
                    }
                    else
                    {
                        memresult.VerifcationCode = "";
                        memresult.UserId = 0;
                        memresult.Result = "4";
                        memresult.Result_Details = "User Doesn't Exist";
                    }
                }
            }
            catch (Exception a1)
            {
                memresult.VerifcationCode = "";
                memresult.UserId = 0;
                memresult.Result = "0";
                memresult.Result_Details = "Error:" + a1.Message;
            }
            return memresult;
        }
        public ResultDataContract ResetPassword(ResetPasswordDataContract data)
        {
            ResultDataContract memresult = new ResultDataContract();
            try
            {
                if (data != null)
                {
                    ClsLogin obj = new ClsLogin();
                    obj.PhoneNumber = data.PhoneNumber;
                    obj.IsDeleted = false;
                    obj.GetRecord();
                    if (obj.DataRecieved)
                    {
                        //if (obj.IsApprovedByAdmin == true)
                        //{
                        if (obj.VerificationCode == data.OTP)
                        {
                            obj.Password = data.Password;
                            obj.Edit();
                            memresult.UserId = obj.Id;
                            memresult.Result = "1";
                            memresult.Result_Details = "Succesfully Update Password";
                        }
                        else
                        {
                            memresult.UserId = obj.Id;
                            memresult.Result = "2";
                            memresult.Result_Details = "Code Not Match";
                        }
                        //}
                        //else
                        //{
                        //    memresult.UserId = obj.Id;
                        //    memresult.Result = "3";
                        //    memresult.Result_Details = "User Not Verified";
                        //}
                    }
                    else
                    {
                        memresult.UserId = 0;
                        memresult.Result = "4";
                        memresult.Result_Details = "User Doesn't Exist";
                    }
                }
            }
            catch (Exception a1)
            {
                memresult.UserId = 0;
                memresult.Result = "0";
                memresult.Result_Details = "Error:" + a1.Message;
            }
            return memresult;
        }
        public ResultDataContract ChangePassword(ChangePasswordDataContract data)
        {
            ResultDataContract memresult = new ResultDataContract();
            try
            {
                if (data != null)
                {
                    ClsLogin obj = new ClsLogin();
                    obj.Id = data.UserId;
                    obj.IsDeleted = false;
                    obj.IsApproved = (int)ClsLogin.BooleanValues.Approved;
                    obj.GetRecord();
                    if (obj.DataRecieved)
                    {
                        if (obj.Password.Trim() == data.OldPassword.Trim())
                        {
                            obj.Password = data.NewPassword;
                            obj.Edit();
                            memresult.UserId = obj.Id;
                            memresult.Result = "1";
                            memresult.Result_Details = "Succesfully Update Password";
                        }
                        else
                        {
                            memresult.UserId = obj.Id;
                            memresult.Result = "2";
                            memresult.Result_Details = "Old Password DoesNot Matched";
                        }
                    }
                    else
                    {
                        memresult.UserId = data.UserId;
                        memresult.Result = "3";
                        memresult.Result_Details = "User Doesn't Exist";
                    }
                }
            }
            catch (Exception a1)
            {
                memresult.UserId = 0;
                memresult.Result = "0";
                memresult.Result_Details = "Error:" + a1.Message;
            }
            return memresult;
        }
        public ResultDataContractWithUserImage EditProfile(ProfileDataContract data)
        {
            ResultDataContractWithUserImage memresult = new ResultDataContractWithUserImage();
            try
            {
                if (data != null)
                {
                    ClsLogin obj = new ClsLogin();
                    obj.Id = data.UserId;
                    obj.IsDeleted = false;
                    obj.IsApproved = (int)ClsLogin.BooleanValues.Approved;
                    obj.GetRecord();
                    if (obj.DataRecieved)
                    {
                        //obj.PhoneNumber = data.PhoneNumber;
                        if (data.ImageChange)
                        {
                            string path = System.Web.HttpContext.Current.Server.MapPath(ClsCommon.UserImagesPath) + obj.Image;
                            if (File.Exists(path))
                            {
                                File.Delete(path);
                            }
                            string uploadfilename = DateTime.Now.ToFileTimeUtc().ToString();
                            uploadfilename = uploadfilename + ".jpg";
                            bool flag = ClsCommon.AddImage(data.Image, ClsCommon.UserImagesPath, uploadfilename);
                            if (flag)
                            {
                                obj.Image = uploadfilename;
                            }
                        }
                        obj.PostalCode = data.PostalCode;
                        obj.Email = data.Email;
                        obj.Website = data.Website;
                        obj.UserName = data.UserName;
                        obj.State = data.State;
                        obj.City = data.City;
                        obj.Country = data.Country;
                        obj.Address1 = data.Address1;
                        obj.Address2 = data.Address2;
                        obj.Edit();
                        memresult.ImageName = obj.Image;
                        memresult.UserId = obj.Id;
                        memresult.Result = "1";
                        memresult.Result_Details = "Succesfully Updated";
                    }
                    else
                    {
                        memresult.UserId = data.UserId;
                        memresult.Result = "2";
                        memresult.Result_Details = "User Doesn't Exist";
                    }
                }
            }
            catch (Exception a1)
            {
                memresult.UserId = 0;
                memresult.Result = "0";
                memresult.Result_Details = "Error:" + a1.Message;
            }
            return memresult;
        }
        public CouponListDataContract CouponsList(PagingDataContract data)
        {
            CouponListDataContract memresult = new CouponListDataContract();
            List<CouponDataContract> coupon_list = new List<CouponDataContract>();
            try
            {
                ClsCoupons coupon = new ClsCoupons();
                coupon.Take = data.Counter;
                coupon.Index = data.Index;
                coupon.Id = data.Id;
                coupon.SelectedCity = data.CityId;
                coupon.SelectedPosition = data.SelectedPosition;
                coupon.Latitude = data.Latitude;
                coupon.Longitude = data.Longitude;
                coupon.CategoryId = data.CategoryId;
                coupon.SubCategoryId = data.SubCategoryId;
                coupon.Keyword = data.Keyword;
                coupon.OrderBy = "Distance";
                coupon.IsDeleted = false;
                coupon.IsApproved = (int)ClsCoupons.BooleanValues.Approved;
                List<ClsCoupons> list_coupons = coupon.GetAll();

                if (list_coupons != null)
                {
                    foreach (ClsCoupons item in list_coupons)
                    {
                        CouponDataContract coup = new CouponDataContract();
                        coup.CouponId = item.Id;
                        coup.CategoryId = Convert.ToInt64(item.CategoryId);
                        coup.SubCategoryId = Convert.ToInt64(item.SubCategoryId);
                        coup.SubCategoryName = item.SubCategoryName;
                        coup.CategoryName = item.CategoryName;
                        coup.CityId = item.SelectedCity;
                        coup.CityName = item.CityName;
                        coup.Title = item.Title;
                        coup.BusinessName = item.BusinessName;
                        coup.ActualPrice = item.ActualPrice;
                        coup.Address = item.Address;
                        coup.SalePrice = item.SalePrice;
                        coup.Latitude = item.Latitude;
                        coup.Longitude = item.Longitude;
                        coup.OfferDetails = item.OfferDetails;
                        coup.TermsAndCondition = item.TermsAndCondition;
                        coup.PayToMerchant = item.PayToMerchant;
                        coup.IsDeleted = item.IsDeleted;
                        coup.IsApprovedByAdmin = item.IsApprovedByAdmin;
                        coup.CouponPrice = item.CouponPrice;
                        coup.CreatedBy = item.CreatedBy;
                        coup.CreatedDate = item.CreatedDate;
                        coup.UpdatedDate = item.UpdatedDate;
                        coup.PhoneNumber = item.PhoneNumber;
                        coup.Distance = Convert.ToInt64(item.Distance);
                        coup.CouponMessage = item.CouponMessage;
                        coup.UniqueId = item.UniqueId;
                        coup.Quantity = Convert.ToInt64(item.Quantity);
                        coup.Image = item.Images;
                        coup.IsAsPerBill = item.IsAsPerBill;
                        coupon_list.Add(coup);
                    }
                }

                List<HomeSliderDataContract> lst_Slider = new List<HomeSliderDataContract>();
                if (data.SelectedPosition != 0)
                {
                    ClsHomeSlider obj = new ClsHomeSlider();
                    obj.IsDeleted = false;
                    obj.IsApproved = (int)ClsHomeSlider.BooleanValues.Approved;
                    obj.Take = 5;
                    List<ClsHomeSlider> lst = obj.GetAll();
                    if (lst != null && lst.Count > 0)
                    {
                        foreach (var slider in lst)
                        {
                            HomeSliderDataContract slide = new HomeSliderDataContract();
                            slide.Id = slider.Id;
                            slide.Image = slider.Image;
                            lst_Slider.Add(slide);
                        }
                    }
                }

                if (coupon_list != null && coupon_list.Count > 0)
                {
                    memresult.Lst_Coupons = coupon_list;
                    memresult.lst_Slider = lst_Slider;
                    memresult.Result = "1";
                }
                else
                {
                    memresult.Lst_Coupons = null;
                    memresult.lst_Slider = lst_Slider;
                    memresult.Result = "2";
                }
            }

            catch (Exception a1)
            {
                memresult.Lst_Coupons = null;
                memresult.lst_Slider = null;
                memresult.Result = "0";
            }
            return memresult;
        }
        public ImagesDataContract GetImagesByType(GetImagesDataContract data)
        {
            ImagesDataContract result = new ImagesDataContract();
            try
            {
                List<Images> lst_imgs = new List<Images>();
                if (data.Type == "Coupons")
                {
                    List<ClsCouponImages> images_list = new List<ClsCouponImages>();
                    ClsCouponImages img = new ClsCouponImages();
                    img.CouponId = data.Id;
                    img.IsDeleted = false;
                    images_list = img.GetAll();
                    if (images_list != null && images_list.Count > 0)
                    {
                        foreach (var image_item in images_list)
                        {
                            Images coup_img = new Images();
                            coup_img.Image = image_item.Image;
                            coup_img.Id = Convert.ToInt64(image_item.Id);
                            lst_imgs.Add(coup_img);
                        }
                        result.lst_Images = lst_imgs;
                        result.Result = "1";
                    }
                    else
                    {
                        result.lst_Images = lst_imgs;
                        result.Result = "2";
                    }
                }
                else if (data.Type == "Products")
                {
                    List<ClsProductImages> images_list = new List<ClsProductImages>();
                    ClsProductImages img = new ClsProductImages();
                    img.ProductId = data.Id;
                    img.IsDeleted = false;
                    images_list = img.GetAll();
                    if (images_list != null && images_list.Count > 0)
                    {
                        foreach (var image_item in images_list)
                        {
                            Images pro_img = new Images();
                            pro_img.Image = image_item.Image;
                            pro_img.Id = Convert.ToInt64(image_item.Id);
                            lst_imgs.Add(pro_img);
                        }
                        result.lst_Images = lst_imgs;
                        result.Result = "1";
                    }
                    else
                    {
                        result.lst_Images = lst_imgs;
                        result.Result = "2";
                    }
                }
            }
            catch (Exception a1)
            {
                result.lst_Images = null;
                result.Result = "0";
            }
            return result;
        }
        public BusinessListDataContract BusinessList(PagingDataContract data)
        {
            BusinessListDataContract memresult = new BusinessListDataContract();
            List<BusinessDataContract> business_list = new List<BusinessDataContract>();
            try
            {
                ClsBusiness objbusiness = new ClsBusiness();
                objbusiness.Take = data.Counter;
                objbusiness.Index = data.Index;
                objbusiness.Id = data.Id;
                objbusiness.Latitude = data.Latitude;
                objbusiness.SelectedCity = data.CityId;
                objbusiness.Longitude = data.Longitude;
                objbusiness.CategoryId = data.CategoryId;
                objbusiness.SubCategoryId = data.SubCategoryId;
                objbusiness.Keyword = data.Keyword;
                objbusiness.OrderBy = "Distance";
                objbusiness.IsDeleted = false;
                objbusiness.IsApproved = (int)ClsBusiness.BooleanValues.Approved;
                List<ClsBusiness> list_business = objbusiness.GetAll();

                if (list_business != null)
                {
                    foreach (ClsBusiness item in list_business)
                    {
                        BusinessDataContract business = new BusinessDataContract();
                        business.BusinessId = item.Id;
                        business.CategoryId = Convert.ToInt64(item.CategoryId);
                        business.SubCategoryId = Convert.ToInt64(item.SubCategoryId);
                        business.SubCategoryName = item.SubCategoryName;
                        business.CategoryName = item.CategoryName; ;
                        business.Description = item.Description;
                        business.ContactPerson = item.ContactPerson;
                        business.BusinessName = item.BusinessName;
                        business.Email = item.Email;
                        business.Address = item.Address;
                        business.Website = item.Website;
                        business.Latitude = item.Latitude;
                        business.Longitude = item.Longitude;
                        business.PhoneNumber1 = item.PhoneNumber1;
                        business.PhoneNumber2 = item.PhoneNumber2;
                        business.IsDeleted = item.IsDeleted;
                        business.IsApprovedByAdmin = item.IsApprovedByAdmin;
                        business.CreatedBy = item.CreatedBy;
                        business.CreatedDate = item.CreatedDate;
                        business.CityId = Convert.ToInt64(item.SelectedCity);
                        business.CityName = item.CityName;
                        business.UpdatedDate = item.UpdatedDate;
                        business.Distance = Convert.ToInt64(item.Distance);
                        business.ButtonTitle = item.ButtonTitle;
                        business.UserMessage = item.UserMessage;
                        business.Subscription = Convert.ToInt64(item.Subscription);

                        //Add images in list of per item
                        business.Image = item.Image;
                        business_list.Add(business);

                    }
                }

                if (business_list != null && business_list.Count > 0)
                {
                    memresult.Lst_Business = business_list;
                    memresult.Result = "1";
                }
                else
                {
                    memresult.Lst_Business = null;
                    memresult.Result = "2";
                }
            }

            catch (Exception a1)
            {
                memresult.Lst_Business = null;
                memresult.Result = "0";
            }
            return memresult;
        }
        public ProductListDataContract ProductList(PagingDataContract data)
        {
            ProductListDataContract memresult = new ProductListDataContract();
            List<ProductDataContract> product_list = new List<ProductDataContract>();
            try
            {
                ClsProducts product = new ClsProducts();
                product.Take = data.Counter;
                product.Index = data.Index;
                product.Id = data.Id;
                product.SelectedCity = data.CityId;
                product.Latitude = data.Latitude;
                product.Longitude = data.Longitude;
                product.CategoryId = data.CategoryId;
                product.SubCategoryId = data.SubCategoryId;
                product.Keyword = data.Keyword;
                product.IsDeleted = false;
                product.IsApproved = (int)ClsProducts.BooleanValues.Approved;
                List<ClsProducts> list_products = product.GetAll();

                if (list_products != null)
                {
                    foreach (ClsProducts item in list_products)
                    {
                        ProductDataContract pro = new ProductDataContract();
                        pro.ProductId = item.Id;
                        pro.CategoryId = Convert.ToInt64(item.CategoryId);
                        pro.SubCategoryId = Convert.ToInt64(item.SubCategoryId);
                        pro.SubCategoryName = item.SubCategoryName;
                        pro.CategoryName = item.CategoryName;
                        pro.CityId = item.SelectedCity;
                        pro.CityName = item.CityName;
                        pro.Title = item.Title;
                        pro.Description = item.Description;
                        pro.ActualPrice = item.ActualPrice;
                        pro.Address = item.Address;
                        pro.SalePrice = item.SalePrice;
                        pro.Latitude = item.Latitude;
                        pro.Longitude = item.Longitude;
                        pro.ShortDescription = item.ShortDescription;
                        pro.Stock = item.Stock;
                        pro.IsDeleted = item.IsDeleted;
                        pro.IsApprovedByAdmin = item.IsApprovedByAdmin;
                        pro.CreatedBy = item.CreatedBy;
                        pro.CreatedDate = item.CreatedDate;
                        pro.UpdatedDate = item.UpdatedDate;
                        pro.Distance = Convert.ToInt64(item.Distance);
                        pro.Image = item.Image;
                        product_list.Add(pro);

                    }
                }

                if (product_list != null && product_list.Count > 0)
                {
                    memresult.Lst_Products = product_list;
                    memresult.Result = "1";
                }
                else
                {
                    memresult.Lst_Products = null;
                    memresult.Result = "2";
                }
            }

            catch (Exception a1)
            {
                memresult.Lst_Products = null;
                memresult.Result = "0";
            }
            return memresult;
        }
        public CategoryListDataContract CategoryList(CategoryFilterDataContract data)
        {
            CategoryListDataContract memresult = new CategoryListDataContract();
            List<CategoryDataContract> category_list = new List<CategoryDataContract>();
            try
            {
                ClsCategory objCategory = new ClsCategory();
                List<ClsPropCategory> list_category = new List<ClsPropCategory>();
                objCategory.IsDeleted = false;
                objCategory.IsApproved = (int)ClsCategory.BooleanValues.Approved;
                if (!string.IsNullOrEmpty(data.Type) && data.Type.ToLower() == "coupons")
                {
                    list_category = objCategory.GetAllForAjaxWithCoupons();
                }
                else if (!string.IsNullOrEmpty(data.Type) && data.Type.ToLower() == "products")
                {
                    list_category = objCategory.GetAllForAjaxWithProducts();
                }
                else
                {
                    list_category = objCategory.GetAllForAjaxWithBusiness();
                }
                if (list_category != null)
                {
                    foreach (ClsPropCategory item in list_category)
                    {
                        CategoryDataContract category = new CategoryDataContract();
                        category.CategoryId = item.Id;
                        category.Description = item.Description;
                        category.Name = item.Name;
                        category.Image = item.Image;
                        category.IsDeleted = item.IsDeleted;
                        category.IsApprovedByAdmin = item.IsApprovedByAdmin;
                        category.CreatedBy = item.CreatedBy;
                        category.CreatedDate = item.CreatedDate;
                        category.UpdatedDate = item.UpdatedDate;
                        category_list.Add(category);
                    }
                }

                if (category_list != null && category_list.Count > 0)
                {
                    memresult.Lst_Category = category_list;
                    memresult.Result = "1";
                }
                else
                {
                    memresult.Lst_Category = null;
                    memresult.Result = "2";
                }
            }

            catch (Exception a1)
            {
                memresult.Lst_Category = null;
                memresult.Result = "0";
            }
            return memresult;
        }
        public SubCategoryListDataContract SubCategoryList(SubCategoryFilterDataContract data)
        {
            SubCategoryListDataContract memresult = new SubCategoryListDataContract();
            List<SubCategoryDataContract> subcategory_list = new List<SubCategoryDataContract>();
            try
            {
                ClsSubCategory sub = new ClsSubCategory();
                sub.CategoryId = data.Id;
                sub.IsApproved = (int)ClsSubCategory.BooleanValues.Approved;
                sub.IsDeleted = false;
                List<ClsSubCategory> lst_subcategory = sub.GetAll();

                if (lst_subcategory != null && lst_subcategory.Count > 0)
                {
                    foreach (var subcate in lst_subcategory)
                    {
                        SubCategoryDataContract subcategory = new SubCategoryDataContract();
                        subcategory.SubCategoryId = subcate.Id;
                        subcategory.CategoryId = Convert.ToInt64(subcate.CategoryId);
                        subcategory.Description = subcate.Description;
                        subcategory.Name = subcate.Name;
                        subcategory.Image = subcate.Image;
                        subcategory.IsDeleted = subcate.IsDeleted;
                        subcategory.IsApprovedByAdmin = subcate.IsApprovedByAdmin;
                        subcategory.CreatedBy = subcate.CreatedBy;
                        subcategory.CreatedDate = subcate.CreatedDate;
                        subcategory.UpdatedDate = subcate.UpdatedDate;
                        subcategory_list.Add(subcategory);
                    }
                }
                if (subcategory_list != null && subcategory_list.Count > 0)
                {
                    memresult.Lst_SubCategory = subcategory_list;
                    memresult.Result = "1";
                }
                else
                {
                    memresult.Lst_SubCategory = null;
                    memresult.Result = "2";
                }
            }
            catch (Exception a1)
            {
                memresult.Lst_SubCategory = null;
                memresult.Result = "0";
            }
            return memresult;
        }
        public CityListDataContract CityList()
        {
            CityListDataContract memresult = new CityListDataContract();
            List<CityDataContract> city_list = new List<CityDataContract>();
            try
            {
                ClsCoupons objcity = new ClsCoupons();
                List<tbl_Cities> list_cities = objcity.GetAllCities();

                if (list_cities != null)
                {
                    foreach (tbl_Cities item in list_cities)
                    {
                        CityDataContract city = new CityDataContract();
                        city.Id = item.Id;
                        city.CityName = item.CityName;
                        city_list.Add(city);

                    }
                }

                if (city_list != null && city_list.Count > 0)
                {
                    memresult.Lst_City = city_list;
                    memresult.Result = "1";
                }
                else
                {
                    memresult.Lst_City = null;
                    memresult.Result = "2";
                }
            }

            catch (Exception a1)
            {
                memresult.Lst_City = null;
                memresult.Result = "0";
            }
            return memresult;
        }
        public AddressListDataContract AddressList(AddressParameterDataContract data)
        {
            AddressListDataContract memresult = new AddressListDataContract();
            List<OrderDataContract> order_list = new List<OrderDataContract>();
            try
            {
                ClsOrders order = new ClsOrders();
                order.AddressId = data.AddressId;
                order.IsDeleted = false;
                List<ClsOrders> list_orders = order.GetAll();

                if (list_orders != null)
                {
                    foreach (ClsOrders item in list_orders)
                    {
                        OrderDataContract ord = new OrderDataContract();
                        ord.OrderId = item.Id;
                        ord.CouponCode = item.OrderId;
                        ord.BillingName = item.BillingName;
                        ord.BillingZip = item.BillingZip;
                        ord.BillingState = item.BillingState;
                        ord.BillingCity = item.BillingCity;
                        ord.BillingCountry = item.BillingCountry;
                        ord.BillingTel = item.BillingTel;
                        ord.BillingEmail = item.BillingEmail;
                        ord.BillingAddress = item.BillingAddress;
                        ord.DeliveryName = item.DeliveryName;
                        ord.DeliveryZip = item.DeliveryZip;
                        ord.DeliveryState = item.DeliveryState;
                        ord.DeliveryCity = item.DeliveryCity;
                        ord.DeliveryCountry = item.DeliveryCountry;
                        ord.DeliveryTel = item.DeliveryTel;
                        ord.DeliveryEmail = item.DeliveryEmail;
                        ord.DeliveryAddress = item.DeliveryAddress;
                        ord.IsDeleted = item.IsDeleted;
                        ord.IsApprovedByAdmin = item.IsApprovedByAdmin;
                        ord.CreatedBy = item.CreatedBy;
                        ord.CreatedDate = item.CreatedDate;
                        ord.UpdatedDate = item.UpdatedDate;
                        ord.TrackingId = item.TrackingId;
                        ord.UserId = Convert.ToInt64(item.UserId);
                        ord.UserPhone = item.UserPhone;
                        ord.PaymentMode = item.PaymentMode;
                        order_list.Add(ord);

                    }
                }

                if (order_list != null && order_list.Count > 0)
                {
                    memresult.Lst_Address = order_list;
                    memresult.Result = "1";
                }
                else
                {
                    memresult.Lst_Address = null;
                    memresult.Result = "2";
                }
            }

            catch (Exception a1)
            {
                memresult.Lst_Address = null;
                memresult.Result = "0";
            }
            return memresult;
        }
        public OrdersListDataContract OrdersList(OrderParameterDataContract data)
        {
            OrdersListDataContract memresult = new OrdersListDataContract();
            List<OrdersProducts> order_list = new List<OrdersProducts>();
            try
            {
                ClsOrderMapping order = new ClsOrderMapping();
                order.Take = data.Counter;
                order.Index = data.Index;
                order.UserId = data.UserId;
                order.IsDeleted = false;
                List<ClsOrderMapping> list_orders = order.GetAll();

                if (list_orders != null)
                {
                    foreach (ClsOrderMapping item in list_orders)
                    {
                        OrdersProducts product = new OrdersProducts();
                        product.Title = item.Title;
                        product.Price = item.Price;
                        product.Type = item.Type;
                        product.Image = item.Image;
                        product.AddressId = Convert.ToInt64(item.AddressId);
                        product.Quantity = Convert.ToInt64(item.Quantity);
                        product.Id = Convert.ToInt64(item.ProductId);
                        product.PaymentMode = item.PaymentMode;
                        product.OrderId = item.CouponCode;
                        product.CreatedDate = item.CreatedDate.ToString();
                        order_list.Add(product);

                    }
                }

                if (order_list != null && order_list.Count > 0)
                {
                    memresult.Lst_Orders = order_list;
                    memresult.Result = "1";
                }
                else
                {
                    memresult.Lst_Orders = null;
                    memresult.Result = "2";
                }
            }

            catch (Exception a1)
            {
                memresult.Lst_Orders = null;
                memresult.Result = "0";
            }
            return memresult;
        }
        public HomeSliderListDataContract HomeSlider()
        {
            HomeSliderListDataContract Result = new HomeSliderListDataContract();
            List<HomeSliderDataContract> lst_Slider = new List<HomeSliderDataContract>();
            try
            {
                ClsHomeSlider obj = new ClsHomeSlider();
                obj.IsDeleted = false;
                obj.IsApproved = (int)ClsHomeSlider.BooleanValues.Approved;
                obj.Take = 5;
                List<ClsHomeSlider> lst = obj.GetAll();
                if (lst != null && lst.Count > 0)
                {
                    foreach (var item in lst)
                    {
                        HomeSliderDataContract slide = new HomeSliderDataContract();
                        slide.Id = item.Id;
                        slide.Image = item.Image;
                        lst_Slider.Add(slide);
                    }
                    Result.Lst_Slider = lst_Slider;
                    Result.Result = "1";
                }
                else
                {
                    Result.Lst_Slider = lst_Slider;
                    Result.Result = "2";
                }
            }
            catch (Exception ex)
            {
                Result.Lst_Slider = null;
                Result.Result = "0";
            }
            return Result;
        }
        public PointsResultDataContract GetUserPoints(PointsDataContract data)
        {
            PointsResultDataContract Result = new PointsResultDataContract();
            try
            {
                ClsUserPoints obj = new ClsUserPoints();
                obj.IsDeleted = false;
                obj.UserId = data.UserId;
                Int64 ReedemPoints = obj.SumPoints();
                if (ReedemPoints > 0)
                {
                    Result.ReedemPoints = ReedemPoints;
                    Result.Result = "1";
                }
                else
                {
                    Result.ReedemPoints = 0;
                    Result.Result = "2";
                }
            }
            catch (Exception ex)
            {
                Result.ReedemPoints = 0;
                Result.Result = "0";
            }
            return Result;
        }
        public ResultDataContract ConfirmBusinessBooking(BookingConfirmationDataContract data)
        {
            ResultDataContract Result = new ResultDataContract();
            try
            {
                ClsBusinessBooking obj = new ClsBusinessBooking();
                obj.BusinessId = data.BusinessId;
                obj.UserId = data.UserId;
                List<ClsBusinessBooking> list_Business = obj.GetAll();
                if (list_Business.Count == 0)
                {
                    obj.Time = data.Time;
                    DateTime ConvertedDate = DateTime.ParseExact(data.Date, "dd/MM/yyyy", null);
                    obj.BookingDate = ConvertedDate;
                    obj.Message = data.UserMessage;
                    obj.Add();
                    if (obj.Id > 0)
                    {
                        ClsBusiness business = new ClsBusiness();
                        ClsCategory category = new ClsCategory();
                        business.Id = data.BusinessId;
                        business.GetRecord();

                        ClsLogin log = new ClsLogin();
                        log.IsApproved = (int)ClsLogin.BooleanValues.Approved;
                        log.IsDeleted = false;
                        log.Id = data.UserId;
                        log.RoleId = 0;
                        log.GetRecord();

                        string businessmessage = ClsCommon.BusinessBookingMessage;
                        businessmessage = businessmessage.Replace("##Date##", data.Date);
                        businessmessage = businessmessage.Replace("##Time##", data.Time);
                        businessmessage = businessmessage.Replace("##Message##", data.UserMessage);
                        businessmessage = businessmessage.Replace("##NameAndPhoneNumber##", (!string.IsNullOrEmpty(log.UserName) ? log.UserName + "/" + log.PhoneNumber : log.PhoneNumber));

                        string businessusermessage = ClsCommon.BusinessBookingUserMessage;
                        businessusermessage = businessusermessage.Replace("##Date##", data.Date);
                        businessusermessage = businessusermessage.Replace("##Time##", data.Time);
                        businessusermessage = businessusermessage.Replace("##BusinessName##", business.BusinessName);

                        if (!string.IsNullOrEmpty(business.PhoneNumber1))
                        {
                            ClsCommon.SendCodeThroughSms(business.PhoneNumber1, businessmessage);
                            // ClsCommon.SendCodeThroughSms(log.PhoneNumber, (!string.IsNullOrEmpty(log.UserName) ? log.UserName : log.PhoneNumber) + " " + data.UserMessage + " Date:" + data.Date + " Time:" + data.Time);
                        }
                        if (!string.IsNullOrEmpty(log.PhoneNumber))
                        {
                            // ClsCommon.SendCodeThroughSms(business.PhoneNumber1, (!string.IsNullOrEmpty(log.UserName) ? log.UserName : log.PhoneNumber) + " " + data.UserMessage + " Date:" + data.Date + " Time:" + data.Time);
                            ClsCommon.SendCodeThroughSms(log.PhoneNumber, businessusermessage);
                        }

                        if (!string.IsNullOrEmpty(business.Email) && log.DataRecieved)
                        {
                            string host = HttpContext.Current.Request.Url.Host;
                            //Send message to owner of business
                            EmailMessage message = new EmailMessage();
                            message.Message = "Hi ," + business.ContactPerson + "<br/>" + businessmessage + (!string.IsNullOrEmpty(log.UserName) ? log.UserName : log.PhoneNumber + data.UserMessage + " Date:" + data.Date + " Time:" + data.Time);
                            message.Subject = ClsCommon.BusinessBookingSubject;
                            message.To = business.Email;
                            bool ret = ClsCommon.SendEmail(message);
                        }

                        if (!string.IsNullOrEmpty(log.Email) && log.DataRecieved)
                        {
                            //Send message to user
                            EmailMessage message1 = new EmailMessage();
                            message1.Message = "Hi ," + (!string.IsNullOrEmpty(log.UserName) ? log.UserName : log.PhoneNumber) + "<br/>" + businessusermessage + (!string.IsNullOrEmpty(log.UserName) ? log.UserName : log.PhoneNumber + data.UserMessage + " Date:" + data.Date + " Time:" + data.Time);
                            message1.Subject = ClsCommon.BusinessBookingSubject;
                            message1.To = log.Email;
                            bool ret1 = ClsCommon.SendEmail(message1);
                        }
                        Result.Result = "1";
                        Result.Result_Details = "Booked Successfully";
                        Result.UserId = data.UserId;
                    }
                }
                else
                {
                    Result.Result = "2";
                    Result.Result_Details = "Already booked";
                    Result.UserId = data.UserId;
                }
            }
            catch (Exception ex)
            {
                Result.Result = "0";
                Result.Result_Details = ex.Message;
                Result.UserId = data.UserId;
            }
            return Result;
        }


        public List<ListingByDistanceDataContract> GetListingsByDistance(ListingByDistanceDataBindingModel model)
        {
            string latitude = model.latitude; string longitude = model.longitude; long cityID = model.cityID; decimal distance = model.distance; int type = model.type;
            ClsBusiness business = new ClsBusiness();
            if (type == 1)
            {
                List<ListingByDistanceDataContract> list = new List<ListingByDistanceDataContract>();

                var data = business.GetBusinessListingByDistance(latitude, longitude, cityID, distance, 20, 0);
                foreach (var item in data)
                {
                    ListingByDistanceDataContract obj = new ListingByDistanceDataContract();
                    obj.Image = item.Image;
                    obj.Description = item.Description;
                    obj.CategoryID = item.CategoryID;
                    obj.ListingID = item.ListingID;
                    obj.Distance = item.Distance;
                    obj.Latitude = item.Latitude;
                    obj.Longitude = item.Longitude;
                    obj.Title = item.Title;
                    obj.Type = item.Type;
                    list.Add(obj);
                }
                return list;
            }
            else if (type == 2)
            {
                var data = business.GetCouponListingByDistance(latitude, longitude, cityID, distance, 20, 0);
                List<ListingByDistanceDataContract> list = new List<ListingByDistanceDataContract>();

                foreach (var item in data)
                {
                    ListingByDistanceDataContract obj = new ListingByDistanceDataContract();
                    obj.Description = item.Description;
                    obj.CategoryID = item.CategoryID;
                    obj.ListingID = item.ListingID;
                    obj.Image = item.Image;
                    obj.Description = item.Description;
                    obj.Distance = item.Distance;
                    obj.Latitude = item.Latitude;
                    obj.Longitude = item.Longitude;
                    obj.Title = item.Title;
                    obj.Type = item.Type;
                    list.Add(obj);
                }
                return list;
            }
            else
            {
                return null;
            }
        }

        public CouponListDataContract GetCouponListingsByDistance(ListingByDistanceDataBindingModel model)
        {
            string latitude = model.latitude; string longitude = model.longitude;
            long cityID = model.cityID; decimal distance = model.distance;
            int type = model.type;

            CouponListDataContract memresult = new CouponListDataContract();
            ClsBusiness business = new ClsBusiness();
            List<CouponDataContract> coupon_list = new List<CouponDataContract>();
            try
            {
                //ClsCoupons coupon = new ClsCoupons();
                //coupon.Take = data.Counter;
                //coupon.Index = data.Index;
                //coupon.Id = data.Id;
                //coupon.SelectedCity = data.CityId;
                //coupon.SelectedPosition = data.SelectedPosition;
                //coupon.Latitude = data.Latitude;
                //coupon.Longitude = data.Longitude;
                //coupon.CategoryId = data.CategoryId;
                //coupon.SubCategoryId = data.SubCategoryId;
                //coupon.Keyword = data.Keyword;
                //coupon.OrderBy = "Distance";
                //coupon.IsDeleted = false;
                //coupon.IsApproved = (int)ClsCoupons.BooleanValues.Approved;
                //List<ClsCoupons> list_coupons = coupon.GetAll();
                var list_coupons = business.GetCouponListingByDistanceWithMoreResponseData(latitude, longitude, cityID, distance, 20, 0);
                if (list_coupons != null)
                {
                    foreach (ClsCoupons item in list_coupons)
                    {
                        CouponDataContract coup = new CouponDataContract();
                        coup.CouponId = item.Id;
                        coup.CategoryId = Convert.ToInt64(item.CategoryId);
                        coup.SubCategoryId = Convert.ToInt64(item.SubCategoryId);
                        coup.SubCategoryName = item.SubCategoryName;
                        coup.CategoryName = item.CategoryName;
                        coup.CityId = item.SelectedCity;
                        coup.CityName = item.CityName;
                        coup.Title = item.Title;
                        coup.BusinessName = item.BusinessName;
                        coup.ActualPrice = item.ActualPrice;
                        coup.Address = item.Address;
                        coup.SalePrice = item.SalePrice;
                        coup.Latitude = item.Latitude;
                        coup.Longitude = item.Longitude;
                        coup.OfferDetails = item.OfferDetails;
                        coup.TermsAndCondition = item.TermsAndCondition;
                        coup.PayToMerchant = item.PayToMerchant;
                        coup.IsDeleted = item.IsDeleted;
                        coup.IsApprovedByAdmin = item.IsApprovedByAdmin;
                        coup.CouponPrice = item.CouponPrice;
                        coup.CreatedBy = item.CreatedBy;
                        coup.CreatedDate = item.CreatedDate;
                        coup.UpdatedDate = item.UpdatedDate;
                        coup.PhoneNumber = item.PhoneNumber;
                        coup.Distance = Convert.ToInt64(item.Distance);
                        coup.CouponMessage = item.CouponMessage;
                        coup.UniqueId = item.UniqueId;
                        coup.Quantity = Convert.ToInt64(item.Quantity);
                        coup.Image = item.Images;
                        coup.IsAsPerBill = item.IsAsPerBill;
                        coupon_list.Add(coup);
                    }
                }

                List<HomeSliderDataContract> lst_Slider = new List<HomeSliderDataContract>();
               

                if (coupon_list != null && coupon_list.Count > 0)
                {
                    memresult.Lst_Coupons = coupon_list;
                    memresult.lst_Slider = lst_Slider;
                    memresult.Result = "1";
                }
                else
                {
                    memresult.Lst_Coupons = null;
                    memresult.lst_Slider = lst_Slider;
                    memresult.Result = "2";
                }
            }

            catch (Exception a1)
            {
                memresult.Lst_Coupons = null;
                memresult.lst_Slider = null;
                memresult.Result = "0";
            }
            return memresult;
        }
        public CouponListDataContract GetCouponListingsByMultiPolygon(ListingByDistanceWithMultiPolygonDataBindingModel model)
        {
            List<string> lst_MP = model.lst_longLat;

            string str_MultiPolygon = "";
            int count1122 = 0;
            string firstlatlong = "";

            foreach (string lnglat in lst_MP)
            {
                if (count1122 == 0)
                {
                    firstlatlong = lnglat;
                }

                str_MultiPolygon += lnglat + ",";

                count1122++;
            }

            str_MultiPolygon += firstlatlong;   // same last and end point


            //List<View_GetEventWithInMultiPolygon> lst_event_vw = conoeManager.GetAllActiveTableEventWithInMultiPolygonDrawn_SP(dt_currentUTC, str_MultiPolygon);


            CouponListDataContract memresult = new CouponListDataContract();
            ClsBusiness business = new ClsBusiness();
            
            List<CouponDataContract> coupon_list = new List<CouponDataContract>();
            try
            {
               
                var list_coupons = business.GetCouponListingByDistanceWithMulitPolygon(str_MultiPolygon); 
                if (list_coupons != null)
                {
                    foreach (ClsCoupons item in list_coupons)
                    {
                        CouponDataContract coup = new CouponDataContract();
                        coup.CouponId = item.Id;
                        coup.CategoryId = Convert.ToInt64(item.CategoryId);
                        coup.SubCategoryId = Convert.ToInt64(item.SubCategoryId);
                        coup.SubCategoryName = item.SubCategoryName;
                        coup.CategoryName = item.CategoryName;
                        coup.CityId = item.SelectedCity;
                        coup.CityName = item.CityName;
                        coup.Title = item.Title;
                        coup.BusinessName = item.BusinessName;
                        coup.ActualPrice = item.ActualPrice;
                        coup.Address = item.Address;
                        coup.SalePrice = item.SalePrice;
                        coup.Latitude = item.Latitude;
                        coup.Longitude = item.Longitude;
                        coup.OfferDetails = item.OfferDetails;
                        coup.TermsAndCondition = item.TermsAndCondition;
                        coup.PayToMerchant = item.PayToMerchant;
                        coup.IsDeleted = item.IsDeleted;
                        coup.IsApprovedByAdmin = item.IsApprovedByAdmin;
                        coup.CouponPrice = item.CouponPrice;
                        coup.CreatedBy = item.CreatedBy;
                        coup.CreatedDate = item.CreatedDate;
                        coup.UpdatedDate = item.UpdatedDate;
                        coup.PhoneNumber = item.PhoneNumber;
                        coup.Distance = Convert.ToInt64(item.Distance);
                        coup.CouponMessage = item.CouponMessage;
                        coup.UniqueId = item.UniqueId;
                        coup.Quantity = Convert.ToInt64(item.Quantity);
                        coup.Image = item.Images;
                        coup.IsAsPerBill = item.IsAsPerBill;
                        coupon_list.Add(coup);
                    }
                }

                List<HomeSliderDataContract> lst_Slider = new List<HomeSliderDataContract>();


                if (coupon_list != null && coupon_list.Count > 0)
                {
                    memresult.Lst_Coupons = coupon_list;
                    memresult.lst_Slider = lst_Slider;
                    memresult.Result = "1";
                }
                else
                {
                    memresult.Lst_Coupons = null;
                    memresult.lst_Slider = lst_Slider;
                    memresult.Result = "2";
                }
            }

            catch (Exception a1)
            {
                memresult.Lst_Coupons = null;
                memresult.lst_Slider = null;
                memresult.Result = "0";
            }
            return memresult;
        }
    }
}
