using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenCasa.Interfaces;

namespace ExamenCasa.Clases
{
    internal class Orden : IOrder
    {
        private readonly List<(IProduct producto, int cantidad)> _items = new List<(IProduct, int)>();
        private readonly List<string> _promotions = new List<string>();
    public void AddProduct(IProduct product, int cantidad = 0)
        {
            _items.Add((product, cantidad));
        }

        public void ApplyPromotion(IPromocion promotion)
        {
            if (promotion.IsAutomatic)
            {
                if (promotion.Condition(this))
                {
                    promotion.Effect(this);
                    _promotions.Add(promotion.Name);
                }
            }
            else
            {
                if (promotion.Condition(this))
                {
                    promotion.Effect(this);
                    _promotions.Add(promotion.Name);
                }
            }
        }
     

        public double GetTotal()
        {
            return _items.Sum(x => x.producto.Precio * x.cantidad);
        }

        public void Print()
        {
            foreach(var (producto,cantidad) in _items)
            {
                Console.WriteLine($"{producto.Nombre} x {cantidad} = {producto.Precio * cantidad}");
            }
            foreach (var promotion in _promotions)
            {
                Console.WriteLine($"Promotion: {promotion}");
            }

            Console.WriteLine($"Total: {GetTotal()}");
        }

        
    }
}
