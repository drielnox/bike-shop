// <copyright file="RentRequest.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System;

    public class RentRequest
    {
        public int Quantity { get; }

        public RentStrategy Strategy { get; }

        public DateTime Created { get; }

        public RentRequest(int quantity, RentStrategy strategy, DateTime created)
        {
            Quantity = quantity;
            Strategy = strategy;
            Created = created;
        }

        public RentRequest(int quantity, RentStrategy strategy)
            : this(quantity, strategy, DateTime.Now)
        {
        }

        public RentRequest(RentStrategy strategy)
            : this(1, strategy, DateTime.Now)
        {
        }

        public RentRequest(int quantity)
            : this(quantity, new HourRentStrategy(), DateTime.Now)
        {
        }

        public RentRequest()
            : this(1, new HourRentStrategy(), DateTime.Now)
        {
        }

        public static bool operator ==(RentRequest a, RentRequest b)
        {
            return a.Quantity == b.Quantity
                && a.Strategy == b.Strategy
                && a.Created == b.Created;
        }

        public static bool operator !=(RentRequest a, RentRequest b)
        {
            return !(a == b);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is RentRequest && this == (RentRequest)obj;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Quantity.GetHashCode()
                ^ Strategy.GetHashCode()
                ^ Created.GetHashCode();
        }
    }
}
