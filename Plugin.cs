using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace GrowAnywhere
{
    [BepInPlugin(PLUGIN_GUID, "PotionCraftGrowAnywhere", PLUGIN_VERSION)]
    [BepInProcess("Potion Craft.exe")]
    public class Plugin : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "mattdeduck.potioncraftgrowanywhere";
        public const string PLUGIN_VERSION = "1.0.1.0";

        public static ManualLogSource Log { get; set; }
        public static bool alreadyDone = false;

        private void Awake()
        {
            Log = base.Logger;
            Harmony.CreateAndPatchAll(typeof(Plugin));
            Harmony.CreateAndPatchAll(typeof(Patches));
            Harmony.CreateAndPatchAll(typeof(Functions));
            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
