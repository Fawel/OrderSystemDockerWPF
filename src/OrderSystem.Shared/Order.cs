using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderSystem.Shared
{
    public class Order
    {
        public readonly OrderIdentifier OrderId;
        public readonly IEnumerable<OrderItem> OrderItems;
    }
}
