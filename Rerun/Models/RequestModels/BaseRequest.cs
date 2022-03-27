
// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models.RequestModels
{
    public class BaseRequest
    {
        /// <summary>
        /// The current session's Session ID, if applicable.
        /// </summary>
        public string sessionId { get; set; }

        /// <summary>
        /// The client's reported version number.
        /// </summary>
        public string version { get; set; }

        /// <summary>
        /// The current sequence number for the request.
        /// </summary>
        public string seq { get; set; }
        
        /// <summary>
        /// The client's reported Revival Version ID.
        /// </summary>
        /// <remarks>
        /// This field is deprecated and will be removed from both the Runners Revival client and Rerun in the future.
        /// </remarks>
        /// <seealso cref="version"/>
        public string revivalVerId { get; set; }
    }
}
