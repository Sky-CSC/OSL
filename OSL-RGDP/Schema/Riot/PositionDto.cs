using Newtonsoft.Json;

namespace OSL_RGDP.Schema.Riot
{
    /// <summary>
    /// Represents a position data transfer object.
    /// </summary>
    /// <remarks>Class generated from the Riot Games API documentation.</remarks>
    public class PositionDto
    {
        /// <summary>
        /// The x coordinate of the position.
        /// </summary>
        [JsonProperty("x")]
        public int X { get; set; }
        /// <summary>
        /// The y coordinate of the position.
        /// </summary>
        [JsonProperty("y")]
        public int Y { get; set; }
    }
}
