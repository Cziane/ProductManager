using ProductManager.Model.Entities;
using ProductManagerCore.Model.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Model
{
    class Order
    {
        public int? ID { get; set; }
        public Customer customer { get; set; }

        private Dictionary<int, LineOrder> _lineOrders;

        private IPriceRule _priceRule;

        public List<LineOrder> LineOrders { get => this._lineOrders.Values.ToList(); }


        public Order()
        {
            this._lineOrders = new Dictionary<int, LineOrder>();
            this._priceRule = PriceRuleFactory.Instance.getPriceRule(0);
        }

        public Order(Customer customer, IPriceRule pr)
        {
            this.customer = customer;
            this._lineOrders = new Dictionary<int, LineOrder>();
            this._priceRule = pr;
        }

        public Order(EOrder order)
        {
            this.ID = order.ID;
            this.customer = new Customer(order.Owner);
            this._lineOrders = new Dictionary<int, LineOrder>();
            this._priceRule = PriceRuleFactory.Instance.getPriceRule(order.PriceRuler);
            foreach(ELineOrder eline in order.Lines)
            {
                this._lineOrders.Add(eline.ID, new LineOrder(eline));
            }

            
        }

        public void addLineOrder(Product p, int quantity)
        {
          /*  LineOrder line = new LineOrder("test", quantity);
            line.content = p;
            this._lineOrders.Add(line.ID, line);*/
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
