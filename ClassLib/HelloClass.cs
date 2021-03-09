using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public static class HelloClass
    {
        public static int HelloWorld()
        {
            Console.WriteLine("Hello World!");
            return 0;
        }

        public static void Array_from_lesson_3()
        {
            int arr_len = 5;    // Для удобства, размер заполняемого вручную массива уменьшен с 10 до 5
            int[] arr = new int[arr_len];
            Console.WriteLine($"Введите {arr_len} чисел:");
            for (int i = 0; i < arr_len; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("=>");

            int sum = 0;
            for (int i = 0; i < arr_len; i++)
            {
                Console.Write($"   {arr[i]}");
                if (arr[i] % 2 == 0)
                {
                    Console.Write("\t- Четное");
                }
                else
                {
                    Console.Write("\t- Нечетное");
                }

                bool ch = true;
                for (int j = 2; j < arr[i]; j++)
                {
                    if (arr[i] % j == 0) { ch = false; break; }
                }
                if (ch && arr[i] > 0)
                {
                    Console.Write(", простое");
                }
                Console.WriteLine(" число");
                sum += arr[i];
            }
            Console.WriteLine($"\nСумма чисел = {sum}");
            Console.ReadKey();
        }
    }
}
