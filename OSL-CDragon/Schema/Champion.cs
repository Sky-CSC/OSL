namespace OSL_CDragon.Schema
{
    /// <summary>
    /// Data composed of a champion's id, name, alias, square portrait path, sounds, roles, skins, and stats.
    /// </summary>
    internal class Champion
    {
        /// <summary>
        /// The champion's id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The champion's name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The champion's alias.
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// The champion's square portrait path.
        /// </summary>
        public string SquarePortraitPath { get; set; }
        /// <summary>
        /// The champion's choose, ban and fx sounds.
        /// </summary>
        public Sound Sounds { get; set; }
        /// <summary>
        /// The champion's roles, top, jungle, mid, adc, support.
        /// </summary>
        public List<string> Roles { get; set; }
        /// <summary>
        /// The champion's skins.
        /// </summary>
        public List<Skin> Skins { get; set; }
        /// <summary>
        /// The champion's stats.
        /// </summary>
        public Stat Stats { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Champion"/> struct.
        /// </summary>
        public Champion()
        {
            Id = -42;
            Name = string.Empty;
            Alias = string.Empty;
            SquarePortraitPath = string.Empty;
            Sounds = new Sound();
            Roles = [];
            Skins = [];
            Stats = new Stat();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Champion"/> struct with id.
        /// </summary>
        /// <param name="id">Id of champion</param>
        public Champion(int id)
        {
            Id = id;
            Name = string.Empty;
            Alias = string.Empty;
            SquarePortraitPath = string.Empty;
            Sounds = new Sound();
            Roles = [];
            Skins = [];
            Stats = new Stat();
        }
    }
}
