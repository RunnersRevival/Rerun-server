namespace Rerun.Models.ConfigModels
{
    public class Config
    {
        public Config()
        {
            Port = 9001;
            GameConfigFilename = "game_config.json";
            EventConfigFilename = "event_config.json";
            InfoConfigFilename = "info_config.json";
            CampaignConfigFilename = "campaign_config.json";
            RouletteConfigFilename = "roulette_config.json";
        }
        /// <summary>
        /// The port number that the server should be hosted on.
        /// Default value is 9001
        /// </summary>
        public int Port { get; init; }
        /// <summary>
        /// The filename for the game configuration. Refer to the Rerun documentation for more info on what should go in the game config.
        /// Default value is "game_config.json"
        /// </summary>
        public string GameConfigFilename { get; init; }
        /// <summary>
        /// The filename for the event configuration. Refer to the Rerun documentation for more info on what should go in the event config.
        /// Default value is "event_config.json"
        /// </summary>
        public string EventConfigFilename { get; init; }
        /// <summary>
        /// The filename for the information configuration. Refer to the Rerun documentation for more info on what should go in the info config.
        /// Default value is "info_config.json"
        /// </summary>
        public string InfoConfigFilename { get; init; }
        /// <summary>
        /// The filename for the campaign configuration. Refer to the Rerun documentation for more info on what should go in the campaign config.
        /// Default value is "campaign_config.json"
        /// </summary>
        public string CampaignConfigFilename { get; init; }
        /// <summary>
        /// The filename for the roulette configuration. Refer to the Rerun documentation for more info on what should go in the roulette config.
        /// Default value is "roulette_config.json"
        /// </summary>
        public string RouletteConfigFilename { get; init; }
        /// <summary>
        /// The filename for the Rerun data file.
        /// </summary>
        public string RerunDataFilename { get; init; }
    }
}
