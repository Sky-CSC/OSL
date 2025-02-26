namespace OSL_CDragon.Schema
{
    /// <summary>
    /// Represents a perk in the game.
    /// </summary>
    internal class Perk
    {
        /// <summary>
        /// The unique identifier of the perk.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of the perk.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The path to the perk's icon.
        /// </summary>
        public string IconPath { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Perk"/> struct.    
        /// </summary>
        public Perk()
        {
            Id = -42;
            Name = string.Empty;
            IconPath = string.Empty;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Perk"/> struct.
        /// </summary>
        /// <param name="id">Id of perk</param>
        /// <param name="name">Name of perk</param>
        /// <param name="iconPath">Icone path of perk</param>
        public Perk(int id, string name, string iconPath)
        {
            Id = id;
            Name = name;
            IconPath = iconPath;
        }
    }
}
