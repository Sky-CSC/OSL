# Developper Documentation **Client**

---

> [!CAUTION] 
> **Documentation in progress** 

---

## **API/Tools used :**
### <ins>**Game Client API :**
[Game Client API](https://developer.riotgames.com/docs/lol#league-client-api)
For recive data from a game add to `C:/Riot Games/League of Legends/Config/game.cfg`
```
[General]
EnableReplayApi=1
```

add to ```C:/Riot Games/League of Legends/Config/game.cfg``` for see a more graphic timer for dragon and baron  
```
[Spectator]
eSportsNeutralTimers=1
```

### <ins>**Live Events API :**
[Live Events API](https://github.com/SkinSpotlights/LiveEventsDocumentation) is a undocumentated API part of League of Legends that can be enabled via a config and a list of events that you wish to receive updates for. The API is only available in Spectator/Replays.
[See personal documentation](#documentation-of-live-events-api)

To enable the API you need to navigate to the ```Riot Games\League of Legends\Config\``` folder and edit the game.cfg then add the following
```
[LiveEvents]
Enable=1
Port=34243
```
Next in ```Riot Games\League of Legends\Config\``` create file LiveEvents.ini and copy
```
OnKill
OnKillDragon_Spectator
OnNeutralMinionKill
OnMinionKill
OnSummonRiftHerald
OnKillWorm_Spectator
OnTurretDie
OnMinionKill
OnChampionKill
```

### <ins>**Read in Memory :**
Use of the application code [LeagueBroadcast](https://github.com/floh22/LeagueBroadcast)

<br><br>

---

## <ins>Local game information "ChampSelect"

When we are in champ select this information are send att server if he change.
<br>This data are recive by :
```
https://localhost:port/lol-champ-select/v1/session
```
<details>
<summary><b>Example value</b></summary>

```json
{
  "actions": [
    {
      "additionalProp1": {}
    }
  ],
  "allowBattleBoost": true,
  "allowDuplicatePicks": true,
  "allowLockedEvents": true,
  "allowRerolling": true,
  "allowSkinSelection": true,
  "bans": {
    "myTeamBans": [
      0
    ],
    "numBans": 0,
    "theirTeamBans": [
      0
    ]
  },
  "benchChampionIds": [
    0
  ],
  "benchEnabled": true,
  "boostableSkinCount": 0,
  "chatDetails": {
    "chatRoomName": "string",
    "chatRoomPassword": "string"
  },
  "counter": 0,
  "entitledFeatureState": {
    "additionalRerolls": 0,
    "unlockedSkinIds": [
      0
    ]
  },
  "gameId": 0,
  "hasSimultaneousBans": true,
  "hasSimultaneousPicks": true,
  "isCustomGame": true,
  "isSpectating": true,
  "localPlayerCellId": 0,
  "lockedEventIndex": 0,
  "myTeam": [
    {
      "assignedPosition": "string",
      "cellId": 0,
      "championId": 0,
      "championPickIntent": 0,
      "entitledFeatureType": "string",
      "selectedSkinId": 0,
      "spell1Id": 0,
      "spell2Id": 0,
      "summonerId": 0,
      "team": 0,
      "wardSkinId": 0
    }
  ],
  "recoveryCounter": 0,
  "rerollsRemaining": 0,
  "skipChampionSelect": true,
  "theirTeam": [
    {
      "assignedPosition": "string",
      "cellId": 0,
      "championId": 0,
      "championPickIntent": 0,
      "entitledFeatureType": "string",
      "selectedSkinId": 0,
      "spell1Id": 0,
      "spell2Id": 0,
      "summonerId": 0,
      "team": 0,
      "wardSkinId": 0
    }
  ],
  "timer": {
    "adjustedTimeLeftInPhase": 0,
    "internalNowInEpochMs": 0,
    "isInfinite": true,
    "phase": "string",
    "totalTimeInPhase": 0
  },
  "trades": [
    {
      "cellId": 0,
      "id": 0,
      "state": "AVAILABLE"
    }
  ]
}
```

</details><br>

Download example of a curent ChampSelect **Not completed!!**
<br>[Ban phase](../misc/lol-champ-selectv1session-ExampleValue-1.json)
<br>[Pick Phase](../misc/lol-champ-selectv1session-ExampleValue-1.json)
<br>[End Phase](../misc/lol-champ-selectv1session-ExampleValue-1.json)

---

## <ins>**Local game information "InGame"**
This information about the game is sent to the server, it is retrieved by the different APIs.

## Drakes (Elder, Fire, Hextech, Air, Water, Chemtech, Earth) **Check Data !!**

```diff
- Live Events API :
OnKillDragon_Spectator (default)
OnKill
OnNeutralMinionKill	
```

<details>
	<summary><b>Example value</b></summary>

```json
{
	"eventname": "OnKillDragon_Spectator",
	"other": "SRU_Dragon_Elder",
	"otherTeam": "Neutral",
	"source": "Sky csc",
	"sourceID": "6",
	"sourceTeam": "Chaos"
}
or
{
	"eventname": "OnKillDragon_Spectator",
	"other": "SRU_Dragon_Fire",
	"otherTeam": "Neutral",
	"source": "Sky csc",
	"sourceID": "6",
	"sourceTeam": "Chaos"
}
or
{
	"eventname": "OnKillDragon_Spectator",
	"other": "SRU_Dragon_Hextech",
	"otherTeam": "Neutral",
	"source": "Sky csc",
	"sourceID": "1",
	"sourceTeam": "Order"
}
or
{
	"eventname": "OnKillDragon_Spectator",
	"other": "SRU_Dragon_Air",
	"otherTeam": "Neutral",
	"source": "Sky csc",
	"sourceID": "5",
	"sourceTeam": "Chaos"
}
or
{
	"eventname": "OnKillDragon_Spectator",
	"other": "SRU_Dragon_Water",
	"otherTeam": "Neutral",
	"source": "Sky csc",
	"sourceID": "5",
	"sourceTeam": "Chaos"
}
or
{
	"eventname": "OnKillDragon_Spectator",
	"other": "SRU_Dragon_Chemtech",
	"otherTeam": "Neutral",
	"source": "Sky csc",
	"sourceID": "5",
	"sourceTeam": "Chaos"
}
or
{
	"eventname": "OnKillDragon_Spectator",
	"other": "SRU_Dragon_Earth",
	"otherTeam": "Neutral",
	"source": "Sky csc",
	"sourceID": "5",
	"sourceTeam": "Chaos"
}
```
</details>

## Baron

```diff
- Live Events API :
OnKillWorm_Spectator (default)
OnKill
OnNeutralMinionKill
```

<details>
<summary><b>Example value</b></summary>

```json
{
	"eventname": "OnKillWorm_Spectator",
	"other": "SRU_Baron12.1.1",
	"otherTeam": "Neutral",
	"source": "Sky csc",
	"sourceID": "1",
	"sourceTeam": "Order"
}
```
</details>

## Herald
- Kill
    ```diff
    - Live Events API :
    OnNeutralMinionKill (default)
    OnKill
    ```
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
	  "eventname": "OnNeutralMinionKill",
	  "other": "SRU_RiftHerald17.1.1",
	  "otherTeam": "Neutral",
	  "source": "Sky csc",
	  "sourceID": "1",
	  "sourceTeam": "Order"
    }
	```
	</detail>
    	
- Take Relic :
    ```diff
    - Live Events API :
    OnMinionKill (default)	
	OnKill
	```
	<details>
    <summary><b>Example value</b></summary>

	```json
    {
	  "eventname": "OnMinionKill",
	  "other": "Rift Herald Relic",
	  "otherTeam": "Order",
	  "source": "SRU_RiftHerald17.1.1",
	  "sourceTeam": "Neutral"
    }
	```
	</detail>

- Launch :
    ```diff
    - Live Events API :	
	OnSummonRiftHerald (default)	
    ```
	<details>
    <summary><b>Example value</b></summary>

	```json
	{
	"eventname": "OnSummonRiftHerald",
	"other": "RiftHeraldMercenary",
	"otherTeam": "Order",
	"source": "Sky csc",
	"sourceID": "1",
	"sourceTeam": "Order"
	}
	```
	</detail>
<br>

## Turret
```diff
- Live Events API :
OnTurretDie (default)
- Game Client API :
https://127.0.0.1:2999/liveclientdata/allgamedata
```
<details>
<summary><b>Example value</b></summary>

```json
{
	"eventname": "OnTurretDie",
	"other": "Sky csc",
	"otherID": "0",
	"otherTeam": "Order",
	"source": "Turret_T2_R_03_A",
	"sourceTeam": "Chaos"
}
or
{
	"eventname": "OnTurretDie",
	"other": "Minion_T200L2S26N0162",
	"otherTeam": "Chaos",
	"source": "Turret_T1_L_03_A",
	"sourceTeam": "Order"
}
or
{
	"eventname": "OnTurretDie",
	"other": "Sky csc",
	"otherID": "7",
	"otherTeam": "Chaos",
	"source": "Turret_T1_R_02_A",
	"sourceTeam": "Order"
}
```
</details>

## Inib **Check Data !!**

```diff
- Game Client API :
https://127.0.0.1:2999/liveclientdata/allgamedata (default)
- Live Events API :
OnDampenerDie
```
<details>
<summary><b>Example value</b></summary>

```json
{

}
```
</details>

## Minion **Check Data !!**
```diff
- Live Events API :
OnMinionKill (default)
OnKill (default for "HiddenMinion")
```
<details>
<summary><b>Example value</b></summary>

```json
{

}
```
</details>
<br>

## Summoner Kill **Check Data !!**
```diff
- Live Events API :
OnChampionKill (default)
OnDeathAssist (default)
OnShutdown
OnChampionKillPre
OnKill
- Game Client API :
https://127.0.0.1:2999/liveclientdata/playerlist
```
<details>
<summary><b>Example value</b></summary>

```json
{

}
```
</details>

## Item **Check Data !!**
```diff
- Game Client API :
https://127.0.0.1:2999/liveclientdata/playerlist
https://127.0.0.1:2999/liveclientdata/playeritems?summonerName=Phenix%20NemBot
```
<details>
<summary><b>Example value</b></summary>

```json
{

}
```
</details>

## Ward **Check Data !!**
```diff
- Game Client API :
https://127.0.0.1:2999/liveclientdata/playerlist
```
<details>
<summary><b>Example value</b></summary>

```json
{

}
```
</details>

## Summoners Spell **Check Data !!**
```diff
- Game Client API :
https://127.0.0.1:2999/liveclientdata/playerlist
```
<details>
<summary><b>Example value</b></summary>

```json
{

}
```
</details>

## Level Up **Check Data !!**
```diff 
- Game Client API :
https://127.0.0.1:2999/liveclientdata/playerlist
```
<details>
<summary><b>Example value</b></summary>

```json
{

}
```
</details>

## Position
  ```diff
  - Read in memory
  ```
## Mana
  ```diff
  - Read in memory
  ```
## MaxMana
  ```diff
  - Read in memory
  ```
## Health
  ```diff
  - Read in memory
  ```
## MaxHealth
  ```diff
  - Read in memory
  ```
## CurrentGold
  ```diff
  - Read in memory
  ```
## GoldTotal
  ```diff
  - Read in memory
  ```
## EXP
  ```diff
  - Read in memory
  ```

## Damages
  ```diff
  - Unknown
  ```

---

<ins> 

## Documentation of **Live Events API**
</ins>

This documentation concern just **Replay** or **Spectator** mode
If he is note ```no information``` he is possible he exist in other game mode or I juts don't found it in a spécific game

## Patern :

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

## All the information :

- <span style="color:red">**OnDelete**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnDelete"
	}
	```
	</details>

- OnSpawn ```no information```

- <span style="color:red">**OnDie**</span>
	<details>
	<summary><b>Example value</b></summary>
	
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
		"other": "Osman �st�ner",
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
	</detail>

- <span style="color:red">**OnKill**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	.... beaucoup
	```
	</details>

- <span style="color:red">**OnChampionDie**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- OnChampionLevelUp ```no information```

- <span style="color:red">**OnChampionKillPre**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- <span style="color:red">**OnChampionKill**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- OnChampionKillPost ```no information```

- OnChampionSingleKill ```no information but possible exist```

- <span style="color:red">**OnChampionDoubleKill**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- <span style="color:red">**OnChampionTripleKill**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	Exempel 1:
	{
		"eventname": "OnChampionTripleKill",
		"other": "Osman �st�ner",
		"otherID": "7",
		"otherTeam": "Chaos",
		"source": "Simp Eboy",
		"sourceID": "1",
		"sourceTeam": "Order"
	}
	```
	</details>

- OnChampionQuadraKill ```no information but possible exist```

- OnChampionPentaKill ```no information but possible exist```

- OnChampionUnrealKill ```no information but possible exist```

- <span style="color:red">**OnFirstBlood**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- <span style="color:red">**OnFirstBloodAssist**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnFirstBloodAssist",
		"source": "NameSummoner",
		"sourceID": "IdSummoner",
		"sourceTeam": "NameTeam"
	}
	```
	</details>

- OnDamageTaken ```no information```

- <span style="color:red">**OnDamageGiven**</span>
	<details>
	<summary><b>Example value</b></summary>

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
		"other": "Osman �st�ner",
		"otherID": "7",
		"otherTeam": "Chaos",
		"source": "ScrandHD",
		"sourceID": "2",
		"sourceTeam": "Order"
	}
	......
	```
	</details>

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

- <span style="color:red">**OnAce**</span> 
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- <span style="color:red">**OnReincarnate**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- OnReviveAlly ```no information BUT```

- <span style="color:red">**OnChangeChampion**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnChangeChampion"
	}
	```
	</details>

- OnResetChampion ```no information```

- OnDampenerKill ```no information```

- <span style="color:red">**OnDampenerDie**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- <span style="color:red">**OnDampenerRespawnSoon**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnDampenerRespawnSoon"
	}
	```
	</details>	

- <span style="color:red">**OnDampenerRespawn**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnDampenerRespawn"
	}
	```
	</details>

