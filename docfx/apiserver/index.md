# Developper Documentation **server**

> [!WARNING] 
> **Documentation in progress** 
---
### Game information obtained remotely
- Runes/Perks/Masteries :
  ```diff
  - Riot API :
  /lol/spectator/v4/active-games/by-summoner/{encryptedSummonerId} (default)
  ```
- Summoners Spell
  ```diff
  - Riot API :
  /lol/spectator/v4/active-games/by-summoner/{encryptedSummonerId} (default)
  ```
---

## Riot API
[Riot API](https://developer.riotgames.com/apis) used for take many information

### Information used :

- Spectator-v4 (get information of a player in game)
    - /lol/spectator/v4/active-games/by-summoner/\{encryptedSummonerId}	
	  <br>Used for found rune of all player of the game
   	
- Summoner-V4 (get summoners information)
    - /lol/summoner/v4/summoners/by-name/\{summonerName} 
      <br>Used for found accountId (encryptedSummonerId) of summonerName

