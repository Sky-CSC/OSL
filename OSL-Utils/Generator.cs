using System.Text;
using System.Security.Cryptography;

namespace OSL_Utils
{
    public static class Generator
    {
        public static string GenerateSha1Id()
        {
            string input = Guid.NewGuid().ToString() + DateTime.UtcNow.Ticks;
            byte[] hashBytes = SHA1.HashData(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower()[..10];
        }
    }
}
