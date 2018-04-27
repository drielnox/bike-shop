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
        public enum RentMode
        {
            Hour,
            Day,
            Week
        }

        internal readonly int _quantity;
        private RentMode _hour;

        public int Quantity
        {
            get
            {
                return _quantity;
            }
        }

        public RentMode Mode
        {
            get
            {
                return _hour;
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

        public RentRequest(RentMode mode)
            : this(1)
        {
            _hour = mode;
        }
    }
}
