namespace OSL_Overlay.Components.Common;

/// <summary>
/// Colors of the two sides, used everywhere in the management pages (blue team / red team).
/// </summary>
public static class TeamColors
{
    public const string Blue = "#0B849E";
    public const string Red = "#BE1E37";

    /// <summary>Accent of a side: 0 = blue, 1 = red.</summary>
    public static string Of(int side) => side == 0 ? Blue : Red;
}
