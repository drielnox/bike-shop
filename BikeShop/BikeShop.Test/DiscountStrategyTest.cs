using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeShop.Test
{
    [TestClass]
    public class DiscountStrategyTest
    {
        [TestMethod]
        public void CreateANoDiscontStrategy()
        {
            var dis = new NoDiscountStrategy();

            Assert.IsNotNull(dis);
        }

        [TestMethod]
        public void CreateAThirtyPercentDiscountStrategy()
        {
            var dis = new ThirtyPercentDiscountStrategy();

            Assert.IsNotNull(dis);
        }
    }
}
