using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BetterAttributePoints.Patches {
    [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel))]
    class DefaultCharacterDevelopmentModelPatch {

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.LevelsPerAttributePoint), MethodType.Getter)]
        public static void LevelsPerAttributePoint(ref int __result) {
            try {
                __result = SubModule._settings.levelsPerAttributePoint;
            } catch (Exception e) {
                Logger.SendMessage("DefaultCharacterDevelopmentModel.LevelsPerAttributePoint threw exception " + e, Severity.High);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.MaxAttribute), MethodType.Getter)]
        public static void MaxAttribute(ref int __result) {
            try {
                __result = SubModule._settings.maxAttributeLevel;
            } catch (Exception e) {
                Logger.SendMessage("DefaultCharacterDevelopmentModel.MaxAttribute threw exception " + e, Severity.High);
            }
        }
    }
}
