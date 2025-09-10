namespace OSL_CDragon.Schema
{
    /// <summary>
    /// Represents a sound of champion.
    /// </summary>
    internal class Sound
    {
        /// <summary>
        /// The path to the sound of champion's choose.
        /// </summary>
        public string ChoosePath { get; set; }
        /// <summary>
        /// The path to the sound of champion's ban.
        /// </summary>
        public string BanPath { get; set; }
        /// <summary>
        /// The path to the sound of champion's sfx.
        /// </summary>
        public string SfxPath { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Sound"/> struct.
        /// </summary>
        public Sound()
        {
            ChoosePath = string.Empty;
            BanPath = string.Empty;
            SfxPath = string.Empty;
        }
    }
}
