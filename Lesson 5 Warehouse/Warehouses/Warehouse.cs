using System;
using System.Collections.Generic;
using Lesson_5_Warehouse.Employees;
using Lesson_5_Warehouse.Products;

namespace Lesson_5_Warehouse.Warehouses
{
    public class Warehouse : IWarehouse_Operations
    {
        public string Address { get; set; }

        private float _area;
        public float Area { get { return _area; } set { if (value > 0) _area = value; } }

        private Manager _responsible_manager;
        public Manager Responsible_Manager { get { return _responsible_manager; }
            set 
            { 
                if (value.Access_Level <= Manager.Access_Levels.Second) _responsible_manager = value;
                else throw new ArgumentOutOfRangeException("Данный сотрудник не может быть назначен менеджером");
            } 
        }

        public Dictionary<Product, int> Warehouse_Products = new Dictionary<Product, int>();
        
        public enum Warehouse_Types {Outdoor, Indoor}
        public Warehouse_Types Warehouse_Type;

        public Warehouse(string address, float area, Warehouse_Types w_t, Manager manager)
        {
            Address = address; Area = area; Warehouse_Type = w_t; Responsible_Manager = manager;
        }

        public string Add_Product(Product product, int quantity)
        {
            if (quantity > 0)
            {
                if (product is Bulk_Product && Warehouse_Type == Warehouse_Types.Outdoor)
                {
                    throw new ArgumentException("Сыпучий товар не может быть добавлен на открытый склад");
                }
                foreach (Product p in Warehouse_Products.Keys)
                {
                    if (p.Name == product.Name)
                    {
                        Warehouse_Products[p] += quantity;
                        return $"На склад был добавлен {product.Name} в количестве {quantity} {product.unit_measure}";
                    }
                }
                Warehouse_Products.Add(product, quantity);
                return $"На склад был добавлен {product.Name} в количестве {quantity} {product.unit_measure}";
            }
            throw new ArgumentOutOfRangeException("Количество задано неверно");
        }

        public string Transfer_Product(Warehouse other, Product product, int quantity)
        {
            foreach (Product p in this.Warehouse_Products.Keys)
            {
                if (p.Name == product.Name && this.Warehouse_Products[p] >= quantity)
                {
                    string message = other.Add_Product(product, quantity);
                    this.Warehouse_Products[product] -= quantity;
                    return $"{product.Name} в количестве {quantity} {product.unit_measure} был успешно перемещён на другой склад";
                }
                else if (p.Name == product.Name && this.Warehouse_Products[p] < quantity)
                {   return $"На данном складе нет товара {product.Name} в заданном количестве"; }
            }
            return $"На данном складе нет товара {product.Name}";
        }

        public string Search_Product_By_SKU(string sku)
        {
            if (Product.Check_SKU_Input(sku))
            {
                foreach(Product p in Warehouse_Products.Keys)
                {
                    if (p.SKU == sku)
                    {
                        return $"На складе имеется {p.Name} в количестве {Warehouse_Products[p]} {p.unit_measure} (SKU - {p.SKU})";
                    }
                }
                return $"Товар с кодом {sku} не был найден";
            }
            else return "Введенный код не соответствует заданным правилам!";

        }

        public float Total_Products_Price()
        {
            float sum = 0;
            foreach (Product p in Warehouse_Products.Keys)
            {
                float price = Warehouse_Products[p] * p.Price;
                sum += price;
            }
            return sum;
        }

        public string Assign_Responsible_Manager(Manager manager)
        {
            if (manager.Access_Level <= Manager.Access_Levels.Second) 
            {
                Responsible_Manager = manager;
                return "Менеджер успешно назначен!";
            }
            return "Менеджер с данным уровнем доступа не может быть назначен";
        }
    }
}
