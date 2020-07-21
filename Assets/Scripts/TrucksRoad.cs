
using UnityEngine;
using System.Collections.Generic;

public class TrucksRoad : MonoBehaviour
{
    public GameObject truckPrefab;

    private GameObject[] trucks;

    private int size;

    void Start()
    {
        size = 10;
        trucks = new GameObject[size];
        Dictionary<float, Vector3> takenPos = new Dictionary<float, Vector3>();

        for (int i = 0; i < size; i++) {
            Vector3 pos = RandomPosition();

            while (takenPos.ContainsKey(pos.x)) {
                pos = RandomPosition();
            }

            takenPos[pos.x] = pos;
        }

        if (takenPos.Count == size) {
            int i = 0;
            foreach (var randomPos in takenPos) {
                trucks[i] = Instantiate(truckPrefab, randomPos.Value, Quaternion.identity);
                trucks[i].GetComponent<Rigidbody>().velocity = new Vector3(10, 0, 0);
                i+= 1;
            }
        }

    }

    void Update()
    {
        for (int i = 0; i < size; i++)
        {
            if (trucks[i].GetComponent<Transform>().position.x > 50)
            {
                trucks[i].GetComponent<Transform>().position -= new Vector3(100, 0, 0);
            }
        }

    }

    Vector3 RandomPosition()
    {
        Vector3 pos = truckPrefab.GetComponent<Transform>().position;
        float randValue = (Mathf.FloorToInt(Random.value * 100) - 50);
        return pos += new Vector3(randValue, 0, 0);
    }

}
