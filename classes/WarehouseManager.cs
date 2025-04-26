using Microsoft.Data.Sqlite;

public class WarehouseManager
{
#pragma warning disable CS8618
    static SqliteConnection connection;
#pragma warning restore CS8618

    //Intializes SQLite connection + Auto creates table if it doesn't exists
    public static void InitDb(string connectionString)
    {
        connection = new SqliteConnection(connectionString);
        connection.Open();

        // Query for auto creation of Products table in database
        var createTableCmd = connection.CreateCommand();
        createTableCmd.CommandText = @$"
            CREATE TABLE
            IF NOT EXISTS 
            PRODUCTS 
            (
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                NAME TEXT,
                PRICE DECIMAL(6,2),
                QUANTITY INTEGER
            )";
        createTableCmd.ExecuteNonQuery();


        connection.Close();
    }
    public void AddProduct(Product product)
    {
        connection.Open();
        var AddProductCmd = connection.CreateCommand();
        AddProductCmd.CommandText = @$"
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
        AddProductCmd.ExecuteNonQuery();

        var successCmd = connection.CreateCommand();
        successCmd.CommandText = "SELECT changes()";
        using (var reader = successCmd.ExecuteReader())
        {
            reader.Read();
            if ((long)reader[0] == 1) { Console.WriteLine($"Produkt {product.Name} přídán úspěšně."); }
        }
        connection.Close();
    }
    public void DeleteProduct(Product product)
    {

    }

}