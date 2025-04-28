public partial class WarehouseManager
{
    public void AddSamples(Product[] Samples)
    {
        foreach (Product product in Samples)
        {
            AddProduct(product);
        }
    }
}