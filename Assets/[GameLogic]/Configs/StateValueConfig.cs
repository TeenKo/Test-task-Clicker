using Core.Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StateValueConfig", menuName = "Configs/Game/StateValueConfig")]
public sealed class StateValueConfig : Config
{
    public float loadingTime;
}
