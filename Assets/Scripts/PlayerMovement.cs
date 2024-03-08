using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private Vector2 forceToApply;
    private Vector2 screenBounds;
    [SerializeField] private float screenBoundsOffset;
    [SerializeField] private CameraMovement cmScript;

    private void Awake()
    {
        Application.targetFrameRate = 120;
    }
    private void FixedUpdate()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x , -(screenBounds.x - screenBoundsOffset), (screenBounds.x - screenBoundsOffset)) , Mathf.Clamp(transform.position.y, -6f, (screenBounds.y - screenBoundsOffset)) , transform.position.z);
        if (playerRigidBody.velocity == Vector2.zero)
        {
            cmScript.MoveCamera();
        }
    }
    void Update()
    {
        if (Input.mousePresent)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    PlayerJump();
                }
            }
        }
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (!EventSystem.current.IsPointerOverGameObject(0))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    PlayerJump();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainLevel", LoadSceneMode.Single);
        }
    }
    private void PlayerJump()
    {
        playerRigidBody.AddForce(forceToApply, ForceMode2D.Impulse);
    }

}
