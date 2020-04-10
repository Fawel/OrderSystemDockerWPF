using System;

namespace CustomersSystem.Models
{
    public class Customer
    {
        public readonly Guid Uid;

        public Customer(Guid uid,
                        string name,
                        int age,
                        Country country)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name must not be empty", nameof(name));

            Uid = uid;
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public Country Country { get; private set; }
    }
}
