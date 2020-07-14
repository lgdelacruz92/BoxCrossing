using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRigidBody;
    public Vector3 jumpForce;
    public Vector3 gravity;
    public Vector3 forwardForce;

    // Update is called once per frame
    void Start()
    {
        //    jumpForce = new Vector3(0, 2000, 0);
        //    gravity = new Vector3(0, -100, 0);
        //    forwardForce = new Vector3(0, 0, 500);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.AddForce(jumpForce);
            playerRigidBody.AddForce(forwardForce);
        }

        playerRigidBody.AddForce(gravity);
    }
}
