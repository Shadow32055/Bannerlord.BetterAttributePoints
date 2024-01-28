using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterAttributePoints.Settings {
    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {

        [SettingPropertyGroup(Strings.AttributeText)]
        [SettingPropertyInteger(Strings.LevelsPerText, 1, 100, "0", Order = 0, RequireRestart = false, HintText = Strings.LevelsPerHint)]
        public int LevelsPerAttributePoint { get; set; } = 4;

        [SettingPropertyGroup(Strings.AttributeText)]
        [SettingPropertyInteger(Strings.MaxLevelText, 0, 60, "0", Order = 0, RequireRestart = false, HintText = Strings.MaxLevelHint)]
        public int MaxAttributeLevel { get; set; } = 10;

        [SettingPropertyGroup(Strings.AttributeText + "/" + Strings.ExtraPointsText)]
        [SettingPropertyInteger(Strings.ExtraText, 0, 20, "0", Order = 0, RequireRestart = false, HintText = Strings.ExtraHint)]
        public int ExtraAttPointsPerLevel { get; set; } = 0;

        [SettingPropertyGroup(Strings.AttributeText + "/" + Strings.ExtraPointsText)]
        [SettingPropertyBool(Strings.PlayerOnlyText, Order = 0, RequireRestart = false, HintText = Strings.PlayerOnlyHint)]
        public bool ExtraPointsPlayerOnly { get; set; } = false;


        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
    }
}
