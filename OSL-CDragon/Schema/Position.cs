namespace OSL_CDragon.Schema
{
    /// <summary>
    /// Represents a position in the game.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// List of top lane position assets
        /// </summary>
        public List<Asset> TopPath { get; set; }
        /// <summary>
        /// List of jungle position assets
        /// </summary>
        public List<Asset> JunglePath { get; set; }
        /// <summary>
        /// List of mid lane position assets
        /// </summary>
        public List<Asset> MiddlePath { get; set; }
        /// <summary>
        /// List of adc position assets
        /// </summary>
        public List<Asset> AdcPath { get; set; }
        /// <summary>
        /// List of support position assets
        /// </summary>
        public List<Asset> SupportPath { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> struct.
        /// </summary>
        public Position()
        {
            TopPath = [];
            JunglePath = [];
            MiddlePath = [];
            AdcPath = [];
            SupportPath = [];
        }
    }
}
