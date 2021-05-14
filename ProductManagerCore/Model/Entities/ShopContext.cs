using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Model.Entities
{
    class ShopContext : DbContext
    {
        public DbSet<EProduct> Products { get; set; }
        public DbSet<ECustomer> Customers { get; set; }

        public DbSet<EOrder> Orders { get; set; }

        public DbSet<ELineOrder> LineOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(@"Data Source=C:\Users\VC2\Documents\ProductManager\shop.db");

    }

   abstract class Entity
    {
        public void Save()
        {
            using (var db = new ShopContext())
            {
                if (this.isExist())
                {
                    db.Update(this);
                }
                else
                {
                    db.Add(this);
                }
                db.SaveChanges();

            }
        }

        public void Remove()
        {
            using (var db = new ShopContext())
            {
                db.Remove(this);
                db.SaveChanges();

            }
        }

        protected abstract bool isExist();
    }

    class ECustomer : Entity
    {
        public int ID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string street { get; set; }

        public string zip { get; set; }

        public string city { get; set; }

        public string? State { get; set; }

        public string country { get; set; }

        protected override bool isExist()
        {
          using ( var db = new ShopContext())
            {
               var customers =  db.Customers.OrderBy(c => c.ID);
                foreach(dynamic c in customers)
                {
                    if(c.ID == this.ID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    class EIllustration : Entity
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string path { get; set; }

        protected override bool isExist()
        {
            return false;
        }
    }

    class EProduct : Entity
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public ICollection<EIllustration>? Illustrations { get; set; }

        protected override bool isExist()
        {
            using (var db = new ShopContext())
            {
                var products = db.Products.OrderBy(c => c.ID);
                foreach (dynamic c in products)
                {
                    if (c.ID == this.ID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    class ELineOrder : Entity
    {
        public int ID { get; set; }
        public EProduct Content { get; set; }

        public int Quantity { get; set; }

        protected override bool isExist()
        {
            using (var db = new ShopContext())
            {
                var lines = db.LineOrders.OrderBy(c => c.ID);
                foreach (dynamic c in lines)
                {
                    if (c.ID == this.ID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    class EOrder : Entity
    {
        public int ID { get; set; }
        public int PriceRuler { get; set; }

        public ECustomer Owner { get; set; }

        public ICollection<ELineOrder>? Lines { get; set; }

        protected override bool isExist()
        {
            using (var db = new ShopContext())
            {
                var orders = db.Orders.OrderBy(c => c.ID);
                foreach (dynamic c in orders)
                {
                    if (c.ID == this.ID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

}
