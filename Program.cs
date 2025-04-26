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
    new Product(Id:141, Name:"Limbus Company Don Quixote Plushie (boots included)",    Price:14999.90m,Quantity:1)
};

//TEST
var WM = new WarehouseManager();
foreach(Product product in samples)
{
    WM.AddProduct(product);
}