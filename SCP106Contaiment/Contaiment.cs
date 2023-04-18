/*
 *
 *
 * This code made by Svelout
 * All questions. Telegram: @svelout
 *
 * 
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CommandSystem.Commands.RemoteAdmin;
using Exiled.API.Enums;
using Exiled.API.Features;
using MEC;
using PlayerRoles;
using UnityEngine;

namespace SCP106Contaiment;

public class Contaiment
{
    public static bool IsReady = false;
    public static bool IsStarted = false;
    public static bool IsWorking = false;
    public static bool IsUsed = false;
    public static bool IsHint = false;

    public static void PrepareToContaiment()
    {
        Cassie.Message(Plugin.Instance.Config.cassie_messages["Сообщение, которое касье объявит после запуска подготовки условия содержаний"]);
        Timer();
        IsWorking = true;
    }

    public static void StartContaiment(Player victim, Player scp106)
    {
        IsWorking = true;
        victim.Kill(DamageType.Unknown);
        Cassie.Message(Plugin.Instance.Config.cassie_messages["Сообщение, которое касье скажет после запуска условия содержаний"]);
        Kill:
        while (Cassie.IsSpeaking) {}

        Timing.RunCoroutine(DeadTimer(scp106));
    }
    private static IEnumerator<float> Timer()
    {
        yield return Timing.WaitForSeconds(90f);
        Cassie.Message(Plugin.Instance.Config
            .cassie_messages["Сообщение, которое касье объявит после завершения подготовки условия содержания"]);
        IsReady = true;
    }

    private static IEnumerator<float> DeadTimer(Player scp106)
    {
        yield return Timing.WaitForSeconds(2.5f);
        scp106.Kill(DamageType.Custom);
        IsWorking = false;
        IsUsed = true;
    }
}    