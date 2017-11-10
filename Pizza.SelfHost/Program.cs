using Rajaraman.Pizza.Services;
using System;
using System.ServiceModel;

namespace Rajaraman.Pizza.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost host = new ServiceHost(typeof(PizzaService));
                host.Open();

                Console.WriteLine("Hit any ket to exit");
                Console.ReadLine();

                host.Close();
            } 
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
