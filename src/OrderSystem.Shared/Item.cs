using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem.Shared
{
    public class Item
    {
        public readonly ItemIdentifier ItemIdentifier;
        public readonly DateTime ProductionDate;
        public readonly int CurrentPrice;

        public DateTime GetExpireDate() 
        {
            if (ItemIdentifier.CanExpire)
                return new DateTime();

            return ProductionDate.Add(ItemIdentifier.ExpireAfter);
        }
    }
}
