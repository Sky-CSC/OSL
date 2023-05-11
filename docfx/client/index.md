# **Client** Documentation

---

> [!CAUTION] 
> **Documentation in progress** 

---

## Run application
1. Download last release : [Release v1.1.0](https://github.com/Sky-CSC/OSL/releases/tag/v1.1.0)
2. Unzip ``OSL-Client-1.1.0-win-x64.zip`` to desired install folder
3. Change IP on ```server-socket.json```
4. > [!CAUTION] If you understand what you are doing, add this information in this file ```C:/Riot Games/League of Legends/Config/game.cfg```

```
[General]
EnableReplayApi=1

[Spectator]
eSportsNeutralTimers=1

[LiveEvents]
Enable=1
Port=34243
```
5. > [!CAUTION] If you understand what you are doing, create file ```C:/Riot Games/League of Legends/Config/LiveEvents.ini``` and copy on it
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

4. If you don't understand what you are doing download <a href="../misc/game.cfg" download>game.cfg</a>  and replace the file on ```C:/Riot Games/League of Legends/Config/game.cfg``` 
5. If you don't understand what you are doing download <a href="../misc/LiveEvents.ini" download>LiveEvents.ini</a>  and replace the file on ```C:/Riot Games/League of Legends/Config/LiveEvents.ini``` 
5. Run ```OSL-Web.exe```, after he is running run ```OSL-Client.exe``` (make ```ctrl+c``` for close him)


<br>

---

## Configuration

```Configuration/riot.json``` : Configuration of League of Legend and riot information for operation of application

  ```"leagueClientLiveEventsApiPort": 34243``` port used for Live Events API (Default)

  ```"leagueClientProcess": "LeagueClient"``` name of application (Default)

  ```"riotLogin": "riot"``` name of login used for LCU Api (Default)

  ```"riotPort": 2999``` port used for Replay API (Default)

<br>

```Configuration/server-socket.json``` : Configuration of socket server for send information

  ```"ip": "192.168.1.5"``` Ip of server (**change it** by ip of computer he run OSL-Web)

  ```"port": 45678``` Default port, if you don't change it on OSL-Web no change this value

<br>

---

## Features

Chek if riot app are **launch**

Read **lockfile**

Check **phases** (Lobby, ChampSelect, InProgress ...)

Information send to the server :
  - **Champ Select** (champ select of the match is in progress)
  - **In Game** (spectator game is in progress)
  - **End Game** (game is over)

**Champ Select** 
- */lol-champ-select/v1/session* (LCU api) 
- */lol-summoner/v1/summoners/* (LCU api)
- *summoners* name are write on *session* and sent in one go

**In Game**
- */lol-gameflow/v1/session* (LCU api)

**End Game**
- */lol-end-of-game/v1/eog-stats-block* (LCU api)