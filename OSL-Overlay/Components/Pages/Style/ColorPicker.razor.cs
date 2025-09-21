using Microsoft.AspNetCore.Components;
using MudBlazor.Utilities;
using OSL_Utils;

namespace OSL_Overlay.Components.Pages.Style
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

        private MudColor _color = new MudColor("#063742");
        private string _cssColor = "#063742";
        private string _displayCode = "#063742";
        private bool _open = false;

        /// <summary>
        /// If value don't have color set it
        /// </summary>
        protected override void OnInitialized()
        {
            _color = Value ?? new MudColor("#063742");
            UpdateCodes();
        }

        /// <summary>
        /// Set color
        /// </summary>
        protected override void OnParametersSet()
        {
            if (Value is not null && Value.ToString() != _color.ToString())
            {
                _color = Value;
                UpdateCodes();
            }
        }

        /// <summary>
        /// When color change
        /// </summary>
        /// <param name="newColor">Color</param>
        /// <returns></returns>
        private async Task OnPickerValueChanged(MudColor newColor)
        {
            _color = newColor;
            UpdateCodes();

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

        /// <summary>
        /// Update color
        /// </summary>
        private void UpdateCodes()
        {
            _cssColor = ColorExtensions.MudColorToRgba(_color);
            _displayCode = _color.A < 255
                ? ColorExtensions.MudColorToRgba(_color)
                : ColorExtensions.MudColorToHex(_color);
        }
    }
}
