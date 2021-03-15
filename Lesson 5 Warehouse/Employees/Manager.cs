using System;
using Lesson_5_Warehouse.Common_Structs;

namespace Lesson_5_Warehouse.Employees
{
    public partial class Manager : Employee
    {
        public enum Access_Levels { First=1, Second=2, Third=3 }
        public Access_Levels Access_Level { get; set; }

        public Manager(Person person, Access_Levels level) : base(person)
        {
            Access_Level = level;
        }
    }
}