- OnDampenerDamage ```no information```

- OnTurretKill ```no information```

- <span style="color:red">**OnTurretDie**</span>
	<details>
	<summary><b>Example value</b></summary>

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
		"other": "Osman �st�ner",
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
	</details>

- OnTurretDamage ```no information```

- <span style="color:red">**OnTurretFirstBlood**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnTurretFirstBlood",
		"other": "Minion_T200L0S18N0111",
		"otherTeam": "Chaos",
		"source": "Turret_T1_R_03_A",
		"sourceTeam": "Order"
	}
	```
	</details>

- OnStructureKill ```no information```

- <span style="color:red">**OnMinionKill**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- <span style="color:red">**OnNeutralMinionKill**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- OnNeutralMinionCampCleared ```no information```

- OnAcquireRedBuffFromNeutral ```no information```

- OnAcquireBlueBuffFromNeutral ```no information```

- <span style="color:red">**OnHQKill**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnHQKill",
		"other": "WilsonMagicWand",
		"otherID": "0",
		"otherTeam": "Order"
	}
	```
	</details>

- OnHQDie ```no information```

- OnHQDamage ```no information```

- <span style="color:red">**OnCastHeal**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- OnBuff ```no information```

- OnCrowdControlDealt ```no information```

- OnCrowdControlExpired ```no information```

