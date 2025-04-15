using Cysharp.Threading.Tasks;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class FireBaseInitialization : IInitializationAsync
    {
        public async UniTask InitializationAsync()
        {
            var fireBaseRes = Services.Instance.DataResourcePrefabs.ServicesObject.GetFireBaseStarter();
            var fireBase = GameObject.Instantiate(fireBaseRes);
            await UniTask.Yield();
        }
    }
}
