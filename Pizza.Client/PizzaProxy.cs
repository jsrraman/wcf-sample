using Rajaraman.Pizza.Entities;
using Rajaraman.Pizza.PizzaServices;
using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Rajaraman.Pizza
{
    class PizzaProxy : ClientBase<IPizzaService>, IPizzaService
    {
        public PizzaProxy() { }
        public PizzaProxy(string endpointName) : base(endpointName) { }
        public PizzaProxy(Binding binding, string address) : base(binding, new EndpointAddress(address)) { }

        public ObservableCollection<Customer> GetCustomers()
        {
            return Channel.GetCustomers();
        }

        public Task<ObservableCollection<Customer>> GetCustomersAsync()
        {
            return Channel.GetCustomersAsync();
        }

        public ObservableCollection<Product> GetProducts()
        {
            return Channel.GetProducts();
        }

        public Task<ObservableCollection<Product>> GetProductsAsync()
        {
            return Channel.GetProductsAsync();
        }

        public void SubmitOrder(Order order)
        {
            Channel.SubmitOrder(order);
        }

        public Task SubmitOrderAsync(Order order)
        {
            return Channel.SubmitOrderAsync(order);
        }
    }
}
