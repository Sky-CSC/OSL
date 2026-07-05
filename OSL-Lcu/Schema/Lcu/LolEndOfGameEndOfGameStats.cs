using Newtonsoft.Json;

namespace OSL_Lcu.Schema.Lcu
{
    /// <summary>
    /// Class generated from the swagger.json file
    /// </summary>
    public class LolEndOfGameEndOfGameStats
    {
        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }

        [JsonProperty("gameId")]
        public Int64 GameId { get; set; }

        [JsonProperty("gameLength")]
        public int GameLength { get; set; }

        [JsonProperty("endOfGameTimestamp")]
        public long EndOfGameTimestamp { get; set; }

        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("gameMutators")]
        public List<string> GameMutators { get; set; }

        [JsonProperty("gameType")]
        public string GameType { get; set; }

        [JsonProperty("invalid")]
        public bool Invalid { get; set; }

        [JsonProperty("queueType")]
        public string QueueType { get; set; }

        [JsonProperty("ranked")]
        public bool Ranked { get; set; }

        [JsonProperty("reportGameId")]
        public int ReportGameId { get; set; }

        [JsonProperty("multiUserChatId")]
        public string MultiUserChatId { get; set; }

        [JsonProperty("multiUserChatPassword")]
        public string MultiUserChatPassword { get; set; }

        [JsonProperty("mucJwtDto")]
        public LolEndOfGameMucJwtDto MucJwtDto { get; set; }

        [JsonProperty("teams")]
        public List<LolEndOfGameEndOfGameTeam> Teams { get; set; }

        [JsonProperty("localPlayer")]
        public LolEndOfGameEndOfGamePlayer LocalPlayer { get; set; }

        [JsonProperty("myTeamStatus")]
        public string MyTeamStatus { get; set; }

        [JsonProperty("leveledUp")]
        public bool LeveledUp { get; set; }

        [JsonProperty("newSpells")]
        public List<int> NewSpells { get; set; }

        [JsonProperty("previousLevel")]
        public int PreviousLevel { get; set; }

        [JsonProperty("rpEarned")]
        public int RpEarned { get; set; }

        [JsonProperty("basePoints")]
        public int BasePoints { get; set; }

        [JsonProperty("battleBoostIpEarned")]
        public int BattleBoostIpEarned { get; set; }

        [JsonProperty("boostIpEarned")]
        public int BoostIpEarned { get; set; }

        [JsonProperty("firstWinBonus")]
        public int FirstWinBonus { get; set; }

        [JsonProperty("ipEarned")]
        public int IpEarned { get; set; }

        [JsonProperty("ipTotal")]
        public int IpTotal { get; set; }

        [JsonProperty("boostXpEarned")]
        public int BoostXpEarned { get; set; }

        [JsonProperty("experienceEarned")]
        public int ExperienceEarned { get; set; }

        [JsonProperty("experienceTotal")]
        public int ExperienceTotal { get; set; }

        [JsonProperty("globalBoostXpEarned")]
        public int GlobalBoostXpEarned { get; set; }

        [JsonProperty("loyaltyBoostXpEarned")]
        public int LoyaltyBoostXpEarned { get; set; }

        [JsonProperty("xbgpBoostXpEarned")]
        public int XbgpBoostXpEarned { get; set; }

        [JsonProperty("missionsXpEarned")]
        public int MissionsXpEarned { get; set; }

        [JsonProperty("previousXpTotal")]
        public int PreviousXpTotal { get; set; }

        [JsonProperty("nextLevelXp")]
        public int NextLevelXp { get; set; }

        [JsonProperty("currentLevel")]
        public int CurrentLevel { get; set; }

        [JsonProperty("preLevelUpExperienceTotal")]
        public int PreLevelUpExperienceTotal { get; set; }

        [JsonProperty("preLevelUpNextLevelXp")]
        public int PreLevelUpNextLevelXp { get; set; }

        [JsonProperty("timeUntilNextFirstWinBonus")]
        public int TimeUntilNextFirstWinBonus { get; set; }

        [JsonProperty("causedEarlySurrender")]
        public bool CausedEarlySurrender { get; set; }

        [JsonProperty("earlySurrenderAccomplice")]
        public bool EarlySurrenderAccomplice { get; set; }

        [JsonProperty("teamEarlySurrendered")]
        public bool TeamEarlySurrendered { get; set; }

        [JsonProperty("gameEndedInEarlySurrender")]
        public bool GameEndedInEarlySurrender { get; set; }

        [JsonProperty("rerollData")]
        public LolEndOfGameEndOfGamePoints RerollData { get; set; }

        [JsonProperty("teamBoost")]
        public LolEndOfGameEndOfGameTeamBoost TeamBoost { get; set; }
    }
}
