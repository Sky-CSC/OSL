using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace OSL_Common.System.SSLCertificate
{
    /// <summary>
    /// Gestion of SSL
    /// </summary>
    public class SSL
    {
        /// <summary>
        /// Bypass SSL for avoid error caused by ssl
        /// </summary>
        public static void BypassSSL()
        {
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);
        }
        /// <summary>
        /// Validate a certificate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns></returns>
        public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
