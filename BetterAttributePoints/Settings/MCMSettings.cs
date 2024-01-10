using BetterAttributePoints.Localizations;
using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterAttributePoints.Settings {

    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {

        [SettingPropertyGroup(RefValues.AttributeText)]
        [SettingPropertyInteger(RefValues.LevelsPerText, 1, 10, "0", Order = 0, RequireRestart = false, HintText = RefValues.LevelsPerHint)]
        public int LevelsPerAttributePoint { get; set; } = 4;

        [SettingPropertyGroup(RefValues.AttributeText)]
        [SettingPropertyInteger(RefValues.MaxLevelText, 0, 100, "0", Order = 0, RequireRestart = false, HintText = RefValues.MaxLevelHint)]
        public int MaxAttributeLevel { get; set; } = 10;

        [SettingPropertyGroup(RefValues.AttributeText)]
        [SettingPropertyInteger(RefValues.ExtraText, 0, 100, "0", Order = 0, RequireRestart = false, HintText = RefValues.ExtraHint)]
        public int ExtraAttPointsPerLevel { get; set; } = 0;



        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
        public bool LoadMCMConfigFile { get; set; } = true;
    }
}
