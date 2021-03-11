using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_Warehouse.Employees
{
    public partial class Manager : Employee
    {
        public enum Access_Levels { First=1, Second=2, Third=3 }
        public Access_Levels Access_Level { get; set; }

        public Manager(string name, Access_Levels level) : base(name)
        {
            Access_Level = level;
        }
    }
}
