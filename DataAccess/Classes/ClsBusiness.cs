using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace DataAccess.Classes
{
    public class ClsBusiness : EntityContext
    {
        #region "Enums"
        public enum BooleanValues
        {
            Both = 2,
            Approved = 1,
            Disapproved = 0
        }

        public enum BusinessSubscription
        {
            Premium = 1,
            Paid = 2,
            Free = 3
        }
        #endregion

        #region "Properties"
        //Id
        private Int64 _Id = 0;
        public Int64 Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        //SNO
        private Int64? _SNO = 0;
        public Int64? SNO
        {
            get { return _SNO ?? 0; }
            set { _SNO = value; }
        }

        //IsApproved
        private Int64 _IsApproved = (int)BooleanValues.Both;
        public Int64 IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }

        //Subscription
        private Int64? _Subscription = (int)BusinessSubscription.Free;
        public Int64? Subscription
        {
            get { return _Subscription; }
            set { _Subscription = value; }
        }

        //Message
        private string _Message = string.Empty;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        //UserMessage
        private string _UserMessage = string.Empty;
        public string UserMessage
        {
            get { return _UserMessage; }
            set { _UserMessage = value; }
        }

        //ButtonTitle
        private string _ButtonTitle = string.Empty;
        public string ButtonTitle
        {
            get { return _ButtonTitle; }
            set { _ButtonTitle = value; }
        }

        //Description 
        private string _Description = string.Empty;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        //SubCategoryIds
        private string _SubCategoryIds = string.Empty;
        public string SubCategoryIds
        {
            get { return _SubCategoryIds; }
            set { _SubCategoryIds = value; }
        }

        //BusinessName
        private string _BusinessName = string.Empty;
        public string BusinessName
        {
            get { return _BusinessName; }
            set { _BusinessName = value; }
        }

        //LstSubCategory
        private List<ClsPropSubCategory> _LstSubCategory = null;
        public List<ClsPropSubCategory> LstSubCategory
        {
            get { return _LstSubCategory; }
            set { _LstSubCategory = value; }
        }

        //Address
        private string _Address = string.Empty;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        //Latitude
        private string _Latitude = ClsCommon.DefaultLatitude;
        public string Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }

        //Longitude
        private string _Longitude = ClsCommon.DefaultLongitude;
        public string Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }

        //ContactPerson
        private string _ContactPerson = string.Empty;
        public string ContactPerson
        {
            get { return _ContactPerson; }
            set { _ContactPerson = value; }
        }


        //PhoneNumber1
        private string _PhoneNumber1 = string.Empty;
        public string PhoneNumber1
        {
            get { return _PhoneNumber1; }
            set { _PhoneNumber1 = value; }
        }

        //PhoneNumber2
        private string _PhoneNumber2 = string.Empty;
        public string PhoneNumber2
        {
            get { return _PhoneNumber2; }
            set { _PhoneNumber2 = value; }
        }

        //Email
        private string _Email = string.Empty;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        //Website
        private string _Website = string.Empty;
        public string Website
        {
            get { return _Website; }
            set { _Website = value; }
        }

        //CheckUserId
        private int _CheckUserId = 0;
        public int CheckUserId
        {
            get { return _CheckUserId; }
            set { _CheckUserId = value; }
        }

        //Images
        private string _Images = string.Empty;
        public string Images
        {
            get { return _Images; }
            set { _Images = value; }
        }

        //Image
        private string _Image = string.Empty;
        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }

        //PremiumImage
        private string _PremiumImage = string.Empty;
        public string PremiumImage
        {
            get { return _PremiumImage; }
            set { _PremiumImage = value; }
        }

        //CreatedDate
        private DateTime? _CreatedDate = DateTime.UtcNow;
        public DateTime? CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        //UpdatedDate
        private DateTime? _UpdatedDate = DateTime.UtcNow;
        public DateTime? UpdatedDate
        {
            get { return _UpdatedDate; }
            set { _UpdatedDate = value; }
        }

        //CreatedBy
        private Int64? _CreatedBy = 0;
        public Int64? CreatedBy
        {
            get { return _CreatedBy ?? 0; }
            set { _CreatedBy = value; }
        }

        //Take
        private Int64 _Take = 0;
        public Int64 Take
        {
            get { return _Take; }
            set { _Take = value; }
        }

        //Index
        private Int64 _Index = 0;
        public Int64 Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        //CategoryId
        private Int64? _CategoryId = 0;
        public Int64? CategoryId
        {
            get { return _CategoryId ?? 0; }
            set { _CategoryId = value; }
        }

        //SubCategoryId
        private Int64? _SubCategoryId = 0;
        public Int64? SubCategoryId
        {
            get { return _SubCategoryId ?? 0; }
            set { _SubCategoryId = value; }
        }

        //UserId
        private Int64? _UserId = 0;
        public Int64? UserId
        {
            get { return _UserId ?? 0; }
            set { _UserId = value; }
        }

        //CategoryName
        private string _CategoryName = "";
        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }

        //SelectedCity
        private Int64? _SelectedCity = 0;
        public Int64? SelectedCity
        {
            get { return _SelectedCity; }
            set { _SelectedCity = value; }
        }

        //CityName
        private string _CityName = string.Empty;
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }

        //OrderBy
        private string _OrderBy = "Id";
        public string OrderBy
        {
            get { return _OrderBy; }
            set { _OrderBy = value; }
        }

        //SubCategoryName
        private string _SubCategoryName = "";
        public string SubCategoryName
        {
            get { return _SubCategoryName; }
            set { _SubCategoryName = value; }
        }

        //Keyword
        private string _Keyword = "";
        public string Keyword
        {
            get { return _Keyword; }
            set { _Keyword = value; }
        }

        //IsDeleted
        private bool _IsDeleted = false;
        public bool IsDeleted
        {
            get { return _IsDeleted; }
            set { _IsDeleted = value; }
        }

        //IsApprovedByAdmin
        private bool _IsApprovedByAdmin = false;
        public bool IsApprovedByAdmin
        {
            get { return _IsApprovedByAdmin; }
            set { _IsApprovedByAdmin = value; }
        }

        //Distance
        private double? _Distance = 0;
        public double? Distance
        {
            get { return _Distance; }
            set { _Distance = value; }
        }

        //DataRecieved
        private bool _DataRecieved = false;
        public bool DataRecieved
        {
            get { return _DataRecieved; }
            set { _DataRecieved = value; }
        }

        #endregion

        #region "Add Delete Update"
        public void Add()
        {
            tbl_Business obj = _db.tbl_Business.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_Business();
                SetObjects(obj);
                _db.tbl_Business.Add(obj);
                _db.SaveChanges();
                Id = obj.Id;
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_Business obj = _db.tbl_Business.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void Delete()
        {
            tbl_Business obj = _db.tbl_Business.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_Business.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void SetObjects(tbl_Business obj)
        {
            obj.Description = Description;
            obj.BusinessName = BusinessName;
            obj.CategoryId = CategoryId;
            obj.SubCategoryId = SubCategoryId;
            obj.Email = Email;
            obj.Website = Website;
            obj.ContactPerson = ContactPerson;
            obj.Address = Address;
            obj.Latitude = Latitude;
            obj.Longitude = Longitude;
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = CreatedBy;
            obj.PhoneNumber1 = PhoneNumber1;
            obj.PhoneNumber2 = PhoneNumber2;
            obj.IsDeleted = IsDeleted;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
            obj.SelectedCity = SelectedCity;
            obj.Message = Message;
            obj.Subscription = Subscription;
            obj.Image = Image;
            obj.UserId = UserId;
            obj.PremiumImage = PremiumImage;
        }
        #endregion

        #region "Get Method"

        public List<ClsBusiness> GetAll()
        {
            List<ClsBusiness> lst = new List<ClsBusiness>();
            try
            {
                lst = (from r in _db.fn_GetDistance_Business(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude), Convert.ToInt64(Id), IsDeleted, Convert.ToInt64(IsApproved), Convert.ToInt64(CategoryId), Convert.ToInt64(SubCategoryId), Convert.ToInt64(SelectedCity), Convert.ToInt64(Distance), BusinessName, Convert.ToInt64(Take), Convert.ToInt64(Index * Take), OrderBy, SubCategoryIds, Keyword, Convert.ToInt64(UserId), CheckUserId)

                       select new ClsBusiness
                       {
                           Id = r.Id,
                           Description = r.Description,
                           BusinessName = r.BusinessName,
                           CategoryId = r.CategoryId,
                           SubCategoryId = r.SubCategoryId,
                           Email = r.Email,
                           Website = r.Website,
                           ContactPerson = r.ContactPerson,
                           Address = r.Address,
                           Latitude = r.Latitude,
                           Longitude = r.Longitude,
                           CreatedDate = r.CreatedDate,
                           CityName = r.CityName,
                           SelectedCity = r.SelectedCity,
                           UpdatedDate = r.UpdatedDate,
                           CreatedBy = r.CreatedBy,
                           PhoneNumber1 = r.PhoneNumber1,
                           PhoneNumber2 = r.PhoneNumber2,
                           CategoryName = r.CategoryName,
                           Distance = r.Distance,
                           Subscription = r.Subscription,
                           Image = r.Image,
                           Message = r.Message,
                           UserId = r.UserId,
                           ButtonTitle = r.ButtonTitle,
                           UserMessage = r.UserMessage,
                           SubCategoryName = r.SubCategoryName,
                           PremiumImage = r.PremiumImage,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                           SNO = r.SNO,
                       }).ToList();


            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return lst;
        }

        public List<ClsPropBusiness> GetAllForAjax()
        {
            List<ClsPropBusiness> lst = new List<ClsPropBusiness>();
            try
            {
                lst = (from r in _db.fn_GetDistance_Business(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude), Convert.ToInt64(Id), IsDeleted,
                           Convert.ToInt64(IsApproved), Convert.ToInt64(CategoryId), Convert.ToInt64(SubCategoryId), Convert.ToInt64(SelectedCity),
                           Convert.ToInt64(Distance), BusinessName, Convert.ToInt64(Take), Convert.ToInt64(Index * Take), OrderBy, SubCategoryIds, Keyword,
                           Convert.ToInt64(UserId), CheckUserId)

                       select new ClsPropBusiness
                       {
                           Id = r.Id,
                           Description = r.Description,
                           BusinessName = r.BusinessName,
                           CategoryId = r.CategoryId,
                           SubCategoryId = r.SubCategoryId,
                           Email = r.Email,
                           Website = r.Website,
                           ContactPerson = r.ContactPerson,
                           Address = r.Address,
                           Latitude = r.Latitude,
                           Longitude = r.Longitude,
                           CreatedDate = r.CreatedDate,
                           CityName = r.CityName,
                           SelectedCity = r.SelectedCity,
                           UpdatedDate = r.UpdatedDate,
                           CreatedBy = r.CreatedBy,
                           PhoneNumber1 = r.PhoneNumber1,
                           PhoneNumber2 = r.PhoneNumber2,
                           CategoryName = r.CategoryName,
                           Distance = r.Distance,
                           Image = r.Image,
                           UserId = r.UserId,
                           SubCategoryName = r.SubCategoryName,
                           Subscription = r.Subscription,
                           ButtonTitle = r.ButtonTitle,
                           UserMessage = r.UserMessage,
                           Message = r.Message,
                           PremiumImage = r.PremiumImage,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                           SNO = r.SNO,
                       }).ToList();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return lst;
        }

        //public List<ClsPropBusiness> GetAllForAjax()
        //{
        //    List<ClsPropBusiness> lst = new List<ClsPropBusiness>();
        //    try
        //    {
        //        lst = (from r in _db.fn_GetDistance_Business(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude), Convert.ToInt64(Id), IsDeleted,
        //                   Convert.ToInt64(IsApproved), Convert.ToInt64(CategoryId), Convert.ToInt64(SubCategoryId), Convert.ToInt64(SelectedCity),
        //                   Convert.ToInt64(Distance), BusinessName, Convert.ToInt64(Take), Convert.ToInt64(Index * Take), OrderBy, SubCategoryIds, Keyword,
        //                   Convert.ToInt64(UserId), CheckUserId)

        //               select new ClsPropBusiness
        //               {
        //                   Id = r.Id,
        //                   Description = r.Description,
        //                   BusinessName = r.BusinessName,
        //                   CategoryId = r.CategoryId,
        //                   SubCategoryId = r.SubCategoryId,
        //                   Email = r.Email,
        //                   Website = r.Website,
        //                   ContactPerson = r.ContactPerson,
        //                   Address = r.Address,
        //                   Latitude = r.Latitude,
        //                   Longitude = r.Longitude,
        //                   CreatedDate = r.CreatedDate,
        //                   CityName = r.CityName,
        //                   SelectedCity = r.SelectedCity,
        //                   UpdatedDate = r.UpdatedDate,
        //                   CreatedBy = r.CreatedBy,
        //                   PhoneNumber1 = r.PhoneNumber1,
        //                   PhoneNumber2 = r.PhoneNumber2,
        //                   CategoryName = r.CategoryName,
        //                   Distance = r.Distance,
        //                   Image = r.Image,
        //                   UserId = r.UserId,
        //                   SubCategoryName = r.SubCategoryName,
        //                   Subscription = r.Subscription,
        //                   ButtonTitle = r.ButtonTitle,
        //                   UserMessage = r.UserMessage,
        //                   Message = r.Message,
        //                   PremiumImage = r.PremiumImage,
        //                   IsDeleted = r.IsDeleted == true ? true : false,
        //                   IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
        //                   SNO = r.SNO,
        //               }).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        string error = ex.Message;
        //    }

        //    return lst;
        //}


        public List<ListingByDistance> GetBusinessListingByDistance(string latitude, string longitude, long cityID, decimal distance, long pageSize, long userID)
        {

            string Type = "Business";
            int pageIndex = 0;
            var lst = (from r in _db.sp_GetBusinessListingByDistance(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude), 0, false,
                        1, 0, 0, cityID,
                        Convert.ToInt64(distance), "", Convert.ToInt64(pageSize), Convert.ToInt64(pageIndex * pageSize), "Id", "", "",
                        Convert.ToInt64(userID), 0)

                       select new ListingByDistance
                       {
                           CategoryID = r.CategoryId.GetValueOrDefault(),
                           ListingID = r.Id,
                           Image = r.Image,
                            Description = r.Description,
                           Title = r.BusinessName,
                           Type = Type,
                           Latitude = r.Latitude,
                           Longitude = r.Longitude,
                           Distance = r.Distance,

                       }).ToList();



            return lst;
        }
        public List<ListingByDistance> GetCouponListingByDistance(string latitude, string longitude, long cityID, decimal distance, long pageSize, long userID)
        {

            string Type = "Coupon";
            int pageIndex = 0;
            var lst = (from r in _db.sp_GetCouponListingByDistance(Convert.ToDouble(latitude), Convert.ToDouble(longitude), 0, false,
                        1, 0, 0, cityID, 0,
                        Convert.ToInt64(distance), "", Convert.ToInt64(pageSize), Convert.ToInt64(pageIndex * pageSize), "Id", "", "")


                       select new ListingByDistance
                       {
                           CategoryID = r.CategoryId.GetValueOrDefault(),
                           ListingID = r.Id,
                           Image = r.Image,
                           Description = r.CouponMessage,
                           Title = r.BusinessName,
                           Type = Type,
                           Latitude = r.Latitude,
                           Longitude = r.Longitude,
                           Distance = r.Distance,

                       }).ToList();



            return lst;
        }
        public List<ClsCoupons> GetCouponListingByDistanceWithMoreResponseData(string latitude, string longitude, long cityID, decimal distance, long pageSize, long userID)
        {

            string Type = "Coupon";
            int pageIndex = 0;
            var lst = (from r in _db.sp_GetCouponListingByDistance(Convert.ToDouble(latitude), Convert.ToDouble(longitude), 0, false,
                        1, 0, 0, cityID, 0,
                        Convert.ToInt64(distance), "", Convert.ToInt64(pageSize), Convert.ToInt64(pageIndex * pageSize), "Id", "", "")


                       select new ClsCoupons
                       {
                           Id = r.Id,
                           Title = r.Title,
                           BusinessName = r.BusinessName,
                           CategoryId = r.CategoryId,
                           SubCategoryId = r.SubCategoryId,
                           ActualPrice = r.ActualPrice,
                           SalePrice = r.SalePrice,
                           PayToMerchant = r.PayToMerchant,
                           CouponPrice = r.CouponPrice,
                           Address = r.Address,
                           Latitude = r.Latitude,
                           Longitude = r.Longitude,
                           OfferDetails = r.OfferDetails,
                           TermsAndCondition = r.TermsAndCondition,
                           SelectedCity = r.SelectedCity,
                           SelectedPosition = r.SelectedPosition,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           CreatedBy = r.CreatedBy,
                           Images = r.Image,
                           PhoneNumber = r.PhoneNumber,
                           CategoryName = r.CategoryName,
                           CityName = r.CityName,
                           Distance = r.Distance,
                           SubCategoryName = r.SubCategoryName,
                           UniqueId = r.UniqueId,
                           CouponMessage = r.CouponMessage,
                           Quantity = r.Quantity,
                           IsAsPerBill = r.IsAsPerBill,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                           SNO = r.SNO,
                       }).ToList();




            return lst;
        }
        public List<ListingByDistance> GetProductListingByDistance(string latitude, string longitude, long cityID, decimal distance, long pageSize, long userID)
        {

            string Type = "Business";
            int pageIndex = 0;
            var lst = (from r in _db.sp_GetProductListingByDistance(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude), 0, false,
                        1, 0, 0, cityID, 0,
                        Convert.ToInt64(Distance), "", Convert.ToInt64(pageSize), Convert.ToInt64(pageIndex * pageSize), "Id", "", "")


                       select new ListingByDistance
                       {
                           Description = r.Description,

                           Type = Type,
                           Latitude = r.Latitude,
                           Longitude = r.Longitude,
                           Distance = r.Distance,

                       }).ToList();



            return lst;
        }
        public List<ClsCoupons> GetCouponListingByDistanceWithMulitPolygon(string str_MultiPolygon)
        {
            
            var lst = (from r in _db.sp_GetCouponListingByMultiPolygon(str_MultiPolygon)
                       select new ClsCoupons
                       {
                           Id = r.Id,
                           Title = r.Title,
                           BusinessName = r.BusinessName,
                           CategoryId = r.CategoryId,
                           SubCategoryId = r.SubCategoryId,
                           ActualPrice = r.ActualPrice,
                           SalePrice = r.SalePrice,
                           PayToMerchant = r.PayToMerchant,
                           CouponPrice = r.CouponPrice,
                           Address = r.Address,
                           Latitude = r.Latitude,
                           Longitude = r.Longitude,
                           OfferDetails = r.OfferDetails,
                           TermsAndCondition = r.TermsAndCondition,
                           SelectedCity = r.SelectedCity,
                           SelectedPosition = r.SelectedPosition,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           CreatedBy = r.CreatedBy,
                           Images = r.Image,
                           PhoneNumber = r.PhoneNumber,
                           CategoryName = r.CategoryName,
                           CityName = r.CityName,
                          // Distance = r.Distance,
                           SubCategoryName = r.SubCategoryName,
                           UniqueId = r.UniqueId,
                           CouponMessage = r.CouponMessage,
                           Quantity = r.Quantity,
                           IsAsPerBill = r.IsAsPerBill,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                           SNO = r.SNO,
                       }).ToList();




            return lst;
        }
        public void GetRecord()
        {
            tbl_Business obj = _db.tbl_Business.FirstOrDefault(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (CategoryId != 0 ? r.CategoryId == CategoryId : CategoryId == 0) &&
                   (CheckUserId != 0 ? r.UserId != 0 : CheckUserId == 0) &&
                   (SelectedCity != 0 ? r.SelectedCity == SelectedCity : SelectedCity == 0) &&
                   (SubCategoryId != 0 ? r.SubCategoryId == SubCategoryId : SubCategoryId == 0) &&
                   (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                   (!string.IsNullOrEmpty(BusinessName) ? r.BusinessName.ToLower() == BusinessName.ToLower() : string.IsNullOrEmpty(BusinessName)));
            if (obj != null)
            {
                Id = obj.Id;
                Description = obj.Description;
                BusinessName = obj.BusinessName;
                CategoryId = obj.CategoryId;
                SubCategoryId = obj.SubCategoryId;
                Email = obj.Email;
                Website = obj.Website;
                ContactPerson = obj.ContactPerson;
                Address = obj.Address;
                Latitude = obj.Latitude;
                Longitude = obj.Longitude;
                CreatedDate = obj.CreatedDate;
                UpdatedDate = obj.UpdatedDate;
                CreatedBy = obj.CreatedBy;
                UserId = obj.UserId;
                PhoneNumber1 = obj.PhoneNumber1;
                CityName = obj.tbl_Cities.CityName;
                SelectedCity = obj.SelectedCity;
                PhoneNumber2 = obj.PhoneNumber2;
                CategoryName = obj.tbl_Category.Name;
                UserMessage = obj.tbl_Category.UserMessage;
                ButtonTitle = obj.tbl_Category.ButtonTitle;
                SubCategoryName = obj.tbl_SubCategory.Name;
                Subscription = obj.Subscription;
                Message = obj.Message;
                Image = obj.Image;
                IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                PremiumImage = obj.PremiumImage;
                DataRecieved = true;
            }
        }
        #endregion

        #region "TotalRecords"
        public Int64 GetTotalRecords()
        {
            Int64 Records = 0;
            Records = _db.tbl_Business.Count(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (CategoryId != 0 ? r.CategoryId == CategoryId : CategoryId == 0) &&
                   (CheckUserId != 0 ? r.UserId != 0 : CheckUserId == 0) &&
                   (SelectedCity != 0 ? r.SelectedCity == SelectedCity : SelectedCity == 0) &&
                   (SubCategoryId != 0 ? r.SubCategoryId == SubCategoryId : SubCategoryId == 0) &&
                   (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                   (!string.IsNullOrEmpty(BusinessName) ? r.BusinessName.ToLower() == BusinessName.ToLower() : string.IsNullOrEmpty(BusinessName)));
            return Records;
        }
        #endregion

    }
    public class ListingByDistance
    {
        public string Image { get; set; }
        public long ListingID { get; set; }
        public long CategoryID { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public double Distance { get; set; }
        public string Description { get; set; }
    }

}
