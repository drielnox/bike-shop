using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeShop.Test
{
    [TestClass]
    public class BikeShopTest
    {
        [TestMethod]
        public void CanCreateABikeShop()
        {
            BikeShop shop = new BikeShop();

            Assert.IsNotNull(shop);
        }
    }
}
