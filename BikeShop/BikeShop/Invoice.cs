// <copyright file="Invoice.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Invoice
    {
        public ISet<InvoiceDetail> Details { get; private set; }

        public decimal Total
        {
            get
            {
                DiscountStrategy discStr;

                if (Details.Sum(x => x.Quantity) > 3)
                {
                    discStr = new ThirtyPercentDiscountStrategy();
                }
                else
                {
                    discStr = new NoDiscountStrategy();
                }

                return Details.Sum(x => x.SubTotal) - discStr.GetDiscount(Details);
            }
        }

        public Invoice()
        {
            Details = new HashSet<InvoiceDetail>();
        }

        internal void AddDetail(RentStrategy strategy, int quantity, DateTime start, DateTime end)
        {
            var det = new InvoiceDetail(strategy, quantity, start, end);

            if (Details.Contains(det))
            {
                throw new InvalidOperationException("The detail exist en the invoice.");
            }

            Details.Add(det);
        }
    }
}
