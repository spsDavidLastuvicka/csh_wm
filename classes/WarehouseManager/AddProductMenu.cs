public partial class WarehouseManager
{
    static void PrintError(string Error)
    {
        int oldLeft = Console.CursorLeft;
        int oldTop = Console.CursorTop;

        Console.SetCursorPosition(0, 7);
        Tools.WriteColor(Text: Error, Foreground: ConsoleColor.Red);
        Console.SetCursorPosition(oldLeft, oldTop);
    }
    public static Product AddProductMenu()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Add product:");

        string[] fields =
        {
            "   Id:       ",
            "   Name:     ",
            "   Price:    ",
            "   Quantity: "
        };

        string[] values =
        {
            "",
            "",
            "",
            ""
        };

        char[] PriceKeys = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ',' };
        char[] Id_QuantityKeys = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        int choice = 0;

        foreach (string field in fields)
        {
            Console.WriteLine(field);
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.BackgroundColor = ConsoleColor.Black;

        Console.SetCursorPosition(0, choice + 1);
        Tools.WriteColor(Text: fields[choice], Background: ConsoleColor.Gray, Foreground: ConsoleColor.Black);

        //PriceKeys.Contains(Console.ReadKey(false).KeyChar.ToString())
        while (true)
        {
            ConsoleKeyInfo KeyRaw = Console.ReadKey(true);
            ConsoleKey Key = KeyRaw.Key;
            char KeyChar = KeyRaw.KeyChar;

            switch (Key)
            {
                case ConsoleKey.UpArrow:
                    if (choice != 0)
                    {
                        Console.SetCursorPosition(0, choice + 1);
                        Tools.WriteColor(Text: fields[choice], Background: ConsoleColor.Black, Foreground: ConsoleColor.White);
                        choice--; ;
                        Console.SetCursorPosition(0, choice + 1);
                        Tools.WriteColor(Text: fields[choice], Background: ConsoleColor.Gray, Foreground: ConsoleColor.Black);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (choice != fields.Length - 1)
                    {
                        Console.SetCursorPosition(0, choice + 1);
                        Tools.WriteColor(Text: fields[choice], Background: ConsoleColor.Black, Foreground: ConsoleColor.White);
                        choice++;
                        Console.SetCursorPosition(0, choice + 1);
                        Tools.WriteColor(Text: fields[choice], Background: ConsoleColor.Gray, Foreground: ConsoleColor.Black);
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (Console.CursorLeft > fields[1].Length)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    try
                    {
                        Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                    }
                    catch (Exception) { }
                    break;
                case ConsoleKey.Backspace:
                    try
                    {
                        values[choice] = values[choice].Remove(values[choice].Length - 1);
                    }
                    catch (Exception) { }
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Tools.WriteColor(Text: fields[choice], Background: ConsoleColor.Gray, Foreground: ConsoleColor.Black);
                    Console.Write(values[choice]);
                    int oldLeft = Console.CursorLeft;
                    for (int i = Console.BufferWidth - Console.CursorLeft; i > 1; i--)
                    {
                        Console.Write(" ");
                    }
                    Console.SetCursorPosition(oldLeft, Console.CursorTop);
                    break;
                case ConsoleKey.Enter:

                    decimal price;
                    int quantity;
                    if (values[1].Trim() == "" || values[1] == null)
                    {
                        PrintError(Error: "Missing name!");
                        break;
                    }
                    try
                    {
                        price = decimal.Parse(values[2]);
                    }
                    catch (FormatException)
                    {
                        PrintError(Error: "Missing price!");
                        break;
                    }
                    try
                    {
                        quantity = int.Parse(values[3]);
                    }
                    catch (FormatException)
                    {
                        PrintError(Error: "Missing quantity!");
                        break;
                    }
                    try
                    {
                        int id = int.Parse(values[0]);
                        Console.ResetColor();
                        Console.Clear();
                        return new Product(id, values[1], price, quantity);
                    }
                    catch (FormatException)
                    {
                        Console.ResetColor();
                        Console.Clear();
                        return new Product(values[1], price, quantity);
                    }
                case ConsoleKey.Escape:
                    Console.ResetColor();
                    return new Product(Id: -2, Name: "", Price: 0, Quantity: 0);
                default:
                    switch (choice)
                    {
                        case 0:
                            if (Id_QuantityKeys.Contains(KeyChar))
                            {
                                Console.Write(KeyChar);
                                values[choice] = values[choice] + KeyChar;
                            }
                            break;
                        case 1:
                            Console.Write(KeyChar);
                            values[choice] = values[choice] + KeyChar;
                            break;
                        case 2:
                            if (PriceKeys.Contains(KeyChar))
                            {
                                Console.Write(KeyChar);
                                values[choice] = values[choice] + KeyChar;
                            }
                            break;
                        case 3:
                            if (Id_QuantityKeys.Contains(KeyChar))
                            {
                                Console.Write(KeyChar);
                                values[choice] = values[choice] + KeyChar;
                            }
                            break;
                    }
                    break;

            }
        }
    }
}