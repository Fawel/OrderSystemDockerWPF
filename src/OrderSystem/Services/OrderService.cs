using Microsoft.EntityFrameworkCore;
using OrderSystem.DataModels;
using OrderSystem.Models;
using OrderSystem.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderSystem.Services
{
    public interface IOrderService
    {
        Guid CreateOrder(NewOrder newOrderRequest);
        Task<Guid> CreateOrderAsync(NewOrder newOrderRequest, CancellationToken token = default);

        bool IsOrderExist(Guid uid);
        Task<bool> IsOrderExistAsync(Guid uid, CancellationToken token = default);

        Order GetOrder(Guid uid);
        Task<Order> GetOrderAsync(Guid uid, CancellationToken token = default);

        Order GetCustomerOrder(Guid customerUid);
        Task<Order> GetCustomerOrderAsync(Guid customerUid, CancellationToken token = default);

        void DeleteOrder(Guid orderUidToDelete);
        Task DeleteOrderAsync(Guid orderUidToDelete, CancellationToken token = default);

        void UpdateOrder(Guid uidToUpdate,
                         ReadOnlySpan<ItemIdentifier> itemsToAdd,
                         ReadOnlySpan<ItemIdentifier> itemsToRemove);
    }

    public class OrderService : IOrderService
    {
        private readonly OrderDbContext _orderDb;

        public OrderService(OrderDbContext orderDb)
        {
            _orderDb = orderDb;
        }

        public Guid CreateOrder(NewOrder newOrderRequest)
        {
            var dbOrder = new OrderDb(newOrderRequest.OrderUid, newOrderRequest.CustomerUid, newOrderRequest.OrderCreateRequestDate);
            _orderDb.Orders.Add(dbOrder);
            _orderDb.SaveChanges();

            return newOrderRequest.OrderUid;
        }

        public async Task<Guid> CreateOrderAsync(NewOrder newOrderRequest, CancellationToken token = default)
        {
            var dbOrder = new OrderDb(newOrderRequest.OrderUid, newOrderRequest.CustomerUid, newOrderRequest.OrderCreateRequestDate);
            _orderDb.Orders.Add(dbOrder);
            await _orderDb.SaveChangesAsync(token);

            return newOrderRequest.OrderUid;
        }

        public void DeleteOrder(Guid orderUidToDelete)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderAsync(Guid orderUidToDelete, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Order GetCustomerOrder(Guid customerUid)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetCustomerOrderAsync(Guid customerUid, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(Guid uid)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderAsync(Guid uid, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public bool IsOrderExist(Guid uid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsOrderExistAsync(Guid uid, CancellationToken token = default)
        {
            return _orderDb.Orders.AnyAsync(x => x.Identifier == uid);
        }

        public void UpdateOrder(Guid uidToUpdate, ReadOnlySpan<ItemIdentifier> itemsToAdd, ReadOnlySpan<ItemIdentifier> itemsToRemove)
        {
            throw new NotImplementedException();
        }
    }
}
