using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sgu.StudentTesting.PL.ViewModel.Shop
{
    public class ShopDisplayVM :IComparable<ShopDisplayVM>
    {
        public int IDShop { get; set; }
        public string NameShop { get; set; }
        public byte[] Image { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Website { get; set; }
        public string DescriptionShop { get; set; }
        public string PhoneShop { get; set; }
        public string OpeningHours { get; set; }
        public double Rating { get; set; }

        public int CompareTo(ShopDisplayVM other)
        {
            return this.Rating.CompareTo(other.Rating);
        }
    }
}