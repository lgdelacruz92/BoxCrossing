using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform playerTranform;
    private Vector3 initialPlayerZ;

    private void Start()
    {
        initialPlayerZ = playerTranform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (initialPlayerZ != playerTranform.position)
        {
            cameraTransform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, cameraTransform.position.z + (playerTranform.position.z - initialPlayerZ.z));
            initialPlayerZ = playerTranform.position;
        }
    }
}
