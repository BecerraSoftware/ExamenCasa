using ExamenCasa.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenCasa.Clases
{
    internal class PromocionAutomatic : IPromocion
    {
        public string Name { get; }

        public Func<IOrder,bool> Condition { get; }

        public Action<IOrder> Effect { get; }
        public bool IsAutomatic => true;



        public PromocionAutomatic(string name, Func<IOrder, bool> condition, Action<IOrder> effect)
        {
            Name = name;
            Condition = condition;
            Effect = effect;
        }
    }
    internal class ManualPromotion : IPromocion
    {
        public string Name { get; }
        public Func<IOrder,bool> Condition { get; }
        public Action<IOrder> Effect { get; }
        public bool IsAutomatic => false;

        public ManualPromotion(string name, Func<IOrder, bool> condition, Action<IOrder> effect)
        {
            Name = name;
            Condition = condition;
            Effect = effect;
        }
    }
    }
