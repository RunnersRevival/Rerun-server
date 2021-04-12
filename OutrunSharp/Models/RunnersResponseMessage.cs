// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace OutrunSharp.Models
{
    // The general model for all responses for Runners
    public class RunnersResponseMessage
    {
        // AES decryption key, if necessary
        public string key { get; set; }
        // type depends on the value of secure: if it's 0, it can be an object of any type derived from BaseResponse; if it's 1, it's a string containing the encrypted JSON data
        public object param { get; set; }
        // indicates whether AES encryption is used in response
        public short secure { get; set; }
    }
}
