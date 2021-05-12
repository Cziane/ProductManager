using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Model
{
    class PriceRule : IPriceRule
    {
        private double _vat;

        
        public PriceRule(double vat)
        {
            this._vat = vat > 0 ? vat : 0;
        }
        public double CalculateTotalPrice(Order order)
        {
            double amount = this.CalculateTotalPriceWithoutVAT(order) ;
            amount += this.CalculateVAT(order);
            return amount;
        }

        public double CalculateTotalPriceWithoutVAT(Order order)
        {
            double amount = 0;
            foreach (LineOrder line in order.LineOrders)
            {
                amount += line.CalculatePrice();
            }
            return amount;
        }

        public double CalculateVAT(Order order)
        {
            double amount = 0;
            foreach (LineOrder line in order.LineOrders)
            {
                amount += line.CalculatePrice() * this._vat;
            }

            return amount;
        }

        public double getVAT()
        {
            return this._vat*100;
        }

        public override string ToString()
        {
            return "VAT : " + this.getVAT();
        }
    }
}
