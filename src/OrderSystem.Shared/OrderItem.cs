using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem.Shared
{
    public class OrderItem
    {
        public readonly OrderIdentifier Order;
        public readonly Item Item;
        public readonly int OrderItemPrice;
    }
}
