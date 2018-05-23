// <copyright file="GenericDiscountStrategy.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System.Collections.Generic;
    using System.Linq;

    public class GenericDiscountStrategy : DiscountStrategy
    {
        public GenericDiscountStrategy(decimal discFactor)
        {
            DiscountFactor = discFactor;
        }

        public override decimal GetDiscount(ISet<InvoiceDetail> dets)
        {
            return dets.Sum(x => x.SubTotal) * DiscountFactor;
        }
    }
}
