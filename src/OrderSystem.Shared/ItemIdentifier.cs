using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem.Shared
{
    public class ItemIdentifier
    {
        public readonly int Id;
        public readonly Guid Identifier;
        public readonly string Name;
        public readonly ItemType Type;
        public readonly TimeSpan ExpireAfter;
        public readonly bool CanExpire;
    }

    public enum ItemType
    {
        Food,
        Cloth,
        Other
    }
}
