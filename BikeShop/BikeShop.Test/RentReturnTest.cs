using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeShop.Test
{
    [TestClass]
    public class RentReturnTest
    {
        private static BikeFactory _fac = new BikeFactory();

        [TestMethod]
        public void CreateARentReturnWithABike()
        {
            var bike = _fac.Create();
            var ret = new RentReturn(bike);

            Assert.IsNotNull(ret);
            Assert.IsTrue(ret.Bikes.Count() == 1);
        }
    }
}
