using Lesson_5_Warehouse.Employees;
using Lesson_5_Warehouse.Products;

namespace Lesson_5_Warehouse.Warehouses
{
    interface IWarehouse_Operations
    {
        string Add_Product(Product product, int quantity);
        string Transfer_Product(Warehouse other, Product product, int quantity);
        string Search_Product_By_SKU(string sku);
        float Total_Products_Price();
        string Assign_Responsible_Manager(Manager manager);
    }
}
