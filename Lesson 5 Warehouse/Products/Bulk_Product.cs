using System;

namespace Lesson_5_Warehouse.Products
{
    public class Bulk_Product : Uncountable_Product
    {
        public override string unit_measure { get => "кг."; }

        public Bulk_Product(string name, string desc, string sku, float price, float density) : base(name, desc, sku, price, density)
        {
        }
                
    }
}
