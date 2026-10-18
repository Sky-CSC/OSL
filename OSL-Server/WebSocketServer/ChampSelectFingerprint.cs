using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OSL_Lcu.Schema.Lcu;
using System.Security.Cryptography;
using System.Text;

namespace OSL_Server.WebSocketServer;

/// <summary>
/// Computes a hash of a champion select session that ignores what changes at every poll without meaning
/// (the timer values). The overlay only reads <c>timer.phase</c>, it runs its own countdown.
/// Two sessions with the same fingerprint do not need to be sent again.
/// </summary>
internal static class ChampSelectFingerprint
{
    public static string Compute(ChampSelectSession session)
    {
        JObject json = JObject.FromObject(session);

        foreach (JProperty property in json.Properties().Where(p => p.Name.Equals("timer", StringComparison.OrdinalIgnoreCase)))
        {
            if (property.Value is not JObject timer)
                continue;

            foreach (JProperty child in timer.Properties().Where(c => !c.Name.Equals("phase", StringComparison.OrdinalIgnoreCase)).ToList())
                child.Remove();
        }

        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(json.ToString(Formatting.None))));
    }
}
