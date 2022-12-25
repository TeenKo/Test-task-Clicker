using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool //: MonoBehaviour
{
    public Transform Container { get; private set; }

    public Queue<GameObject> Objects;

    public Pool(Transform container)
    {
        Container = container;
        Objects = new Queue<GameObject>();
    }

    public void Refresh()
    {
        Objects.Clear();
        for (int i = 0; i < Container.childCount; i++)
        {
            Objects.Enqueue(Container.GetChild(i).gameObject);
        }
    }
}
