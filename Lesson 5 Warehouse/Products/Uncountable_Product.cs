using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_Warehouse.Products
{
    public abstract class Uncountable_Product : Product
    {
        private float _density;
        public float Density { get { return _density; } set { if (value > 0) _density = value; } }

        protected Uncountable_Product(string name, string desc, string sku, float price, float density) : base(name, desc, sku, price)
        {
            Density = density;
        }
    }
}
