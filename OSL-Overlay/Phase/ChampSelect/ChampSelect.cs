using Newtonsoft.Json;

namespace OSL_Overlay.Phase.ChampSelect
{
    public class ChampSelect
    {
        private readonly ChampSelectState _state;

        public ChampSelect(ChampSelectState state)
        {
            _state = state;
        }

        public void LoadStyle(string path)
        {
            // TODO: Load style
            string json = OSL_Utils.File.Read(path);
            var info = JsonConvert.DeserializeObject<ChampSelectInfo>(json);
            if (info != null)
            {
                _state.UpdateInfoCss(info);
            }
        }

        public void SaveStyle(string path)
        {
            // TODO: Save style
            string json = JsonConvert.SerializeObject(_state.Info, Formatting.Indented);
            OSL_Utils.File.Write(path, json);
        }
    }
}
