using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lesson_5_Warehouse.Products
{
    public abstract class Product
    {
        public virtual string unit_measure { get; }

        public string Name;
        public string Description;

        private string _sku;
        public string SKU { get { return _sku; } 
            set 
            {
                if (Check_SKU_Input(value))
                {
                    _sku = value;
                }
            } 
        }

        public static bool Check_SKU_Input(string sku)
        {
            var regex = new Regex(@"^\d{8}$");      // example: "12345678"
            if (regex.IsMatch(sku)) return true;
            else return false;
        }

        public float Price;

        public Product(string name, string desc, string sku, float price)
        {
            Name = name; Description = desc; SKU = sku; Price = price;
        }
    }
}
