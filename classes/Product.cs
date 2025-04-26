public class Product
{
    public static int Id { get; set; }
    public static string? Name { get; set; }
    public static decimal Price { get; set; }
    public static int Quantity { get; set; }

    public Product(int Id, string? Name, decimal Price, int Quantity)
    {
        Product.Id = Id;
        Product.Name = Name;
        Product.Price = Price;
        Product.Quantity = Quantity;
    }
}