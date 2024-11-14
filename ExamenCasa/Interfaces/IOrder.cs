using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenCasa.Interfaces;

namespace ExamenCasa.Interfaces
{
    internal interface IOrder
    {
        void AddProduct(IProduct product, int cantidad = 0);
        double GetTotal();
        void ApplyPromotion(IPromocion promotion);
    }
}
