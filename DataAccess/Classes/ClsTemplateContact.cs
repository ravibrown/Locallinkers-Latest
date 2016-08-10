using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class ClsTemplateContact : EntityContext
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


        //Address
        private string _Address = string.Empty;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        //Website
        private string _Website = string.Empty;
        public string Website
        {
            get { return _Website; }
            set { _Website = value; }
        }

        //Email
        private string _Email = string.Empty;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        //City
        private string _City = string.Empty;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        //State
        private string _State = string.Empty;
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        //PostalCode
        private string _PostalCode = string.Empty;
        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }

        //PhoneNumber
        private string _PhoneNumber = string.Empty;
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }

        //TumblerLink
        private string _TumblerLink = string.Empty;
        public string TumblerLink
        {
            get { return _TumblerLink; }
            set { _TumblerLink = value; }
        }

        //PinInterestLink
        private string _PinInterestLink = string.Empty;
        public string PinInterestLink
        {
            get { return _PinInterestLink; }
            set { _PinInterestLink = value; }
        }

        //GoogleLink
        private string _GoogleLink = string.Empty;
        public string GoogleLink
        {
            get { return _GoogleLink; }
            set { _GoogleLink = value; }
        }

        //FacebookLink
        private string _FacebookLink = string.Empty;
        public string FacebookLink
        {
            get { return _FacebookLink; }
            set { _FacebookLink = value; }
        }

        //TwitterLink
        private string _TwitterLink = string.Empty;
        public string TwitterLink
        {
            get { return _TwitterLink; }
            set { _TwitterLink = value; }
        }

        //TemplateName
        private string _TemplateName = string.Empty;
        public string TemplateName
        {
            get { return _TemplateName; }
            set { _TemplateName = value; }
        }

        //Latitude
        private string _Latitude = string.Empty;
        public string Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }

        //Longitude
        private string _Longitude = string.Empty;
        public string Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
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
            tbl_TemplateContact obj = _db.tbl_TemplateContact.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_TemplateContact();
                SetObjects(obj);
                _db.tbl_TemplateContact.Add(obj);
                _db.SaveChanges();
                Id = obj.Id;
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_TemplateContact obj = _db.tbl_TemplateContact.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void Delete()
        {
            tbl_TemplateContact obj = _db.tbl_TemplateContact.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_TemplateContact.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void EditList()
        {
            List<tbl_TemplateContact> obj = _db.tbl_TemplateContact.Where(a => a.TemplateId == TemplateId).ToList();
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

        public void DeleteByTemplateId()
        {
            List<tbl_TemplateContact> obj = _db.tbl_TemplateContact.Where(a => a.Id == a.Id).ToList();
            if (obj != null && obj.Count > 0)
            {
                foreach (var item in obj)
                {
                    _db.tbl_TemplateContact.Remove(item);
                    _db.SaveChanges();
                    DataRecieved = true;
                }
            }
        }

        public void SetObjects(tbl_TemplateContact obj)
        {
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = CreatedBy;
            obj.Address = Address;
            obj.Email = Email;
            obj.Website = Website;
            obj.FaceBookLink = FacebookLink;
            obj.TwitterLink = TwitterLink;
            obj.TumblarLink = TumblerLink;
            obj.GoogleLink = GoogleLink;
            obj.PinInterestLink = PinInterestLink;
            obj.PhoneNumber = PhoneNumber;
            obj.TemplateId = TemplateId;
            obj.IsDeleted = IsDeleted;
            obj.City = City;
            obj.State = State;
            obj.PostalCode = PostalCode;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
            obj.Latitude = Latitude;
            obj.Longitude = Longitude;
        }
        #endregion

        #region "Get Method"

        public List<ClsTemplateContact> GetAll()
        {
            List<ClsTemplateContact> lst = new List<ClsTemplateContact>();
            lst = (from r in _db.tbl_TemplateContact
                   where ((Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (TemplateId != 0 ? r.TemplateId == TemplateId : TemplateId == 0))

                   select new ClsTemplateContact
                   {
                       Id = r.Id,
                       TemplateId = r.TemplateId,
                       FacebookLink = r.FaceBookLink,
                       TwitterLink = r.TwitterLink,
                       GoogleLink = r.GoogleLink,
                       PinInterestLink = r.PinInterestLink,
                       TumblerLink = r.TumblarLink,
                       Email = r.Email,
                       Address = r.Address,
                       Website = r.Website,
                       PhoneNumber = r.PhoneNumber,
                       City = r.City,
                       State = r.State,
                       PostalCode = r.PostalCode,
                       TemplateName = r.tbl_Template.Title,
                       CreatedBy = r.CreatedBy,
                       CreatedDate = r.CreatedDate,
                       UpdatedDate = r.UpdatedDate,
                       Longitude = r.Longitude,
                       Latitude = r.Latitude,
                       IsDeleted = r.IsDeleted == true ? true : false,
                       IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                   }).ToList();

            lst = lst.Select((r, index) => new ClsTemplateContact
            {
                Id = r.Id,
                TemplateId = r.TemplateId,
                FacebookLink = r.FacebookLink,
                TwitterLink = r.TwitterLink,
                GoogleLink = r.GoogleLink,
                PinInterestLink = r.PinInterestLink,
                TumblerLink = r.TumblerLink,
                Email = r.Email,
                Address = r.Address,
                City = r.City,
                State = r.State,
                PostalCode = r.PostalCode,
                Website = r.Website,
                PhoneNumber = r.PhoneNumber,
                CreatedBy = r.CreatedBy,
                CreatedDate = r.CreatedDate,
                UpdatedDate = r.UpdatedDate,
                TemplateName = r.TemplateName,
                Longitude = r.Longitude,
                Latitude = r.Latitude,
                IsDeleted = r.IsDeleted == true ? true : false,
                IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                SNO = index + 1
            }).ToList();

            return lst;
        }

        public void GetRecord()
        {
            tbl_TemplateContact obj = _db.tbl_TemplateContact.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                Id = obj.Id;
                FacebookLink = obj.FaceBookLink;
                TwitterLink = obj.TwitterLink;
                GoogleLink = obj.GoogleLink;
                PinInterestLink = obj.PinInterestLink;
                TumblerLink = obj.TumblarLink;
                Email = obj.Email;
                Address = obj.Address;
                Website = obj.Website;
                PhoneNumber = obj.PhoneNumber;
                TemplateId = obj.TemplateId;
                CreatedBy = obj.CreatedBy;
                CreatedDate = obj.CreatedDate;
                UpdatedDate = obj.UpdatedDate;
                City = obj.City;
                State = obj.State;
                PostalCode = obj.PostalCode;
                TemplateName = obj.tbl_Template.Title;
                Longitude = obj.Longitude;
                Latitude = obj.Latitude;
                IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                DataRecieved = true;
            }
        }

        public bool IsExist()
        {
            tbl_TemplateContact obj = _db.tbl_TemplateContact.FirstOrDefault(a => a.TemplateId == TemplateId && a.IsDeleted == false);
            if (obj != null)
            {
                Id = obj.Id;
                FacebookLink = obj.FaceBookLink;
                TwitterLink = obj.TwitterLink;
                GoogleLink = obj.GoogleLink;
                PinInterestLink = obj.PinInterestLink;
                TumblerLink = obj.TumblarLink;
                Email = obj.Email;
                Address = obj.Address;
                Website = obj.Website;
                City = obj.City;
                State = obj.State;
                PostalCode = obj.PostalCode;
                PhoneNumber = obj.PhoneNumber;
                TemplateId = obj.TemplateId;
                CreatedBy = obj.CreatedBy;
                CreatedDate = obj.CreatedDate;
                UpdatedDate = obj.UpdatedDate;
                Longitude = obj.Longitude;
                Latitude = obj.Latitude;
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
