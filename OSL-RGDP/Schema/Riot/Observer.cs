using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents an observer of a game.
    /// </summary>
    /// <remarks>Class generated from the Riot Games API documentation.</remarks>
    public class Observer
    {
        /// <summary>
        /// Key used to decrypt the spectator grid game data for playback
        /// </summary>
        [JsonProperty("encryptionKey")]
        public string EncryptionKey { get; set; }
    }
}
