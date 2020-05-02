using System;
using System.Collections.Generic;

namespace OrderSystem.Shared
{
    public class Customer
    {
        public readonly int Id;
        public readonly IReadOnlyCollection<OrderIdentifier> Orders;
    }
}
