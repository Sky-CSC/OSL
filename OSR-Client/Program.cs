using OSR_Client;
using OSR_Client.Configuration;
using OSR_Client.RiotApp;

Console.WriteLine("");
OSRLogger logger = new("Program");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("####################################");
Console.WriteLine("# Hello and welcome to OSR manager #");
Console.WriteLine("####################################\n");
Console.ResetColor();

Config.LoadConfigHost();
LaunchChecker.LoLLauncherCheck();
