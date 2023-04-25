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
using Object = UnityEngine.Object;

namespace SCP106Contaiment
{
    public class EventHandlers
    {
        public static Player Scp106 = null;

        public void OnWaitingForPlayers()
        {
            Log.Warn("\n***************WARNING***************\n\nPlugin does not work with some SCP-106\nIf plugin finds more SCP-106, it will disabled before next round\n\n*************************************");
        }
        public void OnPlayerVerified(VerifiedEventArgs e)
        {
            if (!Contaiment.IsEnabled)
            {
                e.Player.GameObject.AddComponent<ServersComponent>();
            }
        }

        public void OnProcessingHotKey(ProcessingHotkeyEventArgs e)
        {
            if (e.Hotkey == HotkeyButton.Keycard && !Contaiment.IsWorking && !Contaiment.IsUsed && Contaiment.IsHint)
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
            int count = 0;
            if (e.Player.Role.Type is RoleTypeId.Scp106)
            {
                Scp106 = null;
                Log.Info($"Now SCP-106 is null");
            }
            if (e.NewRole is RoleTypeId.Scp106 && !Contaiment.IsUsed && Contaiment.IsEnabled)
            {
                if (Scp106 != null)
                {
                    Contaiment.IsEnabled = false;
                    foreach (Player player in Player.List)
                    {
                        if (player.GameObject.GetComponent<ServersComponent>())
                        {
                            Object.Destroy(player.GameObject.GetComponent<ServersComponent>());
                        }
                    }
                }
                Scp106 = e.Player;
                Log.Info("SCP-106 founded!");
            }
        }
    }
}