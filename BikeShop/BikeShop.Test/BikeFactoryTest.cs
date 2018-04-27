using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeShop.Test
{
    [TestClass]
    public class BikeFactoryTest
    {
        [TestMethod]
        public void CreateABikeFactory()
        {
            var fac = new BikeFactory();

            Assert.IsNotNull(fac);
        }

        [TestMethod]
        public void CreateABikeFromBikeFactory()
        {
            var fac = new BikeFactory();

            var bike = fac.Create();

            Assert.IsNotNull(bike);
        }
    }
}
