using System;
using System.Collections.Generic;
using Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgu.StudentTesting.BLL.Contracts
{
    public interface IShopLogic
    {
        int AddShop(Shop shop);
        IEnumerable<Shop> GetShops();
        IEnumerable<Shop> GetShopsByModerator(int idModerator);
        IEnumerable<Shop> GetShopsByCity(int idCity);
        IEnumerable<Shop> GetShopsByDescription(string description);
        IEnumerable<Shop> GetShopsByName(string nameShop);
        Shop GetShopById(int idShop);
        bool Update(Shop shop);
        bool DeleteById(int idShop);
    }
}
