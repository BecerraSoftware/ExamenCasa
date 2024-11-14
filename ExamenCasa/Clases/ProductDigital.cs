using ExamenCasa.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenCasa.Clases
{
    internal class ProductDigital : Producto, IProduct
    {
        public bool IsDigital => true;

        public ProductDigital(string name, double price):base(name,price)
        {
            Nombre= name;
            Precio = price;
        }
    }
}
