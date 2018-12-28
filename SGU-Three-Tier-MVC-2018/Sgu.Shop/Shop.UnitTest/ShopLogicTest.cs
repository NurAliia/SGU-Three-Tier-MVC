using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sgu.StudentTesting.DAL.Contracts;
using Common;
using Sgu.StudentTesting.BLL;
using System.Collections.Generic;
using System.Linq;

namespace ShopRate.UnitTest
{
    [TestClass]
    public class ShopLogicTest
    {
        [TestMethod]
        public void AddShop()
        {
            var mock = new Mock<IShopDao>();
            mock.Setup(item => item.AddShop(It.IsAny<Shop>())).Returns(100);
            var logic = new ShopLogic(mock.Object);
            var shop = new Shop()
            {
                NameShop = "Lime",
                Address = "Зарубина",
                DescriptionShop = "Кафе",
                Website = "lime.ru",
                Rating = 0,
                PhoneShop = "+7909323232",
                City = "Saratov",
                OpeningHours = "9:00-21:00"
            };
            int id = logic.AddShop(shop);
            Assert.AreEqual(id, 100, "Id is not equal");
        }

        [TestMethod]
        public void UpdateShop()
        {
            var mock = new Mock<IShopDao>();
            mock.Setup(item => item.GetShopById(It.Is<int>(v => v == 1))).Returns(
                new Shop
                {
                    IDShop = 1,
                    NameShop = "Lime",
                    Address = "Зарубина",
                    DescriptionShop = "Кафе",
                    Website = "lime.ru",
                    Rating = 0,
                    PhoneShop = "+7909323232",
                    City = "Saratov",
                    OpeningHours = "9:00-21:00"
                });
            var logic = new ShopLogic(mock.Object);

            mock.Setup(item => item.Update(It.IsAny<Shop>()));

            Assert.AreEqual(true, logic.Update(
                 new Shop
                 {
                     IDShop = 1,
                     NameShop = "Lime",
                     Address = "Зарубина",
                     DescriptionShop = "Кафе",
                     Website = "lime.ru",
                     Rating = 0,
                     PhoneShop = "+7909323232",
                     City = "Moscow",
                     OpeningHours = "9:00-21:00"
                 }), "Method Update doesn't work");
        }

        [TestMethod]
        public void DeleteShop()
        {
            var mock = new Mock<IShopDao>();
            mock.Setup(item => item.GetShopById(It.Is<int>(v => v == 1))).Returns(
                new Shop
                {
                    IDShop = 1,
                    NameShop = "Lime",
                    Address = "Зарубина",
                    DescriptionShop = "Кафе",
                    Website = "lime.ru",
                    Rating = 0,
                    PhoneShop = "+7909323232",
                    City = "Saratov",
                    OpeningHours = "9:00-21:00"
                });
            var logic = new ShopLogic(mock.Object);

            mock.Setup(item => item.DeleteById(It.IsAny<int>()));
            
            Assert.AreEqual(true, logic.DeleteById(1), "Method Delete doesn't work");
        }

        [ExpectedException(typeof(Exception), "Shop with this ID is exist. Method Delete")]
        [TestMethod]
        public void DeleteShopWithException()
        {
            var mock = new Mock<IShopDao>();
            mock.Setup(item => item.GetShopById(It.Is<int>(v => v == 1))).Returns(
                new Shop
                {
                    IDShop = 1,
                    NameShop = "Lime",
                    Address = "Зарубина",
                    DescriptionShop = "Кафе",
                    Website = "lime.ru",
                    Rating = 0,
                    PhoneShop = "+7909323232",
                    City = "Saratov",
                    OpeningHours = "9:00-21:00"
                });
            var logic = new ShopLogic(mock.Object);

            mock.Setup(item => item.DeleteById(It.IsAny<int>()));

            Assert.AreEqual(true, logic.DeleteById(20), "Method Delete doesn't work");
        }


        [TestMethod]
        public void GetShops()
        {
            var mock = new Mock<IShopDao>();
            mock.Setup(item => item.GetShops()).Returns(new List<Shop>()
            {
                new Shop()
                {
                    NameShop = "Lime",
                    Address = "Зарубина",
                    DescriptionShop = "Кафе",
                    Website = "lime.ru",
                    Rating = 0,
                    PhoneShop = "+7909323232",
                    City = "Saratov",
                    OpeningHours = "9:00-21:00"
                }
            });
            var logic = new ShopLogic(mock.Object);
            var shops = logic.GetShops().ToList();
            Assert.AreEqual(shops.Count, 1);
        }
    }
}
