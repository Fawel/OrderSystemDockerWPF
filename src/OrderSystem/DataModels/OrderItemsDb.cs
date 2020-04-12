using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.DataModels
{
    public class OrderItemsDb
    {
        [Key]
        public int Id { get; set; }
    }
}
