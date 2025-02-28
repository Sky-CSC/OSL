namespace OSL_CDragon.Schema
{
    /// <summary>
    /// Data structure for patch data
    /// </summary>
    internal class Data
    {
        /// <summary>
        /// List of patches
        /// </summary>
        public List<Patch> Patchs { get; set; }

        /// <summary>
        /// Assets of top, jungle, mid, adc, and support positions
        /// </summary>
        public Position Positions { get; set; }

        /// <summary>
        /// Assets of epic monsters, dragon, baron, herald, void grubs, Atakhans
        /// </summary>
        public EpicMonster EpicMonsters { get; set; }

        /// <summary>
        /// List of fonts
        /// </summary>
        public List<Asset> Fonts { get; set; }

        public Ux Ux { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Data"/> struct.
        /// </summary>
        public Data()
        {
            Patchs = [];
            Positions = new();
            EpicMonsters = new();
            Fonts = [];
        }
    }
}
