using Common;
using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgu.ShopRate.DAL.Fake
{
    public class ShopDao : IShopDao
    {
        private static Dictionary<int,Shop> _storageShop = new Dictionary<int,Shop>();
        
        public int AddShop(Shop newShop)
        {
            int max = 0;
            if (_storageShop.Any())
            {
                max = _storageShop.Values.Max(Item => Item.IDShop);
            }
            newShop.IDShop = ++max;
            _storageShop.Add(newShop.IDShop, newShop);
            return max;
        }
        public IEnumerable<Shop> GetShops()
        {
            return _storageShop.Values;
        }

        public IEnumerable<Shop> GetShopsByModerator(int idModerator)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Shop> GetShopsByCity(int idCity)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Shop> GetShopsByDescription(string description)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Shop> GetShopsByName(string nameShop)
        {
            throw new NotImplementedException();
        }
        public Shop GetShopById(int idShop)
        {
            if (!_storageShop.TryGetValue(idShop,out var result))
            {
                result = null;
            }
            return result;
        }
        public void Update(Shop shop)
        {
            throw new NotImplementedException();
        }
        public void DeleteById(int idShop)
        {
            throw new NotImplementedException();
        }
    }
}
