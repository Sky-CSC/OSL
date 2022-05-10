using OSR_Client;
using OSR_Client.Config;

Console.WriteLine("");
OSRLogger logger = new("Program");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("####################################");
Console.WriteLine("# Hello and welcome to OSR manager #");
Console.WriteLine("####################################\n");
Console.ResetColor();

Config.LoadConfigHost();
Console.WriteLine(Config.ip + Config.port);