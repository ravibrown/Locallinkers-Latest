using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class ClsLogin : EntityContext
    {

        #region "enum"
        public enum Role
        {
            Admin = 1,
            User = 2,
            Merchant = 3
        }
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

        //IsApproved
        private Int64 _IsApproved = (int)BooleanValues.Both;
        public Int64 IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }

        //SNO
        private Int64 _SNO = 0;
        public Int64 SNO
        {
            get { return _SNO; }
            set { _SNO = value; }
        }

        //UserName
        private string _UserName = string.Empty;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        //Password
        private string _Password = string.Empty;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }


        //DeviceCode
        private string _DeviceCode = string.Empty;
        public string DeviceCode
        {
            get { return _DeviceCode; }
            set { _DeviceCode = value; }
        }

        //IMEI
        private string _IMEI = string.Empty;
        public string IMEI
        {
            get { return _IMEI; }
            set { _IMEI = value; }
        }

        //PlatForm
        private string _PlatForm = string.Empty;
        public string PlatForm
        {
            get { return _PlatForm; }
            set { _PlatForm = value; }
        }


        //UniqueId
        private string _UniqueId = string.Empty;
        public string UniqueId
        {
            get { return _UniqueId; }
            set { _UniqueId = value; }
        }

        //Email
        private string _Email = string.Empty;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        //PhoneNumber
        private string _PhoneNumber = string.Empty;
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }

        //VerificationCode
        private string _VerificationCode = string.Empty;
        public string VerificationCode
        {
            get { return _VerificationCode; }
            set { _VerificationCode = value; }
        }

        //Address1
        private string _Address1 = string.Empty;
        public string Address1
        {
            get { return _Address1; }
            set { _Address1 = value; }
        }

        //Address2
        private string _Address2 = string.Empty;
        public string Address2
        {
            get { return _Address2; }
            set { _Address2 = value; }
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

        //Website
        private string _Website = string.Empty;
        public string Website
        {
            get { return _Website; }
            set { _Website = value; }
        }

        //Country
        private string _Country = string.Empty;
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
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

        //RoleId
        private Int64? _RoleId = (int)Role.User;
        public Int64? RoleId
        {
            get { return _RoleId ?? 0; }
            set { _RoleId = value; }
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
            tbl_Login obj = _db.tbl_Login.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_Login();
                SetObjects(obj);
                _db.tbl_Login.Add(obj);
                _db.SaveChanges();
                Id = obj.Id;
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_Login obj = _db.tbl_Login.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void Delete()
        {
            tbl_Login obj = _db.tbl_Login.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_Login.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void DeleteByRoleId()
        {
            List<tbl_Login> obj = _db.tbl_Login.Where(a => a.RoleId == RoleId).ToList();
            if (obj != null && obj.Count > 0)
            {
                foreach (var item in obj)
                {
                    _db.tbl_Login.Remove(item);
                    _db.SaveChanges();
                    DataRecieved = true;
                }
            }
        }

        public void SetObjects(tbl_Login obj)
        {
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = CreatedBy;
            obj.UserName = UserName;
            obj.RoleId = RoleId;
            obj.Email = Email;
            obj.PhoneNumber = PhoneNumber;
            obj.VerificationCode = VerificationCode;
            obj.Password = ClsCommon.Encode(Password);
            obj.IsDeleted = IsDeleted;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
            obj.UniqueId = UniqueId;
            obj.PlatForm = PlatForm;
            obj.DeviceCode = DeviceCode;
            obj.IMEI = IMEI;
            obj.Address1 = Address1;
            obj.Address2 = Address2;
            obj.State = State;
            obj.City = City;
            obj.Country = Country;
            obj.Website = Website;
            obj.PostalCode = PostalCode;
            obj.Image = Image;
        }
        #endregion

        #region "Get Method"

        public List<ClsLogin> GetAll()
        {
            List<ClsLogin> lst = new List<ClsLogin>();
            lst = (from r in _db.tbl_Login
                   where ((Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (RoleId != 0 ? r.RoleId == RoleId : RoleId == 0) &&
                   (!string.IsNullOrEmpty(PhoneNumber) ? r.PhoneNumber == PhoneNumber : string.IsNullOrEmpty(PhoneNumber)) &&
                   (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                   (!string.IsNullOrEmpty(Email) ? r.Email == Email : string.IsNullOrEmpty(Email)) &&
                   (!string.IsNullOrEmpty(UniqueId) ? r.UniqueId.ToLower() == UniqueId.ToLower() : string.IsNullOrEmpty(UniqueId)) &&
                   (!string.IsNullOrEmpty(VerificationCode) ? r.VerificationCode.ToLower() == VerificationCode.ToLower() : string.IsNullOrEmpty(VerificationCode)))

                   select new ClsLogin
                   {
                       Id = r.Id,
                       RoleId = r.RoleId,
                       Email = r.Email,
                       UserName = r.UserName,
                       Password = r.Password,
                       VerificationCode = r.VerificationCode,
                       PhoneNumber = r.PhoneNumber,
                       CreatedBy = r.CreatedBy,
                       CreatedDate = r.CreatedDate,
                       UpdatedDate = r.UpdatedDate,
                       UniqueId = r.UniqueId,
                       IMEI = r.IMEI,
                       PlatForm = r.PlatForm,
                       DeviceCode = r.DeviceCode,
                       PostalCode = r.PostalCode,
                       Address1 = r.Address1,
                       Address2 = r.Address2,
                       City = r.City,
                       State = r.State,
                       Website = r.Website,
                       Country = r.Country,
                       IsDeleted = r.IsDeleted == true ? true : false,
                       IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                       Image = r.Image,
                   }).ToList();

            lst = lst.Select((r, index) => new ClsLogin
            {
                Id = r.Id,
                RoleId = r.RoleId,
                Email = r.Email,
                UserName = r.UserName,
                Password = r.Password,
                PhoneNumber = r.PhoneNumber,
                VerificationCode = r.VerificationCode,
                CreatedBy = r.CreatedBy,
                CreatedDate = r.CreatedDate,
                UpdatedDate = r.UpdatedDate,
                UniqueId = r.UniqueId,
                IMEI = r.IMEI,
                PlatForm = r.PlatForm,
                DeviceCode = r.DeviceCode,
                PostalCode = r.PostalCode,
                Address1 = r.Address1,
                Address2 = r.Address2,
                City = r.City,
                State = r.State,
                Website = r.Website,
                Country = r.Country,
                IsDeleted = r.IsDeleted == true ? true : false,
                IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                Image = r.Image,
                SNO = index + 1
            }).ToList();

            return lst;
        }
        public void GetUserByID(long userID)
        {
            tbl_Login obj = _db.tbl_Login.FirstOrDefault(r => r.Id == userID);
            if(obj!=null)
            {
                
                    Id = obj.Id;
                    RoleId = obj.RoleId;
                    Email = obj.Email;
                    UserName = obj.UserName;
                    Password = ClsCommon.Decode(obj.Password);
                    PhoneNumber = obj.PhoneNumber;
                    VerificationCode = obj.VerificationCode;
                    CreatedBy = obj.CreatedBy;
                    CreatedDate = obj.CreatedDate;
                    UpdatedDate = obj.UpdatedDate;
                    UniqueId = obj.UniqueId;
                    IMEI = obj.IMEI;
                    PlatForm = obj.PlatForm;
                    DeviceCode = obj.DeviceCode;
                    PostalCode = obj.PostalCode;
                    Address1 = obj.Address1;
                    Address2 = obj.Address2;
                    City = obj.City;
                    State = obj.State;
                    Website = obj.Website;
                    Country = obj.Country;
                    Image = obj.Image;
                    IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                    IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                    DataRecieved = true;
                
            }
            
        }
        public void GetRecord()
        {
            tbl_Login obj = _db.tbl_Login.FirstOrDefault(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (RoleId != 0 ? r.RoleId == RoleId : RoleId == 0) &&
                   (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both) &&
                   (!string.IsNullOrEmpty(PhoneNumber) ? r.PhoneNumber == PhoneNumber : string.IsNullOrEmpty(PhoneNumber)) &&
                   (!string.IsNullOrEmpty(Email) ? r.Email == Email : string.IsNullOrEmpty(Email)) &&
                   (!string.IsNullOrEmpty(UniqueId) ? r.UniqueId.ToLower() == UniqueId.ToLower() : string.IsNullOrEmpty(UniqueId)) &&
                   (!string.IsNullOrEmpty(VerificationCode) ? r.VerificationCode.ToLower() == VerificationCode.ToLower() : string.IsNullOrEmpty(VerificationCode)));

            if (obj != null)
            {
                Id = obj.Id;
                RoleId = obj.RoleId;
                Email = obj.Email;
                UserName = obj.UserName;
                Password = ClsCommon.Decode(obj.Password);
                PhoneNumber = obj.PhoneNumber;
                VerificationCode = obj.VerificationCode;
                CreatedBy = obj.CreatedBy;
                CreatedDate = obj.CreatedDate;
                UpdatedDate = obj.UpdatedDate;
                UniqueId = obj.UniqueId;
                IMEI = obj.IMEI;
                PlatForm = obj.PlatForm;
                DeviceCode = obj.DeviceCode;
                PostalCode = obj.PostalCode;
                Address1 = obj.Address1;
                Address2 = obj.Address2;
                City = obj.City;
                State = obj.State;
                Website = obj.Website;
                Country = obj.Country;
                Image = obj.Image;
                IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                DataRecieved = true;
            }
        }
        public void GetRecordByPhone(string phone)
        {
            tbl_Login obj = _db.tbl_Login.FirstOrDefault(r => r.PhoneNumber == phone && r.IsDeleted == false);
            if (obj != null)
            {
                Id = obj.Id;
                RoleId = obj.RoleId;
                Email = obj.Email;
                UserName = obj.UserName;
                Password = ClsCommon.Decode(obj.Password);
                PhoneNumber = obj.PhoneNumber;
                VerificationCode = obj.VerificationCode;
                CreatedBy = obj.CreatedBy;
                CreatedDate = obj.CreatedDate;
                UpdatedDate = obj.UpdatedDate;
                UniqueId = obj.UniqueId;
                IMEI = obj.IMEI;
                PlatForm = obj.PlatForm;
                DeviceCode = obj.DeviceCode;
                PostalCode = obj.PostalCode;
                Address1 = obj.Address1;
                Address2 = obj.Address2;
                City = obj.City;
                State = obj.State;
                Website = obj.Website;
                Country = obj.Country;
                Image = obj.Image;
                IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                DataRecieved = true;
            }
        }
        public bool IsAunthenticate()
        {
            tbl_Login obj = _db.tbl_Login.FirstOrDefault(a =>
                (!string.IsNullOrEmpty(UserName) ? a.UserName == UserName : string.IsNullOrEmpty(UserName))
                && (!string.IsNullOrEmpty(Password) ? a.Password == Password : string.IsNullOrEmpty(Password))
                && (IsApproved == (int)BooleanValues.Approved ? a.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? a.IsDeleted == false : IsApproved == (int)BooleanValues.Both)
                && (!string.IsNullOrEmpty(PhoneNumber) ? a.PhoneNumber == PhoneNumber : string.IsNullOrEmpty(PhoneNumber))
                && (!string.IsNullOrEmpty(UniqueId) ? a.UniqueId == UniqueId : string.IsNullOrEmpty(UniqueId))
                 && (!string.IsNullOrEmpty(Email) ? a.Email == Email : string.IsNullOrEmpty(Email)));
            if (obj != null)
            {
                Id = obj.Id;
                RoleId = obj.RoleId;
                Email = obj.Email;
                UserName = obj.UserName;
                Password = ClsCommon.Decode(obj.Password);
                PhoneNumber = obj.PhoneNumber;
                CreatedBy = obj.CreatedBy;
                CreatedDate = obj.CreatedDate;
                VerificationCode = obj.VerificationCode;
                UpdatedDate = obj.UpdatedDate;
                UniqueId = obj.UniqueId;
                IMEI = obj.IMEI;
                PlatForm = obj.PlatForm;
                DeviceCode = obj.DeviceCode;
                PostalCode = obj.PostalCode;
                Address1 = obj.Address1;
                Address2 = obj.Address2;
                Image = obj.Image;
                City = obj.City;
                State = obj.State;
                Website = obj.Website;
                Country = obj.Country;
                IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                DataRecieved = true;
            }
            return DataRecieved;
        }

        #endregion
    }
}
