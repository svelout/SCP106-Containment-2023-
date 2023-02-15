using System;
using System.Threading;
using Exiled.API.Enums;
using Exiled.API.Features;
using UnityEngine;

namespace SCP106_Contaiment
{
    public class Contaiment
    {
        private float[] positions = new float[788];
        // 47,852 47.063
        
        internal void InjectPositions()
        {
            int x = 0;
            for (float pos = 47.852f; pos > 47.063f;pos -= 0.001f)
            {
                positions[x] = pos;
                x++;
            }
        }
        public bool contaiment_ready = false;
        public void StartingContaiment(Player player, Player _object, Player scp_106)
        {            
            if (scp_106 != null && scp_106.Role.Type == PlayerRoles.RoleTypeId.Scp106)
            {
                if (_object != null && player.CurrentRoom.Type == RoomType.Hcz106 && _object.CurrentRoom.Type == RoomType.Hcz106 && contaiment_ready == true)
                {
                    _object.Position.Set(79.813f, -999.107f, 5.695f);
                    _object.EnableEffect(EffectType.Stained, 14);
                    Cassie.Message(Plugin.Instance.Config.cassie[2]);
                    Thread.Sleep(14);
                    _object.DisableAllEffects();
                    _object.Kill(DamageType.Tesla);
                    scp_106.EnableEffect(EffectType.Stained, 2);
                    Thread.Sleep(2);
                    scp_106.DisableAllEffects();
                    scp_106.Kill(DamageType.Custom);
                }
            }
        }

        internal void GetPos(Player player, ref bool get_pos)
        {
            if (Array.Exists(positions, element => element == player.Position.x) &&
                player.Position.y == -999.106f && player.Position.z == 140.211f)
                {
                    get_pos = true;
                }
            else get_pos = false;
        }

        public void OnEnabled(Player player)
        {          
            if (player.CurrentRoom.Type == RoomType.Hcz106)
            {
                Cassie.Message(Plugin.Instance.Config.cassie[1]);
                contaiment_ready = true;
            }
        }
    }
}
