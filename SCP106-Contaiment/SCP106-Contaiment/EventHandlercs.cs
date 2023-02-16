using System;
using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using MEC;
using Exiled.API.Enums;

namespace SCP106_Contaiment
{
    public class EventHandlers : Contaiment
    {
        public bool first_start = false;
        public void OnWaitingForPlayers()
        {
            InjectPositions();
        }
        private bool IsGeneratesActivated()
        {
            int count = 0;
            IEnumerator<Generator> e = Generator.List.GetEnumerator();
            while (e.MoveNext()) { if (e.Current.IsEngaged == true) count++; else continue; }                          
            if (count == 3) return true;
            else return false;
        }

        public void OnProccesingHotKey(ProcessingHotkeyEventArgs ev)
        {
            Player _object = null;
            Player scp_106 = null;
            bool get_pos = false;
            GetPos(ev.Player, ref get_pos);
            if (get_pos != true)
                return;
            if (first_start == false)
            {
                OnEnabled(ev.Player);
                first_start = true;
            }
            if (ev.Hotkey == HotkeyButton.Keycard && ev.Player.CurrentRoom.Type == RoomType.Hcz106 && ev.Player.Role.Side != Side.Scp && first_start != false)
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
                    if (count == 2 && contaiment_ready == true)
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
        public void OnChangingMoveState(ChangingMoveStateEventArgs ev)
        {
            bool get_pos = false;
            GetPos(ev.Player, ref get_pos);
            if (get_pos != true)
            {
                if (Timing.CurrentCoroutine != null) Timing.KillCoroutines();
                return;
            }               
            Timing.RunCoroutine(ContaimentMenuHint(ev.Player, ev.Player.CurrentRoom));
        }

        private IEnumerator<float> ContaimentMenuHint(Player player, Room room) 
        {
            for (; ; )
            {
                int count = 0;
                IEnumerator<Player> __enum = room.Players.GetEnumerator();
                while (__enum.MoveNext())
                    count++;
                yield return Timing.WaitForSeconds(1f);
                if (IsGeneratesActivated() == false)
                {
                    player.ShowHint(Plugin.Instance.Config.hints[1]);
                }
                if (first_start == true && count < 2 && IsGeneratesActivated() != true)
                {
                    player.ShowHint(Plugin.Instance.Config.hints[4]);
                }
                if (first_start != false && IsGeneratesActivated() != true)
                {
                    player.ShowHint(Plugin.Instance.Config.hints[3]);
                }
                if (first_start == false && IsGeneratesActivated() != true)
                {
                    player.ShowHint(Plugin.Instance.Config.hints[2]);
                }
            }
        }
    }
}