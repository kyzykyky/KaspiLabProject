using System;
using Lesson_5_Warehouse.Common_Structs;

namespace Lesson_5_Warehouse.Employees
{
    public class Loader : Employee
    {
        public enum Сompetences { Basic = 1, Special = 2}
        public Сompetences Competence { get; set; }
        public Loader(Person person, Сompetences competence) : base(person)
        {
            Competence = competence;
        }
    }
}
