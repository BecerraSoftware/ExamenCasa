using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenCasa.Interfaces;

namespace ExamenCasa.Clases
{
    public abstract class Producto: IProduct
    {
        //hacer que tengan un id unico
        private static int _id = 0;
        public int Id { get; set; } = _id++;

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) ?
                    throw new Exception("invalid name") : value;
            }
        }
        private double _precio;
        public double Precio
        {
            get { return _precio; }
            set
            {
                _precio = value < 0 ?
                    throw new Exception("no negatve") : value;
            }


        }
        public Producto(string nombre, double precio)
        {
            
            Nombre = nombre;
            Precio = precio;
        }
    }
}
