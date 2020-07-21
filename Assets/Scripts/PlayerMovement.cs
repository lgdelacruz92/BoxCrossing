
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody playerRigidBody;

    public float jumpNudge;

    private bool jumping;
    private bool jump;

    private bool forward;
    private bool left;

    private bool right;
    private bool back;

    private Vector3 gravity;
    private float maxJumpHeight;

    private float jumpingOffTolerance;

    private void Start()
    {
        gravity = new Vector3(0, -355.55f, 0);
        Physics.gravity = gravity;
        maxJumpHeight = 4f;
        jumpingOffTolerance = 0.002f;
        jump = false;
        forward = false;
        left = false;
        right = false;
        back = false;
    }

    private void Update()
    {
        // Only jump win not jumping
        if (!jumping) {
            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                jump = true; // turn on jump
                forward = true; // turn on forward
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                jump = true; // turn on jump
                left = true; // turn on left;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)) {
                jump = true; // turn on jump
                right = true; // turn on right;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow)) {
                jump = true; // turn on jump
                back = true; // turn on back;
            }
        }
    }

    private void FixedUpdate()
    {
        // if player is on the floor
        if (playerTransform.position.y <= 0f + jumpingOffTolerance)
        {
            // if previously jumping
            if (jumping) {
                // if previously had forward on
                if (forward) {
                    forward = false; // turn off
                }

                // if previously had left on
                if (left) {
                    left = false;
                }

                // if previously had right on
                if (right) {
                    right = false;
                }

                // if previously had back on
                if (back) {
                    back = false;
                }
            }

            // not jumping
            jumping = false;

            // round z position to the closed integer position
            float zPos = playerTransform.position.z;
            if (zPos > 0) {
                float ceilZPos = Mathf.Ceil(zPos);
                float floorZPos = Mathf.Floor(zPos);
                if (ceilZPos - zPos < zPos - floorZPos) {
                    playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, ceilZPos);
                }
                else {
                    playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, floorZPos);
                }
            }
        }
        else
        {
            jumping = true;
        }

        // Handle jump
        if (jump) {
            playerRigidBody.AddForce(GetJumpForce());
            jump = false;
        }

        // Handle keyboard actions
        if (jumping) {
            if (forward) {
                playerRigidBody.AddForce(GetForwardForce());
            }

            if (left) {
                playerRigidBody.AddForce(GetLeftForce());
            }


            if (right) {
                playerRigidBody.AddForce(-1 * GetLeftForce());
            }

            if (back) {
                playerRigidBody.AddForce(-1 * GetForwardForce());
            }
        }

        if (playerTransform.position.y < -10) {
            Invoke("GameOver", 1);
        }
    }

    private Vector3 GetJumpForce()
    {
        float gravityDown = gravity.y;
        return new Vector3(0, -1 * (gravityDown / 2) * Mathf.Pow(maxJumpHeight, 2), 0);
    }

    private Vector3 GetLeftForce()
    {
        float gravityDown = gravity.y;
        return new Vector3(-1 * 4f / Mathf.Pow(0.3f, 2) + jumpNudge, 0, 0);
    }

    private Vector3 GetForwardForce() 
    {
        return new Vector3(0, 0, 4f / Mathf.Pow(0.3f, 2) + jumpNudge);
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "RoadObject") {
            GameObject objectCollidedWith = collisionInfo.gameObject;
            Vector3 objectsVelocity = objectCollidedWith.GetComponent<Rigidbody>().velocity;
            objectsVelocity /= objectsVelocity.magnitude;
            playerRigidBody.AddForce(objectsVelocity.x * 5000, 1000, 0);
            Invoke("GameOver", 1);
        }
    }

    private void GameOver() {

    }

}
