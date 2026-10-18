using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace OSL_UI.Style
{
    /// <summary>
    /// Manage the files of a style directory: choose the file in use, save it, save as a new file,
    /// rename, duplicate and delete. "default.json" is protected (it can be selected and duplicated only).
    /// </summary>
    public partial class StyleManager
    {
        /// <summary>Title of the component (what kind of file is managed)</summary>
        [Parameter] public string Label { get; set; } = "Style file";
        [Parameter] public string RelativePath { get; set; } = string.Empty;

        /// <summary>
        /// Actual file selected
        /// </summary>
        [Parameter] public string? CurrentFile { get; set; }

        /// <summary>
        /// Write the current settings in the file whose full path is given
        /// </summary>
        [Parameter] public EventCallback<string> OnSave { get; set; }

        /// <summary>
        /// A file is selected: load it
        /// </summary>
        [Parameter] public EventCallback<string> OnFileSelected { get; set; }

        /// <summary>Prefix of the name suggested for a new file</summary>
        [Parameter] public string FilePrefix { get; set; } = "style";

        /// <summary>
        /// True when the current settings differ from the selected file. Optional: when set, the user is warned
        /// before the changes would be lost and "Save" is highlighted.
        /// </summary>
        [Parameter] public bool Modified { get; set; }

        [Parameter] public bool HideRename { get; set; } = false;
        [Parameter] public bool HideDelete { get; set; } = false;
        [Parameter] public bool HideSelect { get; set; } = false;
        [Parameter] public bool HideDuplicate { get; set; } = false;
        [Parameter] public bool HideSave { get; set; } = false;

        private const string ProtectedFile = "default.json";

        private enum EditMode { None, SaveAs, Rename }

        private List<string> _files = new();
        private EditMode _mode = EditMode.None;
        private string _nameInput = string.Empty;
        private string? _error;

        // Changed to rebuild the file list when a selection is cancelled (the list would keep showing it)
        private int _selectKey;

        // Path of wwwroot
        private string FullPath => OSL_Utils.Path.Combine("./wwwroot", RelativePath);

        private string? SelectedName => string.IsNullOrEmpty(CurrentFile) ? null : Path.GetFileName(CurrentFile);

        private static bool IsProtected(string? fileName) =>
            string.Equals(fileName, ProtectedFile, StringComparison.OrdinalIgnoreCase);

        private static string Display(string? fileName) =>
            fileName is null ? string.Empty : Path.GetFileNameWithoutExtension(fileName);

        private bool CannotSave => HideSave || SelectedName is null || IsProtected(SelectedName);
        private bool CannotRename => HideRename || SelectedName is null || IsProtected(SelectedName) || Modified || _mode != EditMode.None;
        private bool CannotDelete => HideDelete || SelectedName is null || IsProtected(SelectedName) || _mode != EditMode.None;
        private bool CannotDuplicate => HideDuplicate || SelectedName is null || _mode != EditMode.None;

        private string SaveTooltip =>
            SelectedName is null ? "Select a file first"
            : IsProtected(SelectedName) ? "The default file is protected: use \"Save as new\""
            : $"Overwrite '{Display(SelectedName)}' with the current settings";

        private string RenameTooltip =>
            IsProtected(SelectedName) ? "The default file cannot be renamed"
            : Modified ? "Save or discard the changes before renaming"
            : "Rename the selected file";

        private string DeleteTooltip =>
            IsProtected(SelectedName) ? "The default file cannot be deleted" : "Delete the selected file";

        protected override void OnParametersSet() => LoadFiles();

        /// <summary>
        /// Load all files of the directory (default first, then alphabetical)
        /// </summary>
        private void LoadFiles()
        {
            if (!Directory.Exists(FullPath))
            {
                _files = new();
                return;
            }

            _files = Directory.EnumerateFiles(FullPath, "*.json")
                .Select(Path.GetFileName)
                .Where(f => f != null)
                .Select(f => f!)
                .OrderBy(f => IsProtected(f) ? 0 : 1)
                .ThenBy(f => f, StringComparer.OrdinalIgnoreCase)
                .ToList();

            if (_files.Count > 0 && string.IsNullOrEmpty(CurrentFile))
            {
                string selectedFile = _files.FirstOrDefault(IsProtected) ?? _files[0];
                CurrentFile = OSL_Utils.Path.Combine(FullPath, selectedFile);
                _ = OnFileSelected.InvokeAsync(CurrentFile);
            }
        }

        // ------------------- Select -------------------
        private async Task SelectFile(string? fileName)
        {
            if (string.IsNullOrEmpty(fileName) || fileName == SelectedName)
                return;

            if (Modified && !await ConfirmAsync("Unsaved changes", "The changes that are not saved will be lost. Continue?", "Discard changes"))
            {
                _selectKey++;
                return;
            }

            CancelMode();
            string fullPath = OSL_Utils.Path.Combine(FullPath, fileName);
            CurrentFile = fullPath;
            await OnFileSelected.InvokeAsync(fullPath);
        }

        // ------------------- Save -------------------
        private async Task SaveSelectedAsync()
        {
            if (CannotSave || SelectedName is null)
                return;

            string filePath = OSL_Utils.Path.Combine(FullPath, SelectedName);
            await OnSave.InvokeAsync(filePath);
            CurrentFile = filePath;
            Snackbar.Add($"'{Display(SelectedName)}' saved.", Severity.Success);
        }

        // ------------------- Save as new / rename -------------------
        private void StartMode(EditMode mode)
        {
            _mode = mode;
            _error = null;
            _nameInput = mode == EditMode.Rename
                ? Display(SelectedName)
                : $"{FilePrefix}-{DateTime.Now:yyyyMMdd-HHmm}";
        }

        private void CancelMode()
        {
            _mode = EditMode.None;
            _error = null;
        }

        private async Task ConfirmModeAsync()
        {
            if (!TryBuildFileName(_nameInput, out string fileName, out _error))
            {
                // Renaming a file with its own name: nothing to do
                if (_mode == EditMode.Rename && string.Equals(fileName, SelectedName, StringComparison.OrdinalIgnoreCase))
                    CancelMode();
                return;
            }

            if (_mode == EditMode.SaveAs)
                await SaveAsNewAsync(fileName);
            else if (_mode == EditMode.Rename)
                await RenameSelectedAsync(fileName);
        }

        private async Task SaveAsNewAsync(string fileName)
        {
            Directory.CreateDirectory(FullPath);
            string filePath = OSL_Utils.Path.Combine(FullPath, fileName);

            await OnSave.InvokeAsync(filePath);
            CurrentFile = filePath;
            CancelMode();
            LoadFiles();
            Snackbar.Add($"Saved as '{Display(fileName)}'.", Severity.Success);
        }

        private async Task RenameSelectedAsync(string newName)
        {
            if (SelectedName is null)
                return;

            string oldPath = OSL_Utils.Path.Combine(FullPath, SelectedName);
            string newPath = OSL_Utils.Path.Combine(FullPath, newName);
            try
            {
                File.Move(oldPath, newPath);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                _error = ex.Message;
                return;
            }

            // The page must know the new path of the file in use
            CurrentFile = newPath;
            CancelMode();
            LoadFiles();
            await OnFileSelected.InvokeAsync(newPath);
            Snackbar.Add($"Renamed to '{Display(newName)}'.", Severity.Success);
        }

        /// <summary>
        /// Build a valid file name from what the user typed
        /// </summary>
        private bool TryBuildFileName(string input, out string fileName, out string? error)
        {
            string name = (input ?? string.Empty).Trim();
            if (name.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                name = name[..^5].Trim();

            fileName = name + ".json";
            error = null;

            if (name.Length == 0)
                error = "Enter a name.";
            else if (name.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0 || name is "." or "..")
                error = "This name contains characters that are not allowed.";
            else if (File.Exists(OSL_Utils.Path.Combine(FullPath, fileName)))
                error = "A file with this name already exists.";

            return error is null;
        }

        // ------------------- Duplicate -------------------
        private Task DuplicateAsync()
        {
            if (CannotDuplicate || SelectedName is null)
                return Task.CompletedTask;

            string sourcePath = OSL_Utils.Path.Combine(FullPath, SelectedName);
            if (!File.Exists(sourcePath))
                return Task.CompletedTask;

            string nameWithoutExt = Path.GetFileNameWithoutExtension(SelectedName);
            string ext = Path.GetExtension(SelectedName);
            string newName = $"{nameWithoutExt}-copy{ext}";
            string destPath = OSL_Utils.Path.Combine(FullPath, newName);

            int counter = 1;
            while (File.Exists(destPath))
            {
                newName = $"{nameWithoutExt}-copy{counter}{ext}";
                destPath = OSL_Utils.Path.Combine(FullPath, newName);
                counter++;
            }

            File.Copy(sourcePath, destPath);
            LoadFiles();
            Snackbar.Add($"Duplicated as '{Display(newName)}'. Select it to edit it.", Severity.Info);
            return Task.CompletedTask;
        }

        // ------------------- Delete -------------------
        private async Task DeleteAsync()
        {
            if (CannotDelete || SelectedName is null)
                return;

            string name = SelectedName;
            if (!await ConfirmAsync("Delete file", $"Delete '{Display(name)}'? This cannot be undone.", "Delete"))
                return;

            try
            {
                string filePath = OSL_Utils.Path.Combine(FullPath, name);
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                Snackbar.Add($"'{Display(name)}' could not be deleted: {ex.Message}", Severity.Error);
                return;
            }

            // Without a selection, LoadFiles selects the default file again and tells the page
            CurrentFile = null;
            LoadFiles();
            Snackbar.Add($"'{Display(name)}' deleted.", Severity.Info);
        }

        private async Task<bool> ConfirmAsync(string title, string message, string yesText)
        {
            bool? result = await DialogService.ShowMessageBoxAsync(title, message, yesText: yesText, cancelText: "Cancel");
            return result == true;
        }
    }
}
