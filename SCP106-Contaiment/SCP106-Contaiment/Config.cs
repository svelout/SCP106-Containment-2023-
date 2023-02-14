using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace SCP106_Contaiment
{
    public class Config : IConfig
    {
        [Description("Включен ли плагин")]
        public bool IsEnabled { get; set; } = true;

        [Description("Дебаг лог плагина")]
        public bool Debug { get; set; } = false;
        [Description("Список фраз касье")]
        public List<string> cassie { get; set; } = new List<string>()
        {
            "WARNING . DETECTED ATTEMPT OF ACTIVATING SCP 1 0 6 CONTAINMENT . PLEASE PUT BIOLOGICAL ORGANISM IN CONTAIN FACILITY .G2 AND RUN PROTOCOLS OF CONTAINMENT",
            "BIOLOGICAL ORGANISM DETECTED . SCP 1 0 6 CONTAINMENT READY TO START . CONTAMINATION START IN 3 . 2 . 1",
        };
    }
}
