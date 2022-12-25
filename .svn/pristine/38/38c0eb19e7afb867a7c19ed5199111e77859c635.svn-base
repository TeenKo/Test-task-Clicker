using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //Singleton
    public static ObjectPooler Instance;
    private ObjectInfo.ObjectType _lastType = ObjectInfo.ObjectType.None;

    //A class containing information about object and its type
    [Serializable]
    public struct ObjectInfo
    {
        public enum ObjectType
        {
            Sphere,
            Virus,
            WinCup,
            None
        }

        public ObjectType Type;
        public GameObject Prefab;
        public int StartCount;
    }

    //A list of parameters for objects
    [SerializeField]
    private List<ObjectInfo> objectsInfo;
    //A pooler, that holds the objectinfo, and its type as a key
    private Dictionary<ObjectInfo.ObjectType, Pool> pools;

    private void Awake()
    {
        if (Instance == null)
        Instance = this;
        InitPool();
    }

    //Initialization of a pool
    private void InitPool()
    {
        pools = new Dictionary<ObjectInfo.ObjectType, Pool>();
        var emptyGO = new GameObject();

        foreach (var obj in objectsInfo)
        {
            //Instantiating an empty object as a container to hold other pooled objects with the same type
            var container = Instantiate(emptyGO, transform, false);
            container.name = obj.Type.ToString();

            //Search the dictionary with given key, and then assing it a new pool
            pools[obj.Type] = new Pool(container.transform);

            //Instantiate all objects of the said type
            for (int i = 0; i < obj.StartCount; i++)
            {
                var go = InstantiateObject(obj.Type,container.transform , i);
                pools[obj.Type].Objects.Enqueue(go);
            }
        }

        
        Destroy(emptyGO);
    }

    //Separate instantiate method to create object with specific name
    private GameObject InstantiateObject(ObjectInfo.ObjectType type, Transform parent , int countInstance)
    {
        var go = Instantiate(objectsInfo.Find(x => x.Type == type).Prefab, parent);
        go.name = go.name.ToString() + countInstance;
        go.SetActive(false);
        return go;
    }

    public GameObject GetObject(ObjectInfo.ObjectType type)
    {
        var obj = pools[type].Objects.Count > 0 ?
                  pools[type].Objects.Dequeue() :
        InstantiateObject(type, pools[type].Container, pools[type].Container.childCount);

        obj.SetActive(true);
        _lastType = type;
        return obj;
    }

    public void DestroyObject(GameObject obj)
    {
        pools[obj.GetComponent<IPooledObject>().Type].Objects.Enqueue(obj);
        obj.SetActive(false);
        obj.transform.position = new Vector3(1000, 1000, 1000);
    }

    public void RefreshAllPoolQueue()
    {
        foreach (var item in pools)
        {
            item.Value.Refresh();
        }
    }
}
