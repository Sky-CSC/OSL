using System.Text;

namespace OSL_CDragon;

/// <summary>
/// Central place for every path used by the asset pipeline.
/// Paths are stored with forward slashes and a leading "./" so the persisted data keeps the same format as before.
/// </summary>
internal static class AssetPaths
{
    // TODO (phase 2): replace by an options class resolved from IWebHostEnvironment.ContentRootPath.
    public const string Root = "./wwwroot/assets";
    public const string EndpointsDirectory = "./EndpointsJson";

    public static string DataFile => $"{Root}/_data.json";
    public static string InfoFile => $"{Root}/_info.json";

    /// <summary>Combines path parts with '/' (never with the OS separator).</summary>
    public static string Combine(params string[] parts)
    {
        var cleaned = parts
            .Where(part => !string.IsNullOrEmpty(part))
            .Select(part => part.Replace('\\', '/').Trim('/'))
            .Where(part => part.Length > 0);
        return string.Join('/', cleaned);
    }

    /// <summary>Directory part of a relative path, with '/' separators ("a/b/c.png" => "a/b").</summary>
    public static string DirectoryOf(string path)
    {
        string? directory = Path.GetDirectoryName(path);
        return directory?.Replace('\\', '/') ?? string.Empty;
    }

    /// <summary>Converts a stored path ("./wwwroot/assets/x.png") to the URL used by the browser ("./assets/x.png").</summary>
    public static string ToWebPath(string? storedPath)
    {
        if (string.IsNullOrEmpty(storedPath))
            return string.Empty;

        const string marker = "/wwwroot";
        int index = storedPath.IndexOf(marker, StringComparison.Ordinal);
        return index < 0 ? storedPath : "." + storedPath[(index + marker.Length)..];
    }

    /// <summary>Returns the text after the last occurrence of <paramref name="marker"/> (lower-cased), or null if absent.</summary>
    public static string? AfterLast(string? value, string marker)
    {
        if (string.IsNullOrEmpty(value))
            return null;
        int index = value.LastIndexOf(marker, StringComparison.OrdinalIgnoreCase);
        return index < 0 ? null : value[(index + marker.Length)..].ToLowerInvariant();
    }

    public static bool IsValidFile(string? path)
    {
        if (string.IsNullOrEmpty(path))
            return false;
        var file = new FileInfo(path);
        return file.Exists && file.Length > 0;
    }

    /// <summary>Returns <paramref name="path"/> if the file really exists, otherwise an empty string.</summary>
    public static string ExistingOrEmpty(string? path) => IsValidFile(path) ? path! : string.Empty;

    /// <summary>Writes a text file atomically (temporary file, then move) so a crash never leaves a truncated JSON.</summary>
    public static void WriteTextAtomic(string path, string content)
    {
        string? directory = Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory))
            Directory.CreateDirectory(directory);

        string temporaryPath = path + ".tmp";
        File.WriteAllText(temporaryPath, content, new UTF8Encoding(false));
        File.Move(temporaryPath, path, overwrite: true);
    }

    public static string? ReadTextOrNull(string path)
    {
        try
        {
            return File.Exists(path) ? File.ReadAllText(path) : null;
        }
        catch (IOException)
        {
            return null;
        }
        catch (UnauthorizedAccessException)
        {
            return null;
        }
    }
}
