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

        public DateTime Created { get; }

        public RentRequest AssociatedRentRequest { get; }

        private RentReturn(DateTime created)
        {
            _bikes = new HashSet<Bike>();

            Created = created;
        }

        public RentReturn(RentRequest request, Bike bike, DateTime created)
            : this(created)
        {
            AssociatedRentRequest = request;

            Add(bike);
        }

        public RentReturn(RentRequest request, IEnumerable<Bike> bikes, DateTime created)
            : this(created)
        {
            AssociatedRentRequest = request;

            AddRange(bikes);
        }

        public RentReturn(RentRequest request, Bike bike)
            : this(request, bike, DateTime.Now)
        {
        }

        public RentReturn(RentRequest request, IEnumerable<Bike> bikes)
            : this(request, bikes, DateTime.Now)
        {
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
