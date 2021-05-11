using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager
{
    interface IPriceRule
    {
        double CalculateTotalPrice(Order order);

        double CalculateVAT(Order order);

        double CalculateTotalPriceWithoutVAT(Order order);

        double getVAT();

    }
}
