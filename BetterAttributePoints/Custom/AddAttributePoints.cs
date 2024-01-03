using BetterAttributePoints;
using BetterCore.Utils;
using System;
using TaleWorlds.CampaignSystem;

namespace MoreAttributePoints.Custom {
    public class AddAttributePoints : CampaignEventReceiver {

        public override void OnHeroLevelledUp(Hero hero, bool shouldNotify = true) {
            base.OnHeroLevelledUp(hero, shouldNotify);
            try {
                if (hero.IsHumanPlayerCharacter) {
                    hero.HeroDeveloper.UnspentAttributePoints = hero.HeroDeveloper.UnspentAttributePoints + SubModule._settings.extraAttPointsPerLevel;
                }
            } catch (Exception e) {
                Logger.SendMessage("AddAttributePoints.OnHeroLevelledUp threw exception " + e, Severity.High);
            }
        }
    }
}
