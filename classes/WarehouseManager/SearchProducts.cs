public partial class WarehouseManager
{
    public void SearchProducts(string? name)
    {
        PrintProducts($"WHERE NAME LIKE '%{name}%'");
    }
    public void SearchProducts(string? name, decimal? price)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        string reformatprice = price.ToString().Replace(',','.');
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        PrintProducts($"WHERE NAME LIKE '%{name}%' AND PRICE <= '{reformatprice}'");
    }
}