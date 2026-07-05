using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Utilities;
using OSL_Utils;

namespace OSL_UI.Style
{
    /// <summary>
    /// Color picker component
    /// </summary>
    public partial class ColorPicker
    {
        /// <summary>
        /// Label
        /// </summary>
        [Parameter] public string Label { get; set; } = "Color";

        /// <summary>
        /// Color
        /// </summary>
        [Parameter] public MudColor Value { get; set; } = new MudColor("#063742");

        /// <summary>
        /// If value change
        /// </summary>
        [Parameter] public EventCallback<MudColor> ValueChanged { get; set; }

        /// <summary>
        /// Info text to display
        /// </summary>
        [Parameter] public string? HelperText { get; set; }

        // Css color get from Value
        private string CssColor => ColorExtensions.ToCssString(Value);

        // Color display
        private string DisplayCode => Value.A < 255
            ? ColorExtensions.ToCssString(Value)
            : ColorExtensions.MudColorToHex(Value);

        // Open or close color picker
        private bool _open = false;

        /// <summary>
        /// When color change
        /// </summary>
        /// <param name="newColor">Color</param>
        /// <returns></returns>
        private async Task OnPickerValueChanged(MudColor newColor)
        {
            if (ValueChanged.HasDelegate)
                await ValueChanged.InvokeAsync(newColor);
        }

        /// <summary>
        /// Display or not color picker
        /// </summary>
        private void TogglePicker()
        {
            _open = !_open; // toggle simple open/close
        }
    }
}
