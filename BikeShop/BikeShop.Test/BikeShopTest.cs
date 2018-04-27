using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BikeShop.Test
{
    [TestClass]
    public class BikeShopTest
    {
        [TestMethod]
        public void CanCreateABikeShop()
        {
            var shop = new BikeShop();

            Assert.IsNotNull(shop);
        }

        [TestMethod]
        public void CanCreateABikeShopWithABike()
        {
            var bike = new Bike();
            var shop = new BikeShop(bike);

            Assert.IsNotNull(shop);
            Assert.IsNotNull(shop.Bikes);
            Assert.IsTrue(shop.Bikes.Count() == 1);
        }

        [TestMethod]
        public void CanCreateABikeShopWithSomeBikes()
        {
            var bikes = new Bike[] 
            {
                new Bike(),
                new Bike(),
                new Bike()
            };
            var shop = new BikeShop(bikes);

            Assert.IsNotNull(shop);
            Assert.IsNotNull(shop.Bikes);
            Assert.IsTrue(shop.Bikes.Count() == 3);
        }
    }
}
