using Core.UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UILevelProgressView : UIElement, IUserDataGameLevelProgressListener
    {
        [SerializeField] private Image progress;

        public void OnUserDataGameLevelProgress(GameEntity entity, float value)
        {
            progress.fillAmount = value;
        }
    }
}