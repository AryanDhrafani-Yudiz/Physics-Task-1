using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;

    [SerializeField] private int numberOfEachObject;
    [SerializeField] private GameObject prefab1;
    [SerializeField] private GameObject prefab2;
    [SerializeField] private GameObject prefab3;
    [SerializeField] private Transform parentObject;

    private int getRandomItem = 0;
    
    public List<GameObject> ListOfObjects;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        CreateObjects();
    }

    public void CreateObjects()
    {
        ListOfObjects = new();
        GameObject temp;

        for (int i = 0; i < numberOfEachObject; i++)
        {
            temp = Instantiate(prefab1, parentObject , true);
            temp.SetActive(false);
            ListOfObjects.Add(temp);

            temp = Instantiate(prefab2, parentObject, true);
            temp.SetActive(false);
            ListOfObjects.Add(temp);

            temp = Instantiate(prefab3, parentObject, true);
            temp.SetActive(false);
            ListOfObjects.Add(temp);
        }
    }
    public GameObject ObjectToPool()
    {
        for (int i = 0; i < ListOfObjects.Count; i++)
        {
            getRandomItem = Random.Range(0, ListOfObjects.Count);

            if (!ListOfObjects[getRandomItem].activeInHierarchy)
            {
                return ListOfObjects[getRandomItem];
            }
        }
        return null;
    }
    public GameObject ObjectToPoolStarting()
    {
        for (int i = 0; i < 3; i++)
        {
            if (!ListOfObjects[i].activeInHierarchy)
            {
                return ListOfObjects[i];
            }
        }
        return null;
    }
}