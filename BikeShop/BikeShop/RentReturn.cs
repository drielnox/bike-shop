// <copyright file="RentReturn.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RentReturn
    {
        private HashSet<Bike> _bikes;

        public IEnumerable<Bike> Bikes
        {
            get
            {
                return _bikes;
            }
        }

        private RentReturn()
        {
            _bikes = new HashSet<Bike>();
        }

        public RentReturn(Bike bike)
            : this()
        {
            Add(bike);
        }

        public RentReturn(IEnumerable<Bike> bikes)
            : this()
        {
            AddRange(bikes);
        }

        public void Add(Bike bike)
        {
            _bikes.Add(bike);
        }

        public void AddRange(IEnumerable<Bike> bikes)
        {
            foreach (var bike in bikes)
            {
                Add(bike);
            }
        }
    }
}
