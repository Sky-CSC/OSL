# **Server** Documentation

---

> [!CAUTION] 
> **Documentation in progress** 
> 
> **These features are under development, they are not available**

---

Download last release : [First Release v0.1.0-alpha](https://github.com/Sky-CSC/OSL/releases/tag/v0.1.0-alpha)

Not forget run ```OSL-Server.exe```, before run ```OSL-Client.exe```

Open in a browser [https://< ip >:4242](https://ip:4242) (change ip by your computer ip)

Home : Link to documentation

CDragon : Data download from CDragon (When you run it he download data)

Config : Not implemented

Champ Select : Customization of overlay. When you run a game, information to OSL-Client is send to OSL-Server. 3 Overlay are usable

```Configuration/configCDragon.json``` : Configuration CDragon for download

```Configuration/configServerSocket.json``` : Port of server 
- Default port : 45678

```wwwroot/``` : 
- ```wwwroot/_content``` : Blazor operation
- ```wwwroot/assets``` : 
  - ```wwwroot/assets/xx.x``` : CDragon pictures downloads
  - ```wwwroot/assets/champselect``` : picture used for champion selection
  - ```wwwroot/assets/ingame``` : picture used for in game
  - ```wwwroot/assets/lolsprites``` : lol sprites
- ```wwwroot/css``` : css of web application
- ```wwwroot/favicon.ico``` : icon of web application
- ```wwwroot/OSL-Server.styles.css``` : css of web application

---

This document explains how to use and connect to the server to receive the different overlay.
The information you can receive from the game is listed, and separated into 5 categories. It is possible to disable or enable all options.

**Waiting a Game** : This overlay displays information about the players in the next game.

**Champ Select** : This overlay display information when champ select of the match is in progress.

**Waiting Game Start** :  This overlay displays information while waiting for the game to start because of the delay between the game and the broadcast for the viewers.

**In Game** : This overlay display information when spectator game is in progress.

**End Game** : This overlay display information when the game is over.

---

## **OBS** configuration :

Add to your différents scènes the différents URL, you can found this URL on your personal area, in games, game-xxxxxxxxxx, in **Waiting a Game**, **Champ Select**, **Waiting Game Start**, **In Game** and **End Game**.

The URL is like https://osl.sky-csc.fr/ezvozhebvized_jcbzekbcize_zebcjk54654_qsdd he is generate randomly

---

## Information display on overlay

<span style="color:yellow">information</span> : Display information if the default riot overlay is disabled

<span style="color:green">information</span> : Only if reading from memory is enabled. If memory reading is enabled, the default riot overlay can be disabled.

<span style="color:darkred">information</span> : Data not found at this time

### <ins>Information display with overlay **Waiting a Game**
- Number of lose and vircory in ranked solo/duo and flex

Video example Waiting a Game

<!-- https://youtu.be/46wy47H3D6o?list=PLk9GhrqI8Se0fgkxp_Ceb3V5A89m0kk4T -->

[![Video example Waiting a Game](https://img.youtube.com/vi/46wy47H3D6o/0.jpg)](https://www.youtube.com/watch?v=46wy47H3D6o)

<!-- [![Video example Waiting a Game](https://img.youtube.com/vi/y-jzB9q54Ng/0.jpg)](https://www.youtube.com/watch?v=y-jzB9q54Ng) -->

<!-- <a href="http://www.youtube.com/watch?feature=player_embedded&v=y-jzB9q54Ng?
" target="_blank"><img src="http://img.youtube.com/vi/y-jzB9q54Ng/0.jpg" 
alt="Video example Waiting a Game" width="240" height="180" border="0" /></a> -->

### <ins>Information display with overlay in **Champ Select**
Linked att game : 
- Champion Ban
- Champion Pick
- Summoners Name
- Summoners Spell
- Skins
- Timer (ban/select/waiting)
 	
Take off game :
- Name Toornament
- Win/Lose Team
- Logo Team
- Name Team
- Name Summoners
- Name Coach
- Stats Champ Ban
- Stats Champ Pick
- Stats Champ Winrate

Video example Champ Select

[![Video example Waiting a Game](https://img.youtube.com/vi/46wy47H3D6o/0.jpg)](https://www.youtube.com/watch?v=46wy47H3D6o)

### <ins>Information display with overlay **Waiting Game Start**
- Stats of players in the champ pick
- Stats Summoners on champ

Video example Waiting Game Start

[![Video example Waiting a Game](https://img.youtube.com/vi/46wy47H3D6o/0.jpg)](https://www.youtube.com/watch?v=46wy47H3D6o)
 
### <ins>Information display with overlay **In Game**
Inter of game :
- LevelUp
- Itemps buy
- Dragon (Kill, <span style="color:darkred">next</span>, soul)
- Elder Dragon (Timer, buff, all champ kill, <span style="color:green">gold diff</span>, <span style="color:green">damege diff</span>, next helder drake)
- Baron (buff, timer, all champ dead, <span style="color:green">gold diff</span>, <span style="color:green">damage diff</span>, next nash)
- Herald (buff, timer, launch or not, take or not)
- <span style="color:yellow">Kill</span>
- <span style="color:yellow">Tower</span>
- <span style="color:yellow">Timer</span>
- <span style="color:green">Gold</span>
- <span style="color:green">Gold win during fight</span>
- <span style="color:green">XP + Level</span>
- <span style="color:darkred">Damage dead</span>
- <span style="color:darkred">Damage dead during fight</span>

Exter of game :
- Ban/Pick
- Runes
- Logo/Name Team
- Lose/Win
- Video

Video example In Game

[![Video example Waiting a Game](https://img.youtube.com/vi/46wy47H3D6o/0.jpg)](https://www.youtube.com/watch?v=46wy47H3D6o)

### <ins>Information display with overlay in **End Game**
- Dega
- Gold
- Objectif
- Size

Video example End Game

[![Video example Waiting a Game](https://img.youtube.com/vi/46wy47H3D6o/0.jpg)](https://www.youtube.com/watch?v=46wy47H3D6o)