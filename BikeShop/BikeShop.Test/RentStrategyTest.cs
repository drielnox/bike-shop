using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeShop.Test
{
    [TestClass]
    public class RentStrategyTest
    {
        [TestMethod]
        public void CreateAHourRentStrategy()
        {
            var rentStr = new HourRentStrategy();

            Assert.IsNotNull(rentStr);
        }

        [TestMethod]
        public void CreateADayRentStrategy()
        {
            var rentStr = new DayRentStrategy();

            Assert.IsNotNull(rentStr);
        }

        [TestMethod]
        public void CreateAWeekRentStrategy()
        {
            var rentStr = new WeekRentStrategy();

            Assert.IsNotNull(rentStr);
        }
    }
}
