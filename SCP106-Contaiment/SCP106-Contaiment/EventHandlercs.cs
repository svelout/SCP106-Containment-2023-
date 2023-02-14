using System;
using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace SCP106_Contaiment
{
    public class EventHandlers : Contaiment
    {
        public void OnWaitingForPlayers()
        {
            InjectPositions();
        }

        public void OnProccesingHotKey(ProcessingHotkeyEventArgs ev)
        {
            Player _object = null;
            Player scp_106 = null;
            if (ev.Hotkey == HotkeyButton.Keycard && ev.Player.CurrentRoom.Type == RoomType.Hcz106 && ev.Player.Role.Side != Side.Scp)
            {
                IEnumerator<Player> p_list = Player.List.GetEnumerator();
                while (p_list.MoveNext())
                    if (p_list.Current.Role.Type == RoleTypeId.Scp106)
                        scp_106 = p_list.Current;
                    else continue;
                if (ev.Player.CurrentItem.Type == ItemType.KeycardO5 && ev.Player.CurrentItem.Type == ItemType.KeycardNTFCommander && ev.Player.CurrentItem.Type == ItemType.KeycardChaosInsurgency && scp_106 != null)
                {
                    int count = 0;
                    IEnumerator<Player> enumerator = ev.Player.CurrentRoom.Players.GetEnumerator();
                    while (enumerator.MoveNext())
                        count++;
                    if (count <= 2 && count > 1 && contaiment_ready == true)
                    {
                        enumerator.Reset();
                        while (enumerator.MoveNext())
                        {
                            if (enumerator.Current.Role.Type == RoleTypeId.ClassD)
                            {
                                _object = enumerator.Current;
                            }
                            else continue;
                        }
                        StartingContaiment(ev.Player, _object, scp_106);
                    }
                }
            }
        }
    }
}