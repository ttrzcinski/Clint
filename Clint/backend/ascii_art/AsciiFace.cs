using System;

namespace Clint
{
    /*  */
    class AsciiFace
    {
        public static String[] happyBot = 
               new String[] {
                            "-----------", 
                            "|         |",
                            "| o     o |", 
                            "|         |", 
                            "|   \\_/   |",
                            "-----------"};

        // TODO  Change those also to consts
        public static String[] neutralBot = 
            new String[] {
                       "-----------", 
                       "|         |",
                       "| o     o |", 
                       "|         |", 
                       "|   ---   |",
                       "-----------"};
        
        public static String[] sadBot = 
            new String[] {"-----------", 
                       "|         |",
                       "| o     o |", 
                       "|         |", 
                       "|   /\"\\   |",
                       "-----------"};
        
        public static String[] angryBot = 
            new String[] {"-----------", 
                       "| \\    /  |",
                       "| o     o |", 
                       "|         |", 
                       "|   /\"\\   |",
                       "-----------"};
        
        public static String[] talkingBot1 = 
            new String[] {
                       "-----------", 
                       "|         |",
                       "| o     o |", 
                       "|         |", 
                       "|   <=>   |",
                       "-----------"};
        
        public static String[] killedBot =
            new String[] {
                    "-----------",
                    "|         |",
                    "| X     X |",
                    "|  -----  |",
                    "|    \\\\   |",
                    "-----------"};

        public static String[] sleepingBot = 
            new String[] {
                       "-----------", 
                       "|    Zzz  |",
                       "| ==Z  == |", 
                       "|  Z      |", 
                       "|   ---   |",
                       "-----------"};
    }
}