using Cysharp.Threading.Tasks;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class AppsFlyerInitialization : IInitializationAsync
    {
        public async UniTask InitializationAsync()
        {
            var appsFlyerRes = Services.Instance.DataResourcePrefabs.ServicesObject.GetsAppsFlyer();
            var appsFlyer = GameObject.Instantiate(appsFlyerRes);
            await UniTask.Yield();
        }
    }
}
