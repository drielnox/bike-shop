﻿// <copyright file="HourRentStrategy.cs" company="Bike Shop">
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
        public override int Compute(TimeSpan timeConsumed)
        {
            return (int)Math.Ceiling(timeConsumed.TotalHours) * CostFactor;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is HourRentStrategy && this == (HourRentStrategy)obj;
        }
    }
}
