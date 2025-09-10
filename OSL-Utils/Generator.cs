using System.Text;
using System.Security.Cryptography;

namespace OSL_Utils
{
    /// <summary>
    /// Generator class to generate unique ids
    /// </summary>
    public static class Generator
    {
        /// <summary>
        /// Generate sha1 id
        /// </summary>
        /// <returns></returns>
        public static string GenerateSha1Id()
        {
            string input = Guid.NewGuid().ToString() + DateTime.UtcNow.Ticks;
            byte[] hashBytes = SHA1.HashData(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower()[..10];
        }
    }
}
