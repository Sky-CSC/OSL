using System.Text;
using System.Security.Cryptography;

namespace OSL_Utils.Generator
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

        /// <summary>
        /// Generate a Token 
        /// </summary>
        /// <returns></returns>
        public static string GenerateToken()
        {
            byte[] bytes = RandomNumberGenerator.GetBytes(32);
            return Convert.ToBase64String(bytes);
        }
    }
}
