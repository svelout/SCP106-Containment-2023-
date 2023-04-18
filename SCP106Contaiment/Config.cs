/*
 *
 *
 * This code made by Svelout
 * All questions. Telegram: @svelout
 *
 * 
 */

using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCP106Contaiment
{
    public class Config : IConfig
    {
        [Description("Включение/Выключение плагина")]
        public bool IsEnabled { get; set; } = true;

        [Description("Включение/Выключение дебага")] 
        public bool Debug { get; set; } = false;

        [Description("Цвет хинтов, которые появляются при подходе к объекту(ПИСАТЬ HEX КОД ЦВЕТА)")] 
        public string HintColor { get; set; } = "#FF0000";

        [Description("Сами хинты")]
        public Dictionary<string, string> hints { get; set; } = new()
        {
            {
                "Хинт, для подготовки условия содержания", 
                "Нажмите L CTRL для подготовки условия содержания"
            },
            {
                "Хинт, для запуска условий содержания",
                "Нажмите L CTRL для запуска условия содержания"
            },
            {
                "Хинт, который будет высвечиваться если scp 106 нет в игре",
                "Недоступно"
            }
        };

        [Description("Сообщения C.A.S.S.I.E")]
        public Dictionary<string, string> cassie_messages { get; set; } = new()
        {
            {
                "Сообщение, которое касье объявит после запуска подготовки условия содержаний",
                "WARNING . DETECTED ATTEMPT OF ACTIVATING SCP 1 0 6 CONTAINMENT . STARTING ELECTROMAGNETISM DEVICE FOR CONTAINING . LEFT 90 SECONDS"
            },
            {
                "Сообщение, которое касье объявит после завершения подготовки условия содержания",
                "WARNING . ELECTROMAGNETISM DEVICE STARTING COMPLETED SUCCESSFULLY . PLEASE PUT BIOLOGICAL ORGANISM IN CONTAIN FACILITY .G2 AND RUN PROTOCOLS OF CONTAINMENT"
            },
            {
                "Сообщение, которое касье скажет после запуска условия содержаний",
                "BIOLOGICAL ORGANISM DETECTED . CONTAMINATION START IN 3 . 2 . 1"
            }
        };
    }
}