using OSL_Client.Configuration;
using OSL_Client.Riot;
using OSL_Client.Riot.GameFlow;
using OSL_Client.Sockets;
using static OSL_Client.CloseEvent;

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("###########################################");
Console.WriteLine("##### Hello and welcome to OSL Client #####");
Console.WriteLine("###### Just let this run, do nothing ######");
Console.WriteLine("# No forget to check if server is running #");
Console.WriteLine("###########################################\n");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("###########################");
Console.WriteLine("###### Version 1.1.0 ######");
Console.WriteLine("###########################\n");
Console.ResetColor();

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
