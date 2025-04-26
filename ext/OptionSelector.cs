public partial class Tools
{
    public static int OptionSelector(string Text, params string[] Options)
    {
        Console.Clear();
        Console.WriteLine(Text);

        int option = 0;
        bool first_line = true;

        WriteColor(Text: "\t" + Options[option] + "\n", Background: ConsoleColor.White, Foreground: ConsoleColor.Black);
        foreach (string initial_option in Options)
        {
            if (first_line) { first_line = false; continue; }
            Console.WriteLine("\t" + initial_option);
        }
        Console.CursorTop = 1;

        while (true)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.DownArrow:
                    if (option + 1 < Options.Count())
                    {
                        Console.CursorLeft = 0;
                        Console.WriteLine("\t" + Options[option]);

                        option++;
                        Console.CursorLeft = 0;
                        Console.CursorTop = option + 1;
                        WriteColor(Text: "\t" + Options[option], Background: ConsoleColor.White, Foreground: ConsoleColor.Black);
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (option > 0)
                    {
                        Console.CursorLeft = 0;
                        Console.WriteLine("\t" + Options[option]);

                        option--;
                        Console.CursorLeft = 0;
                        Console.CursorTop = option + 1;
                        WriteColor(Text: "\t" + Options[option], Background: ConsoleColor.White, Foreground: ConsoleColor.Black);
                    }
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    return option;
            }
        }
    }
}