- <span style="color:red">**OnKillingSpree**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- <span style="color:red">**OnKillingSpreeSet1**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	Exemple 1 :
	{
		"eventname": "OnKillingSpreeSet1",
		"other": "Phenix NemBot",
		"otherID": "4",
		"otherTeam": "Order",
		"source": "Osman �st�ner",
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
	</details>

- <span style="color:red">**OnKillingSpreeSet2**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	Exemple 1 :
	{
		"eventname": "OnKillingSpreeSet2",
		"other": "Phenix NemBot",
		"otherID": "4",
		"otherTeam": "Order",
		"source": "Osman �st�ner",
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
	</details>

- <span style="color:red">**OnKillingSpreeSet3**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- <span style="color:red">**OnKillingSpreeSet4**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- <span style="color:red">**OnKillingSpreeSet5**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnKillingSpreeSet5",
		"other": "Osman �st�ner",
		"otherID": "7",
		"otherTeam": "Chaos",
		"source": "HuSaw",
		"sourceID": "3",
		"sourceTeam": "Order"
	}
	```
	</details>

- <span style="color:red">**OnKillingSpreeSet6**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

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

- <span style="color:red">**OnDeathAssist**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- <span style="color:red">**OnQuit**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnQuit",
		"source": "Le JOAT",
		"sourceID": "8",
		"sourceTeam": "Chaos"
	}
	```
	</details>

- OnLeave ```no information BUT```

- OnReconnect ```no information BUT```

- OnGameEnter ```no information```

- OnGameStart ```no information```

- OnAssistingSpreeSet1 ```no information```

- OnAssistingSpreeSet2 ```no information```

- OnChampionTripleAssist ```no information```

- OnChampionPentaAssist ```no information```

- <span style="color:red">**OnPing**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnPing"
	}
	```
	</details>

- <span style="color:red">**OnPingPlayer**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnPingPlayer"
	}
	```
	</details>

