using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Sgu.StudentTesting.BLL.Contracts
{
    public interface IUserLogic
    {
        int AddUser(User student);
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
        bool CheckLoginUser(string login, string password);
    }
}
