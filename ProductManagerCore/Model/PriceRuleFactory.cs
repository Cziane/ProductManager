using ProductManager.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagerCore.Model.Factory
{
    class PriceRuleFactory
    {

        private static PriceRuleFactory _instance;


        public static PriceRuleFactory Instance
        {
            get
            {
                if(_instance is null)
                {
                    _instance = new PriceRuleFactory();
                }
                return _instance;
            }
        }


        private PriceRuleFactory()
        {

        }

        public ProductManager.Model.IPriceRule getPriceRule(int priID)
        {
            switch (priID)
            {
                case 2:
                    return new PriceRule(0.2);
                default:
                    return new PriceRule(0.1);
            }
        }


        private class PriceRule : ProductManager.Model.IPriceRule
        {
            private double _vat;


            public PriceRule(double vat)
            {
                this._vat = vat > 0 ? vat : 0;
            }
            public double CalculateTotalPrice(Order order)
            {
                double amount = this.CalculateTotalPriceWithoutVAT(order);
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
                return this._vat * 100;
            }

            public override string ToString()
            {
                return "VAT : " + this.getVAT();
            }
        }



    }

    
}
