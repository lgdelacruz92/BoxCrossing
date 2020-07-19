
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject truckRoadPrefab;

    void Start()
    {
        Instantiate(truckRoadPrefab,  truckRoadPrefab.GetComponent<Transform>().position, Quaternion.identity);    
    }
}
