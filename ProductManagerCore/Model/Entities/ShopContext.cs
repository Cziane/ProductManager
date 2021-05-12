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

    class ECustomer
    {
        public int ID { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string street { get; set; }

        public string zip { get; set; }

        public string city { get; set; }

        public string? State { get; set; }

        public string country { get; set; }

    }

    class EIllustration
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string path { get; set; }
    }

    class EProduct
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public ICollection<EIllustration>? Illustrations { get; set; }
    }

    class ELineOrder
    {
        public int ID { get; set; }
        public EProduct Content { get; set; }

        public int Quantity { get; set; }

    }

    class EOrder
    {
        public int ID { get; set; }
        public int PriceRuler { get; set; }

        public ECustomer Owner { get; set; }

        public ICollection<ELineOrder>? Lines { get; set; }
    }

}
