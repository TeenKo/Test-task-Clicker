using Core.Configs;
using Entitas;
using UnityEngine;

namespace Core
{
    public sealed class GameCore : MonoBehaviour
    {
        private Contexts _contexts;
        private Systems _gameCoreSystems;

        public delegate void OnAppFocus(bool hasFocus);
        public static event OnAppFocus AppFocus;
        
        public delegate void OnAppPause(bool pauseStatus);
        public static event OnAppPause AppPause;
        
        private void Awake()
        {
            ConfigsCatalogsManager.LoadCatalogs();
            Application.targetFrameRate = 60;
            
            _contexts = Contexts.sharedInstance;
            _gameCoreSystems = new GameCoreSystems(_contexts);
        }

        private void Start()
        {
            _gameCoreSystems.Initialize();
        }

        private void FixedUpdate()
        {
            // if you need physics systems
        }

        private void Update()
        {
            _gameCoreSystems.Execute();
            _gameCoreSystems.Cleanup();
        }

        private void LateUpdate()
        {
            // _gameCoreSystems.Cleanup();
        }

        private void OnDestroy()
        {
            _gameCoreSystems.TearDown();     
        }
        
        private void OnApplicationFocus(bool hasFocus)
        {
            AppFocus?.Invoke(hasFocus);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            AppPause?.Invoke(pauseStatus);
        }
    }
}