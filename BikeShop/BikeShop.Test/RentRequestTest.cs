using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeShop.Test
{
    [TestClass]
    public class RentRequestTest
    {
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
            var req = new RentRequest(RentRequest.RentMode.Hour);

            Assert.IsNotNull(req);
            Assert.IsTrue(req.Quantity == 1);
            Assert.IsTrue(req.Mode == RentRequest.RentMode.Hour);
        }

        [TestMethod]
        public void CreateARentRequestByDay()
        {
            var req = new RentRequest(RentRequest.RentMode.Day);

            Assert.IsNotNull(req);
            Assert.IsTrue(req.Quantity == 1);
            Assert.IsTrue(req.Mode == RentRequest.RentMode.Day);
        }

        [TestMethod]
        public void CreateARentRequestByWeek()
        {
            var req = new RentRequest(RentRequest.RentMode.Week);

            Assert.IsNotNull(req);
            Assert.IsTrue(req.Quantity == 1);
            Assert.IsTrue(req.Mode == RentRequest.RentMode.Week);
        }
    }
}
