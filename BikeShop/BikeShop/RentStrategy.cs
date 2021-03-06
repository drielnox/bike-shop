﻿// <copyright file="RentStrategy.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System;

    public abstract class RentStrategy
    {
        protected int CostFactor { get; }

        protected RentStrategy(int costFactor)
        {
            CostFactor = costFactor;
        }

        public static bool operator ==(RentStrategy a, RentStrategy b)
        {
            return a.CostFactor == b.CostFactor;
        }

        public static bool operator !=(RentStrategy a, RentStrategy b)
        {
            return !(a == b);
        }

        public virtual int Compute(TimeSpan timeConsumed)
        {
            return TimeRounding(timeConsumed) * CostFactor;
        }

        public override int GetHashCode()
        {
            return CostFactor.GetHashCode();
        }

        protected abstract int TimeRounding(TimeSpan time);
    }
}
