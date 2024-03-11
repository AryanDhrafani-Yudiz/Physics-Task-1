using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;

    [SerializeField] private int numberOfBuildingObject;
    [SerializeField] private GameObject buildingPrefab1;
    [SerializeField] private GameObject buildingPrefab2;
    [SerializeField] private GameObject buildingPrefab3;
    [SerializeField] private Transform buildingParentObject;
    [SerializeField] private int numberOfCoinObject;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform coinParentObject;

    private int getRandomItem = 0;
    
    public List<GameObject> ListOfBuildingObjects;
    public List<GameObject> ListOfCoinObjects;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        CreateBuildingObjects();
        CreateCoinObjects();
    }

    public void CreateBuildingObjects()
    {
        ListOfBuildingObjects = new();
        GameObject temp;

        for (int i = 0; i < numberOfBuildingObject; i++)
        {
            temp = Instantiate(buildingPrefab1, buildingParentObject , true);
            temp.SetActive(false);
            ListOfBuildingObjects.Add(temp);

            temp = Instantiate(buildingPrefab2, buildingParentObject, true);
            temp.SetActive(false);
            ListOfBuildingObjects.Add(temp);

            temp = Instantiate(buildingPrefab3, buildingParentObject, true);
            temp.SetActive(false);
            ListOfBuildingObjects.Add(temp);

        }
    }
    public void CreateCoinObjects()
    {
        ListOfCoinObjects = new();
        GameObject temp;

        for (int i = 0; i < numberOfCoinObject; i++)
        {
            temp = Instantiate(coinPrefab, coinParentObject, true);
            temp.SetActive(false);
            ListOfCoinObjects.Add(temp);
        }
    }
    public GameObject BuildingObjectToPool()
    {
        for (int i = 0; i < ListOfBuildingObjects.Count; i++)
        {
            getRandomItem = Random.Range(0, ListOfBuildingObjects.Count);

            if (!ListOfBuildingObjects[getRandomItem].activeInHierarchy)
            {
                return ListOfBuildingObjects[getRandomItem];
            }
        }
        return null;
    }
    public GameObject BuildingObjectToPoolStarting()
    {
        for (int i = 0; i < 3; i++)
        {
            if (!ListOfBuildingObjects[i].activeInHierarchy)
            {
                return ListOfBuildingObjects[i];
            }
        }
        return null;
    }
    public GameObject CoinsObjectToPool()
    {
        for (int i = 0; i < ListOfCoinObjects.Count; i++)
        {
            if (!ListOfCoinObjects[i].activeInHierarchy)
            {
                return ListOfCoinObjects[i];
            }
        }
        return null;
    }
}