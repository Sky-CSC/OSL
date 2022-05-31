# Welcome to the **client** documentation.

> [!WARNING] 
> **Documentation in progress** 

---
## Enable data collection
### <ins>Game Client API :
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

---

## Spectator Visuel

- ```ctrl + maj + w``` for change max zoom of map
- ```x``` for total gold
- 

---

## Futures Features
- ### Chek if riot app are **launch**, **close**, **crash**

- ### Send if game is launch
  - Creation
  - Ban/Pick
    - Champ selected
    - Champ pick
    - Champ ban
    - Runes 
    - Summoners
    - Skins (Champ)
    - Timer (ban/select/waiting)

- ### Send if game is in progress
  - Herald (buff, timer, launch or not, take or not)
  - Nash (buff, timer, all champ dead, gold diff, damege diff, next nash)
  - Information gold / dega in fight
  - Drakes (Kill, next, soul)
  - Helder Drakes (Timer, buff, all champ kill, gold diff, damege diff, next helder drake)
  - Items buy
  - Runes
  - End game

- ### Send if end game
  - Dega
  - gold
  - objectif
