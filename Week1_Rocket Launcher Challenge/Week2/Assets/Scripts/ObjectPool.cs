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
        if(Input.GetKey(KeyCode.V))
        {
            CreateObject();
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
    }

    public void ReleaseObject(GameObject obj)
    {
        // [요구스펙 3] Release Object
    }

}
