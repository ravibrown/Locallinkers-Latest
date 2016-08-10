using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace DataAccess.Classes
{
    public class ClsOrderMapping:EntityContext
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
        private Int64? _OrderId = 0;
        public Int64? OrderId
        {
            get { return _OrderId ?? 0; }
            set { _OrderId = value; }
        }

        //AddressId
        private Int64? _AddressId = 0;
        public Int64? AddressId
        {
            get { return _AddressId ?? 0; }
            set { _AddressId = value; }
        }

        //CouponCode
        private string _CouponCode =string.Empty;
        public string CouponCode
        {
            get { return _CouponCode; }
            set { _CouponCode = value; }
        }

        //PaymentMode
        private string _PaymentMode = string.Empty;
        public string PaymentMode
        {
            get { return _PaymentMode; }
            set { _PaymentMode = value; }
        }

        //ProductId
        private Int64? _ProductId = 0;
        public Int64? ProductId
        {
            get { return _ProductId ?? 0; }
            set { _ProductId = value; }
        }

        //OriginalProductId
        private Int64? _OriginalProductId = 0;
        public Int64? OriginalProductId
        {
            get { return _OriginalProductId ?? 0; }
            set { _OriginalProductId = value; }
        }

        //Type
        private string _Type = string.Empty;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        //MerchantPhone
        private string _MerchantPhone = string.Empty;
        public string MerchantPhone
        {
            get { return _MerchantPhone; }
            set { _MerchantPhone = value; }
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
            get { return _UserId; }
            set { _UserId = value; }
        }

        //IsApproved
        private Int64 _IsApproved = (int)BooleanValues.Both;
        public Int64 IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
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

        //Quantity
        private Int64? _Quantity = 0;
        public Int64? Quantity
        {
            get { return _Quantity ?? 0; }
            set { _Quantity = value; }
        }

        //Title
        private string _Title = string.Empty;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        //Price
        private decimal? _Price = 0;
        public decimal? Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        //Image
        private string _Image =string.Empty ;
        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
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
            tbl_Order_Product_Mapping obj = _db.tbl_Order_Product_Mapping.FirstOrDefault(a => a.Id == Id);
            if (obj == null)
            {
                obj = new tbl_Order_Product_Mapping();
                SetObjects(obj);
                _db.tbl_Order_Product_Mapping.Add(obj);
                _db.SaveChanges();
                Id = obj.Id;
                DataRecieved = true;
            }
        }

        public void Edit()
        {
            tbl_Order_Product_Mapping obj = _db.tbl_Order_Product_Mapping.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                SetObjects(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void EditList()
        {
            List<tbl_Order_Product_Mapping> obj = _db.tbl_Order_Product_Mapping.Where(a => a.OrderId == OrderId).ToList();
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
            tbl_Order_Product_Mapping obj = _db.tbl_Order_Product_Mapping.FirstOrDefault(a => a.Id == Id);
            if (obj != null)
            {
                _db.tbl_Order_Product_Mapping.Remove(obj);
                _db.SaveChanges();
                DataRecieved = true;
            }
        }

        public void SetObjects(tbl_Order_Product_Mapping obj)
        {
            obj.OrderId = OrderId;
            obj.ProductId = ProductId;
            obj.Type = Type;
            obj.CreatedDate = CreatedDate;
            obj.UpdatedDate = UpdatedDate;
            obj.CreatedBy = CreatedBy;
            obj.IsDeleted = IsDeleted;
            obj.Quantity = Quantity;
            obj.IsApprovedByAdmin = IsApprovedByAdmin;
            obj.OriginalProductId = OriginalProductId;
        }
        #endregion

        #region "Get Method"

        public List<ClsOrderMapping> GetAll()
        {
            List<ClsOrderMapping> lst = new List<ClsOrderMapping>();
            try
            {
                if (Take != 0 && Index == 0)
                {
                    lst = (from r in _db.tbl_Order_Product_Mapping
                           where ((Id != 0 ? r.Id == Id : Id == 0) &&
                           (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                           (OrderId != 0 ? r.OrderId == OrderId : OrderId == 0) &&
                            (UserId != 0 ? r.tbl_Orders.UserId == UserId : UserId == 0) &&
                           (!string.IsNullOrEmpty(CouponCode) ? r.tbl_Orders.OrderId.ToLower() == CouponCode.ToLower() : string.IsNullOrEmpty(CouponCode)) &&
                           (!string.IsNullOrEmpty(Type) ? r.Type.ToLower() == Type.ToLower() : string.IsNullOrEmpty(Type)) &&
                           (ProductId != 0 ? r.ProductId == ProductId : ProductId == 0) &&
                           (OriginalProductId != 0 ? r.OriginalProductId == OriginalProductId : OriginalProductId == 0) &&
                           (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both))
                           let productimage = _db.tbl_OrderDetailImages.FirstOrDefault(a => a.ProductId == r.ProductId)
                           let product = _db.tbl_OrderDetails.FirstOrDefault(a => a.Id == r.ProductId)
                           select new ClsOrderMapping
                           {
                               Id = r.Id,
                               OrderId = r.OrderId,
                               CouponCode=r.tbl_Orders.OrderId,
                               Type = r.Type,
                               ProductId = r.ProductId,
                               OriginalProductId=r.OriginalProductId,
                               CreatedDate = r.CreatedDate,
                               UpdatedDate = r.UpdatedDate,
                               CreatedBy = r.CreatedBy,
                               AddressId=r.tbl_Orders.AddressId,
                               Price = r.Type == "Coupon" ? (product != null ? product.CouponPrice : 0) : (product != null ? product.SalePrice : 0),
                               Title = (product!=null? product.Title:""),
                               Image = (productimage != null ? productimage.Image : ""),
                               MerchantPhone = (product != null ? product.PhoneNumber : ""),
                               Quantity=r.Quantity,
                               PaymentMode=r.tbl_Orders.tbl_OrderAddress.PaymentMode,
                               IsDeleted = r.IsDeleted == true ? true : false,
                               IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                           }).Take(Convert.ToInt32(Take)).ToList();
                }
                else if (Take != 0 && Index != 0)
                {
                    lst = (from r in _db.tbl_Order_Product_Mapping
                           where ((Id != 0 ? r.Id == Id : Id == 0) &&
                           (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                           (OrderId != 0 ? r.OrderId == OrderId : OrderId == 0) &&
                           (UserId != 0 ? r.tbl_Orders.UserId == UserId : UserId == 0) &&
                           (!string.IsNullOrEmpty(CouponCode) ? r.tbl_Orders.OrderId.ToLower() == CouponCode.ToLower() : string.IsNullOrEmpty(CouponCode)) &&
                           (!string.IsNullOrEmpty(Type) ? r.Type.ToLower() == Type.ToLower() : string.IsNullOrEmpty(Type)) &&
                           (ProductId != 0 ? r.ProductId == ProductId : ProductId == 0) &&
                           (OriginalProductId != 0 ? r.OriginalProductId == OriginalProductId : OriginalProductId == 0) &&
                           (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both))
                           let productimage = _db.tbl_OrderDetailImages.FirstOrDefault(a => a.ProductId == r.ProductId)
                           let product = _db.tbl_OrderDetails.FirstOrDefault(a => a.Id == r.ProductId)
                           select new ClsOrderMapping
                           {
                               Id = r.Id,
                               OrderId = r.OrderId,
                               CouponCode = r.tbl_Orders.OrderId,
                               Type = r.Type,
                               ProductId = r.ProductId,
                               OriginalProductId = r.OriginalProductId,
                               CreatedDate = r.CreatedDate,
                               UpdatedDate = r.UpdatedDate,
                               CreatedBy = r.CreatedBy,
                               AddressId = r.tbl_Orders.AddressId,
                               Price = r.Type == "Coupon" ? (product != null ? product.CouponPrice : 0) : (product != null ? product.SalePrice : 0),
                               Title = (product != null ? product.Title : ""),
                               Image = (productimage != null ? productimage.Image : ""),
                               MerchantPhone = (product != null ? product.PhoneNumber : ""),
                               Quantity = r.Quantity,
                               PaymentMode = r.tbl_Orders.tbl_OrderAddress.PaymentMode,
                               IsDeleted = r.IsDeleted == true ? true : false,
                               IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                           }).Skip(Convert.ToInt32(Index * Take)).Take(Convert.ToInt32(Take)).ToList();
                }
                else
                {
                    lst = (from r in _db.tbl_Order_Product_Mapping
                           where ((Id != 0 ? r.Id == Id : Id == 0) &&
                           (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                           (OrderId != 0 ? r.OrderId == OrderId : OrderId == 0) &&
                           (UserId != 0 ? r.tbl_Orders.UserId == UserId : UserId == 0) &&
                           (!string.IsNullOrEmpty(CouponCode) ? r.tbl_Orders.OrderId.ToLower() == CouponCode.ToLower() : string.IsNullOrEmpty(CouponCode)) &&
                           (!string.IsNullOrEmpty(Type) ? r.Type.ToLower() == Type.ToLower() : string.IsNullOrEmpty(Type)) &&
                           (ProductId != 0 ? r.ProductId == ProductId : ProductId == 0) &&
                           (OriginalProductId != 0 ? r.OriginalProductId == OriginalProductId : OriginalProductId == 0) &&
                           (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both))
                           let productimage = _db.tbl_OrderDetailImages.FirstOrDefault(a => a.ProductId == r.ProductId)
                           let product = _db.tbl_OrderDetails.FirstOrDefault(a => a.Id == r.ProductId)
                           select new ClsOrderMapping
                           {
                               Id = r.Id,
                               OrderId = r.OrderId,
                               CouponCode = r.tbl_Orders.OrderId,
                               Type = r.Type,
                               ProductId = r.ProductId,
                               OriginalProductId = r.OriginalProductId,
                               CreatedDate = r.CreatedDate,
                               UpdatedDate = r.UpdatedDate,
                               CreatedBy = r.CreatedBy,
                               AddressId = r.tbl_Orders.AddressId,
                               Price = r.Type == "Coupon" ? (product != null ? product.CouponPrice : 0) : (product != null ? product.SalePrice : 0),
                               Title = (product != null ? product.Title : ""),
                               Image = (productimage != null ? productimage.Image : ""),
                               MerchantPhone = (product != null ? product.PhoneNumber : ""),
                               Quantity = r.Quantity,
                               PaymentMode = r.tbl_Orders.tbl_OrderAddress.PaymentMode,
                               IsDeleted = r.IsDeleted == true ? true : false,
                               IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
                           }).ToList();
                }

                lst = lst.Select((r, index) => new ClsOrderMapping
                {
                    Id = r.Id,
                    OrderId = r.OrderId,
                    Type = r.Type,
                    CouponCode = r.CouponCode,
                    ProductId = r.ProductId,
                    OriginalProductId = r.OriginalProductId,
                    CreatedDate = r.CreatedDate,
                    UpdatedDate = r.UpdatedDate,
                    CreatedBy = r.CreatedBy,
                    Quantity=r.Quantity,
                    PaymentMode = r.PaymentMode,
                    AddressId = r.AddressId,
                    Price = r.Price,
                    Title = r.Title,
                    Image=r.Image,
                    IsDeleted = r.IsDeleted == true ? true : false,
                    IsApprovedByAdmin = r.IsApprovedByAdmin == true ? true : false,
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
            tbl_Order_Product_Mapping obj = _db.tbl_Order_Product_Mapping.FirstOrDefault(r => (Id != 0 ? r.Id == Id : Id == 0) &&
                           (IsDeleted ? r.IsDeleted == true : r.IsDeleted == false) &&
                           (OrderId != 0 ? r.OrderId == OrderId : OrderId == 0) &&
                           (UserId != 0 ? r.tbl_Orders.UserId == UserId : UserId == 0) &&
                           (!string.IsNullOrEmpty(CouponCode) ? r.tbl_Orders.OrderId.ToLower() == CouponCode.ToLower() : string.IsNullOrEmpty(CouponCode)) &&
                           (!string.IsNullOrEmpty(Type) ? r.Type.ToLower() == Type.ToLower() : string.IsNullOrEmpty(Type)) &&
                           (ProductId != 0 ? r.ProductId == ProductId : ProductId == 0)&&
                           (OriginalProductId != 0 ? r.OriginalProductId == OriginalProductId : OriginalProductId == 0) &&
                           (IsApproved == (int)BooleanValues.Approved ? r.IsApprovedByAdmin == true : IsApproved == (int)BooleanValues.Disapproved ? r.IsApprovedByAdmin == false : IsApproved == (int)BooleanValues.Both));
            if (obj != null)
            {
                Id = obj.Id;
                OrderId = obj.OrderId;
                Type = obj.Type;
                ProductId = obj.ProductId;
                OriginalProductId = obj.OriginalProductId;
                UserId = obj.tbl_Orders.UserId;
                CouponCode = obj.tbl_Orders.OrderId;
                CreatedDate = obj.CreatedDate;
                AddressId = obj.tbl_Orders.AddressId;
                UpdatedDate = obj.UpdatedDate;
                CreatedBy = obj.CreatedBy;
                PaymentMode = obj.tbl_Orders.tbl_OrderAddress.PaymentMode;
                Quantity = obj.Quantity;
                IsDeleted = Convert.ToBoolean(obj.IsDeleted);
                IsApprovedByAdmin = Convert.ToBoolean(obj.IsApprovedByAdmin);
                DataRecieved = true;
            }
        }
        #endregion

    }
}
