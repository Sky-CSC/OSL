using Newtonsoft.Json;

namespace OSL_Utils.Version
{
    public static class VersionService
    {
        private static readonly Logger _logger = new("VersionService");

        public static string GetVersion(string filePath)
        {
            if (!File.Exist(filePath))
            {
                _logger.Log(LoggingLevel.ERROR, nameof(GetVersion), $"Version file not found: {filePath}");
                return "Unknown";
            }

            var json = File.Read(filePath);
            if (json == null) {
                _logger.Log(LoggingLevel.ERROR, nameof(GetVersion), $"Failed to read version file: {filePath}");
                return "Unknown";
            }

            var versionInfo = JsonConvert.DeserializeObject<VersionInfo>(json);
            _logger.Log(LoggingLevel.DEBUG, nameof(GetVersion), $"Version read from file {filePath}: {versionInfo?.Version ?? "Unknown"}");
            return versionInfo?.Version ?? "Unknown";
        }
    }
}
