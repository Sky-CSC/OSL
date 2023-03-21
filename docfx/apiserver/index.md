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

- Get information of summoner [Link](https://developer.riotgames.com/apis#summoner-v4/GET_getBySummonerName)
  ```diff
  - Riot API (Summoner-V4) :
  /lol/summoner/v4/summoners/by-name/{summonerName} (default)
  ```
  <details>
  <summary><b>Example value</b></summary>

  ```json
  {
    "id": "xziW6_4V-ILrHKrmgmKoB0CI3MbYRbQEC5t14KcK5F8Ib8Q",
    "accountId": "58tu6xAc6YNqH2I4pGafQfGVceUoGKL6h0jvXW00pdv9k44",
    "puuid": "r7ImkhxSkkUkO3MSLaJhHkJ-uNdDGc6mGb7TPDGCh3LBGvT-veaD1OjG1755pR2thiINuPcVB7HjwQ",
    "name": "Sky csc",
    "profileIconId": 3225,
    "revisionDate": 1676933459000,
    "summonerLevel": 265
  }
  ```
  </details>

<br>

- Get Runes/Perks/Masteries/Summoners Spell from player in curent game [Link](https://developer.riotgames.com/apis#spectator-v4/GET_getCurrentGameInfoBySummoner)
  ```diff
  - Riot API (Spectator-v4) :
  /lol/spectator/v4/active-games/by-summoner/{encryptedSummonerId} (default)
  ```
  <details>
  <summary><b>Example value</b></summary>

  ```json
  {
    
  }
  ```
  </details>

<br>

- Get list of match ids [Link](https://developer.riotgames.com/apis#match-v5/GET_getMatchIdsByPUUID)
  ```diff
  - Riot API (Match-v5) :
  /lol/match/v5/matches/by-puuid/{puuid}/ids (default)
  ```

  <details>
  <summary><b>Example value</b></summary>

  ```json
  [
    "EUW1_6281337448",
    "EUW1_6281303853",
    "EUW1_6281242334",
    "EUW1_6281213734",
    "EUW1_6277829083",
    "EUW1_6277805456",
    "EUW1_6273892284",
    "EUW1_6273878983",
    "EUW1_6273862636",
    "EUW1_6273831420",
    "EUW1_6273826210",
    "EUW1_6272861280",
    "EUW1_6272826665",
    "EUW1_6270877936",
    "EUW1_6265457525",
    "EUW1_6265391413",
    "EUW1_6264887276",
    "EUW1_6264853414",
    "EUW1_6264813923",
    "EUW1_6264777311"
  ]
  ```
  </details>

<br>

- Get match information [Link](https://developer.riotgames.com/apis#match-v5/GET_getMatch)
  ```diff
  - Riot API (Match-v5) :
  /lol/match/v5/matches/{matchId} (default)
  ```

  <details>
  <summary><b>Example value</b></summary>

  ```json
    {
    "metadata": {
        "dataVersion": "2",
        "matchId": "EUW1_6281337448",
        "participants": [
            "sqG16BU9amBxYqoH5LZ-ucdjswJ-AvX2VdPf-X-WA1rhDmB8kYeg-7kMEk6sDDwfRYz90xPHHREEMg",
            "ls7NqlVCKkNreRIzQMVqa3AXk2WMhB-6qGSAf1mQyz-CPCNP1BXz-rbBBHWtBZQhAZ1wiwK0_M2igA",
            "F4Y6Be8otUvTH7QilCoNEWAulI4sPccaYt4FmOud5qXdp_JYmk0mEkmdFhwGNISi_7BggwCVv6TwkA",
            "YZVUOCBWz7JhI6UVz7B2ueOq2aWV9leBUm2IH3W1kYyKKV84d26L4jUxNiQzgHKFFRPGdDM0tPtZ4w",
            "nENcE7wHwp-embxEAuovWJ1qDp8EsKIHZ9eQ4P0q0mcN1olSRF6cY8uqFT95-siyg8PqmVXjZBkQFw",
            "5fXpwUM0GU5NXnKk98rk8-gy-5Bz6uHBDuxWUYUsNStohXGYQUkUBFmSLemINVn7RyNVk0dESRhF7Q",
            "r7ImkhxSkkUkO3MSLaJhHkJ-uNdDGc6mGb7TPDGCh3LBGvT-veaD1OjG1755pR2thiINuPcVB7HjwQ",
            "exUzRLgUAFLgLgx5BVzvIk6dp5wNtelRnmXAJzebgGG49D1_z3D4E3znqmusQ624dnm_LFil_foCvQ",
            "UdEiY5yUbUAcN6skV5BEWXYQbrbhug1qyYyuIXwAY0oKhyRUVpFbo18glp8uJ9pH50QxHQYI-7RgCA",
            "UBzXAY4_3Dmc5ZiI5hnSTDAH_ZCIwMUvXcSZNbJSDdBgu08fj33GSstvEjTSt9LPz6d0MudoaL-27w"
        ]
    },
    "info": {
        "gameCreation": 1676581669670,
        "gameDuration": 1256,
        "gameEndTimestamp": 1676583002390,
        "gameId": 6281337448,
        "gameMode": "URF",
        "gameName": "teambuilder-match-6281337448",
        "gameStartTimestamp": 1676581745918,
        "gameType": "MATCHED_GAME",
        "gameVersion": "13.3.491.6222",
        "mapId": 11,
        "participants": [
            {
                "allInPings": 0,
                "assistMePings": 2,
                "assists": 7,
                "baitPings": 0,
                "baronKills": 0,
                "basicPings": 0,
                "bountyLevel": 2,
                "champExperience": 29193,
                "champLevel": 23,
                "championId": 35,
                "championName": "Shaco",
                "championTransform": 0,
                "commandPings": 1,
                "consumablesPurchased": 1,
                "damageDealtToBuildings": 0,
                "damageDealtToObjectives": 908,
                "damageDealtToTurrets": 0,
                "damageSelfMitigated": 19269,
                "dangerPings": 0,
                "deaths": 9,
                "detectorWardsPlaced": 0,
                "doubleKills": 1,
                "dragonKills": 0,
                "eligibleForProgression": true,
                "enemyMissingPings": 0,
                "enemyVisionPings": 1,
                "firstBloodAssist": false,
                "firstBloodKill": false,
                "firstTowerAssist": false,
                "firstTowerKill": false,
                "gameEndedInEarlySurrender": false,
                "gameEndedInSurrender": false,
                "getBackPings": 0,
                "goldEarned": 12874,
                "goldSpent": 9750,
                "holdPings": 0,
                "individualPosition": "Invalid",
                "inhibitorKills": 0,
                "inhibitorTakedowns": 0,
                "inhibitorsLost": 3,
                "item0": 6653,
                "item1": 2421,
                "item2": 3108,
                "item3": 3116,
                "item4": 3020,
                "item5": 3191,
                "item6": 3340,
                "itemsPurchased": 16,
                "killingSprees": 1,
                "kills": 5,
                "lane": "TOP",
                "largestCriticalStrike": 0,
                "largestKillingSpree": 2,
                "largestMultiKill": 2,
                "longestTimeSpentLiving": 170,
                "magicDamageDealt": 75571,
                "magicDamageDealtToChampions": 18623,
                "magicDamageTaken": 5940,
                "needVisionPings": 0,
                "neutralMinionsKilled": 4,
                "nexusKills": 0,
                "nexusLost": 1,
                "nexusTakedowns": 0,
                "objectivesStolen": 0,
                "objectivesStolenAssists": 0,
                "onMyWayPings": 0,
                "participantId": 1,
                "pentaKills": 0,
                "perks": {
                    "statPerks": {
                        "defense": 5002,
                        "flex": 5008,
                        "offense": 5005
                    },
                    "styles": [
                        {
                            "description": "primaryStyle",
                            "selections": [
                                {
                                    "perk": 8128,
                                    "var1": 803,
                                    "var2": 19,
                                    "var3": 0
                                },
                                {
                                    "perk": 8143,
                                    "var1": 740,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8138,
                                    "var1": 30,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8105,
                                    "var1": 8,
                                    "var2": 3,
                                    "var3": 0
                                }
                            ],
                            "style": 8100
                        },
                        {
                            "description": "subStyle",
                            "selections": [
                                {
                                    "perk": 8014,
                                    "var1": 426,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 9104,
                                    "var1": 13,
                                    "var2": 40,
                                    "var3": 0
                                }
                            ],
                            "style": 8000
                        }
                    ]
                },
                "physicalDamageDealt": 10728,
                "physicalDamageDealtToChampions": 371,
                "physicalDamageTaken": 22052,
                "profileIcon": 5626,
                "pushPings": 0,
                "puuid": "sqG16BU9amBxYqoH5LZ-ucdjswJ-AvX2VdPf-X-WA1rhDmB8kYeg-7kMEk6sDDwfRYz90xPHHREEMg",
                "quadraKills": 0,
                "riotIdName": "",
                "riotIdTagline": "",
                "role": "SUPPORT",
                "sightWardsBoughtInGame": 0,
                "spell1Casts": 70,
                "spell2Casts": 118,
                "spell3Casts": 78,
                "spell4Casts": 116,
                "summoner1Casts": 9,
                "summoner1Id": 14,
                "summoner2Casts": 4,
                "summoner2Id": 4,
                "summonerId": "9WNBwhaEj9b2i2M18I5WCukkD0qf5rE7Mc2AT_q7F48tNE-1",
                "summonerLevel": 186,
                "summonerName": "SoIeil",
                "teamEarlySurrendered": false,
                "teamId": 100,
                "teamPosition": "",
                "timeCCingOthers": 48,
                "timePlayed": 1256,
                "totalDamageDealt": 94083,
                "totalDamageDealtToChampions": 21402,
                "totalDamageShieldedOnTeammates": 0,
                "totalDamageTaken": 28568,
                "totalHeal": 2707,
                "totalHealsOnTeammates": 0,
                "totalMinionsKilled": 73,
                "totalTimeCCDealt": 790,
                "totalTimeSpentDead": 234,
                "totalUnitsHealed": 1,
                "tripleKills": 0,
                "trueDamageDealt": 7783,
                "trueDamageDealtToChampions": 2408,
                "trueDamageTaken": 575,
                "turretKills": 0,
                "turretTakedowns": 0,
                "turretsLost": 11,
                "unrealKills": 0,
                "visionClearedPings": 0,
                "visionScore": 7,
                "visionWardsBoughtInGame": 0,
                "wardsKilled": 0,
                "wardsPlaced": 0,
                "win": false
            },
            {
                "allInPings": 0,
                "assistMePings": 0,
                "assists": 5,
                "baitPings": 0,
                "baronKills": 0,
                "basicPings": 0,
                "bountyLevel": 0,
                "champExperience": 29855,
                "champLevel": 24,
                "championId": 121,
                "championName": "Khazix",
                "championTransform": 0,
                "commandPings": 2,
                "consumablesPurchased": 1,
                "damageDealtToBuildings": 316,
                "damageDealtToObjectives": 32455,
                "damageDealtToTurrets": 316,
                "damageSelfMitigated": 36718,
                "dangerPings": 0,
                "deaths": 9,
                "detectorWardsPlaced": 0,
                "doubleKills": 1,
                "dragonKills": 3,
                "eligibleForProgression": true,
                "enemyMissingPings": 0,
                "enemyVisionPings": 0,
                "firstBloodAssist": false,
                "firstBloodKill": false,
                "firstTowerAssist": false,
                "firstTowerKill": false,
                "gameEndedInEarlySurrender": false,
                "gameEndedInSurrender": false,
                "getBackPings": 0,
                "goldEarned": 17624,
                "goldSpent": 16450,
                "holdPings": 0,
                "individualPosition": "Invalid",
                "inhibitorKills": 0,
                "inhibitorTakedowns": 0,
                "inhibitorsLost": 3,
                "item0": 6671,
                "item1": 3074,
                "item2": 6676,
                "item3": 3031,
                "item4": 3508,
                "item5": 0,
                "item6": 3340,
                "itemsPurchased": 26,
                "killingSprees": 3,
                "kills": 6,
                "lane": "BOTTOM",
                "largestCriticalStrike": 2543,
                "largestKillingSpree": 2,
                "largestMultiKill": 2,
                "longestTimeSpentLiving": 218,
                "magicDamageDealt": 3179,
                "magicDamageDealtToChampions": 1715,
                "magicDamageTaken": 10221,
                "needVisionPings": 0,
                "neutralMinionsKilled": 78,
                "nexusKills": 0,
                "nexusLost": 1,
                "nexusTakedowns": 0,
                "objectivesStolen": 1,
                "objectivesStolenAssists": 0,
                "onMyWayPings": 0,
                "participantId": 2,
                "pentaKills": 0,
                "perks": {
                    "statPerks": {
                        "defense": 5002,
                        "flex": 5008,
                        "offense": 5008
                    },
                    "styles": [
                        {
                            "description": "primaryStyle",
                            "selections": [
                                {
                                    "perk": 8128,
                                    "var1": 660,
                                    "var2": 16,
                                    "var3": 0
                                },
                                {
                                    "perk": 8143,
                                    "var1": 1105,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8138,
                                    "var1": 18,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8135,
                                    "var1": 550,
                                    "var2": 5,
                                    "var3": 0
                                }
                            ],
                            "style": 8100
                        },
                        {
                            "description": "subStyle",
                            "selections": [
                                {
                                    "perk": 8014,
                                    "var1": 499,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 9111,
                                    "var1": 776,
                                    "var2": 220,
                                    "var3": 0
                                }
                            ],
                            "style": 8000
                        }
                    ]
                },
                "physicalDamageDealt": 219069,
                "physicalDamageDealtToChampions": 25604,
                "physicalDamageTaken": 36111,
                "profileIcon": 5692,
                "pushPings": 0,
                "puuid": "ls7NqlVCKkNreRIzQMVqa3AXk2WMhB-6qGSAf1mQyz-CPCNP1BXz-rbBBHWtBZQhAZ1wiwK0_M2igA",
                "quadraKills": 0,
                "riotIdName": "",
                "riotIdTagline": "",
                "role": "SOLO",
                "sightWardsBoughtInGame": 0,
                "spell1Casts": 185,
                "spell2Casts": 207,
                "spell3Casts": 112,
                "spell4Casts": 25,
                "summoner1Casts": 4,
                "summoner1Id": 4,
                "summoner2Casts": 10,
                "summoner2Id": 6,
                "summonerId": "RLG2Dfb0qsHMyjrRbUDlNvblAzLd5O3w7nau3pAv0bOEQfg",
                "summonerLevel": 377,
                "summonerName": "Kal El Oni",
                "teamEarlySurrendered": false,
                "teamId": 100,
                "teamPosition": "",
                "timeCCingOthers": 4,
                "timePlayed": 1256,
                "totalDamageDealt": 228785,
                "totalDamageDealtToChampions": 27869,
                "totalDamageShieldedOnTeammates": 0,
                "totalDamageTaken": 47821,
                "totalHeal": 14295,
                "totalHealsOnTeammates": 0,
                "totalMinionsKilled": 113,
                "totalTimeCCDealt": 64,
                "totalTimeSpentDead": 231,
                "totalUnitsHealed": 1,
                "tripleKills": 0,
                "trueDamageDealt": 6536,
                "trueDamageDealtToChampions": 548,
                "trueDamageTaken": 1488,
                "turretKills": 0,
                "turretTakedowns": 0,
                "turretsLost": 11,
                "unrealKills": 0,
                "visionClearedPings": 0,
                "visionScore": 25,
                "visionWardsBoughtInGame": 0,
                "wardsKilled": 1,
                "wardsPlaced": 0,
                "win": false
            },
            {
                "allInPings": 0,
                "assistMePings": 0,
                "assists": 5,
                "baitPings": 0,
                "baronKills": 0,
                "basicPings": 0,
                "bountyLevel": 0,
                "champExperience": 26815,
                "champLevel": 22,
                "championId": 268,
                "championName": "Azir",
                "championTransform": 0,
                "commandPings": 0,
                "consumablesPurchased": 0,
                "damageDealtToBuildings": 2627,
                "damageDealtToObjectives": 2627,
                "damageDealtToTurrets": 2627,
                "damageSelfMitigated": 42401,
                "dangerPings": 0,
                "deaths": 8,
                "detectorWardsPlaced": 0,
                "doubleKills": 2,
                "dragonKills": 0,
                "eligibleForProgression": true,
                "enemyMissingPings": 0,
                "enemyVisionPings": 1,
                "firstBloodAssist": false,
                "firstBloodKill": false,
                "firstTowerAssist": false,
                "firstTowerKill": false,
                "gameEndedInEarlySurrender": false,
                "gameEndedInSurrender": false,
                "getBackPings": 0,
                "goldEarned": 16820,
                "goldSpent": 14700,
                "holdPings": 0,
                "individualPosition": "Invalid",
                "inhibitorKills": 0,
                "inhibitorTakedowns": 0,
                "inhibitorsLost": 3,
                "item0": 3040,
                "item1": 3115,
                "item2": 6657,
                "item3": 3020,
                "item4": 3135,
                "item5": 3082,
                "item6": 3340,
                "itemsPurchased": 21,
                "killingSprees": 3,
                "kills": 14,
                "lane": "JUNGLE",
                "largestCriticalStrike": 0,
                "largestKillingSpree": 6,
                "largestMultiKill": 2,
                "longestTimeSpentLiving": 283,
                "magicDamageDealt": 128432,
                "magicDamageDealtToChampions": 36518,
                "magicDamageTaken": 9580,
                "needVisionPings": 0,
                "neutralMinionsKilled": 4,
                "nexusKills": 0,
                "nexusLost": 1,
                "nexusTakedowns": 0,
                "objectivesStolen": 0,
                "objectivesStolenAssists": 0,
                "onMyWayPings": 0,
                "participantId": 3,
                "pentaKills": 0,
                "perks": {
                    "statPerks": {
                        "defense": 5003,
                        "flex": 5008,
                        "offense": 5005
                    },
                    "styles": [
                        {
                            "description": "primaryStyle",
                            "selections": [
                                {
                                    "perk": 8229,
                                    "var1": 1453,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8224,
                                    "var1": 1037,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8210,
                                    "var1": 2,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8237,
                                    "var1": 756,
                                    "var2": 0,
                                    "var3": 0
                                }
                            ],
                            "style": 8200
                        },
                        {
                            "description": "subStyle",
                            "selections": [
                                {
                                    "perk": 8345,
                                    "var1": 4,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8347,
                                    "var1": 0,
                                    "var2": 0,
                                    "var3": 0
                                }
                            ],
                            "style": 8300
                        }
                    ]
                },
                "physicalDamageDealt": 4867,
                "physicalDamageDealtToChampions": 1244,
                "physicalDamageTaken": 27626,
                "profileIcon": 5047,
                "pushPings": 0,
                "puuid": "F4Y6Be8otUvTH7QilCoNEWAulI4sPccaYt4FmOud5qXdp_JYmk0mEkmdFhwGNISi_7BggwCVv6TwkA",
                "quadraKills": 0,
                "riotIdName": "",
                "riotIdTagline": "",
                "role": "NONE",
                "sightWardsBoughtInGame": 0,
                "spell1Casts": 165,
                "spell2Casts": 307,
                "spell3Casts": 33,
                "spell4Casts": 14,
                "summoner1Casts": 6,
                "summoner1Id": 3,
                "summoner2Casts": 7,
                "summoner2Id": 4,
                "summonerId": "_gxM2hzmxDarcPXYHkXW9X7ixBjn_y2Miz_Mydt-fjHuFpc",
                "summonerLevel": 318,
                "summonerName": "VoPraX ",
                "teamEarlySurrendered": false,
                "teamId": 100,
                "teamPosition": "",
                "timeCCingOthers": 26,
                "timePlayed": 1256,
                "totalDamageDealt": 133457,
                "totalDamageDealtToChampions": 37920,
                "totalDamageShieldedOnTeammates": 0,
                "totalDamageTaken": 38401,
                "totalHeal": 3603,
                "totalHealsOnTeammates": 0,
                "totalMinionsKilled": 88,
                "totalTimeCCDealt": 332,
                "totalTimeSpentDead": 280,
                "totalUnitsHealed": 1,
                "tripleKills": 0,
                "trueDamageDealt": 158,
                "trueDamageDealtToChampions": 158,
                "trueDamageTaken": 1193,
                "turretKills": 0,
                "turretTakedowns": 0,
                "turretsLost": 11,
                "unrealKills": 0,
                "visionClearedPings": 0,
                "visionScore": 17,
                "visionWardsBoughtInGame": 0,
                "wardsKilled": 0,
                "wardsPlaced": 0,
                "win": false
            },
            {
                "allInPings": 0,
                "assistMePings": 2,
                "assists": 9,
                "baitPings": 0,
                "baronKills": 0,
                "basicPings": 0,
                "bountyLevel": 0,
                "champExperience": 23435,
                "champLevel": 20,
                "championId": 1,
                "championName": "Annie",
                "championTransform": 0,
                "commandPings": 0,
                "consumablesPurchased": 1,
                "damageDealtToBuildings": 367,
                "damageDealtToObjectives": 5820,
                "damageDealtToTurrets": 367,
                "damageSelfMitigated": 23642,
                "dangerPings": 0,
                "deaths": 10,
                "detectorWardsPlaced": 0,
                "doubleKills": 0,
                "dragonKills": 0,
                "eligibleForProgression": true,
                "enemyMissingPings": 0,
                "enemyVisionPings": 0,
                "firstBloodAssist": false,
                "firstBloodKill": false,
                "firstTowerAssist": false,
                "firstTowerKill": false,
                "gameEndedInEarlySurrender": false,
                "gameEndedInSurrender": false,
                "getBackPings": 0,
                "goldEarned": 13132,
                "goldSpent": 12700,
                "holdPings": 0,
                "individualPosition": "Invalid",
                "inhibitorKills": 0,
                "inhibitorTakedowns": 0,
                "inhibitorsLost": 3,
                "item0": 4636,
                "item1": 2421,
                "item2": 4645,
                "item3": 3089,
                "item4": 3191,
                "item5": 3020,
                "item6": 3340,
                "itemsPurchased": 18,
                "killingSprees": 1,
                "kills": 5,
                "lane": "TOP",
                "largestCriticalStrike": 192,
                "largestKillingSpree": 2,
                "largestMultiKill": 1,
                "longestTimeSpentLiving": 303,
                "magicDamageDealt": 83491,
                "magicDamageDealtToChampions": 26751,
                "magicDamageTaken": 3616,
                "needVisionPings": 0,
                "neutralMinionsKilled": 0,
                "nexusKills": 0,
                "nexusLost": 1,
                "nexusTakedowns": 0,
                "objectivesStolen": 0,
                "objectivesStolenAssists": 1,
                "onMyWayPings": 0,
                "participantId": 4,
                "pentaKills": 0,
                "perks": {
                    "statPerks": {
                        "defense": 5003,
                        "flex": 5008,
                        "offense": 5008
                    },
                    "styles": [
                        {
                            "description": "primaryStyle",
                            "selections": [
                                {
                                    "perk": 8112,
                                    "var1": 1807,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8126,
                                    "var1": 605,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8138,
                                    "var1": 30,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8105,
                                    "var1": 13,
                                    "var2": 5,
                                    "var3": 0
                                }
                            ],
                            "style": 8100
                        },
                        {
                            "description": "subStyle",
                            "selections": [
                                {
                                    "perk": 8233,
                                    "var1": 9,
                                    "var2": 50,
                                    "var3": 0
                                },
                                {
                                    "perk": 8224,
                                    "var1": 826,
                                    "var2": 0,
                                    "var3": 0
                                }
                            ],
                            "style": 8200
                        }
                    ]
                },
                "physicalDamageDealt": 2023,
                "physicalDamageDealtToChampions": 451,
                "physicalDamageTaken": 25640,
                "profileIcon": 5227,
                "pushPings": 0,
                "puuid": "YZVUOCBWz7JhI6UVz7B2ueOq2aWV9leBUm2IH3W1kYyKKV84d26L4jUxNiQzgHKFFRPGdDM0tPtZ4w",
                "quadraKills": 0,
                "riotIdName": "",
                "riotIdTagline": "",
                "role": "DUO",
                "sightWardsBoughtInGame": 0,
                "spell1Casts": 137,
                "spell2Casts": 101,
                "spell3Casts": 124,
                "spell4Casts": 30,
                "summoner1Casts": 8,
                "summoner1Id": 4,
                "summoner2Casts": 8,
                "summoner2Id": 14,
                "summonerId": "B7jOkjea_AehG7An7f47j1JuQa93omMPQYCe8yOZll2T8mQ",
                "summonerLevel": 137,
                "summonerName": "Jymster",
                "teamEarlySurrendered": false,
                "teamId": 100,
                "teamPosition": "",
                "timeCCingOthers": 28,
                "timePlayed": 1256,
                "totalDamageDealt": 87229,
                "totalDamageDealtToChampions": 28917,
                "totalDamageShieldedOnTeammates": 3173,
                "totalDamageTaken": 30104,
                "totalHeal": 1320,
                "totalHealsOnTeammates": 0,
                "totalMinionsKilled": 82,
                "totalTimeCCDealt": 198,
                "totalTimeSpentDead": 382,
                "totalUnitsHealed": 1,
                "tripleKills": 0,
                "trueDamageDealt": 1714,
                "trueDamageDealtToChampions": 1714,
                "trueDamageTaken": 847,
                "turretKills": 0,
                "turretTakedowns": 0,
                "turretsLost": 11,
                "unrealKills": 0,
                "visionClearedPings": 0,
                "visionScore": 11,
                "visionWardsBoughtInGame": 0,
                "wardsKilled": 1,
                "wardsPlaced": 0,
                "win": false
            },
            {
                "allInPings": 0,
                "assistMePings": 0,
                "assists": 12,
                "baitPings": 0,
                "baronKills": 0,
                "basicPings": 0,
                "bountyLevel": 0,
                "champExperience": 28286,
                "champLevel": 23,
                "championId": 58,
                "championName": "Renekton",
                "championTransform": 0,
                "commandPings": 0,
                "consumablesPurchased": 0,
                "damageDealtToBuildings": 3698,
                "damageDealtToObjectives": 3829,
                "damageDealtToTurrets": 3698,
                "damageSelfMitigated": 49214,
                "dangerPings": 0,
                "deaths": 8,
                "detectorWardsPlaced": 0,
                "doubleKills": 0,
                "dragonKills": 0,
                "eligibleForProgression": true,
                "enemyMissingPings": 0,
                "enemyVisionPings": 0,
                "firstBloodAssist": false,
                "firstBloodKill": false,
                "firstTowerAssist": false,
                "firstTowerKill": false,
                "gameEndedInEarlySurrender": false,
                "gameEndedInSurrender": false,
                "getBackPings": 0,
                "goldEarned": 17602,
                "goldSpent": 19200,
                "holdPings": 0,
                "individualPosition": "Invalid",
                "inhibitorKills": 0,
                "inhibitorTakedowns": 0,
                "inhibitorsLost": 3,
                "item0": 3748,
                "item1": 6692,
                "item2": 3111,
                "item3": 3031,
                "item4": 3072,
                "item5": 6676,
                "item6": 3364,
                "itemsPurchased": 18,
                "killingSprees": 3,
                "kills": 12,
                "lane": "TOP",
                "largestCriticalStrike": 1052,
                "largestKillingSpree": 4,
                "largestMultiKill": 1,
                "longestTimeSpentLiving": 418,
                "magicDamageDealt": 11938,
                "magicDamageDealtToChampions": 3491,
                "magicDamageTaken": 18529,
                "needVisionPings": 0,
                "neutralMinionsKilled": 8,
                "nexusKills": 0,
                "nexusLost": 1,
                "nexusTakedowns": 0,
                "objectivesStolen": 0,
                "objectivesStolenAssists": 0,
                "onMyWayPings": 1,
                "participantId": 5,
                "pentaKills": 0,
                "perks": {
                    "statPerks": {
                        "defense": 5002,
                        "flex": 5008,
                        "offense": 5005
                    },
                    "styles": [
                        {
                            "description": "primaryStyle",
                            "selections": [
                                {
                                    "perk": 8005,
                                    "var1": 3688,
                                    "var2": 1517,
                                    "var3": 2170
                                },
                                {
                                    "perk": 9111,
                                    "var1": 1878,
                                    "var2": 480,
                                    "var3": 0
                                },
                                {
                                    "perk": 9105,
                                    "var1": 7,
                                    "var2": 10,
                                    "var3": 0
                                },
                                {
                                    "perk": 8299,
                                    "var1": 1538,
                                    "var2": 0,
                                    "var3": 0
                                }
                            ],
                            "style": 8000
                        },
                        {
                            "description": "subStyle",
                            "selections": [
                                {
                                    "perk": 8126,
                                    "var1": 1065,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8106,
                                    "var1": 5,
                                    "var2": 0,
                                    "var3": 0
                                }
                            ],
                            "style": 8100
                        }
                    ]
                },
                "physicalDamageDealt": 144672,
                "physicalDamageDealtToChampions": 35975,
                "physicalDamageTaken": 24988,
                "profileIcon": 23,
                "pushPings": 0,
                "puuid": "nENcE7wHwp-embxEAuovWJ1qDp8EsKIHZ9eQ4P0q0mcN1olSRF6cY8uqFT95-siyg8PqmVXjZBkQFw",
                "quadraKills": 0,
                "riotIdName": "",
                "riotIdTagline": "",
                "role": "DUO",
                "sightWardsBoughtInGame": 0,
                "spell1Casts": 93,
                "spell2Casts": 49,
                "spell3Casts": 104,
                "spell4Casts": 17,
                "summoner1Casts": 9,
                "summoner1Id": 14,
                "summoner2Casts": 9,
                "summoner2Id": 4,
                "summonerId": "Nnnuo_H1rMYrtjvW81GZXDnqMkZPibwRTg1tIINJzYGILAA",
                "summonerLevel": 275,
                "summonerName": "Zob de Compet",
                "teamEarlySurrendered": false,
                "teamId": 100,
                "teamPosition": "",
                "timeCCingOthers": 31,
                "timePlayed": 1256,
                "totalDamageDealt": 160870,
                "totalDamageDealtToChampions": 43726,
                "totalDamageShieldedOnTeammates": 0,
                "totalDamageTaken": 44564,
                "totalHeal": 7824,
                "totalHealsOnTeammates": 0,
                "totalMinionsKilled": 128,
                "totalTimeCCDealt": 40,
                "totalTimeSpentDead": 305,
                "totalUnitsHealed": 1,
                "tripleKills": 0,
                "trueDamageDealt": 4259,
                "trueDamageDealtToChampions": 4259,
                "trueDamageTaken": 1045,
                "turretKills": 1,
                "turretTakedowns": 1,
                "turretsLost": 11,
                "unrealKills": 0,
                "visionClearedPings": 0,
                "visionScore": 22,
                "visionWardsBoughtInGame": 0,
                "wardsKilled": 2,
                "wardsPlaced": 0,
                "win": false
            },
            {
                "allInPings": 0,
                "assistMePings": 0,
                "assists": 8,
                "baitPings": 0,
                "baronKills": 0,
                "basicPings": 0,
                "bountyLevel": 0,
                "champExperience": 27603,
                "champLevel": 22,
                "championId": 75,
                "championName": "Nasus",
                "championTransform": 0,
                "commandPings": 3,
                "consumablesPurchased": 0,
                "damageDealtToBuildings": 9243,
                "damageDealtToObjectives": 13087,
                "damageDealtToTurrets": 9243,
                "damageSelfMitigated": 60561,
                "dangerPings": 0,
                "deaths": 4,
                "detectorWardsPlaced": 0,
                "doubleKills": 0,
                "dragonKills": 0,
                "eligibleForProgression": true,
                "enemyMissingPings": 0,
                "enemyVisionPings": 0,
                "firstBloodAssist": false,
                "firstBloodKill": true,
                "firstTowerAssist": false,
                "firstTowerKill": false,
                "gameEndedInEarlySurrender": false,
                "gameEndedInSurrender": false,
                "getBackPings": 0,
                "goldEarned": 17908,
                "goldSpent": 16200,
                "holdPings": 0,
                "individualPosition": "Invalid",
                "inhibitorKills": 1,
                "inhibitorTakedowns": 1,
                "inhibitorsLost": 0,
                "item0": 3047,
                "item1": 3084,
                "item2": 4401,
                "item3": 3065,
                "item4": 3068,
                "item5": 0,
                "item6": 3340,
                "itemsPurchased": 23,
                "killingSprees": 1,
                "kills": 6,
                "lane": "MIDDLE",
                "largestCriticalStrike": 0,
                "largestKillingSpree": 5,
                "largestMultiKill": 1,
                "longestTimeSpentLiving": 670,
                "magicDamageDealt": 30136,
                "magicDamageDealtToChampions": 7624,
                "magicDamageTaken": 26310,
                "needVisionPings": 0,
                "neutralMinionsKilled": 34,
                "nexusKills": 0,
                "nexusLost": 0,
                "nexusTakedowns": 0,
                "objectivesStolen": 0,
                "objectivesStolenAssists": 0,
                "onMyWayPings": 2,
                "participantId": 6,
                "pentaKills": 0,
                "perks": {
                    "statPerks": {
                        "defense": 5002,
                        "flex": 5008,
                        "offense": 5008
                    },
                    "styles": [
                        {
                            "description": "primaryStyle",
                            "selections": [
                                {
                                    "perk": 8128,
                                    "var1": 936,
                                    "var2": 25,
                                    "var3": 0
                                },
                                {
                                    "perk": 8139,
                                    "var1": 945,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8138,
                                    "var1": 18,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8135,
                                    "var1": 550,
                                    "var2": 5,
                                    "var3": 0
                                }
                            ],
                            "style": 8100
                        },
                        {
                            "description": "subStyle",
                            "selections": [
                                {
                                    "perk": 8210,
                                    "var1": 0,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8236,
                                    "var1": 28,
                                    "var2": 0,
                                    "var3": 0
                                }
                            ],
                            "style": 8200
                        }
                    ]
                },
                "physicalDamageDealt": 122455,
                "physicalDamageDealtToChampions": 17721,
                "physicalDamageTaken": 18958,
                "profileIcon": 4923,
                "pushPings": 0,
                "puuid": "5fXpwUM0GU5NXnKk98rk8-gy-5Bz6uHBDuxWUYUsNStohXGYQUkUBFmSLemINVn7RyNVk0dESRhF7Q",
                "quadraKills": 0,
                "riotIdName": "",
                "riotIdTagline": "",
                "role": "SUPPORT",
                "sightWardsBoughtInGame": 0,
                "spell1Casts": 263,
                "spell2Casts": 40,
                "spell3Casts": 67,
                "spell4Casts": 16,
                "summoner1Casts": 11,
                "summoner1Id": 4,
                "summoner2Casts": 15,
                "summoner2Id": 6,
                "summonerId": "vYx_hhoEaBipJt0tONlTEPfQRTDzyT_W6HYnPHp5_wrU5r9yN5ZxwAZYfQ",
                "summonerLevel": 98,
                "summonerName": "Wymiride",
                "teamEarlySurrendered": false,
                "teamId": 200,
                "teamPosition": "",
                "timeCCingOthers": 20,
                "timePlayed": 1256,
                "totalDamageDealt": 153838,
                "totalDamageDealtToChampions": 25486,
                "totalDamageShieldedOnTeammates": 0,
                "totalDamageTaken": 47504,
                "totalHeal": 13793,
                "totalHealsOnTeammates": 0,
                "totalMinionsKilled": 96,
                "totalTimeCCDealt": 148,
                "totalTimeSpentDead": 109,
                "totalUnitsHealed": 1,
                "tripleKills": 0,
                "trueDamageDealt": 1247,
                "trueDamageDealtToChampions": 140,
                "trueDamageTaken": 2235,
                "turretKills": 2,
                "turretTakedowns": 3,
                "turretsLost": 1,
                "unrealKills": 0,
                "visionClearedPings": 0,
                "visionScore": 18,
                "visionWardsBoughtInGame": 0,
                "wardsKilled": 0,
                "wardsPlaced": 0,
                "win": true
            },
            {
                "allInPings": 0,
                "assistMePings": 0,
                "assists": 4,
                "baitPings": 0,
                "baronKills": 1,
                "basicPings": 0,
                "bountyLevel": 0,
                "champExperience": 31163,
                "champLevel": 24,
                "championId": 18,
                "championName": "Tristana",
                "championTransform": 0,
                "commandPings": 7,
                "consumablesPurchased": 0,
                "damageDealtToBuildings": 14675,
                "damageDealtToObjectives": 73011,
                "damageDealtToTurrets": 14675,
                "damageSelfMitigated": 23921,
                "dangerPings": 0,
                "deaths": 11,
                "detectorWardsPlaced": 0,
                "doubleKills": 2,
                "dragonKills": 2,
                "eligibleForProgression": true,
                "enemyMissingPings": 0,
                "enemyVisionPings": 0,
                "firstBloodAssist": true,
                "firstBloodKill": false,
                "firstTowerAssist": false,
                "firstTowerKill": true,
                "gameEndedInEarlySurrender": false,
                "gameEndedInSurrender": false,
                "getBackPings": 0,
                "goldEarned": 22278,
                "goldSpent": 19200,
                "holdPings": 0,
                "individualPosition": "Invalid",
                "inhibitorKills": 1,
                "inhibitorTakedowns": 1,
                "inhibitorsLost": 0,
                "item0": 6672,
                "item1": 3094,
                "item2": 3046,
                "item3": 3031,
                "item4": 3072,
                "item5": 3036,
                "item6": 3513,
                "itemsPurchased": 19,
                "killingSprees": 5,
                "kills": 17,
                "lane": "MIDDLE",
                "largestCriticalStrike": 1175,
                "largestKillingSpree": 7,
                "largestMultiKill": 2,
                "longestTimeSpentLiving": 185,
                "magicDamageDealt": 22089,
                "magicDamageDealtToChampions": 2969,
                "magicDamageTaken": 21412,
                "needVisionPings": 0,
                "neutralMinionsKilled": 24,
                "nexusKills": 0,
                "nexusLost": 0,
                "nexusTakedowns": 0,
                "objectivesStolen": 0,
                "objectivesStolenAssists": 0,
                "onMyWayPings": 4,
                "participantId": 7,
                "pentaKills": 0,
                "perks": {
                    "statPerks": {
                        "defense": 5002,
                        "flex": 5008,
                        "offense": 5005
                    },
                    "styles": [
                        {
                            "description": "primaryStyle",
                            "selections": [
                                {
                                    "perk": 9923,
                                    "var1": 82,
                                    "var2": 91,
                                    "var3": 0
                                },
                                {
                                    "perk": 8139,
                                    "var1": 1786,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8138,
                                    "var1": 18,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8135,
                                    "var1": 550,
                                    "var2": 5,
                                    "var3": 0
                                }
                            ],
                            "style": 8100
                        },
                        {
                            "description": "subStyle",
                            "selections": [
                                {
                                    "perk": 8014,
                                    "var1": 2094,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 9103,
                                    "var1": 13,
                                    "var2": 20,
                                    "var3": 0
                                }
                            ],
                            "style": 8000
                        }
                    ]
                },
                "physicalDamageDealt": 252416,
                "physicalDamageDealtToChampions": 52652,
                "physicalDamageTaken": 12674,
                "profileIcon": 3225,
                "pushPings": 0,
                "puuid": "r7ImkhxSkkUkO3MSLaJhHkJ-uNdDGc6mGb7TPDGCh3LBGvT-veaD1OjG1755pR2thiINuPcVB7HjwQ",
                "quadraKills": 0,
                "riotIdName": "",
                "riotIdTagline": "",
                "role": "DUO",
                "sightWardsBoughtInGame": 0,
                "spell1Casts": 91,
                "spell2Casts": 63,
                "spell3Casts": 116,
                "spell4Casts": 11,
                "summoner1Casts": 10,
                "summoner1Id": 4,
                "summoner2Casts": 12,
                "summoner2Id": 6,
                "summonerId": "xziW6_4V-ILrHKrmgmKoB0CI3MbYRbQEC5t14KcK5F8Ib8Q",
                "summonerLevel": 265,
                "summonerName": "Sky csc",
                "teamEarlySurrendered": false,
                "teamId": 200,
                "teamPosition": "",
                "timeCCingOthers": 8,
                "timePlayed": 1256,
                "totalDamageDealt": 289702,
                "totalDamageDealtToChampions": 58874,
                "totalDamageShieldedOnTeammates": 0,
                "totalDamageTaken": 35086,
                "totalHeal": 11279,
                "totalHealsOnTeammates": 0,
                "totalMinionsKilled": 145,
                "totalTimeCCDealt": 38,
                "totalTimeSpentDead": 289,
                "totalUnitsHealed": 1,
                "tripleKills": 0,
                "trueDamageDealt": 15196,
                "trueDamageDealtToChampions": 3252,
                "trueDamageTaken": 999,
                "turretKills": 4,
                "turretTakedowns": 4,
                "turretsLost": 1,
                "unrealKills": 0,
                "visionClearedPings": 0,
                "visionScore": 24,
                "visionWardsBoughtInGame": 0,
                "wardsKilled": 0,
                "wardsPlaced": 0,
                "win": true
            },
            {
                "allInPings": 0,
                "assistMePings": 0,
                "assists": 11,
                "baitPings": 0,
                "baronKills": 0,
                "basicPings": 0,
                "bountyLevel": 5,
                "champExperience": 32262,
                "champLevel": 25,
                "championId": 56,
                "championName": "Nocturne",
                "championTransform": 0,
                "commandPings": 0,
                "consumablesPurchased": 0,
                "damageDealtToBuildings": 1532,
                "damageDealtToObjectives": 1532,
                "damageDealtToTurrets": 1532,
                "damageSelfMitigated": 34670,
                "dangerPings": 0,
                "deaths": 5,
                "detectorWardsPlaced": 0,
                "doubleKills": 0,
                "dragonKills": 0,
                "eligibleForProgression": true,
                "enemyMissingPings": 6,
                "enemyVisionPings": 0,
                "firstBloodAssist": false,
                "firstBloodKill": false,
                "firstTowerAssist": false,
                "firstTowerKill": false,
                "gameEndedInEarlySurrender": false,
                "gameEndedInSurrender": false,
                "getBackPings": 1,
                "goldEarned": 16845,
                "goldSpent": 14900,
                "holdPings": 0,
                "individualPosition": "Invalid",
                "inhibitorKills": 0,
                "inhibitorTakedowns": 0,
                "inhibitorsLost": 0,
                "item0": 6692,
                "item1": 3814,
                "item2": 3111,
                "item3": 3153,
                "item4": 3156,
                "item5": 3035,
                "item6": 3363,
                "itemsPurchased": 35,
                "killingSprees": 2,
                "kills": 10,
                "lane": "BOTTOM",
                "largestCriticalStrike": 0,
                "largestKillingSpree": 5,
                "largestMultiKill": 1,
                "longestTimeSpentLiving": 396,
                "magicDamageDealt": 4615,
                "magicDamageDealtToChampions": 2421,
                "magicDamageTaken": 17942,
                "needVisionPings": 0,
                "neutralMinionsKilled": 8,
                "nexusKills": 0,
                "nexusLost": 0,
                "nexusTakedowns": 0,
                "objectivesStolen": 0,
                "objectivesStolenAssists": 0,
                "onMyWayPings": 0,
                "participantId": 8,
                "pentaKills": 0,
                "perks": {
                    "statPerks": {
                        "defense": 5001,
                        "flex": 5008,
                        "offense": 5005
                    },
                    "styles": [
                        {
                            "description": "primaryStyle",
                            "selections": [
                                {
                                    "perk": 8008,
                                    "var1": 25,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 9111,
                                    "var1": 2224,
                                    "var2": 420,
                                    "var3": 0
                                },
                                {
                                    "perk": 9104,
                                    "var1": 10,
                                    "var2": 40,
                                    "var3": 0
                                },
                                {
                                    "perk": 8014,
                                    "var1": 1007,
                                    "var2": 0,
                                    "var3": 0
                                }
                            ],
                            "style": 8000
                        },
                        {
                            "description": "subStyle",
                            "selections": [
                                {
                                    "perk": 8126,
                                    "var1": 992,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8106,
                                    "var1": 5,
                                    "var2": 0,
                                    "var3": 0
                                }
                            ],
                            "style": 8100
                        }
                    ]
                },
                "physicalDamageDealt": 95304,
                "physicalDamageDealtToChampions": 31973,
                "physicalDamageTaken": 15118,
                "profileIcon": 4571,
                "pushPings": 0,
                "puuid": "exUzRLgUAFLgLgx5BVzvIk6dp5wNtelRnmXAJzebgGG49D1_z3D4E3znqmusQ624dnm_LFil_foCvQ",
                "quadraKills": 0,
                "riotIdName": "",
                "riotIdTagline": "",
                "role": "SOLO",
                "sightWardsBoughtInGame": 0,
                "spell1Casts": 152,
                "spell2Casts": 63,
                "spell3Casts": 34,
                "spell4Casts": 29,
                "summoner1Casts": 7,
                "summoner1Id": 6,
                "summoner2Casts": 7,
                "summoner2Id": 4,
                "summonerId": "Y6dz-cfqfkszEhBcdc-hniNLQ7Ewv1Zjcb7iY1NHzkt5gQI",
                "summonerLevel": 571,
                "summonerName": "DYMripper",
                "teamEarlySurrendered": false,
                "teamId": 200,
                "teamPosition": "",
                "timeCCingOthers": 237,
                "timePlayed": 1256,
                "totalDamageDealt": 101777,
                "totalDamageDealtToChampions": 35459,
                "totalDamageShieldedOnTeammates": 0,
                "totalDamageTaken": 33812,
                "totalHeal": 7398,
                "totalHealsOnTeammates": 0,
                "totalMinionsKilled": 69,
                "totalTimeCCDealt": 508,
                "totalTimeSpentDead": 124,
                "totalUnitsHealed": 1,
                "tripleKills": 0,
                "trueDamageDealt": 1858,
                "trueDamageDealtToChampions": 1064,
                "trueDamageTaken": 751,
                "turretKills": 1,
                "turretTakedowns": 1,
                "turretsLost": 1,
                "unrealKills": 0,
                "visionClearedPings": 0,
                "visionScore": 16,
                "visionWardsBoughtInGame": 0,
                "wardsKilled": 0,
                "wardsPlaced": 0,
                "win": true
            },
            {
                "allInPings": 0,
                "assistMePings": 0,
                "assists": 7,
                "baitPings": 0,
                "baronKills": 0,
                "basicPings": 0,
                "bountyLevel": 3,
                "champExperience": 31776,
                "champLevel": 25,
                "championId": 39,
                "championName": "Irelia",
                "championTransform": 0,
                "commandPings": 1,
                "consumablesPurchased": 3,
                "damageDealtToBuildings": 1762,
                "damageDealtToObjectives": 27329,
                "damageDealtToTurrets": 1762,
                "damageSelfMitigated": 42941,
                "dangerPings": 0,
                "deaths": 16,
                "detectorWardsPlaced": 0,
                "doubleKills": 2,
                "dragonKills": 1,
                "eligibleForProgression": true,
                "enemyMissingPings": 6,
                "enemyVisionPings": 0,
                "firstBloodAssist": false,
                "firstBloodKill": false,
                "firstTowerAssist": false,
                "firstTowerKill": false,
                "gameEndedInEarlySurrender": false,
                "gameEndedInSurrender": false,
                "getBackPings": 0,
                "goldEarned": 15661,
                "goldSpent": 14670,
                "holdPings": 0,
                "individualPosition": "Invalid",
                "inhibitorKills": 0,
                "inhibitorTakedowns": 1,
                "inhibitorsLost": 0,
                "item0": 6333,
                "item1": 3009,
                "item2": 3074,
                "item3": 6632,
                "item4": 6609,
                "item5": 1036,
                "item6": 3340,
                "itemsPurchased": 30,
                "killingSprees": 2,
                "kills": 8,
                "lane": "TOP",
                "largestCriticalStrike": 0,
                "largestKillingSpree": 3,
                "largestMultiKill": 2,
                "longestTimeSpentLiving": 111,
                "magicDamageDealt": 25351,
                "magicDamageDealtToChampions": 6423,
                "magicDamageTaken": 14193,
                "needVisionPings": 0,
                "neutralMinionsKilled": 22,
                "nexusKills": 1,
                "nexusLost": 0,
                "nexusTakedowns": 1,
                "objectivesStolen": 0,
                "objectivesStolenAssists": 0,
                "onMyWayPings": 1,
                "participantId": 9,
                "pentaKills": 0,
                "perks": {
                    "statPerks": {
                        "defense": 5002,
                        "flex": 5008,
                        "offense": 5005
                    },
                    "styles": [
                        {
                            "description": "primaryStyle",
                            "selections": [
                                {
                                    "perk": 8010,
                                    "var1": 601,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 9111,
                                    "var1": 1348,
                                    "var2": 300,
                                    "var3": 0
                                },
                                {
                                    "perk": 9104,
                                    "var1": 14,
                                    "var2": 30,
                                    "var3": 0
                                },
                                {
                                    "perk": 8299,
                                    "var1": 1284,
                                    "var2": 0,
                                    "var3": 0
                                }
                            ],
                            "style": 8000
                        },
                        {
                            "description": "subStyle",
                            "selections": [
                                {
                                    "perk": 8451,
                                    "var1": 240,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8446,
                                    "var1": 561,
                                    "var2": 0,
                                    "var3": 0
                                }
                            ],
                            "style": 8400
                        }
                    ]
                },
                "physicalDamageDealt": 116449,
                "physicalDamageDealtToChampions": 18761,
                "physicalDamageTaken": 27089,
                "profileIcon": 3886,
                "pushPings": 0,
                "puuid": "UdEiY5yUbUAcN6skV5BEWXYQbrbhug1qyYyuIXwAY0oKhyRUVpFbo18glp8uJ9pH50QxHQYI-7RgCA",
                "quadraKills": 0,
                "riotIdName": "",
                "riotIdTagline": "",
                "role": "SOLO",
                "sightWardsBoughtInGame": 0,
                "spell1Casts": 168,
                "spell2Casts": 47,
                "spell3Casts": 99,
                "spell4Casts": 12,
                "summoner1Casts": 11,
                "summoner1Id": 4,
                "summoner2Casts": 9,
                "summoner2Id": 6,
                "summonerId": "k2gJlXbRkUy_3yq68d0fWhYwexDeGnM7M65qmANpP56R0nI",
                "summonerLevel": 252,
                "summonerName": "Hei Feng Lii",
                "teamEarlySurrendered": false,
                "teamId": 200,
                "teamPosition": "",
                "timeCCingOthers": 11,
                "timePlayed": 1256,
                "totalDamageDealt": 141801,
                "totalDamageDealtToChampions": 25185,
                "totalDamageShieldedOnTeammates": 0,
                "totalDamageTaken": 45476,
                "totalHeal": 12537,
                "totalHealsOnTeammates": 0,
                "totalMinionsKilled": 83,
                "totalTimeCCDealt": 60,
                "totalTimeSpentDead": 384,
                "totalUnitsHealed": 1,
                "tripleKills": 0,
                "trueDamageDealt": 0,
                "trueDamageDealtToChampions": 0,
                "trueDamageTaken": 4194,
                "turretKills": 1,
                "turretTakedowns": 1,
                "turretsLost": 1,
                "unrealKills": 0,
                "visionClearedPings": 0,
                "visionScore": 17,
                "visionWardsBoughtInGame": 0,
                "wardsKilled": 0,
                "wardsPlaced": 0,
                "win": true
            },
            {
                "allInPings": 0,
                "assistMePings": 1,
                "assists": 10,
                "baitPings": 0,
                "baronKills": 1,
                "basicPings": 0,
                "bountyLevel": 0,
                "champExperience": 31010,
                "champLevel": 24,
                "championId": 90,
                "championName": "Malzahar",
                "championTransform": 0,
                "commandPings": 2,
                "consumablesPurchased": 1,
                "damageDealtToBuildings": 9294,
                "damageDealtToObjectives": 84387,
                "damageDealtToTurrets": 9294,
                "damageSelfMitigated": 16005,
                "dangerPings": 0,
                "deaths": 7,
                "detectorWardsPlaced": 0,
                "doubleKills": 0,
                "dragonKills": 0,
                "eligibleForProgression": true,
                "enemyMissingPings": 3,
                "enemyVisionPings": 0,
                "firstBloodAssist": true,
                "firstBloodKill": false,
                "firstTowerAssist": false,
                "firstTowerKill": false,
                "gameEndedInEarlySurrender": false,
                "gameEndedInSurrender": false,
                "getBackPings": 0,
                "goldEarned": 16302,
                "goldSpent": 14850,
                "holdPings": 0,
                "individualPosition": "Invalid",
                "inhibitorKills": 1,
                "inhibitorTakedowns": 1,
                "inhibitorsLost": 0,
                "item0": 6653,
                "item1": 3020,
                "item2": 4637,
                "item3": 4645,
                "item4": 3089,
                "item5": 1011,
                "item6": 3340,
                "itemsPurchased": 19,
                "killingSprees": 0,
                "kills": 3,
                "lane": "MIDDLE",
                "largestCriticalStrike": 0,
                "largestKillingSpree": 0,
                "largestMultiKill": 1,
                "longestTimeSpentLiving": 354,
                "magicDamageDealt": 214474,
                "magicDamageDealtToChampions": 27561,
                "magicDamageTaken": 9883,
                "needVisionPings": 0,
                "neutralMinionsKilled": 24,
                "nexusKills": 0,
                "nexusLost": 0,
                "nexusTakedowns": 1,
                "objectivesStolen": 0,
                "objectivesStolenAssists": 0,
                "onMyWayPings": 0,
                "participantId": 10,
                "pentaKills": 0,
                "perks": {
                    "statPerks": {
                        "defense": 5003,
                        "flex": 5008,
                        "offense": 5008
                    },
                    "styles": [
                        {
                            "description": "primaryStyle",
                            "selections": [
                                {
                                    "perk": 8214,
                                    "var1": 2116,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8224,
                                    "var1": 797,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8210,
                                    "var1": 1,
                                    "var2": 0,
                                    "var3": 0
                                },
                                {
                                    "perk": 8237,
                                    "var1": 723,
                                    "var2": 0,
                                    "var3": 0
                                }
                            ],
                            "style": 8200
                        },
                        {
                            "description": "subStyle",
                            "selections": [
                                {
                                    "perk": 8105,
                                    "var1": 13,
                                    "var2": 5,
                                    "var3": 0
                                },
                                {
                                    "perk": 8126,
                                    "var1": 834,
                                    "var2": 0,
                                    "var3": 0
                                }
                            ],
                            "style": 8100
                        }
                    ]
                },
                "physicalDamageDealt": 6594,
                "physicalDamageDealtToChampions": 438,
                "physicalDamageTaken": 12834,
                "profileIcon": 782,
                "pushPings": 0,
                "puuid": "UBzXAY4_3Dmc5ZiI5hnSTDAH_ZCIwMUvXcSZNbJSDdBgu08fj33GSstvEjTSt9LPz6d0MudoaL-27w",
                "quadraKills": 0,
                "riotIdName": "",
                "riotIdTagline": "",
                "role": "SUPPORT",
                "sightWardsBoughtInGame": 0,
                "spell1Casts": 311,
                "spell2Casts": 371,
                "spell3Casts": 155,
                "spell4Casts": 9,
                "summoner1Casts": 7,
                "summoner1Id": 4,
                "summoner2Casts": 14,
                "summoner2Id": 6,
                "summonerId": "_JsJ9_tvuIRm60mcv_bITpjs_iNllhF0h7IxW8pPQUv2kcg",
                "summonerLevel": 194,
                "summonerName": "Hirobb",
                "teamEarlySurrendered": false,
                "teamId": 200,
                "teamPosition": "",
                "timeCCingOthers": 71,
                "timePlayed": 1256,
                "totalDamageDealt": 222168,
                "totalDamageDealtToChampions": 28695,
                "totalDamageShieldedOnTeammates": 0,
                "totalDamageTaken": 24183,
                "totalHeal": 2085,
                "totalHealsOnTeammates": 0,
                "totalMinionsKilled": 121,
                "totalTimeCCDealt": 388,
                "totalTimeSpentDead": 191,
                "totalUnitsHealed": 1,
                "tripleKills": 0,
                "trueDamageDealt": 1099,
                "trueDamageDealtToChampions": 695,
                "trueDamageTaken": 1466,
                "turretKills": 2,
                "turretTakedowns": 2,
                "turretsLost": 1,
                "unrealKills": 0,
                "visionClearedPings": 0,
                "visionScore": 18,
                "visionWardsBoughtInGame": 0,
                "wardsKilled": 0,
                "wardsPlaced": 0,
                "win": true
            }
        ],
        "platformId": "EUW1",
        "queueId": 900,
        "teams": [
            {
                "bans": [],
                "objectives": {
                    "baron": {
                        "first": false,
                        "kills": 0
                    },
                    "champion": {
                        "first": false,
                        "kills": 43
                    },
                    "dragon": {
                        "first": true,
                        "kills": 3
                    },
                    "inhibitor": {
                        "first": false,
                        "kills": 0
                    },
                    "riftHerald": {
                        "first": false,
                        "kills": 0
                    },
                    "tower": {
                        "first": false,
                        "kills": 1
                    }
                },
                "teamId": 100,
                "win": false
            },
            {
                "bans": [],
                "objectives": {
                    "baron": {
                        "first": true,
                        "kills": 2
                    },
                    "champion": {
                        "first": true,
                        "kills": 44
                    },
                    "dragon": {
                        "first": false,
                        "kills": 3
                    },
                    "inhibitor": {
                        "first": true,
                        "kills": 3
                    },
                    "riftHerald": {
                        "first": false,
                        "kills": 0
                    },
                    "tower": {
                        "first": true,
                        "kills": 11
                    }
                },
                "teamId": 200,
                "win": true
            }
        ],
        "tournamentCode": ""
    }
  }
  ```
  </details>

---

## Endpoint of CDragon

[Endpoint](https://cdn.communitydragon.org/endpoints)