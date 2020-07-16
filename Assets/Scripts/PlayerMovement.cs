
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRigidBody;
    public Transform playerTransform;
    public MeshRenderer playerMeshRenderer;
    public Vector3 jumpForce;
    public Vector3 leftForce;
    public Vector3 rightForce;
    public Vector3 gravity;
    public Vector3 forwardForce;
    public int collisionForce;
    public bool jumping = false;

    private void Start()
    {
        Physics.gravity = gravity;
    }

    private void Update()
    {

        if (playerTransform.position.y > 2.3)
        {
            jumping = true;
        }
        else
        {
            jumping = false;
        }

        if (!jumping)
        {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                playerRigidBody.AddForce(jumpForce);
                playerRigidBody.AddForce(forwardForce);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerRigidBody.AddForce(jumpForce);
                playerRigidBody.AddForce(leftForce);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerRigidBody.AddForce(jumpForce);
                playerRigidBody.AddForce(rightForce);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerRigidBody.AddForce(jumpForce);
                playerRigidBody.AddForce(-1 * forwardForce);
            }

        }

        if (playerTransform.position.y < -10)
        {
            Invoke("PlayerDead", 1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.IndexOf("Car Right") != -1 || collision.collider.name.IndexOf("Car Left") != -1)
        {
            playerRigidBody.freezeRotation = false;
            if (collision.collider.name.IndexOf("Car Right") != -1)
            {
                playerRigidBody.AddForce(collisionForce, 30, 0);
            }
            else if (collision.collider.name.IndexOf("Car Left") != -1)
            {
                playerRigidBody.AddForce(-1 * collisionForce, 30, 0);
            }
            playerMeshRenderer.material.color = Color.red;
            Invoke("PlayerDead", 2f);
        }
    }

    private void PlayerDead()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.GameOver();
    }
}
