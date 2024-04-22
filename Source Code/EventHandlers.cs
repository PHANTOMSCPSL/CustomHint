using System.Collections.Generic;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using MEC;
using PlayerRoles;
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
                    Dictionary<RoleTypeId, string> roleColorDict = new Dictionary<RoleTypeId, string>()
                    {
                        {RoleTypeId.ClassD, "FF8E00"},
                        {RoleTypeId.Scientist,"FFFF7C"},
                        {RoleTypeId.FacilityGuard, "5B6370"},
                        {RoleTypeId.NtfCaptain, "003ECA"},
                        {RoleTypeId.NtfSergeant, "0096FF"},
                        {RoleTypeId.NtfSpecialist, "0096FF"},
                        {RoleTypeId.NtfPrivate, "6FC3FF"},
                        {RoleTypeId.ChaosRepressor, "006728"},
                        {RoleTypeId.ChaosMarauder, "006728"},
                        {RoleTypeId.ChaosRifleman, "006728"},
                        { RoleTypeId.ChaosConscript, "006728"}
                    };
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
                    
                    foreach (Player player in Player.List) {
                        player.ShowHint($"<b><size=15>         <color=#{roleColorDict[player.Role.Type]}>{HintMessage}</color></size></align>",
                            50);
                    }
                }
                yield return Timing.WaitForSeconds(1f);
            }
            // ReSharper disable once IteratorNeverReturns
        }
    }
}