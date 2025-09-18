using MudBlazor.Utilities;
using System.Globalization;

namespace OSL_Utils
{

    public static class ColorExtensions
    {
        // string -> MudColor (sécurisé)
        public static MudColor AsMudColor(this string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return new MudColor("#ffffff");
            try
            {
                return new MudColor(s!);
            }
            catch
            {
                return new MudColor("#ffffff");
            }
        }

        // MudColor -> css string: "#RRGGBB" ou "rgba(r,g,b,a)"
        public static string ToCssString(this MudColor c)
        {
            if (c.A >= 255)
                return $"#{c.R:X2}{c.G:X2}{c.B:X2}";

            double alpha = c.A / 255.0;
            string a = alpha.ToString("0.###", CultureInfo.InvariantCulture);
            return $"rgba({c.R},{c.G},{c.B},{a})";
        }

        // retourne "#RRGGBB"
        public static string MudColorToHex(MudColor c)
        {
            return $"#{c.R:X2}{c.G:X2}{c.B:X2}";
        }

        // retourne "rgba(r,g,b,a)" où a est en 0..1 (format invariant)
        public static string MudColorToRgba(MudColor c)
        {
            double alpha = c.A / 255.0;
            string alphaStr = alpha.ToString("0.###", CultureInfo.InvariantCulture);
            return $"rgba({c.R},{c.G},{c.B},{alphaStr})";
        }

        // optionnel : parse sécurisé (renvoie true si possible)
        public static bool TryParseMudColor(string? input, out MudColor result)
        {
            result = new MudColor("#063742");
            if (string.IsNullOrWhiteSpace(input)) return false;
            try
            {
                result = new MudColor(input);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
