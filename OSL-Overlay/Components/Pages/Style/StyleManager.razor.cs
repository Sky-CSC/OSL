using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace OSL_Overlay.Components.Pages.Style
{
    /// <summary>
    /// Mange style files
    /// </summary>
    public partial class StyleManager
    {
        /// <summary>Fichier actuellement sélectionné (chemin complet)</summary>
        [Parameter] public string RelativePath { get; set; } = string.Empty;

        /// <summary>
        /// Actual file selected
        /// </summary>
        [Parameter] public string? CurrentFile { get; set; }

        /// <summary>
        /// Save file
        /// </summary>
        [Parameter] public EventCallback<string> OnSave { get; set; }

        /// <summary>
        /// Select file
        /// </summary>
        [Parameter] public EventCallback<string> OnFileSelected { get; set; }

        private List<string> _files = new();
        private Dictionary<string, string> _fileRenameMap = new();

        // Path of wwwroot
        private string FullPath => Path.Combine(Env.WebRootPath, RelativePath);

        protected override void OnParametersSet() => LoadFiles();

        /// <summary>
        /// Load all file in directory
        /// </summary>
        private void LoadFiles()
        {
            if (Directory.Exists(FullPath))
            {
                _files = Directory.GetFiles(FullPath)
                                  .OrderByDescending(f => File.GetLastWriteTime(f)) // most recent in first
                                  .Select(Path.GetFileName)
                                  .Where(f => f != null)
                                  .ToList()!;

                _fileRenameMap = _files.ToDictionary(f => f, f => f);

                if (_files.Count > 0 && string.IsNullOrEmpty(CurrentFile))
                {
                    var lastFile = _files[0];
                    CurrentFile = Path.Combine(FullPath, lastFile);

                    _ = OnFileSelected.InvokeAsync(CurrentFile);
                }
            }
        }

        /// <summary>
        /// Save data on new file
        /// </summary>
        /// <returns></returns>
        private async Task SaveFile()
        {
            var fileName = $"style-{DateTime.Now:yyyyMMdd-HHmmss}.json";
            var filePath = Path.Combine(FullPath, fileName);

            await OnSave.InvokeAsync(filePath);
            CurrentFile = filePath;

            LoadFiles();
        }

        /// <summary>
        /// Save date on actual file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns></returns>
        private async Task SaveChanges(string fileName)
        {
            var filePath = Path.Combine(FullPath, fileName);
            await OnSave.InvokeAsync(filePath);
            CurrentFile = filePath;
        }

        /// <summary>
        /// File is selected or not
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns></returns>
        private bool IsSelected(string fileName)
        {
            if (string.IsNullOrEmpty(CurrentFile))
                return false;

            return Path.GetFileName(CurrentFile) == fileName;
        }

        /// <summary>
        /// Select a file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns></returns>
        private async Task SelectFile(string fileName)
        {
            var fullPath = Path.Combine(FullPath, fileName);
            CurrentFile = fullPath;
            await OnFileSelected.InvokeAsync(fullPath);
        }

        /// <summary>
        /// Confirm deletion
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns></returns>
        private async Task ConfirmDelete(string fileName)
        {
            bool? result = await DialogService.ShowMessageBox(
                "Confirm",
                $"Do you want to delete this file '{fileName}' ?",
                yesText: "Delete", cancelText: "Cancel");

            if (result == true)
            {
                var filePath = Path.Combine(FullPath, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    if (Path.GetFileName(CurrentFile) == fileName)
                        CurrentFile = null;

                    LoadFiles();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetFileRename(string fileName) =>
            _fileRenameMap.TryGetValue(fileName, out var value) ? value : fileName;

        private void UpdateFileRename(string fileName, string newValue)
        {
            if (_fileRenameMap.ContainsKey(fileName))
                _fileRenameMap[fileName] = newValue;
        }

        /// <summary>
        /// Rename file
        /// </summary>
        /// <param name="oldName">Old name</param>
        /// <returns></returns>
        private async Task RenameFile(string oldName)
        {
            if (!_fileRenameMap.ContainsKey(oldName))
                return;

            var newName = _fileRenameMap[oldName];
            if (string.IsNullOrWhiteSpace(newName) || newName == oldName)
                return;

            var oldPath = Path.Combine(FullPath, oldName);
            var newPath = Path.Combine(FullPath, newName);

            if (File.Exists(newPath))
            {
                await DialogService.ShowMessageBox("Error", "This file name already exist.");
                return;
            }

            File.Move(oldPath, newPath);

            if (Path.GetFileName(CurrentFile) == oldName)
                CurrentFile = newPath;

            LoadFiles();
        }

        /// <summary>
        /// If file is selected return scpecific background color
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns></returns>
        private string GetRowBackgroundStyle(string fileName) =>
            IsSelected(fileName) ? $"background-color: {Colors.BlueGray.Darken4};" : string.Empty;

        /// <summary>
        /// If file is selected return specific text color
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns></returns>
        private string GetRowColorStyle(string fileName) =>
            IsSelected(fileName) ? $"color: {Colors.LightGreen.Accent3};" : string.Empty;

        /// <summary>
        /// Duplicate spécific file
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns></returns>
        private async Task DuplicateFile(string fileName)
        {
            var sourcePath = Path.Combine(FullPath, fileName);
            if (!File.Exists(sourcePath)) return;

            var nameWithoutExt = Path.GetFileNameWithoutExtension(fileName);
            var ext = Path.GetExtension(fileName);
            var newName = $"{nameWithoutExt}-copy{ext}";
            var destPath = Path.Combine(FullPath, newName);

            int counter = 1;
            while (File.Exists(destPath))
            {
                newName = $"{nameWithoutExt}-copy{counter}{ext}";
                destPath = Path.Combine(FullPath, newName);
                counter++;
            }

            File.Copy(sourcePath, destPath);
            LoadFiles();
        }
    }
}
