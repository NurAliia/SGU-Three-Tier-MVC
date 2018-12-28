using Common;
using Sgu.StudentTesting.BLL.Contracts;
using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sgu.StudentTesting.BLL
{
    public class RatingLogic: IRatingLogic
    {
        private readonly IRatingDao _ratingDao;

        public RatingLogic(IRatingDao ratingDao)
        {
            _ratingDao = ratingDao;
        }

        public void AddRating(Rating rating)
        {
            _ratingDao.AddRating(rating);
        }
        public double GetRatingShopById(int idShop)
        {
            return _ratingDao.GetRatingShopById(idShop);
        }

        public IEnumerable<Rating> GetRatingByAuthor(int idUser)
        {
            return _ratingDao.GetRatingByAuthor(idUser);
        }
        public IEnumerable<Rating> GetRatingByShop(int idShop)
        {
            return _ratingDao.GetRatingByShop(idShop);
        }
        public void Update(Rating rating)
        {
            _ratingDao.Update(rating);
        }
        public void DeleteById(int idRating)
        {
            _ratingDao.DeleteById(idRating);
        }
    }
}
