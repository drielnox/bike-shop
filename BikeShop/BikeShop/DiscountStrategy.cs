﻿// <copyright file="DiscountStrategy.cs" company="Bike Shop">
// Copyright (c) Bike Shop. All rights reserved.
// </copyright>

namespace BikeShop
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class DiscountStrategy
    {
        public abstract decimal GetDiscount(ISet<InvoiceDetail> dets);
    }
}
