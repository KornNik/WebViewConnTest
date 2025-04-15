using Cysharp.Threading.Tasks;
using Helpers;

namespace Behaviours
{
    sealed class ConfigSaverInitializer : IInitializationAsync
    {
        public async UniTask InitializationAsync()
        {
            var configSaver = new ConfigSaver();
            Services.Instance.ConfigSaver.SetObject(configSaver);
            await UniTask.Yield();
        }
    }
}
