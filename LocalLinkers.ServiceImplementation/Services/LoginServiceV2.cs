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
    public class LoginServiceV2 : ILoginServiceV2
    {
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
        public LoginResultDataContract CheckVerificationCode(OTPDataContract data)
        {
            LoginResultDataContract memresult = new LoginResultDataContract();
            try
            {
                if (data != null)
                {
                    ClsLogin obj = new ClsLogin();
                    obj.PhoneNumber = data.Phone;

                    obj.IsDeleted = false;
                    obj.GetRecordByPhone(data.Phone);
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
                            if (data.OTPCode == obj.VerificationCode)
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
                                memresult.RoleId = obj.RoleId;

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

        public SubCategoryListDataContract SubCategoryList(long categoryId, string type)
        {
            SubCategoryListDataContract memresult = new SubCategoryListDataContract();
            List<SubCategoryDataContract> subcategory_list = new List<SubCategoryDataContract>();
            try
            {
                ClsSubCategory sub = new ClsSubCategory();
                sub.CategoryId = categoryId;
                sub.IsApproved = (int)ClsSubCategory.BooleanValues.Approved;
                sub.IsDeleted = false;
                List<ClsSubCategory> lst_subcategory = sub.GetSubcategoriesWithData(type);

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

        public ResultDataContract CheckCouponValidation(long UserId, long CouponId)
        {
            ResultDataContract result = new ResultDataContract();
            try
            {
                    ClsOrderMapping OrderExist = new ClsOrderMapping();
                    OrderExist.UserId = UserId;
                    OrderExist.OriginalProductId = CouponId;
                    OrderExist.Type = "Coupon";
                    OrderExist.GetRecord();
                    if (OrderExist.DataRecieved)
                    {
                        result.Result = "1";
                        result.Result_Details = "Coupon Exist";
                        result.UserId = UserId;
                    }
                    else
                    {
                        result.Result = "2";
                        result.Result_Details = "Coupon Not Exist";
                        result.UserId = UserId;
                    }
                   
            }
            catch (Exception a1)
            {
                result.Result = "0";
                result.Result_Details = a1.Message;
                result.UserId = 0;
            }
            return result;
        }
    }
}
