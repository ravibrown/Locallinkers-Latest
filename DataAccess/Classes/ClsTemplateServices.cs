﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class ClsTemplateServices : EntityContext
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

        //Description
        private string _Description = string.Empty;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
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
            tbl_Services obj = _db.tbl_Services.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_Services();
                SetObjects(obj);
                _db.tbl_Services.Add(obj);
                _db.SaveChanges();
                Id = obj.Id;
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_Services obj = _db.tbl_Services.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void EditList()
        {
            List<tbl_Services> obj = _db.tbl_Services.Where(a => a.TemplateId == TemplateId).ToList();
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
            tbl_Services obj = _db.tbl_Services.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_Services.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void DeleteByTemplateId()
        {
            List<tbl_Services> obj = _db.tbl_Services.Where(a => a.TemplateId == TemplateId).ToList();
            if (obj != null && obj.Count>0)
            {
                foreach (var item in obj)
                {
                    _db.tbl_Services.Remove(item);
                    _db.SaveChanges();
                    DataRecieved = true;
                }
            }
        }

        public void SetObjects(tbl_Services obj)
        {
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = CreatedBy;
            obj.Description = Description;
            obj.Title = Title;
            obj.TemplateId = TemplateId;
            obj.IsDeleted = IsDeleted;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
        }
        #endregion

        #region "Get Method"

        public List<ClsTemplateServices> GetAll()
        {
            List<ClsTemplateServices> lst = new List<ClsTemplateServices>();
            lst = (from r in _db.tbl_Services
                   where ((Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (TemplateId != 0 ? r.TemplateId == TemplateId : TemplateId == 0))

                   select new ClsTemplateServices
                   {
                       Id = r.Id,
                       TemplateId = r.TemplateId,
                       Title=r.Title,
                       Description = r.Description,
                       CreatedBy = r.CreatedBy,
                       CreatedDate = r.CreatedDate,
                       UpdatedDate = r.UpdatedDate,
                       TemplateName=r.tbl_Template.Title,
                       IsDeleted = r.IsDeleted == true ? true : false,
                       IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                   }).ToList();

            lst = lst.Select((r, index) => new ClsTemplateServices
            {
                Id = r.Id,
                TemplateId = r.TemplateId,
                Title = r.Title,
                Description = r.Description,
                CreatedBy = r.CreatedBy,
                CreatedDate = r.CreatedDate,
                UpdatedDate = r.UpdatedDate,
                TemplateName = r.TemplateName,
                IsDeleted = r.IsDeleted == true ? true : false,
                IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                SNO = index + 1
            }).ToList();

            return lst;
        }

        public void GetRecord()
        {
            tbl_Services obj = _db.tbl_Services.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                Id = obj.Id;
                Description = obj.Description;
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
