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
            BikeShop shop = new BikeShop();

            Assert.IsNotNull(shop);
        }

        [TestMethod]
        public void CanCreateABikeShopWithABike()
        {
            Bike bike = new Bike();
            BikeShop shop = new BikeShop(bike);

            Assert.IsNotNull(shop);
            Assert.IsNotNull(shop.Bikes);
            Assert.IsTrue(shop.Bikes.Count() > 0);
        }
    }
}
