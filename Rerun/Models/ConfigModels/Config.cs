namespace Rerun.Models.ConfigModels
{
    public class Config
    {
        public Config()
        {
            Port = 9001;
            RerunDataFilename = "DataTable.rdt";
        }
        /// <summary>
        /// The port number that the server should be hosted on.
        /// Default value is 9001
        /// </summary>
        public int Port { get; init; }
        /// <summary>
        /// The filename for the Rerun data file. This can be made and edited using the companion Rerun Editor program.
        /// Default value is "DataTable.rdt"
        /// </summary>
        public string RerunDataFilename { get; init; }
        
        /// <summary>
        /// Specifies whether Rerun should log device names in its database.
        /// </summary>
        public bool AllowDeviceLogging { get; init; }
    }
}
