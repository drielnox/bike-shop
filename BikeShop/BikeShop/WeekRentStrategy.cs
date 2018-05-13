// <copyright file="WeekRentStrategy.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System;

    public class WeekRentStrategy : RentStrategy
    {
        public WeekRentStrategy()
            : base(60)
        {
        }

        /// <inheritdoc/>
        public override int Compute(TimeSpan timeConsumed)
        {
            return (int)Math.Ceiling(timeConsumed.TotalDays / 7) * CostFactor;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is WeekRentStrategy && this == (WeekRentStrategy)obj;
        }
    }
}
