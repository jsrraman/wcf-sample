using Rajaraman.Pizza.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace Rajaraman.Pizza.Services
{
    [ServiceContract]
    public interface IPizzaService
    {
        [OperationContract]
        List<Product> GetProducts();

        [OperationContract]
        List<Customer> GetCustomers();

        [OperationContract]
        void SubmitOrder(Order order);
    }
}
