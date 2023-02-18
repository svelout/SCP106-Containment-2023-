using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace SCP106_Contaiment
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "SCP106_Contaiment";
        public override string Author => "SveloutDevelop";
        public override string Prefix => "sсp106contmnt";

        public static Plugin Instance;
        private EventHandlers _eh;

        public override void OnEnabled()
        {
            Instance = this;
            OnRegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            OnUnRegisterEvents();
            base.OnDisabled();
        }

        public void OnRegisterEvents()
        {
            _eh = new EventHandlers();
            Server.RoundStarted += _eh.OnRoundStarted;
            Player.ProcessingHotkey += _eh.OnProccesingHotKey;
            Player.ChangingMoveState += _eh.OnChangingMoveState;

        }
        public void OnUnRegisterEvents()
        {
            _eh = null;
            Server.RoundStarted -= _eh.OnRoundStarted;
            Player.ProcessingHotkey -= _eh.OnProccesingHotKey;
            Player.ChangingMoveState -= _eh.OnChangingMoveState;
        }
    }
}
