using UnityEngine;
using UnityEngine.UIElements;

public class BuildingPooling : MonoBehaviour
{
    public static BuildingPooling Instance;

    [SerializeField] private Transform prefab3Position;
    private float xOffset;
    private float currPosition;
    private int count = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    private void Start()
    {
        currPosition = prefab3Position.position.x;
        SpawnStartingBuilding();
        SpawnBuilding(FindNextPosition());
        SpawnBuilding(FindNextPosition());
        SpawnBuilding(FindNextPosition());
    }
    public void SpawnStartingBuilding()
    {
        while(count<3)
        {
            GameObject Building = ObjectPooling.Instance.BuildingObjectToPoolStarting();

            if (Building != null)
            {
                Building.SetActive(true);
            }
            count++;
        }
    }

    public void SpawnBuilding(float position1)
    {
        GameObject Building = ObjectPooling.Instance.BuildingObjectToPool();

        if (Building != null)
        {
            Building.transform.position = new Vector3(position1 , Building.transform.position.y , Building.transform.position.z);
            Building.SetActive(true);
            if (Mathf.Floor(Random.Range(0,1)) == 0)
            {
            SpawnCoin(Building.transform.position);
            }
        }
    }
    public float FindNextPosition()
    {
        xOffset = Random.Range(3.5f, 4.5f);
        currPosition = currPosition + xOffset;
        return currPosition;
    }
    public void SpawnCoin(Vector3 position)
    {
        GameObject Coin = ObjectPooling.Instance.CoinsObjectToPool();

        if (Coin != null)
        {
            Coin.transform.position = new Vector3(position.x , position.y + 3f , position.z);
            Coin.SetActive(true);
        }
    }
}
