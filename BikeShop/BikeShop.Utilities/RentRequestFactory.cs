// <copyright file="RentRequestFactory.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RentRequestFactory
    {
        public RentRequest Create()
        {
            return new RentRequest();
        }
    }
}
