using System;
using System.Text.RegularExpressions;

namespace Lesson_5_Warehouse.Common_Structs
{
    public struct Person
    {
        public string Name;
        public string LastName;
        public string PhoneNumber;
        public string IIN;
        public Address Address;
        public DateTime BirthDate;

        public Person(string name, string lastname, string phonenumber, string iin, Address address, DateTime birthdate)
        {
            Name = name; LastName = lastname;
            PhoneNumber = phonenumber; 
            Address = address;
            BirthDate = birthdate;

            var regex = new Regex(@"^\d{12}$");    // example: "123456789012"
            if (regex.IsMatch(iin))
                IIN = iin;
            else throw new ArgumentException("Неверный формат ИИН");
        }
    }
}