- <span style="color:red">**OnPingBuilding**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnPingBuilding"
	}
	```
	</details>

- <span style="color:red">**OnPingOther**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnPingOther"
	}
	```
	</details>

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

- <span style="color:red">**OnItemCallout**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- OnItemChange ```no information```

- OnUndoEnabledChange ```no information```

- OnShopItemSubstitutionChange ```no information```

- OnShopMenuOpen ```no information```

- OnShopMenuClose ```no information```

- OnSurrenderVoteStart ```no information```

- OnSurrenderVote ```no information```

- OnSurrenderVoteAlready ```no information```

- <span style="color:red">**OnSurrenderFailedVotes**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnSurrenderFailedVotes",
		"source": "DO U KNO DA WAE",
		"sourceID": "5",
		"sourceTeam": "Chaos"
	}
	```
	</details>

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

- <span style="color:red">**OnMinionsSpawn**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnMinionsSpawn"
	}
	```
	</details>

- <span style="color:red">**OnStartGameMessage1**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnStartGameMessage1"
	}
	```
	</details>

- <span style="color:red">**OnStartGameMessage2**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnStartGameMessage2"
	}
	```
	</details>

- OnStartGameMessage3 ```no information```

- OnStartGameMessage4 ```no information```

- OnStartGameMessage5 ```no information```

