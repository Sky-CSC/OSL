using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using MudBlazor.Utilities;
using OSL_Utils;
using System.Text.RegularExpressions;

namespace OSL_Overlay.Components.Pages.Style
{
    /// <summary>
    /// Style field editor
    /// </summary>
    public partial class StyleFieldEditor
    {
        [Parameter] public string Label { get; set; } = "";
        [Parameter] public string Value { get; set; } = "";
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        [Parameter] public string Type { get; set; } = "color";
        [Parameter] public string DirectoryPath { get; set; } = string.Empty;
        [Parameter] public string HelperText { get; set; } = string.Empty;
        [Parameter] public string BorderColor { get; set; } = "#010A13";
        [Parameter] public int NumericMin { get; set; } = 0;
        [Parameter] public int NumericMax { get; set; } = 5;

        private readonly string[] AvailableFonts =
        [
            "BeaufortforLOL-Bold",
            "Arial",
            "Verdana",
            "Tahoma",
            "Times New Roman"
        ];

        private readonly string[] AvailableTimerDirection =
        [
            "right-to-left",
            "left-to-right",
            "center",
            "center-outside",
        ];

        private readonly string[] AvailableTextAlignDirection =
        [
             "left",
         "right",
 "center",
 "justify",
 "justify-all",
 "start",
 "end",
 "match-parent",
        ];

        // Regex cache (compiled for perf)
        private static readonly Regex LinearGradientRegex =
            new(@"linear-gradient\((?<angle>-?\d+)deg,\s*(?<stops>.+)\)", RegexOptions.Compiled);

        private static readonly Regex RadialGradientRegex =
            new(@"radial-gradient\(circle,\s*(?<stops>.+)\)", RegexOptions.Compiled);

