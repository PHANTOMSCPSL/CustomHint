using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Discord;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using MEC;
using PlayerRoles;
using PlayerRoles.FirstPersonControl;
using PluginAPI.Core;
using PluginAPI.Roles;
using RemoteAdmin.Communication;
using YamlDotNet.Core;
using static Exiled.API.Enums.GeneratorState;
using Player = Exiled.API.Features.Player;
using Round = Exiled.API.Features.Round;
using Server = Exiled.API.Features.Server;

namespace CustomHint
{
    public class EventHandlers
    {
        private CoroutineHandle _coroutine;
        
        public void roldeis(ChangingRoleEventArgs ev)
        {
            _coroutine = Timing.RunCoroutine(cor());
        }
        public void roundended(RoundEndedEventArgs ev)
        {
            Timing.KillCoroutines(_coroutine);
        }
        
        public IEnumerator<float> cor()
        {
            while (true)
            {
                {
                    string HintMessage = Plugin.Instance.Config.Hint.Replace("%tps%", Server.Tps.ToString())
                        .Replace("{MinPlayers}", Server.PlayerCount.ToString())
                        .Replace("{MaxPlayers}", Server.MaxPlayerCount.ToString())
                        .Replace("{Minutes}", Round.ElapsedTime.Minutes.ToString())
                        .Replace("{Seconds}", Round.ElapsedTime.Seconds.ToString())
                        .Replace("%NameServer%", Server.Name)
                        .Replace("{FF}", Server.FriendlyFire.ToString())
                        .Replace("{ServerName}", Server.Name)
                        .Replace("{SCPs}", Round.SurvivingSCPs.ToString())
                        .Replace("{UserRole}", RoleTranslations.RoleNamesFile);
                    
                    foreach (Player player in Player.List)
                    {
                        if (player.Role.Type == RoleTypeId.ClassD)
                        {
                            player.ShowHint($"<b><size=15>         <color=#FF8E00>{HintMessage}</color></size></align>", 50);
                        }
                        if (player.Role.Type == RoleTypeId.Scientist)
                        {
                            player.ShowHint($"<b><size=15>         <color=#FFFF7C>{HintMessage}</color></size></align>", 50);
                        }
                        if (player.Role.Type == RoleTypeId.FacilityGuard)
                        {
                            player.ShowHint($"<b><size=15>         <color=#5B6370>{HintMessage}</color></size></align>", 50);
                        }
                        if (player.Role.Type == RoleTypeId.NtfCaptain)
                        {
                            player.ShowHint($"<b><size=15>         <color=#003ECA>{HintMessage}</color></size></align>", 50);
                        }
                        if (player.Role.Type == RoleTypeId.NtfSergeant)
                        {
                            player.ShowHint($"<b><size=15>         <color=#0096FF>{HintMessage}</color></size></align>", 50);
                        }
                        if (player.Role.Type == RoleTypeId.NtfSpecialist)
                        {
                            player.ShowHint($"<b><size=15>         <color=#0096FF>{HintMessage}</color></size></align>", 50);
                        }
                        if (player.Role.Type == RoleTypeId.NtfPrivate)
                        {
                            player.ShowHint($"<b><size=15>         <color=#6FC3FF>{HintMessage}</color></size></align>", 50);
                        }
                        if (player.Role.Type == RoleTypeId.ChaosRepressor)
                        {
                            player.ShowHint($"<b><size=15>         <color=#006728>{HintMessage}</color></size></align>", 50);
                        }
                        if (player.Role.Type == RoleTypeId.ChaosMarauder)
                        {
                            player.ShowHint($"<b><size=15>         <color=#006728>{HintMessage}</color></size></align>", 50);
                        }
                        if (player.Role.Type == RoleTypeId.ChaosRifleman)
                        {
                            player.ShowHint($"<b><size=15>         <color=#006728>{HintMessage}</color></size></align>", 50);
                        }
                        if (player.Role.Type == RoleTypeId.ChaosConscript)
                        {
                            player.ShowHint($"<b><size=15>         <color=#006728>{HintMessage}</color></size></align>", 50);
                        }
                    }
                }
                yield return Timing.WaitForSeconds(1f);
            }
            // ReSharper disable once IteratorNeverReturns
        }
    }
}