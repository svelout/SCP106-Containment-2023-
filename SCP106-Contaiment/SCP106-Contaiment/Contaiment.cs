using System;
using System.Threading;
using Exiled.API.Enums;
using Exiled.API.Features;
using UnityEngine;

namespace SCP106_Contaiment
{
    public class Contaiment : MonoBehaviour
    {
        private float[] positions = new float[3000];
        // 47,852 47.063
        // "_Scences/Facility/HeavyRooms/HCZ_106/" +
        //"Map_HC_106_CR/106_1f/GFX/Main/Furniture_004/Cube"
        public GameObject obj;
        internal GameObject InjectPositions(GameObject obj)
        {
            Room room = Room.Get(RoomType.Hcz106);
            var objects = room.GetComponentsInChildren<GameObject>();
            int x = 0;
            foreach (GameObject cube in objects)
            {
                if (cube.name == "Cube")
                {
                    for (float pos = cube.transform.position.y + cube.transform.localScale.y; pos < cube.transform.localScale.x / 2; pos -= 0.001f)
                    {
                        positions[x] = pos;
                        x++;
                    }
                    x = 0;
                    for (float pos = cube.transform.position.y + cube.transform.localScale.y; pos <= cube.transform.localScale.x / 2; pos += 0.001f)
                    {
                        positions[x] = pos;
                        x++;
                    }
                    obj = cube;
                    break;                   
                }
            }
            return obj.gameObject;
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
                    Thread.Sleep(14000);
                    _object.DisableAllEffects();
                    _object.Kill(DamageType.Tesla);
                    scp_106.EnableEffect(EffectType.Stained, 2);
                    Thread.Sleep(2000);
                    scp_106.DisableAllEffects();
                    scp_106.Kill(DamageType.Custom);
                }
            }
        }

        internal bool GetPos(Player player)
        {
            if (Array.Exists(positions, element => element == player.Position.x) &&
                player.Position.y == -999.106f && player.Position.z == obj.transform.position.y + obj.transform.localScale.y)
            {
                return true;
            }
            else return false;
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
