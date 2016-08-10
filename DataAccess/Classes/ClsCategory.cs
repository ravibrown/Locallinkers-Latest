using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class ClsCategory : EntityContext
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

        //Name
        private string _Name = string.Empty;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
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

        //IsApproved
        private Int64 _IsApproved = (int)BooleanValues.Both;
        public Int64 IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
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

        //CategoryName
        private string _CategoryName = "";
        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }

        //UserMessage
        private string _UserMessage = "";
        public string UserMessage
        {
            get { return _UserMessage; }
            set { _UserMessage = value; }
        }

        //ButtonTitle
        private string _ButtonTitle = "";
        public string ButtonTitle
        {
            get { return _ButtonTitle; }
            set { _ButtonTitle = value; }
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
            tbl_Category obj = _db.tbl_Category.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_Category();
                SetObjects(obj);
                _db.tbl_Category.Add(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_Category obj = _db.tbl_Category.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void Delete()
        {
            tbl_Category obj = _db.tbl_Category.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_Category.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void SetObjects(tbl_Category obj)
        {
            obj.Name = Name;
            obj.Description = Description;
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = CreatedBy;
            obj.Image = Image;
            obj.UserMessage = UserMessage;
            obj.ButtonTitle = ButtonTitle;
            obj.IsDeleted = IsDeleted;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
        }
        #endregion

        #region "Get Method"

        public List<ClsCategory> GetAll()
        {
            List<ClsCategory> lst = new List<ClsCategory>();
            if (Take != 0 && Index == 0)
            {
                lst = (from r in _db.tbl_Category
                       where ((Id != 0 ? r.Id == Id : Id == 0) &&
                       (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                       (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))

                       select new ClsCategory
                       {
                           Id = r.Id,
                           Name = r.Name,
                           Description = r.Description,
                           Image = r.Image,
                           ButtonTitle = r.ButtonTitle,
                           UserMessage = r.UserMessage,
                           CreatedBy = r.CreatedBy,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                       }).Take(Convert.ToInt32(Take)).ToList();
            }
            else if (Take != 0 && Index != 0)
            {
                lst = (from r in _db.tbl_Category
                       where ((Id != 0 ? r.Id == Id : Id == 0) &&
                       (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                       (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))

                       select new ClsCategory
                       {
                           Id = r.Id,
                           Name = r.Name,
                           Description = r.Description,
                           Image = r.Image,
                           ButtonTitle = r.ButtonTitle,
                           UserMessage = r.UserMessage,
                           CreatedBy = r.CreatedBy,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                       }).OrderBy(a => a.Id).Skip(Convert.ToInt32(Take * Index)).Take(Convert.ToInt32(Take)).ToList();
            }
            else
            {
                lst = (from r in _db.tbl_Category
                       where ((Id != 0 ? r.Id == Id : Id == 0) &&
                       (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                       (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))

                       select new ClsCategory
                       {
                           Id = r.Id,
                           Name = r.Name,
                           Description = r.Description,
                           Image = r.Image,
                           ButtonTitle = r.ButtonTitle,
                           UserMessage = r.UserMessage,
                           CreatedBy = r.CreatedBy,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                       }).ToList();
            }
            lst = lst.Select((r, index) => new ClsCategory
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Image = r.Image,
                ButtonTitle = r.ButtonTitle,
                UserMessage = r.UserMessage,
                CreatedBy = r.CreatedBy,
                CreatedDate = r.CreatedDate,
                UpdatedDate = r.UpdatedDate,
                IsDeleted = r.IsDeleted == true ? true : false,
                IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                SNO = index + 1
            }).ToList();

            return lst;
        }

        public List<ClsPropCategory> GetAllForAjaxWithCoupons()
        {
            List<ClsPropCategory> lst = new List<ClsPropCategory>();
            if (Take != 0 && Index == 0)
            {
                lst = (from r in _db.tbl_Category
                       join a in _db.tbl_Coupons on r.Id equals a.CategoryId
                       where ((Id != 0 ? r.Id == Id : Id == 0) &&
                       (IsDeleted ? (r.IsDeleted == true && a.IsDeleted == true) : (r.IsDeleted == false && a.IsDeleted == false)) &&
                      (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true && a.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false && a.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))

                       select new ClsPropCategory
                       {
                           
                           Id = r.Id,
                           Name = r.Name,
                           Description = r.Description,
                           Image = r.Image,
                           ButtonTitle = r.ButtonTitle,
                           UserMessage = r.UserMessage,
                           CreatedBy = r.CreatedBy,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                       }).Take(Convert.ToInt32(Take)).ToList();
            }
            else if (Take != 0 && Index != 0)
            {
                lst = (from r in _db.tbl_Category
                       join a in _db.tbl_Coupons on r.Id equals a.CategoryId
                       where ((Id != 0 ? r.Id == Id : Id == 0) &&
                        (IsDeleted ? (r.IsDeleted == true && a.IsDeleted == true) : (r.IsDeleted == false && a.IsDeleted == false)) &&
                      (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true && a.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false && a.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))

                       select new ClsPropCategory
                       {
                           Id = r.Id,
                           Name = r.Name,
                           Description = r.Description,
                           Image = r.Image,
                           ButtonTitle = r.ButtonTitle,
                           UserMessage = r.UserMessage,
                           CreatedBy = r.CreatedBy,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                       }).Skip(Convert.ToInt32(Take * Index)).Take(Convert.ToInt32(Take)).ToList();
            }
            else
            {
                lst = (from r in _db.tbl_Category
                       join a in _db.tbl_Coupons on r.Id equals a.CategoryId
                       where ((Id != 0 ? r.Id == Id : Id == 0) &&
                        (IsDeleted ? (r.IsDeleted == true && a.IsDeleted == true) : (r.IsDeleted == false && a.IsDeleted == false)) &&
                      (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true && a.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false && a.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))

                       select new ClsPropCategory
                       {
                           Id = r.Id,
                           Name = r.Name,
                           Description = r.Description,
                           Image = r.Image,
                           ButtonTitle = r.ButtonTitle,
                           UserMessage = r.UserMessage,
                           CreatedBy = r.CreatedBy,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                       }).ToList();
            }
            lst = lst.GroupBy(x => x.Id).Select(y => y.First()).Select((r, index) => new ClsPropCategory
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Image = r.Image,
                ButtonTitle = r.ButtonTitle,
                UserMessage = r.UserMessage,
                CreatedBy = r.CreatedBy,
                CreatedDate = r.CreatedDate,
                UpdatedDate = r.UpdatedDate,
                IsDeleted = r.IsDeleted == true ? true : false,
                IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                SNO = index + 1
            }).ToList();

            return lst;
        }

        public List<ClsPropCategory> GetAllForAjaxWithProducts()
        {
            List<ClsPropCategory> lst = new List<ClsPropCategory>();
            if (Take != 0 && Index == 0)
            {
                lst = (from r in _db.tbl_Category
                       join a in _db.tbl_Products on r.Id equals a.CategoryId
                       where ((Id != 0 ? r.Id == Id : Id == 0) &&
                        (IsDeleted ? (r.IsDeleted == true && a.IsDeleted == true) : (r.IsDeleted == false && a.IsDeleted == false)) &&
                      (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true && a.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false && a.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))

                       select new ClsPropCategory
                       {
                           Id = r.Id,
                           Name = r.Name,
                           Description = r.Description,
                           Image = r.Image,
                           ButtonTitle = r.ButtonTitle,
                           UserMessage = r.UserMessage,
                           CreatedBy = r.CreatedBy,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                       }).Take(Convert.ToInt32(Take)).ToList();
            }
            else if (Take != 0 && Index != 0)
            {
                lst = (from r in _db.tbl_Category
                       join a in _db.tbl_Products on r.Id equals a.CategoryId
                       where ((Id != 0 ? r.Id == Id : Id == 0) &&
                        (IsDeleted ? (r.IsDeleted == true && a.IsDeleted == true) : (r.IsDeleted == false && a.IsDeleted == false)) &&
                      (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true && a.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false && a.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))

                       select new ClsPropCategory
                       {
                           Id = r.Id,
                           Name = r.Name,
                           Description = r.Description,
                           Image = r.Image,
                           ButtonTitle = r.ButtonTitle,
                           UserMessage = r.UserMessage,
                           CreatedBy = r.CreatedBy,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                       }).Skip(Convert.ToInt32(Take * Index)).Take(Convert.ToInt32(Take)).ToList();
            }
            else
            {
                lst = (from r in _db.tbl_Category
                       join a in _db.tbl_Products on r.Id equals a.CategoryId
                       where ((Id != 0 ? r.Id == Id : Id == 0) &&
                        (IsDeleted ? (r.IsDeleted == true && a.IsDeleted == true) : (r.IsDeleted == false && a.IsDeleted == false)) &&
                       (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true && a.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false && a.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))

                       select new ClsPropCategory
                       {
                           Id = r.Id,
                           Name = r.Name,
                           Description = r.Description,
                           Image = r.Image,
                           ButtonTitle = r.ButtonTitle,
                           UserMessage = r.UserMessage,
                           CreatedBy = r.CreatedBy,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                       }).ToList();
            }
            lst = lst.GroupBy(x => x.Id).Select(y => y.First()).Select((r, index) => new ClsPropCategory
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Image = r.Image,
                ButtonTitle = r.ButtonTitle,
                UserMessage = r.UserMessage,
                CreatedBy = r.CreatedBy,
                CreatedDate = r.CreatedDate,
                UpdatedDate = r.UpdatedDate,
                IsDeleted = r.IsDeleted == true ? true : false,
                IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                SNO = index + 1
            }).ToList();

            return lst;
        }

        public List<ClsPropCategory> GetAllForAjaxWithBusiness()
        {
            List<ClsPropCategory> lst = new List<ClsPropCategory>();
            if (Take != 0 && Index == 0)
            {
                lst = (from r in _db.tbl_Category
                       join a in _db.tbl_Business on r.Id equals a.CategoryId
                       where ((Id != 0 ? r.Id == Id : Id == 0) &&
                        (IsDeleted ? (r.IsDeleted == true && a.IsDeleted == true) : (r.IsDeleted == false && a.IsDeleted == false)) &&
                       (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true && a.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false && a.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))

                       select new ClsPropCategory
                       {
                           Id = r.Id,
                           Name = r.Name,
                           Description = r.Description,
                           Image = r.Image,
                           ButtonTitle = r.ButtonTitle,
                           UserMessage = r.UserMessage,
                           CreatedBy = r.CreatedBy,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                       }).Take(Convert.ToInt32(Take)).ToList();
            }
            else if (Take != 0 && Index != 0)
            {
                lst = (from r in _db.tbl_Category
                       join a in _db.tbl_Business on r.Id equals a.CategoryId
                       where ((Id != 0 ? r.Id == Id : Id == 0) &&
                        (IsDeleted ? (r.IsDeleted == true && a.IsDeleted == true) : (r.IsDeleted == false && a.IsDeleted == false)) &&
                       (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true && a.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false && a.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))

                       select new ClsPropCategory
                       {
                           Id = r.Id,
                           Name = r.Name,
                           Description = r.Description,
                           Image = r.Image,
                           ButtonTitle = r.ButtonTitle,
                           UserMessage = r.UserMessage,
                           CreatedBy = r.CreatedBy,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                       }).Skip(Convert.ToInt32(Take * Index)).Take(Convert.ToInt32(Take)).ToList();
            }
            else
            {
                lst = (from r in _db.tbl_Category
                       join a in _db.tbl_Business on r.Id equals a.CategoryId
                       where ((Id != 0 ? r.Id == Id : Id == 0) &&
                        (IsDeleted ? (r.IsDeleted == true && a.IsDeleted == true) : (r.IsDeleted == false && a.IsDeleted == false)) &&
                       (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true && a.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false && a.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (!string.IsNullOrEmpty(Name) ? r.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)))

                       select new ClsPropCategory
                       {
                           Id = r.Id,
                           Name = r.Name,
                           Description = r.Description,
                           Image = r.Image,
                           ButtonTitle = r.ButtonTitle,
                           UserMessage = r.UserMessage,
                           CreatedBy = r.CreatedBy,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                       }).ToList();
            }
            lst = lst.GroupBy(x => x.Id).Select(y => y.First()).Select((r, index) => new ClsPropCategory
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Image = r.Image,
                ButtonTitle = r.ButtonTitle,
                UserMessage = r.UserMessage,
                CreatedBy = r.CreatedBy,
                CreatedDate = r.CreatedDate,
                UpdatedDate = r.UpdatedDate,
                IsDeleted = r.IsDeleted == true ? true : false,
                IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                SNO = index + 1
            }).ToList();

            return lst;
        }


        public void GetRecord()
        {
            tbl_Category obj = _db.tbl_Category.FirstOrDefault(a => (Id != 0 ? a.Id == Id : Id == 0) &&
                   (IsDeleted ? a.IsDeleted == true : a.IsDeleted == false) &&
                   (IsApproved == (int)BooleanValues.Approved ? a.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? a.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                   (!string.IsNullOrEmpty(Name) ? a.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)));
            if (obj != null)
            {
                Id = obj.Id;
                Name = obj.Name;
                Description = obj.Description;
                Image = obj.Image;
                ButtonTitle = obj.ButtonTitle;
                UserMessage = obj.UserMessage;
                CreatedBy = obj.CreatedBy;
                CreatedDate = obj.CreatedDate;
                UpdatedDate = obj.UpdatedDate;
                IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                DataRecieved = true;
            }
        }

        #endregion

        #region "TotalRecords"
        public Int64 GetTotalRecords()
        {
            Int64 Records = 0;
            Records = _db.tbl_Category.Count(a => (Id != 0 ? a.Id == Id : Id == 0) &&
                   (IsDeleted ? a.IsDeleted == true : a.IsDeleted == false) &&
                   (IsApproved == (int)BooleanValues.Approved ? a.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? a.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                   (!string.IsNullOrEmpty(Name) ? a.Name.ToLower() == Name.ToLower() : string.IsNullOrEmpty(Name)));
            return Records;
        }
        #endregion
    }
}
