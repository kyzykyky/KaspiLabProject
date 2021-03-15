using System;
using Lesson_5_Warehouse.Common_Structs;
using Lesson_5_Warehouse.Products;
using Lesson_5_Warehouse.Employees;
using Lesson_5_Warehouse.Warehouses;

namespace KaspiLabPjt
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee manager_1 = new Manager(new Person("Иван", "Иванов", "777732112340", "000123000321",
                new Address("Алматинская область", "Алматы", "Гоголя", "17", "Квартира 3"), new DateTime(1990, 6, 12)), Manager.Access_Levels.Second);
            Employee manager_2 = new Manager(new Person("Борис", "Сарматов", "7707431334", "000123000123",
                new Address("Акмолинская область", "Нур-Султан", "Абая", "63", "Квартира 24"), new DateTime(1989, 5, 22)), Manager.Access_Levels.Second);
            Employee manager_3 = new Manager(new Person("Султан", "Рамазанов", "77013232234", "000121230321",
                new Address("Карагандинская область", "Караганда", "Торайгырова", "56"), new DateTime(1995, 1, 3)), Manager.Access_Levels.First);
            Employee manager_4 = new Manager(new Person("Николай", "Дмитриев", "77478654232", "000123000456",
                new Address("Алматинская область", "Алматы", "Пушкина", "24", "Квартира 15"), new DateTime(1992, 12, 30)), Manager.Access_Levels.Third);
            Employee manager_5 = new Manager(new Person("Абылай", "Жумаканов", "77773412156", "120223000321",
                new Address("Алматинская область", "Талдыкорган", "Алтынсарина", "7"), new DateTime(1985, 2, 3)), Manager.Access_Levels.First);

            Warehouse[] warehouses = new Warehouse[3];
            warehouses[0] = new Warehouse(new Address("Алматинская область", "Алматы", "Суинбая", "65"),
                500, Warehouse.Warehouse_Types.Indoor, (Manager)manager_1);
            warehouses[1] = new Warehouse(new Address("Акмолинская область", "Нур-Султан", "Джангильдина", "4Б"),
                1000, Warehouse.Warehouse_Types.Outdoor, (Manager)manager_2);
            warehouses[2] = new Warehouse(new Address("Карагандинская область", "Караганда", "Карасай Батыра", "5"),
                800, Warehouse.Warehouse_Types.Indoor, (Manager)manager_3);

            Product rp_1 = new Regular_Product("Airbook", "Made by Apple", "00001001", 350000, new Size(70, 40, 10), 5);
            Product rp_2 = new Regular_Product("Zenbook", "Made by Asus", "00001002", 250000, new Size(60, 35, 10), 6);

            Product ovp_1 = new Overall_Product("Шкаф", "Made in China", "00002001", 120000, new Size(200, 100, 70), 90);
            Product ovp_2 = new Overall_Product("Буфет", "Made in Russia", "00002002", 145000, new Size(60, 60, 50), 50);

            Product bp_1 = new Bulk_Product("Сахарный песок", "Made in Kazakhstan", "00010001", 400, 900);
            Product bp_2 = new Bulk_Product("Соль поваренная", "Made in Turkmenistan", "00010051", 150, 1010);

            Product lp_1 = new Liquid_Product("Питьевая вода", "Extracted in Almaty", "00020001", 100, 1000);
            Product lp_2 = new Liquid_Product("Коровье молоко", "From south Kazakhstan", "00050001", 300, 1033);

            // Назначение ответственного за склад менеджера - вызовет ошибку так как уровень менеджера_4 не соответствует необходимому
            try
            {
                warehouses[0].Responsible_Manager = (Manager)manager_4;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Данный сотрудник не может быть назначен ответственным за склад менеджером");
            }
            warehouses[0].Responsible_Manager = (Manager)manager_5;


            // Добавление товаров на склад
            Console.WriteLine(warehouses[0].Add_Product(rp_1, 5));
            Console.WriteLine(warehouses[0].Add_Product(rp_2, 7));
            Console.WriteLine(warehouses[0].Add_Product(bp_2, 200));
            Console.WriteLine(warehouses[1].Add_Product(ovp_1, 15));
            Console.WriteLine(warehouses[1].Add_Product(ovp_2, 25));
            Console.WriteLine(warehouses[1].Add_Product(lp_2, 120));
            try
            {
                warehouses[1].Add_Product(bp_1, 150);    // Сыпучий товар на открытый склад не добавится
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Сыпучий товар не может быть добавлен на открытый склад");
            }
            Console.WriteLine();

            // Перемещение товаров между складами
            Console.WriteLine(warehouses[0].Transfer_Product(warehouses[1], lp_1, 110));
            Console.WriteLine(warehouses[0].Add_Product(lp_1, 200));
            Console.WriteLine(warehouses[0].Transfer_Product(warehouses[1], lp_1, 110));
            Console.WriteLine(warehouses[0].Transfer_Product(warehouses[1], rp_1, 2));
            Console.WriteLine(warehouses[0].Transfer_Product(warehouses[2], rp_2, 3));
            Console.WriteLine();

            // Поиск товара по SKU + подсчет суммы всех товаров на всех складах
            string sku_1 = rp_1.SKU;
            string sku_2 = rp_2.SKU;
            string sku_3 = "0001234";

            float sum = 0;
            foreach (var wh in warehouses)
            {
                Console.WriteLine(wh.Search_Product_By_SKU(sku_1));
                Console.WriteLine(wh.Search_Product_By_SKU(sku_2));
                Console.WriteLine(wh.Search_Product_By_SKU(sku_3));
                Console.WriteLine();

                sum += wh.Total_Products_Price();
            }
            Console.WriteLine($"Сумма товаров на всех складах = {sum}\n");

            //Добавить сотрудника, затем вывести всех сотрудников склада 1
            Employee loader_1 = new Loader(new Person("Глеб", "Ким", "77017651232", "000000123123",
                new Address("Алматинская область", "Талдыкорган", "Алтынсарина", "7"), new DateTime(1998, 4, 14)), Loader.Сompetences.Basic);
            Console.WriteLine(warehouses[0].Add_Employee(loader_1));
            Console.WriteLine(warehouses[0].Add_Employee(loader_1));
            Console.WriteLine(warehouses[0].Remove_Employee_by_IIN("000123000321"));

            foreach (Employee e in warehouses[0].Warehouse_Employees)
            {
                if (e is Loader) { Loader temp_e = (Loader)e; Console.Write($"Грузчик {temp_e.Competence} "); }
                else if (e is Manager) { Manager temp_e = (Manager)e; Console.Write($"Менеджер {temp_e.Access_Level} "); }

                Console.WriteLine($"{e.Person.LastName} {e.Person.Name}");
            }


            //Реализовать поиск склада, на котором есть определенный товар в нужном количестве.
            Console.WriteLine("Введите название необходимого товара:");
            string name = Console.ReadLine(); // Airbook
            Console.WriteLine("Введите количество необходимого товара:");
            int quantity = Convert.ToInt32(Console.ReadLine());

            bool check = false;
            foreach (var wh in warehouses)
            {
                foreach (var p in wh.Warehouse_Products.Keys)
                {
                    if (p.Name.ToLower() == name.ToLower() && wh.Warehouse_Products[p] >= quantity)
                    {
                        check = true;
                        Console.WriteLine($"Товар {p.Name} имеется на складе в {wh.Address} в количестве {wh.Warehouse_Products[p]} {p.unit_measure}");
                    }
                }
            }
            if (!check) Console.WriteLine("Товара с таким названием нет");

            Console.ReadKey();
        }
    }
}
