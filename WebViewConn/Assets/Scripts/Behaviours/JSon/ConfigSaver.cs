using Helpers;
using System;
using System.IO;
using UnityEngine;

namespace Behaviours
{
    sealed class ConfigSaver : IEventListener<ConfigDataEvent>, IDisposable
    {
        private ConfigDataConversion _configData;
        private JsonSerializer<ConfigDataConversion> _jsonSerializer;

        private string _folderName = "ConfigData";
        private string _fileName = "Config.json";
        private string _path;

        public ConfigSaver()
        {
            _path = Path.Combine(Application.dataPath, _folderName);

            _configData = new ConfigDataConversion();
            _jsonSerializer = new JsonSerializer<ConfigDataConversion>();

            CheckDirectory();

            this.EventStartListening<ConfigDataEvent>();
        }
        public void Dispose()
        {
            this.EventStopListening<ConfigDataEvent>();
        }

        public void Save(ConfigDataConversion configData)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            _configData = configData;

            _jsonSerializer.Save(_configData, Path.Combine(_path, _fileName));
        }
        public ConfigDataConversion Load()
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return null;
            _configData = _jsonSerializer.Load(file);

            Debug.Log(_configData);
            return _configData;
        }
        private void CheckDirectory()
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
                _jsonSerializer.Save(_configData, Path.Combine(_path, _fileName));
            }
        }

        public void OnEventTrigger(ConfigDataEvent eventType)
        {
            Save(eventType.ConfigData);
        }
    }
}
