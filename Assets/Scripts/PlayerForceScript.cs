using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForceScript : MonoBehaviour
{
    [SerializeField] private Transform childtransform;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private Vector2 forceToApply;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //playerRigidBody.AddForceAtPosition(forceToApply , childtransform.position);
            playerRigidBody.AddForce(forceToApply , ForceMode2D.Impulse);
        }
    }
}
