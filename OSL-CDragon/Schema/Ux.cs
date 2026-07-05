namespace OSL_CDragon.Schema
{
    /// <summary>
    /// Assets used for the user interface (UX)
    /// </summary>
    public class Ux
    {
        /// <summary>
        /// List of assets for runes
        /// </summary>
        public List<Asset> Runes { get; set; }
        /// <summary>
        /// List of assets for in-game
        /// </summary>
        public List<Asset> InGame { get; set; }
        /// <summary>
        /// List of assets for end-game
        /// </summary>
        public List<Asset> EndGame { get; set; }
        /// <summary>
        /// List of assets for champion select
        /// </summary>
        public List<Asset> ChampSelect { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ux"/> struct.
        /// </summary>
        public Ux()
        {
            Runes = [];
            InGame = [];
            EndGame = [];
            ChampSelect = [];
        }
    }
}
