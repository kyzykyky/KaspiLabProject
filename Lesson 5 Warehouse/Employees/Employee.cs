using System;
using Lesson_5_Warehouse.Common_Structs;

namespace Lesson_5_Warehouse.Employees
{
    public abstract class Employee
    {
        public Person Person;
        
        public Employee(Person person)
        {
            Person = person;
        }
    }
}
