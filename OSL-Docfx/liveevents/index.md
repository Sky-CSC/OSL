# **OSL-LiveEvents** Documentation

---

> [!CAUTION] 
> **Documentation in progress** 

---

## **OSL-LiveEvents** is a library for interacting with events in League of Legends game.

> [!CAUTION] 
>This documentation is for **Replay** or **Spectator** mode in Summoner's Rift.
>It may work in other modes, but this has not been tested.
><a href="../client/index.md">See this documentation for enable LiveEvents</a>

If "<span style="color:red">**LiveEventsName**</span> ``no information``" is indicated, the data may exist but have not been indexed.

If "<span style="color:green">**LiveEventsName**</span> ``Brief explanation``" is indicated, data exist, but not all cases are necessarily listed.

> [!TIP]
>**Last update : 26/07/2023**

## **Patern** :

```json
"eventname": "string",
"other": "string?", //Possible to be null
"otherID": "string?", //Possible to be null
"otherTeam": "string?", //Possible to be null
"source": "string?", //Possible to be null
"sourceID": "string?", //Possible to be null
"sourceTeam": "string?" //Possible to be null
```

- **"eventname"**: Name of the event
- **"other"** : Name of the summoner, turret or mobs (minion, neutral mobs, drake, nash, ...) in game he is impacted by the action
- **"otherID"** : Id of the summoner in game he make the action (0 to 9) if is not a summoner not display
- **"otherTeam"** : Name of the team (Chaos, Order, Neutral)
- **"source"**: Name of the summoner, turret or mobs (minion, neutral mobs, drake, nash, ...) in game he make the action
- **"sourceID"**: Id of the summoner in game he make the action (0 to 9) if is not a summoner not display
- **"sourceTeam"**: Name of the team (Chaos, Order, Neutral)

<br>

## **Data**

<span style="color:red">OnDelete</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpawn</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnDie</span> ``When a unit or target dies (Order, Chaos or Neutral) ``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnKill</span> ``When a unit or objectif is killed (Order, Chaos or Neutral) ``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnChampionDie</span> ``When a champion dies``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnChampionLevelUp</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnChampionKillPre</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnChampionKill</span> ``When a champion is killed``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnChampionKillPost</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnChampionSingleKill</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnChampionDoubleKill</span> ``When a player make a double kill``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnChampionTripleKill</span> ``When a player make a triple kill``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnChampionQuadraKill</span> ``When a player make a quadra kill``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnChampionPentaKill</span> ``When a player make a penta kill``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnChampionUnrealKill</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnFirstBlood</span> ``When a player make the first blood``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnFirstBloodAssist</span> ``When a player make a assist on first blood``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnDamageTaken</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnDamageGiven</span> When a unit or objectif give damage (Order, Chaos or Neutral)
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpellCast1</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpellCast2</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpellCast3</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpellCast4</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpellAvatarCast1</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpellAvatarCast2</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGoldSpent</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGoldEarned</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnItemConsumeablePurchased</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCriticalStrike</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnAce</span> ``When a team make a ace``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnReincarnate</span> ``When a champion come back to life``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnReviveAlly</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnChangeChampion</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnResetChampion</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnDampenerKill</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnDampenerDie</span> ``When a inhibitor dies``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnDampenerRespawnSoon</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnDampenerRespawn</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnDampenerDamage</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnTurretKill</span> ``When a tower is killed``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnTurretDie</span> ``When a tower is dies``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnTurretDamage</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnTurretFirstBlood</span> ``When a tower make the first blood``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnStructureKill</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnMinionKill</span> ``When a minion is killed``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnNeutralMinionKill</span> ``When a neutral unit is killed``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnNeutralMinionCampCleared</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnAcquireRedBuffFromNeutral</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnAcquireBlueBuffFromNeutral</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnHQKill</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnHQDie</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnHQDamage</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnCastHeal</span> ``When a champion cast a heal``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnBuff</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCrowdControlDealt</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCrowdControlExpired</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKillingSpree</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKillingSpreeSet1</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKillingSpreeSet2</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKillingSpreeSet3</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKillingSpreeSet4</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKillingSpreeSet5</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKillingSpreeSet6</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKilledUnitOnKillingSpree</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKilledUnitOnKillingSpreSet1</span> ```n information```
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKilledUnitOnKillingSpreSet2</span> ```n information```
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKilledUnitOnKillingSpreSet3</span> ```n information```
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKilledUnitOnKillingSpreSet4</span> ```n information```
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKilledUnitOnKillingSpreSet5</span> ```n information```
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKilledUnitOnKillingSpreSet6</span> ```n information```
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKilledUnitOnKillingSpreeDoublKill</span> ```n    ormation```
<details>
<summary><b>Example value</></summary>

```json

```
</details>
<br>

<span style="color:red">OnKilledUnitOnKillingSpreeTriplKill</span> ```n    ormation```
<details>
<summary><b>Example value</></summary>

```json


```
</details>
<br>

<span style="color:red">OnKilledUnitOnKillingSpreeQuadrKill</span> ```n    ormation```
<details>
   <summary><b>Example value</></summary>

```json

```
</details>
<br>

<span style="color:red">OnKilledUnitOnKillingSpreePentKill</span> ```n ormation```
<details>
   <summary><b>Example value</></summary>

```json

```
</details>
<br>

