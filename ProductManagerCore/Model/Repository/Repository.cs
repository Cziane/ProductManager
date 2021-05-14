using ProductManager.Model;
using ProductManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductManagerCore.Model.Repository
{
    class ProductRepository
    {
        public static int idGenerator{get;set;}

        public dynamic getAll()
        {
            using (ShopContext db = new ShopContext())
            {
                var result = db.Products.OrderBy(p => p.ID).First();
                return result;

            }
        }

        public void Remove(Product p)
        {
            using (ShopContext db = new ShopContext())
            {
                EProduct ep = new EProduct();
                ep.ID = (int)p.Id;
                ep.Title = p.title;
                ep.Description = p.description;
                ep.Price = p.Price;
                db.Products.Remove(ep);
            }
        }

        public void add(Product p)
        {
            p.Id = p.Id is null ? generateId() : p.Id; ;
            EProduct ep = new EProduct();
            ep.ID = (int)p.Id;
            ep.Title = p.title;
            ep.Description = p.description;
            ep.Price = p.Price;

            ep.Save();

        }

        public static int generateId()
        {
            idGenerator++;
            return idGenerator;
        }
    }
    class CustomersRepository
    {
        public static int idGenerator { get; set; }

        public dynamic getAll()
        {
            using (ShopContext db = new ShopContext())
            {
                var result = db.Customers.OrderBy(p => p.ID).First();
                return result;

            }
        }
        public void Remove(Customer c)
        {
            using (ShopContext db = new ShopContext())
            {
                ECustomer ec = new ECustomer();
                ec.ID = (int)c.Id;
                ec.street = c.street;
                ec.city = c.city;
                ec.State = c.state;
                ec.country = c.country;
                ec.zip = c.zip;
                ec.firstname = c.firstname;
                ec.lastname = c.lastname;
                db.Customers.Remove(ec);
            }
        }

        public void add(Customer c)
        {
            ECustomer ec = new ECustomer();
            c.Id = c.Id is null ? generateId() : c.Id;
            ec.ID = (int)c.Id;
            ec.street = c.street;
            ec.city = c.city;
            ec.State = c.state;
            ec.country = c.country;
            ec.zip = c.zip;
            ec.firstname = c.firstname;
            ec.lastname = c.lastname;
            ec.Save();

        }

        public static int generateId()
        {
            idGenerator++;
            return idGenerator;
        }
    }

    class OrdersRepository
    {
        public static int idGenerator { get; set; }

        public dynamic getAll()
        {
            using (ShopContext db = new ShopContext())
            {
                var result = db.Orders.OrderBy(p => p.ID).First();
                return result;

            }
        }

        public void add(Order o)
        {
            EOrder eo = new EOrder();
            o.ID = o.ID is null ? generateId() : o.ID;
            eo.ID = (int)o.ID;
            eo.PriceRuler = 0;
            eo.Owner = new ECustomer();
            eo.Owner.ID = (int)o.customer.Id;
            eo.Owner.street = o.customer.street;
            eo.Owner.city = o.customer.city;
            eo.Owner.State = o.customer.state;
            eo.Owner.country = o.customer.country;
            eo.Owner.zip = o.customer.zip;
            eo.Owner.firstname = o.customer.firstname;
            eo.Owner.lastname = o.customer.lastname;


            eo.Save();

        }

        public void Remove(Order o)
        {
            using (ShopContext db = new ShopContext())
            {
                EOrder eo = new EOrder();
                o.ID = o.ID is null ? generateId() : o.ID;
                eo.ID = (int)o.ID;
                eo.PriceRuler = 0;
                eo.Owner = new ECustomer();
                eo.Owner.ID = (int)o.customer.Id;
                eo.Owner.street = o.customer.street;
                eo.Owner.city = o.customer.city;
                eo.Owner.State = o.customer.state;
                eo.Owner.country = o.customer.country;
                eo.Owner.zip = o.customer.zip;
                eo.Owner.firstname = o.customer.firstname;
                eo.Owner.lastname = o.customer.lastname;
                db.Orders.Remove(eo);
            }
        }

        public static int generateId()
        {
            idGenerator++;
            return idGenerator;
        }
    }

}
