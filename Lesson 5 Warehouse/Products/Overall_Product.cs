using System;
using Lesson_5_Warehouse.Common_Structs;

namespace Lesson_5_Warehouse.Products
{
    public class Overall_Product : Countable_Product
    {
        
        public Overall_Product(string name, string desc, string sku, float price, Size size, float mass) : base(name, desc, sku, price, size, mass)
        {

        }
    }
}
