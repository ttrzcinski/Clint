using System;
using System.IO;
using System.Speech.Synthesis;

namespace Clint
{
    /* This application serves as CLI for making templates inside code projects.
            Console.WriteLine("<C>ommand");
            Console.WriteLine("<L>ine");
            Console.WriteLine("<I>nterface");
            Console.WriteLine("<N>ew");
            Console.WriteLine("<T>emplar");
     */
    class Clint
    {
        private static void clientTalk(String given)
        {
            //Chop given string to lines
            String[] tokenized = given != null ? given.Split('\n') : new String[] { "" };
            clientTalk(tokenized, true);
        }

        private static void clientTalk(String given, bool faceShown)
        {
            //Chop given string to lines
            String[] tokenized = given != null ? given.Split('\n') : new String[] { "" };
            clientTalk(tokenized, faceShown);
        }

        private static void clientTalk(String[] given)
        {
            clientTalk(given, true);
        }

        private static void clientTalk(String[] given, bool faceShown)
        {
            if (faceShown)
            {
                //AsciiFace asciiFace = new AsciiFace();
                String[] faceNow = AsciiFace.happyBot;
                if (given[0].StartsWith("KILL"))
                {
                    faceNow = AsciiFace.killedBot;
                    given = new String[]{"Aaaaccckhhh..."};
                }

                //foreach (var line in faceNow)
                for (int i = 0; i < Math.Max(given.Length, faceNow.Length); i++)
                {
                    String lineLeft = i < faceNow.Length ? faceNow[i] : "          ";
                    //TODO FIX CHOPPING TO THE END OF LINE
                    String lineRight = i < given.Length ? given[i] : "";
                    Console.WriteLine(lineLeft + " " + lineRight);
                }
            }
            else
            {
                Console.WriteLine(given);
            }
        }

        static String clientAsks(String question)
        {
            clientTalk(question);
            String an_answer = Console.ReadLine();
            return an_answer;
        }

        static void Main(string[] args)
        {
            FastConsole.lineBreak();
            FastConsole.emptyLine();
            //CHANGE THIS TRUE TO PROPERTY
            clientTalk("Clint welcomes You:");
            FastConsole.emptyLine();
            FastConsole.lineBreak();
            Console.WriteLine("How can help?");
            FastConsole.lineBreak();
            //TODO CONSUME JSON AND USE IT ON SCREEN
            Console.WriteLine("0) List all files in current location.");
            Console.WriteLine("1) Create me new file.");
            Console.WriteLine("2) GIT - make it a new repo");
            Console.WriteLine("3) Build this project");
            //Make it a battleship game with use of nukes and real world map?!
            Console.WriteLine("4) Let's play a game - Dice Lairs?");//WWIII?!");
            Console.WriteLine("5} Show yourself!");
            Console.WriteLine("6} Lorem ipsum!");
            Console.WriteLine("9} Kill yourself!");

            bool alive = true;
            while (alive)
            {
                var choice = Console.ReadLine();
                //var date = DateTime.Now;

                //var choice = "5";
                switch (choice)
                {
                    case "1":
                        String currDirectory = Directory.GetCurrentDirectory();
                        clientTalk("We are in " + currDirectory);
                        //Ask about name of file
                        String fileName = clientAsks("How this file should be named?");
                        //Obtain current directory
                        String fullPathString = System.IO.Path.Combine(currDirectory, fileName);
                        //
                        if (!System.IO.File.Exists(fullPathString))
                        {
                            using (System.IO.FileStream fs = System.IO.File.Create(fullPathString))
                            {
                                fs.WriteByte(1);
                            }

                            clientTalk("File was created.");
                        }
                        else
                        {
                            //TODO ADD PARAM IN STRING TO FILL WITH FILE NAME
                            clientTalk("File already exists.");
                        }

                        FastConsole.pressAnyKey();
                        break;

                    case "5":
                        clientTalk("", true);
                        FastConsole.pressAnyKey();
                        break;

                    case "6":
                        String[] longText = new String[]{"'dotnet.exe' (CoreCLR: DefaultDomain):",
                            "Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\2.1.1\\System.Private.CoreLib.dll'.",
                            "Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.",
                            "dotnet.exe'(CoreCLR: clrhost): Loaded 'C:\\vsproj\\Clint\\Clint\\Clint\\bin\\Debug\\netcoreapp2.1\\Clint.dll'.",
                            "Symbols loaded.",
                            "dotnet.exe'(CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\2.1.1\\System.Runtime.dll'" +
                            ".Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled."};
                        clientTalk(longText);
                        FastConsole.pressAnyKey();
                        break;

                    case "9":
                        clientTalk("KILL");
                        FastConsole.pressAnyKey();
                        alive = false;
                        break;

                    //TODO add default here
                    default:
                        clientTalk("I didn't get it.. what?!");
                        break;
                }
            }

            //Console.Write($"Push the button, {name}, to stop wasting time on {date:d} {date:t} ...\n\n");
            //pressAnyKey();
        }
    }
}

// Ideas
// - Add processing of entry arguments
// - Add class to generate file on HDD with or without content in lines
// - Add extending file with adding lines at it's end
// - Add removal of files in pointed location and in current catalog
// - add text-to-speech separate application/agent

// - Add some animated ascii arts - it's 21st centrym like
//   |--b  d--| - disconnected
//   |---bd---| - connecting
//   |---oo---| - connected
//   |===oo===| - transfering
//   |--b   ? | - cannot find source