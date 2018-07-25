using System;

namespace Clint
{
    class FastConsole
    {
        public static void LineBreak() => Console.WriteLine("----------------------------------");

        public static void EmptyLine() => Console.WriteLine("");

        public static void PressAnyKey() => Console.ReadKey(true);
    }
}
