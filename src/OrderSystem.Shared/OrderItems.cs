using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem.Shared
{
    public class OrderItems
    {
        public readonly Order Order;
        public readonly IEnumerable<Item> Items;
    }
}
