using UnityEngine;
using UnityEngine.EventSystems;

public class StartGameButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var transitionEntity = Contexts.sharedInstance.state.appStateEntity;
        transitionEntity.transitionLoading = true;
        transitionEntity.isToGame = true;
    }
}
