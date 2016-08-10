using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class ClsCoupons : EntityContext
    {
        #region "Enums"
        public enum BooleanValues
        {
            Both = 2,
            Approved = 1,
            Disapproved = 0
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

        //Title
        private string _Title = string.Empty;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        //CityName
        private string _CityName = string.Empty;
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }


        //CouponMessage
        private string _CouponMessage = string.Empty;
        public string CouponMessage
        {
            get { return _CouponMessage; }
            set { _CouponMessage = value; }
        }

        //UniqueId
        private string _UniqueId = string.Empty;
        public string UniqueId
        {
            get { return _UniqueId; }
            set { _UniqueId = value; }
        }

        //Quantity
        private Int64? _Quantity = 0;
        public Int64? Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }


        //BusinessName
        private string _BusinessName = string.Empty;
        public string BusinessName
        {
            get { return _BusinessName; }
            set { _BusinessName = value; }
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

        //Distance
        private double? _Distance = 0;
        public double? Distance
        {
            get { return _Distance; }
            set { _Distance = value; }
        }

        //ActualPrice
        private decimal? _ActualPrice = 0;
        public decimal? ActualPrice
        {
            get { return _ActualPrice; }
            set { _ActualPrice = value; }
        }

        //SalePrice
        private decimal? _SalePrice = 0;
        public decimal? SalePrice
        {
            get { return _SalePrice; }
            set { _SalePrice = value; }
        }

        //PayToMerchant
        private decimal? _PayToMerchant = 0;
        public decimal? PayToMerchant
        {
            get { return _PayToMerchant; }
            set { _PayToMerchant = value; }
        }

        //CouponPrice
        private decimal? _CouponPrice = 0;
        public decimal? CouponPrice
        {
            get { return _CouponPrice; }
            set { _CouponPrice = value; }
        }

        //PhoneNumber
        private string _PhoneNumber = string.Empty;
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }

        //Images
        private string _Images = string.Empty;
        public string Images
        {
            get { return _Images; }
            set { _Images = value; }
        }

        //OfferDetails
        private string _OfferDetails = string.Empty;
        public string OfferDetails
        {
            get { return _OfferDetails; }
            set { _OfferDetails = value; }
        }

        //TermsAndCondition
        private string _TermsAndCondition = string.Empty;
        public string TermsAndCondition
        {
            get { return _TermsAndCondition; }
            set { _TermsAndCondition = value; }
        }

        //CategoryIds
        private string _CategoryIds = string.Empty;
        public string CategoryIds
        {
            get { return _CategoryIds; }
            set { _CategoryIds = value; }
        }

        //Keyword
        private string _Keyword = string.Empty;
        public string Keyword
        {
            get { return _Keyword; }
            set { _Keyword = value; }
        }


        //SelectedPosition
        private Int64? _SelectedPosition = 0;
        public Int64? SelectedPosition
        {
            get { return _SelectedPosition; }
            set { _SelectedPosition = value; }
        }

        //IsApproved
        private Int64 _IsApproved = (int)BooleanValues.Both;
        public Int64 IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }

        //SelectedCity
        private Int64? _SelectedCity = 0;
        public Int64? SelectedCity
        {
            get { return _SelectedCity; }
            set { _SelectedCity = value; }
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

        //CategoryName
        private string _CategoryName = "";
        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }

        //SubCategoryName
        private string _SubCategoryName = "";
        public string SubCategoryName
        {
            get { return _SubCategoryName; }
            set { _SubCategoryName = value; }
        }

        //OrderBy
        private string _OrderBy = "Id";
        public string OrderBy
        {
            get { return _OrderBy; }
            set { _OrderBy = value; }
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

        //IsAsPerBill
        private bool _IsAsPerBill = false;
        public bool IsAsPerBill
        {
            get { return _IsAsPerBill; }
            set { _IsAsPerBill = value; }
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
            tbl_Coupons obj = _db.tbl_Coupons.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_Coupons();
                SetObjects(obj);
                _db.tbl_Coupons.Add(obj);
                _db.SaveChanges();
                Id = obj.Id;
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_Coupons obj = _db.tbl_Coupons.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void Delete()
        {
            tbl_Coupons obj = _db.tbl_Coupons.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_Coupons.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void SetObjects(tbl_Coupons obj)
        {
            obj.Title = Title;
            obj.BusinessName = BusinessName;
            obj.CategoryId = CategoryId;
            obj.SubCategoryId = SubCategoryId;
            obj.ActualPrice = ActualPrice;
            obj.SalePrice = SalePrice;
            obj.PayToMerchant = PayToMerchant;
            obj.CouponPrice = CouponPrice;
            obj.Address = Address;
            obj.Latitude = Latitude;
            obj.Longitude = Longitude;
            obj.OfferDetails = OfferDetails;
            obj.TermsAndCondition = TermsAndCondition;
            obj.SelectedCity = SelectedCity;
            obj.SelectedPosition = SelectedPosition;
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = CreatedBy;
            obj.PhoneNumber = PhoneNumber;
            obj.IsDeleted = IsDeleted;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
            obj.UniqueId = UniqueId;
            obj.CouponMessage = CouponMessage;
            obj.Quantity = Quantity;
            obj.IsAsPerBill = IsAsPerBill;
        }
        #endregion

        #region "Get Method"

        public List<ClsCoupons> GetRelatedCoupons(long? couponCategory)
        { 
            List<ClsCoupons> lst = new List<ClsCoupons>();
            lst=(from r in _db.tbl_Coupons
                where r.CategoryId==couponCategory&&r.IsApprovedByAdmin==true&&r.IsDeleted==false

                let image=_db.tbl_CouponImages.FirstOrDefault(a=>a.CouponId==r.Id) 
                select new ClsCoupons
                       {
                           Id = r.Id,
                           Title = r.Title,
                           BusinessName = r.BusinessName,
                           //CategoryId = r.CategoryId,
                           //SubCategoryId = r.SubCategoryId,
                           ActualPrice = r.ActualPrice,
                           SalePrice = r.SalePrice,
                           PayToMerchant = r.PayToMerchant,
                           CouponPrice = r.CouponPrice,
                          // Address = r.Address,
                           //Latitude = r.Latitude,
                           //Longitude = r.Longitude,
                           //OfferDetails = r.OfferDetails,
                           //TermsAndCondition = r.TermsAndCondition,
                           //SelectedCity = r.SelectedCity,
                           //SelectedPosition = r.SelectedPosition,
                           //CreatedDate = r.CreatedDate,
                           //UpdatedDate = r.UpdatedDate,
                           //CreatedBy = r.CreatedBy,
                           Images = image.Image,
                           //PhoneNumber = r.PhoneNumber,
                           //CategoryName = r.CategoryName,
                           //CityName = r.CityName,
                           //Distance = r.Distance,
                           //SubCategoryName = r.SubCategoryName,
                           UniqueId = r.UniqueId,
                          // CouponMessage = r.CouponMessage,
                           //Quantity = r.Quantity,
                           //IsAsPerBill = r.IsAsPerBill,
                          // IsDeleted = r.IsDeleted == true ? true : false,
                         //  IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                           //SNO = r.SNO,
                       }).OrderBy(x => Guid.NewGuid()).Take(4).ToList();
            return lst;

        }

        public List<ClsCoupons> GetAll()
        {
            List<ClsCoupons> lst = new List<ClsCoupons>();
            try
            {

                lst = (from r in _db.fn_GetDistance_Coupons(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude),
                           Convert.ToInt64(Id), IsDeleted,
                           Convert.ToInt64(IsApproved), Convert.ToInt64(CategoryId), Convert.ToInt64(SubCategoryId),
                           Convert.ToInt64(SelectedCity), Convert.ToInt64(SelectedPosition), Convert.ToInt64(Distance),
                           Title, Convert.ToInt64(Take), Convert.ToInt64(Index * Take), OrderBy, CategoryIds, Keyword)

                       //let image=_db.tbl_CouponImages.FirstOrDefault(a=>a.CouponId==r.Id)
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


            }
            catch (Exception ex)
            {
                string aa = ex.Message;
            }
            return lst;
        }

        public List<ClsPropCoupons> GetAllForAjax()
        {
            List<ClsPropCoupons> lst = new List<ClsPropCoupons>();
            try
            {

                lst = (from r in _db.fn_GetDistance_Coupons(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude), Convert.ToInt64(Id), IsDeleted, Convert.ToInt64(IsApproved), Convert.ToInt64(CategoryId), Convert.ToInt64(SubCategoryId), Convert.ToInt64(SelectedCity), Convert.ToInt64(SelectedPosition), Convert.ToInt64(Distance), Title, Convert.ToInt64(Take), Convert.ToInt64(Index * Take), OrderBy, CategoryIds, Keyword)

                       select new ClsPropCoupons
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
                           PhoneNumber = r.PhoneNumber,
                           CategoryName = r.CategoryName,
                           CityName = r.CityName,
                           Distance = r.Distance,
                           UniqueId = r.UniqueId,
                           Images = r.Image,
                           CouponMessage = r.CouponMessage,
                           IsAsPerBill = r.IsAsPerBill,
                           Quantity = r.Quantity,
                           SubCategoryName = r.SubCategoryName,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                           SNO = r.SNO,
                       }).ToList();
            }
            catch (Exception ex)
            {
                string aa = ex.Message;
            }
            return lst;
        }

        public void GetRecord()
        {
            tbl_Coupons obj = _db.tbl_Coupons.FirstOrDefault(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                       (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                    (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (CategoryId != 0 ? r.CategoryId == CategoryId : CategoryId == 0) &&
                       (SubCategoryId != 0 ? r.SubCategoryId == SubCategoryId : SubCategoryId == 0) &&
                       (!string.IsNullOrEmpty(Title) ? r.Title.ToLower() == Title.ToLower() : string.IsNullOrEmpty(Title)));
            if (obj != null)
            {
                Id = obj.Id;
                Title = obj.Title;
                BusinessName = obj.BusinessName;
                CategoryId = obj.CategoryId;
                SubCategoryId = obj.SubCategoryId;
                ActualPrice = obj.ActualPrice;
                SalePrice = obj.SalePrice;
                PayToMerchant = obj.PayToMerchant;
                CouponPrice = obj.CouponPrice;
                Address = obj.Address;
                Latitude = obj.Latitude;
                Longitude = obj.Longitude;
                OfferDetails = obj.OfferDetails;
                TermsAndCondition = obj.TermsAndCondition;
                SelectedCity = obj.SelectedCity;
                SelectedPosition = obj.SelectedPosition;
                CreatedDate = obj.CreatedDate;
                UpdatedDate = obj.UpdatedDate;
                CreatedBy = obj.CreatedBy;
                PhoneNumber = obj.PhoneNumber;
                UniqueId = obj.UniqueId;
                CouponMessage = obj.CouponMessage;
                Quantity = obj.Quantity;
                CategoryName = obj.tbl_Category.Name;
                SubCategoryName = obj.tbl_SubCategory.Name;
                CityName = obj.tbl_Cities.CityName;
                IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                IsAsPerBill = Convert.ToBoolean(obj.IsAsPerBill);
                DataRecieved = true;
            }
        }

        public void CheckPosition()
        {
            tbl_Coupons obj = _db.tbl_Coupons.FirstOrDefault(a => a.SelectedPosition == SelectedPosition && a.SelectedCity == SelectedCity);
            if (obj != null)
            {
                obj.SelectedPosition = 0;
                _db.SaveChanges();
            }
        }

        #endregion

        #region"DropDowns"
        public List<tbl_Cities> GetAllCities()
        {
            List<tbl_Cities> lst = new List<tbl_Cities>();
            lst = (from r in _db.tbl_Cities
                   where ((Id != 0 ? r.Id == Id : Id == 0))

                   select r).ToList();
            return lst;
        }

        #endregion

        #region "TotalRecords"
        public Int64 GetTotalRecords()
        {
            Int64 Records = 0;
            Records = _db.tbl_Coupons.Count(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                       (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                       (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (CategoryId != 0 ? r.CategoryId == CategoryId : CategoryId == 0) &&
                       (SubCategoryId != 0 ? r.SubCategoryId == SubCategoryId : SubCategoryId == 0) &&
                       (!string.IsNullOrEmpty(Title) ? r.Title.ToLower() == Title.ToLower() : string.IsNullOrEmpty(Title)));
            return Records;
        }
        #endregion
    }
}
