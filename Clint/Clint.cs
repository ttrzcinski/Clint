using Clint.backend.menuses;
using System;
using System.Collections.Generic;
using System.IO;
//using System.Speech.Synthesis; //only in .NET Standard

namespace Clint
{
    /// <summary>
    /// This application serves as CLI for making templates inside code projects.
    /// </summary>
    public class Clint
    {
        /// <summary>
        /// Chops line strings into lines and passes them to client as response. 
        /// </summary>
        /// <param name="line">line to chop</param>
        /// <param name="faceShown">flag of showing face, by default true</param>
        private static void ClientTalk(string line, bool faceShown = true)
        {
            //Chop line string to lines
            var tokens = line != null ? line.Split('\n') : new[] { "" };
            ClientTalk(tokens, faceShown);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="given"></param>
        /// <param name="faceShown"></param>
        private static void ClientTalk(string[] given, bool faceShown = true)
        {
            if (faceShown)
            {
                //AsciiFace asciiFace = new AsciiFace();
                var faceNow = AsciiFace.happyBot;
                if (given[0].StartsWith("KILL"))
                {
                    faceNow = AsciiFace.killedBot;
                    given = new[]{"Aaaaccckhhh..."};
                }

                //foreach (var line in faceNow)
                for (int i = 0; i < Math.Max(given.Length, faceNow.Length); i++)
                {
                    var lineLeft = i < faceNow.Length ? faceNow[i] : "          ";
                    // TODO FIX CHOPPING TO THE END OF LINE
                    var lineRight = i < given.Length ? given[i] : "";
                    Console.WriteLine($"{lineLeft} {lineRight}");
                }
            }
            else
            {
                Console.WriteLine(given);
            }
        }

        private static string ClientAsks(String question)
        {
            ClientTalk(question);
            return Console.ReadLine();
        }

        private static void MakeMeAFile()
        {
            var currDirectory = Directory.GetCurrentDirectory();
            ClientTalk("We are in " + currDirectory);
            //Ask about name of file
            var fileName = ClientAsks("How this file should be named?");
            //Obtain current directory
            var fullPathString = Path.Combine(currDirectory, fileName);
            //
            if (!File.Exists(fullPathString))
            {
                using (var fs = File.Create(fullPathString))
                {
                    fs.WriteByte(1);
                }

                ClientTalk("File was created.");
            }
            else
            {
                //TODO ADD PARAM IN STRING TO FILL WITH FILE NAME
                ClientTalk("File already exists.");
            }
        }

        private static void showMainMenu()
        {
            var numberOfItems = 0;
            var menuItems = Convert_JSON2Menu.ParseJsonFile();
            foreach (var menuItem in menuItems) {
                Console.WriteLine(menuItem.asMenuEntry());
                numberOfItems++;
            }
            //If there was nothing
            if (numberOfItems == 0)
            {
                Console.WriteLine("9) Kill yourself!");
            }
        }

        private static void ShowClint()
        {
            FastConsole.LineBreak();
            FastConsole.EmptyLine();
            //CHANGE THIS TRUE TO PROPERTY
            ClientTalk("Clint welcomes You:");
            FastConsole.EmptyLine();
            FastConsole.LineBreak();
            Console.WriteLine("How can help?");
            FastConsole.LineBreak();
            //TODO CONSUME JSON AND USE IT ON SCREEN

            showMainMenu();

            var alive = true;
            while (alive)
            {
                var choice = Console.ReadLine();
                //var date = DateTime.Now;
                switch (choice)
                {
                    case "0":
                        showMainMenu();
                        FastConsole.PressAnyKey();
                        break;
                    
                    case "1":
                        MakeMeAFile();
                        FastConsole.PressAnyKey();
                        break;

                    case "5":
                        ClientTalk("");
                        FastConsole.PressAnyKey();
                        break;

                    case "6":
                        var longText = new[]{"'dotnet.exe' (CoreCLR: DefaultDomain):",
                            "Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\2.1.1\\System.Private.CoreLib.dll'.",
                            "Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.",
                            "dotnet.exe'(CoreCLR: clrhost): Loaded 'C:\\vsproj\\Clint\\Clint\\Clint\\bin\\Debug\\netcoreapp2.1\\Clint.dll'.",
                            "Symbols loaded.",
                            "dotnet.exe'(CoreCLR: clrhost): Loaded 'C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\2.1.1\\System.Runtime.dll'" +
                            ".Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled."};
                        ClientTalk(longText);
                        FastConsole.PressAnyKey();
                        break;

                    case "9":
                        ClientTalk("KILL");
                        FastConsole.PressAnyKey();
                        alive = false;
                        break;

                    default:
                        ClientTalk("I didn't get it.. what?!");
                        break;
                }
            }

            //Console.Write($"Push the button, {name}, to stop wasting time on {date:d} {date:t} ...\n\n");
            //pressAnyKey();
        }

        static void Main(string[] args)
        {
            ShowClint();
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