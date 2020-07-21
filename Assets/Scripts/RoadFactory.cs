using UnityEngine;

public class RoadFactory : MonoBehaviour
{
    public GameObject roadPrefab;

    public GameObject CreateRoad(Vector3 pos, Color color) {
       GameObject road = Instantiate(roadPrefab, pos, Quaternion.identity);
       road.GetComponent<MeshRenderer>().material.color = color;
       return road;
    }
}