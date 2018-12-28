using Common;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Configuration;


namespace Sgu.StudentTesting.DAL.Contracts
{
    public interface IUserDao
    {
        int AddUser(User student, List<byte> password);
        IEnumerable<User> GetUsers();
        IEnumerable<City> GetCity();
        IEnumerable<User> GetModerators();
        User GetUserByEMail(string email);
        User GetUserById(int id);
        void RequestRights(int idUser);
        IEnumerable<User> ListRequestRights();
        void DeleteRequestRights(int idUser);
        int GetRoleUser(int idUser);
        bool Update(User student);
        bool Delete(int idUser);
        bool CheckLoginUser(string login, List<byte> password);        
    }
}
