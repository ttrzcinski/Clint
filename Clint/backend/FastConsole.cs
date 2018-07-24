using System;
using System.Collections.Generic;
using System.Text;

namespace Clint
{
    class FastConsole
    {
        public static void lineBreak()
        {
            Console.WriteLine("----------------------------------");
        }

        public static void emptyLine()
        {
            Console.WriteLine("");
        }

        public static void pressAnyKey()
        {
            Console.ReadKey(true);
        }
    }
}
