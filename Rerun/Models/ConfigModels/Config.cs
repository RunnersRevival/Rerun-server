namespace Rerun.Models.ConfigModels
{
    public class Config
    {
        public Config()
        {
            Port = 9001;

        }
        public int Port { get; init; }
        public string GameConfigFilename { get; init; }
        public string EventConfigFilename { get; init; }
        public string InfoConfigFilename { get; init; }
        public string CampaignConfigFilename { get; init; }
        public string RouletteConfigFilename { get; init; }
    }
}