<span style="color:red">OnKilledUnitOnKillingSpreeUnreaKill</span> ```n    ormation```
<details>
   <summary><b>Example value</></summary>

```json

```
</details>
<br>

<span style="color:green">OnDeathAssist</span> ``When a player make an kill assist``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnQuit</span> ``When a player quit the game``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnLeave</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnReconnect</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameEnter</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameStart</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnAssistingSpreeSet1</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnAssistingSpreeSet2</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnChampionTripleAssist</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnChampionPentaAssist</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnPing</span> ``When a player ping``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnPingPlayer</span> ``When a player ping a player``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnPingBuilding</span> ``When a player ping a building``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnPingOther</span> ``When a player ping``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnEndGame</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpellLevelup1</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpellLevelup2</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpellLevelup3</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpellLevelup4</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpellEvolve1</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpellEvolve2</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpellEvolve3</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpellEvolve4</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnItemPurchased</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnItemSold</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnItemRemoved</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnItemUndo</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnItemCallout</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnItemChange</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnUndoEnabledChange</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnShopItemSubstitutionChange</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnShopMenuOpen</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnShopMenuClose</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSurrenderVoteStart</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSurrenderVote</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSurrenderVoteAlready</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSurrenderFailedVotes</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSurrenderTooEarly</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSurrenderAgreed</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSurrenderSpam</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnNormalAfkSurrenderAllowed</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSurrenderEarlyAllowed</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSurrenderEarlyAccomplice</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSurrenderEarlyOver</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSurrenderEarlyFailed</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSurrenderEarlyFailedNoLongerAvaiable</span> ```n ormation```
<details>
   <summary><b>Example value</></summary>
json
	{
}
	```
</details>
<br>

<span style="color:red">OnSurrenderEarlyFailedDisbled</span> ```n information```
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSurrenderEarlyTooEarly</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSurrenderEarlyFailedNeverAvaiable</span> ```n    ormation```
<details>
   <summary><b>Example value</></summary>
json
	{
}
	```
</details>
<br>

<span style="color:red">OnEarlySurrenderVoteStart</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnUnanimousSurrenderVoteStart</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnUnanimousSurrenderFailedotes</span> ```n information```
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnUnanimousAfkSurrenderAlowed</span> ```n information```
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnPause</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnPauseResume</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnMinionsSpawn</span> ``When minion spown att the start``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnStartGameMessage1</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnStartGameMessage2</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnStartGameMessage3</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnStartGameMessage4</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnStartGameMessage5</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnAlert</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnAudioEventFinished</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnNexusCrystalStart</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCapturePointNeutralized_A</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCapturePointNeutralized_B</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCapturePointNeutralized_C</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCapturePointNeutralized_D</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCapturePointNeutralized_E</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCapturePointCaptured_A</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCapturePointCaptured_B</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCapturePointCaptured_C</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCapturePointCaptured_D</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCapturePointCaptured_E</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCapturePointFiveCap</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnVictoryPointThreshold1</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnVictoryPointThreshold2</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnVictoryPointThreshold3</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnVictoryPointThreshold4</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement1</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement2</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement3</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement4</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement5</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement6</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement7</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement8</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement9</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement10</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement11</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement12</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement13</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement14</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement15</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameModeAnnouncement16</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnReplayFastForwardStart</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnReplayFastForwardEnd</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnReplayOnKeyframeFinished</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnReplayDestroyAllObjects</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKillDragon</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnKillDragon_Spectator</span> ``When a dragon are killed``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnKillDragonSteal</span> ``When a dragon are steal by opponents``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKillRiftHerald</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKillRiftHerald_Spectator</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKillRiftHeraldSteal</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnSummonRiftHerald</span> ``When herald are launched``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKillWorm</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnKillWorm_Spectator</span> ``When baron are killed``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKillWormSteal</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKillSpiderBoss</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnKillSpiderBoss_Spectator</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCaptureAltar</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCaptureAltar_Spectator</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnPlaceWard</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnKillWard</span> ``When ward are killed``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnMinionAscended</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnChampionAscended</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnClearAscended</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGameStatEvent</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnRelativeTeamColorChange</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnMapSkinSwap</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnResetGame</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnResetGameCompleted</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnShutdown</span> ``When a player make a shutdown``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnMute</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnChampionTransformNone</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnChampionTransformAssassin</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnChampionTransformSlayer</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnReceiveShield</span> ``When a player receive a shield``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGrantShield</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnDamageShielded</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnMaterialOverride</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnObjectiveStolen</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnObjectiveTaken</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnNextDragonQueued</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnGearChanged</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSummonerEmotePlayed</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSummonerEmoteEnd</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnCustomStatStoneEvent</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnStatStoneMilestoneHitEvent</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnEnterStealth</span> ``When a player enters a vision zone``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnExitStealth</span> `When a player exit a vision zone``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnPetSpawned</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnLifeSteal</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnSpellVamp</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnLocalPlayerLoadoutBound</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:green">OnTurretPlateDestroyed</span> ``When a rower plate are destroyed``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnPlantActivated</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnEnterPlayerVisibility</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnDragonSoulGiven</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnDisconnect</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>

<span style="color:red">OnConnect</span> ``no information``
<details>
<summary><b>Example value</b></summary>

```json

```
</details>
<br>