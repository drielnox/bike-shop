// <copyright file="BikeShop.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BikeShop
    {
        private HashSet<Bike> _bikes;

        public BikeShop()
        {
            _bikes = new HashSet<Bike>();
        }

        public BikeShop(Bike bike)
            : this()
        {
            _bikes.Add(bike);
        }

        public BikeShop(Bike[] bikes)
            : this()
        {
            foreach (var bike in bikes)
            {
                _bikes.Add(bike);
            }
        }

        public IEnumerable<Bike> Bikes
        {
            get
            {
                return _bikes;
            }
        }

        public void Receive(Bike bike)
        {
            _bikes.Add(bike);
        }
    }
}
