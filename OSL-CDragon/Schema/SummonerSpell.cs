namespace OSL_CDragon.Schema
{
    /// <summary>
    /// Represents a summoner spell in the game.
    /// </summary>
    internal class SummonerSpell
    {
        /// <summary>
        /// The unique identifier of the summoner spell.
        /// </summary>
        public uint Id { get; set; }
        /// <summary>
        /// The name of the summoner spell.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The path to the summoner spell's icon.
        /// </summary>
        public string IconPath { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="SummonerSpell"/> struct.
        /// </summary>
        public SummonerSpell()
        {
            Id = 0;
            Name = string.Empty;
            IconPath = string.Empty;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="SummonerSpell"/> struct with id, name and icon path.
        /// </summary>
        /// <param name="id">Id of summoner spell</param>
        /// <param name="name">Name of summoner spell</param>
        /// <param name="iconPath">Icone path of summoner spell</param>
        public SummonerSpell(uint id, string name, string iconPath)
        {
            Id = id;
            Name = name;
            IconPath = iconPath;
        }
    }
}
