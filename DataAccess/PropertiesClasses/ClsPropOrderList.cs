using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Classes
{
    public class ClsPropOrderList
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

        //Title
        private string _Title = string.Empty;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        //Description
        private string _Description= string.Empty;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        //Type
        private string _Type = string.Empty;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        //Quantity
        private Int64? _Quantity = 0;
        public Int64? Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        //Price
        private decimal? _Price = 0;
        public decimal? Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        //ActualPrice
        private decimal? _ActualPrice = 0;
        public decimal? ActualPrice
        {
            get { return _ActualPrice; }
            set { _ActualPrice = value; }
        }

        //Images
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

        #endregion
    }
}
