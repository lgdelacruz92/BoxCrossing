
using UnityEngine;

public class CarRightMovement : MonoBehaviour
{
    public Rigidbody carRigidBody;
    public Transform carTranform;
    public MeshRenderer carMeshRenderer;
    public float velocity;
    private static Color[] colors = new Color[] { Color.red, Color.magenta, Color.yellow, Color.blue, Color.green, Color.cyan, Color.gray, Color.black };

    private void Start()
    {
        int colorIndex = Mathf.FloorToInt(Random.value * colors.Length);
        carMeshRenderer.material.color = colors[colorIndex];

        if (velocity == 0)
        {
            velocity = 10;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        carRigidBody.velocity = new Vector3(velocity, 0, 0);

        if (carTranform.position.x > 50)
        {
            carTranform.position = new Vector3(-50, carTranform.position.y, carTranform.position.z);
        }
    }
}
