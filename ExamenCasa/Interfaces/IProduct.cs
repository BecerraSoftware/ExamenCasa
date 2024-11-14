﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenCasa.Interfaces
{
    internal interface IProduct
    {
        int Id { get; set; }
        string Nombre { get; set; }
        double Precio { get; set; }
    }
}
