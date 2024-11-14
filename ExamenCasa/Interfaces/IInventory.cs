using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExamenCasa.Interfaces
{
    internal interface IInventory
    {
        void AddProduct(IProduct product, int cantidad = 0);
        void UpdateQuantity(int productId, int cantidad);
        IEnumerable<IProduct> FilterProducts(Predicate<IProduct> predicate);
        List<(IProduct producto, int cantidad)> GetProducts();
    }
}
