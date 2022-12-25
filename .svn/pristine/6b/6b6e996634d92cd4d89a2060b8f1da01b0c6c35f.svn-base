#if FirebaseSDK && !UNITY_EDITOR
using Firebase;
using UnityEngine;
using System;

namespace Adapters.FirebaseAnalytics
{
    public sealed class FirebaseService : IFirebaseService
    {
        public FirebaseAnalyticEvents FirebaseAnalyticEvents { get; private set; }
        private FirebaseApp _firebaseApp;
        
        public void Initialize()
        {
        }

        public void Initialize(Action complete, Action<string> failed)
        {
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Open)
                {
                    _firebaseApp = FirebaseApp.DefaultInstance;
                    var ops = new AppOptions();
                    _firebaseApp = FirebaseApp.Create(ops);

                    FirebaseAnalyticEvents = new FirebaseAnalyticEvents();

                    complete?.Invoke();
                }
                else
                {
                    failed?.Invoke(dependencyStatus.ToString());
                }
            });
        }
    }
}
#endif
