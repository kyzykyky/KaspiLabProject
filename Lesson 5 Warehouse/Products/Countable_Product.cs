using System;
using Lesson_5_Warehouse.Common_Structs;

namespace Lesson_5_Warehouse.Products
{
    public abstract class Countable_Product : Product
    {
        public override string unit_measure { get => "шт."; }

        public Size Size
        {
            get; set;
        }

        private float _mass;
        public float Mass
        {
            get { return _mass; }
            set { if (value > 0) _mass = value; }
        }

        public Countable_Product(string name, string desc, string sku, float price, Size size, float mass) : base(name, desc, sku, price)
        {
            Size = size;
            Mass = mass;
        }
    }
}
