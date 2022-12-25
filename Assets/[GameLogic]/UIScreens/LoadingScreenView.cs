using Core.Configs;
using Core.UI;
using Entitas;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenView : UIScreen, IAnyLoadingListener, IAnyLoadingTimerListener
{
    [SerializeField] private Image LoadingImage;
    [SerializeField] private TextMeshProUGUI LoadingText;

    private StateValueConfig _stateValueConfig;

    public override void Init(IEntity iEntity)
    {
        base.Init(iEntity);
        var stateEntity = Contexts.sharedInstance.state.CreateEntity();
        stateEntity.AddAnyLoadingListener(this);
        stateEntity.AddAnyLoadingTimerListener(this);

        _stateValueConfig = ConfigsCatalogsManager.GetConfig<StateValueConfig>();
    }

    public void OnAnyLoading(StateEntity entity)
    {
        Open();
    }

    public void OnAnyLoadingTimer(StateEntity entity, float value)
    {
        var loadingTime = _stateValueConfig.loadingTime;
        var currentvalue = (loadingTime - value) / loadingTime;
        LoadingImage.fillAmount = currentvalue;
        LoadingText.text = $"{(int)(currentvalue * 100)}%";
    }
}
