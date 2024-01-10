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
                __result = BetterAttributePoints.Settings.LevelsPerAttributePoint;
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterAttributePoints.ModName, "DefaultCharacterDevelopmentModel.LevelsPerAttributePoint threw exception " + e);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(DefaultCharacterDevelopmentModel), nameof(DefaultCharacterDevelopmentModel.MaxAttribute), MethodType.Getter)]
        public static void MaxAttribute(ref int __result) {
            try {
                __result = BetterAttributePoints.Settings.MaxAttributeLevel;
            } catch (Exception e) {
                NotifyHelper.ReportError(BetterAttributePoints.ModName, "DefaultCharacterDevelopmentModel.MaxAttribute threw exception " + e);
            }
        }
    }
}
