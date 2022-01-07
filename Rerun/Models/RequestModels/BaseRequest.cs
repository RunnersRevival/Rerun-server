
// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models.RequestModels
{
    public class BaseRequest
    {
        public string sessionId { get; set; } // Session ID, if one has been assigned

        public string version { get; set; } // Client version number

        public string seq { get; set; }

        public string revivalVerId { get; set; }
    }
}
