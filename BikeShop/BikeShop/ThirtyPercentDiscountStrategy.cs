// <copyright file="ThirtyPercentDiscountStrategy.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System.Collections.Generic;
    using System.Linq;

    public class ThirtyPercentDiscountStrategy : DiscountStrategy
    {
        private class InvoiceTotal
        {
            public int TotalQuantity { get; set; }

            public decimal TotalPrice { get; set; }
        }

        public ThirtyPercentDiscountStrategy()
        {
            DiscountFactor = .3m;
        }

        /// <inheritdoc/>
        public override decimal GetDiscount(ISet<InvoiceDetail> dets)
        {
            int factor;
            var restWith3 = dets.Sum(x => x.Quantity) % 3;
            var restWith4 = dets.Sum(x => x.Quantity) % 4;
            var restWith5 = dets.Sum(x => x.Quantity) % 5;

            if (restWith3 < restWith4 && restWith3 < restWith5)
            {
                factor = 3;
            }
            else if (restWith4 < restWith3 && restWith4 < restWith5)
            {
                factor = 4;
            }
            else if (restWith5 < restWith3 && restWith5 < restWith4)
            {
                factor = 5;
            }
            else
            {
                factor = 3;
            }

            var a = dets
                .Aggregate(new InvoiceTotal(),
                (accu, curr) =>
                {
                    accu.TotalPrice += curr.SubTotal;
                    accu.TotalQuantity += curr.Quantity;
                    return accu;
                });

            var rest = a.TotalQuantity % factor;
            var partValue = a.TotalPrice / a.TotalQuantity;

            return (a.TotalQuantity - rest) * partValue * DiscountFactor;
        }
    }
}
