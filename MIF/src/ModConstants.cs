using System;

namespace Ele.MIF
{
    public static class ModConstants
    {
        public const string modName = "MisakisFoliage"; 
        public const string modDomain = "mif"; 
        public const string mainChannel = $"{modDomain}:main";
        public const string harmonyID = $"com.elephantstudios.{modDomain}";

        public const string langCodeEmpty = "Empty";

        public class EventIDs
        {
            public const string configReloaded = $"{modDomain}:configreloaded";
        }
    }
}
