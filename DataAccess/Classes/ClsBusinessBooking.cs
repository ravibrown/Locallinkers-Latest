using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class ClsBusinessBooking : EntityContext
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

        //UserId
        private Int64? _UserId = 0;
        public Int64? UserId
        {
            get { return _UserId ?? 0; }
            set { _UserId = value; }
        }

        //BusinessId
        private Int64? _BusinessId = 0;
        public Int64? BusinessId
        {
            get { return _BusinessId ?? 0; }
            set { _BusinessId = value; }
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

        //BookingDate
        private DateTime? _BookingDate = DateTime.UtcNow;
        public DateTime? BookingDate
        {
            get { return _BookingDate; }
            set { _BookingDate = value; }
        }

        //Time
        private string _Time = string.Empty;
        public string Time
        {
            get { return _Time; }
            set { _Time = value; }
        }

        //Message
        private string _Message = string.Empty;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        //CreatedBy
        private Int64? _CreatedBy = 0;
        public Int64? CreatedBy
        {
            get { return _CreatedBy ?? 0; }
            set { _CreatedBy = value; }
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
            tbl_BusinessBooking obj = _db.tbl_BusinessBooking.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_BusinessBooking();
                SetObjects(obj);
                _db.tbl_BusinessBooking.Add(obj);
                _db.SaveChanges();
                Id = obj.Id;
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_BusinessBooking obj = _db.tbl_BusinessBooking.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void Delete()
        {
            tbl_BusinessBooking obj = _db.tbl_BusinessBooking.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_BusinessBooking.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void DeleteByBusinessOrCouponId()
        {
            List<tbl_BusinessBooking> obj = _db.tbl_BusinessBooking.Where(a => ((BusinessId != 0 ? a.BusinessId == BusinessId : BusinessId == 0) &&
                (UserId != 0 ? a.UserId == UserId : UserId == 0))).ToList();
            if (obj != null && obj.Count > 0)
            {
                foreach (var item in obj)
                {
                    _db.tbl_BusinessBooking.Remove(item);
                    _db.SaveChanges();
                    DataRecieved = true;
                }
            }
        }

        public void SetObjects(tbl_BusinessBooking obj)
        {
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = Convert.ToInt64(CreatedBy);
            obj.UserId = UserId;
            obj.BusinessId = BusinessId;
            obj.BookingDate = BookingDate;
            obj.Time = Time;
            obj.Message = Message;
            obj.IsDeleted = IsDeleted;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
        }
        #endregion

        #region "Get Method"

        public List<ClsBusinessBooking> GetAll()
        {
            List<ClsBusinessBooking> lst = new List<ClsBusinessBooking>();
            lst = (from r in _db.tbl_BusinessBooking
                   where ((Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (BusinessId != 0 ? r.BusinessId == BusinessId : BusinessId == 0) &&
                (UserId != 0 ? r.UserId == UserId : UserId == 0))

                   select new ClsBusinessBooking
                   {
                       Id = r.Id,
                       BusinessId = r.BusinessId,
                       BookingDate = r.BookingDate,
                       Time = r.Time,
                       UserId = r.UserId,
                       Message=r.Message,
                       CreatedBy = r.CreatedBy,
                       CreatedDate = r.CreatedDate,
                       UpdatedDate = r.UpdatedDate,
                       IsDeleted = r.IsDeleted == true ? true : false,
                       IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                   }).ToList();

            lst = lst.Select((r, index) => new ClsBusinessBooking
            {
                Id = r.Id,
                BusinessId = r.BusinessId,
                BookingDate = r.BookingDate,
                Time = r.Time,
                Message=r.Message,
                UserId = r.UserId,
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
            tbl_BusinessBooking obj = _db.tbl_BusinessBooking.FirstOrDefault(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (BusinessId != 0 ? r.BusinessId == BusinessId : BusinessId == 0) &&
                (UserId != 0 ? r.UserId == UserId : UserId == 0));
            if (obj != null)
            {
                Id = obj.Id;
                UserId = obj.UserId;
                BusinessId = obj.BusinessId;
                BookingDate = obj.BookingDate;
                Time = obj.Time;
                Message = obj.Message;
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
