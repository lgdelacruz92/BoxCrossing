
using UnityEngine;

public class TrucksRoad : MonoBehaviour
{
    public GameObject truckPrefab;

    void Start()
    {
        Instantiate(truckPrefab, truckPrefab.GetComponent<Transform>().position, Quaternion.identity);
    }
}
