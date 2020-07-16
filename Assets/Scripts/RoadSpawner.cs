using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject roadPrefab;
    private GameObject ground1;
    private GameObject ground2;
    private Transform playerTransform;

    public RoadSpawner(GameObject ground1, GameObject ground2, Transform playerTransform)
    {
        this.ground1 = ground1;
        this.ground2 = ground2;
        this.playerTransform = playerTransform;
    }

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider roadCollider = roadPrefab.GetComponent<BoxCollider>();
        Transform roadTransform = roadPrefab.GetComponent<Transform>();

        float depth = (roadCollider.size.z * roadTransform.localScale.z);
        Vector3 pos = roadTransform.position;
        for (int i = 0; i < 10; i++)
        {
            Instantiate(roadPrefab, pos, Quaternion.identity);
            pos += new Vector3(0, 0, depth + 3);
        }
    }
}
