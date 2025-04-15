using System;

namespace Behaviours
{
    [Serializable]
    class ConfigDataConversion
    {
        public string AppFlyerID;
        public string BundleID;
        public string Os;
        public string StoreId;
        public string Locale;
        public string PushToken;
        public string FirebaseProjectID;

        public ConfigDataConversion(string appFlyerID = null, string bundleID = null,
            string os = null,string storeId = null, string locale = null,
            string pushToken = null, string firebaseProjectID = null)
        {
            AppFlyerID = appFlyerID;
            BundleID = bundleID;
            Os = os;
            StoreId = storeId;
            Locale = locale;
            PushToken = pushToken;
            FirebaseProjectID = firebaseProjectID;
        }
    }
}
