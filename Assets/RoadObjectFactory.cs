
using UnityEngine;

public class RoadObjectFactory : MonoBehaviour
{
    public GameObject roadObjectPrefab;

    public GameObject CreateRoadObject(Vector3 pos, Vector3 velocity, Color color, Vector3 size) {
        GameObject roadObject = Instantiate(roadObjectPrefab, pos, Quaternion.identity);
        roadObject.GetComponent<MeshRenderer>().material.color = color;
        roadObject.GetComponent<Transform>().localScale = size;
        roadObject.GetComponent<Rigidbody>().velocity = velocity;
        return roadObject;
    }
}
