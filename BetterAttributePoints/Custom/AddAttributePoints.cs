using BetterCore.Utils;
using System;
using TaleWorlds.CampaignSystem;

namespace BetterAttributePoints.Custom {
    public class AddAttributePoints : CampaignEventReceiver {

        public override void OnHeroLevelledUp(Hero hero, bool shouldNotify = true) {
            base.OnHeroLevelledUp(hero, shouldNotify);
            try {
                if (!hero.CharacterObject.IsPlayerCharacter && BetterAttributePoints.Settings.ExtraPointsPlayerOnly)
                    return;

                hero.HeroDeveloper.UnspentAttributePoints = hero.HeroDeveloper.UnspentAttributePoints + BetterAttributePoints.Settings.ExtraAttPointsPerLevel;
                
            } catch (Exception e) {
                NotifyHelper.WriteError(BetterAttributePoints.ModName, "AddAttributePoints.OnHeroLevelledUp threw exception " + e);
            }
        }
    }
}
