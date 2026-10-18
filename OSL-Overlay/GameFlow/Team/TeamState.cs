using Newtonsoft.Json;
using OSL_Overlay.GameFlow.ChampSelect;
using OSL_Overlay.GameFlow.EndGame;

namespace OSL_Overlay.GameFlow.Team
{
    /// <summary>
    /// Team managements
    /// </summary>
    public class TeamState
    {
        /// <summary>
        /// Blue team info
        /// </summary>
        public TeamInfo BlueInfo { get; set; } = new();
        /// <summary>
        /// Red team info
        /// </summary>
        public TeamInfo RedInfo { get; set; } = new();
        /// <summary>
        /// Blue team file
        /// </summary>
        public string? BlueFile { get; set; }
        /// <summary>
        /// Red team file
        /// </summary>
        public string? RedFile { get; set; }
        /// <summary>
        /// True when every blue lane shows its custom name
        /// </summary>
        public bool DisplayBlueCustomName => AllCustomNames(BlueInfo);
        /// <summary>
        /// True when every red lane shows its custom name
        /// </summary>
        public bool DisplayRedCustomName => AllCustomNames(RedInfo);

        /// <summary>
        /// True when the blue team was edited since it was last loaded or saved
        /// </summary>
        public bool IsBlueModified => Snapshot(BlueInfo) != _blueSnapshot;
        /// <summary>
        /// True when the red team was edited since it was last loaded or saved
        /// </summary>
        public bool IsRedModified => Snapshot(RedInfo) != _redSnapshot;

        // Content of the teams when they were last loaded or saved, to detect unsaved changes
        private string _blueSnapshot = Snapshot(new TeamInfo());
        private string _redSnapshot = Snapshot(new TeamInfo());

        /// <summary>
        /// Champ select state for update team info
        /// </summary>
        private readonly ChampSelectState ChampState;
        private readonly EndGameState EndGameState;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="champSelectState"></param>
        public TeamState(ChampSelectState champSelectState, EndGameState endGameState)
        {
            ChampState = champSelectState;
            EndGameState = endGameState;
        }

        private IWebHostEnvironment Env { get; set; } = default!;

        public event Action? OnChange;

        /// <summary>
        /// Load default teams information
        /// </summary>
        /// <param name="env"></param>
        public void LoadDefault(IWebHostEnvironment env)
        {
            Env = env;
            string path = Path.Combine(Env.WebRootPath, "data/teams/default.json");
            if (!File.Exists(path))
            {
                // TODO
                FileSelectedBlue(path);
                FileSelectedRed(path);
            }
        }

        public void NotifyChanged() => OnChange?.Invoke();

        /// <summary>
        /// Display or hide custom names for blue team
        /// </summary>
        /// <param name="display"></param>
        public void DisplayCustomBlueName(bool display)
        {
            BlueInfo.Top.ShowCustomName = display;
            BlueInfo.Jungle.ShowCustomName = display;
            BlueInfo.Mid.ShowCustomName = display;
            BlueInfo.Adc.ShowCustomName = display;
            BlueInfo.Supp.ShowCustomName = display;
        }

        /// <summary>
        /// Display or hide custom names for red team
        /// </summary>
        /// <param name="display"></param>
        public void DisplayCustomRedName(bool display)
        {
            RedInfo.Top.ShowCustomName = display;
            RedInfo.Jungle.ShowCustomName = display;
            RedInfo.Mid.ShowCustomName = display;
            RedInfo.Adc.ShowCustomName = display;
            RedInfo.Supp.ShowCustomName = display;
        }

        /// <summary>
        /// Select a file for blue team
        /// </summary>
        /// <param name="filePath"></param>
        public void FileSelectedBlue(string filePath)
        {
            string? json = OSL_Utils.File.Read(filePath);
            if (json == null)
                return;

            var info = JsonConvert.DeserializeObject<TeamInfo>(json);
            if (info != null)
            {
                // Update champ state
                ChampState.UpdateBlueTeamInfo(info);
                EndGameState.UpdateBlueTeamInfo(info);
                BlueInfo = info;
                _blueSnapshot = Snapshot(info);
            }
            BlueFile = filePath;

            NotifyChanged();
        }

        /// <summary>
        /// Select a file for red team
        /// </summary>
        /// <param name="filePath"></param>
        public void FileSelectedRed(string filePath)
        {
            string? json = OSL_Utils.File.Read(filePath);
            if (json == null)
                return;

            var info = JsonConvert.DeserializeObject<TeamInfo>(json);
            if (info != null)
            {
                // Update champ state
                ChampState.UpdateRedTeamInfo(info);
                EndGameState.UpdateRedTeamInfo(info);
                RedInfo = info;
                _redSnapshot = Snapshot(info);
            }
            RedFile = filePath;

            NotifyChanged();
        }

