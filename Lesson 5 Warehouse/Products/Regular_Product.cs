using Lesson_5_Warehouse.Common_Structs;
using System;

namespace Lesson_5_Warehouse.Products
{
    public class Regular_Product : Countable_Product
    {
        public Regular_Product(string name, string desc, string sku, float price, Size size, float mass) : base(name, desc, sku, price, size, mass)
        {
        }
    }
}
