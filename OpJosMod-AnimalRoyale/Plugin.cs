using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using OpJosModAnimalRoyale.TestMod.Patches;

namespace OpJosModAnimalRoyale.TestMod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class OpJosModAnimalRoyaleTestMod : BasePlugin
    {
        private const string modGUID = "OpJosModAnimalRoyale.TestMod";
        private const string modName = "TestMod";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static OpJosModAnimalRoyaleTestMod Instance;

        internal ManualLogSource mls;

        //not needed?
        public override void Load()
        {
            Loaded();
        }

        void Awake()
        {
            Loaded();
        }

        private void Loaded()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo(modName + " has loaded");

            PlayerPatch.SetLogSource(mls);
            harmony.PatchAll();
        }
    }
}
