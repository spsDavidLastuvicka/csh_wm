WarehouseManager.InitDb(connectionString: "Data Source=products.db");

//TEST
var WM = new WarehouseManager();
WM.AddProduct(new Product(Id: 5, Name: "Věc1", Price: 3.30m, Quantity: 2));