        private static readonly Regex BorderRegex =
            new(@"^(?<prop>border(?:-(left|right|top|bottom))?)\s*:\s*(?<val>.+)$",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly Regex WidthRegex =
            new(@"(?<w>\d+)px", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly Regex StyleRegex =
            new(@"\b(solid|dashed|dotted|double|none|hidden|groove|ridge|inset|outset)\b",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);

        //private static readonly Regex ColorRegex =
        //    new(@"(#([0-9a-fA-F]{3,8})|\brgba?\([^\)]+\)|hsla?\([^\)]+\)|var\([^\)]+\)|\b[a-zA-Z]+\b)",
        //        RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex ColorRegex = new(
            @"(#(?:[0-9a-fA-F]{3}|[0-9a-fA-F]{4}|[0-9a-fA-F]{6}|[0-9a-fA-F]{8})\b" +
            @"|rgba?\([^)]+\)" +
            @"|hsla?\([^)]+\)" +
            @"|var\([^)]+\)" +
            @"|\b(?:aliceblue|antiquewhite|aqua|aquamarine|azure|beige|bisque|black|blanchedalmond|blue|blueviolet|brown|burlywood|cadetblue|chartreuse|chocolate|coral|cornflowerblue|cornsilk|crimson|cyan|darkblue|darkcyan|darkgoldenrod|darkgray|darkgreen|darkgrey|darkkhaki|darkmagenta|darkolivegreen|darkorange|darkorchid|darkred|darksalmon|darkseagreen|darkslateblue|darkslategray|darkslategrey|darkturquoise|darkviolet|deeppink|deepskyblue|dimgray|dimgrey|dodgerblue|firebrick|floralwhite|forestgreen|fuchsia|gainsboro|ghostwhite|gold|goldenrod|gray|green|greenyellow|grey|honeydew|hotpink|indianred|indigo|ivory|khaki|lavender|lavenderblush|lawngreen|lemonchiffon|lightblue|lightcoral|lightcyan|lightgoldenrodyellow|lightgray|lightgreen|lightgrey|lightpink|lightsalmon|lightseagreen|lightskyblue|lightslategray|lightslategrey|lightsteelblue|lightyellow|lime|limegreen|linen|magenta|maroon|mediumaquamarine|mediumblue|mediumorchid|mediumpurple|mediumseagreen|mediumslateblue|mediumspringgreen|mediumturquoise|mediumvioletred|midnightblue|mintcream|mistyrose|moccasin|navajowhite|navy|oldlace|olive|olivedrab|orange|orangered|orchid|palegoldenrod|palegreen|paleturquoise|palevioletred|papayawhip|peachpuff|peru|pink|plum|powderblue|purple|rebeccapurple|red|rosybrown|royalblue|saddlebrown|salmon|sandybrown|seagreen|seashell|sienna|silver|skyblue|slateblue|slategray|slategrey|snow|springgreen|steelblue|tan|teal|thistle|tomato|transparent|turquoise|violet|wheat|white|whitesmoke|yellow|yellowgreen|currentcolor)\b)",
                RegexOptions.IgnoreCase | RegexOptions.Compiled);



        // Background
        private string _backgroundType = "solid";
        private string _bgColor = "#010A13";
        private int _linearAngle = 150;
        private List<GradientStop> _gradientStops =
        [
            new GradientStop { Color = "#010A13", Position = 0 },
            new GradientStop { Color = "#063742", Position = 100 }
        ];

        private string _bgImageUrl = "";
        private string _bgImageSize = "cover";
        private string _bgImageRepeat = "no-repeat";
        private string _bgImagePosition = "center";

        // Border
        private int _borderWidth = 5;
        private string _borderStyle = "solid";
        private string _borderColor = "#0b849e";
        private bool _borderAll = true;
        private bool _borderLeft;
        private bool _borderRight;
        private bool _borderTop;
        private bool _borderBottom;

        private class GradientStop
        {
            public string Color { get; set; } = "#000000";
            public int Position { get; set; } = 0;
        }

        /// <summary>
        /// Hydrate internal state from Value when parent changes
        /// </summary>
        protected override void OnParametersSet()
        {
            if (Type == "background" && !string.IsNullOrWhiteSpace(Value))
            {
                if (Value.StartsWith("linear-gradient"))
                {
                    _backgroundType = "linear";
                    var match = LinearGradientRegex.Match(Value);
                    if (match.Success)
                    {
                        if (int.TryParse(match.Groups["angle"].Value, out var angle))
                            _linearAngle = angle;

                        _gradientStops = match.Groups["stops"].Value
                            .Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Select(ParseGradientStop)
                            .ToList();
                    }
                }
                else if (Value.StartsWith("radial-gradient"))
                {
                    _backgroundType = "radial";
                    var match = RadialGradientRegex.Match(Value);
                    if (match.Success)
                    {
                        _gradientStops = match.Groups["stops"].Value
                            .Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Select(ParseGradientStop)
                            .ToList();
                    }
                }
                else if (Value.StartsWith("url"))
                {
                    _backgroundType = "image";
                    var urlMatch = Regex.Match(Value, @"url\(['""]?(?<url>[^'""\)]+)['""]?\)");
                    if (urlMatch.Success)
                        _bgImageUrl = urlMatch.Groups["url"].Value;

                    if (Value.Contains("cover")) _bgImageSize = "cover";
                    else if (Value.Contains("contain")) _bgImageSize = "contain";
                    else _bgImageSize = "auto";

                    if (Value.Contains("no-repeat")) _bgImageRepeat = "no-repeat";
                    else if (Value.Contains("repeat-x")) _bgImageRepeat = "repeat-x";
                    else if (Value.Contains("repeat-y")) _bgImageRepeat = "repeat-y";
                    else if (Value.Contains("repeat")) _bgImageRepeat = "repeat";

                    if (Value.Contains("top")) _bgImagePosition = "top";
                    else if (Value.Contains("bottom")) _bgImagePosition = "bottom";
                    else if (Value.Contains("left")) _bgImagePosition = "left";
                    else if (Value.Contains("right")) _bgImagePosition = "right";
                    else _bgImagePosition = "center";
                }
                else if (Value == "none")
                {
                    _backgroundType = "none";
                }
                else
                {
                    _backgroundType = "solid";
                    _bgColor = Value.AsMudColor().ToCssString();
                }
            }

            if (Type == "border" && !string.IsNullOrWhiteSpace(Value))
            {
                ParseBorderFromCss(Value);
            }

            if (Type == "image" && !string.IsNullOrWhiteSpace(Value))
            {
                _selectedImage = Value;
            }
        }

        /// <summary>
        /// Parse gradiant color
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static GradientStop ParseGradientStop(string s)
        {
            var parts = s.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return new GradientStop
            {
                Color = parts[0].AsMudColor().ToCssString(),
                Position = parts.Length > 1 && int.TryParse(parts[1].Replace("%", ""), out var pos) ? pos : 0
            };
        }

        // ------------------- FONT -------------------
        /// <summary>
        /// When font change
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        private async Task OnFontChanged(string font)
        {
            Value = font;
            await ValueChanged.InvokeAsync(Value);
        }

        // ------------------- Timer Direction -------------------
        /// <summary>
        /// When font change
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        private async Task OnTimerDirectionChanged(string direction)
        {
            Value = direction;
            await ValueChanged.InvokeAsync(Value);
        }

        // ------------------- Text Align -------------------
        /// <summary>
        /// When font change
        /// </summary>
        /// <param name="font"></param>
        /// <returns></returns>
        private async Task OnTextAlignDirectionChanged(string direction)
        {
            Value = direction;
            await ValueChanged.InvokeAsync(Value);
        }

        // ------------------- COLOR -------------------
        /// <summary>
        /// When color change
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private async Task OnColorChanged(MudColor c)
        {
            Value = c.ToCssString();
            await ValueChanged.InvokeAsync(Value);
        }

        // ------------------- TEXT -------------------
        /// <summary>
        /// When text change
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private async Task OnTextChanged(string newValue)
        {
            Value = newValue;
            await ValueChanged.InvokeAsync(Value);
        }

        // ------------------- SLIDER -------------------
        /// <summary>
        /// When slide change
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private async Task OnSliderChanged(double newValue, string unit)
        {
            var formatted = $"{newValue}{unit}";
            await OnTextChanged(formatted);
        }


        // ------------------- Integer (0-5) -------------------
        /// <summary>
        /// When text change
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private async Task OnIntChanged(int newValue)
        {
            Value = newValue.ToString();
            await ValueChanged.InvokeAsync(Value);
        }

        // ------------------- Chackbox -------------------
        /// <summary>
        /// When checkbox change
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private async Task OnCheckboxChange(bool check)
        {
            Value = check.ToString();
            await ValueChanged.InvokeAsync(Value);
        }

        // ------------------- IMAGE -------------------
        private string _selectedImage = "";

        private class ImageInfo
        {
            public string FileName { get; set; } = "";
            public string Path { get; set; } = "";
        }

        private List<ImageInfo> LoadDirectoryImage(string path)
        {
            List<ImageInfo> imageInfos = [];
            var folder = System.IO.Path.Combine(Env.WebRootPath, path);
            if (System.IO.Directory.Exists(folder))
            {
                var files = System.IO.Directory.GetFiles(folder)
                    .Where(f =>
                    {
                        var ext = System.IO.Path.GetExtension(f).ToLowerInvariant();
                        return ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".svg";
                    });
                foreach (var file in files)
                {
                    imageInfos.Add(new ImageInfo
                    {
                        FileName = System.IO.Path.GetFileName(file),
                        Path = $"{path}/{System.IO.Path.GetFileName(file)}"
                    });
                }
            }
            return imageInfos;

            //imageInfos. = System.IO.Directory.GetFiles(path);
        }

        private async Task OnImageSelected(string? img)
        {
            _selectedImage = img;
            // ici tu peux mettre à jour ton background
            await ValueChanged.InvokeAsync(img);
            //await UpdateImageFromSelection(img);
        }

        /// <summary>
        /// Lorsqu'une image est sélectionnée
        /// </summary>
        private async Task OnImageFileSelected(InputFileChangeEventArgs e)
        {
            var file = e.File;
            if (file == null) return;

            var ext = System.IO.Path.GetExtension(file.Name).ToLowerInvariant();

            // Dossier temporaire
            var tempDir = System.IO.Path.Combine(Env.WebRootPath, "temp");
            if (!System.IO.Directory.Exists(tempDir))
                System.IO.Directory.CreateDirectory(tempDir);

            // Nom unique
            var fileName = $"{Guid.NewGuid()}{ext}";
            var tempPath = System.IO.Path.Combine(tempDir, fileName);

            using var stream = System.IO.File.Create(tempPath);
            await file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024).CopyToAsync(stream);

            // Stocke le chemin relatif
            Value = $"temp/{fileName}";
            await ValueChanged.InvokeAsync(Value);
        }