- OnAlert ```no information```

- OnAudioEventFinished ```no information```

- <span style="color:red">**OnNexusCrystalStart**</span>
	<details>
	<summary><b>Example value</b></summary>
	
	```json
	{
		"eventname": "OnNexusCrystalStart"
	}
	```
	</details>

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

- <span style="color:red">**OnGameModeAnnouncement5**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnGameModeAnnouncement5"
	}
	```
	</details>

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

- <span style="color:red">**OnKillDragon_Spectator**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- <span style="color:red">**OnKillDragonSteal**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- OnKillRiftHerald ```no information```

- OnKillRiftHerald_Spectator ```no information```

- OnKillRiftHeraldSteal ```no information```

- <span style="color:red">**OnSummonRiftHerald**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- OnKillWorm ```no information```

- <span style="color:red">**OnKillWorm_Spectator**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- OnKillWormSteal

- OnKillSpiderBoss ```no information```

- OnKillSpiderBoss_Spectator ```no information```

- OnCaptureAltar ```no information```

- OnCaptureAltar_Spectator ```no information```

- OnPlaceWard ```no information```

- <span style="color:red">**OnKillWard**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- OnMinionAscended  ```no information```

- OnChampionAscended  ```no information```

- OnClearAscended  ```no information```

- <span style="color:red">**OnGameStatEvent**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnGameStatEvent",
		"other": "100M girls Dream",
		"otherID": "9",
		"otherTeam": "Chaos"
	}
	```
	</details>

