using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class ClsTemplateAboutUs : EntityContext
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

        //AboutUs
        private string _AboutUs = string.Empty;
        public string AboutUs
        {
            get { return _AboutUs; }
            set { _AboutUs = value; }
        }

        //AboutUs
        private string _tagline = string.Empty;
        public string Tagline
        {
            get { return _tagline; }
            set { _tagline = value; }
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
            tbl_TemplateAboutUs obj = _db.tbl_TemplateAboutUs.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_TemplateAboutUs();
                SetObjects(obj);
                _db.tbl_TemplateAboutUs.Add(obj);
                _db.SaveChanges();
                Id = obj.Id;
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_TemplateAboutUs obj = _db.tbl_TemplateAboutUs.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void EditList()
        {
            List<tbl_TemplateAboutUs> obj = _db.tbl_TemplateAboutUs.Where(a => a.TemplateId == TemplateId).ToList();
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
            tbl_TemplateAboutUs obj = _db.tbl_TemplateAboutUs.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_TemplateAboutUs.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void DeleteByTemplateId()
        {
            List<tbl_TemplateAboutUs> obj = _db.tbl_TemplateAboutUs.Where(a => a.Id == a.Id).ToList();
            if (obj != null && obj.Count>0)
            {
                foreach (var item in obj)
                {
                    _db.tbl_TemplateAboutUs.Remove(item);
                    _db.SaveChanges();
                    DataRecieved = true;
                }
            }
        }

        public void SetObjects(tbl_TemplateAboutUs obj)
        {
            obj.tagline = Tagline;
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = CreatedBy;
            obj.AboutUs = AboutUs;
            obj.Image = Image;
            obj.TemplateId = TemplateId;
            obj.IsDeleted = IsDeleted;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
        }
        #endregion

        #region "Get Method"

        public List<ClsTemplateAboutUs> GetAll()
        {
            List<ClsTemplateAboutUs> lst = new List<ClsTemplateAboutUs>();
            lst = (from r in _db.tbl_TemplateAboutUs
                   where ((Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (TemplateId != 0 ? r.TemplateId == TemplateId : TemplateId == 0))

                   select new ClsTemplateAboutUs
                   {
                       Id = r.Id,
                       TemplateId = r.TemplateId,
                       AboutUs = r.AboutUs,
                       Image = r.Image,                       
                       CreatedBy = r.CreatedBy,
                       CreatedDate = r.CreatedDate,
                       UpdatedDate = r.UpdatedDate,
                       Tagline=r.tagline,
                       TemplateName=r.tbl_Template.Title,
                       IsDeleted = r.IsDeleted == true ? true : false,
                       IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                   }).ToList();

            lst = lst.Select((r, index) => new ClsTemplateAboutUs
            {
                Tagline = r.Tagline,
                Id = r.Id,
                TemplateId = r.TemplateId,
                AboutUs = r.AboutUs,
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
            tbl_TemplateAboutUs obj = _db.tbl_TemplateAboutUs.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                Id = obj.Id;
                AboutUs = obj.AboutUs;
                Image = obj.Image;
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

        public bool IsExist()
        {
            tbl_TemplateAboutUs obj = _db.tbl_TemplateAboutUs.FirstOrDefault(a => a.TemplateId == TemplateId && a.IsDeleted == false);
            if (obj != null)
            {
                Id = obj.Id;
                AboutUs = obj.AboutUs;
                Image = obj.Image;
                TemplateId = obj.TemplateId;
                CreatedBy = obj.CreatedBy;
                CreatedDate = obj.CreatedDate;
                UpdatedDate = obj.UpdatedDate;
                TemplateName = obj.tbl_Template.Title;
                IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                DataRecieved = true;
            }
            return DataRecieved;
        }

        #endregion
    }
}
