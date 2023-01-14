using OSL_Client;
using OSL_Client.Communication;
using OSL_Client.Configuration;
using OSL_Client.RiotApp;
using OSL_Client.RiotApp.API;
using OSL_Client.RiotApp.API.LCU;
using System.Diagnostics;
using System.Runtime.InteropServices;
using OSL_Client.RiotApp.MemoryProcessing;
using OSL_Client.Communication.OSLServer;
using System.Net;

Console.WriteLine("");
OSLLogger logger = new("Program");

// Register the handler
//CloseEvent.SetConsoleCtrlHandler(CloseEvent.Handler, true);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("###########################################");
Console.WriteLine("##### Hello and welcome to OSL Client #####");
Console.WriteLine("###### Just let this run, do nothing ######");
Console.WriteLine("# No forget to check if server is running #");
Console.WriteLine("###########################################\n");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("###########################");
Console.WriteLine("##### Version 0.1.0.0 #####");
Console.WriteLine("###########################\n");
Console.ResetColor();

Config.LoadConfig();
//Initialisation for acces att the champion selection or a game
//PostCom.Test2();
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
                //while (ProcessInfo.IdProcessInfo(Config.lockFileProcessId) != null)
                //{
                //    logger.log(LoggingLevel.INFO, "IdProcessInfo()", "Lol runing");
                //    Thread.Sleep(1000);
                //    string gameFlowPhase = ApiRequest.RequestGameClientAPI(UrlRequest.lolgameflowv1gameflowphase);
                //    LcuApi.GameFlowPhaseCheck(gameFlowPhase);

                //}
                //Console.WriteLine("Start");
                //TestClass.Test();
                //Console.WriteLine("End");

                string gameFlowPhase;
                do
                {
                    Thread.Sleep(1000);
                    gameFlowPhase = ApiRequest.RequestGameClientAPI(UrlRequest.lolgameflowv1gameflowphase); //Request game client api
                    LcuApi.GameFlowPhaseCheck(gameFlowPhase); //Check which phase
                    //string testInformation = ApiRequest.RequestGameClientAPI("/lol-perks/v1/currentpage");
                    //Console.WriteLine(testInformation);
                }
                while (gameFlowPhase != null);
            }
        }
    }
}


//See what phase is of the game
//if (ApiRequest.RequestGameClientAPI(LcuApi.lolgameflowv1session))
//while (true)
//{
//    logger.log(LoggingLevel.INFO, "RequestGameClientApi()", ApiRequest.RequestGameClientAPI(UrlRequest.lolgameflowv1gameflowphase));
//    Thread.Sleep(5000);
//}