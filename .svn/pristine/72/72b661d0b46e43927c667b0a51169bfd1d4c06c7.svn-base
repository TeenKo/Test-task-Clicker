using Entitas;
using UnityEngine;

namespace Core.DeveloperMode
{
    /// <summary>
    /// Система ввода в режиме эдитора
    /// </summary>
    public class EditorInputSystem : IExecuteSystem
    {
        private readonly Contexts _contexts;

        public EditorInputSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Execute()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
            {
                _contexts.state.appStateEntity.transitionGame = true;
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
            {
                _contexts.state.appStateEntity.transitionVictory = true;
            }
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
            {
                _contexts.state.appStateEntity.transitionDefeat = true;
            }
        }
    }
}