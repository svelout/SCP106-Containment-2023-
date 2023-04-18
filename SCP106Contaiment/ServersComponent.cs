/*
 *
 *
 * This code made by Svelout
 * All questions. Telegram: @svelout
 *
 * 
 */

using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Features;
using MEC;
using UnityEngine;

namespace SCP106Contaiment
{
    public class ServersComponent : MonoBehaviour
    {
        public static GameObject Serv = GameObject.Find("ContBox");
        private float hint_timeupdate = 1.5f;

        private void Update()
        {
            if (Vector3.Distance(transform.position, Serv.transform.position) <= 3f && !Contaiment.IsHint)
            {
                Timing.RunCoroutine(ShowHints(Player.Get(gameObject)));
            }
        }
        
        private IEnumerator<float> ShowHints(Player player)
        {
            Contaiment.IsHint = true;
            for (;;)
            {
                yield return Timing.WaitForSeconds(1f);
                if (Vector3.Distance(transform.position, Serv.transform.position) > 3f)
                {
                    Contaiment.IsHint = false;
                    yield break;
                }
                if (!Contaiment.IsWorking && !Contaiment.IsUsed)
                {
                    if (EventHandlers.Scp106 == null  && Player.Get(gameObject).Role.Side != Side.Scp)
                    {
                        player.ShowHint(Plugin.Instance.Translation.message
                            .Replace("(COLOR)", Plugin.Instance.Config.HintColor)
                            .Replace("(HINT)",
                                Plugin.Instance.Config.hints[
                                    "Хинт, который будет высвечиваться если scp 106 нет в игре"]), hint_timeupdate);
                    }

                    if (EventHandlers.Scp106 != null && !Contaiment.IsReady && !Contaiment.IsStarted && Player.Get(gameObject).Role.Side != Side.Scp)
                    {
                        player.ShowHint(Plugin.Instance.Translation.message
                            .Replace("(COLOR)", Plugin.Instance.Config.HintColor)
                                .Replace("(HINT)",
                                    Plugin.Instance.Config.hints["Хинт, для подготовки условия содержания"]), hint_timeupdate);
                    }

                    if (EventHandlers.Scp106 != null && Contaiment.IsReady && !Contaiment.IsStarted && Player.Get(gameObject).Role.Side != Side.Scp)
                    {
                        player.ShowHint(Plugin.Instance.Translation.message
                            .Replace("(COLOR)", Plugin.Instance.Config.HintColor)
                            .Replace("(HINT)",
                                Plugin.Instance.Config.hints["Хинт, для запуска условий содержания"]), hint_timeupdate);
                    }
                }
            }
        }
    }
}

