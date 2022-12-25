using Core.Configs;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfigsCatalog", menuName = "Configs/Game/GameConfigsCatalog")]
public sealed class GameConfigsCatalog : ConfigsCatalog
{
    [SerializeField] private GameConfig gameConfig;
    [SerializeField] private DebugLogConfig debugLogConfig;
    [SerializeField] private StateValueConfig stateValueConfig;
    [SerializeField] private GameObjectNamingConfig gameObjectNamingConfig;
}