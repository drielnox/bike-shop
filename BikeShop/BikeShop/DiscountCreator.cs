// <copyright file="DiscountCreator.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    public static class DiscountCreator
    {
        public static DiscountStrategy CreateStrategy(decimal discountFactor)
        {
            return new GenericDiscountStrategy(discountFactor);
        }

        public static DiscountStrategy CreateNoDiscountStrategy()
        {
            return new NoDiscountStrategy();
        }

        public static DiscountStrategy CreateThirtyPercentDiscountStrategy()
        {
            return new ThirtyPercentDiscountStrategy();
        }
    }
}
