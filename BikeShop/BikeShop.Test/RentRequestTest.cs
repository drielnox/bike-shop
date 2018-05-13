using System;
using BikeShop.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeShop.Test
{
    [TestClass]
    public class RentRequestTest
    {
        private static RentStrategyFactory _fac = new RentStrategyFactory();

        [TestMethod]
        public void CreateARentRequest()
        {
            var req = new RentRequest();

            Assert.IsNotNull(req);
        }

        [TestMethod]
        public void CreateARentRequestWithQuantity()
        {
            var req = new RentRequest(1);

            Assert.IsNotNull(req);
            Assert.IsTrue(req.Quantity == 1);
        }

        [TestMethod]
        public void CreateARentRequestByHour()
        {
            var req = new RentRequest(_fac.CreateByHour());

            Assert.IsNotNull(req);
            Assert.IsTrue(req.Quantity == 1);
            Assert.AreEqual(req.Strategy, _fac.CreateByHour());
        }

        [TestMethod]
        public void CreateARentRequestByDay()
        {
            var req = new RentRequest(_fac.CreateByDay());

            Assert.IsNotNull(req);
            Assert.IsTrue(req.Quantity == 1);
            Assert.AreEqual(req.Strategy, _fac.CreateByDay());
        }

        [TestMethod]
        public void CreateARentRequestByWeek()
        {
            var req = new RentRequest(_fac.CreateByWeek());

            Assert.IsNotNull(req);
            Assert.IsTrue(req.Quantity == 1);
            Assert.AreEqual(req.Strategy, _fac.CreateByWeek());
        }
    }
}
