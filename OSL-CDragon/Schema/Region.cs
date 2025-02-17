namespace OSL_CDragon.Schema
{
    /// <summary>
    /// Represents a region in the game.
    /// </summary>
    internal class Region
    {
        /// <summary>
        /// The name of the region.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The list of champions.
        /// </summary>
        public List<Champion> Champions { get; set; }
        /// <summary>
        /// The list of items.
        /// </summary>
        public List<Item> Items { get; set; }
        /// <summary>
        /// The list of summoner spells.
        /// </summary>
        public List<SummonerSpell> SummonerSpells { get; set; }
        /// <summary>
        /// The list of perks.
        /// </summary>
        public List<Perk> Perks { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Region"/> struct.
        /// </summary>
        public Region()
        {
            Name = string.Empty;
            Champions = [];
            Items = [];
            SummonerSpells = [];
            Perks = [];
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Region"/> struct with region name.
        /// </summary>
        /// <param name="name"></param>
        public Region(string name)
        {
            Name = name;
            Champions = [];
            Items = [];
            SummonerSpells = [];
            Perks = [];
        }
    }
}
