using CemeterySystem.Debugging;

namespace CemeterySystem
{
    public class CemeterySystemConsts
    {
        public const string LocalizationSourceName = "CemeterySystem";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "c978e6959a1149728aced3a6cf21adf7";
    }
}
