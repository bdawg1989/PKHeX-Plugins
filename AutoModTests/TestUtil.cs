using System.IO;
using PKHeX.Core;
using PKHeX.Core.AutoMod;

namespace AutoModTests
{
    public static class TestUtil
    {
        static TestUtil() => InitializePKHeXEnvironment();

        private static bool Initialized;

        private static readonly object _lock = new();

        public static void InitializePKHeXEnvironment()
        {
            lock (_lock)
            {
                if (Initialized)
                    return;

                EncounterEvent.RefreshMGDB();
                RibbonStrings.ResetDictionary(GameInfo.Strings.ribbons);
                Legalizer.EnableEasterEggs = false;
                APILegality.SetAllLegalRibbons = false;
                APILegality.Timeout = 99999;
                ParseSettings.Settings.Handler.CheckActiveHandler = false;
                ParseSettings.Settings.HOMETransfer.HOMETransferTrackerNotPresent = Severity.Fishy;
                ParseSettings.Settings.Nickname.Nickname12 = ParseSettings.Settings.Nickname.Nickname3 = ParseSettings.Settings.Nickname.Nickname4 = ParseSettings.Settings.Nickname.Nickname5 = ParseSettings.Settings.Nickname.Nickname6 = ParseSettings.Settings.Nickname.Nickname7 = ParseSettings.Settings.Nickname.Nickname7b = ParseSettings.Settings.Nickname.Nickname8 = ParseSettings.Settings.Nickname.Nickname8a = ParseSettings.Settings.Nickname.Nickname8b = ParseSettings.Settings.Nickname.Nickname9 = new NicknameRestriction() { NicknamedTrade = Severity.Fishy, NicknamedMysteryGift = Severity.Fishy};
                Initialized = true;
            }
        }

        public static string GetTestFolder(string name)
        {
            var folder = Directory.GetCurrentDirectory();
            while (!folder.EndsWith(nameof(AutoModTests)))
            {
                var dir = Directory.GetParent(folder) ?? throw new DirectoryNotFoundException( $"Unable to find a directory named {nameof(AutoModTests)}.");
                folder = dir.FullName;
            }
            return Path.Combine(folder, name);
        }
    }
}
