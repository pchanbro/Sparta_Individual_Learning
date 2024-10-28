using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> pool;
    private const int minSize = 50;
    private const int maxSize = 300;

    public GameObject objectPrefab;

    void Awake()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < minSize; i++)
        {
            pool.Add(CreateObject());
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            GetObject();
            Debug.Log($"현재 오브젝트 {pool.Count}개");
        }
    }

    private GameObject CreateObject()
    {
        // [요구스펙 1] Create Object
        GameObject newObj = Instantiate(objectPrefab);
        newObj.SetActive(false);
        return newObj;
    }

    public GameObject GetObject()
    {
        // [요구스펙 2] Get Object
        foreach(GameObject obj in pool)
        {
            if(!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        if(pool.Count < maxSize)
        {
            GameObject newObj = CreateObject();
            pool.Add(newObj);
            newObj.SetActive(true);
            return newObj;
        }
        else
        {
            GameObject tempObj = Instantiate(objectPrefab);
            tempObj.SetActive(true);
            return tempObj;
        }
    }

    public void ReleaseObject(GameObject obj)
    {
        // [요구스펙 3] Release Object
        if(!pool.Contains(obj))
        {
            Destroy(obj);
        }
        else
        {
            obj.SetActive(false);
        }
    }
}
