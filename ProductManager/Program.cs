using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("Clement", "Ziane", "3 avenue de la motte", "90000", "Valdoie", "", "France");
            Product prod = new Product("Cool T-shirt", "A really cool t-shirt to look fashion", 19.99);
            IPriceRule pr = new PriceRule(0.2);
            Order myFirstOrder = new Order(customer, pr);
            myFirstOrder.addLineOrder(prod, 1);
            Console.WriteLine(myFirstOrder);
        }
    }
}
