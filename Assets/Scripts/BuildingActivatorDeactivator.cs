using UnityEngine;

public class BuildingActivatorDeactivator : MonoBehaviour
{
    void OnBecameInvisible() // Doesnt Work If Scene View Is On or Shadows Are Being Casted
        {
            gameObject.SetActive(false);
            BuildingPooling.Instance.SpawnBuilding(BuildingPooling.Instance.FindNextPosition());
        }
}
