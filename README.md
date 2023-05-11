# **OSL : Overlay Spectator Live**
![work-in-progress](https://img.shields.io/badge/respos%20status-WIP-yellow)
![version](https://img.shields.io/badge/version-v1.1.0-blue)

![language](https://img.shields.io/badge/language-c%23-brightgreen)
![.Net-6.0](https://img.shields.io/badge/.NET-6.0-brightgreen)
![framework](https://img.shields.io/badge/framework-blazor-brightgreen)
![platform](https://img.shields.io/badge/platform-windows-brightgreen)

![license](https://img.shields.io/badge/license-MIT-darkgreen)

![LoL1](https://img.shields.io/badge/Game%20Client%20API-League%20of%20Legends-blue)
![LoL2](https://img.shields.io/badge/Game%20Client%20Replay%20API-League%20of%20Legends-blue)
![LoL3](https://img.shields.io/badge/Live%20Events%20API-League%20of%20Legends-blue)
![LoL4](https://img.shields.io/badge/Memory%20Reader-League%20of%20Legends-blue)
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
- 3 view
- Team/Dragon/Baron frame
- Team name
- Number of victory/lose teams
- Frame for video/logo/player picture ...

**[End Game :](https://sky-csc.github.io/OSL/web/index.html#information-display-with-overlay-in-end-game)**
- 3 view
- Team name
- Team score
- Team win loose
- Damage to champion
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
[OSL-Client](https://sky-csc.github.io/OSL/client/index.html)
[OSL-Web](https://sky-csc.github.io/OSL/web/index.html)
1. Download [last release](https://github.com/Sky-CSC/OSL/releases/latest)
2. Unzip release to desired install folder
3. Run OSL-Client on the computer where the spectator game is running
4. Run OSL-Client on the computer you want (be careful, these two computers must be able to communicate, same network, or communicating network)
5. Add http://ip:4141/champselect/view1 and/or http://ip:4141/champselect/view2 and/or 
http://ip:4141/champselect/view3 and/or http://ip:4141/champselect/view4 as a browser source in OBS in your ban pick scene
6. Add http://ip:4141/ingame/view1 and/or http://ip:4141/ingame/view2 and/or http://ip:4141/ingame/view3 as a browser source in OBS in your in game scene
7. Add http://ip:4141/endgame/view1 and/or http://ip:4141/endgame/view2 and/or http://ip:4141/endgame/view3 as a browser source in OBS in your in game scene
8. Add http://ip:4141/runes/view1/top and http://ip:4141/runes/view1/jungle and http://ip:4141/runes/view1/mid and http://ip:4141/runes/view1/adc and http://ip:4141/runes/view1/supp and http://ip:4141/runes/view1/adcsupp and http://ip:4141/runes/view1/all as a browser source in OBS in your in game scene

# **Roadmap**

**Refactoring code :**
-  **(In progress !!)**

**In Game**
- Read in memory 
- Get game information (items, events ...)
- Improved customization

**Champ Select :**
- Improved customization

**End Game**
- Improved customization

**Runes**
- View 2
- Improved customization

# Thanks to these projets and community
## [Floh22](https://github.com/floh22)

[LeagueBroadcast](https://github.com/floh22/LeagueBroadcast) (League of Legends Spectate Overlay Tools )

## [Riot Community Volunteers ](https://github.com/RCVolus)

[league-prod-toolkit](https://github.com/RCVolus/league-prod-toolkit) (Toolkit for League Productions with overlays for champion select, ingame events, end of game stats, and more)

[league-observer-tool](https://github.com/RCVolus/league-observer-tool) (An addition to the league-prod-toolkit for the observer PC)

[lol-pick-ban-ui](https://github.com/RCVolus/lol-pick-ban-ui) (Web-Based UI to display the league of legends champ select in esports tournaments)

## [Litzuck](https://github.com/Litzuck)

[lol-spectator-overlay-client](https://github.com/Litzuck/lol-spectator-overlay-client) (A client that produces an overlay similar to that of the one used in the broadcasts of LoL Esports during 2015-2017)

## [Piorrro33](https://github.com/piorrro33)

[overlay](https://github.com/piorrro33/overlay/tree/v1.5.1) (Customizable UI for League of Legends champion select spectating)

# **License**
Distributed under the MIT License. See LICENSE for more information.


# **Legal disclaimer**
OSL isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.

OSL was created under Riot Games' "Legal Jibber Jabber" policy using assets owned by Riot Games.  Riot Games does not endorse or sponsor this project.