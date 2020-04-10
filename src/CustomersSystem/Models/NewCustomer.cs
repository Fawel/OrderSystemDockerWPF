using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersSystem.Models
{
    public readonly struct NewCustomer
    {
        public NewCustomer(string name,
                           int age,
                           Country country)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name must not be empty", nameof(name));

            Name = name;
            Age = age;
            Country = country;
        }

        public readonly string Name;
        public readonly int Age;
        public readonly Country Country;
    }
}
