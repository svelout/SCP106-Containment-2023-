/*
 *
 *
 * This code made by Svelout
 * All questions. Telegram: @svelout
 *
 * 
 */

using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace SCP106Contaiment
{
    public class EventHandlers
    {
        public static Player Scp106 = null;
        public void OnPlayerVerified(VerifiedEventArgs e)
        {
            e.Player.GameObject.AddComponent<ServersComponent>();
        }

        public void OnProcessingHotKey(ProcessingHotkeyEventArgs e)
        {
            if (e.Hotkey is HotkeyButton.Keycard && !Contaiment.IsWorking && !Contaiment.IsUsed && Contaiment.IsHint)
            {
                if (!Contaiment.IsReady)
                {
                    Contaiment.PrepareToContaiment();
                }
                else if (!Contaiment.IsStarted)
                {
                    Contaiment.StartContaiment(e.Player, Scp106);
                }
            }
        }

        public void OnPlayerLeft(LeftEventArgs e)
        {
            if (e.Player.Role.Type is RoleTypeId.Scp106)
            {
                Scp106 = null;
            }
        }

        public void OnPlayerChangedRole(ChangingRoleEventArgs e)
        {
            if (e.Player.Role.Type is RoleTypeId.Scp106)
            {
                Scp106 = null;
                Log.Info($"{e.Player.Role}");
            }
            if (e.NewRole is RoleTypeId.Scp106 && !Contaiment.IsUsed)
            {
                Scp106 = e.Player;
                Log.Info("Scp106 founded!");
            }
        }
    }
}