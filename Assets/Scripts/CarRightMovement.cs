
using UnityEngine;

public class CarRightMovement : MonoBehaviour
{
    public Rigidbody carRigidBody;
    public Transform carTranform;

    // Update is called once per frame
    void FixedUpdate()
    {
        carRigidBody.velocity = new Vector3(20, 0, 0);

        if (carTranform.position.x > 50)
        {
            carTranform.position = new Vector3(-50, carTranform.position.y, carTranform.position.z);
        }
    }
}
