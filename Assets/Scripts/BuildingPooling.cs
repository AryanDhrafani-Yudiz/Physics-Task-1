using UnityEngine;

public class BuildingPooling : MonoBehaviour
{
    public static BuildingPooling Instance;

    [SerializeField] private Transform prefab3Position;
    private float xOffset;
    private float currPosition;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    private void Start()
    {
        currPosition = prefab3Position.position.x;
        SpawnStartingBuilding();
        SpawnStartingBuilding();
        SpawnStartingBuilding();
        SpawnBuilding(FindNextPosition());
        SpawnBuilding(FindNextPosition());
    }
    public void SpawnStartingBuilding()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject Building = ObjectPooling.Instance.ObjectToPoolStarting();

            if (Building != null)
            {
                Building.SetActive(true);
                break;
            }
        }
    }

    public void SpawnBuilding(float position1)
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject Building = ObjectPooling.Instance.ObjectToPool();

            if (Building != null)
            {
                Building.transform.position = new Vector3(position1 , Building.transform.position.y , Building.transform.position.z);
                Building.SetActive(true);
                break;
            }
        }
    }
    public float FindNextPosition()
    {
        xOffset = Random.Range(3.5f, 4.5f);
        currPosition = currPosition + xOffset;
        return currPosition;
    }
}
