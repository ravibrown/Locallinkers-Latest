using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class ClsUserPoints : EntityContext
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

        //Points
        private Int64? _Points = 0;
        public Int64? Points
        {
            get { return _Points??0; }
            set { _Points = value; }
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

        //UserId
        private Int64? _UserId = 0;
        public Int64? UserId
        {
            get { return _UserId ?? 0; }
            set { _UserId = value; }
        }

        //OrderId
        private Int64? _OrderId = 0;
        public Int64? OrderId
        {
            get { return _OrderId ?? 0; }
            set { _OrderId = value; }
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
            tbl_UserPoints obj = _db.tbl_UserPoints.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_UserPoints();
                SetObjects(obj);
                _db.tbl_UserPoints.Add(obj);
                _db.SaveChanges();
                Id = obj.Id;
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_UserPoints obj = _db.tbl_UserPoints.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void Delete()
        {
            tbl_UserPoints obj = _db.tbl_UserPoints.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_UserPoints.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void DeleteByUserId()
        {
            List<tbl_UserPoints> obj = _db.tbl_UserPoints.Where(a => a.UserId == UserId).ToList();
            if (obj != null && obj.Count>0)
            {
                foreach (var item in obj)
                {
                    _db.tbl_UserPoints.Remove(item);
                    _db.SaveChanges();
                    DataRecieved = true;
                }
            }
        }

        public void SetObjects(tbl_UserPoints obj)
        {
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = CreatedBy;
            obj.Points = Points;
            obj.UserId = UserId;
            obj.OrderId = OrderId;
            obj.IsDeleted = IsDeleted;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
        }
        #endregion

        #region "Get Method"

        public List<ClsUserPoints> GetAll()
        {
            List<ClsUserPoints> lst = new List<ClsUserPoints>();
            lst = (from r in _db.tbl_UserPoints
                   where ((Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (UserId != 0 ? r.UserId == UserId : UserId == 0)&&
                   (OrderId!=0?r.OrderId==OrderId:OrderId==0))

                   select new ClsUserPoints
                   {
                       Id = r.Id,
                       UserId = r.UserId,
                       OrderId=r.OrderId,
                       Points = r.Points,
                       CreatedBy = r.CreatedBy,
                       CreatedDate = r.CreatedDate,
                       UpdatedDate = r.UpdatedDate,
                       IsDeleted = r.IsDeleted == true ? true : false,
                       IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                   }).ToList();

            lst = lst.Select((r, index) => new ClsUserPoints
            {
                Id = r.Id,
                UserId = r.UserId,
                OrderId=r.OrderId,
                Points = r.Points,
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
            tbl_UserPoints obj = _db.tbl_UserPoints.FirstOrDefault(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (UserId != 0 ? r.UserId == UserId : UserId == 0) &&
                   (OrderId != 0 ? r.OrderId == OrderId : OrderId == 0));
            if (obj != null)
            {
                Id = obj.Id;
                Points = obj.Points;
                UserId = obj.UserId;
                OrderId = obj.OrderId;
                CreatedBy = obj.CreatedBy;
                CreatedDate = obj.CreatedDate;
                UpdatedDate = obj.UpdatedDate;
                IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                DataRecieved = true;
            }
        }

        #endregion

        #region "PointsSum"
        public Int64 SumPoints()
        {
            Int64 TotalPoints = 0;
            TotalPoints =Convert.ToInt64( _db.tbl_UserPoints.Where(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                   (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                   (UserId != 0 ? r.UserId == UserId : UserId == 0)&&
                   (OrderId!=0?r.OrderId==OrderId:OrderId==0)).Select(a=>a.Points).Sum());
            return TotalPoints;
        }
        #endregion
    }
}
