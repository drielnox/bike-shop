// <copyright file="RentRequest.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RentRequest
    {
        internal readonly int _quantity;

        public int Quantity
        {
            get
            {
                return _quantity;
            }
        }

        public RentRequest()
            : this(1)
        {
        }

        public RentRequest(int quantity)
        {
            _quantity = quantity;
        }
    }
}
