using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager
{
    class LineOrder
    {
        public Product content { get; set; }
        public int  quantity { get; set; }

        public string ID { get; set; }

        public LineOrder(string ID, int quantity)
        {
            this.ID = ID;
            this.quantity = quantity;
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
