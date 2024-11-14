using ExamenCasa.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenCasa.Clases;
using ExamenCasa.Interfaces;
using System.Threading;

namespace ExamenCasa
{
    internal class Program
    {
        static void IMain(string[] args)
        {
            var inventory = new Inventory();

            // Agregar productos
            var libro = new ProductDigital("libro digital", 50);
            var musicAlbum = new ProductDigital("Music Album", 120);
            var licenseSoftware = new ProductDigital("Software License", 150);

            inventory.AddProduct(libro, 1);
            inventory.AddProduct(musicAlbum, 1);
            inventory.AddProduct(licenseSoftware, 1);

            var physical1 = new ProductPhysical("Keyboard", 80, 5);
            var physical2 = new ProductPhysical("Monitor", 200, 3);
            var physical3 = new ProductPhysical("Mouse", 30, 2);

            inventory.AddProduct(physical1, 3);
            inventory.AddProduct(physical2, 4);
            inventory.AddProduct(physical3, 1);

            // Filtrar productos y agregar existencia
            var lowStockProducts = inventory.FilterProducts(p => p is ProductPhysical pp && pp.Stock < pp.MinStock);

            /*
            foreach (var product in lowStockProducts)
            {
                if (product is ProductPhysical physicalProduct)
                    inventory.UpdateQuantity(physicalProduct.Id, physicalProduct.MinStock - physicalProduct.Stock);
            }*/

            // Crear orden y aplicar promociones
            var orden = new Orden();
            orden.AddProduct(physical2, 2);
            orden.AddProduct(libro, 1);
            orden.Print();

            var promotion1 = new PromocionAutomatic(
                "2x1 Keyboard",
                o => o.GetTotal() > 50,
                o => o.AddProduct(physical1, -2) // descuento de 1 teclado
            );

            var promotion2 = new ManualPromotion(
        "20% Employee Discount",
        o => o.GetTotal() > 50, // Condición: si el total es mayor a 100
        o => // Efecto: aplica un 20% de descuento en el total
        {
            double total = o.GetTotal();
            double discount = total * 0.80; // 20% de descuento
            o.ApplyPromotion(promotion1);
        }
    );

            orden.ApplyPromotion(promotion1);
            orden.Print();
            orden.ApplyPromotion(promotion2);
            orden.Print();

        }

        static void Main(string[] args)
        {
            IInventory inventory = new Inventory();


            // Agregar productos
            var libro = new ProductDigital("libro digital", 50);
            var musicAlbum = new ProductDigital("Music Album", 120);
            var licenseSoftware = new ProductDigital("Software License", 150);

            inventory.AddProduct(libro, 1);
            inventory.AddProduct(musicAlbum, 1);
            inventory.AddProduct(licenseSoftware, 1);


            IOrder order = new Orden();

            order.AddProduct(libro, 2);
            //añadrir promocion que sea 2x1 en libros digitales
            var promocion = new PromocionAutomatic("2x1 en libros digitales", item => item.GetTotal() > libro.Precio, item => item.AddProduct(libro, -1));
        


        }
    }
}
