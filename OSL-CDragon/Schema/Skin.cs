namespace OSL_CDragon.Schema
{
    /// <summary>
    /// Represents a skin.
    /// </summary>
    internal class Skin
    {
        /// <summary>
        /// The unique identifier of the Skin.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// If is the base skin.
        /// </summary>
        public bool IsBase { get; set; }
        /// <summary>
        /// The path to the splash art of the skin.
        /// </summary>
        public string Splashe { get; set; }
        /// <summary>
        /// The path to the uncentered splash art of the skin.
        /// </summary>
        public string SplasheUncentered { get; set; }
        /// <summary>
        /// The path to the tile of the skin.
        /// </summary>
        public string Tile { get; set; }
        /// <summary>
        /// The path to the load screen of the skin.
        /// </summary>
        public string LoadScreen { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Skin"/> struct.
        /// </summary>
        public Skin()
        {
            Id = -42;
            IsBase = false;
            Splashe = string.Empty;
            SplasheUncentered = string.Empty;
            Tile = string.Empty;
            LoadScreen = string.Empty;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Skin"/> struct with skin id and if is a base skin.
        /// </summary>
        /// <param name="id">Id of skin</param>
        /// <param name="isBase">If skin is base skin</param>
        public Skin(int id, bool isBase)
        {
            Id = id;
            IsBase = isBase;
            Splashe = string.Empty;
            SplasheUncentered = string.Empty;
            Tile = string.Empty;
            LoadScreen = string.Empty;
        }
    }
}
