using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using OSL_Utils;

namespace OSL_Overlay.Components.Pages.Style
{
    /// <summary>
    /// Style field editor
    /// </summary>
    public partial class StyleFieldEditor
    {
        /// <summary>
        /// Label
        /// </summary>
        [Parameter] public string Label { get; set; } = "";

        /// <summary>
        /// Value
        /// </summary>
        [Parameter] public string Value { get; set; } = "";

        /// <summary>
        /// Value change
        /// </summary>
        [Parameter] public EventCallback<string> ValueChanged { get; set; }

        /// <summary>
        /// Type, color, font, border, background
        /// </summary>
        [Parameter] public string Type { get; set; } = "color";

        /// <summary>
        /// Default font avalable
        /// </summary>
        private readonly string[] AvailableFonts =
        [
            "BeaufortforLOL-Bold",
            "Arial",
            "Verdana",
            "Tahoma",
            "Times New Roman"
        ];

        // Background
        private string _backgroundType = "solid";
        private string _bgColor = "#010A13";
        private string _bgStart = "#010A13";
        private string _bgEnd = "#063742";
        private int _linearAngle = 150;

        // Border
        private int _borderWidth = 5;
        private string _borderStyle = "solid";
        private string _borderColor = "#0b849e";

        protected override void OnInitialized()
        {
            if (Type == "background" && !string.IsNullOrWhiteSpace(Value))
            {
                if (Value.StartsWith("linear")) _backgroundType = "linear";
                else if (Value.StartsWith("radial")) _backgroundType = "radial";
                else _backgroundType = "solid";
                _bgColor = Value;
            }

            if (Type == "border" && !string.IsNullOrWhiteSpace(Value))
            {
                var parts = Value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 3)
                {
                    if (int.TryParse(parts[0].Replace("px", ""), out var px))
                        _borderWidth = px;
                    _borderStyle = parts[1];
                    _borderColor = parts[2];
                }
            }
        }

        /// <summary>
        /// When font change
        /// </summary>
        /// <param name="font">Font name</param>
        /// <returns></returns>
        private async Task OnFontChanged(string font)
        {
            Value = font;
            await ValueChanged.InvokeAsync(Value);
        }

        /// <summary>
        /// When color change
        /// </summary>
        /// <param name="c">Color</param>
        /// <returns></returns>
        private async Task OnColorChanged(MudColor c)
        {
            Value = c.ToCssString();
            await ValueChanged.InvokeAsync(Value);
        }

        /// <summary>
        /// When background change
        /// </summary>
        /// <param name="value">Background</param>
        /// <returns></returns>
        private async Task OnBackgroundTypeChanged(string value)
        {
            _backgroundType = value;
            await UpdateBackground(); // déclenche la mise à jour immédiate
        }

        /// <summary>
        /// When background color change
        /// </summary>
        /// <param name="c">Color</param>
        /// <returns></returns>
        private async Task OnBgColorChanged(MudColor c)
        {
            _bgColor = c.ToCssString();
            await UpdateBackground();
        }

        /// <summary>
        /// When background color change for linear or radial
        /// </summary>
        /// <param name="c">Color</param>
        /// <returns></returns>
        private async Task OnBgStartChanged(MudColor c)
        {
            _bgStart = c.ToCssString();
            await UpdateBackground();
        }

        /// <summary>
        /// When background color change for linear or radial
        /// </summary>
        /// <param name="c">Color</param>
        /// <returns></returns>
        private async Task OnBgEndChanged(MudColor c)
        {
            _bgEnd = c.ToCssString();
            await UpdateBackground();
        }
        /// <summary>
        /// When background linear change
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        private async Task OnLinearAngleChanged(int angle)
        {
            _linearAngle = angle;
            await UpdateBackground();
        }

        /// <summary>
        /// Update background
        /// </summary>
        /// <returns></returns>
        private async Task UpdateBackground()
        {
            if (_backgroundType == "solid")
                await ValueChanged.InvokeAsync(_bgColor);
            else if (_backgroundType == "linear")
                await ValueChanged.InvokeAsync($"linear-gradient({_linearAngle}deg, {_bgStart} 0%, {_bgEnd} 100%)");
            else if (_backgroundType == "radial")
                await ValueChanged.InvokeAsync($"radial-gradient(circle, {_bgStart} 0%, {_bgEnd} 100%)");
        }

        /// <summary>
        /// When border width change
        /// </summary>
        /// <param name="w">Width</param>
        /// <returns></returns>
        private async Task OnBorderWidthChanged(int w)
        {
            _borderWidth = w;
            await UpdateBorder();
        }

        /// <summary>
        /// When border style change
        /// </summary>
        /// <param name="style">Style</param>
        /// <returns></returns>
        private async Task OnBorderStyleChanged(string style)
        {
            _borderStyle = style;
            await UpdateBorder();
        }

        /// <summary>
        /// When border color change
        /// </summary>
        /// <param name="c">Color</param>
        /// <returns></returns>
        private async Task OnBorderColorChanged(MudColor c)
        {
            _borderColor = c.ToCssString();
            await UpdateBorder();
        }

        /// <summary>
        /// Update border
        /// </summary>
        /// <returns></returns>
        private async Task UpdateBorder()
        {
            await ValueChanged.InvokeAsync($"{_borderWidth}px {_borderStyle} {_borderColor}");
        }
    }
}
