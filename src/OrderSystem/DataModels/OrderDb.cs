using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.DataModels
{
    public class OrderDb
    {
        [Key]
        public int Id { get; set; }
        public Guid Identifier { get; set; }
        public Guid CustomerIdentifier { get; set; }
        public DateTime CreateDate { get; set; }

        public OrderDb()
        {
        }

        public OrderDb(Guid identifier, Guid customerIdentifier, DateTime createDate)
        {
            Identifier = identifier;
            CustomerIdentifier = customerIdentifier;
            CreateDate = createDate;
        }
    }
}
