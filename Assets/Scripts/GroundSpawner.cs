using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject groundPrefab;
    private GameObject groundObject;
    private GameObject groundObject2;
    private float currentGroundCount;
    private RoadSpawner roadSpawner;

    private void Start()
    {
        currentGroundCount = 0;
        groundObject = Instantiate(groundPrefab, new Vector3(0, 0, currentGroundCount), Quaternion.identity);
        groundObject2 = Instantiate(groundPrefab, new Vector3(0, 0, currentGroundCount + 100), Quaternion.identity);
        roadSpawner = new RoadSpawner(groundObject, groundObject2, playerTransform);
    }

    private void Update()
    {
        if (groundObject2 != null)
        {
            BoxCollider groundBox = groundObject2.GetComponent<BoxCollider>();
            Transform transform = groundObject2.GetComponent<Transform>();

            float treshHold = transform.position.z - ((groundBox.size.z * transform.localScale.z) / 2) * 0.8f;

            if (playerTransform.position.z > treshHold)
            {
                GameObject temp = groundObject;
                temp.GetComponent<Transform>().position = new Vector3(0, 0, currentGroundCount + 200);
                groundObject = groundObject2;
                groundObject2 = temp;
                currentGroundCount += 100;
            }
        }

    }
}
