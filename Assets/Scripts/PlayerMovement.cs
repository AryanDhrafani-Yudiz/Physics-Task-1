using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private Vector2 forceToApply;
    private Vector2 screenBounds;
    [SerializeField] private float screenBoundsOffset;
    [SerializeField] private CameraMovement cmScript; 

    private void FixedUpdate()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        //Debug.Log(screenBounds);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x , -(screenBounds.x - screenBoundsOffset), (screenBounds.x - screenBoundsOffset)) , Mathf.Clamp(transform.position.y, -6f, (screenBounds.y - screenBoundsOffset)) , transform.position.z);
        //Debug.Log(Physics2D.gravity);
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
        
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    Physics2D.gravity = new Vector2(0, -5.0f);
        //    Debug.Log(Physics2D.gravity);
        //}
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    Physics2D.gravity = new Vector2(0, -15.0f);
        //    Debug.Log(Physics2D.gravity);
        //}
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    Physics2D.gravity = new Vector2(0, -9.8f);
        //    Debug.Log(Physics2D.gravity);
        //}
    }
    private void PlayerJump()
    {
        playerRigidBody.AddForce(forceToApply, ForceMode2D.Impulse);
    }

}
