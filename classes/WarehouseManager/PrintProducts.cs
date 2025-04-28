using System.ComponentModel.Design;

public partial class WarehouseManager
{
    public void PrintProducts(string Condition = "")
    {
        Console.Clear();
        connection.Open();
        var selectCmd = connection.CreateCommand();
        selectCmd.CommandText = "SELECT * FROM PRODUCTS " + Condition;

        using (var reader = selectCmd.ExecuteReader())
        {
            if (!reader.HasRows)
            {
                Tools.WriteColor(Text: "Žádné data nenalezeny!\n", Foreground: ConsoleColor.Red);
            }
            else
            {
                while (reader.Read())
                {
                    Tools.WriteColor(Text: "ID:         ", Foreground: ConsoleColor.Red);
                    Console.Write($"{reader["ID"]}\n");

                    Tools.WriteColor(Text: "Name:       ", Foreground: ConsoleColor.Green);
                    Console.Write($"{reader["NAME"]}\n");

                    Tools.WriteColor(Text: "Price:      ", Foreground: ConsoleColor.Green);
                    Console.Write($"{reader["PRICE"]}\n");

                    Tools.WriteColor(Text: "Quantity:   ", Foreground: ConsoleColor.Green);
                    Console.Write($"{reader["QUANTITY"]}\n");

                    Console.Write("\n");
                }
            }
        }
        Console.ReadLine();
        connection.Close();
    }
}