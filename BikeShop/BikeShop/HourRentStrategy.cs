// <copyright file="HourRentStrategy.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System;

    public class HourRentStrategy : RentStrategy
    {
        public HourRentStrategy()
            : base(5)
        {
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is HourRentStrategy && this == (HourRentStrategy)obj;
        }

        /// <inheritdoc/>
        protected override int TimeRounding(TimeSpan time)
        {
            var truncatedHours = Math.Truncate(time.TotalHours);
            return (int)(truncatedHours < 1 ? 1 : truncatedHours);
        }
    }
}
