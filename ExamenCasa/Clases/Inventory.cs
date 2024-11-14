using ExamenCasa.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenCasa.Clases
{
    internal class Inventory : IInventory
    {
        private List<(IProduct producto, int cantidad)> _products = new List<(IProduct, int)>();// MANzana 3, pera 1,  
        public void AddProduct(IProduct product, int cantidad)
        {
            var existingProduct = _products.FindIndex(x => x.Item1.Id == product.Id);

            if (existingProduct >= 0)
            {
                // Si el producto ya existe en el inventario, actualizamos la cantidad
                var currentQuantity = _products[existingProduct].Item1;
                _products[existingProduct] = (currentQuantity, _products[existingProduct].Item2 + cantidad);
            }
            else
            {
                // Si el producto no existe en el inventario, lo agregamos
                _products.Add((product, cantidad));
            }
        }

        public IEnumerable<IProduct> FilterProducts(Predicate<IProduct> predicate)
        {
            return _products.Where(x => predicate(x.producto)).Select(x => x.producto);
        }

        public void UpdateQuantity(int productId, int cantidad)
        {
            _products[productId] = (_products[productId].Item1, cantidad);
            Console.WriteLine($"Quantity of {_products[productId].Item1.Nombre} updated to {cantidad}");
        }
        //devuelva la lista de productos y sus cantidades en el inventario
        public List<(IProduct producto, int cantidad)> GetProducts()
        {
            return _products;
        }
    }
}
