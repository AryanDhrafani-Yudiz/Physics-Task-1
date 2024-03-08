using UnityEngine;

public class BuildingActivatorDeactivator : MonoBehaviour
{
    void OnBecameInvisible() // Doesnt Work If Scene View Is On or Shadows Are Being Casted
        {
            this.gameObject.SetActive(false);
        BuildingPooling.Inst.SpawnBuilding(BuildingPooling.Inst.FindNextPosition());
        }
}
