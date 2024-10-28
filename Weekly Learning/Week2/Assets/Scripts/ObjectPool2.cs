using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool2 : MonoBehaviour
{
    private Queue<GameObject> pool;

    private const int minSize = 50;
    private const int maxSize = 300;


    void Awake()
    {
        pool = new Queue<GameObject>();
        for(int i = 0; i < minSize; i++)
        {
            pool.Enqueue(CreateObject());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            GetObject();
            Debug.Log($"현재 오브젝트 {pool.Count}개");
        }
    }

    private GameObject CreateObject()
    {
        // [요구스펙 1] Create Object
        GameObject newObj = new GameObject();
        newObj.SetActive(false);
        return newObj;
    }

    public GameObject GetObject()
    {
        // [요구스펙 2] Get Object
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        
        if(pool.Count < maxSize)
        {
            GameObject newObj = CreateObject();
            pool.Enqueue(newObj);
            newObj.SetActive(true);
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
        obj.SetActive(false);
    }
}
