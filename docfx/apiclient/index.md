# Developper Documentation **client**

## Riot API
- Spectator-v4 (get information of a player in game)
    - /lol/spectator/v4/active-games/by-summoner/{encryptedSummonerId}
- Summoner-V4 (get summoners information)
    - /lol/summoner/v4/summoners/by-name/{summonerName} (get encryptedSummonerId)


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

Documentation in progress

[Live Events API](https://github.com/SkinSpotlights/LiveEventsDocumentation) is a undocumentated API part of League of Legends that can be enabled via a config and a list of events that you wish to receive updates for. The API is only available in Spectator/Replays.

### Documentation of **Live Events API** .
This documentation concern just **Replay** or **Spectator** mode
If he is note ```no information``` he is possible he exist in other game mode or I juts don't found it in a spécific game

#### I suggest you use only this information  :
```
OnKill
OnKillDragon
OnKillDragon_Spectator
OnKillRiftHerald
OnKillRiftHerald_Spectator
OnSummonRiftHerald
OnKillWorm
OnKillWorm_Spectator
OnDragonSoulGiven
OnNeutrakMinionKill
```

#### Patern :

- **"eventname"**: Name of the event
- **"other"** : Name of the summoner, turret or mobs (minion, neutral mobs, drake, nash, ...) in game he is impacted by the action
- **"otherID"** : Id of the summoner in game he make the action (0 to 9) if is not a summoner no "sourceID" display
- **"otherTeam"** : Name of the team (Chaos, Order, Neutral)
- **"source"**: Name of the summoner, turret or mobs (minion, neutral mobs, drake, nash, ...) in game he make the action
- **"sourceID"**: Id of the summoner in game he make the action (0 to 9) if is not a summoner no "sourceID" display
- **"sourceTeam"**: Name of the team (Chaos, Order, Neutral)
```json
{
	"eventname": "string",
	"other": "string?", //Possible to be null
	"otherID": "string?", //Possible to be null
	"otherTeam": "string?", //Possible to be null
	"source": "string?", //Possible to be null
	"sourceID": "string?", //Possible to be null
	"sourceTeam": "string?" //Possible to be null
}
```

#### Information that can be found 
- Turret :
```
Turret_T1_L_03_A //T1 Top Blue
Turret_T1_L_02_A //T2 Top Blue
Turret_T1_C_06_A //T3 Top Blue

Turret_T1_R_03_A //T1 Bot Blue
Turret_T1_R_02_A //T2 Bot Blue
Turret_T1_C_07_A //T3 Bot Blue

Turret_T1_C_05_A //T1 Mid Blue
Turret_T1_C_04_A //T2 Mid Blue
Turret_T1_C_03_A //T3 Mid Blue

Turret_T1_C_01_A //T4 Nexus Top Blue
Turret_T1_C_02_A //T4 Nexus Bot Blue

Turret_T2_L_03_A //T1 Top Red
Turret_T2_L_02_A //T2 Top Red
Turret_T2_L_01_A //T3 Top Red

Turret_T2_R_03_A //T1 Bot Red
Turret_T2_R_02_A //T2 Bot Red
Turret_T2_R_01_A //T3 Bot Red

Turret_T2_C_05_A //T1 Bot Red
Turret_T2_C_04_A //T2 Bot Red
Turret_T2_C_03_A //T3 Bot Red

Turret_T2_C_02_A //T4 Nexus Top Red
Turret_T2_C_01_A //T4 Nexus Bot Red
```

- Inib :
```
Not information in game
Barracks_T1_L1 //Inib Top Blue
Barracks_T1_R1 //Inib Bot Blue
Barracks_T1_C1 //Inib Mid Blue

Barracks_T2_L1 //Inib Top Red
Barracks_T2_R1 //Inib Bot Red
Barracks_T2_C1 //Inib Mid Red
```

- Jungler Mobs :
    - Dragons :
	```
	SRU_Dragon_Fire
	SRU_Dragon_Air
	SRU_Dragon_Hextech
	SRU_Dragon_Water
	SRU_Dragon_Earth
	SRU_Dragon_Elder
	```
    - Herald :
	```
	SRU_RiftHerald17.1.1
	Rift Herald Relic
	RiftHeraldMercenary
	```
    - Baron :
	```
	SRU_BaronSpawn12.1.2
	SRU_Baron12.1.1
	```
    - Red
	- Blue
	- Wolf
	- Gromp
	- Crab
	- Krug
	- Razorbeak
	- WardCorpse
	- PlantVision

#### All the information :

- **OnDelete**
```json
{
	"eventname": "OnDelete"
}
```
- OnSpawn ```no information```
- **OnDie**
```json
Exemple 1: 
{
	"eventname": "OnDie",
	"other": "WilsonMagicWand",
	"otherID": "0",
	"otherTeam": "Order",
	"source": "Le JOAT",
	"sourceID": "8",
	"sourceTeam": "Chaos"
}
Exemple 2:
{
	"eventname": "OnDie",
	"other": "Turret_T1_R_03_A",
	"otherTeam": "Order",
	"source": "100M girls Dream",
	"sourceID": "9",
	"sourceTeam": "Chaos"
}
Exemple 3:
{
	"eventname": "OnDie",
	"other": "Phenix NemBot",
	"otherID": "4",
	"otherTeam": "Order",
	"source": "ThreshLostSoul",
	"sourceTeam": "Order"
}
Exemple 4:
{
	"eventname": "OnDie",
	"other": "CampRespawn",
	"otherTeam": "Neutral",
	"source": "CampRespawn",
	"sourceTeam": "Neutral"
}
Exemple 5:
{
	"eventname": "OnDie",
	"other": "Simp Eboy",
	"otherID": "1",
	"otherTeam": "Order",
	"source": "SRU_Red4.1.1",
	"sourceTeam": "Neutral"
}
Exemple 6:
{
	"eventname": "OnDie",
	"other": "ScrandHD",
	"otherID": "2",
	"otherTeam": "Order",
	"source": "Minion_T200L1S01N0001",
	"sourceTeam": "Chaos"
}
Exemple 7:
{
	"eventname": "OnDie",
	"other": "Minion_T100L1S01N0003",
	"otherTeam": "Order",
	"source": "Minion_T200L1S01N0000",
	"sourceTeam": "Chaos"
}
Exemple 8:
{
	"eventname": "OnDie",
	"other": "Pou Lord",
	"otherID": "6",
	"otherTeam": "Chaos",
	"source": "SRU_MurkwolfMini8.1.3",
	"sourceTeam": "Neutral"
}
Exemple 9:
{
	"eventname": "OnDie",
	"other": "Osman Üstüner",
	"otherID": "7",
	"otherTeam": "Chaos",
	"source": "Minion_T100L1S01N0001",
	"sourceTeam": "Order"
}
Exemple 10:
{
	"eventname": "OnDie",
	"other": "DO U KNO DA WAE",
	"otherID": "5",
	"otherTeam": "Chaos",
	"source": "BlobDrop",
	"sourceTeam": "Chaos"
}
Exemple 11:
{
	"eventname": "OnDie",
	"other": "ScrandHD",
	"otherID": "2",
	"otherTeam": "Order",
	"source": "EyebeamVision",
	"sourceTeam": "Order"
}
Exemple 12:
{
	"eventname": "OnDie",
	"other": "ScrandHD",
	"otherID": "2",
	"otherTeam": "Order",
	"source": "Poot",
	"sourceTeam": "Order"
}
Exemple 13:
{
	"eventname": "OnDie",
	"other": "HuSaw",
	"otherID": "3",
	"otherTeam": "Order",
	"source": "SightWard",
	"sourceTeam": "Order"
}
Exemple 14
{
	"eventname": "OnDie",
	"other": "Turret_T1_L_03_A",
	"otherTeam": "Order",
	"source": "Minion_T200L2S01N0000",
	"sourceTeam": "Chaos"
}
Exemple 14:
{
	"eventname": "OnDie",
	"other": "Pou Lord",
	"otherID": "6",
	"otherTeam": "Chaos",
	"source": "SRU_Gromp14.1.1",
	"sourceTeam": "Neutral"
}
Exemple 15:
{
	"eventname": "OnDie",
	"other": "Pou Lord",
	"otherID": "6",
	"otherTeam": "Chaos",
	"source": "SRU_Blue7.1.1",
	"sourceTeam": "Neutral"
}
Exemple 16:
{
	"eventname": "OnDie",
	"other": "Simp Eboy",
	"otherID": "1",
	"otherTeam": "Order",
	"source": "SRU_Blue1.1.1",
	"sourceTeam": "Neutral"
}
Exemple 17:
{
	"eventname": "OnDie",
	"other": "100M girls Dream",
	"otherID": "9",
	"otherTeam": "Chaos",
	"source": "Phenix NemBot",
	"sourceID": "4",
	"sourceTeam": "Order"
}
Exemple 18:
{
	"eventname": "OnDie",
	"other": "Phenix NemBot",
	"otherID": "4",
	"otherTeam": "Order",
	"source": "100M girls Dream",
	"sourceID": "9",
	"sourceTeam": "Chaos"
}
Exemple 19:
{
	"eventname": "OnDie",
	"other": "WardCorpse",
	"otherTeam": "Neutral",
	"source": "WardCorpse",
	"sourceTeam": "Neutral"
}
Exemple 20:
{
	"eventname": "OnDie",
	"other": "Pou Lord",
	"otherID": "6",
	"otherTeam": "Chaos",
	"source": "SRU_RazorbeakMini9.1.5",
	"sourceTeam": "Neutral"
}
Exemple 21:
{
	"eventname": "OnDie",
	"other": "Pou Lord",
	"otherID": "6",
	"otherTeam": "Chaos",
	"source": "SRU_RazorbeakMini9.1.6",
	"sourceTeam": "Neutral"
}
Exemple 22:
{
	"eventname": "OnDie",
	"other": "Pou Lord",
	"otherID": "6",
	"otherTeam": "Chaos",
	"source": "SRU_Razorbeak9.1.1",
	"sourceTeam": "Neutral"
}
.....
```
- **OnKill**
```json
.... beaucoup
```
- **OnChampionDie**
```json
Exemple 1:
{
	"eventname": "OnChampionDie",
	"other": "WilsonMagicWand",
	"otherID": "0",
	"otherTeam": "Order",
	"source": "Le JOAT",
	"sourceID": "8",
	"sourceTeam": "Chaos"
}
Exemple 2:
{
	"eventname": "OnChampionDie",
	"other": "Turret_T1_R_03_A",
	"otherTeam": "Order",
	"source": "100M girls Dream",
	"sourceID": "9",
	"sourceTeam": "Chaos"
}
Exemple 3:
{
	"eventname": "OnChampionDie",
	"other": "100M girls Dream",
	"otherID": "9",
	"otherTeam": "Chaos",
	"source": "Phenix NemBot",
	"sourceID": "4",
	"sourceTeam": "Order"
}
```
- OnChampionLevelUp ```no information```
- **OnChampionKillPre**
```json
Exemple 1:
{
	"eventname": "OnChampionKillPre",
	"other": "Le JOAT",
	"otherID": "8",
	"otherTeam": "Chaos",
	"source": "WilsonMagicWand",
	"sourceID": "0",
	"sourceTeam": "Order"
}
Exemple 2:
{
	"eventname": "OnChampionKillPre",
	"other": "Phenix NemBot",
	"otherID": "4",
	"otherTeam": "Order",
	"source": "100M girls Dream",
	"sourceID": "9",
	"sourceTeam": "Chaos"
}

```
- **OnChampionKill**
```json
Exemple 1:
{
	"eventname": "OnChampionKill",
	"other": "Phenix NemBot",
	"otherID": "4",
	"otherTeam": "Order",
	"source": "DO U KNO DA WAE",
	"sourceID": "5",
	"sourceTeam": "Chaos"
}
Exemple 2:
{
	"eventname": "OnChampionKill",
	"other": "DO U KNO DA WAE",
	"otherID": "5",
	"otherTeam": "Chaos",
	"source": "HuSaw",
	"sourceID": "3",
	"sourceTeam": "Order"
}
```
- OnChampionKillPost ```no information```
- OnChampionSingleKill ```no information but possible exist```
- **OnChampionDoubleKill**
```json
Exempel 1:
{
	"eventname": "OnChampionDoubleKill",
	"other": "Le JOAT",
	"otherID": "8",
	"otherTeam": "Chaos",
	"source": "Simp Eboy",
	"sourceID": "1",
	"sourceTeam": "Order"
}
Exempel 2:
{
	"eventname": "OnChampionDoubleKill",
	"other": "HuSaw",
	"otherID": "3",
	"otherTeam": "Order",
	"source": "DO U KNO DA WAE",
	"sourceID": "5",
	"sourceTeam": "Chaos"
}
```
- **OnChampionTripleKill**
```json
Exempel 1:
{
	"eventname": "OnChampionTripleKill",
	"other": "Osman Üstüner",
	"otherID": "7",
	"otherTeam": "Chaos",
	"source": "Simp Eboy",
	"sourceID": "1",
	"sourceTeam": "Order"
}
```
- OnChampionQuadraKill ```no information but possible exist```
- OnChampionPentaKill ```no information but possible exist```
- OnChampionUnrealKill ```no information but possible exist```
- **OnFirstBlood**
```json
{
	"eventname": "OnFirstBlood",
	"other": "Le JOAT",
	"otherID": "8",
	"otherTeam": "Chaos",
	"source": "WilsonMagicWand",
	"sourceID": "0",
	"sourceTeam": "Order"
}
```
- **OnFirstBloodAssist**
```json
{
	"eventname": "OnFirstBloodAssist",
	"source": "NameSummoner",
	"sourceID": "IdSummoner",
	"sourceTeam": "NameTeam"
}
```
- OnDamageTaken ```no information```
- **OnDamageGiven**
```json
Exemple 1 :
{
	"eventname": "OnDamageGiven",
	"other": "Minion_T100L0S01N0002",
	"otherTeam": "Order",
	"source": "Minion_T200L0S01N0002",
	"sourceTeam": "Chaos"
}
Exemple 2 :
{
	"eventname": "OnDamageGiven",
	"other": "Minion_T200L2S01N0002",
	"otherTeam": "Chaos",
	"source": "Minion_T100L2S01N0002",
	"sourceTeam": "Order"
}
Exemple 3 :
{
	"eventname": "OnDamageGiven",
	"other": "SRU_Blue7.1.1",
	"otherTeam": "Neutral",
	"source": "Pou Lord",
	"sourceID": "6",
	"sourceTeam": "Chaos"
}
Exemple 4 :
{
	"eventname": "OnDamageGiven",
	"other": "SRU_Murkwolf8.1.1",
	"otherTeam": "Neutral",
	"source": "Pou Lord",
	"sourceID": "6",
	"sourceTeam": "Chaos"
}
Exemple 5 :
{
	"eventname": "OnDamageGiven",
	"other": "Minion_T200L1S01N0001",
	"otherTeam": "Chaos",
	"source": "ScrandHD",
	"sourceID": "2",
	"sourceTeam": "Order"
}
Exemple 6 :
{
	"eventname": "OnDamageGiven",
	"other": "Osman Üstüner",
	"otherID": "7",
	"otherTeam": "Chaos",
	"source": "ScrandHD",
	"sourceID": "2",
	"sourceTeam": "Order"
}
......
```
- OnSpellCast1 ```no information```
- OnSpellCast2 ```no information```
- OnSpellCast3 ```no information```
- OnSpellCast4 ```no information```
- OnSpellAvatarCast1 ```no information```
- OnSpellAvatarCast2 ```no information```
- OnGoldSpent ```no information```
- OnGoldEarned ```no information```
- OnItemConsumeablePurchased ```no information```
- OnCriticalStrike ```no information```
- **OnAce** 
```json
{
	"eventname": "OnAce",
	"other": "Le JOAT",
	"otherID": "8",
	"otherTeam": "Chaos",
	"source": "Simp Eboy",
	"sourceID": "1",
	"sourceTeam": "Order"
}
```
- **OnReincarnate**
```json
Exemple 1 :
{
	"eventname": "OnReincarnate",
	"source": "Le JOAT",
	"sourceID": "8",
	"sourceTeam": "Chaos"
}
Exemple 2 :
{
	"eventname": "OnReincarnate",
	"source": "Phenix NemBot",
	"sourceID": "4",
	"sourceTeam": "Order"
}
```
- OnReviveAlly ```no information BUT```
- **OnChangeChampion**
```json
{
	"eventname": "OnChangeChampion"
}
```
- OnResetChampion ```no information```
- OnDampenerKill ```no information```
- **OnDampenerDie**
```json
Exemple 1 :
{
	"eventname": "OnDampenerDie",
	"other": "Minion_T100L0S45N0284",
	"otherTeam": "Order"
}
Exemple 2 :
{
	"eventname": "OnDampenerDie",
	"other": "Simp Eboy",
	"otherID": "1",
	"otherTeam": "Order"
}
```
- **OnDampenerRespawnSoon**
```json
{
	"eventname": "OnDampenerRespawnSoon"
}
```
- **OnDampenerRespawn**
```json
{
	"eventname": "OnDampenerRespawn"
}
```
- OnDampenerDamage ```no information```
- OnTurretKill ```no information```
- **OnTurretDie**
```json
Exemple 1 :
{
	"eventname": "OnTurretDie",
	"other": "Minion_T200L0S18N0111",
	"otherTeam": "Chaos",
	"source": "Turret_T1_R_03_A",
	"sourceTeam": "Order"
}
Exemple 2 :
{
	"eventname": "OnTurretDie",
	"other": "Minion_T100L1S58N0370",
	"otherTeam": "Order",
	"source": "Turret_T2_C_01_A",
	"sourceTeam": "Chaos"
}
Exemple 3 :
{
	"eventname": "OnTurretDie",
	"other": "Osman Üstüner",
	"otherID": "7",
	"otherTeam": "Chaos",
	"source": "Turret_T1_C_05_A",
	"sourceTeam": "Order"
}
Exemple 4 :
{
	"eventname": "OnTurretDie",
	"other": "Simp Eboy",
	"otherID": "1",
	"otherTeam": "Order",
	"source": "Turret_T2_L_03_A",
	"sourceTeam": "Chaos"
}
```
- OnTurretDamage ```no information```
- **OnTurretFirstBlood**
```json
{
	"eventname": "OnTurretFirstBlood",
	"other": "Minion_T200L0S18N0111",
	"otherTeam": "Chaos",
	"source": "Turret_T1_R_03_A",
	"sourceTeam": "Order"
}
```
- OnStructureKill ```no information```
- **OnMinionKill**
```json
Exemple 1 :
{
	"eventname": "OnMinionKill",
	"other": "Minion_T200L1S18N0113",
	"otherTeam": "Chaos",
	"source": "Minion_T100L1S19N0118",
	"sourceTeam": "Order"
}
Exemple 2 :
{
	"eventname": "OnMinionKill",
	"other": "Minion_T100L2S18N0111",
	"otherTeam": "Order",
	"source": "Turret_T2_L_03_A",
	"sourceTeam": "Chaos"
}
Exemple 3 :
{
	"eventname": "OnMinionKill",
	"other": "Minion_T100L0S19N0118",
	"otherTeam": "Order",
	"source": "100M girls Dream",
	"sourceID": "9",
	"sourceTeam": "Chaos"
}
Exemple 4 :
{
	"eventname": "OnMinionKill",
	"other": "Pou Lord",
	"otherTeam": "Chaos",
	"source": "Phenix NemBot",
	"sourceID": "4",
	"sourceTeam": "Order"
}
Exemple 5 :
{
	"eventname": "OnMinionKill",
	"other": "Minion_T200L2S22N0137",
	"otherTeam": "Chaos",
	"source": "Turret_T1_L_03_A",
	"sourceTeam": "Order"
}
....
```
- **OnNeutralMinionKill**
```json
Exemple 1 :
{
	"eventname": "OnNeutralMinionKill",
	"other": "CampRespawn",
	"otherTeam": "Neutral",
	"source": "CampRespawn",
	"sourceTeam": "Neutral"
}
Exemple 2 :
{
	"eventname": "OnNeutralMinionKill",
	"other": "SRU_Red4.1.1",
	"otherTeam": "Neutral",
	"source": "Simp Eboy",
	"sourceID": "1",
	"sourceTeam": "Order"
}
Exemple 3 :
{
	"eventname": "OnNeutralMinionKill",
	"other": "SRU_MurkwolfMini8.1.3",
	"otherTeam": "Neutral",
	"source": "Pou Lord",
	"sourceID": "6",
	"sourceTeam": "Chaos"
}
Exemple 4 :
{
	"eventname": "OnNeutralMinionKill",
	"other": "SRU_MurkwolfMini8.1.2",
	"otherTeam": "Neutral",
	"source": "Pou Lord",
	"sourceID": "6",
	"sourceTeam": "Chaos"
}
Exemple 5 :
{
	"eventname": "OnNeutralMinionKill",
	"other": "SRU_Murkwolf8.1.1",
	"otherTeam": "Neutral",
	"source": "Pou Lord",
	"sourceID": "6",
	"sourceTeam": "Chaos"
}
Exemple 6 :
{
	"eventname": "OnNeutralMinionKill",
	"other": "SRU_Murkwolf2.1.1",
	"otherTeam": "Neutral",
	"source": "Simp Eboy",
	"sourceID": "1",
	"sourceTeam": "Order"
}
Exemple 7 :
{
	"eventname": "OnNeutralMinionKill",
	"other": "SRU_Gromp14.1.1",
	"otherTeam": "Neutral",
	"source": "Pou Lord",
	"sourceID": "6",
	"sourceTeam": "Chaos"
}
Exemple 8 :
{
	"eventname": "OnNeutralMinionKill",
	"other": "SRU_RazorbeakMini9.1.5",
	"otherTeam": "Neutral",
	"source": "Pou Lord",
	"sourceID": "6",
	"sourceTeam": "Chaos"
}
....
```
- OnNeutralMinionCampCleared ```no information```
- OnAcquireRedBuffFromNeutral ```no information```
- OnAcquireBlueBuffFromNeutral ```no information```
- **OnHQKill**
```json
{
	"eventname": "OnHQKill",
	"other": "WilsonMagicWand",
	"otherID": "0",
	"otherTeam": "Order"
}
```
- OnHQDie ```no information```
- OnHQDamage ```no information```
- **OnCastHeal**
```json
Exemple 1 :
{
	"eventname": "OnCastHeal",
	"other": "Simp Eboy",
	"otherID": "1",
	"otherTeam": "Order",
	"source": "Simp Eboy",
	"sourceID": "1",
	"sourceTeam": "Order"
}
Exemple 2 :
{
	"eventname": "OnCastHeal",
	"other": "WilsonMagicWand",
	"otherID": "0",
	"otherTeam": "Order",
	"source": "WilsonMagicWand",
	"sourceID": "0",
	"sourceTeam": "Order"
}
Exemple 3 :
{
	"eventname": "OnCastHeal",
	"other": "Pou Lord",
	"otherID": "6",
	"otherTeam": "Chaos",
	"source": "Pou Lord",
	"sourceID": "6",
	"sourceTeam": "Chaos"
}
```
- OnBuff ```no information```
- OnCrowdControlDealt ```no information```
- OnCrowdControlExpired ```no information```
- **OnKillingSpree**
```json
{
	"eventname": "OnKillingSpree",
	"other": "Simp Eboy",
	"otherID": "1",
	"otherTeam": "Order",
	"source": "Simp Eboy",
	"sourceID": "1",
	"sourceTeam": "Order"
}
```
- **OnKillingSpreeSet1**
```json
Exemple 1 :
{
	"eventname": "OnKillingSpreeSet1",
	"other": "Phenix NemBot",
	"otherID": "4",
	"otherTeam": "Order",
	"source": "Osman Üstüner",
	"sourceID": "7",
	"sourceTeam": "Chaos"
}
Exemple 2 :
{
	"eventname": "OnKillingSpreeSet1",
	"other": "100M girls Dream",
	"otherID": "9",
	"otherTeam": "Chaos",
	"source": "Simp Eboy",
	"sourceID": "1",
	"sourceTeam": "Order"
}
```
- **OnKillingSpreeSet2**
```json
Exemple 1 :
{
	"eventname": "OnKillingSpreeSet2",
	"other": "Phenix NemBot",
	"otherID": "4",
	"otherTeam": "Order",
	"source": "Osman Üstüner",
	"sourceID": "7",
	"sourceTeam": "Chaos"
}
Exemple 2 :
{
	"eventname": "OnKillingSpreeSet2",
	"other": "Le JOAT",
	"otherID": "8",
	"otherTeam": "Chaos",
	"source": "Simp Eboy",
	"sourceID": "1",
	"sourceTeam": "Order"
}
```
- **OnKillingSpreeSet3**
```json
{
	"eventname": "OnKillingSpreeSet3",
	"other": "DO U KNO DA WAE",
	"otherID": "5",
	"otherTeam": "Chaos",
	"source": "HuSaw",
	"sourceID": "3",
	"sourceTeam": "Order"
}
```
- **OnKillingSpreeSet4**
```json
{
	"eventname": "OnKillingSpreeSet4",
	"other": "100M girls Dream",
	"otherID": "9",
	"otherTeam": "Chaos",
	"source": "HuSaw",
	"sourceID": "3",
	"sourceTeam": "Order"
}
```
- **OnKillingSpreeSet5**
```json
{
	"eventname": "OnKillingSpreeSet5",
	"other": "Osman Üstüner",
	"otherID": "7",
	"otherTeam": "Chaos",
	"source": "HuSaw",
	"sourceID": "3",
	"sourceTeam": "Order"
}
```
- **OnKillingSpreeSet6**
```json
{
	"eventname": "OnKillingSpreeSet6",
	"other": "Le JOAT",
	"otherID": "8",
	"otherTeam": "Chaos",
	"source": "HuSaw",
	"sourceID": "3",
	"sourceTeam": "Order"
}
```
- OnKilledUnitOnKillingSpree ```no information```
- OnKilledUnitOnKillingSpreeSet1 ```no information```
- OnKilledUnitOnKillingSpreeSet2 ```no information```
- OnKilledUnitOnKillingSpreeSet3 ```no information```
- OnKilledUnitOnKillingSpreeSet4 ```no information```
- OnKilledUnitOnKillingSpreeSet5 ```no information```
- OnKilledUnitOnKillingSpreeSet6 ```no information```
- OnKilledUnitOnKillingSpreeDoubleKill ```no information```
- OnKilledUnitOnKillingSpreeTripleKill ```no information```
- OnKilledUnitOnKillingSpreeQuadraKill ```no information```
- OnKilledUnitOnKillingSpreePentaKill ```no information```
- OnKilledUnitOnKillingSpreeUnrealKill ```no information```
- **OnDeathAssist**
```json
Exemple 1 :
{
	"eventname": "OnDeathAssist",
	"other": "Phenix NemBot",
	"otherID": "4",
	"otherTeam": "Order",
	"source": "Le JOAT",
	"sourceID": "8",
	"sourceTeam": "Chaos"
}
Exemple 2 :
{
	"eventname": "OnDeathAssist",
	"other": "100M girls Dream",
	"otherID": "9",
	"otherTeam": "Chaos",
	"source": "HuSaw",
	"sourceID": "3",
	"sourceTeam": "Order"
}
Exemple 3 :
{
	"eventname": "OnDeathAssist",
	"other": "Turret_T1_R_03_A",
	"otherTeam": "Order",
	"source": "100M girls Dream",
	"sourceID": "9",
	"sourceTeam": "Chaos"
}
Exemple 4 :
{
	"eventname": "OnDeathAssist",
	"other": "SRU_Dragon_Air",
	"otherTeam": "Neutral",
	"source": "Pou Lord",
	"sourceID": "6",
	"sourceTeam": "Chaos"
}
Exemple 5 :
{
	"eventname": "OnDeathAssist",
	"other": "SRU_RiftHerald17.1.1",
	"otherTeam": "Neutral",
	"source": "ScrandHD",
	"sourceID": "2",
	"sourceTeam": "Order"
}
Exemple 6 :
{
	"eventname": "OnDeathAssist",
	"other": "SRU_RiftHerald17.1.1",
	"otherTeam": "Neutral",
	"source": "100M girls Dream",
	"sourceID": "9",
	"sourceTeam": "Chaos"
}
Exemple 7 :
{
	"eventname": "OnDeathAssist",
	"other": "SRU_Baron12.1.1",
	"otherTeam": "Neutral",
	"source": "ScrandHD",
	"sourceID": "2",
	"sourceTeam": "Order"
}
Exemple 8 :
{
	"eventname": "OnDeathAssist",
	"other": "SRU_Baron12.1.1",
	"otherTeam": "Neutral",
	"source": "100M girls Dream",
	"sourceID": "9",
	"sourceTeam": "Chaos"
}
Exemple 9 :
{
	"eventname": "OnDeathAssist",
	"source": "WilsonMagicWand",
	"sourceID": "0",
	"sourceTeam": "Order"
}
```
- **OnQuit**
```json
{
	"eventname": "OnQuit",
	"source": "Le JOAT",
	"sourceID": "8",
	"sourceTeam": "Chaos"
}
```
- OnLeave ```no information BUT```
- OnReconnect ```no information BUT```
- OnGameEnter ```no information```
- OnGameStart ```no information```
- OnAssistingSpreeSet1 ```no information```
- OnAssistingSpreeSet2 ```no information```
- OnChampionTripleAssist ```no information```
- OnChampionPentaAssist ```no information```
- **OnPing**
```json
{
	"eventname": "OnPing"
}
```
- **OnPingPlayer**
```json
{
	"eventname": "OnPingPlayer"
}
```
- **OnPingBuilding**
```json
{
	"eventname": "OnPingBuilding"
}
```
- **OnPingOther**
```json
{
	"eventname": "OnPingOther"
}
```
- OnEndGame ```no information```
- OnSpellLevelup1 ```no information```
- OnSpellLevelup2 ```no information```
- OnSpellLevelup3 ```no information```
- OnSpellLevelup4 ```no information```
- OnSpellEvolve1 ```no information```
- OnSpellEvolve2 ```no information```
- OnSpellEvolve3 ```no information```
- OnSpellEvolve4 ```no information```
- OnItemPurchased ```no information```
- OnItemSold ```no information```
- OnItemRemoved ```no information```
- OnItemUndo ```no information```
- **OnItemCallout**
```json
Exemple 1 :
{
	"eventname": "OnItemCallout",
	"source": "Simp Eboy",
	"sourceID": "1",
	"sourceTeam": "Order"
}
Exemple 2 :
{
	"eventname": "OnItemCallout",
	"source": "Le JOAT",
	"sourceID": "8",
	"sourceTeam": "Chaos"
}
```
- OnItemChange ```no information```
- OnUndoEnabledChange ```no information```
- OnShopItemSubstitutionChange ```no information```
- OnShopMenuOpen ```no information```
- OnShopMenuClose ```no information```
- OnSurrenderVoteStart ```no information```
- OnSurrenderVote ```no information```
- OnSurrenderVoteAlready ```no information```
- **OnSurrenderFailedVotes**
```json
{
	"eventname": "OnSurrenderFailedVotes",
	"source": "DO U KNO DA WAE",
	"sourceID": "5",
	"sourceTeam": "Chaos"
}
```
- OnSurrenderTooEarly ```no information```
- OnSurrenderAgreed ```no information```
- OnSurrenderSpam ```no information```
- OnNormalAfkSurrenderAllowed ```no information```
- OnSurrenderEarlyAllowed ```no information```
- OnSurrenderEarlyAccomplice ```no information```
- OnSurrenderEarlyOver ```no information```
- OnSurrenderEarlyFailed ```no information```
- OnSurrenderEarlyFailedNoLongerAvailable ```no information```
- OnSurrenderEarlyFailedDisabled ```no information```
- OnSurrenderEarlyTooEarly ```no information```
- OnSurrenderEarlyFailedNeverAvailable ```no information```
- OnEarlySurrenderVoteStart ```no information```
- OnUnanimousSurrenderVoteStart ```no information```
- OnUnanimousSurrenderFailedVotes ```no information```
- OnUnanimousAfkSurrenderAllowed ```no information```
- OnPause ```no information BUT```
- OnPauseResume ```no information BUT```
- **OnMinionsSpawn**
```json
{
	"eventname": "OnMinionsSpawn"
}
```
- **OnStartGameMessage1**
```json
{
	"eventname": "OnStartGameMessage1"
}
```
- **OnStartGameMessage2**
```json
{
	"eventname": "OnStartGameMessage2"
}
```
- OnStartGameMessage3 ```no information```
- OnStartGameMessage4 ```no information```
- OnStartGameMessage5 ```no information```
- OnAlert ```no information```
- OnAudioEventFinished ```no information```
- **OnNexusCrystalStart**
```json
{
	"eventname": "OnNexusCrystalStart"
}
```
- OnCapturePointNeutralized_A ```no information```
- OnCapturePointNeutralized_B ```no information```
- OnCapturePointNeutralized_C ```no information```
- OnCapturePointNeutralized_D ```no information```
- OnCapturePointNeutralized_E ```no information```
- OnCapturePointCaptured_A ```no information```
- OnCapturePointCaptured_B ```no information```
- OnCapturePointCaptured_C ```no information```
- OnCapturePointCaptured_D ```no information```
- OnCapturePointCaptured_E ```no information```
- OnCapturePointFiveCap ```no information```
- OnVictoryPointThreshold1 ```no information```
- OnVictoryPointThreshold2 ```no information```
- OnVictoryPointThreshold3 ```no information```
- OnVictoryPointThreshold4 ```no information```
- OnGameModeAnnouncement1 ```no information```
- OnGameModeAnnouncement2 ```no information```
- OnGameModeAnnouncement3 ```no information```
- OnGameModeAnnouncement4 ```no information```
- **OnGameModeAnnouncement5**
```json
{
	"eventname": "OnGameModeAnnouncement5"
}
```
- OnGameModeAnnouncement6 ```no information```
- OnGameModeAnnouncement7 ```no information```
- OnGameModeAnnouncement8 ```no information```
- OnGameModeAnnouncement9 ```no information```
- OnGameModeAnnouncement10 ```no information```
- OnGameModeAnnouncement11 ```no information```
- OnGameModeAnnouncement12 ```no information```
- OnGameModeAnnouncement13 ```no information```
- OnGameModeAnnouncement14 ```no information```
- OnGameModeAnnouncement15 ```no information```
- OnGameModeAnnouncement16 ```no information```
- OnReplayFastForwardStart ```no information```
- OnReplayFastForwardEnd ```no information```
- OnReplayOnKeyframeFinished ```no information```
- OnReplayDestroyAllObjects ```no information```
- OnKillDragon ```no information```
- **OnKillDragon_Spectator**
```json
Exemple 1 :
{
	"eventname": "OnKillDragon_Spectator",
	"other": "SRU_Dragon_Fire",
	"otherTeam": "Neutral",
	"source": "Pou Lord",
	"sourceID": "6",
	"sourceTeam": "Chaos"
}
Exemple 2 :
{
	"eventname": "OnKillDragon_Spectator",
	"other": "SRU_Dragon_Air",
	"otherTeam": "Neutral",
	"source": "DO U KNO DA WAE",
	"sourceID": "5",
	"sourceTeam": "Chaos"
}
Exemple 3 :
{
	"eventname": "OnKillDragon_Spectator",
	"other": "SRU_Dragon_Hextech",
	"otherTeam": "Neutral",
	"source": "Simp Eboy",
	"sourceID": "1",
	"sourceTeam": "Order"
}

```
- **OnKillDragonSteal**
```json
{
	"eventname": "OnKillDragonSteal",
	"other": "SRU_Dragon_Hextech",
	"otherTeam": "Neutral",
	"source": "Simp Eboy",
	"sourceID": "1",
	"sourceTeam": "Order"
}
```
- OnKillRiftHerald ```no information```
- OnKillRiftHerald_Spectator ```no information```
- OnKillRiftHeraldSteal ```no information```
- **OnSummonRiftHerald**
```json
{
	"eventname": "OnSummonRiftHerald",
	"other": "RiftHeraldMercenary",
	"otherTeam": "Order",
	"source": "Simp Eboy",
	"sourceID": "1",
	"sourceTeam": "Order"
}
```
- OnKillWorm ```no information```
- **OnKillWorm_Spectator**
```json
{
	"eventname": "OnKillWorm_Spectator",
	"other": "SRU_Baron12.1.1",
	"otherTeam": "Neutral",
	"source": "Simp Eboy",
	"sourceID": "1",
	"sourceTeam": "Order"
}
```
- OnKillWormSteal
- OnKillSpiderBoss ```no information```
- OnKillSpiderBoss_Spectator ```no information```
- OnCaptureAltar ```no information```
- OnCaptureAltar_Spectator ```no information```
- OnPlaceWard ```no information```
- **OnKillWard**
```json
Exemple 1 :
{
	"eventname": "OnKillWard",
	"other": "SightWard",
	"otherTeam": "Order",
	"source": "DO U KNO DA WAE",
	"sourceID": "5",
	"sourceTeam": "Chaos"
}
Exemple 2 :
{
	"eventname": "OnKillWard",
	"other": "JammerDevice",
	"otherTeam": "Chaos",
	"source": "WilsonMagicWand",
	"sourceID": "0",
	"sourceTeam": "Order"
}
```
- OnMinionAscended  ```no information```
- OnChampionAscended  ```no information```
- OnClearAscended  ```no information```
- **OnGameStatEvent**
```json
{
	"eventname": "OnGameStatEvent",
	"other": "100M girls Dream",
	"otherID": "9",
	"otherTeam": "Chaos"
}
```
- OnRelativeTeamColorChange ```no information```
- OnMapSkinSwap ```no information```
- OnResetGame ```no information```
- OnResetGameCompleted ```no information```
- **OnShutdown**
```json
Exemple 1 :
{
	"eventname": "OnShutdown",
	"other": "Simp Eboy",
	"otherID": "1",
	"otherTeam": "Order",
	"source": "Osman Üstüner",
	"sourceID": "7",
	"sourceTeam": "Chaos"
}
Exemple 2 :
{
	"eventname": "OnShutdown",
	"other": "Le JOAT",
	"otherID": "8",
	"otherTeam": "Chaos",
	"source": "WilsonMagicWand",
	"sourceID": "0",
	"sourceTeam": "Order"
}
```
- OnMute ```no information```
- OnChampionTransformNone ```no information```
- OnChampionTransformAssassin ```no information```
- OnChampionTransformSlayer ```no information```
- **OnReceiveShield**
```json
Exemple 1 :
{
	"eventname": "OnReceiveShield",
	"source": "100M girls Dream",
	"sourceID": "9",
	"sourceTeam": "Chaos"
}
Exemple 2 :
{
	"eventname": "OnReceiveShield",
	"source": "Sru_Crab15.1.1",
	"sourceTeam": "Neutral"
}
Exemple 3 :
{
	"eventname": "OnReceiveShield",
	"source": "Sru_Crab16.1.1",
	"sourceTeam": "Neutral"
}
Exemple 4 :
{
	"eventname": "OnReceiveShield",
	"source": "WilsonMagicWand",
	"sourceID": "0",
	"sourceTeam": "Order"
}
```
- **OnGrantShield**
```json
Exemple 1 :
{
	"eventname": "OnGrantShield",
	"source": "HuSaw",
	"sourceID": "3",
	"sourceTeam": "Order"
}
Exemple 2 :
{
	"eventname": "OnGrantShield",
	"source": "Osman Üstüner",
	"sourceID": "7",
	"sourceTeam": "Chaos"
}
Exemple 3 :
{
	"eventname": "OnGrantShield",
	"source": "Sru_Crab15.1.1",
	"sourceTeam": "Neutral"
}
Exemple 4 :
{
	"eventname": "OnGrantShield",
	"source": "Sru_Crab16.1.1",
	"sourceTeam": "Neutral"
}
```
- OnDamageShielded ```no information```
- OnMaterialOverride ```no information```
- OnObjectiveStolen ```no information```
- OnObjectiveTaken ```no information```
- OnNextDragonQueued ```no information```
- OnGearChanged ```no information```
- **OnSummonerEmotePlayed**
```json
Exemple 1 :
{
	"eventname": "OnSummonerEmotePlayed",
	"source": "Phenix NemBot",
	"sourceID": "4",
	"sourceTeam": "Order"
}
Exemple 2 :
{
	"eventname": "OnSummonerEmotePlayed",
	"source": "Pou Lord",
	"sourceID": "6",
	"sourceTeam": "Chaos"
}
```
- OnSummonerEmoteEnd ```no information```
- OnCustomStatStoneEvent ```no information```
- **OnStatStoneMilestoneHitEvent**
```json
{
	"eventname": "OnStatStoneMilestoneHitEvent"
}
```
- **OnEnterStealth**
```json
Exemple 1 :
{
	"eventname": "OnEnterStealth",
	"other": "VisionWard",
	"otherTeam": "Chaos",
	"source": "VisionWard",
	"sourceTeam": "Chaos"
}
Exemple 2 :
{
	"eventname": "OnEnterStealth",
	"other": "VisionWard",
	"otherTeam": "Order",
	"source": "VisionWard",
	"sourceTeam": "Order"
}
Exemple 3 :
{
	"eventname": "OnEnterStealth",
	"other": "SightWard",
	"otherTeam": "Order",
	"source": "SightWard",
	"sourceTeam": "Order"
}
Exemple 4 :
{
	"eventname": "OnEnterStealth",
	"other": "SightWard",
	"otherTeam": "Chaos",
	"source": "SightWard",
	"sourceTeam": "Chaos"
}
Exemple 5 :
{
	"eventname": "OnEnterStealth",
	"other": "HuSaw",
	"otherID": "3",
	"otherTeam": "Order",
	"source": "HuSaw",
	"sourceID": "3",
	"sourceTeam": "Order"
}
```
- **OnExitStealth**
```json
Exemple 1 :
{
	"eventname": "OnExitStealth",
	"other": "SightWard",
	"otherTeam": "Order",
	"source": "SightWard",
	"sourceTeam": "Order"
}
Exemple 2 :
{
	"eventname": "OnExitStealth",
	"other": "SightWard",
	"otherTeam": "Chaos",
	"source": "SightWard",
	"sourceTeam": "Chaos"
}
Exemple 3 :
{
	"eventname": "OnExitStealth",
	"other": "VisionWard",
	"otherTeam": "Chaos",
	"source": "VisionWard",
	"sourceTeam": "Chaos"
}
Exemple 4 :
{
	"eventname": "OnExitStealth",
	"other": "VisionWard",
	"otherTeam": "Order",
	"source": "VisionWard",
	"sourceTeam": "Order"
}
```
- OnPetSpawned ```no information```
- OnLifeSteal ```no information```
- OnSpellVamp ```no information```
- OnLocalPlayerLoadoutBound ```no information```
- **OnTurretPlateDestroyed**
```json
Exemple 1 :
{
	"eventname": "OnTurretPlateDestroyed",
	"other": "Turret_T1_C_05_A",
	"otherTeam": "Order",
	"source": "Turret_T1_C_05_A",
	"sourceTeam": "Order"
}
Exemple 2 :
{
	"eventname": "OnTurretPlateDestroyed",
	"other": "Turret_T1_R_03_A",
	"otherTeam": "Order",
	"source": "Turret_T1_R_03_A",
	"sourceTeam": "Order"
}
Exemple 3 :
{
	"eventname": "OnTurretPlateDestroyed",
	"other": "Turret_T2_L_03_A",
	"otherTeam": "Chaos",
	"source": "Turret_T2_L_03_A",
	"sourceTeam": "Chaos"
}
```
- OnPlantActivated ```no information```
- OnEnterPlayerVisibility ```no information```
- OnDragonSoulGiven ```no information```
- OnDisconnect ```no information```
- OnConnect ```no information```

## Spectator Visuel

- ```ctrl + maj + w``` for change max zoom of map
- ```x``` for total gold
- 