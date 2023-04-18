/*
 *
 *
 * This code made by Svelout
 * All questions. Telegram: @svelout
 *
 * 
 */

using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCP106Contaiment
{
    public class Translation : ITranslation
    {
        [Description("Format of hint")] 
        public string message { get; set; } = "<size=50%%><color=(COLOR)><b>(HINT)</b></color></size>";
    }
}