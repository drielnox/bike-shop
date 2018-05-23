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
        public override bool Equals(object obj)
        {
            return obj is WeekRentStrategy && this == (WeekRentStrategy)obj;
        }

        /// <inheritdoc/>
        protected override int TimeRounding(TimeSpan time)
        {
            var truncatedDays = Math.Truncate(time.TotalDays);
            return (int)(truncatedDays / 7 < 1 ? 1 : Math.Round(truncatedDays / 7));
        }
    }
}
