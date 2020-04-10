using System;
using System.Collections.Generic;
using System.Text;

namespace OrderSystem.Shared
{
    public class Item
    {
        public readonly int Id;
        public readonly Guid Identifier;
        public readonly string Name;
        public readonly ItemType Type;
    }

    public enum ItemType
    {
        Food,
        Cloth,
        Other
    }
}
