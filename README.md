# **OSL : Overlay Spectator Live**
![work-in-progress](https://img.shields.io/badge/respos%20status-WIP-yellow)
![stability](https://img.shields.io/badge/stability-experimental-orange)
![language](https://img.shields.io/badge/language-c%23-brightgreen)
![.Net-6.0](https://img.shields.io/badge/.NET-6.0-brightgreen)
![framework](https://img.shields.io/badge/framework-blazor-brightgreen)
![platform](https://img.shields.io/badge/platform-windows-brightgreen)
![license](https://img.shields.io/badge/license-comming%20soon-critical)
![LoL1](https://img.shields.io/badge/Game%20Client%20API-League%20of%20Legends-blue)
![LoL2](https://img.shields.io/badge/Game%20Client%20Replay%20API-League%20of%20Legends-blue)
![LoL3](https://img.shields.io/badge/Live%20Events%20API-League%20of%20Legends-blue)
![LoL4](https://img.shields.io/badge/Memory%20Reader-League%20of%20Legends-blue)
![riot1](https://img.shields.io/badge/Web%20API%20Riot-RIOT-blue)
![riot2](https://img.shields.io/badge/CDragon%20API-CDragon-blue)

This project allows you to display an overlay with additional information for your League of Legends games

Applications use various APIs to collect information about the game, champions, players, .....

# **Features**

**[Champ Select :](https://sky-csc.github.io/OSL/serverdoc/intro.html#information-display-with-overlay-in-champ-select)**
- 4 view
- Champ ban/select
- Summoners names
- Team name
- Number of victory/lose teams
- Timer ban/select/waiting
- Summoners Spell

**[In Game :](https://sky-csc.github.io/OSL/serverdoc/intro.html#information-display-with-overlay-in-game)**

[With riot overlay :](https://sky-csc.github.io/OSL/serverdoc/intro.html#with-riot-overlay-)
- 3 view
- Team/Dragon/Baron frame
- Team name
- Number of victory/lose teams
- Frame for video/logo/player picture ...

# **Documentation**
I try to provide full documentation on the code and API I use. **[Link documentation](https://sky-csc.github.io/OSL/)**

# **Getting Started**

**Installation**

1. Download [last release](https://github.com/Sky-CSC/OSL/releases/latest)
2. Unzip release to desired install folder
3. Run OSL-Client on the computer where the spectator game is running
4. Run OSL-Client on the computer you want (be careful, these two computers must be able to communicate, same network, or communicating network)
5. Add http://ip:4141/champselect/view1 and/or http://ip:4141/champselect/view2 and/or 
http://ip:4141/champselect/view3 and/or http://ip:4141/champselect/view4 as a browser source in OBS in your ban pick scene
6. Add http://ip:4141/ingame/view1 and/or http://ip:4141/ingame/view2 and/or http://ip:4141/ingame/view3 as a browser source in OBS in your in game scene

# **Roadmap**

**Champ Select :**
- Improved customization **(In progress !!)**

**In Game**
- Get action/information give by League of Legends api
- Read in memory

**Runes**
- Display of players' runes, lane by lane (blue champion midlane vs red champion midlane, blue champion adc and supp vs red champion adc and supp, ...) **(In progress !!)**

**End Game**
- Recap of the game
  - Timer game
  - Teams name
  - Logo teams
  - Champ dega
  - KDA
  - Total golds
  - Number tower kill by team
  - Number drake kill by team
  - Number elder dragon kill by team
  - Number herald kill by team
  - Number baron kill by team
  - Champion Ban/Pick
  - Gold difference over time


# **License**
⚠️**The license of this code is not given yet, it is coming soon**⚠️


# **Legal disclaimer**
OSL isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.

OSL was created under Riot Games' "Legal Jibber Jabber" policy using assets owned by Riot Games.  Riot Games does not endorse or sponsor this project.