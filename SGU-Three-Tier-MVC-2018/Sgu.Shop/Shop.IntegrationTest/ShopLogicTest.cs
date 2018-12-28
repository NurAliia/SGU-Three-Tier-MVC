using System;
using Sgu.StudentTesting.DAL.Contracts;
using Sgu.StudentTesting;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sgu.StudentTesting.Config;
using Ninject;
using Sgu.StudentTesting.BLL.Contracts;

namespace ShopRate.IntegrationTest
{
    [TestClass]
    public class ShopLogicTest
    {
        private static IShopLogic logic;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            var kernel = new StandardKernel();
            Config.RegisterServices(kernel);
            logic = kernel.Get<IShopLogic>();
        }

        [TestMethod]
        public void AddShop()
        {
            var oldShop = new Common.Shop()
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

            int id = logic.AddShop(oldShop);

            var shop = logic.GetShopById(id);
            Assert.IsNotNull(shop, "Shop is null");
            Assert.AreEqual(Common.Shop.ToString(oldShop), Common.Shop.ToString(shop), "Не совпали названия магазинов при добавлении");
        }

        [TestMethod]
        public void Update()
        {
            var oldShop = new Common.Shop()
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
            int id = logic.AddShop(oldShop);

            Common.Shop shop = logic.GetShopById(id);
            shop.NameShop = "For update";

            logic.Update(shop);

            Assert.AreEqual(Common.Shop.ToString(logic.GetShopById(id)), Common.Shop.ToString(shop),
                "Adding data about shop incorrect");
            logic.DeleteById(id);
        }

        [TestMethod]
        public void GetShops()
        {
            
            var oldShop = new Common.Shop()
            {
                NameShop = "Lime",
                PhoneShop = "+7909323232",
                City = "Saratov"
            };

            int id = logic.AddShop(oldShop);
            var shops = logic.GetShops();

            Assert.IsNotNull(shops.GetEnumerator());
            int count = 0;
            foreach (Common.Shop s in shops)
            {
                count++;
            }
            Assert.AreEqual(count, 1);
        }
    }
}
