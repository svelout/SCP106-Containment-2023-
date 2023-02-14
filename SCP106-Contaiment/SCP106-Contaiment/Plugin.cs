using Exiled.API.Features;

namespace SCP106_Contaiment
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "SCP106_Contaiment";
        public override string Author => "SveloutDevelop";
        public override string Prefix => "sсp106contmnt";

        public static Plugin Instance;

        public override void OnEnabled()
        {
            Instance = this;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
        }
    }
}
