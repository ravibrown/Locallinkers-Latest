using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class ClsProducts:EntityContext
    {
        #region "Enums"
        public enum BooleanValues
        {
            Both=2,
            Approved=1,
            Disapproved=0
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
            get { return _SNO??0; }
            set { _SNO = value; }
        }

        //Title
        private string _Title = string.Empty;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
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

        //CityName
        private string _CityName = string.Empty;
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }


        //Description
        private string _Description = string.Empty;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        //ShortDescription
        private string _ShortDescription = string.Empty;
        public string ShortDescription
        {
            get { return _ShortDescription; }
            set { _ShortDescription = value; }
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


        //Images
        private List<ClsPropProductImages> _Images = null;
        public List<ClsPropProductImages> Images
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



        //SelectedPosition
        private Int64? _SelectedPosition = 0;
        public Int64? SelectedPosition
        {
            get { return _SelectedPosition; }
            set { _SelectedPosition = value; }
        }

        //Stock
        private Int64? _Stock = 0;
        public Int64? Stock
        {
            get { return _Stock; }
            set { _Stock = value; }
        }

        //Distance
        private double? _Distance = 0;
        public double? Distance
        {
            get { return _Distance; }
            set { _Distance = value; }
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
        private Int64 _Take= 0;
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
            tbl_Products obj = _db.tbl_Products.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_Products();
                SetObjects(obj);
                _db.tbl_Products.Add(obj);
                _db.SaveChanges();
                Id = obj.Id;
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_Products obj = _db.tbl_Products.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void Delete()
        {
            tbl_Products obj = _db.tbl_Products.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_Products.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void SetObjects(tbl_Products obj)
        {
            obj.Title = Title;
            obj.Description = Description;
            obj.CategoryId = CategoryId;
            obj.SubCategoryId = SubCategoryId;
            obj.ActualPrice = ActualPrice;
            obj.SalePrice = SalePrice;
            obj.Address = Address;
            obj.Latitude = Latitude;
            obj.Longitude = Longitude;
            obj.SelectedCity = SelectedCity;
            obj.SelectedPosition = SelectedPosition;
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = CreatedBy;
            obj.Stock = Stock;
            obj.IsDeleted = IsDeleted;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
            obj.ShortDescription = ShortDescription;
        }
        #endregion

        #region "Get Method"

        public List<ClsProducts> GetAll()
        {
            List<ClsProducts> lst = new List<ClsProducts>();
                lst = (from r in _db.fn_GetDistance_Products(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude), Convert.ToInt64(Id), IsDeleted, Convert.ToInt64(IsApproved), Convert.ToInt64(CategoryId), Convert.ToInt64(SubCategoryId), Convert.ToInt64(SelectedCity), Convert.ToInt64(SelectedPosition), Convert.ToInt64(Distance), Title, Convert.ToInt64(Take), Convert.ToInt64(Index * Take), OrderBy,CategoryIds,Keyword)                       
                       select new ClsProducts
                       {
                           Id = r.Id,
                           Title = r.Title,
                           Description = r.Description,
                           CategoryId = r.CategoryId,
                           SubCategoryId = r.SubCategoryId,
                           ActualPrice = r.ActualPrice,
                           SalePrice = r.SalePrice,
                           Distance = r.Distance,
                           Address = r.Address,
                           Latitude = r.Latitude,
                           Longitude = r.Longitude,
                           Stock = r.Stock,
                           SelectedCity = r.SelectedCity,
                           SelectedPosition = r.SelectedPosition,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           CreatedBy = r.CreatedBy,
                           Image = r.Image,
                           ShortDescription = r.ShortDescription,
                           CategoryName = r.CategoryName,
                           CityName = r.CityName,
                           SubCategoryName = r.SubCategoryName,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                           SNO=r.SNO,
                       }).ToList();
            

            return lst;
        }

        public List<ClsPropProducts> GetAllForAjax()
        {
            List<ClsPropProducts> lst = new List<ClsPropProducts>();
            lst = (from r in _db.fn_GetDistance_Products(Convert.ToDouble(Latitude), Convert.ToDouble(Longitude), Convert.ToInt64(Id), IsDeleted, Convert.ToInt64(IsApproved), Convert.ToInt64(CategoryId), Convert.ToInt64(SubCategoryId), Convert.ToInt64(SelectedCity), Convert.ToInt64(SelectedPosition), Convert.ToInt64(Distance), Title, Convert.ToInt64(Take), Convert.ToInt64(Index * Take), OrderBy, CategoryIds, Keyword)
                      let image = (from a in _db.tbl_ProductImages
                                    where (a.ProductId == r.Id)
                                    select new ClsPropProductImages
                                    {
                                        Id = a.Id,
                                        ProductId = a.ProductId,
                                        Image = a.Image,
                                        CreatedBy = a.CreatedBy,
                                        CreatedDate = a.CreatedDate,
                                        UpdatedDate = a.UpdatedDate,
                                        IsDeleted = a.IsDeleted == true ? true : false,
                                        IsApprovedByAdmin = a.IsApprovedByAdmin == true ? true : false,
                                    }).ToList()
                       let images = image.Select((l, index) => new ClsPropProductImages
                       {
                           Id = l.Id,
                           ProductId = l.ProductId,
                           Image = l.Image,
                           CreatedBy = l.CreatedBy,
                           CreatedDate = l.CreatedDate,
                           UpdatedDate = l.UpdatedDate,
                           IsDeleted = l.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = l.IsApprovedByAdmin == true ? true : false,
                           SNO = index + 1
                       }).ToList()
                       select new ClsPropProducts
                       {
                           Id = r.Id,
                           Title = r.Title,
                           Description = r.Description,
                           CategoryId = r.CategoryId,
                           SubCategoryId = r.SubCategoryId,
                           ActualPrice = r.ActualPrice,
                           SalePrice = r.SalePrice,
                           Address = r.Address,
                           Latitude = r.Latitude,
                           Longitude = r.Longitude,
                           Distance=r.Distance,
                           Stock = r.Stock,
                           SelectedCity = r.SelectedCity,
                           SelectedPosition = r.SelectedPosition,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           CreatedBy = r.CreatedBy,
                           Images = images,
                           Image=r.Image,
                           ShortDescription = r.ShortDescription,
                           CategoryName = r.CategoryName,
                           CityName = r.CityName,
                           SubCategoryName = r.SubCategoryName,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                           SNO=r.SNO,
                       }).ToList();
           

            return lst;
        }

        public void GetRecord()
        {
            tbl_Products obj = _db.tbl_Products.FirstOrDefault(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                       (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                       (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (CategoryId != 0 ? r.CategoryId == CategoryId : CategoryId == 0) &&
                       (SubCategoryId != 0 ? r.SubCategoryId == SubCategoryId : SubCategoryId == 0) &&
                       (!string.IsNullOrEmpty(Title) ? r.Title.ToLower() == Title.ToLower() : string.IsNullOrEmpty(Title)));
            if (obj != null)
            {
                Id = obj.Id;
                Title = obj.Title;
                Description = obj.Description;
                CategoryId = obj.CategoryId;
                SubCategoryId = obj.SubCategoryId;
                ActualPrice = obj.ActualPrice;
                SalePrice = obj.SalePrice;
                Address = obj.Address;
                Latitude = obj.Latitude;
                ShortDescription = obj.ShortDescription;
                Longitude = obj.Longitude;
                SelectedCity = obj.SelectedCity;
                SelectedPosition = obj.SelectedPosition;
                CreatedDate = obj.CreatedDate;
                UpdatedDate = obj.UpdatedDate;
                CreatedBy = obj.CreatedBy;
                Stock = obj.Stock;
                CategoryName = obj.tbl_Category.Name;
                SubCategoryName = obj.tbl_SubCategory.Name;
                CityName = obj.tbl_Cities.CityName;
                IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                DataRecieved = true;
            }
        }

        public void CheckPosition()
        {
            tbl_Products obj = _db.tbl_Products.FirstOrDefault(a => a.SelectedPosition == SelectedPosition);
            if(obj!=null)
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
            Records = _db.tbl_Products.Count(r => (Id != 0 ? r.Id == Id : Id == 0) &&
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
