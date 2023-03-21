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

**[End Game :](https://sky-csc.github.io/OSL/serverdoc/intro.html#information-display-with-overlay-in-end-game)**
- 3 view
- Team name
- Team score
- Team win loose
- Damage to champion
- Bans
- KDA/Gold/Tower/Dragon/Elder Dragon/Herald/Baron
- Gold Diff

**[Runes :](https://sky-csc.github.io/OSL/serverdoc/intro.html#information-display-with-overlay-runes)**
- 7 view
- Top
- Jungle
- Mid
- Adc
- Support
- Adc and support
- All

<br>

# Applications architecture 
![](picture/OSL-architecture2.drawio.png)

## For more information, please refer to these different documentations.
- [**Client**](clientdoc/intro.md)
> [!NOTE] 
> How to use and configure the application locally to sends information to the **Server**
>
> How to set up and use riot viewer mode

- [**Server**](serverdoc/intro.md)
> [!NOTE]
> How to use the server application and retrieve information and overlay from a game.

- [**Developer Client**](apiclient/index.md)
> [!NOTE]
> What information it sends to the **Server** in what data format.
>
> Code explanation.

- [**Developer Server**](apiserver/index.md)
> [!NOTE]
> What information are recover and in what data format.
>
> Code explanation.

---

> [!WARNING] 
> **Project in progress** 

> [!TIP]
> **If you have any suggestions don't hesitate**

> [!CAUTION]
> **The license of this code is not given yet, it is coming soon**

> [!WARNING]
> **Legal disclaimer**
> OSL isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing Riot Games properties. Riot Games, and all associated properties are trademarks or registered trademarks of Riot Games, Inc.
> OSL was created under Riot Games' "Legal Jibber Jabber" policy using assets owned by Riot Games.  Riot Games does not endorse or sponsor this project.