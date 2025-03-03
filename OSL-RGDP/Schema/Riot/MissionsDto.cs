using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a missions data transfer object.
    /// </summary>
    public struct MissionsDto
    {
        /// <summary>
        /// Player 0 score
        /// </summary>
        [JsonProperty("playerScore0")]
        public int PlayerScore0 { get; set; }
        /// <summary>
        /// Player 1 score
        /// </summary>
        [JsonProperty("playerScore1")]
        public int PlayerScore1 { get; set; }
        /// <summary>
        /// Player 2 score
        /// </summary>
        [JsonProperty("playerScore2")]
        public int PlayerScore2 { get; set; }
        /// <summary>
        /// Player 3 score
        /// </summary>
        [JsonProperty("playerScore3")]
        public int PlayerScore3 { get; set; }
        /// <summary>
        /// Player 4 score
        /// </summary>
        [JsonProperty("playerScore4")]
        public int PlayerScore4 { get; set; }
        /// <summary>
        /// Player 5 score
        /// </summary>
        [JsonProperty("playerScore5")]
        public int PlayerScore5 { get; set; }
        /// <summary>
        /// Player 6 score
        /// </summary>
        [JsonProperty("playerScore6")]
        public int PlayerScore6 { get; set; }
        /// <summary>
        /// Player 7 score
        /// </summary>
        [JsonProperty("playerScore7")]
        public int PlayerScore7 { get; set; }
        /// <summary>
        /// Player 8 score
        /// </summary>
        [JsonProperty("playerScore8")]
        public int PlayerScore8 { get; set; }
        /// <summary>
        /// Player 9 score
        /// </summary>
        [JsonProperty("playerScore9")]
        public int PlayerScore9 { get; set; }
        /// <summary>
        /// Player 10 score
        /// </summary>
        [JsonProperty("playerScore10")]
        public int PlayerScore10 { get; set; }
        /// <summary>
        /// Player 11 score
        /// </summary>
        [JsonProperty("playerScore11")]
        public int PlayerScore11 { get; set; }
    }
}
