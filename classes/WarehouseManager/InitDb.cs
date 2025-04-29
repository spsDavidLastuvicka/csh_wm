using Microsoft.Data.Sqlite;

public partial class WarehouseManager
{
    //Intializes SQLite connection + Auto creates table if it doesn't exist
    public static void InitDb(string connectionString)
    {
        connection = new SqliteConnection(connectionString);
        connection2 = new SqliteConnection("Data Source=products.db");
        connection.Open();

        // Query for auto creation of Products table in database
        var createTableCmd = connection.CreateCommand();
        createTableCmd.CommandText =
        @$"
            CREATE TABLE
            IF NOT EXISTS 
            PRODUCTS 
            (
                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                NAME TEXT,
                PRICE DECIMAL(6,2),
                QUANTITY INTEGER
            )
        ";
        createTableCmd.ExecuteNonQuery();


        connection.Close();
    }
}