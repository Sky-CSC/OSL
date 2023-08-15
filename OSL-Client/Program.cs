using OSL_Client.Configuration;
using OSL_Client.Riot;
using OSL_Client.Riot.GameFlow;
using OSL_Client.Sockets;
using OSL_LcuApi;
using static OSL_Client.CloseEvent;

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("  ______    ______   __           ______   __  __                        __     ");
Console.WriteLine(" /      \\  /      \\ |  \\         /      \\ |  \\|  \\                     |  \\    ");
Console.WriteLine("|  $$$$$$\\|  $$$$$$\\| $$        |  $$$$$$\\| $$ \\$$  ______   _______  _| $$_   ");
Console.WriteLine("| $$  | $$| $$___\\$$| $$ ______ | $$   \\$$| $$|  \\ /      \\ |       \\|   $$ \\  ");
Console.WriteLine("| $$  | $$ \\$$    \\ | $$|      \\| $$      | $$| $$|  $$$$$$\\| $$$$$$$\\$$$$$$  ");
Console.WriteLine("| $$  | $$ _\\$$$$$$\\| $$ \\$$$$$$| $$   __ | $$| $$| $$    $$| $$  | $$ | $$ __ ");
Console.WriteLine("| $$__/ $$|  \\__| $$| $$_____   | $$__/  \\| $$| $$| $$$$$$$$| $$  | $$ | $$|  \\");
Console.WriteLine(" \\$$    $$ \\$$    $$| $$     \\   \\$$    $$| $$| $$ \\$$     \\| $$  | $$  \\$$  $$");
Console.WriteLine("  \\$$$$$$   \\$$$$$$  \\$$$$$$$$    \\$$$$$$  \\$$ \\$$  \\$$$$$$$ \\$$   \\$$   \\$$$$ ");
Console.WriteLine();
Console.ForegroundColor = ConsoleColor.Red;
//Console.WriteLine(" __     __                                __                              __         ______       ______  ");
//Console.WriteLine("|  \\   |  \\                              |  \\                           _/  \\       /      \\     /      \\ ");
//Console.WriteLine("| $$   | $$  ______    ______    _______  \\$$  ______   _______        |   $$      |  $$$$$$\\   |  $$$$$$\\");
//Console.WriteLine("| $$   | $$ /      \\  /      \\  /       \\|  \\ /      \\ |       \\        \\$$$$       \\$$__| $$   | $$$\\| $$");
//Console.WriteLine(" \\$$\\ /  $$|  $$$$$$\\|  $$$$$$\\|  $$$$$$$| $$|  $$$$$$\\| $$$$$$$\\        | $$       /      $$   | $$$$\\ $$");
//Console.WriteLine("  \\$$\\  $$ | $$    $$| $$   \\$$ \\$$    \\ | $$| $$  | $$| $$  | $$        | $$      |  $$$$$$    | $$\\$$\\$$");
//Console.WriteLine("   \\$$ $$  | $$$$$$$$| $$       _\\$$$$$$\\| $$| $$__/ $$| $$  | $$       _| $$_  __ | $$_____  __| $$_\\$$$$");
//Console.WriteLine("    \\$$$    \\$$     \\| $$      |       $$| $$ \\$$    $$| $$  | $$      |   $$ \\|  \\| $$     \\|  \\\\$$  \\$$$");
//Console.WriteLine("     \\$      \\$$$$$$$ \\$$       \\$$$$$$$  \\$$  \\$$$$$$  \\$$   \\$$       \\$$$$$$ \\$$ \\$$$$$$$$ \\$$ \\$$$$$$ ");
Console.WriteLine(" __     __                                __                              __          __       _______  ");
Console.WriteLine("|  \\   |  \\                              |  \\                           _/  \\       _/  \\     |       \\ ");
Console.WriteLine("| $$   | $$  ______    ______    _______  \\$$  ______   _______        |   $$      |   $$     | $$$$$$$ ");
Console.WriteLine("| $$   | $$ /      \\  /      \\  /       \\|  \\ /      \\ |       \\        \\$$$$       \\$$$$     | $$____  ");
Console.WriteLine(" \\$$\\ /  $$|  $$$$$$\\|  $$$$$$\\|  $$$$$$$| $$|  $$$$$$\\| $$$$$$$\\        | $$        | $$     | $$   \\ ");
Console.WriteLine("  \\$$\\  $$ | $$    $$| $$   \\$$ \\$$    \\ | $$| $$  | $$| $$  | $$        | $$        | $$      \\$$$$$$$\\");
Console.WriteLine("   \\$$ $$  | $$$$$$$$| $$       _\\$$$$$$\\| $$| $$__/ $$| $$  | $$       _| $$_  __  _| $$_  __|  \\__| $$");
Console.WriteLine("    \\$$$    \\$$     \\| $$      |       $$| $$ \\$$    $$| $$  | $$      |   $$ \\|  \\|   $$ \\|  \\\\$$    $$");
Console.WriteLine("     \\$      \\$$$$$$$ \\$$       \\$$$$$$$  \\$$  \\$$$$$$  \\$$   \\$$       \\$$$$$$ \\$$ \\$$$$$$ \\$$ \\$$$$$$ ");
Console.ResetColor();
Console.WriteLine();
Console.ResetColor();
Console.WriteLine();

SetConsoleCtrlHandler(new SetConsoleCtrlEventHandler(Handler), true);

Config.LoadConfig();

//Console.WriteLine(Directory.GetCurrentDirectory().Replace("\\", "/") + "\n");
//Console.WriteLine(Environment.CurrentDirectory.Replace("\\", "/") + "\n");
//Path.DirectorySeparatorChar;

AsyncClient.StartClient("Hello is OSL-Client");
Thread.Sleep(1000);

while (true)
{
    if (LeagueClient.CheckLaunch()) //Chek if lol is running
    {
        if (LeagueClient.LockFile()) //Get lock file pass
        {
            if (LeagueClient.SetHostApi()) //Get pass and host of client api
            {
                RegionLocale.SetRegionLocale(); //Send region and laguage for download in OSL-Web information
                string gameFlowPhase;
                do
                {
                    Thread.Sleep(1000);
                    gameFlowPhase = GameFlow.PhaseRequest();
                    GameFlow.Phase(gameFlowPhase); //Check which phase
                }
                while (gameFlowPhase != null);
            }
        }
    }
}
