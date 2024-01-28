using BetterAttributePoints.Custom;
using BetterAttributePoints.Settings;
using BetterCore.Utils;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BetterAttributePoints {
    public class BetterAttributePoints : MBSubModuleBase {

        public static MCMSettings Settings { get; private set; } = new MCMSettings();
        public static string ModName { get; private set; } = "BetterAttributePoints";

        private bool isInitialized = false;
        private bool isLoaded = false;

        //FIRST
        protected override void OnSubModuleLoad() {
            try {
                base.OnSubModuleLoad();

                if (isInitialized)
                    return;

                Harmony h = new("Bannerlord.Shadow." + ModName);

                h.PatchAll();

                isInitialized = true;
            } catch (Exception e) {
                NotifyHelper.WriteError(ModName, "OnSubModuleLoad threw exception " + e);
            }
        }

        //SECOND
        protected override void OnBeforeInitialModuleScreenSetAsRoot() {
            try {
                base.OnBeforeInitialModuleScreenSetAsRoot();

                if (isLoaded)
                    return;

                ModName = base.GetType().Assembly.GetName().Name;

                Settings = MCMSettings.Instance ?? throw new NullReferenceException("Settings are null");

                NotifyHelper.WriteMessage(ModName + " Loaded.", MsgType.Good);
                Integrations.BetterAttributePointsLoaded = true;

                isLoaded = true;
            } catch (Exception e) {
                NotifyHelper.WriteError(ModName, "OnBeforeInitialModuleScreenSetAsRoot threw exception " + e);
            }
        }

        protected override void OnGameStart(Game game, IGameStarter gameStarter) {
            base.OnGameStart(game, gameStarter);

            if (Settings.ExtraAttPointsPerLevel > 0) {
                if (game.GameType is Campaign) {
                    Campaign campaign = (Campaign)game.GameType;

                    if (campaign != null) {
                        campaign.AddCampaignEventReceiver(new AddAttributePoints());
                    }
                }
            }
        }
    }
}
