using BepInEx.Logging;
using BepInEx.Unity.IL2CPP.UnityEngine;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using UnityEngine;
using KeyCode = BepInEx.Unity.IL2CPP.UnityEngine.KeyCode;

namespace OpJosModAnimalRoyale.TestMod.Patches
{ 
    [HarmonyPatch(typeof(MonoBehaviourPublicObcuBousBoSiovBoCoCaUnique))]
    internal class PlayerPatch
    {
        private static ManualLogSource mls;
        public static void SetLogSource(ManualLogSource source)
        {
            mls = source;
        }

        private static bool alreadyPressed = false;
        private static KeyCode key = KeyCode.C;

        [HarmonyPatch("Update")]
        [HarmonyPostfix]
        private static void UpdatePatch(MonoBehaviourPublicObcuBousBoSiovBoCoCaUnique __instance)
        {
            if (Input.GetKeyInt(key) && alreadyPressed == false) //show imposters
            {
                doThing(__instance);
            }

            alreadyPressed = Input.GetKeyInt(key);
        }
        private static void doThing(MonoBehaviourPublicObcuBousBoSiovBoCoCaUnique __instnace)
        {
            mls.LogInfo("button was pressed");

            //__instnace.GameServerSentPlayerHPArmorMoveModeChange(1, false, 1, 1, 1, 1, 1, 1, 1);

            __instnace.gameObject.transform.position += new Vector3(20, 20, 20);
        }
    }
}
