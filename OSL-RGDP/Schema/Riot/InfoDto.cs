using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents the info DTO.
    /// </summary>
    public struct InfoDto
    {
        /// <summary>
        /// Refer to indicate if the game ended in termination.
        /// </summary>
        [JsonProperty("endOfGameResult")]
        public string EndOfGameResult { get; set; }
        /// <summary>
        /// Unix timestamp for when the game is created on the game server(i.e., the loading screen).
        /// </summary>
        [JsonProperty("gameCreation")]
        public long GameCreation { get; set; }
        /// <summary>
        /// Prior to patch 11.20, this field returns the game length in milliseconds calculated from gameEndTimestamp - gameStartTimestamp.Post patch 11.20, this field returns the max timePlayed of any participant in the game in seconds, which makes the behavior of this field consistent with that of match-v4.The best way to handling the change in this field is to treat the value as milliseconds if the gameEndTimestamp field isn't in the response and to treat the value as seconds if gameEndTimestamp is in the response.
        /// </summary>
        [JsonProperty("gameDuration")]
        public long GameDuration { get; set; }
        /// <summary>
        /// Unix timestamp for when match ends on the game server.This timestamp can occasionally be significantly longer than when the match "ends". The most reliable way of determining the timestamp for the end of the match would be to add the max time played of any participant to the gameStartTimestamp.This field was added to match-v5 in patch 11.20 on Oct 5th, 2021.
        /// </summary>
        [JsonProperty("gameEndTimestamp")]
        public long GameEndTimestamp { get; set; }
        /// <summary>
        /// The ID of the game.
        /// </summary>
        [JsonProperty("gameId")]
        public long GameId { get; set; }
        /// <summary>
        /// Refer to the Game Constants documentation.
        /// </summary>
        [JsonProperty("gameMode")]
        public string GameMode { get; set; }
        /// <summary>
        /// The name of the game.
        /// </summary>
        [JsonProperty("gameName")]
        public string GameName { get; set; }
        /// <summary>
        /// Unix timestamp for when match starts on the game server.
        /// </summary>
        [JsonProperty("gameStartTimestamp")]
        public long GameStartTimestamp { get; set; }
        /// <summary>
        /// Refer to the Game Constants documentation.
        /// </summary>
        [JsonProperty("gameType")]
        public string GameType { get; set; }
        /// <summary>
        /// The first two parts can be used to determine the patch a game was played on.
        /// </summary>
        [JsonProperty("gameVersion")]
        public string GameVersion { get; set; }
        /// <summary>
        /// Refer to the Game Constants documentation.
        /// </summary>
        [JsonProperty("mapId")]
        public int MapId { get; set; }
        /// <summary>
        /// The list of participants in the game.
        /// </summary>
        [JsonProperty("participants")]
        public List<ParticipantDto> Participants { get; set; }
        /// <summary>
        /// Platform where the match was played.
        /// </summary>
        [JsonProperty("platformId")]
        public string PlatformId { get; set; }
        /// <summary>
        /// Refer to the Game Constants documentation.
        /// </summary>
        [JsonProperty("queueId")]
        public int QueueId { get; set; }
        /// <summary>
        /// The list of teams in the game.
        /// </summary>
        [JsonProperty("teams")]
        public List<TeamDto> Teams { get; set; }
        /// <summary>
        /// Tournament code used to generate the match. This field was added to match-v5 in patch 11.13 on June 23rd, 2021.
        /// </summary>
        [JsonProperty("tournamentCode")]
        public string TournamentCode { get; set; }
    }
}
