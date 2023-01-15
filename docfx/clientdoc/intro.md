# **Client** Documentation

---

> [!CAUTION] 
> **Documentation in progress** 

---
Download last release : [First Release v0.1.0-alpha](https://github.com/Sky-CSC/OSL/releases/tag/v0.1.0-alpha)

Not forget run ```OSL-Server.exe```, before run ```OSL-Client.exe```

```Configuration/configHost.json``` : Configuration of Live Events API port

```Configuration/configRiot.json``` : Name of windows process used by League of Legends

```Configuration/configServerSocketOSLServer.json``` : IP and Port of server 
- Default port : 45678
- IP : is the IP of computer where you run ```OSL-Server.exe```

You need just run ```OSL-Client.exe```, nothing more, make ```ctrl+c``` for close him.

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
- Send information to the server in :
  - **Champ Select** (champ select of the match is in progress)
  - **Waiting Game Start** (information while waiting for the game to start)
  - **In Game** (spectator game is in progress)
  - **End Game** (game is over)
