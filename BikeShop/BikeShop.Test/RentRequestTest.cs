using System;
using System.Collections.Generic;
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

        [TestMethod]
        public void ARentRequestIsEqualsToTheSameRentRequest()
        {
            var req = new RentRequest();

            Assert.AreEqual(req, req);
        }

        [TestMethod]
        public void ARentRequestIsEqualsToTheAnotherInstanceOfSameRentRequest()
        {
            var req1 = new RentRequest();
            var req2 = new RentRequest();

            Assert.AreEqual(req1, req2);
        }

        [TestMethod]
        public void ARentRequestIsNotEqualsToAnotherRentRequest()
        {
            var req1 = new RentRequest();
            var req2 = new RentRequest(_fac.CreateByDay());

            Assert.AreNotEqual(req1, req2);
        }

        [TestMethod]
        public void ASetOfRentRequestAreEqualsToSameSetOfRentRequest()
        {
            var req1 = new RentRequest();
            var req2 = new RentRequest();

            var s1 = new HashSet<RentRequest>(new[] { req1, req2 });
            var s2 = new HashSet<RentRequest>(new[] { req1, req2 });

            Assert.IsTrue(s1.SetEquals(s2));
        }
    }
}
