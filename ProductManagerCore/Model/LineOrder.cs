using ProductManager.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Model
{
    class LineOrder
    {
        public Product content { get; set; }
        public int  quantity { get; set; }

        public int? ID { get; set; }

        public LineOrder(Product p, int quantity)
        {
            this.content = p;
            this.quantity = quantity;
        }

        public LineOrder(ELineOrder eline)
        {
            this.ID = eline.ID;
            this.quantity = eline.Quantity;
            //this.content = eline.Content;

        }

        public double CalculatePrice()
        {
            return this.content.Price * this.quantity;
        }

        public override string ToString()
        {
            return this.content.title + " : " + this.quantity + " => " + this.CalculatePrice();
        }
    }
}
