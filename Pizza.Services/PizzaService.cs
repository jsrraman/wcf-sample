using Rajaraman.Pizza.Data;
using Rajaraman.Pizza.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Rajaraman.Pizza.Services
{
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.PerCall)]
    public class PizzaService : IPizzaService, IDisposable
    {
        readonly PizzaDbContext pizzaDbContext = new PizzaDbContext();

        public void Dispose()
        {
            pizzaDbContext.Dispose();
        }

        public List<Customer> GetCustomers()
        {
            return pizzaDbContext.Customers.ToList();
        }

        public List<Product> GetProducts()
        {
            return pizzaDbContext.Products.ToList();
        }

        [OperationBehavior(TransactionScopeRequired=true)]
        public void SubmitOrder(Order order)
        {
            pizzaDbContext.Orders.Add(order);
            order.OrderItems.ForEach(orderItem => pizzaDbContext.OrderItems.Add(orderItem));
            pizzaDbContext.SaveChanges();
        }
    }
}
