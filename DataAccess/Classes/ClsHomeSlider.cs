using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class ClsHomeSlider : EntityContext
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

        //IsApproved
        private Int64 _IsApproved = (int)BooleanValues.Both;
        public Int64 IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }

        #endregion

        #region "Add Delete Update"
        public void Add()
        {
            tbl_HomeSlider obj = _db.tbl_HomeSlider.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_HomeSlider();
                SetObjects(obj);
                _db.tbl_HomeSlider.Add(obj);
                _db.SaveChanges();
                Id = obj.Id;
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_HomeSlider obj = _db.tbl_HomeSlider.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }



        public void Delete()
        {
            tbl_HomeSlider obj = _db.tbl_HomeSlider.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_HomeSlider.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }



        public void SetObjects(tbl_HomeSlider obj)
        {
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = Convert.ToInt64(CreatedBy);
            obj.Image = Image;
            obj.Title = Title;
            obj.IsDeleted = IsDeleted;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
        }
        #endregion

        #region "Get Method"

        public List<ClsHomeSlider> GetAll()
        {
            List<ClsHomeSlider> lst = new List<ClsHomeSlider>();
            if (Take != 0)
            {
                lst = (from r in _db.tbl_HomeSlider
                       where ((Id != 0 ? r.Id == Id : Id == 0) &&
                       (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false))

                       select new ClsHomeSlider
                       {
                           Id = r.Id,
                           Title = r.Title,
                           Image = r.Image,
                           CreatedBy = r.CreatedBy,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                       }).Take(Convert.ToInt32(Take)).ToList();
            }
            else
            {
                lst = (from r in _db.tbl_HomeSlider
                       where ((Id != 0 ? r.Id == Id : Id == 0) &&
                       (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false))

                       select new ClsHomeSlider
                       {
                           Id = r.Id,
                           Title = r.Title,
                           Image = r.Image,
                           CreatedBy = r.CreatedBy,
                           CreatedDate = r.CreatedDate,
                           UpdatedDate = r.UpdatedDate,
                           IsDeleted = r.IsDeleted == true ? true : false,
                           IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                       }).ToList();
            }

            lst = lst.Select((r, index) => new ClsHomeSlider
            {
                Id = r.Id,
                Title = r.Title,
                Image = r.Image,
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
            tbl_HomeSlider obj = _db.tbl_HomeSlider.FirstOrDefault(r => ((Id != 0 ? r.Id == Id : Id == 0) &&
                       (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                       (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false)));
            if (obj != null)
            {
                Id = obj.Id;
                Image = obj.Image;
                Title = obj.Title;
                CreatedBy = obj.CreatedBy;
                CreatedDate = obj.CreatedDate;
                UpdatedDate = obj.UpdatedDate;
                IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                DataRecieved = true;
            }
        }

        #endregion
    }
}
