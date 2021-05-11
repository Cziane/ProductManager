using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager
{
    class LineOrder
    {
        public Product content { get; }
        public uint  quantity { get; set; }

        public string ID { get; }

        public LineOrder(Product content, uint quantity)
        {
            this.ID = Guid.NewGuid().ToString();
            this.content = content;
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
