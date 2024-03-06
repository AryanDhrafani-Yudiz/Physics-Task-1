using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private Transform childtransform;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private Vector2 forceToApply;
    private Vector2 screenBounds;
    private float offset = 0.6f;

    void Start()
    {
        //Physics2D.gravity = new Vector2(0, -9.8f);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Debug.Log(screenBounds.y);
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-(screenBounds.x - offset), (screenBounds.x - offset)), Mathf.Clamp(transform.position.y, -6f, (screenBounds.y - offset)), transform.position.z);
        //Debug.Log(Physics2D.gravity);
    }
    void Update()
    {
        if (Input.mousePresent)
        {
            if (Input.GetMouseButtonDown(0))    // When First Clicked At A Point On Screen
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
                if (touch.phase == TouchPhase.Began)    // When First Clicked At A Point On Screen
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
