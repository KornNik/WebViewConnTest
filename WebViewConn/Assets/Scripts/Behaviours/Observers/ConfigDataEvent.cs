using Helpers;

namespace Behaviours {
    struct ConfigDataEvent
    {
        private ConfigDataConversion _configData;
        private static ConfigDataEvent _configDataEvent;

        public ConfigDataConversion ConfigData => _configData;

        public static void Trigger(ConfigDataConversion configData)
        {
            _configDataEvent._configData = configData;
            EventManager.TriggerEvent(_configDataEvent);
        }
    }
}
