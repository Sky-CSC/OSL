namespace OSL_CDragon.Schema
{
    /// <summary>
    /// Represents a stat of champion.
    /// </summary>
    public class Stat
    {
        /// <summary>
        /// The percent of pick.
        /// </summary>
        public int Pick { get; set; }
        /// <summary>
        /// The percent of ban.
        /// </summary>
        public int Ban { get; set; }
        /// <summary>
        /// The percent of win.
        /// </summary>
        public int Win { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Stat"/> class.
        /// </summary>
        public Stat()
        {
            Pick = 0;
            Ban = 0;
            Win = 0;
        }
    }
}
