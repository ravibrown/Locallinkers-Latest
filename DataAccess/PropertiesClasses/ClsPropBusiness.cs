using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace DataAccess.Classes
{
    public class ClsPropBusiness
    {
        #region "Enums"
        public enum BooleanValues
        {
            Both = 2,
            Approved = 1,
            Disapproved = 0
        }

        public enum BusinessSubscription
        {
            Premium = 1,
            Paid = 2,
            Free = 3
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
        private Int64? _SNO = 0;
        public Int64? SNO
        {
            get { return _SNO??0; }
            set { _SNO = value; }
        }

        //IsApproved
        private Int64 _IsApproved = (int)BooleanValues.Both;
        public Int64 IsApproved
        {
            get { return _IsApproved; }
            set { _IsApproved = value; }
        }
        //SelectedCity
        private Int64? _SelectedCity = 0;
        public Int64? SelectedCity
        {
            get { return _SelectedCity; }
            set { _SelectedCity = value; }
        }

        //CityName
        private string _CityName = string.Empty;
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }


        //Description 
        private string _Description = string.Empty;
        public string Description 
        {
            get { return _Description; }
            set { _Description = value; }
        }


        //BusinessName
        private string _BusinessName = string.Empty;
        public string BusinessName
        {
            get { return _BusinessName; }
            set { _BusinessName = value; }
        }

        //LstSubCategory
        private List<ClsPropBusiness> _LstSubCategory = null;
        public List<ClsPropBusiness> LstSubCategory
        {
            get { return _LstSubCategory; }
            set { _LstSubCategory = value; }
        }

        //Subscription
        private Int64? _Subscription = (int)BusinessSubscription.Free;
        public Int64? Subscription
        {
            get { return _Subscription; }
            set { _Subscription = value; }
        }

        //Message
        private string _Message = string.Empty;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        //Address
        private string _Address = string.Empty;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        //Latitude
        private string _Latitude = ClsCommon.DefaultLatitude;
        public string Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }

        //Longitude
        private string _Longitude = ClsCommon.DefaultLongitude;
        public string Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }

        //ContactPerson
        private string _ContactPerson = string.Empty;
        public string ContactPerson
        {
            get { return _ContactPerson; }
            set { _ContactPerson = value; }
        }


        //PhoneNumber1
        private string _PhoneNumber1 = string.Empty;
        public string PhoneNumber1
        {
            get { return _PhoneNumber1; }
            set { _PhoneNumber1 = value; }
        }

        //PhoneNumber2
        private string _PhoneNumber2 = string.Empty;
        public string PhoneNumber2
        {
            get { return _PhoneNumber2; }
            set { _PhoneNumber2 = value; }
        }

        //Email
        private string _Email = string.Empty;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        //Website
        private string _Website = string.Empty;
        public string Website
        {
            get { return _Website; }
            set { _Website = value; }
        }

        //Images
        private string _Images = string.Empty;
        public string Images
        {
            get { return _Images; }
            set { _Images = value; }
        }

        //Image
        private string _Image = string.Empty;
        public string Image
        {
            get { return _Image; }
            set { _Image = value; }
        }

        //PremiumImage
        private string _PremiumImage = string.Empty;
        public string PremiumImage
        {
            get { return _PremiumImage; }
            set { _PremiumImage = value; }
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

        //CategoryId
        private Int64? _CategoryId = 0;
        public Int64? CategoryId
        {
            get { return _CategoryId ?? 0; }
            set { _CategoryId = value; }
        }

        //SubCategoryId
        private Int64? _SubCategoryId = 0;
        public Int64? SubCategoryId
        {
            get { return _SubCategoryId ?? 0; }
            set { _SubCategoryId = value; }
        }

        //CategoryName
        private string _CategoryName = "";
        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }

        //UserMessage
        private string _UserMessage = string.Empty;
        public string UserMessage
        {
            get { return _UserMessage; }
            set { _UserMessage = value; }
        }

        //ButtonTitle
        private string _ButtonTitle = string.Empty;
        public string ButtonTitle
        {
            get { return _ButtonTitle; }
            set { _ButtonTitle = value; }
        }

        //SubCategoryName
        private string _SubCategoryName = "";
        public string SubCategoryName
        {
            get { return _SubCategoryName; }
            set { _SubCategoryName = value; }
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

        //Distance
        private double? _Distance = 0;
        public double? Distance
        {
            get { return _Distance; }
            set { _Distance = value; }
        }

        //DataRecieved
        private bool _DataRecieved = false;
        public bool DataRecieved
        {
            get { return _DataRecieved; }
            set { _DataRecieved = value; }
        }

        #endregion
    }
}
