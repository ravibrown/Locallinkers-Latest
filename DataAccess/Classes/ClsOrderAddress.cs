using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace DataAccess.Classes
{
    public class ClsOrderAddress : EntityContext
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

        //PaymentMode
        private string _PaymentMode = string.Empty;
        public string PaymentMode
        {
            get { return _PaymentMode; }
            set { _PaymentMode = value; }
        }

        //TrackingId
        private string _TrackingId = string.Empty;
        public string TrackingId
        {
            get { return _TrackingId; }
            set { _TrackingId = value; }
        }

        //BankReferenceNumber
        private string _BankReferenceNumber = string.Empty;
        public string BankReferenceNumber
        {
            get { return _BankReferenceNumber; }
            set { _BankReferenceNumber = value; }
        }

        //Currency
        private string _Currency = string.Empty;
        public string Currency
        {
            get { return _Currency; }
            set { _Currency = value; }
        }

        //OrderId
        private string _OrderId = string.Empty;
        public string OrderId
        {
            get { return _OrderId; }
            set { _OrderId = value; }
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
            tbl_OrderAddress obj = _db.tbl_OrderAddress.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_OrderAddress();
                SetObjects(obj);
                _db.tbl_OrderAddress.Add(obj);
                _db.SaveChanges();
                Id = obj.Id;
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_OrderAddress obj = _db.tbl_OrderAddress.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void Delete()
        {
            tbl_OrderAddress obj = _db.tbl_OrderAddress.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_OrderAddress.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void SetObjects(tbl_OrderAddress obj)
        {
            obj.PaymentMode = PaymentMode;
            obj.BillingAddress = BillingAddress;
            obj.BillingCity = BillingCity;
            obj.BillingCountry = BillingCountry;
            obj.BillingEmail = BillingEmail;
            obj.BillingTel = BillingTel;
            obj.BillingZip = BillingZip;
            obj.BillingState = BillingState;
            obj.BillingName = BillingName;
            obj.DeliveryAddress = DeliveryAddress;
            obj.DeliveryCity = DeliveryCity;
            obj.DeliveryCountry = DeliveryCountry;
            obj.DeliveryEmail = DeliveryEmail;
            obj.DeliveryTel = DeliveryTel;
            obj.DeliveryZip = DeliveryZip;
            obj.DeliveryState = DeliveryState;
            obj.DeliveryName = DeliveryName;
            obj.TrackingId = TrackingId;
            obj.Currency = Currency;
            obj.BankReferenceNumber = BankReferenceNumber;
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = CreatedBy;
            obj.IsDeleted = IsDeleted;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
            obj.OrderId = OrderId;
        }
        #endregion

        #region "Get Method"

        public List<ClsOrderAddress> GetAll()
        {
            List<ClsOrderAddress> lst = new List<ClsOrderAddress>();
            try
            {
                if (Take != 0 && Index == 0)
                {
                    lst = (from r in _db.tbl_OrderAddress
                           where ((Id != 0 ? r.Id == Id : Id == 0) &&
                           (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                           (!String.IsNullOrEmpty(TrackingId) ? r.TrackingId.ToLower() == TrackingId.ToLower() : String.IsNullOrEmpty(TrackingId)) &&
                           (!String.IsNullOrEmpty(OrderId) ? r.OrderId.ToLower() == OrderId.ToLower() : String.IsNullOrEmpty(OrderId)) &&
                           (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both))

                           select new ClsOrderAddress
                           {
                               Id = r.Id,
                               PaymentMode = r.PaymentMode,
                               BillingAddress = r.BillingAddress,
                               BillingCity = r.BillingCity,
                               BillingCountry = r.BillingCountry,
                               BillingEmail = r.BillingEmail,
                               BillingTel = r.BillingTel,
                               BillingZip = r.BillingZip,
                               BillingState = r.BillingState,
                               BillingName = r.BillingName,
                               DeliveryAddress = r.DeliveryAddress,
                               DeliveryCity = r.DeliveryCity,
                               DeliveryCountry = r.DeliveryCountry,
                               DeliveryEmail = r.DeliveryEmail,
                               DeliveryTel = r.DeliveryTel,
                               DeliveryZip = r.DeliveryZip,
                               DeliveryState = r.DeliveryState,
                               DeliveryName = r.DeliveryName,
                               TrackingId = r.TrackingId,
                               Currency = r.Currency,
                               BankReferenceNumber = r.BankReferenceNumber,
                               CreatedDate = r.CreatedDate,
                               UpdatedDate = r.UpdatedDate,
                               CreatedBy = r.CreatedBy,
                               IsDeleted = r.IsDeleted == true ? true : false,
                               IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                               OrderId=r.OrderId
                           }).Take(Convert.ToInt32(Take)).ToList();
                }
                else if (Take != 0 && Index != 0)
                {
                    lst = (from r in _db.tbl_OrderAddress
                           where ((Id != 0 ? r.Id == Id : Id == 0) &&
                           (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                           (!String.IsNullOrEmpty(TrackingId) ? r.TrackingId.ToLower() == TrackingId.ToLower() : String.IsNullOrEmpty(TrackingId)) &&
                           (!String.IsNullOrEmpty(OrderId) ? r.OrderId.ToLower() == OrderId.ToLower() : String.IsNullOrEmpty(OrderId)) &&
                           (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both))
                           select new ClsOrderAddress
                           {
                               Id = r.Id,
                               PaymentMode = r.PaymentMode,
                               BillingAddress = r.BillingAddress,
                               BillingCity = r.BillingCity,
                               BillingCountry = r.BillingCountry,
                               BillingEmail = r.BillingEmail,
                               BillingTel = r.BillingTel,
                               BillingZip = r.BillingZip,
                               BillingState = r.BillingState,
                               BillingName = r.BillingName,
                               DeliveryAddress = r.DeliveryAddress,
                               DeliveryCity = r.DeliveryCity,
                               DeliveryCountry = r.DeliveryCountry,
                               DeliveryEmail = r.DeliveryEmail,
                               DeliveryTel = r.DeliveryTel,
                               DeliveryZip = r.DeliveryZip,
                               DeliveryState = r.DeliveryState,
                               DeliveryName = r.DeliveryName,
                               TrackingId = r.TrackingId,
                               Currency = r.Currency,
                               BankReferenceNumber = r.BankReferenceNumber,
                               CreatedDate = r.CreatedDate,
                               UpdatedDate = r.UpdatedDate,
                               CreatedBy = r.CreatedBy,
                               IsDeleted = r.IsDeleted == true ? true : false,
                               IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                               OrderId=r.OrderId
                           }).Skip(Convert.ToInt32(Index * Take)).Take(Convert.ToInt32(Take)).ToList();
                }
                else
                {
                    lst = (from r in _db.tbl_OrderAddress
                           where ((Id != 0 ? r.Id == Id : Id == 0) &&
                           (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                           (!String.IsNullOrEmpty(TrackingId) ? r.TrackingId.ToLower() == TrackingId.ToLower() : String.IsNullOrEmpty(TrackingId)) &&
                           (!String.IsNullOrEmpty(OrderId) ? r.OrderId.ToLower() == OrderId.ToLower() : String.IsNullOrEmpty(OrderId)) &&
                           (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both))

                           select new ClsOrderAddress
                           {
                               Id = r.Id,
                               PaymentMode = r.PaymentMode,
                               BillingAddress = r.BillingAddress,
                               BillingCity = r.BillingCity,
                               BillingCountry = r.BillingCountry,
                               BillingEmail = r.BillingEmail,
                               BillingTel = r.BillingTel,
                               BillingZip = r.BillingZip,
                               BillingState = r.BillingState,
                               BillingName = r.BillingName,
                               DeliveryAddress = r.DeliveryAddress,
                               DeliveryCity = r.DeliveryCity,
                               DeliveryCountry = r.DeliveryCountry,
                               DeliveryEmail = r.DeliveryEmail,
                               DeliveryTel = r.DeliveryTel,
                               DeliveryZip = r.DeliveryZip,
                               DeliveryState = r.DeliveryState,
                               DeliveryName = r.DeliveryName,
                               TrackingId = r.TrackingId,
                               Currency = r.Currency,
                               BankReferenceNumber = r.BankReferenceNumber,
                               CreatedDate = r.CreatedDate,
                               UpdatedDate = r.UpdatedDate,
                               CreatedBy = r.CreatedBy,
                               IsDeleted = r.IsDeleted == true ? true : false,
                               IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                               OrderId = r.OrderId
                           }).ToList();
                }

                lst = lst.Select((r, index) => new ClsOrderAddress
                {
                    Id = r.Id,
                    PaymentMode = r.PaymentMode,
                    BillingAddress = r.BillingAddress,
                    BillingCity = r.BillingCity,
                    BillingCountry = r.BillingCountry,
                    BillingEmail = r.BillingEmail,
                    BillingTel = r.BillingTel,
                    BillingZip = r.BillingZip,
                    BillingState = r.BillingState,
                    BillingName = r.BillingName,
                    DeliveryAddress = r.DeliveryAddress,
                    DeliveryCity = r.DeliveryCity,
                    DeliveryCountry = r.DeliveryCountry,
                    DeliveryEmail = r.DeliveryEmail,
                    DeliveryTel = r.DeliveryTel,
                    DeliveryZip = r.DeliveryZip,
                    DeliveryState = r.DeliveryState,
                    DeliveryName = r.DeliveryName,
                    TrackingId = r.TrackingId,
                    Currency = r.Currency,
                    BankReferenceNumber = r.BankReferenceNumber,
                    CreatedDate = r.CreatedDate,
                    UpdatedDate = r.UpdatedDate,
                    CreatedBy = r.CreatedBy,
                    IsDeleted = r.IsDeleted == true ? true : false,
                    IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                    OrderId=r.OrderId,
                    SNO = index + 1
                }).ToList();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return lst;
        }



        public void GetRecord()
        {
            tbl_OrderAddress obj = _db.tbl_OrderAddress.FirstOrDefault(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                           (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                           (!String.IsNullOrEmpty(TrackingId) ? r.TrackingId.ToLower() == TrackingId.ToLower() : String.IsNullOrEmpty(TrackingId)) &&
                           (!String.IsNullOrEmpty(OrderId) ? r.OrderId.ToLower() == OrderId.ToLower() : String.IsNullOrEmpty(OrderId)) &&
                           (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both));
            if (obj != null)
            {
                Id = obj.Id;
                PaymentMode = obj.PaymentMode;
                BillingAddress = obj.BillingAddress;
                BillingCity = obj.BillingCity;
                BillingCountry = obj.BillingCountry;
                BillingEmail = obj.BillingEmail;
                BillingTel = obj.BillingTel;
                BillingZip = obj.BillingZip;
                BillingState = obj.BillingState;
                BillingName = obj.BillingName;
                DeliveryAddress = obj.DeliveryAddress;
                DeliveryCity = obj.DeliveryCity;
                DeliveryCountry = obj.DeliveryCountry;
                DeliveryEmail = obj.DeliveryEmail;
                DeliveryTel = obj.DeliveryTel;
                DeliveryZip = obj.DeliveryZip;
                DeliveryState = obj.DeliveryState;
                DeliveryName = obj.DeliveryName;
                TrackingId = obj.TrackingId;
                Currency = obj.Currency;
                BankReferenceNumber = obj.BankReferenceNumber;
                CreatedDate = obj.CreatedDate;
                UpdatedDate = obj.UpdatedDate;
                CreatedBy = obj.CreatedBy;
                IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                OrderId = obj.OrderId;
                DataRecieved = true;
            }
        }
        #endregion

    }
}
