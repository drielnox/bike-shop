// <copyright file="DayRentStrategy.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System;

    public class DayRentStrategy : RentStrategy
    {
        public DayRentStrategy()
            : base(20)
        {
        }

        /// <inheritdoc/>
        public override int Compute(TimeSpan timeConsumed)
        {
            return (int)Math.Ceiling(timeConsumed.TotalDays) * CostFactor;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is DayRentStrategy && this == (DayRentStrategy)obj;
        }
    }
}
