﻿using System;
using ProductManager.Model;
using ProductManager.Model.Entities;
using ProductManagerCore.Model;
using ProductManagerCore.Model.Factory;

namespace ProductManager
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new ShopContext())
            {
                Customer customer = new Customer("Clement", "Ziane", "3 avenue de la motte", "90000", "Valdoie", "", "France");
                Product prod = new Product("Cool T-shirt", "A really cool t-shirt to look fashion", 19.99);
                IPriceRule pr = PriceRuleFactory.Instance.getPriceRule(2);
                Order myFirstOrder = new Order(customer, pr);
                myFirstOrder.addLineOrder(prod, 1);
                Console.WriteLine(myFirstOrder);
                db.Add(customer);
                db.Add(prod);
                db.Add(myFirstOrder);
                db.SaveChanges();
               
            }

            
        }
    }
}
