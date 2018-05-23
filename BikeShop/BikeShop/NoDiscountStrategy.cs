// <copyright file="NoDiscountStrategy.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System.Collections.Generic;

    public class NoDiscountStrategy : DiscountStrategy
    {
        public NoDiscountStrategy()
        {
            DiscountFactor = 0;
        }

        /// <inheritdoc/>
        public override decimal GetDiscount(ISet<InvoiceDetail> dets)
        {
            return DiscountFactor;
        }
    }
}