        // ------------------- BACKGROUND -------------------
        /// <summary>
        /// When type of background change
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private async Task OnBackgroundTypeChanged(string value)
        {
            _backgroundType = value;
            await UpdateBackground();
        }

        /// <summary>
        /// When background color change
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private async Task OnBgColorChanged(MudColor c)
        {
            _bgColor = c.ToCssString();
            await UpdateBackground();
        }

        /// <summary>
        /// When angle of background change
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        private async Task OnLinearAngleChanged(int angle)
        {
            _linearAngle = angle;
            await UpdateBackground();
        }

        /// <summary>
        /// Add color
        /// </summary>
        private void AddGradientStop()
        {
            _gradientStops.Add(new GradientStop { Color = "#FFFFFF", Position = 50 });
            _ = UpdateBackground();
        }

        /// <summary>
        /// Remove color
        /// </summary>
        /// <param name="stop"></param>
        private void RemoveGradientStop(GradientStop stop)
        {
            if (_gradientStops.Count > 2)
            {
                _gradientStops.Remove(stop);
                _ = UpdateBackground();
            }
        }

        /// <summary>
        /// When color change
        /// </summary>
        /// <param name="stop"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private async Task OnGradientStopColorChanged(GradientStop stop, MudColor c)
        {
            stop.Color = c.ToCssString();
            await UpdateBackground();
        }

