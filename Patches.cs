using BepInEx.Logging;
using HarmonyLib;
using PotionCraft.ManagersSystem.Game;
using PotionCraft.SceneLoader;

namespace GrowAnywhere
{
    class Patches
    {
        static ManualLogSource Log => Plugin.Log;

        [HarmonyPostfix, HarmonyPatch(typeof(GameManager), "Start")]
        public static void Start_Postfix()
        {
            Log.LogInfo("Patching seeds...");
            ObjectsLoader.AddLast("SaveLoadManager.SaveNewGameState", () => Functions.AddZonesToSeeds());
            Log.LogInfo("Seeds patched!");
        }
    }
}
