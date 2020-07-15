using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRigidBody;
    public Vector3 jumpForce;
    public Vector3 gravity;
    public Vector3 forwardForce;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidBody.AddForce(jumpForce);
            playerRigidBody.AddForce(forwardForce);
        }

        playerRigidBody.AddForce(gravity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Car Left" || collision.collider.name == "Car Right")
        {
            playerRigidBody.freezeRotation = false;
            if (collision.collider.name == "Car Right")
            {
                playerRigidBody.AddForce(5000, 0, 0);
            }
            else if (collision.collider.name == "Car Left")
            {
                playerRigidBody.AddForce(-5000, 0, 0);
            }
            Invoke("PlayerDead", 2f);
        } 
    } 

    private void PlayerDead()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.GameOver();
    }
}
