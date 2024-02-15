# **OSL : Overlay Spectator Live**
![work-in-progress](https://img.shields.io/badge/respos%20status-WIP-yellow)
[![GitHub Release](https://img.shields.io/github/release/Sky-csc/OSL)](https://github.com/Sky-csc/OSL/releases/latest)
[![Stargazers](https://img.shields.io/github/stars/Sky-csc/OSL)](https://github.com/Sky-csc/OSL/stargazers)
[![Issues](https://img.shields.io/github/issues/Sky-csc/OSL)](https://github.com/Sky-csc/OSL/issues)

![language](https://img.shields.io/badge/c%23-10.0-brightgreen)
![.Net-6.0](https://img.shields.io/badge/.NET-6.0-brightgreen)
![framework](https://img.shields.io/badge/framework-blazor-brightgreen)
![platform](https://img.shields.io/badge/platform-windows-brightgreen)

[![MIT Licensed](https://img.shields.io/github/license/Sky-csc/OSL)](https://github.com/Sky-CSC/OSL/blob/main/LICENSE)

![LoL1](https://img.shields.io/badge/Game%20Client%20API-League%20of%20Legends-blue)
![LoL2](https://img.shields.io/badge/Game%20Client%20Replay%20API-League%20of%20Legends-blue)
![LoL3](https://img.shields.io/badge/Live%20Events%20API-League%20of%20Legends-blue)
![LoL4](https://img.shields.io/badge/Memory%20Reader-League%20of%20Legends-blue)
![LoL4](https://img.shields.io/badge/LCU%20API-League%20of%20Legends-blue)
![riot1](https://img.shields.io/badge/Web%20API%20Riot-RIOT-blue)
![riot2](https://img.shields.io/badge/CDragon%20API-CDragon-blue)

This project allows you to display an overlay with additional information for your League of Legends games

Applications use various APIs to collect information about the game, champions, players, .....

# **Features**

**[Champ Select :](https://sky-csc.github.io/OSL/web/index.html#information-display-with-overlay-in-champ-select)**
- 4 view
- Champ ban/select
- Summoners names
- Team name
- Number of victory/lose teams
- Timer ban/select/waiting
- Summoners Spell

**[In Game :](https://sky-csc.github.io/OSL/web/index.html#information-display-with-overlay-in-game)**

[With riot overlay :](https://sky-csc.github.io/OSL/web/index.html#with-riot-overlay-)
- 4 view
- Team/Dragon/Baron/Elder frame
- Team name
- Number of victory/lose teams
- Frame for video/logo/player picture ...
- Items buy
- Dragon kill

**[End Game :](https://sky-csc.github.io/OSL/web/index.html#information-display-with-overlay-in-end-game)**
- 3 view
- Team name
- Team score
- Team win loose
- Général information : assists, barracks killed, champions killed, gold earned, largest critical strike, largest killing spree, largest multi kill, level, magic damage dealt player, magic damage dealt to champions, magic damage taken, minions killed, num deaths, physical damage dealt player, physical damage dealt to champions, physical damage taken, total damage dealt, total damage dealt to buildings, total damage dealt to champions, total damage dealt to objectives, total damage dealt to turrets, total damage self mitigated, total damage shielded on teammates, total damage taken, total heal, total heal on teammates, total time crowd control dealt, true damage dealt player, true damage dealt to champions, true damage taken, turrets killed, vision score, ward killed, ward placed
- Bans
- KDA/Gold/Tower/Dragon/Elder Dragon/Herald/Baron
- Gold Diff

**[Runes :](https://sky-csc.github.io/OSL/web/index.html#information-display-with-overlay-runes)**
- 7 view
- Top
- Jungle
- Mid
- Adc
- Support
- Adc and support
- All

# **Documentation**
Applications, riot api and installation documentation. **[Link documentation](https://sky-csc.github.io/OSL/)**

# **Getting Started**

**Installation**

Link to [OSL-Web installation](https://sky-csc.github.io/OSL/web/index.html) (Read the index web page when OSL-Web is launched)

Link to [OSL-Client installation](https://sky-csc.github.io/OSL/client/index.html)

A summary of the process to be followed :
1. Download [last release](https://github.com/Sky-CSC/OSL/releases/latest)
2. Unzip release to desired install folder
3. Run ```OSL-Web.exe```
4. Change the Web Riot Api key in the web interface configuration
[Riot Developer page (take your api key)](https://developer.riotgames.com/)
Login and copy past your "Development API Key" 
5. Get IP of your computer where ```OSL-Web.exe``` is running (windows+r, cmd, ipconfig, field IPv4) and copy this ip on ip field on ```OSL-CLient-vx.x.x/Configuration/server-socket.json```
6. If you understand what you are doing, add this information in this file ```C:/Riot Games/League of Legends/Config/game.cfg```
```
[General]
EnableReplayApi=1

[Spectator]
eSportsNeutralTimers=1

[LiveEvents]
Enable=1
Port=34243
```
7. If you understand what you are doing, create file ```C:/Riot Games/League of Legends/Config/LiveEvents.ini``` and copy on it
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
6. If you don't understand what you are doing download <a href="https://sky-csc.github.io/OSL/misc/game.cfg" download>game.cfg</a>  and replace the file on ```C:/Riot Games/League of Legends/Config/game.cfg``` 
7. If you don't understand what you are doing download <a href="https://sky-csc.github.io/OSL/misc/LiveEvents.ini" download>LiveEvents.ini</a>  and replace the file on ```C:/Riot Games/League of Legends/Config/LiveEvents.ini``` 
8. Run ```OSL-Client.exe``` on the computer where the spectator game is running
9. Add http://ip:4141/champselect/view1 and/or http://ip:4141/champselect/view2 and/or 
http://ip:4141/champselect/view3 and/or http://ip:4141/champselect/view4 as a browser source in OBS in your ban pick scene
10. Add http://ip:4141/ingame/view1 and/or http://ip:4141/ingame/view2 and/or http://ip:4141/ingame/view3 as a browser source in OBS in your in game scene
11. Add http://ip:4141/endgame/view1 and/or http://ip:4141/endgame/view2 and/or http://ip:4141/endgame/view3 as a browser source in OBS in your in game scene
12. Add http://ip:4141/runes/view1/top and http://ip:4141/runes/view1/jungle and http://ip:4141/runes/view1/mid and http://ip:4141/runes/view1/adc and http://ip:4141/runes/view1/supp and http://ip:4141/runes/view1/adcsupp and http://ip:4141/runes/view1/all as a browser source in OBS in your in game scene
13. Have fun

# **Roadmap**
**2.0.0** version are planned for April 2024 (end Q1 beginning Q2)

### **OSL-CDragon**
- Refactoring code (planned for 2.0.0)
- Fix bugs, download and display errors (planned for 2.0.0)
- No other features planned yet

### **OSL-Client**
- Refactoring code (planned for 2.0.0)
- No other features planned yet

### **OSL-Common**
- Refactoring code (planned for 2.0.0)
- No other features planned yet

### **OSL-Docfx**
- Write and enhanced documentation for 2.0.0

### **OSL-LcuApi**
- Refactoring code (planned for 2.0.0)
- Cover all LcuApi request (not planned yet)

### **OSL-LiveEvents**
- Refactoring code (planned for 2.0.0)
- No other features planned yet

### **OSL-ReplayApi**
- Refactoring code (planned for 2.0.0)
- Cover all ReplayApi request (not planned yet)

### **OSL-Web**
- Refactoring code (planned for 2.0.0)
- Enhanced web interface (planned for 2.0.0)

- **CDragon**
    - Manuel download patch and language (planned for 2.0.0)
    - Manual select patch and language (planned for 2.0.0)
    - Enhanced web interface (planned for 2.0.0)

- **Champ Select**
    - Enhanced customization web interface (planned for 2.0.0)
    - Display team logo (planned for 2.0.0)
    - Fix bugs, square, splash art not display (planned for 2.0.0)
    - Enhancing existing views (planned for 2.0.0)
    - Display stat winrate and pick champ (not planned yet)
    - New view (not planned yet)

- **Config**
    - Enhanced web interface (planned for 2.0.0)

- **End Game**
    - Enhanced customization web interface (planned for 2.0.0)
    - Display team logo on overlay (planned for 2.0.0)
    - Number of Voidgrubs killed (planned for 2.0.0)
    - Enhancing existing views (planned for 2.0.0)

- **In Game**
    - Read information in memory (not planned yet, wait Riot Vanguard information)
        - HP/Mana/Dragon/Gold/Dega in fight/Champion stacks/XP/Level ...
    - Enhanced customization web interface (planned for 2.0.0)
    - Enhancing existing views (planned for 2.0.0)
        - Voidgrubs
            - Timer (planned for 2.0.0)
            - Number killed per team (planned for 2.0.0)
            - Logo (planned for 2.0.0)
            - Add your own logo (not planned yet)
        - Herald
            - Change timer (planned for 2.0.0)
            - Change default logo (planned for 2.0.0)
            - Add your own logo (not planned yet)
        - Baron
            - Change default logo for each baron (planned for 2.0.0)
            - Add your own logo (not planned yet)
        - Dragon
            - For fire add ash (planned for 2.0.0)
            - Add your own logos (not planned yet)
        - Items
            - Update list and fix bugs (planned for 2.0.0)
        - Display team logo (planned for 2.0.0)
        - Win lose display (planned for 2.0.0)
    - Add multiple overlay types (planned for 2.0.0)

- **Runes**
    - Enhanced customization web interface (planned for 2.0.0) 
    - Enhancing existing views (planned for 2.0.0)
    - Add multiple overlay types (not planned yet)

### **OSL-WebApiRiot**
- Refactoring code (planned for 2.0.0)
- Cover all WebApiRiot request (not planned yet)


# Thanks to these projets and community
### [Floh22](https://github.com/floh22)

[LeagueBroadcast](https://github.com/floh22/LeagueBroadcast) (League of Legends Spectate Overlay Tools )

### [Riot Community Volunteers ](https://github.com/RCVolus)

[league-prod-toolkit](https://github.com/RCVolus/league-prod-toolkit) (Toolkit for League Productions with overlays for champion select, ingame events, end of game stats, and more)

[league-observer-tool](https://github.com/RCVolus/league-observer-tool) (An addition to the league-prod-toolkit for the observer PC)

[lol-pick-ban-ui](https://github.com/RCVolus/lol-pick-ban-ui) (Web-Based UI to display the league of legends champ select in esports tournaments)

### [Litzuck](https://github.com/Litzuck)

[lol-spectator-overlay-client](https://github.com/Litzuck/lol-spectator-overlay-client) (A client that produces an overlay similar to that of the one used in the broadcasts of LoL Esports during 2015-2017)

### [Piorrro33](https://github.com/piorrro33)

[overlay](https://github.com/piorrro33/overlay) (Customizable UI for League of Legends champion select spectating)

### [SkinSpotlights](https://github.com/SkinSpotlights)

[LiveEventsDocumentation](https://github.com/SkinSpotlights/LiveEventsDocumentation) (Minimalist documentation of live events)

# **License**
Distributed under the MIT License. See LICENSE for more information.


# **Legal disclaimer**
OSL isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.

OSL was created under Riot Games' "Legal Jibber Jabber" policy using assets owned by Riot Games.  Riot Games does not endorse or sponsor this project.
