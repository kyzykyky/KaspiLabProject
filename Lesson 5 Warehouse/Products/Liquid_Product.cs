using System;

namespace Lesson_5_Warehouse.Products
{
    public class Liquid_Product : Uncountable_Product
    {
        public override string unit_measure { get => "л."; }

        public Liquid_Product(string name, string desc, string sku, float price, float density) : base(name, desc, sku, price, density)
        {
        }
                 
    }
}
