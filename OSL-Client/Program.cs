using OSL_Client;
using OSL_Client.Communication;
using OSL_Client.Configuration;
using OSL_Client.RiotApp;
using OSL_Client.RiotApp.API;
using OSL_Client.RiotApp.API.LCU;
using System.Diagnostics;
using System.Runtime.InteropServices;
//using OSL_Client.RiotApp.MemoryProcessing;
using OSL_Client.Communication.OSLServer;
using System.Net;

Console.WriteLine("");
OSLLogger logger = new("Program");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("###########################################");
Console.WriteLine("##### Hello and welcome to OSL Client #####");
Console.WriteLine("###### Just let this run, do nothing ######");
Console.WriteLine("# No forget to check if server is running #");
Console.WriteLine("###########################################\n");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("###########################");
Console.WriteLine("##### Version 0.1.0 #####");
Console.WriteLine("###########################\n");
Console.ResetColor();

Config.LoadConfig();
//Initialisation for acces att the champion selection or a game

String data = "Hello OSL-Server is OSL-Client managed by Sky";
AsyncClient.StartClient(data);
//while (!AsyncClient.StartClient(data))
//{

//    Thread.Sleep(1000);
//}

while (true)
{
    if (LaunchChecker.LoLLauncherCheck()) //Chek if lol is running
    {
        if (FilesRiotApp.LockFileCheck()) //Get lock file pass
        {
            if (Config.SetHostPassGameClientApi()) //Get pass and host of client api
            {
                string gameFlowPhase;
                do
                {
                    Thread.Sleep(1000);
                    gameFlowPhase = ApiRequest.RequestGameClientAPI(UrlRequest.lolgameflowv1gameflowphase); //Request game client api
                    LcuApi.GameFlowPhaseCheck(gameFlowPhase); //Check which phase
                }
                while (gameFlowPhase != null);
            }
        }
    }
}