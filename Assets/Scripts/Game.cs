using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public RoadFactory roadFactory;

    public RoadObjectFactory roadObjectFactory;

    private GameObject[] roads;

    private List<List<GameObject>> roadObjects;

    public int roadsSize;

    void Start()
    {   
        roads = new GameObject[roadsSize];
        roadObjects = new List<List<GameObject>>();

        Color[] colors = new Color[]{Color.red, Color.gray, Color.green};
        for (int i = 0; i < roadsSize; i++) {
            Vector3 pos = new Vector3(0, -5.5f, i * 2 + 2);
            Color color = colors[i % colors.Length];
            roads[i] = roadFactory.CreateRoad(pos, color);

            Vector3 velocity = new Vector3(-10, 0, 0);
            if (i % 2 == 1) {
                velocity = new Vector3(10, 0, 0);
            }

            int numRoadObjects = (int)Mathf.Floor(Random.value * 5) + 1;
            List<GameObject> newRoadObjects = new List<GameObject>();
            for (int l = 0; l < numRoadObjects; l++) {
                newRoadObjects.Add(roadObjectFactory.CreateRoadObject(pos + new Vector3(pos.x + 30 * l, 6, 0), velocity, color, new Vector3(5, 2, 1.5f)));
            }
            roadObjects.Add(newRoadObjects);
        }
    }

    void FixedUpdate()
    {
        foreach (var road in roadObjects) {
            foreach(var roadObject in road) {
                if (roadObject.GetComponent<Transform>().position.x < -50) {
                    roadObject.GetComponent<Transform>().position += new Vector3(100, 0, 0);
                }
                else if (roadObject.GetComponent<Transform>().position.x > 50) {
                    roadObject.GetComponent<Transform>().position += new Vector3(-100, 0, 0);
                }
            }
        }
    }
}
