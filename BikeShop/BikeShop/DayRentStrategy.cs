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
        public override bool Equals(object obj)
        {
            return obj is DayRentStrategy && this == (DayRentStrategy)obj;
        }

        /// <inheritdoc/>
        protected override int TimeRounding(TimeSpan time)
        {
            var trunDate = Math.Truncate(time.TotalDays);
            return (int)(trunDate < 1 ? 1 : trunDate);
        }
    }
}
