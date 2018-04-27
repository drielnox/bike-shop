using System;
using System.Linq;
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

        [TestMethod]
        public void CreateSomeBikesFromBikeFactory()
        {
            var fac = new BikeFactory();

            var bikes = fac.Create(3);

            Assert.IsNotNull(bikes);
            Assert.IsTrue(bikes.Count() == 3);
        }
    }
}
