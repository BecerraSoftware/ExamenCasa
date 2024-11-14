using ExamenCasa.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenCasa.Clases
{
    internal class ProductPhysical : Producto, IProduct
    {
        public bool IsDigital => false;
        public int Stock { get; set; }
        public int MinStock { get; set; }

        public ProductPhysical(string name, double price, int minStock) : base(name, price)
        {
            Nombre = name;
            Precio = price;
            MinStock = minStock;
        }


    }
}
