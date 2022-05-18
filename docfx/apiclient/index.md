# Developper Documentation **client**

## Game Client API
[Game Client API](https://developer.riotgames.com/docs/lol#general_game-constants)
For recive data from a game add to ```C:/Riot Games/League of Legends/Config/game.cfg```
```
[General]
EnableReplayApi=1
```

add to ```C:/Riot Games/League of Legends/Config/game.cfg``` for see a more graphic timer for dragon and baron  
```
[Spectator]
eSportsNeutralTimers=1
```

## Live Events API :

[Live Events API](https://github.com/SkinSpotlights/LiveEventsDocumentation) is a undocumentated API part of League of Legends that can be enabled via a config and a list of events that you wish to receive updates for. The API is only available in Spectator/Replays.

Documentation of all json recive is comming

used :

- OnKillDragon
- OnKillDragon_Spectator
- OnKillRiftHerald
- OnKillRiftHerald_Spectator
- OnSummonRiftHerald
- OnKillWorm
- OnKillWorm_Spectator
- OnDragonSoulGiven
- OnNeutrakMinionKill

the mess :

- OnDelete
- OnSpawn
- OnDie
- OnKill
- OnChampionDie
- OnChampionLevelUp
- OnChampionKillPre
- OnChampionKill
- OnChampionKillPost
- OnChampionSingleKill
- OnChampionDoubleKill
- OnChampionTripleKill
- OnChampionQuadraKill
- OnChampionPentaKill
- OnChampionUnrealKill
- OnFirstBlood
- OnFirstBloodAssist
- OnDamageTaken
- OnDamageGiven
- OnSpellCast1
- OnSpellCast2
- OnSpellCast3
- OnSpellCast4
- OnSpellAvatarCast1
- OnSpellAvatarCast2
- OnGoldSpent
- OnGoldEarned
- OnItemConsumeablePurchased
- OnCriticalStrike
- OnAce
- OnReincarnate
- OnReviveAlly
- OnChangeChampion
- OnResetChampion
- OnDampenerKill
- OnDampenerDie
- OnDampenerRespawnSoon
- OnDampenerRespawn
- OnDampenerDamage
- OnTurretKill
- OnTurretDie
- OnTurretDamage
- OnTurretFirstBlood
- OnStructureKill
- OnMinionKill
- OnNeutralMinionKill
- OnNeutralMinionCampCleared
- OnAcquireRedBuffFromNeutral
- OnAcquireBlueBuffFromNeutral
- OnHQKill
- OnHQDie
- OnHQDamage
- OnCastHeal
- OnBuff
- OnCrowdControlDealt
- OnCrowdControlExpired
- OnKillingSpree
- OnKillingSpreeSet1
- OnKillingSpreeSet2
- OnKillingSpreeSet3
- OnKillingSpreeSet4
- OnKillingSpreeSet5
- OnKillingSpreeSet6
- OnKilledUnitOnKillingSpree
- OnKilledUnitOnKillingSpreeSet1
- OnKilledUnitOnKillingSpreeSet2
- OnKilledUnitOnKillingSpreeSet3
- OnKilledUnitOnKillingSpreeSet4
- OnKilledUnitOnKillingSpreeSet5
- OnKilledUnitOnKillingSpreeSet6
- OnKilledUnitOnKillingSpreeDoubleKill
- OnKilledUnitOnKillingSpreeTripleKill
- OnKilledUnitOnKillingSpreeQuadraKill
- OnKilledUnitOnKillingSpreePentaKill
- OnKilledUnitOnKillingSpreeUnrealKill
- OnDeathAssist
- OnQuit
- OnLeave
- OnReconnect
- OnGameEnter
- OnGameStart
- OnAssistingSpreeSet1
- OnAssistingSpreeSet2
- OnChampionTripleAssist
- OnChampionPentaAssist
- OnPing
- OnPingPlayer
- OnPingBuilding
- OnPingOther
- OnEndGame
- OnSpellLevelup1
- OnSpellLevelup2
- OnSpellLevelup3
- OnSpellLevelup4
- OnSpellEvolve1
- OnSpellEvolve2
- OnSpellEvolve3
- OnSpellEvolve4
- OnItemPurchased
- OnItemSold
- OnItemRemoved
- OnItemUndo
- OnItemCallout
- OnItemChange
- OnUndoEnabledChange
- OnShopItemSubstitutionChange
- OnShopMenuOpen
- OnShopMenuClose
- OnSurrenderVoteStart
- OnSurrenderVote
- OnSurrenderVoteAlready
- OnSurrenderFailedVotes
- OnSurrenderTooEarly
- OnSurrenderAgreed
- OnSurrenderSpam
- OnNormalAfkSurrenderAllowed
- OnSurrenderEarlyAllowed
- OnSurrenderEarlyAccomplice
- OnSurrenderEarlyOver
- OnSurrenderEarlyFailed
- OnSurrenderEarlyFailedNoLongerAvailable
- OnSurrenderEarlyFailedDisabled
- OnSurrenderEarlyTooEarly
- OnSurrenderEarlyFailedNeverAvailable
- OnEarlySurrenderVoteStart
- OnUnanimousSurrenderVoteStart
- OnUnanimousSurrenderFailedVotes
- OnUnanimousAfkSurrenderAllowed
- OnPause
- OnPauseResume
- OnMinionsSpawn
- OnStartGameMessage1
- OnStartGameMessage2
- OnStartGameMessage3
- OnStartGameMessage4
- OnStartGameMessage5
- OnAlert
- OnAudioEventFinished
- OnNexusCrystalStart
- OnCapturePointNeutralized_A
- OnCapturePointNeutralized_B
- OnCapturePointNeutralized_C
- OnCapturePointNeutralized_D
- OnCapturePointNeutralized_E
- OnCapturePointCaptured_A
- OnCapturePointCaptured_B
- OnCapturePointCaptured_C
- OnCapturePointCaptured_D
- OnCapturePointCaptured_E
- OnCapturePointFiveCap
- OnVictoryPointThreshold1
- OnVictoryPointThreshold2
- OnVictoryPointThreshold3
- OnVictoryPointThreshold4
- OnGameModeAnnouncement1
- OnGameModeAnnouncement2
- OnGameModeAnnouncement3
- OnGameModeAnnouncement4
- OnGameModeAnnouncement5
- OnGameModeAnnouncement6
- OnGameModeAnnouncement7
- OnGameModeAnnouncement8
- OnGameModeAnnouncement9
- OnGameModeAnnouncement10
- OnGameModeAnnouncement11
- OnGameModeAnnouncement12
- OnGameModeAnnouncement13
- OnGameModeAnnouncement14
- OnGameModeAnnouncement15
- OnGameModeAnnouncement16
- OnReplayFastForwardStart
- OnReplayFastForwardEnd
- OnReplayOnKeyframeFinished
- OnReplayDestroyAllObjects
- OnKillDragon
- OnKillDragon_Spectator
- OnKillDragonSteal
- OnKillRiftHerald
- OnKillRiftHerald_Spectator
- OnKillRiftHeraldSteal
- OnSummonRiftHerald
- OnKillWorm
- OnKillWorm_Spectator
- OnKillWormSteal
- OnKillSpiderBoss
- OnKillSpiderBoss_Spectator
- OnCaptureAltar
- OnCaptureAltar_Spectator
- OnPlaceWard
- OnKillWard
- OnMinionAscended
- OnChampionAscended
- OnClearAscended
- OnGameStatEvent
- OnRelativeTeamColorChange
- OnMapSkinSwap
- OnResetGame
- OnResetGameCompleted
- OnShutdown
- OnMute
- OnChampionTransformNone
- OnChampionTransformAssassin
- OnChampionTransformSlayer
- OnReceiveShield
- OnGrantShield
- OnDamageShielded
- OnMaterialOverride
- OnObjectiveStolen
- OnObjectiveTaken
- OnNextDragonQueued
- OnGearChanged
- OnSummonerEmotePlayed
- OnSummonerEmoteEnd
- OnCustomStatStoneEvent
- OnStatStoneMilestoneHitEvent
- OnEnterStealth
- OnExitStealth
- OnPetSpawned
- OnLifeSteal
- OnSpellVamp
- OnLocalPlayerLoadoutBound
- OnTurretPlateDestroyed
- OnPlantActivated
- OnEnterPlayerVisibility
- OnDragonSoulGiven
- OnDisconnect
- OnConnect

## Spectator Visuel

- ```ctrl + maj + w``` for change max zoom of map
- ```x``` for total gold
- 