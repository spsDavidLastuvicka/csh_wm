public partial class WarehouseManager
{
    public void SearchProducts(string? name)
    {
        PrintProducts($"WHERE NAME LIKE '%{name}%'");
    }
    public void SearchProducts(string? name, decimal? price)
    {

        PrintProducts($"WHERE NAME LIKE '%{name}%' AND PRICE <= '{price}'");
    }
}