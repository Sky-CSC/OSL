namespace OSL_CDragon.Schema
{
    /// <summary>
    /// Represents a patch.
    /// </summary>
    public class Patch
    {
        /// <summary>
        /// The patch number. ex : 15.3.6540407+branch.releases-15-3.content.release
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// The short patch number. ex : 15.3
        /// </summary>
        public string ShortNumber { get; set; }
        /// <summary>
        /// The regions that the patch is available in.
        /// </summary>
        public List<Region> Regions { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Patch"/> struct.
        /// </summary>
        public Patch()
        {
            Number = string.Empty;
            ShortNumber = string.Empty;
            Regions = [];
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Patch"/> struct with patch number and short number.
        /// </summary>
        /// <param name="number">Patch number</param>
        /// <param name="shortNumber">Patch short number</param>
        public Patch(string number, string shortNumber)
        {
            Number = number;
            ShortNumber = shortNumber;
            Regions = [];
        }
    }
}
