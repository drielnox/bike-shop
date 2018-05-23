using BikeShop.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BikeShop.Test
{
    [TestClass]
    public class BikeShopTest
    {
        private static BikeFactory _fac = new BikeFactory();
        private static RentStrategyFactory _fac2 = new RentStrategyFactory();

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
        public void RentABikeByHour()
        {
            var req = new RentRequest(_fac2.CreateByHour());
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);

            var rentedBikes = shop.Rent(req);

            Assert.IsTrue(rentedBikes.Count() == 1);
            Assert.IsTrue(shop.Bikes.Count() == 2);
        }

        [TestMethod]
        public void ReceiveARentedBike()
        {
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(2);

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes);
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(shop.Bikes.Count() == 3);
        }

        [TestMethod]
        public void ReceiveARentedBikesByHourOneHourAgo()
        {
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(2);

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddHours(1));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 10);
        }

        [TestMethod]
        public void ReceiveARentedBikesByDayOneHourAgo()
        {
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(2, _fac2.CreateByDay());

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddHours(1));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 40);
        }

        [TestMethod]
        public void ReceiveARentedBikesByWeekOneHourAgo()
        {
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(2, _fac2.CreateByWeek());

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddHours(1));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 120);
        }

        [TestMethod]
        public void ReceiveARentedBikesByHourOneDayAgo()
        {
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(2);

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddDays(1));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 240);
        }

        [TestMethod]
        public void ReceiveARentedBikesByDayOneDayAgo()
        {
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(2, _fac2.CreateByDay());

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddDays(1));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 40);
        }

        [TestMethod]
        public void ReceiveARentedBikesByWeekOneDayAgo()
        {
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(2, _fac2.CreateByWeek());

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddDays(1));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 120);
        }

        [TestMethod]
        public void ReceiveARentedBikesByHourOneWeekAgo()
        {
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(2);

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddDays(7));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 1680);
        }

        [TestMethod]
        public void ReceiveARentedBikesByDayOneWeekAgo()
        {
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(2, _fac2.CreateByDay());

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddDays(7));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 280);
        }

        [TestMethod]
        public void ReceiveARentedBikesByWeekOneWeekAgo()
        {
            var bikes = _fac.Create(3);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(2, _fac2.CreateByWeek());

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddDays(7));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 120);
        }

        [TestMethod]
        public void ReceiveARentedFamilyBikesByHourOneHourAgo()
        {
            var bikes = _fac.Create(6);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(5);

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddHours(1));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 17.5m);
        }

        [TestMethod]
        public void ReceiveARentedFamilyBikesByDayOneHourAgo()
        {
            var bikes = _fac.Create(6);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(5, _fac2.CreateByDay());

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddHours(1));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 70);
        }

        [TestMethod]
        public void ReceiveARentedFamilyBikesByWeekOneHourAgo()
        {
            var bikes = _fac.Create(6);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(5, _fac2.CreateByWeek());

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddHours(1));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 210);
        }

        [TestMethod]
        public void ReceiveARentedFamilyBikesByHourOneDayAgo()
        {
            var bikes = _fac.Create(6);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(5);

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddDays(1));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 420);
        }

        [TestMethod]
        public void ReceiveARentedFamilyBikesByDayOneDayAgo()
        {
            var bikes = _fac.Create(6);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(5, _fac2.CreateByDay());

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddDays(1));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 70);
        }

        [TestMethod]
        public void ReceiveARentedFamilyBikesByWeekOneDayAgo()
        {
            var bikes = _fac.Create(6);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(5, _fac2.CreateByWeek());

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddDays(1));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 210);
        }

        [TestMethod]
        public void ReceiveARentedFamilyBikesByHourOneWeekAgo()
        {
            var bikes = _fac.Create(6);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(5);

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddDays(7));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 2940);
        }

        [TestMethod]
        public void ReceiveARentedFamilyBikesByDayOneWeekAgo()
        {
            var bikes = _fac.Create(6);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(5, _fac2.CreateByDay());

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddDays(7));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 490);
        }

        [TestMethod]
        public void ReceiveARentedFamilyBikesByWeekOneWeekAgo()
        {
            var bikes = _fac.Create(6);
            var shop = new BikeShop(bikes);
            var req = new RentRequest(5, _fac2.CreateByWeek());

            var rentedBikes = shop.Rent(req);
            var ret = new RentReturn(req, rentedBikes, DateTime.Now.AddDays(7));
            var inv = shop.ReceiveFromRent(ret);

            Assert.IsNotNull(inv);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.IsTrue(inv.Total == 210);
        }
    }
}
