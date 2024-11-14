using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenCasa.Interfaces
{
    internal interface IPromocion
    {
        string Name { get; }
        Func<IOrder, bool> Condition { get; }
        Action<IOrder> Effect { get; }
        bool IsAutomatic { get; }

    }
}
