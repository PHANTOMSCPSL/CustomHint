using Exiled.API.Interfaces;
using System.ComponentModel;

namespace CustomHint
{
    public class Config : IConfig
    {
        [Description("This Plugin Enabled?")] public bool IsEnabled { get; set; } = true;
        [Description("Plugin debug?")] public bool Debug { get; set; } = false;

        [Description("Hint message, {tps}, {MinPlayers}, {MaxPlayers}, {Minutes}, {Seconds}, {ServerName}, {SCPs}...")]
        public string Hint { get; set; } = "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n<align=left>\n         \ud83d\udd51 | <color=#ffffff>The round lasts - {Minutes}:{Seconds}</color>\n         \ud83d\udc65 | <color=#ffffff>Players: {MinPlayers}/{MaxPlayers}</color>\n         \ud83d\udcdf | <color=#ffffff>TPS: {tps}</color>\n         \ud83c\udfae | <color=#ffffff>The server: {ServerName}</color>";
    }
}