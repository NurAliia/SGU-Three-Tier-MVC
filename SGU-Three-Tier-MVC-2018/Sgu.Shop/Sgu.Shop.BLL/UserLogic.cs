using Common;
using Sgu.StudentTesting.BLL.Contracts;
using Sgu.StudentTesting.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Sgu.StudentTesting.BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public int AddUser(User user)
        {

            byte[] data = user.Password.Select(x => (byte)x).ToArray();
            byte[] result;
            using (SHA512 shaM = SHA512.Create())
            {
                result = shaM.ComputeHash(data);
            }

            return _userDao.AddUser(user, result.ToList());
        }

        public IEnumerable<City> GetCity()
        {
            return _userDao.GetCity();
        }
        public IEnumerable<User> GetUsers()
        {
            return _userDao.GetUsers();
        }
        public IEnumerable<User> GetModerators()
        {
            return _userDao.GetModerators();
        }
        public User GetUserByEMail(string email)
        {
            return _userDao.GetUserByEMail(email);
        }
        public User GetUserById(int id)
        {
            return _userDao.GetUserById(id);
        }
       
        public void RequestRights(int idUser)
        {
            _userDao.RequestRights(idUser);
        }
        public IEnumerable<User> ListRequestRights()
        {
            return _userDao.ListRequestRights();
        }
        public void DeleteRequestRights(int idUser)
        {
            _userDao.DeleteRequestRights(idUser);
        }
        public int GetRoleUser(int idUser)
        {
            return _userDao.GetRoleUser(idUser);
        }


        public bool Update(User user)
        {
            return _userDao.Update(user);
        }
        public bool Delete(int idUser)
        {
            return _userDao.Delete(idUser);
        }
       
        public bool CheckLoginUser(string login, string password)
        {
            byte[] data = password.Select(x => (byte)x).ToArray();
            byte[] result;
            using (SHA512 shaM = SHA512.Create())
            {
                result = shaM.ComputeHash(data);
            }
            return _userDao.CheckLoginUser(login, result.ToList());
        }
        
    }
}