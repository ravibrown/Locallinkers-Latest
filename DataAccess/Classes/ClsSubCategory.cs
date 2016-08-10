using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class ClsSubCategory:EntityContext
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
        private Int64 _SNO = 0;
        public Int64 SNO
        {
            get { return _SNO; }
            set { _SNO = value; }
        }

        //IsApproved
        private Int64 _IsApproved = (int)BooleanValues.Both;
        public Int64 IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }

        //CategoryId
        private Int64? _CategoryId = 0;
        public Int64? CategoryId
        {
            get { return _CategoryId??0; }
            set { _CategoryId = value; }
        }

        //Name
        private string _Name = string.Empty;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        //CategoryName
        private string _CategoryName = string.Empty;
        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
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

        //Image
        private string _Image = string.Empty;
        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
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

        //DataRecieved
        private bool _DataRecieved = false;
        public bool DataRecieved
        {
            get { return _DataRecieved; }
            set { _DataRecieved = value; }
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
        #endregion

        #region "Add Delete Update"
        public void Add()
        {
            tbl_SubCategory obj = _db.tbl_SubCategory.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_SubCategory();
                SetObjects(obj);
                _db.tbl_SubCategory.Add(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_SubCategory obj = _db.tbl_SubCategory.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void Delete()
        {
            tbl_SubCategory obj = _db.tbl_SubCategory.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_SubCategory.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void SetObjects(tbl_SubCategory obj)
        {
            obj.CategoryId = CategoryId;
            obj.Name = Name;
            obj.Description = Description;
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = CreatedBy;
            obj.Image = Image;
            obj.IsDeleted = IsDeleted;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
        }
        #endregion

        #region "Get Method"

        public List<ClsSubCategory> GetSubcategoriesWithData(string type)
        {
            List<ClsSubCategory> lst = new List<ClsSubCategory>();
            var query = (from r in _db.tbl_SubCategory
                   where ((Id != 0 ? r.Id == Id : Id == 0) &&
                   (CategoryId != 0 ? r.CategoryId == CategoryId : CategoryId == 0) &&
                      (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                      (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                   (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name))
                   
                   )
                         select new ClsSubCategory
                         {
                             Id = r.Id,
                             Name = r.Name,
                             CategoryId = r.CategoryId,
                             CategoryName = r.tbl_Category.Name,
                             Description = r.Description,
                             Image = r.Image,
                             UpdatedDate = r.UpdatedDate,
                             UserMessage = UserMessage,
                             ButtonTitle = ButtonTitle,

                         });
                   if(type.ToLower().Trim()=="coupons")
                   {
                       query = from p in query
                               where (_db.tbl_Coupons.Count(a => a.SubCategoryId == p.Id&&a.IsApprovedByAdmin==true&&IsDeleted==false) > 0)
                               select p;
                   }
                   else if(type.ToLower().Trim()=="business")
                   {
                       query = from p in query
                               where (_db.tbl_Business.Count(a => a.SubCategoryId == p.Id && a.IsApprovedByAdmin == true && IsDeleted == false) > 0)
                               select p;
                   }
                   lst = query.ToList(); 
            lst = lst.Select((r, index) => new ClsSubCategory
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Image = r.Image,
                CategoryId = r.CategoryId,
                CategoryName = r.CategoryName,
                UserMessage = r.UserMessage,
                ButtonTitle = r.ButtonTitle,
               
                SNO = index + 1
            }).ToList();
            return lst;
        }
        public List<ClsSubCategory> GetAll()
        {
            List<ClsSubCategory> lst = new List<ClsSubCategory>();
            lst = (from r in _db.tbl_SubCategory
                   where ((Id != 0 ? r.Id == Id : Id == 0) &&
                   (CategoryId != 0 ? r.CategoryId == CategoryId : CategoryId == 0) &&
                      (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                      (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                   (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))
                   select new ClsSubCategory
                   {
                       Id = r.Id,
                       Name = r.Name,
                       CategoryId = r.CategoryId,
                       CategoryName = r.tbl_Category.Name,
                       Description = r.Description,
                       Image = r.Image,
                       CreatedBy = r.CreatedBy,
                       CreatedDate = r.CreatedDate,
                       UpdatedDate = r.UpdatedDate,
                       UserMessage=UserMessage,
                       ButtonTitle=ButtonTitle,
                       IsDeleted = r.IsDeleted == true ? true : false,
                       IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                   }).ToList();
            lst = lst.Select((r, index) => new ClsSubCategory
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Image = r.Image,
                CreatedBy = r.CreatedBy,
                CreatedDate = r.CreatedDate,
                UpdatedDate = r.UpdatedDate,
                CategoryId = r.CategoryId,
                CategoryName = r.CategoryName,
                UserMessage = r.UserMessage,
                ButtonTitle = r.ButtonTitle,
                IsDeleted = r.IsDeleted == true ? true : false,
                IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                SNO = index + 1
            }).ToList();
            return lst;
        }

        public List<ClsPropSubCategory> GetAllForAjax()
        {
            List<ClsPropSubCategory> lst = new List<ClsPropSubCategory>();
            lst = (from r in _db.tbl_SubCategory
                   where ((Id != 0 ? r.Id == Id : Id == 0) &&
                   (CategoryId != 0 ? r.CategoryId == CategoryId : CategoryId == 0) &&
                      (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                      (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                   (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))
                   select new ClsPropSubCategory
                   {
                       Id = r.Id,
                       Name = r.Name,
                       CategoryId = r.CategoryId,
                       CategoryName = r.tbl_Category.Name,
                       Description = r.Description,
                       Image = r.Image,
                       CreatedBy = r.CreatedBy,
                       CreatedDate = r.CreatedDate,
                       UpdatedDate = r.UpdatedDate,
                       UserMessage = UserMessage,
                       ButtonTitle = ButtonTitle,
                       IsDeleted = r.IsDeleted == true ? true : false,
                       IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                   }).ToList();
            lst = lst.Select((r, index) => new ClsPropSubCategory
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Image = r.Image,
                CreatedBy = r.CreatedBy,
                CreatedDate = r.CreatedDate,
                UpdatedDate = r.UpdatedDate,
                CategoryId = r.CategoryId,
                CategoryName = r.CategoryName,
                UserMessage = r.UserMessage,
                ButtonTitle = r.ButtonTitle,
                IsDeleted = r.IsDeleted == true ? true : false,
                IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                SNO = index + 1
            }).ToList();
            return lst;
        }

        public List<ClsPropSubCategory> GetAllForAjaxWithJoin()
        {
            List<ClsPropSubCategory> lst = new List<ClsPropSubCategory>();
            lst = (from r in _db.tbl_SubCategory
                   join a in _db.tbl_Business on r.Id equals a.SubCategoryId
                   where ((Id != 0 ? r.Id == Id : Id == 0) &&
                   (CategoryId != 0 ? r.CategoryId == CategoryId : CategoryId == 0) &&
                      (IsDeleted ? (r.IsDeleted == true && a.IsDeleted == true) : (r.IsDeleted == false && a.IsDeleted == false)) &&
                      (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                   (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))
                   select new ClsPropSubCategory
                   {
                       Id = r.Id,
                       Name = r.Name,
                       CategoryId = r.CategoryId,
                       CategoryName = r.tbl_Category.Name,
                       Description = r.Description,
                       Image = r.Image,
                       CreatedBy = r.CreatedBy,
                       CreatedDate = r.CreatedDate,
                       UpdatedDate = r.UpdatedDate,
                       UserMessage = UserMessage,
                       ButtonTitle = ButtonTitle,
                       IsDeleted = r.IsDeleted == true ? true : false,
                       IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                   }).ToList();
            lst = lst.GroupBy(x => x.Id).Select(y => y.First()).Select((r, index) => new ClsPropSubCategory
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Image = r.Image,
                CreatedBy = r.CreatedBy,
                CreatedDate = r.CreatedDate,
                UpdatedDate = r.UpdatedDate,
                CategoryId = r.CategoryId,
                CategoryName = r.CategoryName,
                UserMessage = r.UserMessage,
                ButtonTitle = r.ButtonTitle,
                IsDeleted = r.IsDeleted == true ? true : false,
                IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                SNO = index + 1
            }).ToList();
            return lst;
        }

        public void GetRecord()
        {
            tbl_SubCategory obj = _db.tbl_SubCategory.FirstOrDefault(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                   (CategoryId != 0 ? r.CategoryId == CategoryId : CategoryId == 0) &&
                      (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                      (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                   (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)));
            if (obj != null)
            {
                Id = obj.Id;
                Name = obj.Name;
                CategoryName = obj.tbl_Category.Name;
                CategoryId = obj.CategoryId;
                Description = obj.Description;
                Image = obj.Image;
                CreatedBy = obj.CreatedBy;
                CreatedDate = obj.CreatedDate;
                UpdatedDate = obj.UpdatedDate;
                UserMessage = UserMessage;
                ButtonTitle = ButtonTitle;
                IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                DataRecieved = true;
            }
        }

        #endregion

        #region "DropDowns"
        public List<Subcategory> GetDropDownAll()
        {
            List<Subcategory> lst = new List<Subcategory>();
            lst = (from r in _db.tbl_SubCategory
                   where ((Id != 0 ? r.Id == Id : Id == 0) &&
                   (CategoryId != 0 ? r.CategoryId == CategoryId : CategoryId == 0) &&
                      (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))
                   select new Subcategory
                   {
                       Id = r.Id,
                       Name = r.Name
                   }).ToList();        
            return lst;
        }
        #endregion

        #region "TotalRecords"
        public Int64 GetTotalRecords()
        {
            Int64 Records = 0;
            Records = _db.tbl_SubCategory.Count(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                   (CategoryId != 0 ? r.CategoryId == CategoryId : CategoryId == 0) &&
                      (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)));
            return Records;
        }
        #endregion
    }
    public class Subcategory
    {
        public long Id;
        public string Name;
    }
}
