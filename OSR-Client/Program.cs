using OSR_Client;
using OSR_Client.Configuration;
using OSR_Client.RiotApp;
using OSR_Client.RiotApp.API;
using OSR_Client.RiotApp.API.LCU;

Console.WriteLine("");
OSRLogger logger = new("Program");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("####################################");
Console.WriteLine("# Hello and welcome to OSR manager #");
Console.WriteLine("####################################\n");
Console.ResetColor();

//Config.LoadConfigHost();

//Initialisation for acces att the champion selection or a game
if (LaunchChecker.LoLLauncherCheck())
{
    if (FilesRiotApp.LockFileCheck())
    {
        if (Config.SetHostPassGameClientApi())
        {
            string gameFlowPhase = ApiRequest.RequestGameClientAPI(UrlRequest.lolgameflowv1gameflowphase);
            LcuApi.GameFlowPhaseCheck(gameFlowPhase);
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