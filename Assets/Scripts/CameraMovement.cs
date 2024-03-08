using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float speedForCameraMovement;
    [SerializeField] private float xOffset;

    public void MoveCamera()
    {
        transform.position = Vector3.Lerp(transform.position , new Vector3(playerTransform.position.x + xOffset, transform.position.y, -10f), speedForCameraMovement * Time.deltaTime);
    }
}
