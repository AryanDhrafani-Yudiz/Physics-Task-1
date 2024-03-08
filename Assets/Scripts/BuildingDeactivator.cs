using UnityEngine;

public class BuildingDeactivator : MonoBehaviour
{
    void OnBecameInvisible() // Doesnt Work If Scene View Is On or Shadows Are Being Casted
        {
            this.gameObject.SetActive(false);
            PlayerPools.Inst.SpawnBuilding(PlayerPools.Inst.FindNextPosition());
        }
}
