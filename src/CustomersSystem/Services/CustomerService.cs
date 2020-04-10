using CustomersSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Threading.Tasks.Sources;
using Microsoft.Extensions.Logging;

namespace CustomersSystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<DataModels.Customer> _dbCustomers;
        public readonly ILogger<CustomerService> _logger;
        public CustomerService(ICustomerDatabaseSettings customerDatabaseSettings, ILogger<CustomerService> logger)
        {
            if (customerDatabaseSettings is null)
            {
                throw new ArgumentNullException(nameof(customerDatabaseSettings));
            }

            var mongoClient = new MongoClient(customerDatabaseSettings.ConnectionString);
            var database = mongoClient.GetDatabase(customerDatabaseSettings.DatabaseName);
            _dbCustomers = database.GetCollection<DataModels.Customer>(customerDatabaseSettings.CustomerCollectionName);
            _logger = logger;
        }

        public void AddCustomer(NewCustomer newCustomer)
        {
            var customer = new DataModels.Customer(Guid.NewGuid(), newCustomer.Name, newCustomer.Age, newCustomer.Country);
            _dbCustomers.InsertOne(customer);
        }

        public ValueTask AddCustomerAsync(NewCustomer newCustomer, CancellationToken token = default)
        {
            var customer = new DataModels.Customer(Guid.NewGuid(), newCustomer.Name, newCustomer.Age, newCustomer.Country);
            _dbCustomers.InsertOne(customer, cancellationToken:token);
            return new ValueTask();
        }

        public void DeleteCustomer(Guid uid)
        {
            _dbCustomers.FindOneAndDelete(x => x.Uid == uid.ToString());
        }

        public ValueTask DeleteCustomerAsync(Guid uid, CancellationToken token = default)
        {
            _dbCustomers.FindOneAndDeleteAsync(x => x.Uid == uid.ToString(), cancellationToken:token);
            return new ValueTask();
        }

        public Customer GetCustomer(Guid uid)
        {
            var dbCustomer = _dbCustomers.Find(x => x.Uid == uid.ToString()).FirstOrDefault();
            if (dbCustomer is null)
                return null;

            var customer = new Customer(Guid.Parse(dbCustomer.Uid), dbCustomer.Name, dbCustomer.Age, dbCustomer.Country);
            return customer;
        }

        public async ValueTask<Customer> GetCustomerAsync(Guid uid, CancellationToken token = default)
        {
            var dbCustomer = await _dbCustomers.Find(x => x.Uid == uid.ToString()).FirstOrDefaultAsync(token);
            if (dbCustomer is null)
                return null;

            var customer = new Customer(Guid.Parse(dbCustomer.Uid), dbCustomer.Name, dbCustomer.Age, dbCustomer.Country);
            return customer;
        }
    }
}
