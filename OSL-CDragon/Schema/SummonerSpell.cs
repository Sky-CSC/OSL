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
        public int Id { get; set; }
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
            Id = -42;
            Name = string.Empty;
            IconPath = string.Empty;
        }
    }
}
