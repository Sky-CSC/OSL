using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Information about an account.
    /// </summary>
    public struct AccountDto
    {
        /// <summary>
        /// The unique identifier of the account.
        /// </summary>
        [JsonProperty("puuid")]
        public string Puuid { get; set; }
        /// <summary>
        /// The game name of the account.
        /// </summary>
        [JsonProperty("gameName")]
        public string GameName { get; set; } // This field may be excluded from the response if the account doesn't have a gameName.
        /// <summary>
        /// The tag of the account.
        /// </summary>
        [JsonProperty("tagLine")]
        public string TagLine { get; set; } // This field may be excluded from the response if the account doesn't have a tagLine.
    }
}
