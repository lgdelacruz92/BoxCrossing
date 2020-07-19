
using UnityEngine;

public class Game : MonoBehaviour
{
    public RoadFactory roadFactory;

    public RoadObjectFactory roadObjectFactory;

    private GameObject[] roads;

    private GameObject[] roadObjects;

    private int roadsSize;

    void Start()
    {   
        roadsSize = 20;
        roads = new GameObject[roadsSize];
        roadObjects = new GameObject[roadsSize];

        Color[] colors = new Color[]{Color.red, Color.gray, Color.green};
        for (int i = 0; i < roadsSize; i++) {
            Vector3 pos = new Vector3(0, -5.5f, i * 2 + 2);
            roads[i] = roadFactory.CreateRoad(pos, colors[i % colors.Length]);

            Vector3 velocity = new Vector3(-10, 0, 0);
            if (i % 2 == 1) {
                velocity = new Vector3(10, 0, 0);
            }
            roadObjects[i] = roadObjectFactory.CreateRoadObject(pos + new Vector3(0, 7, 0), velocity, colors[i % colors.Length], new Vector3(10, 2, 1.5f));
        }
    }

    void FixedUpdate()
    {
        for (int i = 0; i < roadsSize; i++) {
            if (roadObjects[i].GetComponent<Transform>().position.x < -50) {
                roadObjects[i].GetComponent<Transform>().position += new Vector3(100, 0, 0);
            }
            else if (roadObjects[i].GetComponent<Transform>().position.x > 50) {
                roadObjects[i].GetComponent<Transform>().position += new Vector3(-100, 0, 0);
            }
        }
    }
}
