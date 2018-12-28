using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgu.ShopRate.DAL.Fake
{
    internal static class Repository
    {
        static Repository()
        {
            Users = new Dictionary<int, User>();
            Shops = new Dictionary<int, Shop>();
            Comments = new Dictionary<int, Comment>();
        }

        internal static IDictionary<int, User> Users { get; set; }
        internal static IDictionary<int, Shop> Shops { get; set; }
        internal static IDictionary<int, Comment> Comments { get; set; }
    }
}
