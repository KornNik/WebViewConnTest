using UnityEngine;
using Firebase.Extensions;
using Firebase;
using Helpers;
using Behaviours;

public class FireBaseStarter : MonoBehaviour
{
    private FirebaseApp _app;

    public void Start()
    {
        Init();

        Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
        Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
    }

    public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token)
    {
        Debug.Log("Received Registration Token: " + token.Token);
        var data = Services.Instance.ConfigSaver.ServicesObject.Load();
        data.PushToken = token.Token;
        ConfigDataEvent.Trigger(data);
    }

    public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
    {
        Debug.Log("Received a new message from: " + e.Message.From);
    }
    public void Init()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                 _app = Firebase.FirebaseApp.DefaultInstance;
                var data = Services.Instance.ConfigSaver.ServicesObject.Load();
                data.FirebaseProjectID = _app.Options.ProjectId;
                ConfigDataEvent.Trigger(data);

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }
}
