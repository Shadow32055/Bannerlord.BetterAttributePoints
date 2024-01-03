using BetterAttributePoints.Settings;
using BetterCore.Utils;
using HarmonyLib;
using MoreAttributePoints.Custom;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BetterAttributePoints {
    public class SubModule : MBSubModuleBase {

        public static MCMSettings _settings;
		protected override void OnSubModuleLoad() {
			base.OnSubModuleLoad();

			Harmony h = new Harmony("Bannerlord.Shadow.BetterAttributePoints");

            h.PatchAll();
		}

        protected override void OnGameStart(Game game, IGameStarter gameStarter) {
            base.OnGameStart(game, gameStarter);

            if (game.GameType is Campaign) {
                Campaign campaign = (Campaign)game.GameType;

                if (campaign != null) {
                    campaign.AddCampaignEventReceiver(new AddAttributePoints());
                }
            }
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot() {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            string modName = base.GetType().Assembly.GetName().Name;

            Helper.SetModName(modName);
            if (MCMSettings.Instance is not null) {
                _settings = MCMSettings.Instance;
            } else {
                Logger.SendMessage("Failed to find settings instance!", Severity.High);
            }
        }
    }
}
