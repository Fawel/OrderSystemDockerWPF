using CustomersSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CustomersSystem.Services
{
    public interface ICustomerService
    {
        Customer GetCustomer(Guid uid);
        ValueTask<Customer> GetCustomerAsync(Guid uid, CancellationToken token = default);
        ValueTask AddCustomerAsync(NewCustomer customer, CancellationToken token = default);
        void AddCustomer(NewCustomer customer);
        ValueTask DeleteCustomerAsync(Guid uid, CancellationToken token = default);
        void DeleteCustomer(Guid uid);
    }
}
