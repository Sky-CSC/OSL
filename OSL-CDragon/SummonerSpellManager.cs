﻿using Newtonsoft.Json;
using OSL_Common.System.Logging;

namespace OSL_CDragon
{
    /// <summary>
    /// Retrieve data from each summoner spell
    /// </summary>
    public class SummonerSpellManager
    {
        private static Logger _logger = new("SummonerSpellManager");

        /// <summary>
        /// Recover all summoners spell existing and is data
        /// </summary>
        /// <param name="numPatch"></param>
        /// <param name="region"></param>
        public static void DownloadSummonersSpell(string numPatch, string region)
        {
            //Summoners spell
            //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/{region}/v1/{summonerSpells}.json
            //https://raw.communitydragon.org/{patch}/plugins/rcp-be-lol-game-data/global/default/data/spells/icons2d/{item}
            int indexPatch = CDragon.dataCDragon.Patch.FindIndex(x => x.Name == numPatch);
            int indexRegion = CDragon.dataCDragon.Patch[indexPatch].Region.FindIndex(x => x.Name == region);

            //string summonersSpellDirectory = "./" + numPatch + "/" + region + "/" + "SummonerSpells" + "/";
            string summonersSpellDirectory = CDragon.summonerSpellsDirectory;
            Uri urlSummonersSpell = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/{region}/v1/{CDragon.summonerSpells}.json");
            string summonersSpellData = OSL_Common.Download.Download.DownloadStringAsync(urlSummonersSpell).Result;
            if (summonersSpellData != null)
            {
                try
                {
                    dynamic jsonSummonersSpell = JsonConvert.DeserializeObject(summonersSpellData);
                    OSL_Common.Download.Download.downloadAllFile = 0;
                    OSL_Common.Download.Download.errorDownloadAllFile = 0;
                    foreach (dynamic summonersSpell in jsonSummonersSpell)
                    {
                        int summonersSpellId = summonersSpell.id;
                        //string summonersSpellName = summonersSpell.name;
                        string iconPath = summonersSpell.iconPath;
                        string[] parseIconPath = iconPath.Split('/');
                        string summonersSpellFullName = parseIconPath[parseIconPath.Length - 1];
                        summonersSpellFullName = summonersSpellFullName.ToLower();
                        SummonersSpellAsyncDownload(indexPatch, indexRegion, numPatch, summonersSpell, summonersSpellDirectory, summonersSpellId, summonersSpellFullName);
                    }
                    int infini = 0;
                    while (OSL_Common.Download.Download.downloadAllFile > 0 && OSL_Common.Download.Download.errorDownloadAllFile == 0 && infini != 200)
                    {
                        _logger.log(LoggingLevel.INFO, "DownloadFileAsync()", $"Waiting end DownloadFileAsync() download : {OSL_Common.Download.Download.downloadAllFile} error : {OSL_Common.Download.Download.errorDownloadAllFile}");
                        infini++;
                        Thread.Sleep(100);
                    }
                    _logger.log(LoggingLevel.INFO, "DownloadFileAsync()", $"{OSL_Common.Download.Download.errorDownloadAllFile} error of download");
                }
                catch (Exception e)
                {
                    _logger.log(LoggingLevel.ERROR, "DownloadSummonersSpell()", $"Error json summoners spell {e.Message}");
                }
            }
        }

        /// <summary>
        /// Download summoners spell async
        /// </summary>
        /// <param name="indexPatch"></param>
        /// <param name="indexRegion"></param>
        /// <param name="numPatch"></param>
        /// <param name="summonersSpell"></param>
        /// <param name="summonersSpellDirectory"></param>
        /// <param name="summonersSpellId"></param>
        /// <param name="summonersSpellFullName"></param>
        public static void SummonersSpellAsyncDownload(int indexPatch, int indexRegion, string numPatch, dynamic summonersSpell, string summonersSpellDirectory, int summonersSpellId, string summonersSpellFullName)
        {
            Uri urlSummonersSpellId = new($"https://raw.communitydragon.org/{numPatch}/plugins/rcp-be-lol-game-data/global/default/data/spells/icons2d/{summonersSpellFullName}");
            string summonersSpellIcone = summonersSpellDirectory + summonersSpellId + ".png";
            OSL_Common.Download.Download.DownloadFileAsync(urlSummonersSpellId, summonersSpellIcone);
            UpdateDataCDragonSummonersSpell(indexPatch, indexRegion, summonersSpell, summonersSpellIcone);
        }

        /// <summary>
        /// Update summoners spell in <see cref="dataCDragon"/>
        /// </summary>
        /// <param name="indexPatch"></param>
        /// <param name="indexRegion"></param>
        /// <param name="summonersSpell"></param>
        /// <param name="summonersSpellIcone"></param>
        public static void UpdateDataCDragonSummonersSpell(int indexPatch, int indexRegion, dynamic summonersSpell, string summonersSpellIcone)
        {
            SummonerSpells summonerSpells = new SummonerSpells();
            summonerSpells.Id = summonersSpell.id;
            summonerSpells.Name = summonersSpell.name;
            summonerSpells.IconPath = summonersSpellIcone;

            int summonerSpellsId = summonersSpell.id;
            int indexSummonersSpell = CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.SummonerSpells.FindIndex(x => x.Id == summonerSpellsId);
            if (indexSummonersSpell == -1)
            {
                CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.SummonerSpells.Add(summonerSpells);
            }
            else
            {
                CDragon.dataCDragon.Patch[indexPatch].Region[indexRegion].RegionContent.SummonerSpells[indexSummonersSpell] = summonerSpells;
            }
        }
    }
}
