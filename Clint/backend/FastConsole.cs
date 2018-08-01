using System;

namespace Clint
{
    class FastConsole
    {
        public static void LineBreak() => Console.WriteLine("----------------------------------");

        public static void EmptyLine() => Console.WriteLine("");

        public static void PressAnyKey() => Console.ReadKey(true);

        public static void AsDefault() => Console.ResetColor();
        
        public static void AsError() => Console.ForegroundColor = ConsoleColor.Red;
        
        public static void AsWarning() => Console.ForegroundColor = ConsoleColor.Yellow;
        
        public static void AsPass() => Console.ForegroundColor = ConsoleColor.Green;

        public static void listColors()
        {
            var type = typeof(ConsoleColor);
            Console.BackgroundColor = ConsoleColor.Black;
            foreach (var name in Enum.GetNames(type))
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, name);
                Console.WriteLine(name);
            }
        }
    }
}
