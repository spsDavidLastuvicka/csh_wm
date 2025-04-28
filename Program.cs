using Microsoft.Data.Sqlite;
//ROLLBACK FUNCTION
//WarehouseManager.Startup();
//WarehouseManager.InitDb(connectionString: "Data Source=temp_products.db");

WarehouseManager.InitDb(connectionString: "Data Source=products.db");

//SAMPLE DATA
Product[] samples =
{
    new Product(Id:1,   Name:"Mobilní telefon",                                        Price:4990.90m, Quantity:4),
    new Product(Id:2,   Name:"Osobní počítač",                                         Price:7890.90m, Quantity:2),
    new Product(Id:3,   Name:"Bezdrátové sluchátka",                                   Price:890.90m,  Quantity:9),
    new Product(Id:4,   Name:"Učebnice češtiny",                                       Price:320.90m,  Quantity:22),
    new Product(Id:5,   Name:"Mountain Dew 2l",                                        Price:26.90m,   Quantity:29),
    new Product(Id:6,   Name:"Stolní lampa",                                           Price:529.90m,  Quantity:7),
    new Product(Id:7,   Name:"Monitor",                                                Price:4899.90m, Quantity:2),
    new Product(Id:8,   Name:"Papír A4",                                               Price:0.90m,    Quantity:299),
    new Product(Id:12,  Name:"Limbus Company Don Quixote Plushie (boots included)",    Price:14999.90m,Quantity:1)
};


var WM = new WarehouseManager();

bool running = true;
//MAIN LOOP
while(running)
{
    switch (WarehouseManager.MainMenu()+1)
    {
        case 1: //ADD PRODUCTS
            try
            {
                WM.AddProduct(WarehouseManager.AddProductMenu());
            }
            catch(SqliteException)
            {
                Console.WriteLine("ERROR DATABÁZE. PRODUKT S TÍMTO ID UZ EXISTUJE.");
                Console.ReadLine();
            }
            break;
        case 2: //ADD SAMPLES
            try
            {
                WM.AddSamples(samples);
            }
            catch(SqliteException)
            {
                Console.WriteLine("ERROR DATABÁZE. ALESPOŇ JEDEN PRODUKT S TÍMTO ID UZ EXISTUJE.");
                Console.ReadLine();
            }
            break;
        case 3: //PRINT PRODUCTS
            WM.PrintProducts();
            Thread.Sleep(100);
            break;
        case 4: //SEARCH PRODUCTS BY NAME
            Console.Write("Zadejte jméno produktu: ");
            WM.SearchProducts(Console.ReadLine());
            break;  
        case 5: //SEARCH PRODUCTS BY NAME AND PRICE
            Console.Write("Zadejte jméno produktu: ");
            string? name = Console.ReadLine();
            Console.WriteLine("Zadejte max. cenu produktu ve formátu 0,00");
            decimal price = 0.0m;
            decimal.TryParse(Console.ReadLine(), out price);
            WM.SearchProducts(name,price);
            break;  
        case 6: //DELETE PRODUCTS
            Console.Write("ID produktu na smazání?: ");
            int id;
            while(!int.TryParse(Console.ReadLine(),out id)){
                Console.Write("Špatný vstup. Zkuste znovu:");
            }
            WM.DeleteProduct(id);
            break;

        //NOT FUNCTIONAL
        // case 7: //CONFIRM
        //     WarehouseManager.connection.Dispose();
        //     File.Delete("products.db");
        //     File.Copy("temp_products.db","products.db");
        //     Thread.Sleep(100);
        //     File.Delete("temp_products.db");
        //     WarehouseManager.InitDb(connectionString:"Data Source=temp_products.db");
        //     running = false;
        //     break;
        // case 8: //ROLLBACK
        //     File.Delete("temp_products.db");
        //     File.Copy("products.db", "temp_products.db");
        //     break;
    }
}