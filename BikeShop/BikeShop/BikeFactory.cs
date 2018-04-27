// <copyright file="BikeFactory.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System.Collections.Generic;

    public class BikeFactory
    {
        public Bike Create()
        {
            return new Bike();
        }

        public IEnumerable<Bike> Create(int quantity)
        {
            Bike[] bikes = new Bike[quantity];

            for (int index = 0; index < quantity; index++)
            {
                bikes[index] = Create();
            }

            return bikes;
        }
    }
}
