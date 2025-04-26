public partial class Tools
{
	public static void WriteColor(string Text, ConsoleColor Background = ConsoleColor.Black, ConsoleColor Foreground = ConsoleColor.White)
	{
		ConsoleColor OldBackground = Console.BackgroundColor;
		ConsoleColor OldForeground = Console.ForegroundColor;

		Console.BackgroundColor = Background;
		Console.ForegroundColor = Foreground;

		Console.Write(Text);

		Console.ForegroundColor = OldForeground;
		Console.BackgroundColor = OldBackground;
	}
}
