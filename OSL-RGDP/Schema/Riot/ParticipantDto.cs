using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a participant data transfer object.
    /// </summary>
    /// <remarks>Class generated from the Riot Games API documentation.</remarks>
    public class ParticipantDto
    {
        /// <summary>
        /// Yellow crossed swords
        /// </summary>
        [JsonProperty("allInPings")]
        public int AllInPings { get; set; }
        /// <summary>
        /// Green flag
        /// </summary>
        [JsonProperty("assistMePings")]
        public int AssistMePings { get; set; }
        /// <summary>
        /// Assists
        /// </summary>
        [JsonProperty("assists")]
        public int Assists { get; set; }
        /// <summary>
        /// Baron kills
        /// </summary>
        [JsonProperty("baronKills")]
        public int BaronKills { get; set; }
        /// <summary>
        /// Bounty level
        /// </summary>
        [JsonProperty("bountyLevel")]
        public int BountyLevel { get; set; }
        /// <summary>
        /// Champ experience
        /// </summary>
        [JsonProperty("champExperience")]
        public int ChampExperience { get; set; }
        /// <summary>
        /// Champ level
        /// </summary>
        [JsonProperty("champLevel")]
        public int ChampLevel { get; set; }
        /// <summary>
        /// Champion ID
        /// </summary>
        [JsonProperty("championId")]
        public int ChampionId { get; set; }
        /// <summary>
        /// Champion name
        /// </summary>
        [JsonProperty("championName")]
        public string ChampionName { get; set; }
        /// <summary>
        /// Blue generic ping (ALT+click)
        /// </summary>
        [JsonProperty("commandPings")]
        public int CommandPings { get; set; }
        /// <summary>
        /// This field is currently only utilized for Kayn's transformations. (Legal values: 0 - None, 1 - Slayer, 2 - Assassin)
        /// </summary>
        [JsonProperty("championTransform")]
        public int ChampionTransform { get; set; }
        /// <summary>
        /// Consumables purchased
        /// </summary>
        [JsonProperty("consumablesPurchased")]
        public int ConsumablesPurchased { get; set; }
        /// <summary>
        /// Challenges
        /// </summary>
        [JsonProperty("challenges")]
        public ChallengesDto Challenges { get; set; }
        /// <summary>
        /// Damage dealt to buildings
        /// </summary>
        [JsonProperty("damageDealtToBuildings")]
        public int DamageDealtToBuildings { get; set; }
        /// <summary>
        /// Damage dealt to objectives
        /// </summary>
        [JsonProperty("damageDealtToObjectives")]
        public int DamageDealtToObjectives { get; set; }
        /// <summary>
        /// Damage dealt to turrets
        /// </summary>
        [JsonProperty("damageDealtToTurrets")]
        public int DamageDealtToTurrets { get; set; }
        /// <summary>
        /// Damage self mitigated
        /// </summary>
        [JsonProperty("damageSelfMitigated")]
        public int DamageSelfMitigated { get; set; }
        /// <summary>
        /// Deaths
        /// </summary>
        [JsonProperty("deaths")]
        public int Deaths { get; set; }
        [JsonProperty("detectorWardsPlaced")]
        public int DetectorWardsPlaced { get; set; }
        /// <summary>
        /// Double kills    
        /// </summary>
        [JsonProperty("doubleKills")]
        public int DoubleKills { get; set; }
        /// <summary>
        /// Dragon kills
        /// </summary>
        [JsonProperty("dragonKills")]
        public int DragonKills { get; set; }
        /// <summary>
        /// Eligible for progression
        /// </summary>
        [JsonProperty("eligibleForProgression")]
        public bool EligibleForProgression { get; set; }
        /// <summary>
        /// Yellow questionmark
        /// </summary>
        [JsonProperty("enemyMissingPings")]
        public int EnemyMissingPings { get; set; }
        /// <summary>
        /// Red eyeball
        /// </summary>
        [JsonProperty("enemyVisionPings")]
        public int EnemyVisionPings { get; set; }
        /// <summary>
        /// First blood assist
        /// </summary>
        [JsonProperty("firstBloodAssist")]
        public bool FirstBloodAssist { get; set; }
        /// <summary>
        /// First blood
        /// </summary>
        [JsonProperty("firstBloodKill")]
        public bool FirstBloodKill { get; set; }
        /// <summary>
        /// First tower assist
        /// </summary>
        [JsonProperty("firstTowerAssist")]
        public bool FirstTowerAssist { get; set; }
        /// <summary>
        /// First tower kill
        /// </summary>
        [JsonProperty("firstTowerKill")]
        public bool FirstTowerKill { get; set; }
        /// <summary>
        /// This is an offshoot of the OneStone challenge. The code checks if a spell with the same instance ID does the final point of damage to at least 2 Champions. It doesn't matter if they're enemies, but you cannot hurt your friends.
        /// </summary>
        [JsonProperty("gameEndedInEarlySurrender")]
        public bool GameEndedInEarlySurrender { get; set; }
        /// <summary>
        /// Game ended in surrender
        /// </summary>
        [JsonProperty("gameEndedInSurrender")]
        public bool GameEndedInSurrender { get; set; }
        /// <summary>
        /// Hold pings
        /// </summary>
        [JsonProperty("holdPings")]
        public int HoldPings { get; set; }
        /// <summary>
        /// Yellow circle with horizontal line
        /// </summary>
        [JsonProperty("getBackPings")]
        public int GetBackPings { get; set; }
        /// <summary>
        /// Gold earned
        /// </summary>
        [JsonProperty("goldEarned")]
        public int GoldEarned { get; set; }
        /// <summary>
        /// Gold spent
        /// </summary>
        [JsonProperty("goldSpent")]
        public int GoldSpent { get; set; }
        /// <summary>
        /// Both individualPosition and teamPosition are computed by the game server and are different versions of the most likely position played by a player. The individualPosition is the best guess for which position the player actually played in isolation of anything else. The teamPosition is the best guess for which position the player actually played if we add the constraint that each team must have one top player, one jungle, one middle, etc. Generally the recommendation is to use the teamPosition field over the individualPosition field.
        /// </summary>
        [JsonProperty("individualPosition")]
        public string IndividualPosition { get; set; }
        /// <summary>
        /// Inhibitor kills
        /// </summary>
        [JsonProperty("inhibitorKills")]
        public int InhibitorKills { get; set; }
        /// <summary>
        /// Inhibitor takedowns
        /// </summary>
        [JsonProperty("inhibitorTakedowns")]
        public int InhibitorTakedowns { get; set; }
        /// <summary>
        /// Inhibitors lost
        /// </summary>
        [JsonProperty("inhibitorsLost")]
        public int InhibitorsLost { get; set; }
        /// <summary>
        /// Item 0
        /// </summary>
        [JsonProperty("item0")]
        public int Item0 { get; set; }
        /// <summary>
        /// Item 1
        /// </summary>
        [JsonProperty("item1")]
        public int Item1 { get; set; }
        /// <summary>
        /// Item 2
        /// </summary>
        [JsonProperty("item2")]
        public int Item2 { get; set; }
        /// <summary>
        /// Item 3
        /// </summary>
        [JsonProperty("item3")]
        public int Item3 { get; set; }
        /// <summary>
        /// Item 4
        /// </summary>
        [JsonProperty("item4")]
        public int Item4 { get; set; }
        /// <summary>
        /// Item 5
        /// </summary>
        [JsonProperty("item5")]
        public int Item5 { get; set; }
        /// <summary>
        /// Item 6
        /// </summary>
        [JsonProperty("item6")]
        public int Item6 { get; set; }
        /// <summary>
        /// Items purchased
        /// </summary>
        [JsonProperty("itemsPurchased")]
        public int ItemsPurchased { get; set; }
        /// <summary>
        /// Killing sp
        /// </summary>
        [JsonProperty("killingSprees")]
        public int KillingSprees { get; set; }
        /// <summary>
        /// Kills
        /// </summary>
        [JsonProperty("kills")]
        public int Kills { get; set; }
        /// <summary>
        /// Lane
        /// </summary>
        [JsonProperty("lane")]
        public string Lane { get; set; }
        /// <summary>
        /// Largest critical strike
        /// </summary>
        [JsonProperty("largestCriticalStrike")]
        public int LargestCriticalStrike { get; set; }
        /// <summary>
        /// Largest killing
        /// </summary>
        [JsonProperty("largestKillingSpree")]
        public int LargestKillingSpree { get; set; }
        /// <summary>
        /// Largest multi kill
        /// </summary>
        [JsonProperty("largestMultiKill")]
        public int LargestMultiKill { get; set; }
        /// <summary>
        /// Longest time spent living
        /// </summary>
        [JsonProperty("longestTimeSpentLiving")]
        public int LongestTimeSpentLiving { get; set; }
        /// <summary>
        /// Magic damage dealt
        /// </summary>

        [JsonProperty("magicDamageDealt")]
        public int MagicDamageDealt { get; set; }
        /// <summary>
        /// Magic damage dealt to champions
        /// </summary>
        [JsonProperty("magicDamageDealtToChampions")]
        public int MagicDamageDealtToChampions { get; set; }
        /// <summary>
        /// Magic damage taken
        /// </summary>
        [JsonProperty("magicDamageTaken")]
        public int MagicDamageTaken { get; set; }
        /// <summary>
        /// Missions
        /// </summary>
        [JsonProperty("missions")]
        public MissionsDto Missions { get; set; }
        /// <summary>
        /// Neutral minions killed
        /// </summary>
        [JsonProperty("neutralMinionsKilled")]
        public int NeutralMinionsKilled { get; set; }
        /// <summary>
        /// Green ward
        /// </summary>
        [JsonProperty("needVisionPings")]
        public int NeedVisionPings { get; set; }
        /// <summary>
        /// Nexus kills
        /// </summary>
        [JsonProperty("nexusKills")]
        public int NexusKills { get; set; }
        /// <summary>
        /// Nexus takedowns
        /// </summary>
        [JsonProperty("nexusTakedowns")]
        public int NexusTakedowns { get; set; }
        /// <summary>
        /// Nexus lost
        /// </summary>
        [JsonProperty("nexusLost")]
        public int NexusLost { get; set; }
        /// <summary>
        /// Objectives stolen
        /// </summary>
        [JsonProperty("objectivesStolen")]
        public int ObjectivesStolen { get; set; }
        /// <summary>
        /// Objectives stolen assists
        /// </summary>
        [JsonProperty("objectivesStolenAssists")]
        public int ObjectivesStolenAssists { get; set; }
        /// <summary>
        /// Blue arrow pointing at ground
        /// </summary>
        [JsonProperty("onMyWayPings")]
        public int OnMyWayPings { get; set; }
        /// <summary>
        /// Participant ID
        /// </summary>
        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }
        /// <summary>
        /// Player score 0
        /// </summary>
        [JsonProperty("playerScore0")]
        public int PlayerScore0 { get; set; }
        /// <summary>
        /// Player score 1
        /// </summary>
        [JsonProperty("playerScore1")]
        public int PlayerScore1 { get; set; }
        /// <summary>
        /// Player score 2
        /// </summary>
        [JsonProperty("playerScore2")]
        public int PlayerScore2 { get; set; }
        /// <summary>
        /// Player score 3
        /// </summary>
        [JsonProperty("playerScore3")]
        public int PlayerScore3 { get; set; }
        /// <summary>
        /// Player score 4
        /// </summary>
        [JsonProperty("playerScore4")]
        public int PlayerScore4 { get; set; }
        /// <summary>
        /// Player score 5
        /// </summary>
        [JsonProperty("playerScore5")]
        public int PlayerScore5 { get; set; }
        /// <summary>
        /// Player score 6
        /// </summary>
        [JsonProperty("playerScore6")]
        public int PlayerScore6 { get; set; }
        /// <summary>
        /// Player score 7
        /// </summary>
        [JsonProperty("playerScore7")]
        public int PlayerScore7 { get; set; }
        /// <summary>
        /// Player score 8
        /// </summary>
        [JsonProperty("playerScore8")]
        public int PlayerScore8 { get; set; }
        /// <summary>
        /// Player score 9
        /// </summary>
        [JsonProperty("playerScore9")]
        public int PlayerScore9 { get; set; }
        /// <summary>
        /// Player score 10
        /// </summary>
        [JsonProperty("playerScore10")]
        public int PlayerScore10 { get; set; }
        /// <summary>
        /// Player score 11
        /// </summary>
        [JsonProperty("playerScore11")]
        public int PlayerScore11 { get; set; }
        /// <summary>
        /// Penta kills
        /// </summary>
        [JsonProperty("pentaKills")]
        public int PentaKills { get; set; }
        /// <summary>
        /// Perks
        /// </summary>
        [JsonProperty("perks")]
        public PerksDto Perks { get; set; }
        /// <summary>
        /// Physical damage dealt
        /// </summary>
        [JsonProperty("physicalDamageDealt")]
        public int PhysicalDamageDealt { get; set; }
        /// <summary>
        /// Physical damage dealt to champions
        /// </summary>
        [JsonProperty("physicalDamageDealtToChampions")]
        public int PhysicalDamageDealtToChampions { get; set; }
        /// <summary>
        /// Physical damage taken
        /// </summary>
        [JsonProperty("physicalDamageTaken")]
        public int PhysicalDamageTaken { get; set; }
        /// <summary>
        /// Placement
        /// </summary>
        [JsonProperty("placement")]
        public int Placement { get; set; }
        /// <summary>
        /// Player augment 1
        /// </summary>
        [JsonProperty("playerAugment1")]
        public int PlayerAugment1 { get; set; }
        /// <summary>
        /// Player augment 2
        /// </summary>
        [JsonProperty("playerAugment2")]
        public int PlayerAugment2 { get; set; }
        /// <summary>
        /// Player augment 3
        /// </summary>
        [JsonProperty("playerAugment3")]
        public int PlayerAugment3 { get; set; }
        /// <summary>
        /// Player augment 4
        /// </summary>
        [JsonProperty("playerAugment4")]
        public int PlayerAugment4 { get; set; }
        /// <summary>
        /// Player subteam ID
        /// </summary>
        [JsonProperty("playerSubteamId")]
        public int PlayerSubteamId { get; set; }
        /// <summary>
        /// Green minion
        /// </summary>
        [JsonProperty("pushPings")]
        public int PushPings { get; set; }
        /// <summary>
        /// Profile icon
        /// </summary>
        [JsonProperty("profileIcon")]
        public int ProfileIcon { get; set; }
        /// <summary>
        /// Puuid
        /// </summary>
        [JsonProperty("puuid")]
        public string Puuid { get; set; }
        /// <summary>
        /// Quadra kills
        /// </summary>
        [JsonProperty("quadraKills")]
        public int QuadraKills { get; set; }
        /// <summary>
        /// Riot ID game name
        /// </summary>
        [JsonProperty("riotIdGameName")]
        public string RiotIdGameName { get; set; }
        /// <summary>
        /// Riot ID tagline
        /// </summary>
        [JsonProperty("riotIdTagline")]
        public string RiotIdTagline { get; set; }
        /// <summary>
        /// Role
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }
        /// <summary>
        /// Sight wards bought in game
        /// </summary>
        [JsonProperty("sightWardsBoughtInGame")]
        public int SightWardsBoughtInGame { get; set; }
        /// <summary>
        /// Spell 1 casts
        /// </summary>
        [JsonProperty("spell1Casts")]
        public int Spell1Casts { get; set; }
        /// <summary>
        /// Spell 2 casts
        /// </summary>
        [JsonProperty("spell2Casts")]
        public int Spell2Casts { get; set; }
        /// <summary>
        /// Spell 3 casts
        /// </summary>
        [JsonProperty("spell3Casts")]
        public int Spell3Casts { get; set; }
        /// <summary>
        /// Spell 4 casts
        /// </summary>
        [JsonProperty("spell4Casts")]
        public int Spell4Casts { get; set; }
        /// <summary>
        /// Subteam placement
        /// </summary>
        [JsonProperty("subteamPlacement")]
        public int SubteamPlacement { get; set; }
        /// <summary>
        /// Summoner 1 casts
        /// </summary>
        [JsonProperty("summoner1Casts")]
        public int Summoner1Casts { get; set; }
        /// <summary>
        /// Summoner 1 ID
        /// </summary>
        [JsonProperty("summoner1Id")]
        public int Summoner1Id { get; set; }
        /// <summary>
        /// Summoner 2 casts
        /// </summary>
        [JsonProperty("summoner2Casts")]
        public int Summoner2Casts { get; set; }
        /// <summary>
        /// Summoner 2 ID
        /// </summary>
        [JsonProperty("summoner2Id")]
        public int Summoner2Id { get; set; }
        /// <summary>
        /// Summoner ID
        /// </summary>
        [JsonProperty("summonerId")]
        public string SummonerId { get; set; }
        /// <summary>
        /// Summoner level
        /// </summary>
        [JsonProperty("summonerLevel")]
        public int SummonerLevel { get; set; }
        /// <summary>
        /// Summoner name
        /// </summary>
        [JsonProperty("summonerName")]
        public string SummonerName { get; set; }
        /// <summary>
        /// Team early surrendered
        /// </summary>
        [JsonProperty("teamEarlySurrendered")]
        public bool TeamEarlySurrendered { get; set; }
        /// <summary>
        /// Team ID
        /// </summary>
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
        /// <summary>
        /// Both individualPosition and teamPosition are computed by the game server and are different versions of the most likely position played by a player. The individualPosition is the best guess for which position the player actually played in isolation of anything else. The teamPosition is the best guess for which position the player actually played if we add the constraint that each team must have one top player, one jungle, one middle, etc. Generally the recommendation is to use the teamPosition field over the individualPosition field.
        /// </summary>
        [JsonProperty("teamPosition")]
        public string TeamPosition { get; set; }
        /// <summary>
        /// Time CCing others
        /// </summary>
        [JsonProperty("timeCCingOthers")]
        public int TimeCCingOthers { get; set; }
        /// <summary>
        /// Time played
        /// </summary>
        [JsonProperty("timePlayed")]
        public int TimePlayed { get; set; }
        /// <summary>
        /// Total ally jungle minions killed
        /// </summary>
        [JsonProperty("totalAllyJungleMinionsKilled")]
        public int TotalAllyJungleMinionsKilled { get; set; }
        /// <summary>
        /// Total damage dealt
        /// </summary>
        [JsonProperty("totalDamageDealt")]
        public int TotalDamageDealt { get; set; }
        /// <summary>
        /// Total damage dealt to champions
        /// </summary>
        [JsonProperty("totalDamageDealtToChampions")]
        public int TotalDamageDealtToChampions { get; set; }
        /// <summary>
        /// Total damage shielded on teammates
        /// </summary>
        [JsonProperty("totalDamageShieldedOnTeammates")]
        public int TotalDamageShieldedOnTeammates { get; set; }
        /// <summary>
        /// Total damage taken
        /// </summary>
        [JsonProperty("totalDamageTaken")]
        public int TotalDamageTaken { get; set; }
        /// <summary>
        /// Total enemy jungle minions killed
        /// </summary>
        [JsonProperty("totalEnemyJungleMinionsKilled")]
        public int TotalEnemyJungleMinionsKilled { get; set; }
        /// <summary>
        /// Total heal
        /// </summary>
        [JsonProperty("totalHeal")]
        public int TotalHeal { get; set; }
        /// <summary>
        /// Total heals on teammates
        /// </summary>
        [JsonProperty("totalHealsOnTeammates")]
        public int TotalHealsOnTeammates { get; set; }
        /// <summary>
        /// Total minions killed
        /// </summary>
        [JsonProperty("totalMinionsKilled")]
        public int TotalMinionsKilled { get; set; }
        /// <summary>
        /// Total time CC dealt
        /// </summary>
        [JsonProperty("totalTimeCCDealt")]
        public int TotalTimeCCDealt { get; set; }
        /// <summary>
        /// Total time spent dead
        /// </summary>
        [JsonProperty("totalTimeSpentDead")]
        public int TotalTimeSpentDead { get; set; }
        /// <summary>
        /// Total units healed
        /// </summary>
        [JsonProperty("totalUnitsHealed")]
        public int TotalUnitsHealed { get; set; }
        /// <summary>
        /// Triple kills
        /// </summary>
        [JsonProperty("tripleKills")]
        public int TripleKills { get; set; }
        /// <summary>
        /// True damage dealt
        /// </summary>
        [JsonProperty("trueDamageDealt")]
        public int TrueDamageDealt { get; set; }
        /// <summary>
        /// True damage dealt to champions
        /// </summary>
        [JsonProperty("trueDamageDealtToChampions")]
        public int TrueDamageDealtToChampions { get; set; }
        /// <summary>
        /// True damage taken
        /// </summary>
        [JsonProperty("trueDamageTaken")]
        public int TrueDamageTaken { get; set; }
        /// <summary>
        /// Turret kills
        /// </summary>
        [JsonProperty("turretKills")]
        public int TurretKills { get; set; }
        /// <summary>
        /// Turret takedowns
        /// </summary>
        [JsonProperty("turretTakedowns")]
        public int TurretTakedowns { get; set; }
        /// <summary>
        /// Turrets lost
        /// </summary>
        [JsonProperty("turretsLost")]
        public int TurretsLost { get; set; }
        /// <summary>
        /// Unreal kills
        /// </summary>
        [JsonProperty("unrealKills")]
        public int UnrealKills { get; set; }
        /// <summary>
        /// Vision score
        /// </summary>
        [JsonProperty("visionScore")]
        public int VisionScore { get; set; }
        /// <summary>
        /// Vision cleared pings
        /// </summary>
        [JsonProperty("visionClearedPings")]
        public int VisionClearedPings { get; set; }
        /// <summary>
        /// Vision wards bought in game
        /// </summary>
        [JsonProperty("visionWardsBoughtInGame")]
        public int VisionWardsBoughtInGame { get; set; }
        /// <summary>
        /// Ward killed
        /// </summary>
        [JsonProperty("wardsKilled")]
        public int WardsKilled { get; set; }
        /// <summary>
        /// Wards placed
        /// </summary>
        [JsonProperty("wardsPlaced")]
        public int WardsPlaced { get; set; }
        /// <summary>
        /// Win
        /// </summary>
        [JsonProperty("win")]
        public bool Win { get; set; }
    }
}
