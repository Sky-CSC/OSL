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
        /// Initializes a new instance of the <see cref="Data"/> struct.
        /// </summary>
        public Data()
        {
            Patchs = [];
        }
    }
}
