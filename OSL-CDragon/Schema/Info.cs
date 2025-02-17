namespace OSL_CDragon.Schema
{
    /// <summary>
    /// Information used for download assets and manage version and region current used.
    /// </summary>
    internal struct Info
    {
        /// <summary>
        /// The patch version current used.
        /// </summary>
        public string Patch { get; set; }
        /// <summary>
        /// The short version of the patch current used.
        /// </summary>
        public string PatchShort { get; set; }
        /// <summary>
        /// A value indicating whether the patch is the latest.
        /// </summary>
        public bool IsLatest { get; set; }
        /// <summary>
        /// The region current used.
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// The date of the last update.
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// The url info of champion summary.
        /// </summary>
        public string ChampionSummary { get; set; }
        /// <summary>
        /// The url info of items.
        /// </summary>
        public string Items { get; set; }
        /// <summary>
        /// The url info of summoner spells.
        /// </summary>
        public string SummonerSpells { get; set; }
        /// <summary>
        /// The url info of perks.
        /// </summary>
        public string Perks { get; set; }
        /// <summary>
        /// The url info of perkstyles.
        /// </summary>
        public string Perkstyles { get; set; }
        /// <summary>
        /// The url info of content metadata.
        /// </summary>
        public string ContentMetadata { get; set; }
        /// <summary>
        /// A value indicating whether download all skin.
        /// </summary>
        public bool DownloadAllSkin { get; set; }
        /// <summary>
        /// The directory where the assets are stored.
        /// </summary>
        public string AssetsDir { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Info"/> struct.
        /// </summary>
        public Info()
        {
            Patch = "latest";
            PatchShort = "";
            IsLatest = true;
            Region = "fr_fr";
            Date = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss");
            ChampionSummary = "champion-summary";
            Items = "items";
            SummonerSpells = "summoner-spells";
            Perks = "perks";
            Perkstyles = "perkstyles";
            ContentMetadata = "content-metadata";
            DownloadAllSkin = false;
            AssetsDir = "";
        }
    }
}
