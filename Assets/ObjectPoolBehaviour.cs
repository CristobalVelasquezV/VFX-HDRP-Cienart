using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;
    [SerializeField] private bool shouldExpand;
    private List<GameObject> pooledObjects;


    private void Start()
    {
        CreatePool();
    }
    public void CreatePool()
    {
        pooledObjects = new List<GameObject>();
        Debug.Log("Create pool bullets");
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool, transform);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if (shouldExpand)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            return obj;
        }

        return null;


    }
}