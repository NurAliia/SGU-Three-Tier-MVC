using System;
using System.Collections.Generic;
using Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sgu.StudentTesting.DAL.Contracts
{
    public interface IRatingDao
    {
        void AddRating(Rating rating);
        double GetRatingShopById(int idShop);
        IEnumerable<Rating> GetRatingByAuthor(int idUser);
        IEnumerable<Rating> GetRatingByShop(int idShop);
        void Update(Rating rating);
        void DeleteById(int idRating);
    }
}
