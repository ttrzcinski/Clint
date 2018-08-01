using System;
using System.Collections.Generic;
using System.IO;
using Clint.backend.converters;
using Clint.backend.utilities;

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
        /// <param name="faceShown">shows face, by default true</param>
        private static void ClientTalk(string line, bool faceShown = true)
        {
            //Chop line string to lines
            var lines = line != null ? line.Split('\n') : new[] { "" };
            ClientTalk(lines, faceShown);
        }

        /// <summary>
        /// Passes lines them to client as response. 
        /// </summary>
        /// <param name="lines">lines to present</param>
        /// <param name="faceShown">shows face, by default true</param>
        private static void ClientTalk(string[] lines, bool faceShown = true)
        {
            FastConsole.AsWarning();
            if (faceShown)
            {
                //AsciiFace asciiFace = new AsciiFace();
                var faceNow = AsciiFace.happyBot;
                if (lines[0].StartsWith("KILL"))
                {
                    faceNow = AsciiFace.killedBot;
                    lines = new[]{"Aaaaccckhhh..."};
                }

                for (var i = 0; i < Math.Max(lines.Length, faceNow.Length); i++)
                {
                    var lineLeft = i < faceNow.Length ? faceNow[i] : "          ";
                    // TODO FIX CHOPPING TO THE END OF LINE
                    // TODO Chop lines right split up to console's width - lineLeft and if longer, another part lands in next line 
                    var lineRight = i < lines.Length ? lines[i] : "";
                    //Console.WriteLine("Line has {0} chars.", Console.WindowWidth);
                    if (Console.WindowWidth < lineLeft.Length + lineRight.Length)
                    {
                        //It means, that lineRight must be chopped into pieces
                        var lineRightSplit = lineRight.SplitAfter(Console.WindowWidth - lineLeft.Length);
                        Console.WriteLine($"{lineLeft} {lineRight}");
                    }
                    else
                    {
                        Console.WriteLine($"{lineLeft} {lineRight}");
                    }
            }
            }
            else
            {
                Console.WriteLine(lines);
            }
            FastConsole.AsDefault();
        }

        /// <summary>
        /// ASks give question to user and returns whole line of response.
        /// </summary>
        /// <param name="question">given question passed to user</param>
        /// <returns>line of response</returns>
        private static string ClientAsks(string question)
        {
            ClientTalk(question);
            return Console.ReadLine();
        }

        private static void MakeMeAFile()
        {
            var currDirectory = Directory.GetCurrentDirectory();
            ClientTalk($"We are in {currDirectory}");
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
                // Inform about existence of file.
                ClientTalk(string.Format("File (fileName) already exists.", fileName));
            }
        }

        // TODO Take loading JSON to menu into some generic separate method.
        
        private static void ShowMainMenu()
        {
            const string fullPath = "C:\\vsproj\\Clint\\Clint\\Clint\\backend\\menuses\\menu_main.json";
            var menuItems = CovertJSONTo.ParseJsonFile(fullPath);
            // If there was nothing
            if (menuItems.Count != 0)
            {
                foreach (var menuItem in menuItems)
                {
                    Console.WriteLine(menuItem.asMenuEntry());
                }
            }
            else
            {
                Console.WriteLine("9) Kill yourself!");
            }
        }
        
        private static void ShowGitMenu()
        {
            const string fullPath = "C:\\vsproj\\Clint\\Clint\\Clint\\backend\\menuses\\git_menu.json";
            var menuItems = CovertJSONTo.ParseJsonFile(fullPath);
            // If there was nothing
            if (menuItems.Count != 0)
            {
                foreach (var menuItem in menuItems)
                {
                    Console.WriteLine(menuItem.asMenuEntry());
                }
            }
            else
            {
                Console.WriteLine("9) Kill yourself!");
            }
        }

        private static void ShowClint()
        {
            FastConsole.LineBreak();
            FastConsole.EmptyLine();
            // TODO CHANGE THIS TO PROPERTY
            ClientTalk("Clint welcomes You:");
            FastConsole.EmptyLine();
            FastConsole.LineBreak();
            Console.WriteLine("How can help?");
            FastConsole.LineBreak();
            //TODO CONSUME JSON AND USE IT ON SCREEN

            ShowMainMenu();

            var alive = true;
            while (alive)
            {
                var choice = Console.ReadLine();
                //var date = DateTime.Now;
                switch (choice)
                {
                    case "0":
                        ShowMainMenu();
                        FastConsole.PressAnyKey();
                        break;
                    
                    case "1":
                        MakeMeAFile();
                        FastConsole.PressAnyKey();
                        break;
                    
                    case "2":
                        ShowGitMenu();
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