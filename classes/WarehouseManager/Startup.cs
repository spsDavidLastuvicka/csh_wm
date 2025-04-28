using System.IO;
public partial class WarehouseManager
{
    public static void Startup()
    {
        if (!File.Exists("temp_products.db"))
        {
            if (File.Exists("products.db"))
            {
                File.Copy("products.db", "temp_products.db");
            }
            else
            {
                WarehouseManager.InitDb(connectionString: "Data Source=products.db");
                File.Copy("products.db", "temp_products.db");
            }
        }
    }
}