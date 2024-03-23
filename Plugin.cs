using Exiled.API.Features;
using Playerev = Exiled.Events.Handlers.Player;
using SRV = Exiled.Events.Handlers.Server;

namespace CustomHint
{

    public class Plugin : Plugin<Config>
    {
        public override string Author => "Greyzer";

        public override string Name => "CustomHint";

        public override string Prefix => Name;

        public static Plugin Instance;

        private EventHandlers _handlers;

        public override void OnEnabled()
        {
            Instance = this;

            RegisterEvents();

            base.OnEnabled();
            Log.Info("Успешно активен");
        }

        public override void OnDisabled()
        {
            UnregisterEvents();

            Instance = null;

            base.OnDisabled();
            Log.Info("Успешно неактивен");
        }

        private void RegisterEvents()
        {
            _handlers = new EventHandlers();
            Playerev.ChangingRole += _handlers.roldeis;
            SRV.RoundEnded += _handlers.roundended;
            Log.Info("REGISTERED");

        }

        public int UpdateRateInSeconds { get; set; }

        private void UnregisterEvents()
        {
            Playerev.ChangingRole -= _handlers.roldeis;
            SRV.RoundEnded -= _handlers.roundended;
            _handlers = null;
            Log.Info("UNREGISTERED");

        }
    }
}
