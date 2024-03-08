using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Inst;

    [SerializeField] private int _numberOfEachObject;
    [SerializeField] private GameObject _prefab1;
    [SerializeField] private GameObject _prefab2;
    [SerializeField] private GameObject _prefab3;
    [SerializeField] private Transform parentObject;
    private int getRandomItem = 0;

    public List<GameObject> ListOfObjects;

    private void Awake()
    {
        Inst = this;
        CreateObjects();
    }
    public void CreateObjects()
    {
        ListOfObjects = new();
        GameObject tmp;

        for (int i = 0; i < _numberOfEachObject; i++)
        {
            tmp = Instantiate(_prefab1, parentObject , true);
            tmp.SetActive(false);
            ListOfObjects.Add(tmp);

            tmp = Instantiate(_prefab2, parentObject, true);
            tmp.SetActive(false);
            ListOfObjects.Add(tmp);

            tmp = Instantiate(_prefab3, parentObject, true);
            tmp.SetActive(false);
            ListOfObjects.Add(tmp);
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