        /// <summary>
        /// Save blue team info to a file
        /// </summary>
        /// <param name="filePath"></param>
        public void SaveBlue(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(BlueInfo.Name))
            {
                // Directory how to save all data
                string directoryPath = OSL_Utils.Path.Combine("data/teams", BlueInfo.Name);

                // Create directory if not exist
                OSL_Utils.Directory.Create(OSL_Utils.Path.Combine(Env.WebRootPath, directoryPath));

                // Save file
                BlueInfo.Logo = CopyFromTemp(BlueInfo.Logo, directoryPath, "logo");
                BlueInfo.Top.Image = CopyFromTemp(BlueInfo.Top.Image, directoryPath, "top");
                BlueInfo.Jungle.Image = CopyFromTemp(BlueInfo.Jungle.Image, directoryPath, "jungle");
                BlueInfo.Mid.Image = CopyFromTemp(BlueInfo.Mid.Image, directoryPath, "mid");
                BlueInfo.Adc.Image = CopyFromTemp(BlueInfo.Adc.Image, directoryPath, "adc");
                BlueInfo.Supp.Image = CopyFromTemp(BlueInfo.Supp.Image, directoryPath, "supp");

                // Convert data to json
                string json = JsonConvert.SerializeObject(BlueInfo, Formatting.Indented);
                OSL_Utils.File.Write(filePath, json);
                BlueFile = filePath;
                _blueSnapshot = Snapshot(BlueInfo);

                // Update champ state
                ChampState.UpdateBlueTeamInfo(BlueInfo);
                EndGameState.UpdateBlueTeamInfo(BlueInfo);

                NotifyChanged();
            }
        }

        /// <summary>
        /// Save red team info to a file
        /// </summary>
        /// <param name="filePath"></param>
        public void SaveRed(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(RedInfo.Name))
            {
                // Directory how to save all data
                string directoryPath = OSL_Utils.Path.Combine("data/teams", RedInfo.Name);

                // Create directory if not exist
                OSL_Utils.Directory.Create(OSL_Utils.Path.Combine(Env.WebRootPath, directoryPath));

                // Save file
                RedInfo.Logo = CopyFromTemp(RedInfo.Logo, directoryPath, "logo");
                RedInfo.Top.Image = CopyFromTemp(RedInfo.Top.Image, directoryPath, "top");
                RedInfo.Jungle.Image = CopyFromTemp(RedInfo.Jungle.Image, directoryPath, "jungle");
                RedInfo.Mid.Image = CopyFromTemp(RedInfo.Mid.Image, directoryPath, "mid");
                RedInfo.Adc.Image = CopyFromTemp(RedInfo.Adc.Image, directoryPath, "adc");
                RedInfo.Supp.Image = CopyFromTemp(RedInfo.Supp.Image, directoryPath, "supp");

                // Convert data to json
                string json = JsonConvert.SerializeObject(RedInfo, Formatting.Indented);
                OSL_Utils.File.Write(filePath, json);
                RedFile = filePath;
                _redSnapshot = Snapshot(RedInfo);

                // Update champ state
                ChampState.UpdateRedTeamInfo(RedInfo);
                EndGameState.UpdateRedTeamInfo(RedInfo);

                NotifyChanged();
            }
        }

        /// <summary>
        /// Send the current blue team to the overlays without saving it to a file
        /// </summary>
        public void ApplyBlue()
        {
            ChampState.UpdateBlueTeamInfo(BlueInfo);
            EndGameState.UpdateBlueTeamInfo(BlueInfo);
            NotifyChanged();
        }

        /// <summary>
        /// Send the current red team to the overlays without saving it to a file
        /// </summary>
        public void ApplyRed()
        {
            ChampState.UpdateRedTeamInfo(RedInfo);
            EndGameState.UpdateRedTeamInfo(RedInfo);
            NotifyChanged();
        }

        private static bool AllCustomNames(TeamInfo info) =>
            info.Top.ShowCustomName && info.Jungle.ShowCustomName && info.Mid.ShowCustomName
            && info.Adc.ShowCustomName && info.Supp.ShowCustomName;

        private static string Snapshot(TeamInfo info) => JsonConvert.SerializeObject(info);

        /// <summary>
        /// Swap blue and red teams
        /// </summary>
        public void SwapTeams()
        {
            string? blue = BlueFile;
            string? red = RedFile;
            if (blue != null && red != null)
            {
                FileSelectedBlue(red);
                FileSelectedRed(blue);
            }
        }

        /// <summary>
        /// Copy a file from temp to the right directory
        /// </summary>
        /// <param name="relativeSourceFile"></param>
        /// <param name="relativeDestDir"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string CopyFromTemp(string relativeSourceFile, string relativeDestDir, string fileName)
        {
            if (string.IsNullOrWhiteSpace(relativeSourceFile))
                return "";

            // Add wwwroot path to file
            string sourceFile = OSL_Utils.Path.Combine(Env.WebRootPath, relativeSourceFile);
            // Add wwwroot path to dir
            string destDir = OSL_Utils.Path.Combine(Env.WebRootPath, relativeDestDir);

            // Check if dir exist
            if (!Directory.Exists(destDir))
                Directory.CreateDirectory(destDir);

            // Create dest file path
            string destFile = OSL_Utils.Path.Combine(destDir, fileName + Path.GetExtension(relativeSourceFile));

            // Copy file
            if (sourceFile != destFile)
            {
                string file = OSL_Utils.File.Copy(sourceFile, destFile, true);
                return OSL_Utils.Path.ToWebPath(file, Env.WebRootPath);
            }

            return OSL_Utils.Path.ToWebPath(destFile, Env.WebRootPath);
        }
    }
}
