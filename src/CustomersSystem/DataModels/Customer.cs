using CustomersSystem.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomersSystem.DataModels
{
    public class Customer
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Country Country { get; private set; }
        public string Uid;

        public Customer(Guid uid, string name, int age, Country country)
        {
            Name = name;
            Age = age;
            Country = country;
            Uid = uid.ToString();
        }

        public Customer()
        {
        }
    }
}
