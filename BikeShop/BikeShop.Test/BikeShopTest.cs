using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BikeShop.Test
{
    [TestClass]
    public class BikeShopTest
    {
        private static BikeFactory _fac = new BikeFactory();

        [TestMethod]
        public void CanCreateABikeShop()
        {
            var shop = new BikeShop();

            Assert.IsNotNull(shop);
        }

        [TestMethod]
        public void CanCreateABikeShopWithABike()
        {
            var bike = _fac.Create();
            var shop = new BikeShop(bike);

            Assert.IsNotNull(shop);
            Assert.IsNotNull(shop.Bikes);
            Assert.IsTrue(shop.Bikes.Count() == 1);
        }

        [TestMethod]
        public void CanCreateABikeShopWithSomeBikes()
        {
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);

            Assert.IsNotNull(shop);
            Assert.IsNotNull(shop.Bikes);
            Assert.IsTrue(shop.Bikes.Count() == 3);
        }

        [TestMethod]
        public void CanCreateABikeShopThenAfterReceiveABike()
        {
            var shop = new BikeShop();
            var bike = _fac.Create();

            shop.Receive(bike);

            Assert.IsTrue(shop.Bikes.Count() == 1);
        }

        [TestMethod]
        public void CanCreateABikeShopThenAfterReceiveSomeBikes()
        {
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);

            shop.Receive(bikes);

            Assert.IsTrue(shop.Bikes.Count() == 3);
        }

        [TestMethod]
        public void RentABike()
        {
            var req = new RentRequest();
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);

            var rentedBikes = shop.Rent(req);

            Assert.IsNotNull(rentedBikes);
            Assert.IsTrue(rentedBikes.Count() == 1);
            Assert.IsTrue(shop.Bikes.Count() == 2);
        }

        [TestMethod]
        public void RentSomeBikesWithSpecifiedQuantity()
        {
            var req = new RentRequest(2);
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);

            var rentedBikes = shop.Rent(req);

            Assert.IsNotNull(rentedBikes);
            Assert.IsTrue(rentedBikes.Count() == 2);
            Assert.IsTrue(shop.Bikes.Count() == 1);
        }

        [TestMethod]
        public void ReceiveARentedBike()
        {
            var req = new RentRequest(2);
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);

            var rentedBikes = shop.Rent(req);

            var ret = new RentReturn(rentedBikes);
            
            shop.ReceiveFromRent(ret);
            
            Assert.IsTrue(shop.Bikes.Count() == 3);
        }
    }
}
