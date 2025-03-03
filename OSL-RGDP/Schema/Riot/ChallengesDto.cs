using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Challenges DTO.
    /// </summary>
    public struct ChallengesDto
    {
        /// <summary>
        /// 12 Assist Streak Count
        /// </summary>
        [JsonProperty("12AssistStreakCount")]
        public int AssistStreakCount { get; set; }
        /// <summary>
        /// Baron Buff Gold Advantage Over Threshold
        /// </summary>
        [JsonProperty("baronBuffGoldAdvantageOverThreshold")]
        public int BaronBuffGoldAdvantageOverThreshold { get; set; }
        /// <summary>
        /// Control Ward Time Coverage In River Or Enemy Half
        /// </summary>
        [JsonProperty("controlWardTimeCoverageInRiverOrEnemyHalf")]
        public double ControlWardTimeCoverageInRiverOrEnemyHalf { get; set; }
        /// <summary>
        /// Earliest Baron
        /// </summary>
        [JsonProperty("earliestBaron")]
        public double EarliestBaron { get; set; }
        /// <summary>
        /// Earliest Dragon Takedown
        /// </summary>
        [JsonProperty("earliestDragonTakedown")]
        public double EarliestDragonTakedown { get; set; }
        /// <summary>
        /// Earliest Elder Dragon
        /// </summary>
        [JsonProperty("earliestElderDragon")]
        public double EarliestElderDragon { get; set; }
        /// <summary>
        /// Early Laning Phase Gold Exp Advantage
        /// </summary>
        [JsonProperty("earlyLaningPhaseGoldExpAdvantage")]
        public int EarlyLaningPhaseGoldExpAdvantage { get; set; }
        /// <summary>
        /// Faster Support Quest Completion
        /// </summary>
        [JsonProperty("fasterSupportQuestCompletion")]
        public int FasterSupportQuestCompletion { get; set; }
        /// <summary>
        /// Fastest Legendary
        /// </summary>
        [JsonProperty("fastestLegendary")]
        public double FastestLegendary { get; set; }
        /// <summary>
        /// Had Afk Teammate
        /// </summary>
        [JsonProperty("hadAfkTeammate")]
        public int HadAfkTeammate { get; set; }
        /// <summary>
        /// Highest Champion Damage
        /// </summary>
        [JsonProperty("highestChampionDamage")]
        public int HighestChampionDamage { get; set; }
        /// <summary>
        /// Highest Crowd Control Score
        /// </summary>
        [JsonProperty("highestCrowdControlScore")]
        public int HighestCrowdControlScore { get; set; }
        /// <summary>
        /// Highest Ward Kills
        /// </summary>
        [JsonProperty("highestWardKills")]
        public int HighestWardKills { get; set; }
        /// <summary>
        /// Jungler Kills Early Jungle
        /// </summary>
        [JsonProperty("junglerKillsEarlyJungle")]
        public int JunglerKillsEarlyJungle { get; set; }
        /// <summary>
        /// Kills On Laners Early Jungle As Jungler
        /// </summary>
        [JsonProperty("killsOnLanersEarlyJungleAsJungler")]
        public int KillsOnLanersEarlyJungleAsJungler { get; set; }
        /// <summary>
        /// Laning Phase Gold Exp Advantage
        /// </summary>
        [JsonProperty("laningPhaseGoldExpAdvantage")]
        public int LaningPhaseGoldExpAdvantage { get; set; }
        /// <summary>
        /// Legendary Count
        /// </summary>
        [JsonProperty("legendaryCount")]
        public int LegendaryCount { get; set; }
        /// <summary>
        /// Max Cs Advantage On Lane Opponent
        /// </summary>
        [JsonProperty("maxCsAdvantageOnLaneOpponent")]
        public double MaxCsAdvantageOnLaneOpponent { get; set; }
        /// <summary>
        /// Max Level Lead Lane Opponent
        /// </summary>
        [JsonProperty("maxLevelLeadLaneOpponent")]
        public int MaxLevelLeadLaneOpponent { get; set; }
        /// <summary>
        /// Most Wards Destroyed One Sweeper
        /// </summary>
        [JsonProperty("mostWardsDestroyedOneSweeper")]
        public int MostWardsDestroyedOneSweeper { get; set; }
        /// <summary>
        /// Mythic Item Used
        /// </summary>
        [JsonProperty("mythicItemUsed")]
        public int MythicItemUsed { get; set; }
        /// <summary>
        /// Played Champ Select Position
        /// </summary>
        [JsonProperty("playedChampSelectPosition")]
        public int PlayedChampSelectPosition { get; set; }
        /// <summary>
        /// Solo Turrets Lategame
        /// </summary>
        [JsonProperty("soloTurretsLategame")]
        public int SoloTurretsLategame { get; set; }
        /// <summary>
        /// Takedowns First 25 Minutes
        /// </summary>
        [JsonProperty("takedownsFirst25Minutes")]
        public int TakedownsFirst25Minutes { get; set; }
        /// <summary>
        /// Teleport Takedowns
        /// </summary>
        [JsonProperty("teleportTakedowns")]
        public int TeleportTakedowns { get; set; }
        /// <summary>
        /// Third Inhibitor Destroyed Time
        /// </summary>
        [JsonProperty("thirdInhibitorDestroyedTime")]
        public int ThirdInhibitorDestroyedTime { get; set; }
        /// <summary>
        /// Three Wards One Sweeper Count
        /// </summary>
        [JsonProperty("threeWardsOneSweeperCount")]
        public int ThreeWardsOneSweeperCount { get; set; }
        /// <summary>
        /// Vision Score Advantage Lane Opponent
        /// </summary>
        [JsonProperty("visionScoreAdvantageLaneOpponent")]
        public double VisionScoreAdvantageLaneOpponent { get; set; }
        /// <summary>
        /// Infernal Scale Pickup
        /// </summary>
        [JsonProperty("InfernalScalePickup")]
        public int InfernalScalePickup { get; set; }
        /// <summary>
        /// Fist Bump Participation
        /// </summary>
        [JsonProperty("fistBumpParticipation")]
        public int FistBumpParticipation { get; set; }
        /// <summary>
        /// Void Monster Kill
        /// </summary>
        [JsonProperty("voidMonsterKill")]
        public int VoidMonsterKill { get; set; }
        /// <summary>
        /// Ability Uses
        /// </summary>
        [JsonProperty("abilityUses")]
        public int AbilityUses { get; set; }
        /// <summary>
        /// Aces Before 15 Minutes
        /// </summary>
        [JsonProperty("acesBefore15Minutes")]
        public int AcesBefore15Minutes { get; set; }
        /// <summary>
        /// Allied Jungle Monster Kills
        /// </summary>
        [JsonProperty("alliedJungleMonsterKills")]
        public double AlliedJungleMonsterKills { get; set; }
        /// <summary>
        /// Baron Takedowns
        /// </summary>
        [JsonProperty("baronTakedowns")]
        public int BaronTakedowns { get; set; }
        /// <summary>
        /// Blast Cone Opposite Opponent Count
        /// </summary>
        [JsonProperty("blastConeOppositeOpponentCount")]
        public int BlastConeOppositeOpponentCount { get; set; }
        /// <summary>
        /// Bounty Gold
        /// </summary>
        [JsonProperty("bountyGold")]
        public double BountyGold { get; set; }
        /// <summary>
        /// Buffs Stolen
        /// </summary>
        [JsonProperty("buffsStolen")]
        public int BuffsStolen { get; set; }
        /// <summary>
        /// Complete Support Quest In Time
        /// </summary>
        [JsonProperty("completeSupportQuestInTime")]
        public int CompleteSupportQuestInTime { get; set; }
        /// <summary>
        /// Control Wards Placed
        /// </summary>
        [JsonProperty("controlWardsPlaced")]
        public int ControlWardsPlaced { get; set; }
        /// <summary>
        /// Damage Per Minute
        /// </summary>
        [JsonProperty("damagePerMinute")]
        public double DamagePerMinute { get; set; }
        /// <summary>
        /// Damage Taken On Team Percentage
        /// </summary>
        [JsonProperty("damageTakenOnTeamPercentage")]
        public double DamageTakenOnTeamPercentage { get; set; }
        /// <summary>
        /// Danced With Rift Herald
        /// </summary>
        [JsonProperty("dancedWithRiftHerald")]
        public int DancedWithRiftHerald { get; set; }
        /// <summary>
        /// Deaths By Enemy
        /// </summary>
        [JsonProperty("deathsByEnemyChamps")]
        public int DeathsByEnemyChamps { get; set; }
        /// <summary>
        /// Dodge Skill Shots Small Window
        /// </summary>
        [JsonProperty("dodgeSkillShotsSmallWindow")]
        public int DodgeSkillShotsSmallWindow { get; set; }
        /// <summary>
        /// Double Aces
        /// </summary>
        [JsonProperty("doubleAces")]
        public int DoubleAces { get; set; }
        /// <summary>
        /// Dragon Takedowns
        /// </summary>
        [JsonProperty("dragonTakedowns")]
        public int DragonTakedowns { get; set; }
        /// <summary>
        /// Legendary Item Used
        /// </summary>
        [JsonProperty("legendaryItemUsed")]
        public List<int> LegendaryItemUsed { get; set; }
        /// <summary>
        /// Effective Heal And Shielding
        /// </summary>
        [JsonProperty("effectiveHealAndShielding")]
        public double EffectiveHealAndShielding { get; set; }
        /// <summary>
        /// Elder Dragon Kills With Opposing Soul
        /// </summary>
        [JsonProperty("elderDragonKillsWithOpposingSoul")]
        public int ElderDragonKillsWithOpposingSoul { get; set; }
        /// <summary>
        /// Elder Dragon Multikills
        /// </summary>
        [JsonProperty("elderDragonMultikills")]
        public int ElderDragonMultikills { get; set; }
        /// <summary>
        /// Enemy Champion Immobilizations
        /// </summary>
        [JsonProperty("enemyChampionImmobilizations")]
        public int EnemyChampionImmobilizations { get; set; }
        /// <summary>
        /// Enemy Jungle Monster Kills
        /// </summary>
        [JsonProperty("enemyJungleMonsterKills")]
        public double EnemyJungleMonsterKills { get; set; }
        /// <summary>
        /// Epic Monster Kills Near Enemy Jungler
        /// </summary>
        [JsonProperty("epicMonsterKillsNearEnemyJungler")]
        public int EpicMonsterKillsNearEnemyJungler { get; set; }
        /// <summary>
        /// Epic Monster Kills Within 30 Seconds Of Spawn
        /// </summary>
        [JsonProperty("epicMonsterKillsWithin30SecondsOfSpawn")]
        public int EpicMonsterKillsWithin30SecondsOfSpawn { get; set; }
        /// <summary>
        /// Epic Monster Steals
        /// </summary>
        [JsonProperty("epicMonsterSteals")]
        public int EpicMonsterSteals { get; set; }
        /// <summary>
        /// Epic Monster Stolen Without Smite
        /// </summary>
        [JsonProperty("epicMonsterStolenWithoutSmite")]
        public int EpicMonsterStolenWithoutSmite { get; set; }
        /// <summary>
        /// First Turret Killed
        /// </summary>
        [JsonProperty("firstTurretKilled")]
        public int FirstTurretKilled { get; set; }
        /// <summary>
        /// First Turret Killed Time
        /// </summary>
        [JsonProperty("firstTurretKilledTime")]
        public double FirstTurretKilledTime { get; set; }
        /// <summary>
        /// Flawless Aces
        /// </summary>
        [JsonProperty("flawlessAces")]
        public int FlawlessAces { get; set; }
        /// <summary>
        /// Full Team Takedown
        /// </summary>
        [JsonProperty("fullTeamTakedown")]
        public int FullTeamTakedown { get; set; }
        /// <summary>
        /// Game Length
        /// </summary>
        [JsonProperty("gameLength")]
        public double GameLength { get; set; }
        /// <summary>
        /// Get Takedowns In All Lanes Early Jungle As Laner
        /// </summary>
        [JsonProperty("getTakedownsInAllLanesEarlyJungleAsLaner")]
        public int GetTakedownsInAllLanesEarlyJungleAsLaner { get; set; }
        /// <summary>
        /// Gold Per Minute
        /// </summary>
        [JsonProperty("goldPerMinute")]
        public double GoldPerMinute { get; set; }
        /// <summary>
        /// Had Open Nexus
        /// </summary>
        [JsonProperty("hadOpenNexus")]
        public int HadOpenNexus { get; set; }
        /// <summary>
        /// Immobilize
        /// </summary>
        [JsonProperty("immobilizeAndKillWithAlly")]
        public int ImmobilizeAndKillWithAlly { get; set; }
        /// <summary>
        /// Initial Buff Count
        /// </summary>
        [JsonProperty("initialBuffCount")]
        public int InitialBuffCount { get; set; }
        /// <summary>
        /// Initial Crab Count
        /// </summary>
        [JsonProperty("initialCrabCount")]
        public int InitialCrabCount { get; set; }
        /// <summary>
        /// Jungle Cs Before 10 Minutes
        /// </summary>
        [JsonProperty("jungleCsBefore10Minutes")]
        public double JungleCsBefore10Minutes { get; set; }
        /// <summary>
        /// Jungler Takedowns Near Damaged Epic Monster
        /// </summary>
        [JsonProperty("junglerTakedownsNearDamagedEpicMonster")]
        public int JunglerTakedownsNearDamagedEpicMonster { get; set; }
        /// <summary>
        /// Kda
        /// </summary>
        [JsonProperty("kda")]
        public double Kda { get; set; }
        /// <summary>
        /// Kill After Hidden With Ally
        /// </summary>
        [JsonProperty("killAfterHiddenWithAlly")]
        public int KillAfterHiddenWithAlly { get; set; }
        /// <summary>
        /// Killed Champ Took Full Team Damage Survived
        /// </summary>
        [JsonProperty("killedChampTookFullTeamDamageSurvived")]
        public int KilledChampTookFullTeamDamageSurvived { get; set; }
        /// <summary>
        /// Killing Sprees
        /// </summary>
        [JsonProperty("killingSprees")]
        public int KillingSprees { get; set; }
        /// <summary>
        /// Kill Participation
        /// </summary>
        [JsonProperty("killParticipation")]
        public double KillParticipation { get; set; }
        /// <summary>
        /// Kills Near Enemy Turret
        /// </summary>
        [JsonProperty("killsNearEnemyTurret")]
        public int KillsNearEnemyTurret { get; set; }
        /// <summary>
        /// Kills On Other Lanes Early Jungle As Laner
        /// </summary>
        [JsonProperty("killsOnOtherLanesEarlyJungleAsLaner")]
        public int KillsOnOtherLanesEarlyJungleAsLaner { get; set; }
        /// <summary>
        /// Kills On Recently Healed By Aram Pack
        /// </summary>
        [JsonProperty("killsOnRecentlyHealedByAramPack")]
        public int KillsOnRecentlyHealedByAramPack { get; set; }
        /// <summary>
        /// Kills Under Own Turret
        /// </summary>
        [JsonProperty("killsUnderOwnTurret")]
        public int KillsUnderOwnTurret { get; set; }
        /// <summary>
        /// Kills With Help From Epic Monster
        /// </summary>
        [JsonProperty("killsWithHelpFromEpicMonster")]
        public int KillsWithHelpFromEpicMonster { get; set; }
        /// <summary>
        /// Knock Enemy
        /// </summary>
        [JsonProperty("knockEnemyIntoTeamAndKill")]
        public int KnockEnemyIntoTeamAndKill { get; set; }
        /// <summary>
        /// KTurrets Destroyed Before Plates Fall
        /// </summary>
        [JsonProperty("kTurretsDestroyedBeforePlatesFall")]
        public int KTurretsDestroyedBeforePlatesFall { get; set; }
        /// <summary>
        /// Land Skill Shots Early Game
        /// </summary>
        [JsonProperty("landSkillShotsEarlyGame")]
        public int LandSkillShotsEarlyGame { get; set; }
        /// <summary>
        /// Lane Minions First 10 Minutes
        /// </summary>
        [JsonProperty("laneMinionsFirst10Minutes")]
        public int LaneMinionsFirst10Minutes { get; set; }
        /// <summary>
        /// Lost An Inhibitor
        /// </summary>
        [JsonProperty("lostAnInhibitor")]
        public int LostAnInhibitor { get; set; }
        /// <summary>
        /// Max Kill Deficit
        /// </summary>
        [JsonProperty("maxKillDeficit")]
        public int MaxKillDeficit { get; set; }
        /// <summary>
        /// Mejais Full Stack In Time
        /// </summary>
        [JsonProperty("mejaisFullStackInTime")]
        public int MejaisFullStackInTime { get; set; }
        /// <summary>
        /// More Enemy Jungle Than Opponent
        /// </summary>
        [JsonProperty("moreEnemyJungleThanOpponent")]
        public double MoreEnemyJungleThanOpponent { get; set; }
        /// <summary>
        /// Multi Kill One Spell
        /// </summary>
        [JsonProperty("multiKillOneSpell")]
        public int MultiKillOneSpell { get; set; }
        /// <summary>
        /// Multikills
        /// </summary>
        [JsonProperty("multikills")]
        public int Multikills { get; set; }
        /// <summary>
        /// Multikills After Aggressive Flash
        /// </summary>
        [JsonProperty("multikillsAfterAggressiveFlash")]
        public int MultikillsAfterAggressiveFlash { get; set; }
        /// <summary>
        /// Multi Turret Rift Herald Count
        /// </summary>
        [JsonProperty("multiTurretRiftHeraldCount")]
        public int MultiTurretRiftHeraldCount { get; set; }
        /// <summary>
        /// Outer Turret
        /// </summary>
        [JsonProperty("outerTurretExecutesBefore10Minutes")]
        public int OuterTurretExecutesBefore10Minutes { get; set; }
        /// <summary>
        /// Outnumbered Kills
        /// </summary>
        [JsonProperty("outnumberedKills")]
        public int OutnumberedKills { get; set; }
        /// <summary>
        /// Outnumbered Nexus Kill
        /// </summary>
        [JsonProperty("outnumberedNexusKill")]
        public int OutnumberedNexusKill { get; set; }
        /// <summary>
        /// Perfect Dragon Souls Taken
        /// </summary>
        [JsonProperty("perfectDragonSoulsTaken")]
        public int PerfectDragonSoulsTaken { get; set; }
        /// <summary>
        /// Perfect Game
        /// </summary>
        [JsonProperty("perfectGame")]
        public int PerfectGame { get; set; }
        /// <summary>
        /// Pick Kill With Ally
        /// </summary>
        [JsonProperty("pickKillWithAlly")]
        public int PickKillWithAlly { get; set; }
        /// <summary>
        /// Poro Explosions
        /// </summary>
        [JsonProperty("poroExplosions")]
        public int PoroExplosions { get; set; }
        /// <summary>
        /// Quick Cleanse
        /// </summary>
        [JsonProperty("quickCleanse")]
        public int QuickCleanse { get; set; }
        /// <summary>
        /// Quick First Turret
        /// </summary>
        [JsonProperty("quickFirstTurret")]
        public int QuickFirstTurret { get; set; }
        /// <summary>
        /// Quick Solo Kills
        /// </summary>
        [JsonProperty("quickSoloKills")]
        public int QuickSoloKills { get; set; }
        /// <summary>
        /// Rift Herald Takedowns
        /// </summary>
        [JsonProperty("riftHeraldTakedowns")]
        public int RiftHeraldTakedowns { get; set; }
        /// <summary>
        /// Save Ally From Death
        /// </summary>
        [JsonProperty("saveAllyFromDeath")]
        public int SaveAllyFromDeath { get; set; }
        /// <summary>
        /// Scuttle Crab Kills
        /// </summary>
        [JsonProperty("scuttleCrabKills")]
        public int ScuttleCrabKills { get; set; }
        /// <summary>
        /// Shortest Time To Ace From First Takedown
        /// </summary>
        [JsonProperty("shortestTimeToAceFromFirstTakedown")]
        public double ShortestTimeToAceFromFirstTakedown { get; set; }
        /// <summary>
        /// Skillshots Dodged
        /// </summary>
        [JsonProperty("skillshotsDodged")]
        public int SkillshotsDodged { get; set; }
        /// <summary>
        /// Skillshots Hit
        /// </summary>
        [JsonProperty("skillshotsHit")]
        public int SkillshotsHit { get; set; }
        /// <summary>
        /// Snowballs Hit
        /// </summary>
        [JsonProperty("snowballsHit")]
        public int SnowballsHit { get; set; }
        /// <summary>
        /// Solo Baron Kills
        /// </summary>
        [JsonProperty("soloBaronKills")]
        public int SoloBaronKills { get; set; }
        /// <summary>
        /// SWARM Defeat Aatrox
        /// </summary>
        [JsonProperty("SWARM_DefeatAatrox")]
        public int SWARM_DefeatAatrox { get; set; }
        /// <summary>
        /// SWARM Defeat Briar
        /// </summary>
        [JsonProperty("SWARM_DefeatBriar")]
        public int SWARM_DefeatBriar { get; set; }
        /// <summary>
        /// SWARM Defeat Mini Bosses
        /// </summary>
        [JsonProperty("SWARM_DefeatMiniBosses")]
        public int SWARM_DefeatMiniBosses { get; set; }
        /// <summary>
        /// SWARM Evolve Weapon
        /// </summary>
        [JsonProperty("SWARM_EvolveWeapon")]
        public int SWARM_EvolveWeapon { get; set; }
        /// <summary>
        /// SWARM Have 3 Passives
        /// </summary>
        [JsonProperty("SWARM_Have3Passives")]
        public int SWARM_Have3Passives { get; set; }
        /// <summary>
        /// SWARM Kill Enemy
        /// </summary>
        [JsonProperty("SWARM_KillEnemy")]
        public int SWARM_KillEnemy { get; set; }
        /// <summary>
        /// SWARM Pickup Gold
        /// </summary>
        [JsonProperty("SWARM_PickupGold")]
        public double SWARM_PickupGold { get; set; }
        /// <summary>
        /// SWARM Reach Level 50
        /// </summary>
        [JsonProperty("SWARM_ReachLevel50")]
        public int SWARM_ReachLevel50 { get; set; }
        /// <summary>
        /// SWARM Survive 15 Min
        /// </summary>
        [JsonProperty("SWARM_Survive15Min")]
        public int SWARM_Survive15Min { get; set; }
        /// <summary>
        /// SWARM Win With 5 Evolved Weapons
        /// </summary>
        [JsonProperty("SWARM_WinWith5EvolvedWeapons")]
        public int SWARM_WinWith5EvolvedWeapons { get; set; }
        /// <summary>
        /// Solo Kills
        /// </summary>
        [JsonProperty("soloKills")]
        public int SoloKills { get; set; }
        /// <summary>
        /// Stealth Wards Placed
        /// </summary>
        [JsonProperty("stealthWardsPlaced")]
        public int StealthWardsPlaced { get; set; }
        /// <summary>
        /// Survived Single Digit Hp Count
        /// </summary>
        [JsonProperty("survivedSingleDigitHpCount")]
        public int SurvivedSingleDigitHpCount { get; set; }
        /// <summary>
        /// Survived Three Immobilizes In Fight
        /// </summary>
        [JsonProperty("survivedThreeImmobilizesInFight")]
        public int SurvivedThreeImmobilizesInFight { get; set; }
        /// <summary>
        /// Takedown On First Turret
        /// </summary>
        [JsonProperty("takedownOnFirstTurret")]
        public int TakedownOnFirstTurret { get; set; }
        /// <summary>
        /// Takedowns
        /// </summary>
        [JsonProperty("takedowns")]
        public int Takedowns { get; set; }
        /// <summary>
        /// Takedowns After Gaining Level Advantage
        /// </summary>
        [JsonProperty("takedownsAfterGainingLevelAdvantage")]
        public int TakedownsAfterGainingLevelAdvantage { get; set; }
        /// <summary>
        /// Takedowns Before Jungle Minion Spawn
        /// </summary>
        [JsonProperty("takedownsBeforeJungleMinionSpawn")]
        public int TakedownsBeforeJungleMinionSpawn { get; set; }
        /// <summary>
        /// Takedowns First X Minutes
        /// </summary>
        [JsonProperty("takedownsFirstXMinutes")]
        public int TakedownsFirstXMinutes { get; set; }
        /// <summary>
        /// Takedowns In Alcove
        /// </summary>
        [JsonProperty("takedownsInAlcove")]
        public int TakedownsInAlcove { get; set; }
        /// <summary>
        /// Takedowns In Enemy Fountain
        /// </summary>
        [JsonProperty("takedownsInEnemyFountain")]
        public int TakedownsInEnemyFountain { get; set; }
        /// <summary>
        /// Team Baron Kills
        /// </summary>
        [JsonProperty("teamBaronKills")]
        public int TeamBaronKills { get; set; }
        /// <summary>
        /// Team Damage Percentage
        /// </summary>
        [JsonProperty("teamDamagePercentage")]
        public double TeamDamagePercentage { get; set; }
        /// <summary>
        /// Team Elder Dragon Kills
        /// </summary>
        [JsonProperty("teamElderDragonKills")]
        public int TeamElderDragonKills { get; set; }
        /// <summary>
        /// Team Rift Herald Kills
        /// </summary>
        [JsonProperty("teamRiftHeraldKills")]
        public int TeamRiftHeraldKills { get; set; }
        /// <summary>
        /// Took Large Damage Survived
        /// </summary>
        [JsonProperty("tookLargeDamageSurvived")]
        public int TookLargeDamageSurvived { get; set; }
        /// <summary>
        /// Turret Plates Taken
        /// </summary>
        [JsonProperty("turretPlatesTaken")]
        public int TurretPlatesTaken { get; set; }
        /// <summary>
        /// Turrets Taken With Rift Herald
        /// </summary>
        [JsonProperty("turretsTakenWithRiftHerald")]
        public int TurretsTakenWithRiftHerald { get; set; }
        /// <summary>
        /// Turret Takedowns
        /// </summary>
        [JsonProperty("turretTakedowns")]
        public int TurretTakedowns { get; set; }
        /// <summary>
        /// Twenty Minions In 3 Seconds Count
        /// </summary>
        [JsonProperty("twentyMinionsIn3SecondsCount")]
        public int TwentyMinionsIn3SecondsCount { get; set; }
        /// <summary>
        /// Two Wards One Sweeper Count
        /// </summary>
        [JsonProperty("twoWardsOneSweeperCount")]
        public int TwoWardsOneSweeperCount { get; set; }
        /// <summary>
        /// Unseen Recalls
        /// </summary>
        [JsonProperty("unseenRecalls")]
        public int UnseenRecalls { get; set; }
        /// <summary>
        /// Vision Score Per Minute
        /// </summary>
        [JsonProperty("visionScorePerMinute")]
        public double VisionScorePerMinute { get; set; }
        /// <summary>
        /// Wards Guarded
        /// </summary>
        [JsonProperty("wardsGuarded")]
        public int WardsGuarded { get; set; }
        /// <summary>
        /// Ward Takedowns
        /// </summary>
        [JsonProperty("wardTakedowns")]
        public int WardTakedowns { get; set; }
        /// <summary>
        /// Ward Takedowns Before 20M
        /// </summary>
        [JsonProperty("wardTakedownsBefore20M")]
        public int WardTakedownsBefore20M { get; set; }
    }
}
