using MudBlazor.Utilities;

namespace OSL_Utils
{
    /// <summary>
    /// Color extension for manage color type to set it in hexa
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// String to mud color
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static MudColor AsMudColor(this string? s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return new MudColor("#ffffff");
            try
            {
                return new MudColor(s!);
            }
            catch
            {
                return new MudColor("#ffffff");
            }
        }

        /// <summary>
        /// MudColor to css string "#RRGGBB" or "#RRGGBBAA"
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string ToCssString(this MudColor c)
        {
            // Not alpha
            if (c.A >= 255)
                return $"#{c.R:X2}{c.G:X2}{c.B:X2}";

            // With alpha
            return $"#{c.R:X2}{c.G:X2}{c.B:X2}{c.A:X2}";
        }

        /// <summary>
        /// Mud color to hexa
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string MudColorToHex(MudColor c)
        {
            return $"#{c.R:X2}{c.G:X2}{c.B:X2}";
        }

        /// <summary>
        /// MudColor to hewa with alpha
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string MudColorToHexaWithAlpha(MudColor c)
        {
            return $"#{c.R:X2}{c.G:X2}{c.B:X2}{c.A:X2}";
        }

        /// <summary>
        /// Parse color and return hexa color
        /// </summary>
        /// <param name="input"></param>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static bool TryParseMudColor(string? input, out string hex)
        {
            hex = "#FFFFFF";
            if (string.IsNullOrWhiteSpace(input)) return false;

            try
            {
                var mc = new MudColor(input);

                // Return hexa with alpha if need
                hex = mc.ToCssString();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
