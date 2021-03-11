using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5_Warehouse.Employees
{
    public class Loader : Employee
    {
        public enum Сompetences { Basic = 1, Special = 2}
        public Сompetences Competence { get; set; }
        public Loader(string name, Сompetences competence) : base(name)
        {
            Competence = competence;
        }
    }
}
