// <copyright file="RentStrategyFactory.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop.Utilities
{
    public class RentStrategyFactory
    {
        public RentStrategy CreateByHour()
        {
            return new HourRentStrategy();
        }

        public RentStrategy CreateByDay()
        {
            return new DayRentStrategy();
        }

        public RentStrategy CreateByWeek()
        {
            return new WeekRentStrategy();
        }
    }
}
