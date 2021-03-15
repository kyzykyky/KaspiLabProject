using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_Warehouse.Common_Structs
{
    public struct Address
    {
        public string Region;
        public string City;
        public string Street;
        public string House;
        public string Misc;

        public Address(string region, string city, string street, string house, string misc="")
        {
            Region = region; City = city; 
            Street = street; House = house;
            Misc = misc;
        }
    }
}
