using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_Warehouse.Employees
{
    public abstract class Employee
    {
        public string name;
        
        public Employee(string name)
        {
            this.name = name;
        }
    }
}
