namespace OSL_Overlay.GameFlow.Patch
{
    /// <summary>
    /// Patch information
    /// </summary>
    public class PatchInfo
    {
        public string Text { get; set; }
        public string Version { get; set; }
        public PatchInfo()
        {
            Text = string.Empty;
            Version = string.Empty;
        }
    }
}
