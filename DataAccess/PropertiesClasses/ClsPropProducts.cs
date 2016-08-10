using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class ClsPropProducts
    {
        #region "Enums"
        public enum BooleanValues
        {
            Both=2,
            Approved=1,
            Disapproved=0
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

        //Title
        private string _Title = string.Empty;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
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

        //ShortDescription
        private string _ShortDescription = string.Empty;
        public string ShortDescription
        {
            get { return _ShortDescription; }
            set { _ShortDescription = value; }
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

        //ActualPrice
        private decimal? _ActualPrice = 0;
        public decimal? ActualPrice
        {
            get { return _ActualPrice; }
            set { _ActualPrice = value; }
        }

        //SalePrice
        private decimal? _SalePrice = 0;
        public decimal? SalePrice
        {
            get { return _SalePrice; }
            set { _SalePrice = value; }
        }


        //Images
        private List<ClsPropProductImages> _Images = null;
        public List<ClsPropProductImages> Images
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


        //SelectedPosition
        private Int64? _SelectedPosition = 0;
        public Int64? SelectedPosition
        {
            get { return _SelectedPosition; }
            set { _SelectedPosition = value; }
        }

        //Stock
        private Int64? _Stock = 0;
        public Int64? Stock
        {
            get { return _Stock; }
            set { _Stock = value; }
        }

        //Distance
        private double? _Distance = 0;
        public double? Distance
        {
            get { return _Distance; }
            set { _Distance = value; }
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

        //Take
        private Int64 _Take= 0;
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
