using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager
{
    class Order
    {
        public string ID { get; }
        public Customer customer { get; set; }

        private Dictionary<string, LineOrder> _lineOrders;

        private IPriceRule _priceRule;

        public List<LineOrder> LineOrders { get => this._lineOrders.Values.ToList(); }


        public Order(Customer customer)
        {
            this.customer = customer;
            this._lineOrders = new Dictionary<string, LineOrder>();
            this._priceRule = new PriceRule(0);
        }

        public Order(Customer customer, IPriceRule pr)
        {
            this.customer = customer;
            this._lineOrders = new Dictionary<string, LineOrder>();
            this._priceRule = pr;
        }

        public void addLineOrder(Product p, uint quantity)
        {
            LineOrder line = new LineOrder(p, quantity);
            this._lineOrders.Add(line.ID, line);
        }

        public double getTotal()
        {
            return this._priceRule.CalculateTotalPrice(this);
        }


        public override string ToString()
        {
            string content = this.customer.ToString()+"\n";
            foreach(LineOrder line in this.LineOrders)
            {
                content += line.ToString() + "\n";
            }
            content += "Price without VAT : " + this._priceRule.CalculateTotalPriceWithoutVAT(this) + "€ \n";
            content += this._priceRule.ToString() + "\n";
            content += "VAT amount :" + this._priceRule.CalculateVAT(this) + " euros \n";
            content += "Total price : " + this._priceRule.CalculateTotalPrice(this);
            return content;
        }
    }
}
