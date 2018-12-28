using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Shop
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
        public int Moderator { get; set; }

        public static string ToString(Shop shop)
        {
            return $"{shop.NameShop} {shop.Address} {shop.City} {shop.Website} {shop.DescriptionShop} " +
                $"{shop.PhoneShop} {shop.OpeningHours} {shop.Rating} {shop.Moderator}";
        }
        public string GetOpeningHours(Shop shop, int i)
        {
            string[] hours = new string[1];
            hours = shop.OpeningHours.Split('-');
            return hours[i];
        }
    }
}
