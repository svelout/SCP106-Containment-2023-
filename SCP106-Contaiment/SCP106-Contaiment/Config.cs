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
            "WARNING . DETECTED ATTEMPT OF ACTIVATING SCP 1 0 6 CONTAINMENT . STARTING ELECTROMAGNETISM DEVICE FOR CONTAINING . LEFT 90 SECONDS",
            "BIOLOGICAL ORGANISM DETECTED . SCP 1 0 6 CONTAINMENT READY TO START . CONTAMINATION START IN 3 . 2 . 1",
            "WARNING . DEVICE STARTING COMPLETED SUCCESSFULLY . PLEASE PUT BIOLOGICAL ORGANISM IN CONTAIN FACILITY .G2 AND RUN PROTOCOLS OF CONTAINMENT"
        };
        public List<string> hints { get; set; } = new List<string>() 
        {
            "Необходимо активировать все генераторы",
            "Нажмите L CTRL для подготовки условия содержания",
            "Нажмите L CTRL для запуска условия содержания",
            "Вы не можете запустить условие содержания так как в комнате нет биологического объекта"
        };
        
    }
}
