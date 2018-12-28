using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using Sgu.StudentTesting.DAL.Contracts;
using Sgu.StudentTesting.BLL;
using Common;
using System.Security.Cryptography;

namespace ShopRate.UnitTest
{
    [TestClass]
    class UserLogicTest
    {
        [TestMethod]
        public void CreateUser()
        {
            var mock = new Mock<IUserDao>();
            User user = new User()
            {
                Name = "Олег",
                LastName = "Арзямов",
                EMail = "Oleg@mail.ru",
                Password = "q1w2e3r"
            };
            byte[] data = user.Password.Select(x => (byte)x).ToArray();
            byte[] result;
            using (SHA512 shaM = SHA512.Create())
            {
                result = shaM.ComputeHash(data);
            }
            mock.Setup(item => item.AddUser(user, result.ToList())).Returns(100);

            var logic = new UserLogic(mock.Object);

            int id = logic.AddUser(user);
            Assert.AreEqual(id, 100);
        }
        [TestMethod]
        public void GetUserById()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.GetUserById(1)).Returns(new User());

            var logic = new UserLogic(mock.Object);

            Assert.IsInstanceOfType(logic.GetUserById(1), typeof(User));
        }
        [TestMethod]
        public void GetUsers()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.GetUsers()).Returns(new List<User>());

            var logic = new UserLogic(mock.Object);

            Assert.IsInstanceOfType(logic.GetUsers(), typeof(List<User>));
        }
        [TestMethod]
        public void UpdateUser()
        {
            var mock = new Mock<IUserDao>();
            User user = new User()
            {
                Name = "Oleg",
                LastName = "Arzyamov",
                EMail = "Oleg@mail.ru"
            };
            mock.Setup(item => item.Update(user)).Returns(true);

            var logic = new UserLogic(mock.Object);

            Assert.IsTrue(logic.Update(user));
        }


        [TestMethod]
        public void DeleteUser()
        {
            var mock = new Mock<IUserDao>();

            mock.Setup(item => item.Delete(1)).Returns(true);

            var logic = new UserLogic(mock.Object);

            Assert.IsTrue(logic.Delete(1), "FALSE");
        }


    }
}
