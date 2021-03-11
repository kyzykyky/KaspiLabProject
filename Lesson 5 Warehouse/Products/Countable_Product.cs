using System;
using System.Text.RegularExpressions;

namespace Lesson_5_Warehouse.Products
{
    public abstract class Countable_Product : Product
    {
        public override string unit_measure { get => "шт."; }

        public static bool Check_Size_Input(string size)
        {
            var regex = new Regex(@"^(\d+(?:,\d+)?) x (\d+(?:,\d+)?)(?: x (\d+(?:,\d+)?))?$");
            if (regex.IsMatch(size)) return true;          // example: "10,5 x 12 x 4"
            return false;
        }
        private string _size;
        public string Size
        {
            get { return _size; }
            set
            {
                if (Check_Size_Input(value))
                {
                    _size = value;
                }
            }
        }

        private float _mass;
        public float Mass
        {
            get { return _mass; }
            set { if (value > 0) _mass = value; }
        }

        public Countable_Product(string name, string desc, string sku, float price, string size, float mass) : base(name, desc, sku, price)
        {
            Size = size;
            Mass = mass;
        }
    }
}
