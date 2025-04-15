using Cysharp.Threading.Tasks;

namespace Behaviours
{
    sealed class ConfigFillerInitialzier : IInitializationAsync
    {
        public async UniTask InitializationAsync()
        {
            var configAppsFlyerFiller = new ConfigAppsFlyerFiller();
            configAppsFlyerFiller.Fill();
            await UniTask.Yield();
        }
    }
}
