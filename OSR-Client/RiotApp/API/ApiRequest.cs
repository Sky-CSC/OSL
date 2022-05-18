using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using OSR_Client.Configuration;

namespace OSR_Client.RiotApp.API
{
    internal class ApiRequest
    {
        private static OSRLogger _logger = new OSRLogger("ApiRequest");

        public static string RequestGameClientAPI(string nameRequest)
        {
            SSL.BypassSSL();
            string httpsLocalHost = Config.localIpHttps + ":" + Config.lockFilePort + nameRequest;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpsLocalHost);
                request.Headers["Accept"] = "application/json";
                request.Headers["Host"] = Config.GameClientApiLocalHost;
                request.Headers["Authorization"] = Config.GameClientApiPassword;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                _logger.log(LoggingLevel.INFO, "RequestGameClientAPI", "Request to " + httpsLocalHost + " was successful");
                return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "RequestGameClientAPI", "Request to " + httpsLocalHost + " failed, " + e.Message);
                return null;
            }
            //_logger.log(LoggingLevel.ERROR, "RequestGameClientAPI", "Request to " + httpsLocalHost + " failed");
            //return null;
        }

        public static string RequestGameClientReplayAPI(string nameRequest)
        {
            SSL.BypassSSL();
            string httpsLocalHost = Config.localIpHttps + ":" + Config.portRiot + nameRequest;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpsLocalHost);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream resStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(resStream);
                _logger.log(LoggingLevel.INFO, "RequestGameClientReplayAPI", "Request to " + httpsLocalHost + " was successful");
                return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                _logger.log(LoggingLevel.ERROR, "RequestGameClientReplayAPI", "Request to " + httpsLocalHost + " failed, " + e.Message);
                return null;
            }
        }
    }
    class SSL
    {
        public static void BypassSSL()
        {
            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(ValidateServerCertificate);
        }
        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }

}
