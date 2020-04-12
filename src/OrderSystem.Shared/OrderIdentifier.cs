using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem.Shared
{
    public class OrderIdentifier
    {
        public readonly int Id;
        public readonly Guid Identifier;
        public readonly Guid CustomerIdentifier;

        public OrderIdentifier(int id, Guid identifier, Guid customerIdentifier)
        {
            Id = id;
            Identifier = identifier;
            CustomerIdentifier = customerIdentifier;
        }
    }
}
