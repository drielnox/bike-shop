using System;
using System.Linq;
using BikeShop.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BikeShop.Test
{
    [TestClass]
    public class InvoiceTest
    {
        private static RentStrategyFactory _fac = new RentStrategyFactory();

        [TestMethod]
        public void CreateAInvoice()
        {
            var inv = new Invoice();

            Assert.IsNotNull(inv);
            Assert.IsNotNull(inv.Details);
            Assert.IsTrue(inv.Details.Count() == 0);
            Assert.IsTrue(inv.Total == 0);
        }

        [TestMethod]
        public void CreateAInvoiceWithADetail()
        {
            var invdet = new InvoiceDetail(_fac.CreateByHour(), 1, DateTime.Now, DateTime.Now.AddHours(1));
            var inv = new Invoice(invdet);

            Assert.IsNotNull(inv);
            Assert.IsNotNull(inv.Details);
            Assert.IsTrue(inv.Details.Count() == 1);
            Assert.AreEqual(inv.Details.Single(), invdet);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateAInvoiceWithTwoSameDetails()
        {
            var invdet1 = new InvoiceDetail(_fac.CreateByHour(), 1, DateTime.Now, DateTime.Now.AddHours(1));
            var invdet2 = new InvoiceDetail(_fac.CreateByHour(), 1, DateTime.Now, DateTime.Now.AddHours(1));
            var inv = new Invoice(new[] { invdet1, invdet2 });

            Assert.Fail("Isn't allowed two same details.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CreateAInvoiceWithTwoDifferentsDetails()
        {
            var invdet1 = new InvoiceDetail(_fac.CreateByHour(), 1, DateTime.Now, DateTime.Now.AddHours(1));
            var invdet2 = new InvoiceDetail(_fac.CreateByDay(), 1, DateTime.Now, DateTime.Now.AddDays(1));
            var inv = new Invoice(new[] { invdet1, invdet2 });

            Assert.IsNotNull(inv);
            Assert.IsNotNull(inv.Details);
            Assert.IsTrue(inv.Details.Count() == 2);
            Assert.AreEqual(inv.Details.SingleOrDefault(x => x == invdet1), invdet1);
            Assert.AreEqual(inv.Details.SingleOrDefault(x => x == invdet2), invdet2);
        }
    }
}
