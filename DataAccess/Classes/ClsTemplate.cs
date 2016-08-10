using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class ClsTemplate : EntityContext
    {
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

        //Title
        private string _Title = string.Empty;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        //IconImage
        private string _IconImage = string.Empty;
        public string IconImage
        {
            get { return _IconImage; }
            set { _IconImage = value; }
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

        //TemplateId
        private Int64? _TemplateId = 0;
        public Int64? TemplateId
        {
            get { return _TemplateId ?? 0; }
            set { _TemplateId = value; }
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
            tbl_Template obj = _db.tbl_Template.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_Template();
                SetObjects(obj);
                _db.tbl_Template.Add(obj);
                _db.SaveChanges();
                Id = obj.Id;
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_Template obj = _db.tbl_Template.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void Delete()
        {
            tbl_Template obj = _db.tbl_Template.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_Template.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void DeleteByTemplateId()
        {
            List<tbl_Template> obj = _db.tbl_Template.Where(a => a.Id == a.Id).ToList();
            if (obj != null && obj.Count>0)
            {
                foreach (var item in obj)
                {
                    _db.tbl_Template.Remove(item);
                    _db.SaveChanges();
                    DataRecieved = true;
                }
            }
        }

        public void SetObjects(tbl_Template obj)
        {
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = CreatedBy;
            obj.Title = Title;
            obj.IconImage = IconImage;
            obj.TemplateId = TemplateId;
            obj.IsDeleted = IsDeleted;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
        }
        #endregion

        #region "Get Method"

        public List<ClsTemplate> GetAll()
        {
            List<ClsTemplate> lst = new List<ClsTemplate>();
            lst = (from r in _db.tbl_Template
                   where ((Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (TemplateId != 0 ? r.TemplateId == TemplateId : TemplateId == 0)&&
                    (!string.IsNullOrEmpty(Title) ? r.Title.ToLower() == Title.ToLower() : string.IsNullOrEmpty(Title)))

                   select new ClsTemplate
                   {
                       Id = r.Id,
                       TemplateId = r.TemplateId,
                       IconImage=r.IconImage,
                       Title=r.Title,
                       CreatedBy = r.CreatedBy,
                       CreatedDate = r.CreatedDate,
                       UpdatedDate = r.UpdatedDate,
                       IsDeleted = r.IsDeleted == true ? true : false,
                       IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                   }).ToList();

            lst = lst.Select((r, index) => new ClsTemplate
            {
                Id = r.Id,
                TemplateId = r.TemplateId,
                IconImage = r.IconImage,
                Title = r.Title,
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
            tbl_Template obj = _db.tbl_Template.FirstOrDefault(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (TemplateId != 0 ? r.TemplateId == TemplateId : TemplateId == 0)&&
                   (!string.IsNullOrEmpty(Title) ? r.Title.ToLower() == Title.ToLower() : string.IsNullOrEmpty(Title)));
            if (obj != null)
            {
                Id = obj.Id;
                Title = obj.Title;
                IconImage = obj.IconImage;
                TemplateId = obj.TemplateId;
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
            Records = _db.tbl_Template.Count(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (TemplateId != 0 ? r.TemplateId == TemplateId : TemplateId == 0) &&
                   (!string.IsNullOrEmpty(Title) ? r.Title.ToLower() == Title.ToLower() : string.IsNullOrEmpty(Title)));
            return Records;
        }
        #endregion
    }
}
