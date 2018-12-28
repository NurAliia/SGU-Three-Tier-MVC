using Common;
using Sgu.StudentTesting.BLL.Contracts;
using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Sgu.StudentTesting.BLL
{
    public class ShopLogic: IShopLogic
    {
        private readonly IShopDao _shopDao;

        public ShopLogic(IShopDao shopDao)
        {
            _shopDao = shopDao;
        }
        public int AddShop(Shop shop)
        {
            return _shopDao.AddShop(shop);
        }
        public IEnumerable<Shop> GetShops()
        {
            return _shopDao.GetShops();
        }
        public IEnumerable<Shop> GetShopsByModerator(int idModerator)
        {
            IEnumerable<Shop> list = _shopDao.GetShopsByModerator(idModerator);
            return list;
        }
        public IEnumerable<Shop> GetShopsByCity(int idCity)
        {
            return _shopDao.GetShopsByCity(idCity);
        }
        public IEnumerable<Shop> GetShopsByDescription(string description)
        {
            return _shopDao.GetShopsByDescription(description);
        }
        public IEnumerable<Shop> GetShopsByName(string nameShop)
        {
            return _shopDao.GetShopsByName(nameShop);
        }
        public Shop GetShopById(int idShop)
        {
            return _shopDao.GetShopById(idShop);
        }
        public bool Update(Shop shop)
        {
            try
            {
                _shopDao.Update(shop);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteById(int idShop)
        {
            if (_shopDao.GetShopById(idShop)!=null)
            {
                _shopDao.DeleteById(idShop);
                return true;
            }
            return false;
        }
    }
}