        /// <summary>
        /// When % of color change
        /// </summary>
        /// <param name="stop"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private async Task OnGradientStopPositionChanged(GradientStop stop, int pos)
        {
            stop.Position = pos;
            await UpdateBackground();
        }

        /// <summary>
        /// When background image change
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private async Task OnBgImageChanged(FocusEventArgs args) => await UpdateBackground();

        /// <summary>
        /// When size of background image change
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private async Task OnBgImageSizeChanged(string value) { _bgImageSize = value; await UpdateBackground(); }

        /// <summary>
        /// When style of background image change
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private async Task OnBgImageRepeatChanged(string value) { _bgImageRepeat = value; await UpdateBackground(); }

        /// <summary>
        /// When position of background image change
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private async Task OnBgImagePositionChanged(string value) { _bgImagePosition = value; await UpdateBackground(); }

        /// <summary>
        /// For user wwwroot path
        /// </summary>
        [Inject] private IWebHostEnvironment Env { get; set; } = default!;

        /// <summary>
        /// When file is selected
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        private async Task OnFileSelected(InputFileChangeEventArgs e)
        {
            var file = e.File;
            if (file == null) return;

            var allowedExt = new[] { ".png", ".jpg", ".jpeg", ".webp" };
            var ext = System.IO.Path.GetExtension(file.Name).ToLowerInvariant();
            if (!allowedExt.Contains(ext)) return;

            var uploads = System.IO.Path.Combine(Env.WebRootPath, "data/backgrounds");
            if (!System.IO.Directory.Exists(uploads))
                System.IO.Directory.CreateDirectory(uploads);

            //OSL_Utils.File.Write(System.IO.Path.Combine(uploads, file.Name), await file.GetBytesAsync());

            var fileName = file.Name;
            var filePath = System.IO.Path.Combine(uploads, fileName);

            try
            {
                using var stream = System.IO.File.Create(filePath);
                await file.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024).CopyToAsync(stream);

                _bgImageUrl = $"data/backgrounds/{fileName}";
                await UpdateBackground();
            }
            catch
            {
                // Optional: log error
            }
        }

        /// <summary>
        /// Update background css
        /// </summary>
        /// <returns></returns>
        private async Task UpdateBackground()
        {
            string css = _backgroundType switch
            {
                "solid" => _bgColor,
                "linear" => $"linear-gradient({_linearAngle}deg, {string.Join(", ", _gradientStops.Select(s => $"{s.Color} {s.Position}%"))})",
                "radial" => $"radial-gradient(circle, {string.Join(", ", _gradientStops.Select(s => $"{s.Color} {s.Position}%"))})",
                "image" when !string.IsNullOrEmpty(_bgImageUrl) => BuildImageBackgroundCss(),
                "none" => "none",
                _ => ""
            };

            await ValueChanged.InvokeAsync(css);
        }

