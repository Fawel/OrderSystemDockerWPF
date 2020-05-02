using OrderSystem.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.DataModels
{
    public class ItemDb
    {
        [Key]
        public int Id { get; set; }
        public Guid Identifier { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public TimeSpan ExpireAfter { get; set; }
        public bool CanExpire { get; set; }
    }
}
