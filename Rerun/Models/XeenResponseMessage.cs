// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models
{
    /// <summary>The general model for all responses</summary>
    public class XeenResponseMessage
    {
        /// <summary>The AES decryption key for <see cref="param"/>, if necessary</summary>
        /// <seealso cref="secure"/>
        public string key { get; set; }

        /// <remarks>The type depends on the value of <see cref="secure"/>: if it's 0, it can be an object of any type derived from BaseResponse; if it's 1, it's a string containing the encrypted JSON object</remarks>
        public object param { get; set; }

        /// <summary>Indicates whether AES encryption is used for <see cref="param"/></summary>
        /// <seealso cref="key"/>
        public short secure { get; set; }
    }
}
