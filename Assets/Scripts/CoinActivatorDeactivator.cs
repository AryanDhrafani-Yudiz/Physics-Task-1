using UnityEngine;

public class CoinActivatorDeactivator : MonoBehaviour
{
    void OnBecameInvisible() // Doesnt Work If Scene View Is On or Shadows Are Being Casted
    {
        gameObject.SetActive(false);
    }
}
