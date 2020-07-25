using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public Transform vehicleTransform;

    // Update is called once per frame
    void Update()
    {
        if (vehicleTransform.position.x > 50) {
            vehicleTransform.position -= new Vector3(100, 0, 0);
        }
        else if (vehicleTransform.position.x < -50) {
            vehicleTransform.position += new Vector3(100, 0, 0);
        }
    }
}
