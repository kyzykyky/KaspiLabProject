using System;
using ClassLib;

namespace KaspiLabPjt
{
    class Program
    {
        static void Main(string[] args)
        {
            var lift = new Lift(8, 10);

            lift.Call_Lift(3);

            lift.People_enter_or_exit_Lift(7);

            lift.Call_Lift(6);
            lift.People_enter_or_exit_Lift(-3);
            lift.Call_Lift(6);
            lift.People_enter_or_exit_Lift(6);

            lift.Call_Lift(1);
            lift.People_enter_or_exit_Lift(-111);
            lift.People_enter_or_exit_Lift(0);

            Console.ReadKey();
        }
    }
}
