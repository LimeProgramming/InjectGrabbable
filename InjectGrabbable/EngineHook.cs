using ResoniteModLoader;
using FrooxEngine;


namespace InjectGrabbable
{
    public partial class InjectGrabbable : ResoniteMod
    {
        public override string Name => "InjectGrabbable";
        public override string Author => "CalamityLime";
        public override string Version => "1.0.0";
        public override string Link => "";

        public static ModConfiguration Config;

        /* ========== Register Config keys ========== */

        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<bool> ModEnable = new ModConfigurationKey<bool>("Enable", "Enable InjectGrabbable Mod?", () => true); //Optional config settings

        [AutoRegisterConfigKey]
        private static readonly ModConfigurationKey<bool> InjectGrabbableRootLocation = new ModConfigurationKey<bool>("Set Location?", "Set Location of Inject Grabbable slot with dynamic value variable of World/InjectGrabbableRootLocation", () => false); //Optional config settings

        /* ========== Our Hook into the game ========== */

        public override void OnEngineInit()
        {
            Config = GetConfiguration();
            Config?.Save(true);

            Engine.Current.RunPostInit(() =>
            {
                Engine.Current.WorldManager.WorldAdded += SetupWorld;
            });
        }
    }
}