using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool3 : MonoBehaviour
{
    private Queue<GameObject> pool;
    private const int maxSize = 100;

    void Awake()
    {
        pool = new Queue<GameObject>();
    }

    private GameObject CreateObject()
    {
        // [요구스펙 1] Create Object
        GameObject obj = new GameObject();
        obj.SetActive(false);
        pool.Enqueue(obj);
        return obj;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            GetObject();
            Debug.Log($"현재 오브젝트 {pool.Count}개");
        }
    }

    public GameObject GetObject()
    {
        // [요구스펙 2] Get Object
        if (pool.Count < maxSize)
        {
            GameObject newObj = CreateObject();
            pool.Enqueue(newObj);
            return newObj;
        }
        else
        {
            GameObject oldestObj = pool.Dequeue();
            ReleaseObject(oldestObj);
            pool.Enqueue(oldestObj);
            return oldestObj;
        }
    }

    public void ReleaseObject(GameObject obj)
    {
        // [요구스펙 3] Release Object
        if (!pool.Contains(obj))
        {
            Destroy(obj);
        }
        else
        {
            obj.SetActive(false);
        }
    }
}
