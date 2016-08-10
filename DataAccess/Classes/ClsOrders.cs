using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace DataAccess.Classes
{
    public class ClsOrders:EntityContext
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

        //OrderId
        private string  _OrderId = string.Empty;
        public string OrderId
        {
            get { return _OrderId; }
            set { _OrderId = value; }
        }

        //ReedemPoints
        private Int64? _ReedemPoints = 0;
        public Int64? ReedemPoints
        {
            get { return _ReedemPoints; }
            set { _ReedemPoints = value; }
        }

        //TrackingId
        private string _TrackingId = string.Empty;
        public string TrackingId
        {
            get { return _TrackingId; }
            set { _TrackingId = value; }
        }

        //AddressId
        private Int64? _AddressId = 0;
        public Int64? AddressId
        {
            get { return _AddressId??0; }
            set { _AddressId = value; }
        }

        //UserId
        private Int64? _UserId = 0;
        public Int64? UserId
        {
            get { return _UserId ?? 0; }
            set { _UserId = value; }
        }

        //SNO
        private Int64 _SNO = 0;
        public Int64 SNO
        {
            get { return _SNO; }
            set { _SNO = value; }
        }

        //IsApproved
        private Int64 _IsApproved = (int)BooleanValues.Both;
        public Int64 IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }

        //Type 
        private string _Type = string.Empty;
        public string Type 
        {
            get { return _Type; }
            set { _Type = value; }
        }

        //PaymentMode 
        private string _PaymentMode = string.Empty;
        public string PaymentMode
        {
            get { return _PaymentMode; }
            set { _PaymentMode = value; }
        }


        //OfferType
        private string _OfferType = string.Empty;
        public string OfferType
        {
            get { return _OfferType; }
            set { _OfferType = value; }
        }

        //OfferCode
        private string _OfferCode = string.Empty;
        public string OfferCode
        {
            get { return _OfferCode; }
            set { _OfferCode = value; }
        }

        //Discount
        private decimal? _Discount = 0;
        public decimal? Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }

        //Amount
        private decimal? _Amount = 0;
        public decimal? Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        //BillingAddress 
        private string _BillingAddress = string.Empty;
        public string BillingAddress
        {
            get { return _BillingAddress; }
            set { _BillingAddress = value; }
        }


        //BillingState
        private string _BillingState = string.Empty;
        public string BillingState
        {
            get { return _BillingState; }
            set { _BillingState = value; }
        }

        //BillingCity
        private string _BillingCity = string.Empty;
        public string BillingCity
        {
            get { return _BillingCity; }
            set { _BillingCity = value; }
        }

        //BillingZip
        private string _BillingZip = string.Empty;
        public string BillingZip
        {
            get { return _BillingZip; }
            set { _BillingZip = value; }
        }

        //BillingCountry
        private string _BillingCountry = string.Empty;
        public string BillingCountry
        {
            get { return _BillingCountry; }
            set { _BillingCountry = value; }
        }

        //BillingName
        private string _BillingName = string.Empty;
        public string BillingName
        {
            get { return _BillingName; }
            set { _BillingName = value; }
        }

        //BillingTel
        private string _BillingTel = string.Empty;
        public string BillingTel
        {
            get { return _BillingTel; }
            set { _BillingTel = value; }
        }

        //BillingEmail
        private string _BillingEmail = string.Empty;
        public string BillingEmail
        {
            get { return _BillingEmail; }
            set { _BillingEmail = value; }
        }


        //DeliveryAddress 
        private string _DeliveryAddress = string.Empty;
        public string DeliveryAddress
        {
            get { return _DeliveryAddress; }
            set { _DeliveryAddress = value; }
        }


        //DeliveryState
        private string _DeliveryState = string.Empty;
        public string DeliveryState
        {
            get { return _DeliveryState; }
            set { _DeliveryState = value; }
        }

        //DeliveryCity
        private string _DeliveryCity = string.Empty;
        public string DeliveryCity
        {
            get { return _DeliveryCity; }
            set { _DeliveryCity = value; }
        }

        //DeliveryZip
        private string _DeliveryZip = string.Empty;
        public string DeliveryZip
        {
            get { return _DeliveryZip; }
            set { _DeliveryZip = value; }
        }

        //DeliveryCountry
        private string _DeliveryCountry = string.Empty;
        public string DeliveryCountry
        {
            get { return _DeliveryCountry; }
            set { _DeliveryCountry = value; }
        }

        //DeliveryName
        private string _DeliveryName = string.Empty;
        public string DeliveryName
        {
            get { return _DeliveryName; }
            set { _DeliveryName = value; }
        }

        //DeliveryTel
        private string _DeliveryTel = string.Empty;
        public string DeliveryTel
        {
            get { return _DeliveryTel; }
            set { _DeliveryTel = value; }
        }

        //DeliveryEmail
        private string _DeliveryEmail = string.Empty;
        public string DeliveryEmail
        {
            get { return _DeliveryEmail; }
            set { _DeliveryEmail = value; }
        }

        //UserPhone
        private string _UserPhone = string.Empty;
        public string UserPhone
        {
            get { return _UserPhone; }
            set { _UserPhone = value; }
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

        //Index
        private Int64 _Index = 0;
        public Int64 Index
        {
            get { return _Index; }
            set { _Index = value; }
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
            tbl_Orders obj = _db.tbl_Orders.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_Orders();
                SetObjects(obj);
                _db.tbl_Orders.Add(obj);
                _db.SaveChanges();
                Id = obj.Id;
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_Orders obj = _db.tbl_Orders.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void Delete()
        {
            tbl_Orders obj = _db.tbl_Orders.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_Orders.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void SetObjects(tbl_Orders obj)
        {
            obj.OrderId = OrderId;
            obj.AddressId = AddressId;
            obj.TrackingId = TrackingId;
            obj.UserId = UserId;
            obj.Type = Type;
            obj.OfferType = OfferType;
            obj.OfferCode = OfferCode;
            obj.Discount = Discount;
            obj.Amount = Amount;
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = CreatedBy;
            obj.IsDeleted = IsDeleted;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
            obj.ReedemPoints = ReedemPoints;
        }
        #endregion

        #region "Get Method"

        public List<ClsOrders> GetAll()
        {
            List<ClsOrders> lst = new List<ClsOrders>();
            try
            {
                if (Take != 0 && Index == 0)
                {
                    lst = (from r in _db.tbl_Orders
                           where ((Id != 0 ? r.Id == Id : Id == 0) &&
                           (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                           (!String.IsNullOrEmpty(OrderId) ? r.OrderId.ToLower() == OrderId.ToLower() : String.IsNullOrEmpty(OrderId)) &&
                           (AddressId != 0 ? r.AddressId == AddressId : AddressId == 0) &&
                           (UserId != 0 ? r.UserId == UserId : UserId == 0) &&
                           (!String.IsNullOrEmpty(TrackingId) ? r.TrackingId.ToLower() == TrackingId.ToLower() : String.IsNullOrEmpty(TrackingId)) &&
                           (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both))

                           select new ClsOrders
                           {
                               Id = r.Id,
                               OrderId = r.OrderId,
                               AddressId = r.AddressId,
                               TrackingId = r.TrackingId,
                               UserId = r.UserId,
                               Type = r.Type,
                               OfferType = r.OfferType,
                               OfferCode = r.OfferCode,
                               Discount = r.Discount,
                               UserPhone=r.tbl_Login.PhoneNumber,
                               BillingAddress=r.tbl_OrderAddress.BillingAddress,
                               BillingCity=r.tbl_OrderAddress.BillingCity,
                               BillingState = r.tbl_OrderAddress.BillingState,
                               BillingTel = r.tbl_OrderAddress.BillingTel,
                               BillingEmail = r.tbl_OrderAddress.BillingEmail,
                               BillingName = r.tbl_OrderAddress.BillingName,
                               BillingZip = r.tbl_OrderAddress.BillingZip,
                               BillingCountry = r.tbl_OrderAddress.BillingCountry,
                               DeliveryAddress = r.tbl_OrderAddress.DeliveryAddress,
                               DeliveryCity = r.tbl_OrderAddress.DeliveryCity,
                               DeliveryState = r.tbl_OrderAddress.DeliveryState,
                               DeliveryTel = r.tbl_OrderAddress.DeliveryTel,
                               DeliveryEmail = r.tbl_OrderAddress.DeliveryEmail,
                               DeliveryName = r.tbl_OrderAddress.DeliveryName,
                               DeliveryZip = r.tbl_OrderAddress.DeliveryZip,
                               DeliveryCountry = r.tbl_OrderAddress.DeliveryCountry,
                               PaymentMode=r.tbl_OrderAddress.PaymentMode,
                               ReedemPoints=r.ReedemPoints,
                               Amount = r.Amount,
                               CreatedDate = r.CreatedDate,
                               UpdatedDate = r.UpdatedDate,
                               CreatedBy = r.CreatedBy,
                               IsDeleted = r.IsDeleted == true ? true : false,
                               IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                           }).Take(Convert.ToInt32(Take)).ToList();
                }
                else if (Take != 0 && Index != 0)
                {
                    lst = (from r in _db.tbl_Orders
                           where ((Id != 0 ? r.Id == Id : Id == 0) &&
                           (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                           (!String.IsNullOrEmpty(OrderId) ? r.OrderId.ToLower() == OrderId.ToLower() : String.IsNullOrEmpty(OrderId)) &&
                           (AddressId != 0 ? r.AddressId == AddressId : AddressId == 0) &&
                           (UserId != 0 ? r.UserId == UserId : UserId == 0) &&
                           (!String.IsNullOrEmpty(TrackingId) ? r.TrackingId.ToLower() == TrackingId.ToLower() : String.IsNullOrEmpty(TrackingId)) &&
                           (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both))
                           select new ClsOrders
                           {
                               Id = r.Id,
                               OrderId = r.OrderId,
                               AddressId = r.AddressId,
                               TrackingId = r.TrackingId,
                               UserId = r.UserId,
                               Type = r.Type,
                               OfferType = r.OfferType,
                               OfferCode = r.OfferCode,
                               Discount = r.Discount,
                               UserPhone = r.tbl_Login.PhoneNumber,
                               BillingAddress = r.tbl_OrderAddress.BillingAddress,
                               BillingCity = r.tbl_OrderAddress.BillingCity,
                               BillingState = r.tbl_OrderAddress.BillingState,
                               BillingTel = r.tbl_OrderAddress.BillingTel,
                               BillingEmail = r.tbl_OrderAddress.BillingEmail,
                               BillingName = r.tbl_OrderAddress.BillingName,
                               BillingZip = r.tbl_OrderAddress.BillingZip,
                               BillingCountry = r.tbl_OrderAddress.BillingCountry,
                               DeliveryAddress = r.tbl_OrderAddress.DeliveryAddress,
                               DeliveryCity = r.tbl_OrderAddress.DeliveryCity,
                               DeliveryState = r.tbl_OrderAddress.DeliveryState,
                               DeliveryTel = r.tbl_OrderAddress.DeliveryTel,
                               DeliveryEmail = r.tbl_OrderAddress.DeliveryEmail,
                               DeliveryName = r.tbl_OrderAddress.DeliveryName,
                               DeliveryZip = r.tbl_OrderAddress.DeliveryZip,
                               DeliveryCountry = r.tbl_OrderAddress.DeliveryCountry,
                               PaymentMode = r.tbl_OrderAddress.PaymentMode,
                               Amount = r.Amount,
                               ReedemPoints = r.ReedemPoints,
                               CreatedDate = r.CreatedDate,
                               UpdatedDate = r.UpdatedDate,
                               CreatedBy = r.CreatedBy,
                               IsDeleted = r.IsDeleted == true ? true : false,
                               IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                           }).OrderBy(a=>a.Id).Skip(Convert.ToInt32(Index * Take)).Take(Convert.ToInt32(Take)).ToList();
                }
                else
                {
                    lst = (from r in _db.tbl_Orders
                           where ((Id != 0 ? r.Id == Id : Id == 0) &&
                           (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                           (!String.IsNullOrEmpty(OrderId) ? r.OrderId.ToLower() == OrderId.ToLower() : String.IsNullOrEmpty(OrderId)) &&
                           (AddressId != 0 ? r.AddressId == AddressId : AddressId == 0) &&
                           (UserId != 0 ? r.UserId == UserId : UserId == 0) &&
                           (!String.IsNullOrEmpty(TrackingId) ? r.TrackingId.ToLower() == TrackingId.ToLower() : String.IsNullOrEmpty(TrackingId)) &&
                           (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both))

                           select new ClsOrders
                           {
                               Id = r.Id,
                               OrderId = r.OrderId,
                               AddressId = r.AddressId,
                               TrackingId = r.TrackingId,
                               UserId = r.UserId,
                               Type = r.Type,
                               OfferType = r.OfferType,
                               OfferCode = r.OfferCode,
                               Discount = r.Discount,
                               UserPhone = r.tbl_Login.PhoneNumber,
                               BillingAddress = r.tbl_OrderAddress.BillingAddress,
                               BillingCity = r.tbl_OrderAddress.BillingCity,
                               BillingState = r.tbl_OrderAddress.BillingState,
                               BillingTel = r.tbl_OrderAddress.BillingTel,
                               BillingEmail = r.tbl_OrderAddress.BillingEmail,
                               BillingName = r.tbl_OrderAddress.BillingName,
                               BillingZip = r.tbl_OrderAddress.BillingZip,
                               BillingCountry = r.tbl_OrderAddress.BillingCountry,
                               DeliveryAddress = r.tbl_OrderAddress.DeliveryAddress,
                               PaymentMode = r.tbl_OrderAddress.PaymentMode,
                               DeliveryCity = r.tbl_OrderAddress.DeliveryCity,
                               DeliveryState = r.tbl_OrderAddress.DeliveryState,
                               DeliveryTel = r.tbl_OrderAddress.DeliveryTel,
                               DeliveryEmail = r.tbl_OrderAddress.DeliveryEmail,
                               DeliveryName = r.tbl_OrderAddress.DeliveryName,
                               DeliveryZip = r.tbl_OrderAddress.DeliveryZip,
                               DeliveryCountry = r.tbl_OrderAddress.DeliveryCountry,
                               Amount = r.Amount,
                               ReedemPoints = r.ReedemPoints,
                               CreatedDate = r.CreatedDate,
                               UpdatedDate = r.UpdatedDate,
                               CreatedBy = r.CreatedBy,
                               IsDeleted = r.IsDeleted == true ? true : false,
                               IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                           }).ToList();
                }

                lst = lst.Select((r, index) => new ClsOrders
                {
                    Id = r.Id,
                    OrderId = r.OrderId,
                    AddressId = r.AddressId,
                    TrackingId = r.TrackingId,
                    UserId = r.UserId,
                    Type = r.Type,
                    OfferType = r.OfferType,
                    OfferCode = r.OfferCode,
                    Discount = r.Discount,
                    UserPhone = r.UserPhone,
                    BillingAddress = r.BillingAddress,
                    BillingCity = r.BillingCity,
                    BillingState = r.BillingState,
                    BillingTel = r.BillingTel,
                    BillingEmail = r.BillingEmail,
                    BillingName = r.BillingName,
                    BillingZip = r.BillingZip,
                    BillingCountry = r.BillingCountry,
                    DeliveryAddress = r.DeliveryAddress,
                    DeliveryCity = r.DeliveryCity,
                    DeliveryState = r.DeliveryState,
                    DeliveryTel = r.DeliveryTel,
                    DeliveryEmail = r.DeliveryEmail,
                    DeliveryName = r.DeliveryName,
                    DeliveryZip = r.DeliveryZip,
                    PaymentMode = r.PaymentMode,
                    DeliveryCountry = r.DeliveryCountry,
                    Amount = r.Amount,
                    ReedemPoints = r.ReedemPoints,
                    CreatedDate = r.CreatedDate,
                    UpdatedDate = r.UpdatedDate,
                    CreatedBy = r.CreatedBy,
                    IsDeleted = r.IsDeleted == true ? true : false,
                    IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                    SNO = index + 1
                }).ToList();
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }

            return lst;
        } 

        public void GetRecord()
        {
            tbl_Orders obj = _db.tbl_Orders.FirstOrDefault(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                           (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                           (!String.IsNullOrEmpty(OrderId) ? r.OrderId.ToLower() == OrderId.ToLower() : String.IsNullOrEmpty(OrderId)) &&
                           (AddressId != 0 ? r.AddressId == AddressId : AddressId == 0) &&
                           (UserId != 0 ? r.UserId == UserId : UserId == 0) &&
                           (!String.IsNullOrEmpty(TrackingId) ? r.TrackingId.ToLower() == TrackingId.ToLower() : String.IsNullOrEmpty(TrackingId)) &&
                           (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both));
            if (obj != null)
            {
                Id = obj.Id;
                OrderId = obj.OrderId;
                AddressId = obj.AddressId;
                TrackingId = obj.TrackingId;
                UserId = obj.UserId;
                Type = obj.Type;
                OfferType = obj.OfferType;
                OfferCode = obj.OfferCode;
                Discount = obj.Discount;
                Amount = obj.Amount;
                UserPhone = obj.tbl_Login.PhoneNumber;
                BillingAddress = obj.tbl_OrderAddress.BillingAddress;
                BillingCity = obj.tbl_OrderAddress.BillingCity;
                BillingState = obj.tbl_OrderAddress.BillingState;
                BillingTel = obj.tbl_OrderAddress.BillingTel;
                BillingEmail = obj.tbl_OrderAddress.BillingEmail;
                BillingName = obj.tbl_OrderAddress.BillingName;
                BillingZip = obj.tbl_OrderAddress.BillingZip;
                BillingCountry = obj.tbl_OrderAddress.BillingCountry;
                DeliveryAddress = obj.tbl_OrderAddress.DeliveryAddress;
                DeliveryCity = obj.tbl_OrderAddress.DeliveryCity;
                DeliveryState = obj.tbl_OrderAddress.DeliveryState;
                DeliveryTel = obj.tbl_OrderAddress.DeliveryTel;
                DeliveryEmail = obj.tbl_OrderAddress.DeliveryEmail;
                DeliveryName = obj.tbl_OrderAddress.DeliveryName;
                DeliveryZip = obj.tbl_OrderAddress.DeliveryZip;
                DeliveryCountry = obj.tbl_OrderAddress.DeliveryCountry;
                PaymentMode = obj.tbl_OrderAddress.PaymentMode;
                CreatedDate = obj.CreatedDate;
                UpdatedDate = obj.UpdatedDate;
                ReedemPoints = obj.ReedemPoints;
                CreatedBy = obj.CreatedBy;
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
            Records = _db.tbl_Orders.Count(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                           (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                           (!String.IsNullOrEmpty(OrderId) ? r.OrderId.ToLower() == OrderId.ToLower() : String.IsNullOrEmpty(OrderId)) &&
                           (AddressId != 0 ? r.AddressId == AddressId : AddressId == 0) &&
                           (UserId != 0 ? r.UserId == UserId : UserId == 0) &&
                           (!String.IsNullOrEmpty(TrackingId) ? r.TrackingId.ToLower() == TrackingId.ToLower() : String.IsNullOrEmpty(TrackingId)) &&
                           (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both));
            return Records;
        }
        #endregion

    }
}
