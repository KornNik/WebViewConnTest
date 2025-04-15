using AppsFlyerSDK;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class ConfigAppsFlyerFiller
    {
        public void Fill()
        {
            var configData = Services.Instance.ConfigSaver.ServicesObject.Load();
            configData.AppFlyerID = AppsFlyer.instance.getAppsFlyerId();
            configData.BundleID = AppsFlyer.getAppsFlyerId();
            configData.Os = Application.platform.ToString();
            if (Application.platform == RuntimePlatform.Android)
            {
                configData.StoreId = AppsFlyer.getAppsFlyerId();
            }
            else if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                configData.StoreId = AppsFlyer.getAppsFlyerId();
            }
            configData.Locale = Application.systemLanguage.ToString();

            ConfigDataEvent.Trigger(configData);
        }
    }
}
