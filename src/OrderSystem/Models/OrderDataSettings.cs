using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Models
{
    public interface IOrderDataSettings
    {
        string ConnectionString { get; set; }
        string DbName { get; set; }
    }

    public class OrderDataSettings : IOrderDataSettings
    {
        public string ConnectionString { get; set; }
        public string DbName { get; set; }
    }
}
