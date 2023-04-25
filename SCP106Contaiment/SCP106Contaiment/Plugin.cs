/*
 *
 *
 * This code made by Svelout
 * All questions. Telegram: @svelout
 *
 * 
 */

using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;
using Server = Exiled.Events.Handlers.Server;

namespace SCP106Contaiment
{
    public class Plugin : Plugin<Config, Translation>
    {
        public override string Name => "SCP106Contaiment";
        public override string Author => "SveloutDevelop";
        public override string Prefix => "scp106contaiment";

        private EventHandlers _eh;
        public static Plugin Instance;

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
            _eh = new();
            Server.WaitingForPlayers += _eh.OnWaitingForPlayers;
            Player.ChangingRole += _eh.OnPlayerChangedRole;
            Player.Verified += _eh.OnPlayerVerified;
            Player.ProcessingHotkey += _eh.OnProcessingHotKey;
            Player.Left += _eh.OnPlayerLeft;
        }

        public void OnUnRegisterEvents()
        {
            _eh = null;
            Server.WaitingForPlayers -= _eh.OnWaitingForPlayers;
            Player.ChangingRole -= _eh.OnPlayerChangedRole;
            Player.Verified -= _eh.OnPlayerVerified;
            Player.ProcessingHotkey -= _eh.OnProcessingHotKey;
            Player.Left -= _eh.OnPlayerLeft;
        }
    }
}