- OnRelativeTeamColorChange ```no information```

- OnMapSkinSwap ```no information```

- OnResetGame ```no information```

- OnResetGameCompleted ```no information```

- <span style="color:red">**OnShutdown**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	Exemple 1 :
	{
		"eventname": "OnShutdown",
		"other": "Simp Eboy",
		"otherID": "1",
		"otherTeam": "Order",
		"source": "Osman �st�ner",
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
	</details>

- OnMute ```no information```

- OnChampionTransformNone ```no information```

- OnChampionTransformAssassin ```no information```

- OnChampionTransformSlayer ```no information```

- <span style="color:red">**OnReceiveShield**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- <span style="color:red">**OnGrantShield**</span>
	<details>
	<summary><b>Example value</b></summary>

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
		"source": "Osman �st�ner",
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
	</details>

- OnDamageShielded ```no information```

- OnMaterialOverride ```no information```

- OnObjectiveStolen ```no information```

- OnObjectiveTaken ```no information```

- OnNextDragonQueued ```no information```

- OnGearChanged ```no information```

- <span style="color:red">**OnSummonerEmotePlayed**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- OnSummonerEmoteEnd ```no information```

- OnCustomStatStoneEvent ```no information```

- <span style="color:red">**OnStatStoneMilestoneHitEvent**</span>
	<details>
	<summary><b>Example value</b></summary>

	```json
	{
		"eventname": "OnStatStoneMilestoneHitEvent"
	}
	```
	</details>

- <span style="color:red">**OnEnterStealth**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- <span style="color:red">**OnExitStealth**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>

- OnPetSpawned ```no information```

- OnLifeSteal ```no information```

- OnSpellVamp ```no information```

- OnLocalPlayerLoadoutBound ```no information```

- <span style="color:red">**OnTurretPlateDestroyed**</span>
	<details>
	<summary><b>Example value</b></summary>

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
	</details>
	
- OnPlantActivated ```no information```

- OnEnterPlayerVisibility ```no information```

- OnDragonSoulGiven ```no information```

- OnDisconnect ```no information```

- OnConnect ```no information```

### Information in "eventname" that can be found 

- **Turret :**
	<details>
	<summary><b>Data</b></summary>
	
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
	</details>

- Inib ```Not information in game```

- **Dragons :**
	<details>
	<summary><b>Data</b></summary>

	```
	SRU_Dragon_Fire
	SRU_Dragon_Air
	SRU_Dragon_Hextech
	SRU_Dragon_Water
	SRU_Dragon_Earth
	SRU_Dragon_
	SRU_Dragon_Elder
	```
	</details>

- **Herald :**
	<details>
	<summary><b>Data</b></summary>

	```
	SRU_RiftHerald17.1.1
	Rift Herald Relic
	RiftHeraldMercenary
	```
	</details>

- **Baron :**
	<details>
	<summary><b>Data</b></summary>

	```
	SRU_BaronSpawn12.1.2
	SRU_Baron12.1.1
	```
	</details>

- Red
- Blue
- Wolf
- Gromp
- Crab
- Krug
- Razorbeak
- WardCorpse
- PlantVision