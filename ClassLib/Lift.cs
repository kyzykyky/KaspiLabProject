using System;
using System.Threading;

namespace ClassLib
{
    /**     Создать класс, описывающий лифт.                                        +
            Методы (как минимум)
            - поехать на заданный этаж                                              +
            - вызвать лифт на заданный этаж                                         +
            Загрузить/выгрузить пассажиров                                          +

            Свойства (как минимум):
            - этажность здания                                                      +
            - грузоподъемность (людей)                                              +

            Лифт не должен:
            - попасть на несуществующий этаж                                        +
            - открывать двери между этажами                                         +
            - ехать с открытыми дверями                                             +
            - ехать с перегрузкой                                                   +
            - запускать людей в момент движения

            В каждом действии выводить на консоль сообщение, что выполняется        +
            При передвижении выводить сообщение для каждого этажа                   +
    */


    public class Lift
    {
        private bool moving = false;
        public bool is_moving
        {
            get { return moving; }
        }
        private bool doors_opened = false;
        public bool doors_are_opened
        {
            get { return doors_opened; }
        }

        public int cur_floor = 1;
        
        private int _floors;
        public int floors
        {
            get { return _floors; } 
            set
            {
                if (value > 1 && value < 100)
                {
                    _floors = value;
                }
                else _floors = 2;       // Этажность - минимум 2
            }
        }

        private int _load_capacity;
        private int load_capacity
        {
            get { return _load_capacity; }
            set
            {
                if (value > 2 && value < 16)
                {
                    _load_capacity = value;
                }
                else _load_capacity = 3;    // Установка грузоподъёсности - минимум 3 человека
            }
        }

        private int _people_inside;
        private int people_inside
        {
            get { return _people_inside; }
            set
            {
                if (value > 1 && value + people_inside <= load_capacity)      // На вход
                {
                    Console.WriteLine($"В лифт зашло {value}");
                    _people_inside += value;
                }
                else if (value < 0 && value * (-1) <= load_capacity && value * (-1) <= people_inside)  // На выход
                {
                    Console.WriteLine($"Из лифта вышло {value * (-1)}");
                    _people_inside -= value * (-1);
                }
                    
                else if (value == 0) Console.WriteLine("Никто не зашел и не вышел");
                    
                else if (value > 1 && people_inside == load_capacity) 
                {
                    Console.WriteLine("Лифт переполнен! Никто не вошёл");
                }
                else if (value > 1 && (value + people_inside) > load_capacity)
                {
                    Console.WriteLine($"Лифт переполнен! Вошло только {load_capacity - people_inside}");
                    _people_inside += load_capacity - people_inside;
                }
                else if (value < 0 && value * (-1) >= people_inside)
                {
                    Console.WriteLine("Столько людей из лифта выйти не могут");
                    Console.WriteLine($"Из лифта вышли все пассажиры");
                    _people_inside = 0;
                }
            }
        }
        public Lift(int load_capacity, int floors)
        {
            this.load_capacity = load_capacity;
            this.floors = floors;
        }

        public void Call_Lift(int floor)
        {
            if (floor == cur_floor)
            {
                Doors_Opening();
            }
            else if (floor > 0 && floor <= floors)
            {
                Move(floor);
                Doors_Opening();
            }
            else
            {
                Console.WriteLine("Задан некорректный этаж!");
            }
        }

        private void Move(int floor)        // Движение лифта вверх/вниз
        {
            if (!doors_opened)
            {
                moving = true;
                Console.WriteLine($"Лифт начинает своё движение с {cur_floor} этажа");

                if (floor < cur_floor)      // Спуск
                {
                    Console.WriteLine($"Лифт спускается на {floor} этаж");
                    while (cur_floor > floor + 1)
                    {
                        Thread.Sleep(1000);
                        cur_floor--;
                        Console.WriteLine($"Сейчас лифт на {cur_floor} этаже...");
                    }
                }

                else if (floor > cur_floor) // Подъём
                {
                    Console.WriteLine($"Лифт поднимается на {floor} этаж");

                    while (cur_floor < floor - 1)
                    {
                        Thread.Sleep(1000);
                        cur_floor++;
                        Console.WriteLine($"Сейчас лифт на {cur_floor} этаже...");
                    }
                    cur_floor++;
                }
                Thread.Sleep(1000);
                Console.WriteLine($"Лифт прибыл на {cur_floor} этаж!\n");

                moving = false;
            }
            else Console.WriteLine("Лифт не может двигаться с открытыми дверями!");
        }

        public void Doors_Opening()  // Открытие дверей лифта
        {
            Console.WriteLine("Двери лифта открываются");
            doors_opened = true;
        }
        public void Doors_Closing()  // Закрытие дверей лифта
        {
            Console.WriteLine("Двери лифта закрываются\n");
            doors_opened = false;
        }

        public void People_enter_or_exit_Lift(int people_count)
        {
            if (!doors_opened && moving) Console.WriteLine("Люди не могут зайти/выйти пока двери закрыты и лифт находится в движении!");
            else if (!doors_opened) Console.WriteLine("Люди не могут зайти/выйти пока двери закрыты!");
            else if (doors_opened && !moving)
            {
                if (people_count > 0)       // Положительное значение - люди входят
                {
                        Console.WriteLine("Люди начинают заходить в лифт...");
                }
                else if (people_count < 0)  // Отрицательное значение - люди выходят
                {
                        Console.WriteLine("Люди выходят из лифта...");
                }
                Thread.Sleep(2000);
                people_inside = people_count;
                Console.WriteLine($"В лифте сейчас {people_inside} пас.");
                Doors_Closing();
            }
            
        }
    }
}
