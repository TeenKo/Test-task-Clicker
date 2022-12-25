using Core.UI;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIPlayerMoneyRewardView : UIElement, IUserDataGameLevelListener
    {
        [SerializeField] private TextMeshProUGUI levelCompleteTmp;

        public void OnUserDataGameLevel(GameEntity entity, int value)
        {
            levelCompleteTmp.text = $"Level {value}\nContinue";
        }
    }
}