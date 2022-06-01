# **Client** Documentation

---

> [!CAUTION] 
> **Documentation in progress** 

---

## Enable data collection
### <ins>**Game Client API :**
[Game Client API](https://developer.riotgames.com/docs/lol#league-client-api)
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

### <ins>**Live Events API :**
[Live Events API](https://github.com/SkinSpotlights/LiveEventsDocumentation) For recive data from a game add to ```C:/Riot Games/League of Legends/Config/game.cfg```

```
[LiveEvents]
Enable=1
Port=34243
```
Next in ```C:/Riot Games/League of Legends/Config/``` create file ```LiveEvents.ini``` and copy on it
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

---

## Spectator Visuel

- ```ctrl + maj + w``` for change max zoom of map
- ```x``` for total gold
- 

---

## Features
- Chek if riot app are **launch**, **close**, **crash**
- Send information to the server if it is during ChampSelect
- Send information to the server if game is in Progress
- Sends information to the server if the game is finished
