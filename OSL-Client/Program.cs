using OSL_Client;
using OSL_Client.Communication;
using OSL_Client.Configuration;
using OSL_Client.RiotApp;
using OSL_Client.RiotApp.API;
using OSL_Client.RiotApp.API.LCU;
using System.Diagnostics;
using System.Runtime.InteropServices;

Console.WriteLine("");
OSLLogger logger = new("Program");

// Register the handler
//CloseEvent.SetConsoleCtrlHandler(CloseEvent.Handler, true);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("####################################");
Console.WriteLine("# Hello and welcome to OSL manager #");
Console.WriteLine("####################################\n");
Console.ResetColor();

//Config.LoadConfigHost();
//Initialisation for acces att the champion selection or a game
//PostCom.Test2();
while (true)
{
    if (LaunchChecker.LoLLauncherCheck())
    {
        if (FilesRiotApp.LockFileCheck())
        {
            if (Config.SetHostPassGameClientApi())
            {
                //while (ProcessInfo.IdProcessInfo(Config.lockFileProcessId) != null)
                //{
                //    logger.log(LoggingLevel.INFO, "IdProcessInfo()", "Lol runing");
                //    Thread.Sleep(1000);
                //    string gameFlowPhase = ApiRequest.RequestGameClientAPI(UrlRequest.lolgameflowv1gameflowphase);
                //    LcuApi.GameFlowPhaseCheck(gameFlowPhase);

                //}
                string gameFlowPhase;
                do
                {
                    Thread.Sleep(1000);
                    gameFlowPhase = ApiRequest.RequestGameClientAPI(UrlRequest.lolgameflowv1gameflowphase);
                    LcuApi.GameFlowPhaseCheck(gameFlowPhase);
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