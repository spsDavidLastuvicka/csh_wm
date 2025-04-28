public partial class WarehouseManager
{
    public void AddProduct(Product product)
    {
        if(product.Id != -2)
        {
            connection.Open();
            var AddProductCmd = connection.CreateCommand();

            //products can be either added with an ID or have one generated in db with auto_increment
            if (product.Id == -1)
            {
                AddProductCmd.CommandText =
                @$"
                    INSERT INTO PRODUCTS(NAME,PRICE,QUANTITY) 
                    SELECT '{product.Name}','{product.Price}',{product.Quantity} 
                    WHERE NOT EXISTS
                    (
                        SELECT * FROM PRODUCTS
                        WHERE ID    ={product.Id}
                        AND NAME    ='{product.Name}' 
                        AND PRICE   ='{product.Price}'
                        AND QUANTITY={product.Quantity}
                    );
                ";
            }
            else
            {
                AddProductCmd.CommandText =
                @$"
                    INSERT INTO PRODUCTS(ID,NAME,PRICE,QUANTITY) 
                    SELECT '{product.Id}','{product.Name}','{product.Price}',{product.Quantity} 
                    WHERE NOT EXISTS
                    (
                        SELECT * FROM PRODUCTS
                        WHERE ID    ={product.Id}
                        AND NAME    ='{product.Name}' 
                        AND PRICE   ='{product.Price}'
                        AND QUANTITY={product.Quantity}
                    );
                ";
            }
            AddProductCmd.ExecuteNonQuery();

            //
            var successCmd = connection.CreateCommand();
            successCmd.CommandText = "SELECT changes()";
            using (var reader = successCmd.ExecuteReader())
            {
                reader.Read();
                if ((long)reader[0] == 1) { Console.WriteLine($"Produkt {product.Name} přídán úspěšně."); }
            }
            connection.Close();
        }
    }
    public void AddProduct(string Name, decimal Price, int Quantity)
    {
        AddProduct(new Product(Name, Price, Quantity));
    }
}