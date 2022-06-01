# Developper Documentation **Server**

---

> [!CAUTION] 
> **Documentation in progress** 

---

## **API/Tools used :**
## Web API Riot
[Riot API](https://developer.riotgames.com/apis) used for take many information

## **CDragon API :**
[CDragon API](https://www.communitydragon.org/) used for take picture of game and build overlays

---

## Game information take with Web API Riot
- Runes/Perks/Masteries (Used for found rune of all player of the curent game) : 
  ```diff
  - Riot API (Spectator-v4) :
  /lol/spectator/v4/active-games/by-summoner/{encryptedSummonerId} (default)
  ```
- Summoners Spell (Used for found accountId (encryptedSummonerId) of summonerName) :
  ```diff
  - Riot API (Summoner-V4) :
  /lol/spectator/v4/active-games/by-summoner/{encryptedSummonerId} (default)
  ```
---

## Endpoint of CDragon

[Endpoint](https://cdn.communitydragon.org/endpoints)