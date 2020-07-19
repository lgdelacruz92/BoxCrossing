
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerTransform;
    public Rigidbody playerRigidBody;

    public float jumpNudge;

    public Game game;

    private bool jumping;
    private bool jump;

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
    }

    private void Update()
    {
        if (playerTransform.position.y <= 0f + jumpingOffTolerance)
        {
            jumping = false;
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

        if (!jumping && Input.GetKeyDown(KeyCode.UpArrow)) {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        if (jump) {
            playerRigidBody.AddForce(GetJumpForce());
            jump = false;
        }

        if (jumping) {
            playerRigidBody.AddForce(GetForwardForce());
        }

        
    }

    private Vector3 GetJumpForce()
    {
        float gravityDown = gravity.y;
        return new Vector3(0, -1 * (gravityDown / 2) * Mathf.Pow(maxJumpHeight, 2), 0);
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
        game.GameOver();
    }

}
