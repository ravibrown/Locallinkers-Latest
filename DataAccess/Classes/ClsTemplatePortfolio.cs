using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class ClsTemplatePortfolio : EntityContext
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

        //Image
        private string _Image = string.Empty;
        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }

        //Title
        private string _Title = string.Empty;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        //TemplateName
        private string _TemplateName = string.Empty;
        public string TemplateName
        {
            get { return _TemplateName; }
            set { _TemplateName = value; }
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
            tbl_Portfolio obj = _db.tbl_Portfolio.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_Portfolio();
                SetObjects(obj);
                _db.tbl_Portfolio.Add(obj);
                _db.SaveChanges();
                Id = obj.Id;
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_Portfolio obj = _db.tbl_Portfolio.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void EditList()
        {
            List<tbl_Portfolio> obj = _db.tbl_Portfolio.Where(a => a.TemplateId == TemplateId).ToList();
            if (obj != null && obj.Count > 0)
            {
                foreach (var item in obj)
                {
                    item.IsDeleted = true;
                    _db.SaveChanges();
                    DataRecieved = true;
                }
            }
        }

        public void Delete()
        {
            tbl_Portfolio obj = _db.tbl_Portfolio.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_Portfolio.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void DeleteByTemplateId()
        {
            List<tbl_Portfolio> obj = _db.tbl_Portfolio.Where(a => a.TemplateId == TemplateId).ToList();
            if (obj != null && obj.Count>0)
            {
                foreach (var item in obj)
                {
                    _db.tbl_Portfolio.Remove(item);
                    _db.SaveChanges();
                    DataRecieved = true;
                }
            }
        }

        public void SetObjects(tbl_Portfolio obj)
        {
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = CreatedBy;
            obj.Image = Image;
            obj.Title = Title;
            obj.TemplateId = TemplateId;
            obj.IsDeleted = IsDeleted;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
        }
        #endregion

        #region "Get Method"

        public List<ClsTemplatePortfolio> GetAll()
        {
            List<ClsTemplatePortfolio> lst = new List<ClsTemplatePortfolio>();
            lst = (from r in _db.tbl_Portfolio
                   where ((Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (TemplateId != 0 ? r.TemplateId == TemplateId : TemplateId == 0))

                   select new ClsTemplatePortfolio
                   {
                       Id = r.Id,
                       TemplateId = r.TemplateId,
                       Title=r.Title,
                       Image = r.Image,
                       CreatedBy = r.CreatedBy,
                       CreatedDate = r.CreatedDate,
                       UpdatedDate = r.UpdatedDate,
                       TemplateName=r.tbl_Template.Title,
                       IsDeleted = r.IsDeleted == true ? true : false,
                       IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                   }).ToList();

            lst = lst.Select((r, index) => new ClsTemplatePortfolio
            {
                Id = r.Id,
                TemplateId = r.TemplateId,
                Title = r.Title,
                Image = r.Image,
                CreatedBy = r.CreatedBy,
                CreatedDate = r.CreatedDate,
                UpdatedDate = r.UpdatedDate,
                TemplateName=r.TemplateName,
                IsDeleted = r.IsDeleted == true ? true : false,
                IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                SNO = index + 1
            }).ToList();

            return lst;
        }

        public void GetRecord()
        {
            tbl_Portfolio obj = _db.tbl_Portfolio.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                Id = obj.Id;
                Image = obj.Image;
                Title = obj.Title;
                TemplateId = obj.TemplateId;
                CreatedBy = obj.CreatedBy;
                CreatedDate = obj.CreatedDate;
                UpdatedDate = obj.UpdatedDate;
                TemplateName = obj.tbl_Template.Title;
                IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                DataRecieved = true;
            }
        }

        #endregion
    }
}
