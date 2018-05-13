using System;
using System.Linq;
using BikeShop.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeShop.Test
{
    [TestClass]
    public class RentReturnTest
    {
        private static BikeFactory _fac = new BikeFactory();
        private static RentRequestFactory _fac2 = new RentRequestFactory();

        [TestMethod]
        public void CreateARentReturnWithABike()
        {
            var bike = _fac.Create();
            var req = _fac2.Create();
            var ret = new RentReturn(req, bike);

            Assert.IsNotNull(ret);
            Assert.IsTrue(ret.Bikes.Count() == 1);
        }
    }
}
