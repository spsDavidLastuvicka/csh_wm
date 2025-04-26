class Product
{
    public static int Id { get; set; }
    public static int Name { get; set; }
    public static int Price { get; set; }
    public static int Quantity { get; set; }

    public Product(int Id, int Name, int Price, int Quantity)
    {
        Product.Id = Id;
        Product.Name = Name;
        Product.Price = Price;
        Product.Quantity = Quantity;
    }
}