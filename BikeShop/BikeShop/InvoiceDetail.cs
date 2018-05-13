// <copyright file="InvoiceDetail.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System;

    public class InvoiceDetail
    {
        public int Quantity { get; private set; }

        public RentStrategy Strategy { get; private set; }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        public int SubTotal
        {
            get
            {
                return Quantity * Strategy.Compute(TimeConsumed);
            }
        }

        public TimeSpan TimeConsumed
        {
            get
            {
                return End - Start;
            }
        }

        private InvoiceDetail()
        {
        }

        public InvoiceDetail(RentStrategy strategy, int quantity, DateTime start, DateTime end)
            : this()
        {
            Strategy = strategy;
            Quantity = quantity;
            Start = start;
            End = end;
        }
    }
}