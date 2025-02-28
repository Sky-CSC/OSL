namespace OSL_CDragon.Schema
{
    /// <summary>
    /// List of assets for each dragon
    /// </summary>
    internal class Dragon
    {
        /// <summary>
        /// List of assets for the Cloud dragon
        /// </summary>
        public List<Asset> Cloud { get; set; }
        /// <summary>
        /// List of assets for the Chemtech dragon
        /// </summary>
        public List<Asset> Chemtech { get; set; }
        /// <summary>
        /// List of assets for the Mountain dragon
        /// </summary>
        public List<Asset> Mountain { get; set; }
        /// <summary>
        /// List of assets for the Infernal dragon
        /// </summary>
        public List<Asset> Infernal { get; set; }
        /// <summary>
        /// List of assets for the Hextech dragon
        /// </summary>
        public List<Asset> Hextech { get; set; }
        /// <summary>
        /// List of assets for the Ocean dragon
        /// </summary>
        public List<Asset> Ocean { get; set; }
        /// <summary>
        /// List of assets for the Elder dragon
        /// </summary>
        public List<Asset> Elder { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dragon"/> struct.
        /// </summary>
        public Dragon()
        {
            Cloud = [];
            Chemtech = [];
            Mountain = [];
            Infernal = [];
            Hextech = [];
            Ocean = [];
            Elder = [];
        }
    }
}
