using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BetterAttributePoints.Settings {

    public class MCMSettings : AttributeGlobalSettings<MCMSettings> {

        const string attributeText = "{BA_OUkZom}Attribute Points";

        [SettingPropertyGroup(attributeText)]
        [SettingPropertyInteger("{=BA_GU6Ibm}Levels Per Attribute Point", 1, 10, "0", Order = 0, RequireRestart = false, HintText = "{=BA_VhEAx3}How many levels you need to gain to get an attribute point.")]
        public int levelsPerAttributePoint { get; set; } = 4;

        [SettingPropertyGroup(attributeText)]
        [SettingPropertyInteger("{=BA_KAggxW}Max Attribute Level", 0, 100, "0", Order = 0, RequireRestart = false, HintText = "{=BA_TAtfSS}Maximum level for attributes.")]
        public int maxAttributeLevel { get; set; } = 10;

        [SettingPropertyGroup(attributeText)]
        [SettingPropertyInteger("{=BA_IhtaxW}Extra Points Per Level", 0, 100, "0", Order = 0, RequireRestart = false, HintText = "{=BA_T5Ylpe}Extra attribute points per level.")]
        public int extraAttPointsPerLevel { get; set; } = 0;



        public override string Id { get { return base.GetType().Assembly.GetName().Name; } }
        public override string DisplayName { get; } = "Better Attribute Points";
        public override string FolderName { get { return base.GetType().Assembly.GetName().Name; } }
        public override string FormatType { get; } = "xml";
        public bool LoadMCMConfigFile { get; set; } = true;
    }
}
