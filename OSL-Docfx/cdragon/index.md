# **OSL-CDragon** Documentation

---

> [!CAUTION] 
> **Documentation in progress** 

---

## **OSL-CDragon** is a library for interacting with CDragon data.

Download the last version or a specific patch of game picture on [CDragon web site](https://communitydragon.org/).

### Management of :

Champions
  - Skins
  - Default square
  - Song
  - Abilitys

Items

Perks

Summoners Spell

### Files downloads :

Général :
- https://raw.communitydragon.org/latest/content-metadata.json

Champion :
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/champion-summary.json
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/champions/{champID}.json
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-icons/{jsonChampionId.id}.png
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/champion-choose-vo/{jsonChampionId.id}.ogg
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/champion-ban-vo/{jsonChampionId.id}.ogg
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-sfx-audios/{jsonChampionId.id}.ogg
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-splashes/{jsonChampionId.id}/{championIdSkin}.jpg
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-splashes/uncentered/{jsonChampionId.id}/{championIdSkin}.jpg
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/v1/champion-tiles/{jsonChampionId.id}/{championIdSkin}.jpg
- https://raw.communitydragon.org/{numPatch}/game/assets/characters/{nameChampionToLower}/skins/base/{nameLoadScreenChamp}.png

Items :
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/items.json
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/assets/items/icons2d/{itemFullName}

Perks :
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/perks.json
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/{CDragon.perkstyles}.json
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/v1/perk-images/{perkFullName}


Summoners Spell :
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/summonerSpells.json
- https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/data/spells/icons2d/{summonersSpellFullName}

### Format directory :

    13.7/ #Version Patch
    ├── fr_fr/ #Region
    │   ├── Champions/ #Champions
    │   │   ├── 19/ #Id Champion
    │   │   │   ├── Abilitys/
    │   │   │   ├── Skins/
    │   │   │   │   ├── 19000/ #Id Skin
    │   │   │   │   │   ├── 19000_LoadScreen.png #Loading screen
    │   │   │   │   │   ├── 19000_Splashe.jpg #Centered spashed
    │   │   │   │   │   ├── 19000_Splashe_Uncentered.jpg #Uncentered spashed
    │   │   │   │   │   ├── 19000_Tile.jpg #Tile
    │   │   │   ├── Sound/
    │   │   │   │   ├── champion-ban.ogg #Champion banned
    │   │   │   │   ├── champion-choose.ogg #Champion choose
    │   │   │   │   ├── champion-sfx.ogg #Champion sfx
    │   │   │   ├── default-square.png/
    │   │   ...
    │   ├── Items/ #Items
    │   │   ├── 1001.png #Id Items
    │   │   ├── 1004.png #Id Items
    │   │   ├── ...
    │   ├── Perks/ #Runes
    │   │   ├── StatMods/
    │   │   │   ├── 5001.png
    │   │   │   ├── 5002.png
    │   │   │   ├── 5003.png
    │   │   │   ├── 5005.png
    │   │   │   ├── 5007.png
    │   │   │   ├── 5008.png
    │   │   ├── Style/
    │   │   │   ├── Domination/
    │   │   │   │   ├── 8105.png
    │   │   │   │   ├── ...
    │   │   │   ├── Inspiration/
    │   │   │   │   ├── 8304.png
    │   │   │   │   ├── ...
    │   │   │   ├── Precision/
    │   │   │   │   ├── 8005.png
    │   │   │   │   ├── ...
    │   │   │   ├── Resolve/
    │   │   │   │   ├── 8401.png
    │   │   │   │   ├── ...
    │   │   │   ├── RuneIcon.png/
    │   │   │   │   ├── 8004.png
    │   │   │   │   ├── ...
    │   │   │   ├── Sorcery/
    │   │   │   │   ├── 8210.png
    │   │   │   │   ├── ...
    │   │   ├── 7000.png
    │   │   ├── 8100.png
    │   │   ├── 8200.png
    │   │   ├── 8300.png
    │   │   ├── 8400.png
    │   ├── SummonerSpell/ #Summoner spell
    │   │   ├── 1.png
    │   │   ├── 3.png
    │   │   ├── ...

