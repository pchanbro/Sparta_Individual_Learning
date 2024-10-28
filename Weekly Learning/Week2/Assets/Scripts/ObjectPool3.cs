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
        // [�䱸���� 1] Create Object
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
            Debug.Log($"���� ������Ʈ {pool.Count}��");
        }
    }

    public GameObject GetObject()
    {
        // [�䱸���� 2] Get Object
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
        // [�䱸���� 3] Release Object
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
