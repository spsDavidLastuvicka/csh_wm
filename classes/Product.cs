public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product(int Id, string? Name, decimal Price, int Quantity)
    {
        this.Id = Id;
        this.Name = Name;
        this.Price = Price;
        this.Quantity = Quantity;
    }

    public Product(string? Name, decimal Price, int Quantity)
    {
        this.Id = -1;
        this.Name = Name;
        this.Price = Price;
        this.Quantity = Quantity;
    }
}