using Newtonsoft.Json;
using OSL_Overlay.Phase.ChampSelect;

namespace OSL_Overlay.Phase.Team
{
    public class TeamState
    {
        public TeamInfo BlueInfo { get; set; } = new();
        public TeamInfo RedInfo { get; set; } = new();
        public string? BlueFile { get; set; }
        public string? RedFile { get; set; }

        private readonly ChampSelectState ChampState;

        public TeamState(ChampSelectState state)
        {
            ChampState = state;
        }

        private IWebHostEnvironment Env { get; set; } = default!;

        public event Action? OnChange;

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

        public void FileSelectedBlue(string filePath)
        {
            string? json = OSL_Utils.File.Read(filePath);
            if (json == null)
                return;

            var info = JsonConvert.DeserializeObject<TeamInfo>(json);
            if (info != null)
            {
                // Update champ state
                ChampState.UpdateInfoTeam(info, "blue-side");
                BlueInfo = info;
            }
            BlueFile = filePath;

            NotifyChanged();
        }

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

                // Update champ state
                ChampState.UpdateInfoTeam(BlueInfo, "blue-side");

                NotifyChanged();
            }
        }

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

                // Update champ state
                ChampState.UpdateInfoTeam(RedInfo, "red-side");

                NotifyChanged();
            }
        }

        public void FileSelectedRed(string filePath)
        {
            string? json = OSL_Utils.File.Read(filePath);
            if (json == null)
                return;

            var info = JsonConvert.DeserializeObject<TeamInfo>(json);
            if (info != null)
            {
                // Update champ state
                ChampState.UpdateInfoTeam(info, "red-side");
                RedInfo = info;
            }
            RedFile = filePath;

            NotifyChanged();
        }

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
                return OSL_Utils.Path.ToWebpath(file, Env.WebRootPath);
            }

            return OSL_Utils.Path.ToWebpath(destFile, Env.WebRootPath);
        }
    }
}
