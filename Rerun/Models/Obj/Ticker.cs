using System;

// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models.Obj
{
    public class Ticker
    {
        public Ticker()
        {
            id = 1;
            start = DateTimeOffset.Now.ToUnixTimeSeconds();
            end = DateTimeOffset.Now.AddDays(1).ToUnixTimeSeconds();
            param = "Welcome to Rerun, the next generation of Sonic Runners Revival's server software.";
        }

        public Ticker(string message)
        {
            id = 1;
            start = DateTimeOffset.Now.ToUnixTimeSeconds();
            end = DateTimeOffset.Now.AddDays(1).ToUnixTimeSeconds();
            param = message;
        }

        public long id { get; set; }
        public long start { get; set; }
        public long end { get; set; }
        public string param { get; set; }
    }
}
