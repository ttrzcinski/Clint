using System;

namespace Clint
{
    /*  */
    class AsciiConnectio
    {
        public static String disconnected()
        {
            return "|--o  o--| - disconnected";
        }

        public static String connecting()
        {
            return "|---oo---| - connecting";
        }
        
        public static String connected()
        {
            return "|---bd---| - connected";
        }

        public static String transfering()
        {
            return "|===bd===| - transfering";
        }
        
        public static String cannotFindSource()
        {
            return "|--o   ? | - cannot find source";
        }
    }
}