        /// <summary>
        /// Build css background image
        /// </summary>
        /// <returns></returns>
        private string BuildImageBackgroundCss()
        {
            var css = $"url('{_bgImageUrl}') {_bgImageRepeat} {_bgImagePosition}";
            css += _bgImageSize switch
            {
                "cover" => " / cover",
                "contain" => " / contain",
                _ => ""
            };
            return css;
        }

        // ------------------- BORDER -------------------
        /// <summary>
        /// When border width change
        /// </summary>
        /// <param name="w"></param>
        /// <returns></returns>
        private async Task OnBorderWidthChanged(int w)
        {
            _borderWidth = w;
            await UpdateBorder();
        }

        /// <summary>
        /// When border style change
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        private async Task OnBorderStyleChanged(string style)
        {
            _borderStyle = style;
            await UpdateBorder();
        }

        /// <summary>
        /// When border color change
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private async Task OnBorderColorChanged(MudColor c)
        {
            _borderColor = c.ToCssString();
            await UpdateBorder();
        }

        /// <summary>
        /// Update css border 
        /// </summary>
        /// <returns></returns>
        private async Task UpdateBorder()
        {
            var css = "";

            if (_borderAll)
            {
                css = $"border: {_borderWidth}px {_borderStyle} {_borderColor};";
            }
            else
            {
                if (_borderLeft) css += $"border-left: {_borderWidth}px {_borderStyle} {_borderColor}; ";
                if (_borderRight) css += $"border-right: {_borderWidth}px {_borderStyle} {_borderColor}; ";
                if (_borderTop) css += $"border-top: {_borderWidth}px {_borderStyle} {_borderColor}; ";
                if (_borderBottom) css += $"border-bottom: {_borderWidth}px {_borderStyle} {_borderColor}; ";
            }

            await ValueChanged.InvokeAsync(css.Trim());
        }

        /// <summary>
        /// When side all change
        /// </summary>
        /// <param name="all"></param>
        /// <returns></returns>
        private async Task OnBorderAllChanged(bool all)
        {
            _borderAll = all;
            if (all)
            {
                _borderLeft = _borderRight = _borderTop = _borderBottom = false;
            }
            await UpdateBorder();
        }

        /// <summary>
        /// When side change
        /// </summary>
        /// <param name="side"></param>
        /// <param name="isChecked"></param>
        /// <returns></returns>
        private async Task OnBorderSideChanged(string side, bool isChecked)
        {
            switch (side)
            {
                case "left": _borderLeft = isChecked; break;
                case "right": _borderRight = isChecked; break;
                case "top": _borderTop = isChecked; break;
                case "bottom": _borderBottom = isChecked; break;
            }

            if (_borderLeft || _borderRight || _borderTop || _borderBottom)
                _borderAll = false;

            await UpdateBorder();
        }

        /// <summary>
        /// Parse border from css
        /// </summary>
        /// <param name="css"></param>
        private void ParseBorderFromCss(string css)
        {
            _borderAll = true;
            _borderLeft = _borderRight = _borderTop = _borderBottom = false;

            if (string.IsNullOrWhiteSpace(css)) return;

            var decls = css.Split(';', StringSplitOptions.RemoveEmptyEntries)
                           .Select(d => d.Trim())
                           .Where(d => !string.IsNullOrEmpty(d));

            foreach (var d in decls)
            {
                var m = BorderRegex.Match(d);
                if (!m.Success) continue;

                var prop = m.Groups["prop"].Value.ToLowerInvariant();
                var val = m.Groups["val"].Value.Trim();

                var widthMatch = WidthRegex.Match(val);
                //Console.WriteLine(widthMatch);
                if (widthMatch.Success && int.TryParse(widthMatch.Groups["w"].Value, out var px))
                    _borderWidth = px;

                var styleMatch = StyleRegex.Match(val);
                //Console.WriteLine(styleMatch);
                if (styleMatch.Success) _borderStyle = styleMatch.Value;

                var colorMatch = ColorRegex.Match(val);
                if (colorMatch.Success)
                    _borderColor = colorMatch.Value.AsMudColor().ToCssString();

                switch (prop)
                {
                    case "border": _borderAll = true; break;
                    case "border-left": _borderLeft = true; _borderAll = false; break;
                    case "border-right": _borderRight = true; _borderAll = false; break;
                    case "border-top": _borderTop = true; _borderAll = false; break;
                    case "border-bottom": _borderBottom = true; _borderAll = false; break;
                }
            }
        }
    }
}
