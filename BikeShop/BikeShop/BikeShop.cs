﻿// <copyright file="BikeShop.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System.Collections.Generic;
    using System.Linq;

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
            Receive(bike);
        }

        public BikeShop(IEnumerable<Bike> bikes)
            : this()
        {
            Receive(bikes);
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

        public void Receive(IEnumerable<Bike> bikes)
        {
            foreach (var bike in bikes)
            {
                Receive(bike);
            }
        }

        public IEnumerable<Bike> Rent(RentRequest req)
        {
            var bikesToTake = _bikes.Take(req.Quantity).ToArray();

            foreach (var bike in bikesToTake)
            {
                _bikes.Remove(bike);
            }

            return bikesToTake;
        }

        public Invoice ReceiveFromRent(RentReturn ret)
        {
            Receive(ret.Bikes);

            var inv = new Invoice();
            inv.AddDetail(ret.AssociatedRentRequest.Strategy, ret.Bikes.Count(), ret.AssociatedRentRequest.Created, ret.Created);

            return inv;
        }
    }
}
