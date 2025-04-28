public partial class WarehouseManager
{
    public void DeleteProduct(int Id)
    {
        connection.Open();

        var deleteCmd = connection.CreateCommand();
        deleteCmd.CommandText =
        @$"
            DELETE FROM PRODUCTS
            WHERE ID={Id};
        ";
        deleteCmd.ExecuteNonQuery();

        var successCmd = connection.CreateCommand();
        successCmd.CommandText = "SELECT changes()";
        using (var reader = successCmd.ExecuteReader())
        {
            reader.Read();
            if ((long)reader[0] == 1) { Console.WriteLine($"Produkt {Id} smazán úspěšně."); }
        }

        connection.Close();
    }
}